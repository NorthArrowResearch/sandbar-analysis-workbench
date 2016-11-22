using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    public class SandbarSite : AuditTrail
    {
        private const string GDAWSLink = "http://waterdata.usgs.gov/ks/nwis/inventory/?site_no={0:00000000}";

        public long SiteID { get; internal set; }
        public string SiteCode { get; internal set; }
        public string SiteCode5 { get; internal set; }
        public double RiverMile { get; internal set; }
        public ListItem RiverSide { get; internal set; }
        public string Title { get; internal set; }
        public string AlternateTitle { get; internal set; }
        public ListItem SiteType { get; internal set; }
        public string History { get; internal set; }
        public Nullable<long> PrimaryGDAWS { get; internal set; }
        public Nullable<long> SecondaryGDAWS { get; internal set; }
        public ListItem Reach { get; internal set; }
        public ListItem Segment { get; internal set; }
        public string CampSiteSurveyRecord { get; internal set; }
        public Nullable<double> Northing { get; internal set; }
        public Nullable<double> Easting { get; internal set; }
        public Nullable<double> Latitude { get; internal set; }
        public Nullable<double> Longitude { get; internal set; }
        public string InitialSurvey { get; internal set; }
        public Nullable<long> EddySize { get; internal set; }
        public Nullable<double> ExpansionRatio8k { get; internal set; }
        public Nullable<double> ExpansionRatio45k { get; internal set; }
        public Nullable<double> StageChange8k45k { get; internal set; }
        public StageDischargeCurve SDCurve { get; internal set; }
        public BindingList<SandbarSurvey> Surveys { get; set; }
        public int SurveyCount { get { return Surveys.Count; } }

        // Best photo time is used to support the thumbnail viewer on the main data grid
        public Nullable<long> RemoteCameraID { get; internal set; }
        public string RemoteCameraSiteCode { get; internal set; }
        public string BestPhotoTime { get; internal set; }

        public string PrimaryGDAWSLink
        {
            get
            {
                return string.Format(GDAWSLink, PrimaryGDAWS);
            }
        }

        public SandbarSite(long nSiteID
            , string sSiteCode
            , string sSiteCode5
            , double fRiverMile
            , long nRiverSideID
            , string sRiverSide
            , string sTitle
            , string sAlternateTitle
            , long nSiteType
            , string sSiteType
            , string sHistory
            , Nullable<long> nPrimaryGDAWS
            , Nullable<long> nSecondaryGDAWS
            , Nullable<long> nReachID
            , string sReach
            , Nullable<long> nSegmentID
            , string sSegment
            , string sCampSiteSurveyRecord
            , Nullable<long> nRemoteCameraID
            , string sRemoteCameraSiteCode
            , string sBestPhotoTime
            , Nullable<double> fStageDischargeA
            , Nullable<double> fStageDischargeB
            , Nullable<double> fStageDischargeC
            , Nullable<double> fNorthing
            , Nullable<double> fEasting
            , Nullable<double> fLatitude
            , Nullable<double> fLongitude
            , string sInitialSurvey
            , Nullable<long> nEddySize
            , Nullable<double> fExpansionRatio8k
            , Nullable<double> fExpansionRatio45k
            , Nullable<double> fStageChange8k45k
            , DateTime dtAddedOn
            , string sAddedBy
            , DateTime dtUpdatedOn
            , string sUpdatedBy) : base(dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            SiteID = nSiteID;
            SiteCode = sSiteCode;
            SiteCode5 = sSiteCode5;
            RiverMile = fRiverMile;
            RiverSide = new ListItem(sRiverSide, nRiverSideID);
            Title = sTitle;
            AlternateTitle = sAlternateTitle;
            SiteType = new ListItem(sSiteType, nSiteType);
            History = sHistory;
            PrimaryGDAWS = nPrimaryGDAWS;
            SecondaryGDAWS = nSecondaryGDAWS;

            if (nReachID.HasValue)
                Reach = new ListItem(sReach, nReachID.Value);

            if (nSegmentID.HasValue)
                Segment = new ListItem(sSegment, nSegmentID.Value);

            CampSiteSurveyRecord = sCampSiteSurveyRecord;
            RemoteCameraID = nRemoteCameraID;
            RemoteCameraSiteCode = sRemoteCameraSiteCode;
            BestPhotoTime = sBestPhotoTime;
            SDCurve = new StageDischargeCurve(fStageDischargeA, fStageDischargeB, fStageDischargeC);
            Northing = fNorthing;
            Easting = fEasting;
            Latitude = fLatitude;
            Longitude = fLongitude;
            InitialSurvey = sInitialSurvey;
            EddySize = nEddySize;
            ExpansionRatio8k = fExpansionRatio8k;
            ExpansionRatio45k = fExpansionRatio45k;
            StageChange8k45k = fStageChange8k45k;
        }

        public static SandbarSite LoadSandbarSite(string sDB, long nSiteID)
        {
            SortableBindingList<SandbarSite> lItems = LoadData(sDB, nSiteID);
            if (lItems.Count == 1)
                return lItems[0];
            else
                return null;
        }

        public static SortableBindingList<SandbarSite> LoadSandbarSites(string sDB)
        {
            return LoadData(sDB);
        }

        private static SortableBindingList<SandbarSite> LoadData(string sDB, long nSiteID = -1)
        {
            SortableBindingList<SandbarSite> lItems = new SortableBindingList<SandbarSite>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM vwSandbarSites ORDER BY RiverMile", dbCon);

                if (nSiteID > 0)
                {
                    dbCom = new SQLiteCommand("SELECT * FROM vwSandbarSites WHERE SiteID = @SiteID", dbCon);
                    dbCom.Parameters.AddWithValue("SiteID", nSiteID);
                }

                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {

                    SandbarSite theSite = new SandbarSite(
                        (long)dbRead["SiteID"]
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SiteCode")
                        , (string)dbRead["SiteCode5"]
                        , (double)dbRead["RiverMile"]
                        , (long)dbRead["RiverSideID"]
                        , (string)dbRead["RiverSide"]
                        , (string)dbRead["Title"]
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AlternateTitle")
                        , (long)dbRead["SiteTypeID"]
                        , (string)dbRead["SiteType"]
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "History")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "PrimaryGDAWS")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SecondaryGDAWS")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "ReachID")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Reach")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SegmentID")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Segment")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "CampSiteSurveyRecord")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "RemoteCameraID")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "CameraSiteCode")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BestPhotoTime")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeA")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeB")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeC")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Northing")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Easting")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Latitude")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Longitude")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "InitialSurvey")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "EddySize")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio8k")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio45k")
                        , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageChange8k45k")
                        , (DateTime)dbRead["AddedOn"]
                        , (string)dbRead["AddedBy"]
                        , (DateTime)dbRead["UpdatedOn"]
                        , (string)dbRead["UpdatedBy"]
                        );

                    theSite.Surveys = SandbarSurvey.LoadSandbarSurveys(sDB, theSite.SiteID);
                    lItems.Add(theSite);
                }
            }

            return lItems;
        }
    }
}
