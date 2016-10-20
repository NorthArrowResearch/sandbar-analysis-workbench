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
        public double RiverMile { get; internal set; }
        public long CameraRiverBankID { get; internal set; }
        public string CameraRiverBank { get; internal set; }
        public long TargetRiverBankID { get; internal set; }
        public string TargetRiverBank { get; internal set; }
        public string SiteName { get; internal set; }
        public string SiteCode { get; internal set; }
        public Nullable<long> SiteID { get; internal set; }
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
            , double fRiverMile
            , long nCameraRiverBankID
            , string sCameraRiverBank
            , long nTargetRiverBankID
            , string sTargetRiverBank
            , string sSiteName
            , string sSiteCode
            , Nullable<long> nSiteID
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
            CameraID = nCameraID;
            RiverMile = fRiverMile;
            CameraRiverBankID = nCameraRiverBankID;
            CameraRiverBank = sCameraRiverBank;
            TargetRiverBankID = nTargetRiverBankID;
            TargetRiverBank = sTargetRiverBank;
            SiteName = sSiteName;
            SiteCode = sSiteCode;
            SiteID = nSiteID;
            SiteCode5 = sSiteCode5;
            NAUName = sNAUName;
            CurrentNPSPermit = bCurrentNPSPermit;
            HavePhotos = bHavePhotos;
            Subject = sSubject;
            View = sView;
            BestPhotoTime = sBestPhotoTime;
            BeginFilmRecord = sBeginFilmRecord;
            EndFilmRecord = sEndFilmRecord;
            BeginDigitalRecord = sBeginDigitalRecord;
            EndDigitalRecord = sEndDigitalRecord;
            CardTypeID = nCardTypeID;
            CardType = sCardType;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dtUpdatedOn;
            UpdatedBy = sUpdatedBy;
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
                    RemoteCamera theSite = new RemoteCamera(
                        (long)dbRead["CameraID"]
                        , (double)dbRead["RiverMile"]
                         , (long)dbRead["CameraRiverBankID"]
                       , (string)dbRead["CameraRiverBank"]
                        , (long)dbRead["TargetRiverBankID"]
                        , (string)dbRead["TargetRiverBank"]
                        , (string)dbRead["SiteName"]
                        , (string)dbRead["SiteCode"]
                        , DBHelpers.SQLiteHelpers.GetSafeValueNInt(ref dbRead, "SiteID")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SiteCode5")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "NAUName")
                        , DBHelpers.SQLiteHelpers.GetSafeValueBool(ref dbRead, "CurrentNPSPermit")
                        , DBHelpers.SQLiteHelpers.GetSafeValueBool(ref dbRead, "HavePhotos")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "Subject")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "View")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BestPhotoTime")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BeginFilmRecord")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "EndFilmRecord")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BeginDigitalRecord")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "EndDigitalRecord")
                        , DBHelpers.SQLiteHelpers.GetSafeValueInt(ref dbRead, "CardTypeID")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "CardType")
                        , DBHelpers.SQLiteHelpers.GetSafeValueDT(ref dbRead, "AddedOn")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "AddedBy")
                        , DBHelpers.SQLiteHelpers.GetSafeValueDT(ref dbRead, "UpdatedOn")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "UpdatedBy")
                        );

                    lItems.Add(theSite);
                }
            }

            return lItems;
        }
    }
}
