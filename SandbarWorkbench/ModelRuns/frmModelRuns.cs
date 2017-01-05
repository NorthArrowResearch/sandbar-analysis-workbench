using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

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

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdData, "Date Run", "RunOnLT", true);
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
            tt.SetToolTip(dtFrom, "The filtered list of model runs is filtered to only those runs that were performed on or after this date");
            tt.SetToolTip(dtTo, "The filtered list of model runs is filtered to only those runs that were performed on or before this date");
            tt.SetToolTip(rdoAllRuns, "Choose this option to display all model runs that have results stored in the local database on this computer.");
            tt.SetToolTip(rdoLocalRuns, "Choose this option to display only the model runs that were actually performed on this local computer");

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
            UpdateGridViewCMS();
        }

        private void UpdateGridViewCMS()
        {
            // Browsing is only allowed when there is one LOCAL model run selected
            bool bAllowBrowse = false;
            if (grdData.SelectedRows.Count == 1 && grdData.SelectedRows[0].DataBoundItem is ModelRunLocal)
                bAllowBrowse = ((ModelRunLocal)grdData.SelectedRows[0].DataBoundItem).IsLocalRun;
            browseLocalModelRunResultsToolStripMenuItem.Enabled = bAllowBrowse;

            editModelRunToolStripMenuItem.Enabled = grdData.SelectedRows.Count == 1;
            exportIncrementalResultsToCSVToolStripMenuItem.Enabled = grdData.SelectedRows.Count == 1;
            exportBinnedResultsToCSVToolStripMenuItem.Enabled = grdData.SelectedRows.Count == 1;
            deleteModelRunToolStripMenuItem.Enabled = grdData.SelectedRows.Count > 0;
        }

        private void grdData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && grdData.Rows[e.RowIndex].DataBoundItem is ModelRunLocal)
            {
                ModelRunLocal run = grdData.Rows[e.RowIndex].DataBoundItem as ModelRunLocal;
                //grdData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = run.IsLocalRun ? Color.Blue : Color.DarkGray;
            }
        }

        private void editModelRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows.Count == 1 && grdData.SelectedRows[0].DataBoundItem is ModelRunLocal)
            {
                ModelRunLocal selRun = (ModelRunLocal)grdData.SelectedRows[0].DataBoundItem;
                frmModelRunProperties frm = new frmModelRunProperties(ref selRun);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData(selRun.ID);
            }
        }

        /// <summary>
        /// Deletes one or more selected model runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>This method attempts to delete the selected model runs on the local AND master database.
        /// Deleting the run on the master database is only attempted if the run possesses a master ID. Either
        /// it originated on a different computer or its a local run that has been synced. Both types of delete
        /// operations are performed in transactions and aborted if either experiences a problem.</remarks>
        private void deleteModelRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sCount = string.Empty;
            string sPlural = string.Empty;

            if (grdData.SelectedRows.Count > 1)
            {
                sCount = string.Format(" {0}", grdData.SelectedRows.Count);
                sPlural = "s";
            }
            if (MessageBox.Show(string.Format("Are you sure that you want to delete the{0} selected model run{1}?" +
                " This action is permanent and cannot be undone. Only the database records will be deleted. No model result files will be deleted during this process." +
                " Any local model runs will also be deleted on the master database, while model runs from other computers will only be deleted locally.", sCount, sPlural),
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;

                using (SQLiteConnection conLocal = new SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    conLocal.Open();
                    SQLiteTransaction transLocal = conLocal.BeginTransaction();
                    SQLiteCommand comLocal = new SQLiteCommand("DELETE FROM ModelRuns WHERE LocalRunID = @LocalRunID", transLocal.Connection, transLocal);
                    SQLiteParameter pLocal = comLocal.Parameters.Add("LocalRunID", DbType.Int64);

                    using (MySqlConnection conMaster = new MySqlConnection(DBCon.ConnectionStringMaster))
                    {
                        conMaster.Open();
                        MySqlTransaction transMaster = conMaster.BeginTransaction();
                        MySqlCommand comMaster = new MySqlCommand("DELETE FROM ModelRuns WHERE MasterRunID = @MasterRunID", transMaster.Connection, transMaster);
                        MySqlParameter pMaster = comMaster.Parameters.Add("MasterRunID", MySqlDbType.Int64);

                        try
                        {
                            foreach (DataGridViewRow dgvr in grdData.SelectedRows)
                            {
                                // Always delete the copy of the model run on lcoal
                                ModelRunLocal mr = dgvr.DataBoundItem as ModelRunLocal;
                                pLocal.Value = mr.ID;
                                comLocal.ExecuteNonQuery();

                                // Only local runs that have been synced should be deleted on master
                                if (mr.IsLocalRun && mr.MasterID > 0)
                                {
                                    pMaster.Value = mr.MasterID;
                                    comMaster.ExecuteNonQuery();
                                }
                            }

                            transLocal.Commit();
                            transMaster.Commit();

                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            transLocal.Rollback();
                            transMaster.Rollback();
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

        private void grdData_SelectionChanged(object sender, EventArgs e)
        {
            UpdateGridViewCMS();
        }

        private void browseLocalModelRunResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdData.SelectedRows[0].DataBoundItem is ModelRunLocal)
            {
                ModelRunLocal mr = grdData.SelectedRows[0].DataBoundItem as ModelRunLocal;
                if (mr.AnalysisFolder is System.IO.DirectoryInfo && mr.AnalysisFolder.Exists)
                    System.Diagnostics.Process.Start(mr.AnalysisFolder.FullName);
            }
        }

        private void ExportResultsCSV(object sender, EventArgs e)
        {
            SandbarWorkbench.DBHelpers.DataExporter exp = new SandbarWorkbench.DBHelpers.DataExporter(DBCon.ConnectionStringLocal);
            SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes eType = ((ToolStripMenuItem)sender).Text.ToLower().Contains("incremental") ? SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes.ResultsIncremental : SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes.ResultsBinned;

            try
            {
                long nModelID = ((ModelRunLocal)grdData.SelectedRows[0].DataBoundItem).ID;
                exp.Run(nModelID, eType, true);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }
    }
}
