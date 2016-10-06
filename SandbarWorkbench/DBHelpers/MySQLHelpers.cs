using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.DBHelpers
{
    class MySQLHelpers
    {
        public static string MySQLConString = "server=mysql.northarrowresearch.com;uid=nar;pwd=5Yuuxf3BhSI7F3Z5;database=SandbarTest;";

        public static LookupDataVersion GetMasterLookupDataVersion()
        {
            LookupDataVersion masterVersion = null;
            using (MySqlConnection conMaster = new MySqlConnection("server=mysql.northarrowresearch.com;uid=nar;pwd=5Yuuxf3BhSI7F3Z5;database=SandbarTest;"))
            {
                conMaster.Open();

                MySqlCommand comMaster = new MySqlCommand("SELECT * FROM LookupDataVersions ORDER BY MHashID DESC LIMIT 1", conMaster);
                MySqlDataReader rdMaster = comMaster.ExecuteReader();
                if (rdMaster.Read())
                {
                    masterVersion = new LookupDataVersion(rdMaster.GetInt64("MHashID"), rdMaster.GetDateTime("AddedOn"), rdMaster.GetString("AddedBy"), rdMaster.GetGuid("InstallationHash"));
                }
                else
                    throw new Exception("The master database does not contain any lookup data version information.");
            }
            return masterVersion;
        }
    }
}
