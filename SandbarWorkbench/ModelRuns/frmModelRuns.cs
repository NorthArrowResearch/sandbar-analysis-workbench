using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.ModelRuns
{
    public partial class frmModelRuns : Form
    {
        private SortableBindingList<ModelRunLocal> ModelRuns { get; set; }

        public frmModelRuns()
        {
            InitializeComponent();

            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToDeleteRows = false;
            grdData.ReadOnly = true;
            grdData.AllowUserToResizeRows = false;
            grdData.RowHeadersVisible = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //grdData.MultiSelect = false;
            grdData.AutoGenerateColumns = false;
            grdData.ContextMenuStrip = cmsGridView;
            grdData.Dock = DockStyle.Fill;

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Date Run", "RunOn", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Run By", "RunBy", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Title", "Title", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Local Run", "IsLocalRun", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Synchronized", "Sync", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Remarks", "Remarks", true);

            dtFrom.CustomFormat = "d MMM yyyy";
            dtFrom.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = "d MMM yyyy";
            dtTo.Format = DateTimePickerFormat.Custom;
        }

        private void frmModelRuns_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Now.AddDays(-30);
            dtTo.Value = DateTime.Now;

            dtFrom.ValueChanged += FilterItems;
            dtTo.ValueChanged += FilterItems;

            // Fix bug where the form icon uses the Visual Studio default when launched maximized
            // http://stackoverflow.com/questions/888865/problem-with-icon-on-creating-new-maximized-mdi-child-form-in-net
            this.Icon = (Icon)Icon.Clone();

            LoadData();


            FilterItems(null, null);


        }

        public void LoadData(long nSelectID = 0)
        {
            ModelRuns = new SortableBindingList<ModelRunLocal>(ModelRunLocal.Load().Values.ToList<ModelRunLocal>());
            DataView custDV = new DataView();
            grdData.DataSource = ModelRuns;

            if (nSelectID > 0)
            {
                grdData.ClearSelection();
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if (((ModelRunLocal)grdData.Rows[i].DataBoundItem).ID == nSelectID)
                    {
                        grdData.Rows[i].Selected = true;
                        break;
                    }
                }
            }

            UpdateGridViewCMS();
        }



        private void FilterItems(object sender, EventArgs e)
        {
            SortableBindingList<ModelRunLocal> lFilteredItems = ModelRuns;

            // Always filter by date
            DateTime FilterFrom = new DateTime(dtFrom.Value.Year, dtFrom.Value.Month, dtFrom.Value.Day, 0, 0, 0);
            DateTime FilterTo = (new DateTime(dtTo.Value.Year, dtTo.Value.Month, dtTo.Value.Day, 0, 0, 0)).AddDays(1);
            lFilteredItems = new SortableBindingList<ModelRunLocal>(lFilteredItems.Where(mr => mr.RunOn >= FilterFrom && mr.RunOn < FilterTo).ToList<ModelRunLocal>());

            if (rdoLocalRuns.Checked)
                lFilteredItems = new SortableBindingList<ModelRunLocal>(lFilteredItems.Where(mr => mr.IsLocalRun).ToList<ModelRunLocal>());
            
            grdData.DataSource = lFilteredItems;
        }

        private void UpdateGridViewCMS()
        {
            bool bActiveSelection = grdData.SelectedRows.Count > 0;

            //viewPropertiesToolStripMenuItem.Enabled = bActiveSelection;
            //editPropertiesToolStripMenuItem.Enabled = bActiveSelection;
            //deleteSelectedToolStripMenuItem.Enabled = bActiveSelection;
            //browseTopoFolderToolStripMenuItem.Enabled = bActiveSelection;
        }

        private void grdData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex>=0 && grdData.Rows[e.RowIndex].DataBoundItem is ModelRunLocal)
            {
                ModelRunLocal run = grdData.Rows[e.RowIndex].DataBoundItem as ModelRunLocal;
                grdData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor =  run.IsLocalRun ? Color.Blue : Color.DarkGray;
            }
        }
    }
}
