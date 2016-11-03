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
using MySql.Data.MySqlClient;


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

            if (!string.IsNullOrEmpty(DBCon.ConnectionStringLocal) && System.IO.File.Exists(DBCon.DatabasePath))
            {
                switch (SandbarWorkbench.Properties.Settings.Default.StartupView)
                {
                    case 1:
                        sandbarSitesToolStripMenuItem_Click(null, null);
                        break;

                    case 2:
                        remoteCamerasToolStripMenuItem_Click(null, null);
                        break;
                }
            }

            UpdateMenuItemStatus();
        }

        private void UpdateMenuItemStatus()
        {
            bool bActiveDatabase = !string.IsNullOrEmpty(DBCon.ConnectionStringLocal) && System.IO.File.Exists(DBCon.DatabasePath);

            closeDatabaseToolStripMenuItem.Enabled = bActiveDatabase;
            databaseInformationToolStripMenuItem.Enabled = bActiveDatabase;
            sandbarSitesToolStripMenuItem.Enabled = bActiveDatabase;
            remoteCamerasToolStripMenuItem.Enabled = bActiveDatabase;

            cascadeToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;
            tileHorizontalToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;
            tileVerticaToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;

            tssDatabasePath.Text = DBCon.DatabasePath;
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
            System.Diagnostics.Process.Start(SandbarWorkbench.Properties.Resources.WebsiteURL);
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

        private void sandbarSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sandbars.frmSandbars frm = null;
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild is Sandbars.frmSandbars)
                {
                    frm = (Sandbars.frmSandbars)frmChild;
                    frm.Activate();
                    frm.BringToFront();
                    break;
                }
            }

            if (frm == null)
            {
                frm = new Sandbars.frmSandbars();
                frm.MdiParent = this;

                // Only maximize the form if there are no other MDI forms and this is a new version
                if (this.MdiChildren.Count<Form>() < 2)
                    frm.WindowState = FormWindowState.Maximized;
            }

            frm.Show();
            UpdateMenuItemStatus();
        }

        private void remoteCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteCameras.frmRemoteCameras frm = null;
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild is RemoteCameras.frmRemoteCameras)
                {
                    frm = (RemoteCameras.frmRemoteCameras)frmChild;
                    frm.Activate();
                    frm.BringToFront();
                    break;
                }
            }

            if (frm == null)
            {
                frm = new RemoteCameras.frmRemoteCameras();
                frm.MdiParent = this;

                // Only maximize the form if there are no other MDI forms and this is a new version
                if (this.MdiChildren.Count<Form>() < 2)
                    frm.WindowState = FormWindowState.Maximized;
            }

            frm.Show();
            UpdateMenuItemStatus();
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
                viewsToolStripMenuItem.DropDownItems.RemoveAt(i);

            // Create a list to store the definitions of all the custom views that will be added to the View menu.
            List<DataGridViews.DataGridViewTypeBase> lMenuItems = new List<DataGridViews.DataGridViewTypeBase>();

            // Add the lookup tables that have unique table structures
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Reaches", "Reaches", "SELECT ReachID AS ID, ReachCode AS [Reach Code], Title AS [Name] , AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM Reaches ORDER BY Title", "DELETE FROM Reaches WHERE ReachID = @ID"));
            lMenuItems.Add(new DataGridViews.DataGridViewTypeBase("Segments", "Segments", "SELECT SegmentID AS ID, SegmentCode AS [Segment Code], Title, UpstreamRiverMile AS [Upstream RM], DownstreamRiverMile AS [Downstream RM], AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM Segments ORDER BY Title", "DELETE FROM Segments WHERE SegmentID = @ID"));

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

        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBCon.CloseDatabase();
            UpdateMenuItemStatus();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DBCon.DatabasePath) && System.IO.File.Exists(DBCon.DatabasePath))
                System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(DBCon.DatabasePath));
        }

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSynchronize frmSync = new frmSynchronize();
                if (frmSync.ShowDialog() == DialogResult.OK)
                {
                    foreach (Form frm in this.MdiChildren)
                    {
                        if (frm is Sandbars.frmSandbars)
                        {
                            ((Sandbars.frmSandbars)frm).LoadData();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
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
                    DataGridViews.DataGridViewTypeBase mnuTag = (DataGridViews.DataGridViewTypeBase) mnu.Tag;
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
                frm = new DataGridViews.frmDataGridView((DataGridViews.DataGridViewTypeBase) mnu.Tag);
                frm.MdiParent = this;
            }

            frm.Show();
            UpdateMenuItemStatus();
        }
    }
}