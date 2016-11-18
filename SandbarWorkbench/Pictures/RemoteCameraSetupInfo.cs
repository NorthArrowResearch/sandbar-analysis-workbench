using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;

namespace SandbarWorkbench.Pictures
{
    public class RemoteCameraSetupInfo : RemoteCameras.RemoteCameraBase
    {
        public double RiverMile { get; internal set; }
        public string SiteName { get; internal set; }
        public string BestPhotoTime { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", SiteCode, SiteName, RiverMile);
        }

        public RemoteCameraSetupInfo(string sSiteCode, double fRiverMile, string sSiteName, string sBestPhotoTime) : base(sSiteCode)
        {
            SiteName = sSiteName;
            RiverMile = fRiverMile;
            BestPhotoTime = sBestPhotoTime;
        }

        public static BindingList<RemoteCameraSetupInfo> Load()
        {
            BindingList<RemoteCameraSetupInfo> lResult = new BindingList<RemoteCameraSetupInfo>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT SiteCode, SiteName, RiverMile, BestPhotoTime FROM RemoteCameras ORDER BY RiverMile", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    lResult.Add(new RemoteCameraSetupInfo(
                        dbRead.GetString(dbRead.GetOrdinal("SiteCode"))
                        , dbRead.GetDouble(dbRead.GetOrdinal("RiverMile"))
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "SiteName")
                        , DBHelpers.SQLiteHelpers.GetSafeValueStr(ref dbRead, "BestPhotoTime")
                        ));
                }
            }

            return lResult;
        }
    }
}
