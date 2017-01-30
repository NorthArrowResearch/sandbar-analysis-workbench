using System;
using System.Data.SQLite;

namespace SandbarWorkbench.DBHelpers
{
    class LocalDBHelpers
    {
        public static LookupDataVersion GetLocalLookupDataVersion(string sDBCon)
        {
            LookupDataVersion lookupVersion = new LookupDataVersion();
            using (SQLiteConnection conLocal = new SQLiteConnection(sDBCon))
            {
                conLocal.Open();

                SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM LookupDataVersions ORDER BY MHashID DESC LIMIT 1", conLocal);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                // The local database might not have lookup data when it is initiated.
                if (dbRead.Read())
                {
                    lookupVersion = new LookupDataVersion(dbRead.GetInt64(dbRead.GetOrdinal("MHashID")), dbRead.GetDateTime(dbRead.GetOrdinal("AddedOn")), dbRead.GetString(dbRead.GetOrdinal("AddedBy")), dbRead.GetGuid(dbRead.GetOrdinal("InstallationHash")));
                }
            }
            return lookupVersion;
        }
    }
}
