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
            AddDataGridViewTextColumn(ref grdData, "Title", "Title", true);
            AddDataGridViewTextColumn(ref grdData, "Eddy Size", "EddySize", true);
            AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 8k", "ExpansionRatio8k", true);
            AddDataGridViewTextColumn(ref grdData, "Exp. Ratio 45k", "ExpansionRatio8k45k", true);
            AddDataGridViewTextColumn(ref grdData, "Stage Change", "StageChange8k45k", true);
            AddDataGridViewLinkColumn(ref grdData, "GDAWS", "PrimaryGDAWS", true);
        }

        private void frmSandbars_Load(object sender, EventArgs e)
        {
            SandbarSites = SandbarSite.LoadSandbarSites(DBCon.ConnectionString);
            grdData.DataSource = SandbarSites;

        }

        private void AddDataGridViewTextColumn(ref DataGridView dg, string sHeaderText, string sDataPropertyMember, bool bVisible)
        {
            var aCol = new DataGridViewTextBoxColumn();
            aCol.Visible = bVisible;
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = sDataPropertyMember;
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
    }
}
