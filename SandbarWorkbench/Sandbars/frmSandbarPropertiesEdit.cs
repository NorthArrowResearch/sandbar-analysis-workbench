using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbarPropertiesEdit : Form
    {
        // These are the exponents to adjust the stage discharge values for display. 3 equates to 10^3.
        // Note that the negative value of this exponent should be then used for saving values to DB.
        private const int StageDischarge_B_Adjustment = 3;
        private const int StageDischarge_C_Adjustment = 9;

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
            ConfigureToolTips();

            long nSiteTypeID = 0;
            long nRiverSideID = 0;
            long nReachID = 0;
            long nSegmentID = 0;
            long nCameraID = 0;

            if (ID > 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                using (SQLiteConnection dbCon = new SQLiteConnection(conMaster))
                {
                    dbCon.Open();

                    SQLiteCommand dbCom = new SQLiteCommand("SELECT * FROM SandbarSites WHERE SiteID = @SiteID", dbCon);
                    dbCom.Parameters.AddWithValue("SiteID", ID);
                    SQLiteDataReader dbRead = dbCom.ExecuteReader();
                    dbRead.Read();

                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "SiteCode5", ref txtSiteCode5);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "RiverMile", ref valRiverMile);
                    nRiverSideID = dbRead.GetInt64(dbRead.GetOrdinal("RiverSideID"));
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "EddySize", ref valEddySize);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "Title", ref txtTitle);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "AlternateTitle", ref txtAlternateTitle);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "History", ref txtHistory);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "CampsiteSurveyRecord", ref txtCampsite);
                    nSiteTypeID = dbRead.GetInt64(dbRead.GetOrdinal("SiteTypeID"));

                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("ReachID")))
                        nReachID = dbRead.GetInt64(dbRead.GetOrdinal("ReachID"));

                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("SegmentID")))
                        nSegmentID = dbRead.GetInt64(dbRead.GetOrdinal("SegmentID"));

                    if (!dbRead.IsDBNull(dbRead.GetOrdinal("RemoteCameraID")))
                        nCameraID = dbRead.GetInt64(dbRead.GetOrdinal("RemoteCameraID"));

                    // Tab 2
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "ExpansionRatio8k", ref valExpansion8k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "ExpansionRatio45k", ref valExpansion45k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageChange8k45k", ref valStageChange845k);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeA", ref valStageChangeA);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeB", ref valStageChangeB, StageDischarge_B_Adjustment);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "StageDischargeC", ref valStageChangeC, StageDischarge_C_Adjustment);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "PrimaryGDAWS", ref txtPrimaryGDAWS);
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "SecondaryGDAWS", ref txtSecondaryGDAWS);

                    // Tab 3
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Easting", ref valEasting);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Northing", ref valNorthing);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Latitude", ref valLatitude);
                    DBHelpers.MySQLHelpers.FillNumericUpDown(ref dbRead, "Longitude", ref valLongitude);

                    // Tab - Remarks
                    DBHelpers.MySQLHelpers.FillTextBox(ref dbRead, "Remarks", ref txtRemarks);
                }
            }

            ListItem.LoadComboWithListItemsMySQL(ref cboRiverSide, conMaster, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 1 ORDER BY Title", nRiverSideID);
            ListItem.LoadComboWithListItemsMySQL(ref cboSiteType, conMaster, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 2 ORDER BY Title", nSiteTypeID);
            ListItem.LoadComboWithListItemsMySQL(ref cboReaches, conMaster, "SELECT ReachID, Title FROM Reaches ORDER BY Title", nReachID);
            ListItem.LoadComboWithListItemsMySQL(ref cboSegment, conMaster, "SELECT SegmentID, Title FROM Segments ORDER BY Title", nSegmentID);
            ListItem.LoadComboWithListItemsMySQL(ref cboRemoteCameras, conMaster, "SELECT CameraID, SiteName FROM RemoteCameras ORDER BY SiteName", nCameraID);

            Cursor.Current = Cursors.Default;
        }

        private void ConfigureToolTips()
        {
            tt.SetToolTip(txtSiteCode5, "Five digit site code. Four numerical digits representing the river mile following by an L for left or R for right bank: ####L or ####R. Max 5 characters.");
            tt.SetToolTip(valRiverMile, "River mile. Zero represents Glen Canyon Dam.");
            tt.SetToolTip(cboRiverSide, "Left or right bank where the sandbar site occurs.");
            tt.SetToolTip(valEddySize, "Size of the eddy at the sandbar site.");
            tt.SetToolTip(txtTitle, "Full, verbose, title describing the sandbar site. Max 50 characters.");
            tt.SetToolTip(txtAlternateTitle, "Alternative title used for the sandbar site. Max 50 characters.");
            tt.SetToolTip(txtHistory, "Brief description of the history of this sandbar site. Max 50 characters.");
            tt.SetToolTip(txtCampsite, "Campsite record.");
            tt.SetToolTip(cboSiteType, "Identification of whether this is a monitoring, irregular or backwater sandbar site.");
            tt.SetToolTip(cboReaches, "Reach in which this sandbar site occurs in.");
            tt.SetToolTip(cboSegment, "The segment in which this sandbar site occurs.");
            tt.SetToolTip(cboRemoteCameras, "Remote camera setup that is targeted at this sandbar site.");
            tt.SetToolTip(valExpansion8k, "Stage discharge expansion ratio at 8,000 cubic feet per second discharge.");
            tt.SetToolTip(valExpansion45k, "Stage discharge expansion ratio at 45,000 cubic feet per second discharge.");
            tt.SetToolTip(valStageChangeA, "Stage discharge curve coefficient A.");
            tt.SetToolTip(valStageChangeB, "Stage discharge curve coefficient B.");
            tt.SetToolTip(valStageChangeC, "Stage discharge curve coefficient C.");
            tt.SetToolTip(valStageChange845k, "Elevation change between 8,000 and 45,000 cubic feet per second discharge.");
            tt.SetToolTip(txtPrimaryGDAWS, "USGS stream gage identification number for the primary gage associated with this sandbar site.");
            tt.SetToolTip(txtSecondaryGDAWS, "USGS stream gage identification number for the secondary gage associated with this sandbar site.");
            tt.SetToolTip(valEasting, "Stateplane Arizona Central FIPS 0202 easting coordinate.");
            tt.SetToolTip(valNorthing, "Stateplane Arizona Central FIPS 0202 northing coordinate.");
            tt.SetToolTip(valLatitude, "Latitude in decimal degrees.");
            tt.SetToolTip(valLongitude, "Longitude in decimal degrees");
            tt.SetToolTip(txtRemarks, "Optional, miscellaneous remarks and comments about this sandbar site.");
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            string[] sFields = {"RiverMile","SiteCode5", "Title", "AlternateTitle" , "History", "ExpansionRatio8k" , "ExpansionRatio45k" , "StageChange8k45k", "SecondaryGDAWS",
                    "ReachID", "SegmentID", "CampsiteSurveyRecord" , "RemoteCameraID" , "StageDischargeA", "StageDischargeB", "StageDischargeC" , "Northing", "Easting", "Latitude" ,"Longitude",
                    "RiverSideID" , "SiteTypeID", "EddySize", "PrimaryGDAWS", "Remarks" };

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    SQLiteCommand dbCom = new SQLiteCommand();
                    dbCom.Connection = dbCon;

                    if (ID > 0)
                    {
                        dbCom.CommandText = string.Format("UPDATE SandbarSites SET {0}, UpdatedBy = @UserName WHERE SiteID = @SiteID", string.Join(", ", sFields.Select(x => string.Format("{0} = @{0}", x))));
                        dbCom.Parameters.AddWithValue("SiteID", ID);
                    }
                    else
                    {
                        dbCom.CommandText = string.Format("INSERT INTO SandbarSites ({0}, AddedBy, UpdatedBy) VALUES (@{1}, @UserName, @UserName)", string.Join(", ", sFields), string.Join(", @", sFields));
                    }

                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valRiverMile, "RiverMile");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtSiteCode5, "SiteCode5");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtTitle, "Title");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtAlternateTitle, "AlternateTitle");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtHistory, "History");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valExpansion8k, "ExpansionRatio8k");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valExpansion45k, "ExpansionRatio45k");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valStageChange845k, "StageChange8k45k");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtSecondaryGDAWS, "SecondaryGDAWS");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboReaches, "ReachID");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboSegment, "SegmentID");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtCampsite, "CampsiteSurveyRecord");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboRemoteCameras, "RemoteCameraID");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valStageChangeA, "StageDischargeA");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valStageChangeB, "StageDischargeB", -1 * StageDischarge_B_Adjustment);
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valStageChangeC, "StageDischargeC", -1 * StageDischarge_C_Adjustment);
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valNorthing, "Northing");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valEasting, "Easting");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valLatitude, "Latitude");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valLongitude, "Longitude");
                    //DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txt, "InitialSurvey");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboRiverSide, "RiverSideID");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboSiteType, "SiteTypeID");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valEddySize, "EddySize");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtPrimaryGDAWS, "PrimaryGDAWS");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtRemarks, "Remarks");

                    // Both queries require the user name
                    dbCom.Parameters.AddWithValue("UserName", Environment.UserName);

                    System.Diagnostics.Debug.Print(dbCom.CommandText);
                    dbCom.ExecuteNonQuery();
                    dbTrans.Commit();

                    if (ID < 1)
                        ID = dbCon.LastInsertRowId;

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Sandbar site data saved to the remote, master database. Your local database will now be updated when you click OK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

            }

        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtSiteCode5.Text))
            {
                MessageBox.Show("The site code cannot be empty.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSiteCode5.Select();
                return false;
            }

            if (!(cboRiverSide.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select the side of the river on which the sandbar is located.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRiverSide.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("The sandbar title cannot be empty.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Select();
                return false;
            }

            if (!(cboSiteType.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select the sandbar site type.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSiteType.Select();
                return false;
            }

            return true;
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmSandbarPropertiesEdit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
