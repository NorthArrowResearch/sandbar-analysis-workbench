using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SandbarWorkbench.Sandbars
{
    public partial class ucStageDischarge : UserControl
    {
        public StageDischargeCurve SDCurve { get; internal set; }
        public Dictionary<long, AnalysisBin> AnalysisBins { get; internal set; }

        public ucStageDischarge()
        {
            InitializeComponent();
        }

        private void ucStageDischarge_Load(object sender, EventArgs e)
        {
            if (SDCurve == null)
                return;

            AnalysisBins = AnalysisBin.Load(DBCon.ConnectionStringLocal);
            LoadStageDischargeCurve();

            chtData.ChartAreas[0].AxisX.Title = "Discharge (cfs)";
            chtData.ChartAreas[0].AxisX.LabelStyle.Format = "#,##0";
            chtData.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chtData.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.GhostWhite;
            chtData.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chtData.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.LightGray;

            chtData.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chtData.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chtData.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.GhostWhite;
            chtData.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chtData.ChartAreas[0].AxisY.MinorTickMark.LineColor = Color.LightGray;

            chtData.ChartAreas[0].AxisY.Title = "Stage (ft)";

            // Should trigger calculation of stage.
            valDischarge.Value = 8000;
        }

        private void LoadStageDischargeCurve()
        {
            if (!(SDCurve is StageDischargeCurve))
                return;

            chtData.Series.Clear();
            Series theSeries = chtData.Series.Add("Stage Discharge");
            theSeries.ChartType = SeriesChartType.Line;
            theSeries.IsVisibleInLegend = false;

            Nullable<double> fMinStage = new Nullable<double>();
            Nullable<double> fStage;
            if (SDCurve.HasAllValues)
            {
                for (double fQ = 7500; fQ < 50000; fQ += 1000)
                {
                    fStage = SDCurve.Stage(fQ);
                    theSeries.Points.AddXY(fQ, fStage);

                    if (fMinStage.HasValue)
                        fMinStage = Math.Min(fStage.Value, fMinStage.Value);
                    else
                        fMinStage = fStage;
                }

                chtData.ChartAreas[0].AxisY.Minimum = Math.Floor(fMinStage.Value / 10.0) * 10;

                Series BinSeries = chtData.Series.Add("Analysis Bin Discharges");
                BinSeries.IsVisibleInLegend = false;
                BinSeries.ChartType = SeriesChartType.Point;
                BinSeries.BorderWidth = 2;
                BinSeries.MarkerSize = 10;
                BinSeries.MarkerStyle = MarkerStyle.Circle;
                BinSeries.Color = Color.Red;

                SortedList<double, double> lBins = AnalysisBin.GetActiveBinBoundaries(AnalysisBins.Values);
                foreach (double fBin in lBins.Values)
                {
                    fStage = SDCurve.Stage(fBin);
                    if (fStage.HasValue)
                    {
                        int nPoint = BinSeries.Points.AddXY(fBin, fStage);
                        BinSeries.Points[nPoint].Label = string.Format("{0:#,##0} cfs stage is {1:0.00}", fBin, fStage.Value);
                    }
                }
            }
        }

        private void valDischarge_ValueChanged(object sender, EventArgs e)
        {
            if (SDCurve is StageDischargeCurve)
            {
                Nullable<double> fStage = SDCurve.Stage((double)valDischarge.Value);
                if (fStage.HasValue)
                    txtStage.Text = fStage.Value.ToString("#,##0.00");
            }
        }
    }
}
