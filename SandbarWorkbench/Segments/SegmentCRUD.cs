﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.Segments
{
    class SegmentCRUD : DBHelpers.CRUDManager
    {
        public SegmentCRUD()
            : base("Segments", "SegmentID", new string[] { "Title", "SegmentCode", "UpstreamRiverMile", "DownstreamRiverMile" })
        {

        }

        protected override void SaveLocal(ref SQLiteTransaction dbTrans, ref DBHelpers.DatabaseObject obj, string sSQL)
        {
            System.Diagnostics.Debug.Assert(obj.ID > 0, "The object should already have been saved to master which would generate the ID");
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);
            dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            dbCom.Parameters.AddWithValue("Title", obj.Title);
            dbCom.Parameters.AddWithValue("SegmentCode", ((Segment)obj).SegmentCode);
            dbCom.Parameters.AddWithValue("UpstreamRiverMile", ((Segment)obj).UpstreamRiverMile);
            dbCom.Parameters.AddWithValue("DownstreamRiverMile", ((Segment)obj).DownstreamRiverMile);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.ExecuteNonQuery();
        }
    }
}
