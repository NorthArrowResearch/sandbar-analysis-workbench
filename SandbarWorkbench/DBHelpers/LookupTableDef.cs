using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.DBHelpers
{
    public class LookupTableDef : BaseTableDef
    {
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

        public LookupTableDef(string sTableName) : base(sTableName)
        {
            LocalLastChanged = new Nullable<DateTime>();
            MasterLastChanged = new Nullable<DateTime>();
            MasterFields = new Dictionary<string, FieldDef>();
            LocalFields = new Dictionary<string, FieldDef>();
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
                    else if (sDataType.StartsWith("varchar") || sDataType.StartsWith("text"))
                        theDataType = System.Data.DbType.String;
                    else if (string.Compare(sDataType, "real", true) == 0)
                        theDataType = System.Data.DbType.Double;
                    else if (string.Compare(sDataType, "datetime", true) == 0 || string.Compare(sDataType, "date", true) == 0)
                        theDataType = System.Data.DbType.DateTime;
                    else if (string.Compare(sDataType, "boolean", true) == 0)
                        theDataType = System.Data.DbType.Boolean;
                    else
                        throw new Exception(string.Format("Unhandled local database field type '{0}' in LOCAL table {1}", sDataType, TableName));

                    LocalFields[dbRead.GetString(dbRead.GetOrdinal("name"))] = new FieldDef(dbRead.GetString(dbRead.GetOrdinal("name")), theDataType);
                }
            }
            dbRead.Close();
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
