using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucAreaVolumeAnalyses : UserControl
    {
        public SandbarSite SandbarSite { get; set; }
        private BindingList<ModelRun> ModelRuns;

        private List<string> SelectedAnalyses
        {
            get
            {
                List<string> lResult = new List<string>();
                foreach (DataGridViewRow aRow in grdAnalyses.Rows)
                {
                    if ((bool) aRow.Cells[0].Value)
                    {
                        lResult.Add(((ModelRun)aRow.DataBoundItem).RunID.ToString());
                    }
                }
                return lResult;
            }
        }

        public ucAreaVolumeAnalyses()
        {
            InitializeComponent();
        }
                
        private void ucAreaVolumeAnalyses_Load(object sender, EventArgs e)
        {
            if (SandbarSite == null)
                return;

            ConfigureAnalysesDataGridView();
            ModelRuns = ModelRun.Load(DBCon.ConnectionString);
            grdAnalyses.DataSource = ModelRuns;
        }

        private void ConfigureAnalysesDataGridView()
        {
            grdAnalyses.RowHeadersVisible = false;
            grdAnalyses.AllowUserToAddRows = false;
            grdAnalyses.AllowUserToDeleteRows = false;
            grdAnalyses.AllowUserToResizeRows = false;
            grdAnalyses.AutoGenerateColumns = false;
            grdAnalyses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Helpers.DataGridViewHelpers.AddDataGridViewCheckboxColumn(ref grdAnalyses, "Visible");
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Title", "Title", true,"", DataGridViewAutoSizeColumnMode.DisplayedCells);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run On", "AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run By", "AddedBy", true);
        }

        private LoadData()
        {
            using ()

        }
    }
}
