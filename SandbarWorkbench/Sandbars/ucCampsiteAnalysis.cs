using SandbarWorkbench.AnalysisBins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucCampsiteAnalysis : UserControl
    {

        public SandbarSite SandbarSite { get; set; }
        private BindingList<ModelRun> ModelRuns;

        private Dictionary<long, ModelResults> ModelResultData;
        private Dictionary<long, AnalysisBins.AnalysisBin> Bins;

        private List<string> SelectedAnalyses
        {
            get
            {
                List<string> lResult = new List<string>();
                foreach (DataGridViewRow aRow in grdAnalyses.Rows)
                {
                    if ((bool)aRow.Cells[0].Value)
                    {
                        lResult.Add(((ModelRun)aRow.DataBoundItem).RunID.ToString());
                    }
                }
                return lResult;
            }
        }

        public ucCampsiteAnalysis()
        {
            InitializeComponent();
        }

        private void ucCampsiteAnalysis_Load(object sender, EventArgs e)
        {
            if (SandbarSite == null)
                return;

            ConfigureAnalysesDataGridView();
            ModelRuns = ModelRun.Load(DBCon.ConnectionStringLocal);
            grdAnalyses.DataSource = ModelRuns;
            grdAnalyses.ContextMenuStrip = cmsResults;

            // One time load of the analysis bin definitions
            Bins = AnalysisBins.AnalysisBin.Load(DBCon.ConnectionStringLocal, AnalysisBins.AnalysisBin.BinnedAnalysisTypes.CampsiteAnalysis);
            //CheckedListItem.LoadComboWithListItems(ref chkBins, DBCon.ConnectionStringLocal, "SELECT BinID, Title FROM AnalysisBins ORDER BY LowerElevation", true);
            chkBins.Items.AddRange(Bins.Values.ToArray<AnalysisBins.AnalysisBin>());

            chtData.ChartAreas.Clear();

            ChartArea chtArea = chtData.ChartAreas.Add("area");
            chtArea.AxisY.Title = "Campsite Area (m²)";

            chtArea.AxisX.MajorGrid.LineColor = Color.Gray;
            chtArea.AxisX.MinorGrid.LineColor = Color.LightGray;
            chtArea.AxisX.MinorGrid.Enabled = true;

            chtArea.AxisY.MajorGrid.LineColor = Color.Gray;
            chtArea.AxisY.MinorGrid.LineColor = Color.LightGray;
            chtArea.AxisY.MinorGrid.Enabled = true;


            ChartTypeChanging(null, null);
        }

        private void ConfigureXAxis(ChartArea chtArea)
        {
            chtArea.AxisX.Title = "Survey";
            chtArea.AxisX.IntervalType = DateTimeIntervalType.Number;
            chtArea.AxisX.Interval = 1;
        }

        private void ChartTypeChanging(object sender, EventArgs e)
        {
            chtData.Series.Clear();

            ConfigureXAxis(chtData.ChartAreas[0]);

            UpdateCharts(null, null);
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
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Title", "Title", true, eAutoSizeMode: DataGridViewAutoSizeColumnMode.DisplayedCells);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run On", "AddedOn", true, true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run By", "AddedBy", true);
        }

        private void UpdateCharts(object sender, EventArgs e)
        {
            chtData.Series.Clear();
            chtData.Titles.Clear();

            if (ModelResultData == null)
                return;

            try
            {

                string sTitle = string.Empty;


                sTitle = string.Format("Binned Campsite Areas");

                int nBinsOnDisplay = 0;


                Title theTitle = new Title(sTitle);
                theTitle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                chtData.Titles.Add(theTitle);

                UpdateBinnedChartArea(null, nBinsOnDisplay);

            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void UpdateBinnedChartArea(CheckedListBox.CheckedItemCollection chkItems, int nBinsOnDisplay)
        {
            foreach (long nModelID in ModelResultData.Keys)
            {
                foreach (AnalysisBin bin in chkBins.CheckedItems)
                {
                    Series binSeries = chtData.Series.Add(string.Format("{0}_{1}", nModelID, bin.Title));
                    binSeries.LegendText = bin.Title;
                    binSeries.ChartType = SeriesChartType.StackedColumn;
                    binSeries.ChartArea = chtData.ChartAreas[0].Name;
                    binSeries.Color = bin.DisplayColor;
                    //binSeries.BorderColor = Color.White;
                    //binSeries.BorderWidth = 1;
                    binSeries.IsVisibleInLegend = nBinsOnDisplay < Bins.Count;

                    nBinsOnDisplay += binSeries.IsVisibleInLegend ? 1 : 0;

                    Dictionary<long, double> fValues = new Dictionary<long, double>(); // surveyID to sum of values in this bin
                    List<DateTime> lSurveyDates = new List<DateTime>();
                    binSeries.CustomProperties = string.Format("StackedGroupName={0}", nModelID); //PointWidth=.6

                   
                    foreach (CampsiteResults result in  ModelResultData[nModelID].CampsiteResults.Values.ToList().OrderBy(x => x.SurveyDate))
                    {
                        if (!fValues.ContainsKey(result.SurveyID))
                        {
                            lSurveyDates.Add(result.SurveyDate);
                            fValues.Add(result.SurveyID, 0);
                        }

                        if (result.BinnedResults.ContainsKey(bin.ID))
                        {
                            fValues[result.SurveyID] = result.BinnedResults[bin.ID];
                        }
                    }

                    binSeries.Points.DataBindY(fValues.Values);
                    System.Diagnostics.Debug.Print(fValues.Count.ToString());

                    System.Diagnostics.Debug.Assert(lSurveyDates.Count == binSeries.Points.Count);
                    for (int i = 0; i < lSurveyDates.Count; i++)
                    {
                        binSeries.Points[i].AxisLabel = lSurveyDates[i].ToString("d-MMM-yyy");
                    }
                }
            }
        }

        private void grdAnalyses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow aRow in grdAnalyses.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)aRow.Cells[0];

                ModelRun theModel = (ModelRun)aRow.DataBoundItem;
                if (aRow.Cells[0].Value == chk.TrueValue)
                {
                    //System.Diagnostics.Debug.Print("Visible Row Index {0}, {1}", aRow.Index, aRow.Cells[1].Value);

                    if (ModelResultData == null)
                        ModelResultData = new Dictionary<long, ModelResults>();

                    if (!ModelResultData.ContainsKey(theModel.RunID))
                    {
                        ModelResultData[theModel.RunID] = new ModelResults(DBCon.ConnectionStringLocal, SandbarSite.SiteID, theModel.RunID, theModel.Title);
                    }
                }
                else
                {
                    if (ModelResultData != null)
                        if (ModelResultData.ContainsKey(theModel.RunID))
                            ModelResultData.Remove(theModel.RunID);
                }
            }

            UpdateCharts(null, null);
        }

        private void ExportResults(object sender, EventArgs e)
        {
            SandbarWorkbench.DBHelpers.DataExporter exp = new SandbarWorkbench.DBHelpers.DataExporter(DBCon.ConnectionStringLocal);
            SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes eType = ((ToolStripMenuItem)sender).Text.ToLower().Contains("incremental") ? SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes.ResultsIncremental : SandbarWorkbench.DBHelpers.DataExporter.ModelResultTypes.ResultsBinned;

            try
            {
                long nModelID = ((ModelRun)grdAnalyses.SelectedRows[0].DataBoundItem).RunID;
                exp.Run(nModelID, eType, true);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void grdAnalyses_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdAnalyses.EndEdit();
            }
        }

        private void browseAnalysisFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
