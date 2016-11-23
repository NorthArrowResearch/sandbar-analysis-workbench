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

namespace SandbarWorkbench.RemoteCameras
{
    public partial class frmRemoteCameras : Form
    {
        SortableBindingList<RemoteCamera> RemoteCameras;

        public frmRemoteCameras()
        {
            InitializeComponent();

            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToDeleteRows = false;
            grdData.ReadOnly = true;
            grdData.AllowUserToResizeRows = false;
            grdData.RowHeadersVisible = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdData.MultiSelect = false;
            grdData.AutoGenerateColumns = false;
            grdData.ContextMenuStrip = cmsGridView;

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "CameraID", "CameraID", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "River Mile", "RiverMile", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Camera Bank", "CameraRiverBank", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Target Bank", "TargetRiverBank", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "SiteName", "SiteName", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Sandbar Site", "SiteCode5", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "NAU Name", "NAUName", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "NPS Permit", "CurrentNPSPermit", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Photos", "HavePhotos", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Best Time", "BestPhotoTime", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Begin Film", "BeginFilmRecord", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "End Film", "EndFilmRecord", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Begin Digital", "BeginDigitalRecord", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "End Digital", "EndDigitalRecord", true);
        }

        private void frmRemoteCameras_Load(object sender, EventArgs e)
        {
            // Fix bug where the form icon uses the Visual Studio default when launched maximized
            // http://stackoverflow.com/questions/888865/problem-with-icon-on-creating-new-maximized-mdi-child-form-in-net
            this.Icon = (Icon)Icon.Clone();

            LoadData();
            FilterItems(null, null);
        }

        public void LoadData(long nSelectID = 0)
        {
            RemoteCameras = RemoteCamera.LoadRemoteCameras(DBCon.ConnectionStringLocal);
            DataView custDV = new DataView();
            grdData.DataSource = RemoteCameras;

            if (nSelectID > 0)
            {
                grdData.ClearSelection();
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if (((RemoteCamera)grdData.Rows[i].DataBoundItem).CameraID == nSelectID)
                    {
                        grdData.Rows[i].Selected = true;
                        break;
                    }
                }
            }
        }

        private void FilterItemsRiverMileUpstream(object sender, EventArgs e)
        {
            valDownstream.Value = Math.Min(valDownstream.Value, valUpstream.Value);
            FilterItemsRiverMile(null, null);
        }

        private void FilterItemsRiverMileDownstream(object sender, EventArgs e)
        {
            valUpstream.Value = Math.Max(valUpstream.Value, valDownstream.Value);
            FilterItemsRiverMile(null, null);
        }

        private void FilterItemsRiverMile(object sender, EventArgs e)
        {
            chkRiverMile.CheckedChanged -= FilterItems;
            chkRiverMile.Checked = true;
            chkRiverMile.CheckedChanged += FilterItems;
            FilterItems(null, null);
        }

        private void FilterItems(object sender, EventArgs e)
        {
            BindingList<RemoteCamera> lFilteredItems = RemoteCameras;

            if (chkRiverMile.Checked)
            {
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => (ss.RiverMile >= (double)valDownstream.Value && ss.RiverMile <= (double)valUpstream.Value)).ToList<RemoteCamera>());
            }

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => ss.SiteName.ToLower().Contains(txtTitle.Text.ToLower())).ToList<RemoteCamera>());
            }

            if (rdoCLeft.Checked)
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => ss.CameraRiverBankID == 2).ToList<RemoteCamera>());
            else if (rdoCRight.Checked)
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => ss.CameraRiverBankID == 1).ToList<RemoteCamera>());

            if (rdoTLeft.Checked)
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => ss.TargetRiverBankID == 2).ToList<RemoteCamera>());
            else if (rdoTRight.Checked)
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => ss.TargetRiverBankID == 1).ToList<RemoteCamera>());

            if (chkActive.Checked)
            {
                lFilteredItems = new BindingList<RemoteCamera>(lFilteredItems.Where(ss => !string.IsNullOrEmpty(ss.BeginDigitalRecord) && ss.EndDigitalRecord.ToLower().Contains("active")).ToList<RemoteCamera>());
            }

            grdData.DataSource = lFilteredItems;
        }

        private void EnterNumericUpDown(object sender, EventArgs e)
        {
            NumericUpDown theControl = (NumericUpDown)sender;
            theControl.Select(0, theControl.Text.Length);
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton theControl = (RadioButton)sender;

            //theControl.CheckedChanged -= rdo_CheckedChanged;
            //theControl.Checked = !theControl.Checked;
            //theControl.CheckedChanged += rdo_CheckedChanged;

            if (theControl.Checked)
                FilterItems(null, null);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRemoteCameraPropertiesEdit frm = new frmRemoteCameraPropertiesEdit();
                if (frm.ShowDialog() == DialogResult.OK)
                    MasterDatabaseChanged(frm.RemoteCameraID);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void MasterDatabaseChanged(long nSelectID = 0)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                sync.SynchronizeLookupTables();
                LoadData(nSelectID);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows[0].DataBoundItem is RemoteCamera)
            {
                RemoteCamera theCamera = (RemoteCamera)grdData.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show(string.Format("Are you sure that you want to delete the remote camera at site '{0}'? This process is permanent and cannot be undone.", theCamera.SiteCode5), "Confirm Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        dbCon.Open();

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            MySqlCommand dbCom = new MySqlCommand("DELETE FROM RemoteCameras WHERE CameraID = @RemoteCameraID", dbCon);
                            dbCom.Parameters.AddWithValue("RemoteCameraID", theCamera.CameraID);
                            dbCom.ExecuteNonQuery();
                            MasterDatabaseChanged();
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
                }
            }
        }

        private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPropertiesForm(true);
        }

        private void grdData_SelectionChanged(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count == 1)
            {
                RemoteCamera rc = (RemoteCamera)grdData.SelectedRows[0].DataBoundItem;
                if (!string.IsNullOrEmpty(rc.SiteCode))
                {
                    ucThumbail.UpdateThumbnail(rc.SiteCode, rc.BestPhotoTime);
                }
            }
        }

        private void viewPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPropertiesForm(false);
        }

        private void ShowPropertiesForm(bool bEditable)
        {
            try
            {
                RemoteCamera selCamera = (RemoteCamera)grdData.SelectedRows[0].DataBoundItem;

                frmRemoteCameraPropertiesEdit frm = new frmRemoteCameraPropertiesEdit(selCamera, bEditable);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MasterDatabaseChanged(selCamera.CameraID);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras)
                && System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras))
            {
                System.Diagnostics.Process.Start(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras);
            }
        }
    }
}
