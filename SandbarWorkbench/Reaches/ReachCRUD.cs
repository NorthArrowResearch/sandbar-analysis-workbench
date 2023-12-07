using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.Reaches
{
    class ReachCRUD : DBHelpers.CRUDManager
    {
        public ReachCRUD()
            : base("Reaches", "ReachID", new string[] { "Title", "ReachCode" })
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
            
            dbCom.Parameters.AddWithValue("Title", obj.Title);
            dbCom.Parameters.AddWithValue("ReachCode", ((Reach)obj).ReachCode);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.ExecuteNonQuery();
            DBCon.BackupRequiredOnClose = true;

            if (obj.ID == 0)
            {
                obj.ID = dbTrans.Connection.LastInsertRowId;
            }
        }
    }
}