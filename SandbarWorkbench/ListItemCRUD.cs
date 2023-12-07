using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench
{
    class ListItemCRUD : DBHelpers.CRUDManager
    {
        public long ListID { get; internal set; }

        public ListItemCRUD(long nListID)
            : base("LookupListItems", "ItemID", new string[] { "Title", "ListID" })
        {
            ListID = nListID;
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
            dbCom.Parameters.AddWithValue("ListID", ListID);
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
