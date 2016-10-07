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
            LookupTables.Add(new LookupTableDef("Sites"));
        }

        public void SyncLookupData()
        {
            using (MySqlConnection conMaster = new MySqlConnection(MasterDBCon))
            {
                conMaster.Open();

                using (SQLiteConnection conLocal = new SQLiteConnection(LocalDBCon))
                {
                    conLocal.Open();
                    SQLiteTransaction dbTrans = conLocal.BeginTransaction();

                    try
                    {
                        foreach (LookupTableDef aTable in LookupTables)
                        {
                            // Load the last changed and field schema from both master and local. Then verify that the schemas match (will throw exception if fails)
                            aTable.RetrievePropertiesFromMaster(conMaster);
                            aTable.RetrievePropertiesFromLocal(conLocal);
                            aTable.VerifySchemasMatch();

                            // A sync is needed if the local has never been synced or the latest change date on master is newer than local
                            if (aTable.RequiresSync)
                            {
                                if (SynchronizeLookupTable(conMaster, ref dbTrans, aTable))
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

            // Query for updating local rows
            SQLiteCommand comUpdateLocal = new SQLiteCommand(string.Format("UPDATE {0} SET UpdatedOn = @UpdatedOn, UpdatedBy = @UpdatedBy, Title = @Title WHERE {1} = @{1}", aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
            SQLiteParameter pUpdate_UpdatedOn = comUpdateLocal.Parameters.Add("UpdatedOn", System.Data.DbType.DateTime);
            SQLiteParameter pUpdate_UpdatedBy = comUpdateLocal.Parameters.Add("UpdatedBy", System.Data.DbType.String);
            SQLiteParameter pUpdate_Title = comUpdateLocal.Parameters.Add("Title", System.Data.DbType.String);
            SQLiteParameter pUpdate_PrimaryKey = comUpdateLocal.Parameters.Add(aTable.MasterPrimaryKey, System.Data.DbType.UInt64);

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
                            pUpdate_UpdatedOn.Value = dbReadMaster.GetDateTime("UpdatedOn");
                            pUpdate_UpdatedBy.Value = dbReadMaster.GetString("UpdatedBy");
                            pUpdate_Title.Value = dbReadMaster.GetString("Title");
                            pUpdate_PrimaryKey.Value = dbReadMaster.GetInt64(aTable.MasterPrimaryKey);
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
                SQLiteCommand comInsertLocal = new SQLiteCommand(string.Format("INSERT INTO {0} ({1}, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy) VALUES (@{1}, @Title, @AddedOn, @AddedBy, @UpdatedOn, @UpdatedBy)", aTable.TableName, aTable.MasterPrimaryKey), dbTrans.Connection, dbTrans);
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
                        aTable.LocalInserts += comInsertLocal.ExecuteNonQuery();
                    }
                }
                dbReadMasterNew.Close();

            }

            System.Diagnostics.Debug.Print("{0} inserts = {1}, updates = {2}, deletes = {3}", aTable.TableName, aTable.LocalInserts, aTable.LocalUpdates, aTable.LocalDeletes);
            return aTable.LocalChanges;
        }

        public class LookupTableDef
        {
            public string TableName { get; internal set; }
            public string MasterPrimaryKey { get; internal set; }
            private string LocalPrimaryKey { get; set; }

            public Nullable<DateTime> LocalLastChanged { get; set; }
            public Nullable<DateTime> MasterLastChanged { get; set; }

            public Dictionary<string, FieldDef> MasterFields { get; internal set; }
            // The local fields are used internally only. External code should just use the master fields
            private Dictionary<string, FieldDef> LocalFields { get; set; }

            public int LocalInserts { get; set; }
            public int LocalUpdates { get; set; }
            public int LocalDeletes { get; set; }

            public bool RequiresSync
            {
                get
                {
                    return !LocalLastChanged.HasValue || MasterLastChanged > LocalLastChanged;
                }
            }

            public bool LocalChanges
            {
                get
                {
                    return (LocalInserts > 0) || (LocalUpdates > 0) || (LocalDeletes > 0);
                }
            }

            public LookupTableDef(string sTableName)
            {
                TableName = sTableName;
                LocalLastChanged = new Nullable<DateTime>();
                MasterLastChanged = new Nullable<DateTime>();
                MasterFields = new Dictionary<string, FieldDef>();
                LocalFields = new Dictionary<string, FieldDef>();
            }

            public void RetrievePropertiesFromMaster(MySqlConnection dbCon)
            {
                MySqlCommand dbCom = new MySqlCommand("SELECT UpdatedOn FROM TableChangeLog WHERE TableName = @TableName", dbCon);
                dbCom.Parameters.AddWithValue("TableName", TableName);

                object objMasterchanged = dbCom.ExecuteScalar();
                if (objMasterchanged != null && objMasterchanged is DateTime)
                {
                    MasterLastChanged = (DateTime)objMasterchanged;
                }
                else
                {
                    Exception ex = new Exception("Failed to load lookup table from MASTER TableChangeLog.");
                    ex.Data["TableName"] = TableName;
                    ex.Data["Connection"] = dbCon.ConnectionString;
                    throw ex;
                }

                // Attempt to determine the look up table schema
                dbCom = new MySqlCommand(string.Format("SELECT COLUMN_NAME, DATA_TYPE, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_SCHEMA = 'SandbarTest') AND (TABLE_NAME = 'Sites')", TableName), dbCon);
                MySqlDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("COLUMN_KEY")) && string.Compare(dbRead.GetString("COLUMN_Key"), "PRI", true) == 0)
                    {
                        MasterPrimaryKey = dbRead.GetString("COLUMN_NAME");
                    }
                    else
                    {
                        System.Data.DbType theDataType;
                        switch (dbRead.GetString("DATA_TYPE").ToLower())
                        {
                            case "int":
                                theDataType = System.Data.DbType.UInt64;
                                break;

                            case "varchar":
                                theDataType = System.Data.DbType.String;
                                break;

                            case "datetime":
                                theDataType = System.Data.DbType.DateTime;
                                break;

                            default:
                                throw new Exception(string.Format("Unhandled database field type '{0}'", dbRead.GetString("DATA_TYPE")));

                        }

                        MasterFields[dbRead.GetString("COLUMN_NAME")] = new FieldDef(dbRead.GetString("COLUMN_NAME"), theDataType);
                    }
                }

                // Verify that the table has a primary key defined.
                if (string.IsNullOrEmpty(MasterPrimaryKey))
                    throw new Exception(string.Format("The table {0} does not have a primary key defined on the Master database.", TableName));

                // Verify that all the mandatory audit trail fields exist.
                string[] MandatoryFields = { "UpdatedOn", "UpdatedBy", "AddedOn", "AddedBy" };
                foreach (string aFieldName in MandatoryFields)
                {
                    if (!MasterFields.ContainsKey("UpdatedOn"))
                        throw new Exception(string.Format("The table {0} is missing the mandatory field {1}", TableName, aFieldName));
                }
            }

            public void RetrievePropertiesFromLocal(SQLiteConnection dbCon)
            {
                SQLiteCommand dbCom = new SQLiteCommand("SELECT CASE WHEN UpdatedOn IS NULL THEN '1970-01-01 00:00:00' ELSE UpdatedOn END FROM TableChangeLog WHERE TableName = @TableName", dbCon);
                dbCom.Parameters.AddWithValue("TableName", TableName);

                object objLocalChanged = dbCom.ExecuteScalar();
                DateTime dtTemp;
                if (objLocalChanged != null && DateTime.TryParse(objLocalChanged.ToString(), out dtTemp))
                {
                    LocalLastChanged = dtTemp;
                }
                else
                {
                    Exception ex = new Exception("Failed to load lookup table from LOCAL TableChangeLog.");
                    ex.Data["TableName"] = TableName;
                    ex.Data["Connection"] = dbCon.ConnectionString;
                    throw ex;
                }

                dbCom = new SQLiteCommand(string.Format("PRAGMA table_info('{0}')", TableName), dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    if (dbRead.GetInt16(dbRead.GetOrdinal("pk")) == 1)
                    {
                        LocalPrimaryKey = dbRead.GetString(dbRead.GetOrdinal("name"));
                    }
                    else
                    {
                        System.Data.DbType theDataType;
                        string sDataType = dbRead.GetString(dbRead.GetOrdinal("type")).ToLower();
                        if (string.Compare(sDataType, "integer", true) == 0)
                            theDataType = System.Data.DbType.Int64;
                        else if (sDataType.StartsWith("varchar"))
                            theDataType = System.Data.DbType.String;
                        else if (string.Compare(sDataType, "datetime", true) == 0)
                            theDataType = System.Data.DbType.DateTime;
                        else
                            throw new Exception(string.Format("Unhandled database field type '{0}' in LOCAL table {1}", sDataType, TableName));

                        LocalFields[dbRead.GetString(dbRead.GetOrdinal("name"))] = new FieldDef(dbRead.GetString(dbRead.GetOrdinal("name")), theDataType);
                    }
                }
            }

            public void VerifySchemasMatch()
            {
                if (string.Compare(MasterPrimaryKey, LocalPrimaryKey, true) != 0)
                    throw new Exception(string.Format("The primary keys for lookup table {0} don't match. Master = {1}, local = {2}", TableName, MasterPrimaryKey, LocalPrimaryKey));

                // Loop over both databases and check that the fields in each, exist in the other.
                Dictionary<string, Dictionary<string, FieldDef>> dDatabaseDefs = new Dictionary<string, Dictionary<string, FieldDef>>();
                dDatabaseDefs["master"] = MasterFields;
                dDatabaseDefs["local"] = LocalFields;

                foreach (string sDatabase in dDatabaseDefs.Keys)
                {
                    Dictionary<string, FieldDef> theDatabaseDef = dDatabaseDefs[sDatabase];
                    foreach (FieldDef aField in theDatabaseDef.Values)
                    {
                        if (!LocalFields.ContainsKey(aField.FieldName))
                            throw new Exception(string.Format("The {0} database lookup table {1} contains a field called {2} but it is missing from the local database.", sDatabase, TableName, aField.FieldName));
                    }
                }

                // Verify that the data types match
                foreach (FieldDef masterField in MasterFields.Values)
                {
                    if (masterField.DataType != LocalFields[masterField.FieldName].DataType)
                        throw new Exception(string.Format("The {0} field in the {1} lookup table has a different data type on master than local. Master = {2}, local = {3}", masterField.FieldName, TableName, masterField.DataType.ToString(), LocalFields[masterField.FieldName].DataType.ToString()));
                }
            }

            public override string ToString()
            {
                return string.Format("{0}, PK = {1}", TableName, MasterPrimaryKey);
            }
        }

        public class FieldDef
        {
            public string FieldName { get; internal set; }
            public System.Data.DbType DataType { get; internal set; }

            public FieldDef(string sFieldName, System.Data.DbType aDataType)
            {
                FieldName = sFieldName;
                DataType = aDataType;
            }

            public override string ToString()
            {
                return FieldName;
            }
        }

    }
}
