using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DBHelpers
{
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

        public override string ToString()
        {
            return string.Format("{0}, PK = {1}", TableName, MasterPrimaryKey);
        }

        public LookupTableDef(string sTableName)
        {
            TableName = sTableName;
            LocalLastChanged = new Nullable<DateTime>();
            MasterLastChanged = new Nullable<DateTime>();
            MasterFields = new Dictionary<string, FieldDef>();
            LocalFields = new Dictionary<string, FieldDef>();
        }

        public void RetrievePropertiesFromMaster(string sSchemaName, MySqlConnection dbCon)
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
            dbCom = new MySqlCommand(string.Format("SELECT COLUMN_NAME, DATA_TYPE, COLUMN_KEY FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_SCHEMA = '{0}') AND (TABLE_NAME = '{1}')", sSchemaName, TableName), dbCon);
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
            dbRead.Close();

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
            dbRead.Close();
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

        public SQLiteCommand BuildUpdateCommand(ref SQLiteTransaction dbTrans)
        {
            // Query for updating local rows
            SQLiteCommand dbCom = new SQLiteCommand(dbTrans.Connection);
            dbCom.Transaction = dbTrans;

            // Add each of the lookup table fields as parameters to the query
            foreach (FieldDef aField in LocalFields.Values)
                dbCom.Parameters.Add(aField.FieldName, aField.DataType);

            // Add the primary key parameter used in the WHERE clause
            dbCom.Parameters.Add(MasterPrimaryKey, System.Data.DbType.UInt64);

            // Use LinQ to concatenate the field names into the field list of the SQL query
            string sFieldUpdateList = string.Join(", ", LocalFields.Select(x => string.Format("{0} = @{0}", x.Value.FieldName)).ToArray<string>());

            // Build the SQL UPDATE query that uses the list of fields.
            dbCom.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2} = @{2}", TableName, sFieldUpdateList, MasterPrimaryKey);

            return dbCom;
        }

        public SQLiteCommand BuildInsertCommand(ref SQLiteTransaction dbTrans)
        {
            // Query for updating local rows
            SQLiteCommand dbCom = new SQLiteCommand(dbTrans.Connection);
            dbCom.Transaction = dbTrans;

            // Add each of the lookup table fields as parameters to the query
            foreach (FieldDef aField in LocalFields.Values)
                dbCom.Parameters.Add(aField.FieldName, aField.DataType);

            // Add the primary key parameter
            dbCom.Parameters.Add(MasterPrimaryKey, System.Data.DbType.UInt64);

            // Use LinQ to concatenate the field names into the field list of the SQL query. Then prepend Primary Key
            string sFieldList = string.Join(", ", LocalFields.Select(x => x.Value.FieldName).ToArray<string>());
            sFieldList = string.Format("{0}, {1}", MasterPrimaryKey, sFieldList);

            // Build the SQL UPDATE query that uses the list of fields.
            // Note how the field list is used twice, 1st for the fields, then again as the parameters           
            dbCom.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES (@{2})", TableName, sFieldList, sFieldList.Replace(", ", ", @"));

            return dbCom;
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
