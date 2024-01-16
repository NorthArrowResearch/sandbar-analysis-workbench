using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;
using naru.ui;

namespace SandbarWorkbench.Sandbars
{
    public class SandbarSite : AuditTrail
    {
        private const string GDAWSLink = "http://waterdata.usgs.gov/usa/nwis/uv?{0:00000000}";

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
        public StageDischarge.SDCurve SDCurve { get; internal set; }
        public naru.ui.SortableBindingList<SandbarSurvey> Surveys { get; set; }
        public int SurveyCount { get { return Surveys.Count; } }

        // Best photo time is used to support the thumbnail viewer on the main data grid
        public Nullable<long> RemoteCameraID { get; internal set; }
        public string RemoteCameraSiteCode { get; internal set; }
        public string BestPhotoTime { get; internal set; }

        public string Remarks { get; internal set; }

        public string PrimaryGDAWSLink
        {
            get
            {
                return string.Format(GDAWSLink, PrimaryGDAWS);
            }
        }

        public System.IO.DirectoryInfo TopoDataFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData)
                    && System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData))
                    {
                    string sSite = string.Compare(SandbarWorkbench.Properties.Settings.Default.SandbarIdentification, "SiteCode5", true) == 0 ? this.SiteCode5 : this.SiteCode;
                    sSite = string.Format("{0}corgrids", sSite);
                    string sPath = System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData, sSite);
                    if (System.IO.Directory.Exists(sPath))
                        return new System.IO.DirectoryInfo(sPath);
                }
                return null;
            }
        }

        public Pictures.PictureInfo BestPhoto
        {
            get
            {
                if (RemoteCameraID.HasValue)
                    return Pictures.PictureInfo.GetPictureInfo(RemoteCameraSiteCode, BestPhotoTime);
                else
                    return null;
            }
        }

        public bool TopoDataFolderExists
        {
            get
            {
                System.IO.DirectoryInfo diTopoData = TopoDataFolder;
                return diTopoData is System.IO.DirectoryInfo && diTopoData.Exists;
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
            , string sRemarks
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
            //SDCurve = new StageDischarge.SDCurve(SiteID, SiteCode5, fStageDischargeA, fStageDischargeB, fStageDischargeC);
            Northing = fNorthing;
            Easting = fEasting;
            Latitude = fLatitude;
            Longitude = fLongitude;
            InitialSurvey = sInitialSurvey;
            EddySize = nEddySize;
            ExpansionRatio8k = fExpansionRatio8k;
            ExpansionRatio45k = fExpansionRatio45k;
            StageChange8k45k = fStageChange8k45k;
            Remarks = sRemarks;
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
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SiteCode")
                        , (string)dbRead["SiteCode5"]
                        , (double)dbRead["RiverMile"]
                        , (long)dbRead["RiverSideID"]
                        , (string)dbRead["RiverSide"]
                        , (string)dbRead["Title"]
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AlternateTitle")
                        , (long)dbRead["SiteTypeID"]
                        , (string)dbRead["SiteType"]
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "History")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "PrimaryGDAWS")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SecondaryGDAWS")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "ReachID")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Reach")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SegmentID")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Segment")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "CampSiteSurveyRecord")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "RemoteCameraID")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "CameraSiteCode")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BestPhotoTime")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeA")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeB")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeC")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Northing")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Easting")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Latitude")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "Longitude")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "InitialSurvey")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "EddySize")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio8k")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio45k")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageChange8k45k")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Remarks")
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
