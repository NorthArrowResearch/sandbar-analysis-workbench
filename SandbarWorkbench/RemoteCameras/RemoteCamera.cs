using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.RemoteCameras
{
    class RemoteCamera
    {
        public long CameraID { get; internal set; }
        public float RiverMile { get; internal set; }
        public long CameraRiverBankID { get; internal set; }
        public string CameraRiverBank { get; internal set; }
        public long TargetRiverBankID { get; internal set; }
        public string TargetRiverBank { get; internal set; }
        public string SiteName { get; internal set; }
        public string SiteCode { get; internal set; }
        public long SiteID { get; internal set; }
        public string SiteCode5 { get; internal set; }
        public string NAUName { get; internal set; }
        public bool CurrentNPSPermit { get; internal set; }
        public string CurrentNPSPermitDisplay { get { return CurrentNPSPermit ? "Yes" : "No"; } }
        public bool HavePhotos { get; internal set; }
        public string HavePhotosDisplay { get { return HavePhotos ? "Yes" : "No"; } }
        public string Subject { get; internal set; }
        public string View { get; internal set; }
        public string BestPhotoTime { get; internal set; }
        public string BeginFilmRecord { get; internal set; }
        public string EndFilmRecord { get; internal set; }
        public string BeginDigitalRecord { get; internal set; }
        public string EndDigitalRecord { get; internal set; }
        public long CardTypeID { get; internal set; }
        public string CardType { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public DateTime UpdatedOn { get; internal set; }
        public string UpdatedBy { get; internal set; }

        public RemoteCamera(long nCameraID
            , float fRiverMile
            , long nCameraRiverBankID
            , string sCameraRiverBank
            , long nTargetRiverBankID
            , string sTargetRiverBankID
            , string sSiteName
            , string sSiteCode
            , long nSiteID
            , string sSiteCode5
            , string sNAUName
            , bool bCurrentNPSPermit
            , bool bHavePhotos
            , string sSubject
            , string sView
            , string sBestPhotoTime
            , string sBeginFilmRecord
            , string sEndFilmRecord
            , string sBeginDigitalRecord
            , string sEndDigitalRecord
            , long nCardTypeID
            , string sCardType
            , DateTime dtAddedOn
            , string sAddedBy
            , DateTime dtUpdatedOn
            , string sUpdatedBy)
        {


        }


        public static BindingList<RemoteCamera> LoadRemoteCameras(string sDB)
        {
            BindingList<RemoteCamera> lItems = new BindingList<RemoteCamera>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM vwRemoteCameras ORDER BY RiverMile", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    //RemoteCamera theSite = new RemoteCamera(
                    //    (long)dbRead["SiteID"]
                    //    , (string)dbRead["SiteCode"]
                    //    , (string)dbRead["SiteCode5"]
                    //    , (double)dbRead["RiverMile"]
                    //    , (long)dbRead["RiverSideID"]
                    //    , (string)dbRead["RiverSide"]
                    //    , (string)dbRead["Title"]
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "EddySize")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio8k")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "ExpansionRatio45k")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageChange8k45k")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "PrimaryGDAWS")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeA")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeB")
                    //    , DBHelpers.SQLiteHelpers.GetSafeValueNDbl(ref dbRead, "StageDischargeC")
                    //    );

                    //theSite.Surveys = SandbarSurvey.loadre(sDB, theSite.SiteID);
                    //lItems.Add(theSite);
                }
            }

            return lItems;
        }
    }
}
