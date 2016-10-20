using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbars : Form
    {
        BindingList<SandbarSite> SandbarSites;

        public frmSandbars()
        {
            InitializeComponent();

            grdData.AutoGenerateColumns = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "SiteID", "SiteID", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode5", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "River Mile", "RiverMile", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Bank", "RiverSide", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Name", "Title", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Eddy Size", "EddySize", true, "#,##0");
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 8k", "ExpansionRatio8k", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 45k", "ExpansionRatio8k45k", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Stage Change", "StageChange8k45k", true);
            Helpers.DataGridViewHelpers.AddDataGridViewLinkColumn(ref grdData, "GDAWS", "PrimaryGDAWS", true);
        }

        private void frmSandbars_Load(object sender, EventArgs e)
        {
            SandbarSites = SandbarSite.LoadSandbarSites(DBCon.ConnectionStringLocal);

            DataView custDV = new DataView();
            grdData.DataSource = SandbarSites;

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
            BindingList<SandbarSite> lFilteredItems = SandbarSites;

            if (chkRiverMile.Checked)
            {
                lFilteredItems = new BindingList<SandbarSite>(lFilteredItems.Where(ss => (ss.RiverMile <= (double)valUpstream.Value && ss.RiverMile >= (double)valDownstream.Value)).ToList<SandbarSite>());
            }

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                lFilteredItems = new BindingList<SandbarSite>(lFilteredItems.Where(ss => ss.Title.ToLower().Contains(txtTitle.Text.ToLower())).ToList<SandbarSite>());
            }

            grdData.DataSource = lFilteredItems;
        }

        private void EnterNumericUpDown(object sender, EventArgs e)
        {
            NumericUpDown theControl = (NumericUpDown)sender;
            theControl.Select(0, theControl.Text.Length);
        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;
            frmSandbarProperties frm = new frmSandbarProperties(ref selSite);
            frm.ShowDialog();
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdData.Columns[e.ColumnIndex].HeaderText.ToLower().Contains("gdaws"))
            {
                if (grdData.Rows[e.RowIndex].DataBoundItem is SandbarSite)
                {
                    SandbarSite theSite = (SandbarSite)grdData.Rows[e.RowIndex].DataBoundItem;
                    if (theSite.PrimaryGDAWS.HasValue)
                        System.Diagnostics.Process.Start(theSite.PrimaryGDAWSLink);
                }
            }
        }

        private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SandbarSite selSite = (SandbarSite)grdData.SelectedRows[0].DataBoundItem;

                Sandbars.frmSandbarPropertiesEdit frm = new frmSandbarPropertiesEdit(DBCon.ConnectionStringMaster, selSite.SiteID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // TODO re-load form
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        //private void grdData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //if (e.Button == MouseButtons.Right)
        //    //{
        //    //    grdData.Rows[e.RowIndex].Selected = true;
        //    //}
        //}

        private void grdData_MouseClick(object sender, MouseEventArgs e)
        {
            var hti = grdData.HitTest(e.X, e.Y);
            grdData.ClearSelection();
            if (hti.RowY > 1 && hti.ColumnX > 0)
                grdData.Rows[hti.RowIndex].Selected = true;
        }
    }
}
