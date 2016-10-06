using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SandbarWorkbench.DBHelpers
{
    class SQLiteHelpers
    {
        public static double GetSafeValueDbl(ref SQLiteDataReader dbRead, string sColumnName)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                return 0;
            else
                return dbRead.GetDouble(dbRead.GetOrdinal(sColumnName));
        }

        public static Nullable<double> GetSafeValueNDbl(ref SQLiteDataReader dbRead, string sColumnName)
        {
            Nullable<double> fResult = new Nullable<double>();
            if (!dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                fResult = dbRead.GetDouble(dbRead.GetOrdinal(sColumnName));
            return fResult;
        }

        public static long GetSafeValueInt(ref SQLiteDataReader dbRead, string sColumnName)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                return 0;
            else
                return dbRead.GetInt64(dbRead.GetOrdinal(sColumnName));
        }
        
        public static Nullable<long> GetSafeValueNInt(ref SQLiteDataReader dbRead, string sColumnName)
        {
            Nullable<long> nResult = new Nullable<long>();
            if (!dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                nResult = dbRead.GetInt64(dbRead.GetOrdinal(sColumnName));
            return nResult;
        }

        public static string GetSafeValueStr(ref SQLiteDataReader dbRead, string sColumnName)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                return string.Empty;
            else
                return dbRead.GetString(dbRead.GetOrdinal(sColumnName));
        }

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
