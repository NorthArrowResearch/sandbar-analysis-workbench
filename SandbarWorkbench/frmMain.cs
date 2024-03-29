﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Deployment.Application;
using Ionic.Zip;
using SandbarWorkbench.DBHelpers;

namespace SandbarWorkbench
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Issue a new installation hash if the current version is the default empty GUID.
            System.Guid installationHash = new Guid("00000000-0000-0000-0000-000000000000");
            if (SandbarWorkbench.Properties.Settings.Default.InstallationHash.Equals(installationHash))
            {
                SandbarWorkbench.Properties.Settings.Default.InstallationHash = System.Guid.NewGuid();
                SandbarWorkbench.Properties.Settings.Default.Save();
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = SandbarWorkbench.Properties.Resources.ApplicationNameLong;

            if (SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase)
            {
                if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath) && System.IO.File.Exists(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath))
                    OpenDatabase(new System.IO.FileInfo(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath));
            }

            // Track whether to backup the database on backup
            DBCon.BackupRequiredOnClose = Properties.Settings.Default.BackupRequiredOnClose;

            if (!string.IsNullOrEmpty(DBCon.ConnectionStringLocal) && System.IO.File.Exists(DBCon.DatabasePath))
            {
                switch (SandbarWorkbench.Properties.Settings.Default.StartupView)
                {
                    case 1:
                        LoadView(sandbarSitesToolStripMenuItem.Text, null);
                        break;

                    case 2:
                        LoadView(remoteCamerasToolStripMenuItem.Text, null);
                        break;

                    case 3:
                        LoadView(remoteCameraPictureViewerToolStripMenuItem.Text, null);
                        break;
                }
            }

            UpdateMenuItemStatus();
        }

        private void UpdateMenuItemStatus()
        {
            bool bActiveDatabase = !string.IsNullOrEmpty(DBCon.ConnectionStringLocal) && System.IO.File.Exists(DBCon.DatabasePath);

            // All items under Views, Tools and Experimental are only enabled when there's a database.
            ToolStripMenuItem[] arrtMenus = { viewsToolStripMenuItem, toolsToolStripMenuItem, experimentalToolStripMenuItem };
            foreach (ToolStripMenuItem mnu in arrtMenus)
                foreach (ToolStripMenuItem subItem in mnu.DropDownItems.OfType<ToolStripMenuItem>())
                    subItem.Enabled = bActiveDatabase;

            closeDatabaseToolStripMenuItem.Enabled = bActiveDatabase;
            databaseInformationToolStripMenuItem.Enabled = bActiveDatabase;
            tssDatabasePath.Text = DBCon.DatabasePath;

            experimentalToolStripMenuItem.Visible = false;
#if DEBUG
            experimentalToolStripMenuItem.Visible = true;
#endif
        }

        #region "Generic Main Form Events"

        private void tileVerticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutTheWorkbenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void sandbarWorkbenchOnlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SandbarWorkbench.Properties.Resources.WebSiteURL);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions();
            frm.ShowDialog();
        }

        private void databaseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseInfo frm = new frmDatabaseInfo();
            frm.ShowDialog();
        }

        #endregion

        private void LoadView(object sender, EventArgs e)
        {
            // Add the key word for each view type here and then the full namespace of the associated view form.
            // Each form needs a default constructor with no arguments.
            Dictionary<string, string> dViewTypes = new Dictionary<string, string>();
            dViewTypes["sandbar sites"] = "SandbarWorkbench.Sandbars.frmSandbars";
            dViewTypes["cameras"] = "SandbarWorkbench.RemoteCameras.frmRemoteCameras";
            dViewTypes["picture"] = "SandbarWorkbench.Pictures.frmPictureViewer";
            dViewTypes["analysis"] = "SandbarWorkbench.ModelRuns.frmModelRuns";

            try
            {
                // Find the associated MDI form type based on the keyword
                Type frmType = null;
                foreach (string sKey in dViewTypes.Keys)
                {
                    if (sender.ToString().ToLower().Contains(sKey))
                    {
                        frmType = Type.GetType(dViewTypes[sKey], true, true);
                        break;
                    }
                }

                foreach (Form mdiForm in this.MdiChildren)
                {
                    if (mdiForm.GetType() == frmType)
                    {
                        mdiForm.Focus();
                        return;
                    }
                }

                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                frm.WindowState = this.MdiChildren.Count<Form>() == 0 ? FormWindowState.Maximized : FormWindowState.Normal;

                if (frm is Sandbars.frmSandbars)
                    ToolStripManager.Merge(((Sandbars.frmSandbars)frm).toolStrip1, this.toolStrip1);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = string.Format("Open {0} Database", SandbarWorkbench.Properties.Resources.ApplicationNameLong);
            frm.Filter = "SQLite Databases (*.sqlite, *.db)|*.sqlite;*.db";

            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath) && System.IO.File.Exists(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath))
            {
                frm.InitialDirectory = System.IO.Path.GetDirectoryName(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath);
                frm.FileName = System.IO.Path.GetFileNameWithoutExtension(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath);
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                OpenDatabase(new System.IO.FileInfo(frm.FileName));
            }
        }

        private void OpenDatabase(System.IO.FileInfo fiDatabase)
        {
            if (fiDatabase.Exists)
            {
                try
                {
                    DBCon.ConnectionStringLocal = fiDatabase.FullName;
                    SandbarWorkbench.Properties.Settings.Default.LastDatabasePath = fiDatabase.FullName;
                    SandbarWorkbench.Properties.Settings.Default.Save();

                    // Apply any database migrations
                    string upgradeMessages;
                    if (!DBVersionManager.UpgradeDatabase(DBCon.ConnectionStringLocal, out upgradeMessages))
                    {
                        MessageBox.Show(string.Format("Failed to upgrade to the latest version of the database. Closing application. Contact the developer and provide the message:\n\n{0}", upgradeMessages),
                            "Database Migration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                    }

                    UpdateMenuItemStatus();
                    LoadLookupTableGridViewMenuItems();
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }

        private void LoadLookupTableGridViewMenuItems()
        {
            // Remove all items after the separator in the Views menu (then re-add them below)
            int i = viewsToolStripMenuItem.DropDownItems.Count - 1;
            while (!(viewsToolStripMenuItem.DropDownItems[i] is ToolStripSeparator) && i >= 0)
            {
                viewsToolStripMenuItem.DropDownItems.RemoveAt(i);
                i--;
            }

            // Create a list to store the definitions of all the custom views that will be added to the View menu.
            List<DataGridViews.DataGridViewTypeBase> lMenuItems = new List<DataGridViews.DataGridViewTypeBase>();

            // Add the lookup tables that have unique table structures
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Analysis Bin", "Analysis Bins", "SELECT BinID AS ID, Title AS [Name], LowerDischarge AS [Lower Discharge], UpperDischarge AS [Upper Discharge], IsActive AS Active, AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM AnalysisBins WHERE BinType = 'AnalysisBins' ORDER BY LowerDischarge", "DELETE FROM AnalysisBins WHERE BinID = @ID"));
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Campsite Analysis Bin", "Campsite Analysis Bins", "SELECT BinID AS ID, Title AS [Name], LowerDischarge AS [Lower Discharge], UpperDischarge AS [Upper Discharge], IsActive AS Active, AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM AnalysisBins WHERE BinType = 'CampsiteBins' ORDER BY LowerDischarge", "DELETE FROM AnalysisBins WHERE BinID = @ID"));
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Reaches", "Reaches", "SELECT ReachID AS ID, ReachCode AS [Reach Code], Title AS [Name], AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM Reaches ORDER BY Title", "DELETE FROM Reaches WHERE ReachID = @ID"));
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Segments", "Segments", "SELECT SegmentID AS ID, SegmentCode AS [Segment Code], Title, UpstreamRiverMile AS [Upstream RM], DownstreamRiverMile AS [Downstream RM], AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM Segments ORDER BY Title", "DELETE FROM Segments WHERE SegmentID = @ID"));
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Trips", "Trips", "SELECT TripID AS ID, TripDate AS [Trip Date], SurveyCount AS [Surveys], Remarks AS Remarks, AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM vwTrips ORDER BY TripDate DESC", "DELETE FROM Trips WHERE TripID = @ID"));

            // Now add the generic lookup lists (that can be edited by the user)
            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ListID, Title FROM LookupLists WHERE EditableByUser <> 0 ORDER BY Title", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    lMenuItems.Add(new DataGridViews.DataGridViewTypeLookupList(dbRead.GetInt64(dbRead.GetOrdinal("ListID")), dbRead.GetString(dbRead.GetOrdinal("Title")), dbRead.GetString(dbRead.GetOrdinal("Title"))));
                }
            }

            // Now loop over all these menu items and add them to the Views menu.
            foreach (DataGridViews.DataGridViewTypeBase aView in lMenuItems)
            {
                ToolStripMenuItem mnu = new ToolStripMenuItem(aView.MenuItemText, SandbarWorkbench.Properties.Resources.table, DataGridViewMenuItem_Click);
                mnu.Tag = aView;
                viewsToolStripMenuItem.DropDownItems.Add(mnu);
            }
        }

        private void CloseDBMenuItem_Click(object sender, EventArgs e)
        {
            CloseMDIChildren();
            DBCon.CloseDatabase();
            UpdateMenuItemStatus();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DBCon.DatabasePath) && System.IO.File.Exists(DBCon.DatabasePath))
                System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(DBCon.DatabasePath));
        }

        private void DataGridViewMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
            System.Diagnostics.Debug.Assert(mnu.Tag is DataGridViews.DataGridViewTypeBase);

            DataGridViews.frmDataGridView frm = null;
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild is DataGridViews.frmDataGridView)
                {
                    DataGridViews.DataGridViewTypeBase mnuTag = (DataGridViews.DataGridViewTypeBase)mnu.Tag;
                    if (mnuTag.MenuItemText == mnu.Text)
                    {
                        frmChild.Activate();
                        frmChild.BringToFront();
                        break;
                    }
                }
            }

            if (frm == null)
            {
                frm = new DataGridViews.frmDataGridView((DataGridViews.DataGridViewTypeBase)mnu.Tag);
                frm.MdiParent = this;
            }

            frm.Show();
            UpdateMenuItemStatus();
        }

        private void tripsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeDuplicateSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conRead = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                conRead.Open();
                SQLiteCommand comRead = new SQLiteCommand("SELECT * FROM SandbarSections ORDER BY SurveyID, SectionID", conRead);
                SQLiteDataReader dbRead = comRead.ExecuteReader();

                using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    dbCon.Open();
                    SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                    try
                    {
                        SQLiteCommand comDelete = new SQLiteCommand("DELETE FROM SandbarSections WHERE SectionID = @SectionID", dbTrans.Connection, dbTrans);
                        SQLiteParameter pSectionID = comDelete.Parameters.Add("SectionID", DbType.Int64);

                        long nSurveyID = -1;
                        long nDeleted = 0;
                        Dictionary<long, string> dSections = null;
                        while (dbRead.Read())
                        {
                            if (dbRead.GetInt64(dbRead.GetOrdinal("SurveyID")) != nSurveyID)
                            {
                                dSections = new Dictionary<long, string>();
                                nSurveyID = dbRead.GetInt64(dbRead.GetOrdinal("SurveyID"));
                            }

                            if (dSections.ContainsKey(dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID"))))
                            {
                                pSectionID.Value = dbRead.GetInt64(dbRead.GetOrdinal("SectionID"));
                                nDeleted += comDelete.ExecuteNonQuery();
                            }
                            else
                            {
                                dSections.Add(dbRead.GetInt64(dbRead.GetOrdinal("SectionTypeID")), string.Empty);
                            }
                        }

                        //dbTrans.Rollback();
                        dbTrans.Commit();
                        MessageBox.Show(string.Format("SqLite completed successfully. {0} deleted.", nDeleted));
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void createNewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Title = string.Format("New {0} Database File", SandbarWorkbench.Properties.Resources.ApplicationNameLong);
            frm.Filter = "SQLite Databases (*.sqlite)|*.sqlite|Other SQLite Database Extensions (*.db *.sdb *.sqlite *.db3 *.s3db *.sl3)|*.db;*.sdb;*.sqlite;*.db3;*.s3db;*.sl3";
            frm.AddExtension = true;

            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath) && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath)))
                frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);

            frm.FileName = "SandbarWorkbench";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.FileInfo fiNewDatabase = DBHelpers.DBVersionManager.CreateNewDatabase(frm.FileName);
                    if (fiNewDatabase is System.IO.FileInfo && fiNewDatabase.Exists)
                    {
                        // Now open the new database. This will also save it as the new last database.
                        OpenDatabase(fiNewDatabase);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }

        public void CloseMDIChildren()
        {
            this.MdiChildren.ToList<Form>().ForEach(x => x.Close());
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCheckInfo info = null;
            Cursor.Current = Cursors.WaitCursor;

            if ((ApplicationDeployment.IsNetworkDeployed))
            {
                ApplicationDeployment AD = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = AD.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time.\n\nPlease check your network connection, or try again later. Error: " + dde.Message, SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message, SandbarWorkbench.Properties.Resources.ApplicationNameLong);
                    return;
                }

                if ((info.UpdateAvailable))
                {
                    bool doUpdate = true;

                    if ((!info.IsUpdateRequired))
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if ((!(System.Windows.Forms.DialogResult.OK == dr)))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " + "version to version " + info.MinimumRequiredVersion.ToString() + ". The application will now install the update and restart.", "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if ((doUpdate))
                    {
                        try
                        {
                            AD.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            System.Windows.Forms.Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application.\n\nPlease check your network connection, or try again later.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The application is not deployed over the internet and therefore cannot be updated automatically.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Attempt to backup the current database.
        /// </summary>
        private void BackupDatabase()
        {
            if (!DBCon.BackupRequiredOnClose) return;

            if (!string.IsNullOrEmpty(DBCon.ConnectionStringLocal) && DBCon.BackupRequiredOnClose)
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.BackupDatabaseFolder) && System.IO.Directory.Exists(Properties.Settings.Default.BackupDatabaseFolder))
                {
                    string zipFileName = string.Format("{0}_{1:yyyyMMdd_HHmmss}.zip", System.IO.Path.GetFileNameWithoutExtension(DBCon.DatabasePath), DateTime.Now);
                    string zipFilePath = System.IO.Path.Combine(Properties.Settings.Default.BackupDatabaseFolder, zipFileName);
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        Console.WriteLine("Backing up to {0}", zipFilePath);

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddFile(DBCon.DatabasePath, "");
                            zip.Save(zipFilePath);
                        }

                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ex.Message, "Error Backing Up Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackupDatabase();
        }
    }
}