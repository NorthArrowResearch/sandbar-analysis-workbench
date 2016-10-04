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
            ModelRuns = ModelRun.Load(DBCon.ConnectionString);
            grdAnalyses.DataSource = ModelRuns;

            string sSQL = string.Format("SELECT ItemID, Title FROM LookupListItems WHERE ListID = {0}", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
            CheckedListItem.LoadComboWithListItems(ref chkAreaSectionTypes, DBCon.ConnectionString, sSQL, false);
            CheckedListItem.LoadComboWithListItems(ref chkVolSectionTypes, DBCon.ConnectionString, sSQL, false);

            chtData.ChartAreas[0].AxisX.Title = "Date";
            chtData.ChartAreas[0].AxisY.Title = "Sandbar Area (m²)";

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

        private void grdAnalyses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                foreach (ListItem sectionTypeItem in chkAreaSectionTypes.CheckedItems)
                {
                    foreach (long nModelID in ModelResultData.Keys)
                    {
                        if (ModelResultData[nModelID].SectionTypes.ContainsKey(sectionTypeItem.Value))
                        {
                            Series theSeries = chtData.Series.Add(string.Format("{0} - {1}", ModelResultData[nModelID].Title, sectionTypeItem.Text));
                            theSeries.ChartType = SeriesChartType.Line;
                            theSeries.BorderWidth = 2;
                            theSeries.MarkerSize = 10;
                            theSeries.BorderDashStyle = ChartDashStyle.Dash;
                            theSeries.MarkerStyle = MarkerStyle.Circle;

                            double fMinY = -1;
                            double fMaxY = -1;

                            foreach (SurveyResults aSurvey in ModelResultData[nModelID].SectionTypes[sectionTypeItem.Value].Surveys.Values)
                            {
                                // See if this model result contains the section type
                                foreach (double fElevation in aSurvey.Elevations.Keys)
                                {
                                    if (fElevation >= fLowerElev)
                                    {
                                        theSeries.Points.AddXY(aSurvey.SurveyDate, aSurvey.Elevations[fElevation].Area);

                                        if (fMinY == -1 || fMinY > aSurvey.Elevations[fElevation].Area)
                                            fMinY = aSurvey.Elevations[fElevation].Area;

                                        fMaxY = Math.Max(fMaxY, aSurvey.Elevations[fElevation].Area);

                                        break;
                                    }
                                }
                            }

                            double fInterval, fAxisMin, fAxisMax = 0;
                            formatAxis(fMinY, fMaxY, out fInterval, out fAxisMin, out fAxisMax);
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
                        }
                    }
                }

            }
        }

        private void formatAxis(double fMin, double fMax, out double fInterval, out double fAxisMin, out double fAxisMax)
        {
            double fRange = fMax - fMin;
            double fExponent = (int) Math.Log10(fRange);
            double fMagnitude = Math.Pow(10, fExponent);
            fInterval = fMagnitude / 10;
            fAxisMin = Math.Floor(fMin / fInterval) * fInterval;
            fAxisMax = Math.Ceiling(fMax / fInterval) * fInterval;
            fInterval = fInterval *2;
        }

        private void chkVolSectionTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateChart(null, null);
        }

        private void grdAnalyses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool bDataAdded = false;
            foreach (DataGridViewRow aRow in grdAnalyses.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)aRow.Cells[0];

                ModelRun theModel = (ModelRun)aRow.DataBoundItem;
                if (aRow.Cells[0].Value == chk.TrueValue)
                {
                    if (ModelResultData == null)
                        ModelResultData = new Dictionary<long, ModelResults>();

                    if (!ModelResultData.ContainsKey(theModel.RunID))
                    {
                        ModelResultData[theModel.RunID] = new ModelResults(DBCon.ConnectionString, SandbarSite.SiteID, theModel.RunID, theModel.Title);
                        bDataAdded = true;
                    }
                }
                else
                {
                    if (ModelResultData != null)
                        if (ModelResultData.ContainsKey(theModel.RunID))
                            ModelResultData.Remove(theModel.RunID);
                }
            }

            if (bDataAdded)
                UpdateChart(null, null);
        }
    }
}
