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
            lItems.Add(new ListItemInt("Remote Camera Sites", 2));
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

            int nRow = grdFolderPaths.Rows.Add("Sandbar Topo Data", SandbarWorkbench.Properties.Settings.Default.Folder_SandbarTopoData);
            grdFolderPaths.Rows[nRow].Tag = "Folder_SandbarTopoData";

            // Sandbar Analysis Tab
            valDefaultInputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_InputCellSize;
            valDefaultOutputCellSize.Value = SandbarWorkbench.Properties.Settings.Default.Default_OutputCellSize;
            ListItem.LoadComboWithListItems(ref cboInterpolation, DBCon.ConnectionStringLocal, "SELECT ItemID, Title FROM LookupListItems WHERE ListID = 8 ORDER BY Title", SandbarWorkbench.Properties.Settings.Default.Default_Interpolation);

            // Error Logging
            if (AWSCloudWatch.AWSCloudWatchSingleton.HasInstallationGUID)
                txtStreamName.Text = AWSCloudWatch.AWSCloudWatchSingleton.Instance.InstallationGUID.ToString();

            chkAWSLoggingEnabled.Checked = SandbarWorkbench.Properties.Settings.Default.AWSLoggingEnabled;
#if DEBUG
            cmdTestAWS.Visible = true;
#endif



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

            SandbarWorkbench.Properties.Settings.Default.Save();
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
    }
}
