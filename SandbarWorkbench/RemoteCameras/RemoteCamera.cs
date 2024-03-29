﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;
using naru.ui;

namespace SandbarWorkbench.RemoteCameras
{
    public class RemoteCamera
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
        public string Remarks { get; internal set; }
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
            , string sRemarks
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
            Remarks = sRemarks;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dtUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }

        public Pictures.RemoteCameraSetupInfo RemoteCameraSetupInfo
        {
            get
            {
                return new Pictures.RemoteCameraSetupInfo(SiteCode, RiverMile, SiteName, BestPhotoTime);
            }
        }

        public static SortableBindingList<RemoteCamera> LoadRemoteCameras(string sDB)
        {
            SortableBindingList<RemoteCamera> lItems = new SortableBindingList<RemoteCamera>();

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
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueNInt(dbRead, "SiteID")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "SiteCode5")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "NAUName")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueBool(dbRead, "CurrentNPSPermit")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueBool(dbRead, "HavePhotos")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "Subject")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "View")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "BestPhotoTime")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "BeginFilmRecord")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "EndFilmRecord")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "BeginDigitalRecord")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "EndDigitalRecord")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueInt(dbRead, "CardTypeID")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "CardType")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "Remarks")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueDT(dbRead, "AddedOn")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "AddedBy")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueDT(dbRead, "UpdatedOn")
                        , naru.db.sqlite.SQLiteHelpers.GetSafeValueStr(dbRead, "UpdatedBy")
                        );

                    lItems.Add(theSite);
                }
            }

            return lItems;
        }
    }
}
