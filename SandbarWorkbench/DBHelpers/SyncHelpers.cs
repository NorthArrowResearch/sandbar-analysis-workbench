using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DBHelpers
{
    class SyncHelpers
    {
        public string SchemaName { get; internal set; }
        public string MasterDBCon { get; internal set; }
        public string LocalDBCon { get; internal set; }

        public SyncHelpers(string sSchemaName, string sMasterDBCon, string sLocalDBCon)
        {
            Init(sSchemaName, sMasterDBCon, sLocalDBCon);
        }

        public SyncHelpers()
        {
            Init("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);
        }

        private void Init(string sSchemaName, string sMasterDBCon, string sLocalDBCon)
        {
            SchemaName = sSchemaName;
            MasterDBCon = sMasterDBCon;
            LocalDBCon = sLocalDBCon;
        }

        public void SynchronizeDatabaseType(long nTableTypeID)
        {
            using (MySqlConnection conMaster = new MySqlConnection(MasterDBCon))
            {
                conMaster.Open();

                // Retrieve the list of lookup tables that should be synced
                List<LookupTableDef> LookupTables = new List<LookupTableDef>();
                MySqlCommand dbCom = new MySqlCommand("SELECT TableName FROM TableChangeLog WHERE (Synchronize <> 0) AND (TableTypeID = @TableTypeID) ORDER BY Sequence", conMaster);
                dbCom.Parameters.AddWithValue("TableTypeID", nTableTypeID);
                MySqlDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                    LookupTables.Add(new LookupTableDef(dbRead.GetString("TableName")));
                dbRead.Close();

                using (SQLiteConnection conLocal = new SQLiteConnection(LocalDBCon))
                {
                    conLocal.Open();
                    SQLiteTransaction dbTrans = conLocal.BeginTransaction();

                    try
                    {
                        foreach (LookupTableDef aTable in LookupTables)
                        {
                            // Load the last changed and field schema from both master and local. Then verify that the schemas match (will throw exception if fails)
                            aTable.RetrievePropertiesFromMaster(SchemaName, conMaster);
                            aTable.RetrievePropertiesFromLocal(conLocal);
                            aTable.VerifySchemasMatch();

                            // A sync is needed if the local has never been synced or the latest change date on master is newer than local
                            if (aTable.RequiresSync)
                            {
                                bool bSuccessfulSync = false;
                                if (nTableTypeID == SandbarWorkbench.Properties.Settings.Default.TableType_LookupTables)
                                    bSuccessfulSync = SynchronizeLookupTable(conMaster, ref dbTrans, aTable);
                                else
                                    bSuccessfulSync = SynchronizeResultsTable(conMaster, ref dbTrans, aTable);

                                if (bSuccessfulSync)
                                {
                                    // Update the local TableChangeLog to reflect the update
                                    SQLiteCommand cLocal = new SQLiteCommand("UPDATE TableChangeLog SET UpdatedOn = @UpdatedOn WHERE TableName = @TableName", conLocal, dbTrans);
                                    cLocal.Parameters.AddWithValue("UpdatedOn", aTable.MasterLastChanged.Value);
                                    cLocal.Parameters.AddWithValue("TableName", aTable.TableName);
                                    if (cLocal.ExecuteNonQuery() != 1)
                                        throw new Exception("Error updating the TableChangeLog on local");
                                }
                            }
                        }

                        dbTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        throw;
                    }
                }
            }
        }

        private bool SynchronizeLookupTable(MySqlConnection conMaster, ref SQLiteTransaction dbTrans, LookupTableDef aTable)
        {
            // Query for checking if row exists on master
            MySqlCommand cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), conMaster);
            MySqlParameter pMaster_PrimaryKey = cReadMaster.Parameters.Add(aTable.MasterPrimaryKey, MySqlDbType.Int64);

            SQLiteCommand comUpdateLocal = aTable.BuildUpdateCommand(ref dbTrans);

            // Query for deleting local rows
            SQLiteCommand comDeleteLocal = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
            SQLiteParameter pDelete_PrimaryKey = comDeleteLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.Int64);

            // Connection to read local rows (needs to be separate to the connection used to insert/update/delete rows)
            using (SQLiteConnection conReadLocal = new SQLiteConnection(LocalDBCon))
            {
                conReadLocal.Open();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 1 - loop over rows on local. Update them if they are newer on master and delete them if they don't exist on master

                // Loop over all rows in local table
                SQLiteCommand comReadLocal = new SQLiteCommand(string.Format("SELECT {0}, UpdatedOn FROM {1}", aTable.MasterPrimaryKey, aTable.TableName), conReadLocal);
                SQLiteDataReader readLocal = comReadLocal.ExecuteReader();
                while (readLocal.Read())
                {
                    pMaster_PrimaryKey.Value = readLocal.GetInt64(readLocal.GetOrdinal(aTable.MasterPrimaryKey));
                    MySqlDataReader dbReadMaster = cReadMaster.ExecuteReader();
                    if (dbReadMaster.Read())
                    {
                        // This row currently exists on both local and master. Check it's update date
                        if (dbReadMaster.GetDateTime("UpdatedOn") > readLocal.GetDateTime(readLocal.GetOrdinal("UpdatedOn")))
                        {
                            // The row on Master has been updated more recently than the row on local. Update local.
                            foreach (SQLiteParameter aParam in comUpdateLocal.Parameters)
                                aParam.Value = dbReadMaster[aParam.ParameterName];

                            aTable.LocalUpdates += comUpdateLocal.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // This row exists on local but not on master. Delete the local copy.
                        pDelete_PrimaryKey.Value = readLocal.GetInt64(readLocal.GetOrdinal(aTable.MasterPrimaryKey));
                        aTable.LocalDeletes += comDeleteLocal.ExecuteNonQuery();
                    }
                    dbReadMaster.Close();
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 2 - loop over rows on master. Insert them into local if their added on date is newer than the date that local was last updated.

                // Query to lookup a single row in local
                SQLiteCommand comSelectLocal = new SQLiteCommand(string.Format("SELECT {0} FROM {1} WHERE {0} = @{0}", aTable.MasterPrimaryKey, aTable.TableName), conReadLocal);
                SQLiteParameter pPrimaryKey = comSelectLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.Int64);

                // Prepared command to insert local records
                SQLiteCommand comInsertLocal = aTable.BuildInsertCommand(ref dbTrans);

                // Loop over rows in master and find those that are not in local.
                // Note that the UpdatedOn > @UpdatedOn is not strickly necessary, but it does help when old records on master are missing from local due to developer manual manipulation
                cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE (AddedOn > @UpdatedOn) OR (UpdatedOn > @UpdatedOn)", aTable.TableName), conMaster);
                cReadMaster.Parameters.AddWithValue("@UpdatedOn", aTable.LocalLastChanged);
                MySqlDataReader dbReadMasterNew = cReadMaster.ExecuteReader();
                while (dbReadMasterNew.Read())
                {
                    pPrimaryKey.Value = dbReadMasterNew.GetInt64(aTable.MasterPrimaryKey);
                    object objPrimaryKey = comSelectLocal.ExecuteScalar();
                    if (objPrimaryKey == null)
                    {
                        // Insert missing row into local
                        foreach (SQLiteParameter aParam in comInsertLocal.Parameters)
                            aParam.Value = dbReadMasterNew[aParam.ParameterName];

                        aTable.LocalInserts += comInsertLocal.ExecuteNonQuery();
                    }
                }
                dbReadMasterNew.Close();

            }

            System.Diagnostics.Debug.Print("{0} inserts = {1}, updates = {2}, deletes = {3}", aTable.TableName, aTable.LocalInserts, aTable.LocalUpdates, aTable.LocalDeletes);
            return aTable.LocalChanges;
        }

        private bool SynchronizeResultsTable(MySqlConnection conMaster, ref SQLiteTransaction dbTrans, LookupTableDef aTable)
        {
            return aTable.LocalChanges;
        }
    }
}
