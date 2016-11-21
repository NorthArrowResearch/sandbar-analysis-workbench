using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();

            List<ListItemInt> lItems = new List<ListItemInt>();
            lItems.Add(new ListItemInt("-- None --", 0));
            lItems.Add(new ListItemInt("Sandbar Sites", 1));
            lItems.Add(new ListItemInt("Remote Camera Sites", 2));
            lItems.Add(new ListItemInt("Remote Camera Pictures", 3));
            cboStartupView.ValueMember = "Value";
            cboStartupView.DisplayMember = "Text";
            cboStartupView.DataSource = lItems;
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} Options", SandbarWorkbench.Properties.Resources.ApplicationNameLong);

            cboStartupView.SelectedValue = SandbarWorkbench.Properties.Settings.Default.StartupView;
            chkLoadLastDatabase.Checked = SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase;

            // Retrieve whether sandbar site folders are identified by either 4 or 5 digit codes
            rdo5Digits.Checked = string.Compare(SandbarWorkbench.Properties.Settings.Default.SandbarIdentification, "sitecode5", true) == 0;

            txtInstallationGuid.Text = SandbarWorkbench.Properties.Settings.Default.InstallationHash.ToString();

            txtMasterServer.Text = SandbarWorkbench.Properties.Settings.Default.MasterServer;
            txtMasterDatabase.Text = SandbarWorkbench.Properties.Settings.Default.MasterDatabase;
            txtMasterUserName.Text = SandbarWorkbench.Properties.Settings.Default.MasterUser;
            txtMasterPassword.Text = SandbarWorkbench.Properties.Settings.Default.MasterPassword;

            grdFolderPaths.AllowUserToAddRows = false;
            grdFolderPaths.AllowUserToDeleteRows = false;
            grdFolderPaths.AllowUserToResizeRows = false;
            grdFolderPaths.RowHeadersVisible = false;
            grdFolderPaths.Dock = DockStyle.Fill;
            grdFolderPaths.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grdFolderPaths.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
            grdFolderPaths.Columns[0].HeaderText = "Type";
            grdFolderPaths.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdFolderPaths.Columns[0].ReadOnly = true;

            grdFolderPaths.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell()));
            grdFolderPaths.Columns[1].HeaderText = "Local Folder Path";
            grdFolderPaths.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Folder paths
            int nRow = grdFolderPaths.Rows.Add("Sandbar Topo Data", SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData);
            grdFolderPaths.Rows[nRow].Tag = "Folder_SandbarTopoData";

            nRow = grdFolderPaths.Rows.Add("Remote Camera Photo Image Folder", SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras);
            grdFolderPaths.Rows[nRow].Tag = "Folder_RemoteCameras";

            nRow = grdFolderPaths.Rows.Add("Sandbar Bar Analysis Results", SandbarWorkbench.Properties.Settings.Default.Folder_SandbarAnalysisResults);
            grdFolderPaths.Rows[nRow].Tag = "Folder_SandbarAnalysisResults";

            // Sandbar Analysis Tab
            valDefaultInputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize;
            valDefaultOutputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize;
            ListItem.LoadComboWithListItems(ref cboInterpolation, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 8 ORDER BY Title", SandbarWorkbench.Properties.Settings.Default.Default_Interpolation);
            txtSpatialReference.Text = SandbarWorkbench.Properties.Settings.Default.SpatialReference;
            txtCompExtents.Text = SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile;
            IOHelpers.IOHelpers.FillTextBoxFile(SandbarWorkbench.Properties.Settings.Default.GDALWarp, ref txtGDALWarp);
            valIncrement.Value = SandbarWorkbench.Properties.Settings.Default.ElevationIncrement;
            valBenchmark.Value = SandbarWorkbench.Properties.Settings.Default.BenchmarkStage;

            // Error Logging
            if (AWSCloudWatch.AWSCloudWatchSingleton.HasInstallationGUID)
                txtStreamName.Text = AWSCloudWatch.AWSCloudWatchSingleton.Instance.InstallationGUID.ToString();

            chkAWSLoggingEnabled.Checked = SandbarWorkbench.Properties.Settings.Default.AWSLoggingEnabled;
#if DEBUG
            cmdTestAWS.Visible = true;
#endif

            // Date Display Formats
            LoadDateDisplayCombo(ref cboTripDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_TripDates);
            LoadDateDisplayCombo(ref cboSurveyDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_SurveyDates);
            LoadDateDisplayCombo(ref cboAuditFieldDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields);
        }

        private void LoadDateDisplayCombo(ref ComboBox cbo, string sExistingFormat)
        {
            // Load the items
            ListItem.LoadComboWithListItems(ref cbo, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 10 ORDER BY Title");

            // Loop over the items and select the one that matches the existing format.
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (((ListItem) cbo.Items[i]).Text.Contains(sExistingFormat))
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }

            // Select the first item in the event that one is not selected
            if (cbo.SelectedIndex < 0 && cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SandbarWorkbench.Properties.Settings.Default.StartupView = (int)cboStartupView.SelectedValue;
            SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase = chkLoadLastDatabase.Checked;

            // Store whether sandbar site folders are identified by either 4 or 5 digit codes
            SandbarWorkbench.Properties.Settings.Default.SandbarIdentification = rdo5Digits.Checked ? "SiteCode5" : "SiteCode";

            // Master database connection properties
            SandbarWorkbench.Properties.Settings.Default.MasterServer = txtMasterServer.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterDatabase = txtMasterDatabase.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterUser = txtMasterUserName.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterPassword = txtMasterPassword.Text;

            // Sandbar Analysis Tab
            SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize = valDefaultInputCellSize.Value;
            SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize = valDefaultOutputCellSize.Value;
            SandbarWorkbench.Properties.Settings.Default.Default_Interpolation = ((ListItem)cboInterpolation.SelectedItem).Value;
            SandbarWorkbench.Properties.Settings.Default.SpatialReference = txtSpatialReference.Text;
            SandbarWorkbench.Properties.Settings.Default.ElevationIncrement = valIncrement.Value;
            SandbarWorkbench.Properties.Settings.Default.BenchmarkStage = valBenchmark.Value;

            // Date Display Formats
            SandbarWorkbench.Properties.Settings.Default.DateFormat_SurveyDates = GetDateFormatFromCombo(ref cboSurveyDates);
            SandbarWorkbench.Properties.Settings.Default.DateFormat_TripDates = GetDateFormatFromCombo(ref cboTripDates);
            SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields = GetDateFormatFromCombo(ref cboAuditFieldDates);

            SandbarWorkbench.Properties.Settings.Default.Save();
        }

        private string GetDateFormatFromCombo(ref ComboBox cbo)
        {
            string sFormat = string.Empty;

            if (cbo.SelectedItem is ListItem)
            {
                try
                {
                    sFormat = cbo.Text.Split('\"')[1];
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(new Exception("The date format string is missing quotes around the actual format part of the string."));
                    sFormat = "dd MMM yyy";
                }
            }

            return sFormat;
        }

        private void grdFolderPaths_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                string sCurrentPath = string.Empty;

                if (!string.IsNullOrEmpty(grdFolderPaths.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    if (System.IO.Directory.Exists(grdFolderPaths.Rows[e.RowIndex].Cells[1].Value.ToString()))
                        sCurrentPath = grdFolderPaths.Rows[e.RowIndex].Cells[1].Value.ToString();

                FolderBrowserDialog frm = new FolderBrowserDialog();
                frm.SelectedPath = sCurrentPath;
                frm.ShowNewFolderButton = true;
                frm.Description = grdFolderPaths.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    grdFolderPaths.Rows[e.RowIndex].Cells[1].Value = frm.SelectedPath;

                    SandbarWorkbench.Properties.Settings.Default[grdFolderPaths.Rows[e.RowIndex].Tag.ToString()] = frm.SelectedPath;
                    SandbarWorkbench.Properties.Settings.Default.Save();
                }
            }
        }

        private void cmdBrowseCompExtents_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = "Computational Extents ShapeFile";
            frm.CheckFileExists = true;
            frm.Filter = "ShapeFiles (*.shp)|*.shp";
            frm.AddExtension = true;

            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile)
                && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile)))
            {
                frm.InitialDirectory = (System.IO.Path.GetDirectoryName(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile));
                if (System.IO.File.Exists(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile))
                    frm.FileName = System.IO.Path.GetFileNameWithoutExtension(SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile);
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile = frm.FileName;
                txtCompExtents.Text = frm.FileName;
            }
        }

        private void cmdBrowseGDALWarp_Click(object sender, EventArgs e)
        {
            IOHelpers.IOHelpers.BrowseFillTextBoxFile("GDAL Warp", "Executable Files (*.exe)|*.exe", ref txtGDALWarp, true);
        }
    }
}
