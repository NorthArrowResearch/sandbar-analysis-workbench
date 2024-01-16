using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.DataVisualization.Charting;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucAreaVolumeAnalyses : UserControl
    {
        private enum AreaVolType
        {
            Area,
            Volume
        }
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

        public ucAreaVolumeAnalyses()
        {
            InitializeComponent();
        }

        private void ucAreaVolumeAnalyses_Load(object sender, EventArgs e)
        {
            if (SandbarSite == null)
                return;

            tt.SetToolTip(rdoIncremental, "Displays the incremental sandbar analysis that is performed at 10cm vertical increments above the minimum surface.");
            tt.SetToolTip(rdoBinned, "Displays the binned sandbar analysis that is performed at user-defined vertical slices through the sandbar.");
            tt.SetToolTip(valDisLower, "The lower discharge, above which sandbar is included in the chart.");
            tt.SetToolTip(valDisUpper, "The upper discharge, below which sandbar is included in the chart.");
            tt.SetToolTip(chkBins, "Check the boxes to turn on or off each user-defined elevation bin in the chart.");
            tt.SetToolTip(chkAreaSectionTypes, "Check the boxes to turn on or off the area results for each section type in the chart.");
            tt.SetToolTip(chkVolSectionTypes, "Check the boxes to turn on or off the volume results for each section type in the chart.");

            ConfigureAnalysesDataGridView();
            ModelRuns = ModelRun.Load(DBCon.ConnectionStringLocal);
            grdAnalyses.DataSource = ModelRuns;
            grdAnalyses.ContextMenuStrip = cmsResults;

            // One time load of the analysis bin definitions
            Bins = AnalysisBins.AnalysisBin.Load(DBCon.ConnectionStringLocal, AnalysisBins.AnalysisBin.BinnedAnalysisTypes.BinnedAnalysis);
            //CheckedListItem.LoadComboWithListItems(ref chkBins, DBCon.ConnectionStringLocal, "SELECT BinID, Title FROM AnalysisBins ORDER BY LowerElevation", true);
            chkBins.Items.AddRange(Bins.Values.ToArray<AnalysisBins.AnalysisBin>());

            string sSQL = string.Format("SELECT ItemID, Title FROM LookupListItems WHERE ListID = {0}", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
            CheckedListItem.LoadComboWithListItems(ref chkAreaSectionTypes, DBCon.ConnectionStringLocal, sSQL, false);
            CheckedListItem.LoadComboWithListItems(ref chkVolSectionTypes, DBCon.ConnectionStringLocal, sSQL, false);

            chtData.ChartAreas.Clear();

            ChartArea chtArea = chtData.ChartAreas.Add("area");
            chtArea.AxisY.Title = "Sandbar Area (m²)";

            ChartArea chtVolume = chtData.ChartAreas.Add("volume");
            chtVolume.AxisY.Title = "Sandbar Volume(m³)";

            ChartTypeChanging(null, null);
        }

        private void ChartTypeChanging(object sender, EventArgs e)
        {
            chtData.Series.Clear();

            lblLowerdischarge.Enabled = rdoIncremental.Checked;
            lblUpperDischarge.Enabled = rdoIncremental.Checked;
            valDisLower.Enabled = rdoIncremental.Checked;
            valDisUpper.Enabled = rdoIncremental.Checked;

            chkBins.Enabled = rdoBinned.Checked;

            ConfigureXAxis(chtData.ChartAreas[0]);
            ConfigureXAxis(chtData.ChartAreas[1]);

            UpdateCharts(null, null);
        }

        private void ConfigureXAxis(ChartArea chtArea)
        {
            chtArea.AxisX.Title = rdoIncremental.Checked ? "Date" : "Survey";

            if (rdoIncremental.Checked)
            {
                chtArea.AxisX.LabelStyle.Format = "yyyy";
                chtArea.AxisX.IntervalType = DateTimeIntervalType.Years;
                chtArea.AxisX.Interval = 1;

                chtArea.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Years;
                chtArea.AxisX.MajorGrid.Interval = 1;
                chtArea.AxisX.MajorGrid.LineColor = Color.LightGray;

                chtArea.AxisX.MinorGrid.Enabled = true;
                chtArea.AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Months;
                chtArea.AxisX.MinorGrid.Interval = 6;
                chtArea.AxisX.MinorGrid.LineColor = Color.GhostWhite;
                chtArea.AxisX.MinorTickMark.Enabled = true;
                chtArea.AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Months;
                chtArea.AxisX.MinorTickMark.Interval = 6;
                chtArea.AxisX.MinorTickMark.LineColor = Color.LightGray;
            }
            else
            {
                chtArea.AxisX.IntervalType = DateTimeIntervalType.Number;
                chtArea.AxisX.Interval = 1;
            }
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
                chtData.ChartAreas[0].Visible = chkAreaSectionTypes.CheckedItems.Count > 0;
                chtData.ChartAreas[1].Visible = chkVolSectionTypes.CheckedItems.Count > 0;

                string sTitle = string.Empty;

                if (rdoIncremental.Checked)
                {
                    sTitle = string.Format("Sandbar Metrics Between Stage Elevations Associated with Discharges of {0:#,##0} and {1:#,##0} cfs (ft³/s)", valDisLower.Value, valDisUpper.Value);

                    if (chkAreaSectionTypes.CheckedItems.Count > 0)
                        UpdateIncrementalChart(AreaVolType.Area, chkAreaSectionTypes.CheckedItems);

                    if (chkVolSectionTypes.CheckedItems.Count > 0)
                        UpdateIncrementalChart(AreaVolType.Volume, chkVolSectionTypes.CheckedItems);
                }
                else
                {
                    sTitle = string.Format("Binned Sandbar Metrics", valDisLower.Value, valDisUpper.Value);

                    int nBinsOnDisplay = 0;

                    if (chkAreaSectionTypes.CheckedItems.Count > 0)
                        UpdateBinnedChartArea(AreaVolType.Area, chkAreaSectionTypes.CheckedItems, ref nBinsOnDisplay);

                    if (chkVolSectionTypes.CheckedItems.Count > 0)
                        UpdateBinnedChartArea(AreaVolType.Volume, chkVolSectionTypes.CheckedItems, ref nBinsOnDisplay);
                }


                Title theTitle = new Title(sTitle);
                theTitle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                chtData.Titles.Add(theTitle);

            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void UpdateIncrementalChart(AreaVolType eType, CheckedListBox.CheckedItemCollection chkItems)
        {
            Nullable<double> fLowerElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);
            Nullable<double> fUpperElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);

            if (!fLowerElev.HasValue)
            {
                return;
            }


            double fMinY = -1;
            double fMaxY = -1;

            foreach (long nModelID in ModelResultData.Keys)
            {
                foreach (ListItem sectionTypeItem in chkItems)
                {
                    if (ModelResultData[nModelID].SectionTypes.ContainsKey(sectionTypeItem.Value))
                        AddIncrementResultToChart(sectionTypeItem, nModelID, eType, fLowerElev.Value, ref fMinY, ref fMaxY);
                }
            }

            double fRange = fMaxY - fMinY;
            double fExponent = (int)Math.Log10(fRange);
            double fMagnitude = Math.Pow(10, fExponent);
            double fInterval = fMagnitude / 10;

            //using (Axis yAxis = chtData.ChartAreas[eType == AreaVolType.Area ? 0 : 1].AxisY)
            //{
            //    yAxis.Minimum = Math.Floor(fMinY / fInterval) * fInterval;
            //    yAxis.Maximum = Math.Ceiling(fMaxY / fInterval) * fInterval;
            //    yAxis.MajorGrid.Interval = fInterval * 2;

            //    yAxis.MajorGrid.LineColor = Color.LightGray;

            //    yAxis.MinorGrid.Enabled = true;
            //    yAxis.MinorGrid.Interval = fInterval / 2;
            //    yAxis.MinorGrid.LineColor = Color.GhostWhite;
            //    yAxis.MinorTickMark.Enabled = true;
            //    yAxis.MinorTickMark.LineColor = Color.LightGray;
            //    yAxis.Enabled = chkAreaSectionTypes.CheckedItems.Count > 0 ? AxisEnabled.True : AxisEnabled.False;
            //    yAxis.IsStartedFromZero = false;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eType"></param>
        /// <param name="chkItems"></param>
        /// <param name="nBinsOnDisplay"></param>
        /// <remarks>http://support2.dundas.com/Default.aspx?article=1405</remarks>
        private void UpdateBinnedChartArea(AreaVolType eType, CheckedListBox.CheckedItemCollection chkItems, ref int nBinsOnDisplay)
        {
            // Stacked bar charts require lots of series. But we don't want them
            // all in the legend. So keep this counter and don't display any more
            // series once this counter matches the number of bins.

            foreach (long nModelID in ModelResultData.Keys)
            {
                foreach (AnalysisBins.AnalysisBin bin in chkBins.CheckedItems)
                {
                    Series binSeries = chtData.Series.Add(string.Format("{0}_{1}_{2}", nModelID, bin.Title, eType.ToString()));
                    binSeries.LegendText = bin.Title;
                    binSeries.ChartType = SeriesChartType.StackedColumn;
                    binSeries.ChartArea = chtData.ChartAreas[eType == AreaVolType.Area ? 0 : 1].Name;
                    binSeries.Color = bin.DisplayColor;
                    //binSeries.BorderColor = Color.White;
                    //binSeries.BorderWidth = 1;
                    binSeries.IsVisibleInLegend = nBinsOnDisplay < Bins.Count;

                    nBinsOnDisplay += binSeries.IsVisibleInLegend ? 1 : 0;

                    Dictionary<long, double> fValues = new Dictionary<long, double>(); // surveyID to sum of values in this bin
                    List<DateTime> lSurveyDates = new List<DateTime>();
                    binSeries.CustomProperties = string.Format("StackedGroupName={0}", nModelID); //PointWidth=.6

                    foreach (ListItem sectionTypeItem in chkItems)
                    {
                        if (ModelResultData[nModelID].SectionTypes.ContainsKey(sectionTypeItem.Value))
                        {
                            foreach (SurveyResults surveyRes in ModelResultData[nModelID].SectionTypes[sectionTypeItem.Value].Surveys.Values)
                            {
                                if (!fValues.ContainsKey(surveyRes.SurveyID))
                                {
                                    lSurveyDates.Add(surveyRes.SurveyDate);
                                    fValues.Add(surveyRes.SurveyID, 0);
                                }

                                if (surveyRes.BinnedResults.ContainsKey(bin.ID))
                                {
                                    if (eType == AreaVolType.Area)
                                        fValues[surveyRes.SurveyID] += surveyRes.BinnedResults[bin.ID].Area;
                                    else
                                        fValues[surveyRes.SurveyID] += surveyRes.BinnedResults[bin.ID].Vol;
                                }

                            }
                        }

                        //System.Diagnostics.Debug.Assert(lSurveyDates.Count == fValues.Count);
                        //binSeries.Points.DataBindXY(lSurveyDates, fValues.Values);
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

        private void AddIncrementResultToChart(ListItem sectionTypeItem, long nModelID, AreaVolType eType, double fLowerElev, ref double fMinY, ref double fMaxY)
        {
            string sTypeName = "AREA";
            MarkerStyle eMarker = MarkerStyle.Circle;
            if (eType == AreaVolType.Volume)
            {
                sTypeName = "VOLUME";
                eMarker = MarkerStyle.Square;
            }

            System.Diagnostics.Debug.Print("Loading {0} for section {1} - {2}", ModelResultData[nModelID].Title, sectionTypeItem, sTypeName);

            string sSeriesName;
            int nIndex = 0;
            do
            {
                sSeriesName = string.Format("{0} - {1} - {2}", ModelResultData[nModelID].Title, sectionTypeItem.Text, sTypeName);
                if (nIndex > 0)
                    sSeriesName = string.Format("{0} ({1})", sSeriesName, nIndex);

                nIndex++;

            } while (chtData.Series.FindByName(sSeriesName) is Series);

            Series theSeries = chtData.Series.Add(sSeriesName);
            theSeries.ChartArea = chtData.ChartAreas[eType == AreaVolType.Area ? 0 : 1].Name;
            theSeries.ChartType = SeriesChartType.Line;
            theSeries.BorderWidth = 2;
            theSeries.MarkerSize = 10;
            theSeries.BorderDashStyle = ChartDashStyle.Dash;
            theSeries.MarkerStyle = eMarker;

            foreach (SurveyResults aSurvey in ModelResultData[nModelID].SectionTypes[sectionTypeItem.Value].Surveys.Values)
            {
                // See if this model result contains the section type
                foreach (double fElevation in aSurvey.IncrementalResults.Keys)
                {
                    if (fElevation >= fLowerElev)
                    {
                        double displayValue = aSurvey.IncrementalResults[fElevation].Area;
                        if (eType == AreaVolType.Volume)
                            displayValue = aSurvey.IncrementalResults[fElevation].Vol;

                        // System.Diagnostics.Debug.Print("{0},{1},{2}", nModelID, aSurvey.SurveyID, displayValue);
                        theSeries.Points.AddXY(aSurvey.SurveyDate, displayValue);

                        UpdateMinMaxValues(ref fMinY, ref fMaxY, displayValue);
                        break;
                    }
                }
            }
        }

        private void UpdateMinMaxValues(ref double fOldMin, ref double fOldMax, double fNewValue)
        {
            if (fOldMin == -1 || fOldMin > fNewValue)
                fOldMin = fNewValue;

            fOldMax = Math.Max(fOldMax, fNewValue);
        }

        private void ConfigureYAxis(double fMin, double fMax, out double fInterval, out double fAxisMin, out double fAxisMax)
        {
            double fRange = fMax - fMin;
            double fExponent = (int)Math.Log10(fRange);
            double fMagnitude = Math.Pow(10, fExponent);
            fInterval = fMagnitude / 10;
            fAxisMin = Math.Floor(fMin / fInterval) * fInterval;
            fAxisMax = Math.Ceiling(fMax / fInterval) * fInterval;
            fInterval = fInterval * 2;
        }

        /// <summary>
        /// Capture when a channel section is checked or unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>The ItemCheck event occurs BEFORE the state of the item is checked.
        /// You can use the e.NewValue to determine the state of the newly checked item, or
        /// you can just queue up the desired event to fire after the state has changed.
        /// This code uses the latter approach.
        /// http://stackoverflow.com/questions/3666682/which-checkedlistbox-event-triggers-after-a-item-is-checked
        /// </remarks>
        private void SectionTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => UpdateCharts(null, null)));
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

        /// <summary>
        /// This is needed to force the saving of the state of the checkbox to the underlying object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdAnalyses_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                grdAnalyses.EndEdit();
            }
        }

        private void Discharge_ValueChanged(object sender, EventArgs e)
        {
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
    }
}
