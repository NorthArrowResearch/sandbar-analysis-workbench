﻿using System;
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
            cboStartupView.ValueMember = "Value";
            cboStartupView.DisplayMember = "Text";
            cboStartupView.DataSource = lItems;
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            ConfigureToolTips();

            this.Text = string.Format("{0} Options", SandbarWorkbench.Properties.Resources.ApplicationNameLong);

            cboStartupView.SelectedValue = SandbarWorkbench.Properties.Settings.Default.StartupView;
            chkLoadLastDatabase.Checked = SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase;

            // Retrieve whether sandbar site folders are identified by either 4 or 5 digit codes
            rdo5Digits.Checked = string.Compare(SandbarWorkbench.Properties.Settings.Default.SandbarIdentification, "sitecode5", true) == 0;

            txtInstallationGuid.Text = SandbarWorkbench.Properties.Settings.Default.InstallationHash.ToString();

#if DEBUG
            txtInstallationGuid.ReadOnly = false;
#endif
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

            //nRow = grdFolderPaths.Rows.Add("Remote Camera Photo Image Folder", SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras);
            //grdFolderPaths.Rows[nRow].Tag = "Folder_RemoteCameras";

            nRow = grdFolderPaths.Rows.Add("Sandbar Analysis Results", SandbarWorkbench.Properties.Settings.Default.Folder_SandbarAnalysisResults);
            grdFolderPaths.Rows[nRow].Tag = "Folder_SandbarAnalysisResults";

            nRow = grdFolderPaths.Rows.Add("Database Backup Folder", SandbarWorkbench.Properties.Settings.Default.BackupDatabaseFolder);
            grdFolderPaths.Rows[nRow].Tag = "BackupDatabaseFolder";

            // Sandbar Analysis Tab
            valDefaultInputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize;
            valDefaultOutputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize;
            ListItem.LoadComboWithListItems(ref cboInterpolation, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 8 ORDER BY Title", SandbarWorkbench.Properties.Settings.Default.Default_Interpolation);
            txtSpatialReference.Text = SandbarWorkbench.Properties.Settings.Default.SpatialReference;
            txtCompExtents.Text = SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile;
            txtCampsitePath.Text = SandbarWorkbench.Properties.Settings.Default.CampsitesFolder;
            Helpers.IOHelpers.FillTextBoxFile(SandbarWorkbench.Properties.Settings.Default.GDALWarp, ref txtGDALWarp);
            valIncrement.Value = SandbarWorkbench.Properties.Settings.Default.ElevationIncrement;
            valBenchmark.Value = SandbarWorkbench.Properties.Settings.Default.BenchmarkStage;
            txtMainPy.Text = SandbarWorkbench.Properties.Settings.Default.SandbarAnalysisMainPy;

            // Error Logging
            if (AWSCloudWatch.AWSCloudWatchSingleton.HasInstallationGUID)
                txtErrorLoggingKey.Text = AWSCloudWatch.AWSCloudWatchSingleton.Instance.InstallationGUID.ToString();

            chkAWSLoggingEnabled.Checked = SandbarWorkbench.Properties.Settings.Default.AWSLoggingEnabled;
#if DEBUG
            cmdTestAWS.Visible = true;
#endif

            // Date Display Formats
            LoadDateDisplayCombo(ref cboTripDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_TripDates);
            LoadDateDisplayCombo(ref cboSurveyDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_SurveyDates);
            LoadDateDisplayCombo(ref cboAuditFieldDates, SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields);

            // Python
            txtPython.Text = SandbarWorkbench.Properties.Settings.Default.PythonConfig;
        }

        private void ConfigureToolTips()
        {
            tt.SetToolTip(chkLoadLastDatabase, "Check this box to automatically load the last used local database each time the workbench is opened.");
            tt.SetToolTip(cboStartupView, "Select the type of view that you want to be opened automatically each time that the workbench is opened.");
            tt.SetToolTip(rdo4Digits, "Select this option if the sandbar site raw topo point CSV files use 4 digit site code folder and file names. e.g. \"003Lcorgrids\".");
            tt.SetToolTip(rdo5Digits, "Select this option if the sandbar site raw topo point CSV files use 5 digit site code folder and file names. e.g. \"0003Lcorgrids\".");
            tt.SetToolTip(txtInstallationGuid, "The unique identifier for the workbench on the current computer. Include this unique identifier when reporting issues with the software developers.");

            tt.SetToolTip(valDefaultInputCellSize, "Default point spacing, in meters, of the raw sandbar survey text point files. Typically 1m.");
            tt.SetToolTip(valDefaultOutputCellSize, "Default output cell size, in meters, of the raster GeoTIFFs that will be generated as part of the sandbar analysis.");
            tt.SetToolTip(cboInterpolation, "Default interpolation method that is used within the sandbar analysis to generate rasters from the raw text point files, if the input and output spatial resolutions are different.");
            tt.SetToolTip(valIncrement, "Vertical elevation increment, in meters, for the sandbar analysis incremental analysis. Default is 0.1m.");
            tt.SetToolTip(valBenchmark, "Benchmark discharge, in cubic feet per second, that is used to initiate the incremental sandbar analaysis. Default is 8000 CFS.");
            tt.SetToolTip(txtCompExtents, "Default full, absolute file path to the ShapeFile that contains the computational boundary polygons for the sandbar analysis.");
            tt.SetToolTip(txtCampsitePath, "Default full, absolute path to the folder that contains the campsite boundary polygons for the sandbar analysis.");
            tt.SetToolTip(txtGDALWarp, "Default full, absolute file path to the GDAL warp executable used within the sandbar analsysis. See online help for more details.");
            tt.SetToolTip(txtMainPy, "Default full, absolute file path to the sandbar analysis main.py file. See online help for more details.");
            tt.SetToolTip(txtSpatialReference, "Spatial reference \"well known string\" that defines the coordinate system of the sandbar survey raw text point files.");
            tt.SetToolTip(chkAWSLoggingEnabled, "Check this box to turn on sharing of error information with software developers.");
            tt.SetToolTip(txtErrorLoggingKey, "Unique identifier that is used to track workbench errors that occur on this computer. Include this unique identifier when reporting issues with the software developers.");
            tt.SetToolTip(cboTripDates, "Date time format used for displaying trip dates.");
            tt.SetToolTip(cboSurveyDates, "Date/time format used for displaying sandbar survey dates.");
            tt.SetToolTip(cboAuditFieldDates, "Date/time format used for displaying the date and time that records were added and changed in the database.");
            tt.SetToolTip(txtPython, "Python environment configuration for running the sandbar analysis. See the \"Python Environment\" page of the online help for more details.");
        }

        private void LoadDateDisplayCombo(ref ComboBox cbo, string sExistingFormat)
        {
            // Load the items
            ListItem.LoadComboWithListItems(ref cbo, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 10 ORDER BY Title");

            // Loop over the items and select the one that matches the existing format.
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (((ListItem)cbo.Items[i]).Text.Contains(sExistingFormat))
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
            // Only update the installation GUID if in Debug mode
#if DEBUG
            if (string.Compare(txtInstallationGuid.Text, SandbarWorkbench.Properties.Settings.Default.InstallationHash.ToString(), true) != 0)
            {
                switch (MessageBox.Show("Are you sure that you want to change the installation GUID?", "DEVELOPER MODE WARNING", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Cancel:
                        this.DialogResult = DialogResult.Cancel;
                        return;

                    case DialogResult.No:
                        txtInstallationGuid.Text = SandbarWorkbench.Properties.Settings.Default.InstallationHash.ToString();
                        this.DialogResult = DialogResult.None;
                        return;

                    case DialogResult.Yes:
                        try
                        {
                            SandbarWorkbench.Properties.Settings.Default.InstallationHash = new Guid(txtInstallationGuid.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Exception Creating Installation GUID. No Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = DialogResult.None;
                            return;
                        }

                        break;
                }
            }
#endif

            SandbarWorkbench.Properties.Settings.Default.StartupView = (int)cboStartupView.SelectedValue;
            SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase = chkLoadLastDatabase.Checked;

            // Store whether sandbar site folders are identified by either 4 or 5 digit codes
            SandbarWorkbench.Properties.Settings.Default.SandbarIdentification = rdo5Digits.Checked ? "SiteCode5" : "SiteCode";

            // Sandbar Analysis Tab
            SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize = valDefaultInputCellSize.Value;
            SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize = valDefaultOutputCellSize.Value;
            SandbarWorkbench.Properties.Settings.Default.Default_Interpolation = ((ListItem)cboInterpolation.SelectedItem).Value;
            SandbarWorkbench.Properties.Settings.Default.SpatialReference = txtSpatialReference.Text;
            SandbarWorkbench.Properties.Settings.Default.ElevationIncrement = valIncrement.Value;
            SandbarWorkbench.Properties.Settings.Default.BenchmarkStage = valBenchmark.Value;
            SandbarWorkbench.Properties.Settings.Default.SandbarAnalysisMainPy = txtMainPy.Text;
            SandbarWorkbench.Properties.Settings.Default.CompExtents_ShapeFile = txtCompExtents.Text;
            SandbarWorkbench.Properties.Settings.Default.CampsitesFolder = txtCampsitePath.Text;
            Properties.Settings.Default.GDALWarp = txtGDALWarp.Text;

            // Date Display Formats
            SandbarWorkbench.Properties.Settings.Default.DateFormat_SurveyDates = GetDateFormatFromCombo(ref cboSurveyDates);
            SandbarWorkbench.Properties.Settings.Default.DateFormat_TripDates = GetDateFormatFromCombo(ref cboTripDates);
            SandbarWorkbench.Properties.Settings.Default.DateFormat_AuditFields = GetDateFormatFromCombo(ref cboAuditFieldDates);

            // Python
            SandbarWorkbench.Properties.Settings.Default.PythonConfig = txtPython.Text;

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
            Helpers.IOHelpers.BrowseFillTextBoxFile("GDAL Warp", "Executable Files (*.exe)|*.exe", ref txtGDALWarp, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFile("Sandbar Analysis Main.oy Python File", "Python Scripts (*.py)|*.py", ref txtMainPy, true);
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmOptions_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void cmdCampsite_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFolder("Campsite Folder", ref txtCampsitePath, false);
        }
    }
}
