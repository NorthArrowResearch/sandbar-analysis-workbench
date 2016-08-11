using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    class SandbarSite
    {
        private const string GDAWSLink = "http://waterdata.usgs.gov/ks/nwis/inventory/?site_no={0}";

        public long SiteID { get; internal set; }
        public string SiteCode { get; internal set; }
        public string SiteCode5 { get; internal set; }
        public double RiverMile { get; internal set; }
        public ListItem RiverSide { get; internal set; }
        public string Title { get; internal set; }
        public long EddySize { get; internal set; }
        public double ExpansionRatio8k { get; internal set; }
        public double ExpansionRatio8k45k { get; internal set; }
        public double StageChange8k45k { get; internal set; }
        public long PrimaryGDAWS { get; internal set; }

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
            , long nEddySize
            , double fExpansionRatio8k
            , double fExpansionRatio8k45k
            , double fStageChange8k45k
            , long nPrimaryGDAWS)
        {
            SiteID = nSiteID;
            SiteCode = sSiteCode;
            SiteCode5 = sSiteCode5;
            RiverMile = fRiverMile;
            RiverSide = new ListItem(sRiverSide, nRiverSideID);
            Title = sTitle;
            EddySize = nEddySize;
            ExpansionRatio8k = fExpansionRatio8k;
            ExpansionRatio8k45k = fExpansionRatio8k45k;
            StageChange8k45k = fStageChange8k45k;
            PrimaryGDAWS = nPrimaryGDAWS;
        }


        public static BindingList<SandbarSite> LoadSandbarSites(string sDB)
        {
            BindingList<SandbarSite> lSandbarSites = new BindingList<SandbarSite>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT SiteID, SiteCode, SiteCode5, RiverMile, RiverSideID, RiverSide, Title, EddySize, ExpansionRatio8k, ExpansionRatio45k, StageChange8k45k, PrimaryGDAWS FROM vwSandbarSites ORDER BY RiverMile", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    lSandbarSites.Add(new SandbarSite(
                        (long) dbRead["SiteID"]
                        , (string)dbRead["SiteCode"]
                        , (string)dbRead["SiteCode5"]
                        , (double)dbRead["RiverMile"]
                        , (long)dbRead["RiverSideID"]
                        , (string)dbRead["RiverSide"]
                        , (string)dbRead["Title"]
                        , DBHelpers.SQLiteHelpers.GetSafeValueInt(ref dbRead, "EddySize")
                        , DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "ExpansionRatio8k")
                        , DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "ExpansionRatio45k")
                        , DBHelpers.SQLiteHelpers.GetSafeValueDbl(ref dbRead, "StageChange8k45k")
                        , DBHelpers.SQLiteHelpers.GetSafeValueInt(ref dbRead, "PrimaryGDAWS")
                        ));
                }

            }

            return lSandbarSites;
        }
    }
}
