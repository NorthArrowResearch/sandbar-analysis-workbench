using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using naru.ui;

namespace SandbarWorkbench.Segments
{
    public class Segment : DBHelpers.DatabaseObject
    {
        public string SegmentCode { get; set; }
        public double UpstreamRiverMile { get; set; }
        public double DownstreamRiverMile { get; set; }

        public Segment(long nID, string sSegmentcode, string sTitle, double fUSRM, double fDSRM, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
            : base(nID, sTitle, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            SegmentCode = sSegmentcode;
            UpstreamRiverMile = fUSRM;
            DownstreamRiverMile = fDSRM;
        }

        public Segment(string sSegmentcode, string sTitle, double fUSRM, double fDSRM, string sAddedBy)
        : base(0, sTitle, DateTime.Now, sAddedBy, DateTime.Now, sAddedBy)
        {
            SegmentCode = sSegmentcode;
            UpstreamRiverMile = fUSRM;
            DownstreamRiverMile = fDSRM;
        }

        public static Segment Load(long nSegmentID)
        {
            SortableBindingList<Segment> lSegments = Load();
            return lSegments.Where<Segment>(x => x.ID == nSegmentID).Single<Segment>();
        }

        public static SortableBindingList<Segment> Load()
        {
            SortableBindingList<Segment> lItems = new SortableBindingList<Segment>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT SegmentID, SegmentCode, Title, UpstreamRiverMile, DownstreamRiverMile, AddedOn, AddedBy, UpdatedOn, UpdatedBy FROM Segments ORDER BY Title", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    Segment theItem = new Segment(
                        (long)dbRead["SegmentID"]
                        , (string)dbRead["SegmentCode"]
                        , (string)dbRead["Title"]
                        , (double) dbRead["UpstreamRiveRMile"]
                        , (double) dbRead["DownstreamRiverMile"]
                        , (DateTime)dbRead["AddedOn"]
                        , (string)dbRead["AddedBy"]
                        , (DateTime)dbRead["UpdatedOn"]
                        , (string)dbRead["UpdatedBy"]
                        );

                    lItems.Add(theItem);
                }
            }

            return lItems;
        }
    }
}
