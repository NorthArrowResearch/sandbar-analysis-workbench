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
            AddDataGridViewTextColumn(ref grdData, "SiteID", "SiteID", false);
            AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode", false);
            AddDataGridViewTextColumn(ref grdData, "Site Code", "SiteCode5", true);
            AddDataGridViewTextColumn(ref grdData, "River Mile", "RiverMile", true);
            AddDataGridViewTextColumn(ref grdData, "Bank", "RiverSide", true);
            AddDataGridViewTextColumn(ref grdData, "Name", "Title", true);
            AddDataGridViewTextColumn(ref grdData, "Eddy Size", "EddySize", true, "#,##0");
            AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 8k", "ExpansionRatio8k", true);
            AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 45k", "ExpansionRatio8k45k", true);
            AddDataGridViewTextColumn(ref grdData, "Stage Change", "StageChange8k45k", true);
            AddDataGridViewLinkColumn(ref grdData, "GDAWS", "PrimaryGDAWS", true);
        }

        private void frmSandbars_Load(object sender, EventArgs e)
        {
            SandbarSites = SandbarSite.LoadSandbarSites(DBCon.ConnectionString);

            DataView custDV = new DataView();
            grdData.DataSource = SandbarSites;

        }

        private void AddDataGridViewTextColumn(ref DataGridView dg, string sHeaderText, string sDataPropertyMember, bool bVisible, string sFormat = "")
        {
            var aCol = new DataGridViewTextBoxColumn();
            aCol.Visible = bVisible;
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = sDataPropertyMember;

            if (!string.IsNullOrEmpty(sFormat))
                aCol.DefaultCellStyle.Format = sFormat;

            dg.Columns.Add(aCol);
        }

        private void AddDataGridViewLinkColumn(ref DataGridView dg, string sHeaderText, string sDataPropertyMember, bool bVisible)
        {
            var aCol = new DataGridViewLinkColumn();
            aCol.Visible = bVisible;
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = sDataPropertyMember;
            aCol.UseColumnTextForLinkValue = false;
            dg.Columns.Add(aCol);
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
                lFilteredItems = new BindingList<SandbarSite>(lFilteredItems.Where(ss => (ss.RiverMile >= (double)valUpstream.Value && ss.RiverMile <= (double)valDownstream.Value)).ToList<SandbarSite>());
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
    }
}
