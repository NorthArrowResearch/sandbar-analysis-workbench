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
        public string MasterDBCon { get; internal set; }
        public string LocalDBCon { get; internal set; }

        private List<LookupTableDef> LookupTables;

        public SyncHelpers(string sMasterDBCon, string sLocalDBCon)
        {
            MasterDBCon = sMasterDBCon;
            LocalDBCon = sLocalDBCon;

            LookupTables = new List<LookupTableDef>();
            LookupTables.Add(new LookupTableDef("Sites", "SiteID"));
        }

        public void SyncLookupData()
        {
            using (MySqlConnection conMaster = new MySqlConnection(MasterDBCon))
            {
                conMaster.Open();

                using (SQLiteConnection conLocal = new SQLiteConnection(LocalDBCon))
                {
                    conLocal.Open();

                    foreach (LookupTableDef aTable in LookupTables)
                    {
                        MySqlCommand cMasterChange = new MySqlCommand("SELECT UpdatedOn FROM TableChangeLog WHERE TableName = @TableName", conMaster);
                        cMasterChange.Parameters.AddWithValue("TableName", aTable.TableName);
                        object objMasterchanged = cMasterChange.ExecuteScalar();
                        if (objMasterchanged != null && objMasterchanged is DateTime)
                        {
                            aTable.MasterLastChanged = (DateTime)objMasterchanged;
                        }
                        else
                            throw new Exception("TODO: No records in master table.");

                        SQLiteCommand cLocalChanged = new SQLiteCommand("SELECT CASE WHEN UpdatedOn IS NULL THEN '1970-01-01 00:00:00' ELSE UpdatedOn END FROM TableChangeLog WHERE TableName = @TableName", conLocal);
                        cLocalChanged.Parameters.AddWithValue("TableName", aTable.TableName);
                        object objLocalChanged = cLocalChanged.ExecuteScalar();
                        DateTime dtTemp;
                        if (objLocalChanged != null && DateTime.TryParse(objLocalChanged.ToString(), out dtTemp))
                        {
                            aTable.LocalLastChanged = dtTemp;
                        }
                        else
                            throw new Exception("TODO: local is empty");

                        // A sync is needed if the local has never been synced or the latest change date on master is newer than local
                        if (aTable.RequiresSync)
                        {
                            SQLiteTransaction dbTrans = conLocal.BeginTransaction();

                            try
                            {
                                Step01_DeleteOldData(conMaster, ref dbTrans, aTable.LocalLastChanged.Value);

                                // Update the local TableChangeLog to reflect the update
                                SQLiteCommand cLocal = new SQLiteCommand("UPDATE TableChangeLog SET UpdatedOn = @UpdatedOn WHERE TableName = @TableName", conLocal, dbTrans);
                                cLocal.Parameters.AddWithValue("UpdatedOn", aTable.MasterLastChanged.Value);
                                cLocal.Parameters.AddWithValue("TableName", aTable.TableName);
                                if (cLocal.ExecuteNonQuery() != 1)
                                    throw new Exception("Error updating the TableChangeLog on local");

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
            }
        }

        private DatabaseChanges Step01_DeleteOldData(MySqlConnection conMaster, ref SQLiteTransaction dbTrans, LookupTableDef aTable)
        {
            DatabaseChanges changeCounter = new DatabaseChanges();

            // Query for checking if row exists on master
            MySqlCommand cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), conMaster);
            MySqlParameter pMaster_PrimaryKey = cReadMaster.Parameters.Add(aTable.MasterPrimaryKey, MySqlDbType.Int64);

            // Query for updating local rows
            SQLiteCommand comUpdateLocal = new SQLiteCommand(string.Format("UPDATE {0} SET UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy, Title = @Title WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
            SQLiteParameter pUpdate_UpdatedOn = comUpdateLocal.Parameters.Add("UpdatedOn", System.Data.DbType.DateTime);
            SQLiteParameter pUpdate_UpdatedBy = comUpdateLocal.Parameters.Add("UpdatedBy", System.Data.DbType.String);
            SQLiteParameter pUpdate_Title = comUpdateLocal.Parameters.Add("Title", System.Data.DbType.String);
            SQLiteParameter pUpdate_PrimaryKey = comUpdateLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.UInt64);

            // Query for deleting local rows
            SQLiteCommand comDeleteLocal = new SQLiteCommand(string.Format("DELETE FROM {0} WHERE {1} = @{1}",aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
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
                            pUpdate_UpdatedOn.Value = dbReadMaster.GetDateTime("UpdatedOn");
                            pUpdate_UpdatedBy.Value = dbReadMaster.GetString("UpdatedBy");
                            pUpdate_Title.Value = dbReadMaster.GetString("Title");
                            pUpdate_PrimaryKey.Value = dbReadMaster.GetInt64(aTable.MasterPrimaryKey);
                            changeCounter.Updated += comUpdateLocal.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // This row exists on local but not on master. Delete the local copy.
                        pDelete_PrimaryKey.Value = readLocal.GetInt64(readLocal.GetOrdinal(aTable.MasterPrimaryKey));
                        changeCounter.Deleted += comDeleteLocal.ExecuteNonQuery();
                    }
                    dbReadMaster.Close();
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // PHASE 2 - loop over rows on master. Insert them into local if their added on date is newer than the date that local was last updated.

                // Query to lookup a single row in local
                SQLiteCommand comSelectLocal = new SQLiteCommand(string.Format("SELECT {0} FROM {1} WHERE {0} = @{0}",aTable.MasterPrimaryKey,aTable.TableName), conReadLocal);
                SQLiteParameter pPrimaryKey = comSelectLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.Int64);

                // Prepared command to insert local records
                SQLiteCommand comInsertLocal = new SQLiteCommand(string.Format("INSERT INTO {0} ({1}, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (@{1}, @Title, @AddedOn, @AddedBy, @UpdatedOn, @UpdatedBy)",aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
                SQLiteParameter pInsert_PrimaryKey = comInsertLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.UInt64);
                SQLiteParameter pInsert_Title = comInsertLocal.Parameters.Add("Title", System.Data.DbType.String);
                SQLiteParameter pInsert_AddedOn = comInsertLocal.Parameters.Add("AddedOn", System.Data.DbType.DateTime);
                SQLiteParameter pInsert_AddedBy = comInsertLocal.Parameters.Add("AddedBy", System.Data.DbType.String);
                SQLiteParameter pInsert_UpdatedOn = comInsertLocal.Parameters.Add("UpdatedOn", System.Data.DbType.DateTime);
                SQLiteParameter pInsert_UpdatedBy = comInsertLocal.Parameters.Add("UpdatedBy", System.Data.DbType.String);

                // Loop over rows in master and find those that 
                cReadMaster = new MySqlCommand(string.Format("SELECT * FROM {0} WHERE AddedOn > @UpdatedOn", aTable.TableName), conMaster);
                cReadMaster.Parameters.AddWithValue("@UpdatedOn", aTable.LocalLastChanged);
                MySqlDataReader dbReadMasterNew = cReadMaster.ExecuteReader();
                while (dbReadMasterNew.Read())
                {
                    pPrimaryKey.Value = dbReadMasterNew.GetInt64(aTable.MasterPrimaryKey);
                    object objPrimaryKey = comSelectLocal.ExecuteScalar();
                    if (objPrimaryKey == null)
                    {
                        // Insert missing row into local
                        pInsert_PrimaryKey.Value = dbReadMasterNew.GetInt64(aTable.MasterPrimaryKey);
                        pInsert_Title.Value = dbReadMasterNew.GetString("Title");
                        pInsert_AddedOn.Value = dbReadMasterNew.GetDateTime("AddedOn");
                        pInsert_AddedBy.Value = dbReadMasterNew.GetString("AddedBy");
                        pInsert_UpdatedOn.Value = dbReadMasterNew.GetDateTime("UpdatedOn");
                        pInsert_UpdatedBy.Value = dbReadMasterNew.GetString("UpdatedBy");
                        changeCounter.Inserted += comInsertLocal.ExecuteNonQuery();
                    }
                }
                dbReadMasterNew.Close();

            }

            System.Diagnostics.Debug.Print(changeCounter.ToString());
            return changeCounter;
        }

        public class DatabaseChanges
        {
            public int Inserted { get; set; }
            public int Updated { get; set; }
            public int Deleted { get; set; }

            public DatabaseChanges()
            {
                Inserted = 0;
                Updated = 0;
                Deleted = 0;
            }

            public override string ToString()
            {
                return string.Format("{0} Inserted, {1} Updated, {2} Deleted", Inserted, Updated, Deleted);
            }
        }

        public class LookupTableDef
        {
            public string TableName { get; internal set; }
            public string MasterPrimaryKey { get; internal set; }

            public Nullable<DateTime> LocalLastChanged { get; set; }
            public Nullable<DateTime> MasterLastChanged { get; set; }

            public bool RequiresSync
            {
                get
                {
                    return LocalLastChanged.HasValue || MasterLastChanged > LocalLastChanged;
                }
            }
            public LookupTableDef(string sTableName, string sMasterPrimaryKey)
            {
                TableName = sTableName;
                MasterPrimaryKey = sMasterPrimaryKey;
                LocalLastChanged = new Nullable<DateTime>();
                MasterLastChanged = new Nullable<DateTime>();
            }

            public override string ToString()
            {
                return string.Format("{0}, PK = {1}", TableName, MasterPrimaryKey);
            }
        }

    }
}
