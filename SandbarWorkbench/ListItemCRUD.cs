﻿using System;
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
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The object should already have been saved to master which would generate the ID");
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            dbCom.Parameters.AddWithValue("Title", obj.Title);
            dbCom.Parameters.AddWithValue("ListID", ListID);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.ExecuteNonQuery();
        }
    }
}
