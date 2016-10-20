using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbarPropertiesEdit : Form
    {
        public string conMaster { get; internal set; }
        public long ID { get; internal set; }

        public frmSandbarPropertiesEdit(string sConMaster, long nID = 0)
        {
            InitializeComponent();
            conMaster = sConMaster;
            ID = nID;
        }

        private void frmSandbarPropertiesEdit_Load(object sender, EventArgs e)
        {
            long nSiteTypeID = 0;
            long nRiverSideID = 0;
            long nReachID = 0;
            long nSegmentID = 0;
            long nCameraID = 0;

            if (ID > 0)
            {
                using (MySqlConnection dbCon = new MySqlConnection(conMaster))
                {
                    dbCon.Open();

                    MySqlCommand dbCom = new MySqlCommand("SELECT * FROM SandbarSites WHERE SiteID = @SiteID", dbCon);
                    dbCom.Parameters.AddWithValue("SiteID", ID);
                    MySqlDataReader dbRead = dbCom.ExecuteReader();
                    dbRead.Read();

                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "SiteCode5", ref txtSiteCode5);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "RiverMile", ref valRiverMile);
                    nRiverSideID = dbRead.GetInt64("RiverSideID");
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "EddySize", ref valEddySize);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "Title", ref txtTitle);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "AlternateTitle", ref txtAlternateTitle);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "History", ref txtHistory);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "CampsiteSurveyRecord", ref txtCampsite);
                    nSiteTypeID = dbRead.GetInt64("SiteTypeID");
                    nReachID = dbRead.GetInt64("ReachID");
                    nSegmentID = dbRead.GetInt64("SegmentID");

                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("RemoteCameraID")))
                        nCameraID = dbRead.GetInt64("RemoteCameraID");

                    // Tab 2
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "ExpansionRatio8k", ref valExpansion8k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "ExpansionRatio45k", ref valExpansion45k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageChange8k45k", ref valStageChange845k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeA", ref valStageChangeA);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeB", ref valStageChangeB);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeC", ref valStageChangeC);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "PrimaryGDAWS", ref txtPrimaryGDAWS);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "SecondaryGDAWS", ref txtSecondaryGDAWS);

                    // Tab 3
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Easting", ref valEasting);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Northing", ref valNorthing);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Latitude", ref valLatitude);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Longitude", ref valLongitude);
                }
            }

            ListItem.LoadComboWithListItemsMySQL(ref cboRiverSide, conMaster, "SELECT ListID, Title FROM LookupListItems WHERE ListID = 1 ORDER BY Title", nRiverSideID);
            ListItem.LoadComboWithListItemsMySQL(ref cboSiteType, conMaster, "SELECT ListID, Title FROM LookupListItems WHERE ListID = 2 ORDER BY Title", nSiteTypeID);
            ListItem.LoadComboWithListItemsMySQL(ref cboReaches, conMaster, "SELECT ReachID, Title FROM Reaches ORDER BY Title", nReachID);
            ListItem.LoadComboWithListItemsMySQL(ref cboSegment, conMaster, "SELECT SegmentID, Title FROM Segments ORDER BY Title", nSegmentID);
            ListItem.LoadComboWithListItemsMySQL(ref cboRemoteCameras, conMaster, "SELECT CameraID, SiteName FROM RemoteCameras ORDER BY SiteName", nCameraID);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string sSQL = string.Empty;
            string[] sFields = { };

            //if (ID>0)
            //{
            //    sSQL = string.Format("UPDATE SandbarSites SET {0} WHERE SiteID = @SiteID", )
            //}
            //else
            //{
            //    dbCom = new MySqlCommand
            //}
        }
    }
}
