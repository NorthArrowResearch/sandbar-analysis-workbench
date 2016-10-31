using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "EndDigital", "EndDigitalRecord", true);
        }

        private void frmRemoteCameras_Load(object sender, EventArgs e)
        {
            // Fix bug where the form icon uses the Visual Studio default when launched maximized
            // http://stackoverflow.com/questions/888865/problem-with-icon-on-creating-new-maximized-mdi-child-form-in-net
            this.Icon = (Icon)Icon.Clone();

            RemoteCameras = RemoteCamera.LoadRemoteCameras(DBCon.ConnectionStringLocal);

            DataView custDV = new DataView();
            grdData.DataSource = RemoteCameras;
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
    }
}
