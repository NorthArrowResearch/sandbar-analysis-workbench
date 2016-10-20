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
        BindingList<RemoteCamera> RemoteCameras;

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

            RemoteCameras = RemoteCamera.LoadRemoteCameras(DBCon.ConnectionString);

            DataView custDV = new DataView();
            grdData.DataSource = RemoteCameras;
        }
    }
}
