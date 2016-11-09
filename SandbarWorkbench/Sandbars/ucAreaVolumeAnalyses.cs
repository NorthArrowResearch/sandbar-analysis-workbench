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

            ConfigureAnalysesDataGridView();
            ModelRuns = ModelRun.Load(DBCon.ConnectionStringLocal);
            grdAnalyses.DataSource = ModelRuns;

            string sSQL = string.Format("SELECT ItemID, Title FROM LookupListItems WHERE ListID = {0}", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
            CheckedListItem.LoadComboWithListItems(ref chkAreaSectionTypes, DBCon.ConnectionStringLocal, sSQL, false);
            CheckedListItem.LoadComboWithListItems(ref chkVolSectionTypes, DBCon.ConnectionStringLocal, sSQL, false);

            chtData.ChartAreas[0].AxisX.Title = "Date";
            chtData.ChartAreas[0].AxisY.Title = "Sandbar Area (m²)";
            chtData.ChartAreas[0].AxisY2.Title = "Sandbar Volume (m³)";

            chtData.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy";
            chtData.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
            chtData.ChartAreas[0].AxisX.Interval = 1;

            chtData.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Years;
            chtData.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            chtData.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            chtData.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Months;
            chtData.ChartAreas[0].AxisX.MinorGrid.Interval = 6;
            chtData.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.GhostWhite;
            chtData.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Months;
            chtData.ChartAreas[0].AxisX.MinorTickMark.Interval = 6;
            chtData.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;
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
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Title", "Title", true, "", DataGridViewAutoSizeColumnMode.DisplayedCells);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run On", "AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdAnalyses, "Run By", "AddedBy", true);
        }

        private void UpdateChart(object sender, EventArgs e)
        {
            chtData.Series.Clear();
            chtData.Titles.Clear();

            Nullable<double> fLowerElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);
            Nullable<double> fUpperElev = SandbarSite.SDCurve.Stage((double)valDisLower.Value);

            if (ModelResultData == null)
                return;

            if (fLowerElev.HasValue)
            {
                Title theTitle = new Title(string.Format("Sandbar Metrics Between Stage Elevations Associated with Discharges of {0:#,##0} and {1:#,##0} cfs (ft³/s)", valDisLower.Value, valDisUpper.Value));
                theTitle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
                chtData.Titles.Add(theTitle);

                double fMinY1 = -1;
                double fMaxY1 = -1;

                double fMinY2 = -1;
                double fMaxY2 = -1;

                foreach (long nModelID in ModelResultData.Keys)
                {
                    foreach (ListItem sectionTypeItem in chkAreaSectionTypes.CheckedItems)
                    {
                        if (ModelResultData[nModelID].SectionTypes.ContainsKey(sectionTypeItem.Value))
                            AddModelResultToChart(sectionTypeItem, nModelID, AreaVolType.Area, fLowerElev.Value, ref fMinY1, ref fMaxY1);
                    }

                    foreach (ListItem sectionTypeItem in chkVolSectionTypes.CheckedItems)
                    {
                        if (ModelResultData[nModelID].SectionTypes.ContainsKey(sectionTypeItem.Value))
                            AddModelResultToChart(sectionTypeItem, nModelID, AreaVolType.Volume, fLowerElev.Value, ref fMinY2, ref fMaxY2);
                    }

                    double fInterval, fAxisMin, fAxisMax = 0;

                    // First axis for Area
                    formatAxis(fMinY1, fMaxY1, out fInterval, out fAxisMin, out fAxisMax);
                    chtData.ChartAreas[0].AxisY.Interval = fInterval;
                    chtData.ChartAreas[0].AxisY.Minimum = fAxisMin;
                    chtData.ChartAreas[0].AxisY.Maximum = fAxisMax;
                    chtData.ChartAreas[0].AxisY.MajorGrid.Interval = fInterval;
                    chtData.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                    chtData.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                    chtData.ChartAreas[0].AxisY.MinorGrid.Interval = fInterval / 2;
                    chtData.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.GhostWhite;
                    chtData.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                    chtData.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;
                    chtData.ChartAreas[0].AxisY.Enabled = chkAreaSectionTypes.CheckedItems.Count > 0 ? AxisEnabled.True : AxisEnabled.False;
                    chtData.ChartAreas[0].AxisY.IsStartedFromZero = false;

                    // Second Y axis for volume
                    formatAxis(fMinY2, fMaxY2, out fInterval, out fAxisMin, out fAxisMax);
                    chtData.ChartAreas[0].AxisY2.Interval = fInterval;
                    chtData.ChartAreas[0].AxisY2.Minimum = fAxisMin;
                    chtData.ChartAreas[0].AxisY2.Maximum = fAxisMax;
                    chtData.ChartAreas[0].AxisY2.MajorGrid.Interval = fInterval;
                    chtData.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray;

                    chtData.ChartAreas[0].AxisY2.MinorGrid.Enabled = true;
                    chtData.ChartAreas[0].AxisY2.MinorGrid.Interval = fInterval / 2;
                    chtData.ChartAreas[0].AxisY2.MinorGrid.LineColor = Color.GhostWhite;
                    chtData.ChartAreas[0].AxisY2.MinorTickMark.Enabled = true;
                    chtData.ChartAreas[0].AxisY2.MinorTickMark.LineColor = Color.LightGray;
                    chtData.ChartAreas[0].AxisY2.Enabled = chkVolSectionTypes.CheckedItems.Count > 0 ? AxisEnabled.True : AxisEnabled.False;
                    chtData.ChartAreas[0].AxisY2.IsStartedFromZero = false;
                }
            }
        }

        private void AddModelResultToChart(ListItem sectionTypeItem, long nModelID, AreaVolType eType, double fLowerElev, ref double fMinY, ref double fMaxY)
        {
            AxisType eAxis = AxisType.Primary;
            string sTypeName = "AREA";
            MarkerStyle eMarker = MarkerStyle.Circle;
            if (eType == AreaVolType.Volume)
            {
                eAxis = AxisType.Secondary;
                sTypeName = "VOLUME";
                eMarker = MarkerStyle.Square;
            }

            System.Diagnostics.Debug.Print("Loading {0} for section {1} - {2}", ModelResultData[nModelID].Title, sectionTypeItem, sTypeName);
            Series theSeries = chtData.Series.Add(string.Format("{0} - {1} - {2}", ModelResultData[nModelID].Title, sectionTypeItem.Text, sTypeName));
            theSeries.ChartType = SeriesChartType.Line;
            theSeries.BorderWidth = 2;
            theSeries.MarkerSize = 10;
            theSeries.BorderDashStyle = ChartDashStyle.Dash;
            theSeries.MarkerStyle = eMarker;
            theSeries.YAxisType = eAxis;

            foreach (SurveyResults aSurvey in ModelResultData[nModelID].SectionTypes[sectionTypeItem.Value].Surveys.Values)
            {
                // See if this model result contains the section type
                foreach (double fElevation in aSurvey.Elevations.Keys)
                {
                    if (fElevation >= fLowerElev)
                    {
                        double displayValue = aSurvey.Elevations[fElevation].Area;
                        if (eType == AreaVolType.Volume)
                            displayValue = aSurvey.Elevations[fElevation].Vol;

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

        private void formatAxis(double fMin, double fMax, out double fInterval, out double fAxisMin, out double fAxisMax)
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
            this.BeginInvoke((MethodInvoker)(() => UpdateChart(null, null)));
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

            UpdateChart(null, null);
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
            UpdateChart(null, null);
        }
    }
}
