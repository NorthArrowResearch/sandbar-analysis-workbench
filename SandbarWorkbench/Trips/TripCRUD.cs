using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            if (obj.ID > 0)
            {
                dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            }
            else
            {
                dbCom.Parameters.AddWithValue(PrimaryKey, DBNull.Value);
            }
            dbCom.Parameters.AddWithValue("TripDate", ((Trip)obj).TripDate);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);

            SQLiteParameter pRemarks = dbCom.Parameters.Add("Remarks", System.Data.DbType.String);
            if (string.IsNullOrEmpty(((Trip)obj).Remarks))
                pRemarks.Value = DBNull.Value;
            else
                pRemarks.Value = ((Trip)obj).Remarks;

            dbCom.ExecuteNonQuery();
            DBCon.BackupRequiredOnClose = true;

            if (obj.ID == 0)
            {
                obj.ID = dbTrans.Connection.LastInsertRowId;
            }
        }
    }
}
