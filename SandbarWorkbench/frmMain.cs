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
    public partial class frmMain : Form
    {
        private System.IO.FileInfo m_fiDatabasePath;

        public System.IO.FileInfo DatabasePath
        {
            get { return m_fiDatabasePath; }

            internal set
            {
                m_fiDatabasePath = value;
                if (value is System.IO.FileInfo && value.Exists)
                    SandbarWorkbench.Properties.Settings.Default.LastDatabasePath = value.FullName;
                UpdateMenuItemStatus();
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = SandbarWorkbench.Properties.Resources.ApplicationNameLong;

            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath) && System.IO.File.Exists(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath))
                DatabasePath = new System.IO.FileInfo(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath);

            UpdateMenuItemStatus();
        }

        private void UpdateMenuItemStatus()
        {
            bool bActiveDatabase = DatabasePath is System.IO.FileInfo && DatabasePath.Exists;

            closeDatabaseToolStripMenuItem.Enabled = bActiveDatabase;
            databaseInformationToolStripMenuItem.Enabled = bActiveDatabase;
            sandbarSitesToolStripMenuItem.Enabled = bActiveDatabase;
            remoteCamerasToolStripMenuItem.Enabled = bActiveDatabase;

            cascadeToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;
            tileHorizontalToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;
            tileVerticaToolStripMenuItem.Enabled = this.MdiChildren.Count<Form>() > 0;
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

        private void databaseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = string.Format("Open {0} Database", SandbarWorkbench.Properties.Resources.ApplicationNameLong);
            frm.Filter = "SQLite Databases (*.sqlite, *.db)|*.sqlite;*.db";

            if (DatabasePath is System.IO.FileInfo && DatabasePath.Exists)
            {
                // Initialize with the current database
                frm.InitialDirectory = DatabasePath.DirectoryName;
                frm.FileName = System.IO.Path.GetFileNameWithoutExtension(DatabasePath.FullName);
            }
            else
            {
                // Initialize with the last used database
                if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath) && System.IO.File.Exists(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath))
                {
                    frm.InitialDirectory = System.IO.Path.GetDirectoryName(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath);
                    frm.FileName = System.IO.Path.GetFileNameWithoutExtension(SandbarWorkbench.Properties.Settings.Default.LastDatabasePath);
                }
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
                    SQLiteConnection dbCon = new SQLiteConnection(fiDatabase.FullName);
                    dbCon.Open();
                    DatabasePath = fiDatabase;
                    dbCon.Close();
                }
                catch (Exception ex)
                {


                }
            }
        }
    }
}