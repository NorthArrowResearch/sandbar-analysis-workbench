using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Trips
{
    public class TripCRUD : DBHelpers.CRUDManager
    {
        public TripCRUD()
            : base("Trips", "TripID", new string[] { "TripDate", "Remarks" })
        {

        }

        protected override void SaveLocal(ref SQLiteTransaction dbTrans, ref DBHelpers.DatabaseObject obj, string sSQL)
        {
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The object should already have been saved to master which would generate the ID");
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            dbCom.Parameters.AddWithValue("TripDate", ((Trip)obj).TripDate);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);

            SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
            if (string.IsNullOrEmpty(((Trip)obj).Remarks))
                pRemarks.Value = DBNull.Value;
            else
                pRemarks.Value = ((Trip)obj).Remarks;

            dbCom.ExecuteNonQuery();
        }

        protected override long SaveMaster(ref MySqlTransaction dbTrans, ref DBHelpers.DatabaseObject obj)
        {
            MySqlCommand dbCom = null;

            if (obj.ID > 0)
            {
                dbCom = new MySqlCommand(UpdateSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            }
            else
            {
                dbCom = new MySqlCommand(InsertSQL, dbTrans.Connection, dbTrans);
                dbCom.Parameters.AddWithValue(PrimaryKey, DBNull.Value);
            }

            dbCom.Parameters.AddWithValue("TripDate", ((Trip)obj).TripDate);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            DBHelpers.MySQLHelpers.AddStringParameterN(ref dbCom, ((Trip)obj).Remarks, "Remarks");

            dbCom.ExecuteNonQuery();

            obj.ID = dbCom.LastInsertedId;
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The next code to execute is relying on there being a master ID at this point");
            return obj.ID;
        }
    }
}
