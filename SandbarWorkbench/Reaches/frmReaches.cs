using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace SandbarWorkbench.Reaches
{
    public partial class frmReaches : Form
    {
        BindingList<Reach> GridItems;

        public frmReaches()
        {
            InitializeComponent();

            grdData.AutoGenerateColumns = false;

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "ReachID", "reachID", false);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Reach Code", "ReachCode", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Name", "Title", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Added On", "AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Added By", "AddedBy", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Updated On", "UpdatedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
        }


        private void frmReaches_Load(object sender, EventArgs e)
        {
            grdData.AllowUserToAddRows = false;
            grdData.AllowUserToDeleteRows = false;
            grdData.ReadOnly = true;
            grdData.AllowUserToResizeRows = false;
            grdData.RowHeadersVisible = false;
            grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdData.Dock = DockStyle.Fill;

            LoadData();
        }

        private void LoadData(long nSelectID = 0)
        {
            try
            {
                GridItems = Reach.LoadReaches();
                DataView custDV = new DataView();
                grdData.DataSource = GridItems;

                if (nSelectID > 0)
                {
                    grdData.ClearSelection();
                    for (int i = 0; i < grdData.Rows.Count; i++)
                    {
                        if (((Reach)grdData.Rows[i].DataBoundItem).ID == nSelectID)
                        {
                            grdData.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }
    }
}
