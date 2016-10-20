using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

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

        public static void FillTextBox(ref MySqlDataReader dbRead, string sColumnName, ref TextBox txt)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                txt.Text = string.Empty;
            else
                txt.Text = dbRead.GetString(sColumnName);
        }

        public static void FillNumericUpDown(ref MySqlDataReader dbRead, string sColumnName, ref NumericUpDown val)
        {
            if (!dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
            {
                switch (dbRead.GetDataTypeName(dbRead.GetOrdinal(sColumnName)).ToLower())
                {
                    case "Int64":
                    case "int":
                        val.Value = (decimal)dbRead.GetInt64(sColumnName);
                        break;

                    case "double":
                        val.Value = (decimal)dbRead.GetDouble(sColumnName);
                        break;

                    default:
                        throw new Exception(string.Format("Unhandled data type filling numeric up down for type {0}", dbRead.GetDataTypeName(dbRead.GetOrdinal(sColumnName)).ToLower()));
                }
            }
        }

        public static void AddParameter(ref MySqlCommand dbCom, ref TextBox ctrl, string sParameterName)
        {
            if (string.IsNullOrEmpty(ctrl.Text))
            {
                MySqlParameter p = dbCom.Parameters.Add(sParameterName, MySqlDbType.String);
                p.Value = DBNull.Value;
            }
            else
            {
                dbCom.Parameters.AddWithValue(sParameterName, ctrl.Text);
            }
        }

        public static void AddParameter(ref MySqlCommand dbCom, ref NumericUpDown ctrl, string sParameterName)
        {
            dbCom.Parameters.AddWithValue(sParameterName, ctrl.Value);
        }

        public static void AddParameter(ref MySqlCommand dbCom, ref ComboBox ctrl, string sParameterName)
        {
            if (ctrl.SelectedIndex < 0)
            {
                MySqlParameter p = dbCom.Parameters.Add(sParameterName, MySqlDbType.Int64);
                p.Value = DBNull.Value;
            }
            else
            {
                dbCom.Parameters.AddWithValue(sParameterName, ((ListItem)ctrl.SelectedItem).Value);
            }
        }
    }
}
