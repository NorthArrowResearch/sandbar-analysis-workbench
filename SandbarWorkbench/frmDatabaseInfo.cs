using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SandbarWorkbench
{
    public partial class frmDatabaseInfo : Form
    {
        public frmDatabaseInfo()
        {
            InitializeComponent();
        }

        private void frmDatabaseInfo_Load(object sender, EventArgs e)
        {
            LoadBasicInformation();
            LoadVersionHistory();
        }


        private void LoadBasicInformation()
        {
            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT Key, ValueInfo FROM VersionInfo", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    int i = grdBasic.Rows.Add();
                    grdBasic[0, i].Value = AddSpacesToSentence(dbRead.GetString(0), true);
                    grdBasic[1, i].Value = dbRead.GetString(1);
                }
            }
        }

        private void LoadVersionHistory()
        {
            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT DateOfChange, Version, Description FROM VersionChangeLog", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    int i = grdVersionHistory.Rows.Add();
                    grdVersionHistory["colDate", i].Value = dbRead.GetDateTime(dbRead.GetOrdinal("DateOfChange")).ToString(SandbarWorkbench.Properties.Resources.SQLLiteDateFormat);
                    grdVersionHistory["colVersion", i].Value = dbRead.GetInt32(dbRead.GetOrdinal("Version"));
                    grdVersionHistory["colDescription", i].Value = dbRead.GetString(dbRead.GetOrdinal("Description"));
                }
            }
        }

        private string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i <= text.Length - 1; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    {
                        newText.Append(' ');
                    }
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
