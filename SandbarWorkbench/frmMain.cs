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
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
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
            DBHelpers.SyncHelpers syncTool = new DBHelpers.SyncHelpers("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);
            try
            {
                syncTool.SyncLookupData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}