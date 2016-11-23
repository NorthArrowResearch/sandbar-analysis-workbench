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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("About The {0}", SandbarWorkbench.Properties.Resources.ApplicationNameLong);
            lblProductName.Text = SandbarWorkbench.Properties.Resources.ApplicationNameLong;

              string sWebSiteURL = SandbarWorkbench.Properties.Resources.WebSiteURL;
            lblWebSite.Text = string.Format("Web Site: {0}", sWebSiteURL);
            lblWebSite.LinkArea = new LinkArea(lblWebSite.Text.Length - sWebSiteURL.Length, sWebSiteURL.Length);
            lblWebSite.Links[0].LinkData = sWebSiteURL;
            lblWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);


            string sSoftwareVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lnkVersion.Text= string.Format("Workbench Version {0}", sSoftwareVersion);
            lnkVersion.LinkArea = new LinkArea(lnkVersion.Text.Length - sSoftwareVersion.Length, sSoftwareVersion.Length);
            lnkVersion.Links[0].LinkData = string.Format("{0}//ReleaseNotes/", sWebSiteURL);
            lnkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            
            lnkLicense.Text = "GNU General Public License";
            lnkLicense.LinkArea = new LinkArea(0, lnkLicense.Text.Length);
            lnkLicense.Links[0].LinkData = "https://github.com/NorthArrowResearch/sandbar-analysis-workbench/blob/master/LICENSE";
            lnkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            
            if (string.IsNullOrEmpty(DBCon.ConnectionStringLocal))
            {
                lblDBVersion.Visible = false;
            }
            else
            {
                try
                {
                    using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                    {
                        dbCon.Open();
                        SQLiteCommand dbCom = new SQLiteCommand("SELECT ValueInfo FROM VersionInfo WHERE Key = 'DatabaseVersion'", dbCon);
                        String sVersion = (string)dbCom.ExecuteScalar();
                        if (String.IsNullOrWhiteSpace(sVersion))
                            throw new Exception("Error retrieving database version");

                        lblDBVersion.Text = "Database version: " + sVersion;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex, false);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }
    }
}
