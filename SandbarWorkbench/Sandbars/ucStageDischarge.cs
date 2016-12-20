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
        public StageDischarge.SDCurve SDCurve { get; internal set; }
        public Dictionary<long, AnalysisBin> AnalysisBins { get; internal set; }

        public ucStageDischarge()
        {
            InitializeComponent();
        }

        private void ucStageDischarge_Load(object sender, EventArgs e)
        {
            if (SDCurve == null || !SDCurve.CoeffA.HasValue)
            {
                groupBox1.Visible = false;
                chtData.Visible = false;
                return;
            }


            AnalysisBins = AnalysisBin.Load(DBCon.ConnectionStringLocal);
            LoadStageDischargeCurve();

            cboSamples.DataSource = SDCurve.StageDischargeSamples;
            cboSamples.ValueMember = "SampleID";
            cboSamples.DisplayMember = "Title";

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

            chtData.ChartAreas[0].AxisY.Title = "Stage (m)";

            // Should trigger calculation of stage.
            valDischarge.Value = 8000;
        }

        private void LoadStageDischargeCurve()
        {
            if (!(SDCurve is StageDischarge.SDCurve))
                return;

            chtData.Series.Clear();
            Series theSeries = chtData.Series.Add("Stage Discharge Curve");
            theSeries.ChartType = SeriesChartType.Line;

            Title chtTitle = chtData.Titles.Add(string.Format("Stage Discharge Curve for Site {0}", SDCurve.SiteName));
            chtTitle.Font = new Font(chtTitle.Font, FontStyle.Bold);
            chtData.Titles.Add(string.Format("Elevation = {0} + ({1} * Q) + ({2} * Q^2)", SDCurve.CoeffA, SDCurve.CoeffB, SDCurve.CoeffC));

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

            LoadStageDischargeValues();
        }

        private void LoadStageDischargeValues()
        {
            if (this.SDCurve.LoadStageDischargeValues() > 0)
            {
                string sSampleSeries = "Samples";
                Series seriesSV = chtData.Series.FindByName(sSampleSeries);
                if (seriesSV == null)
                {
                    seriesSV = new Series("Samples");
                    chtData.Series.Insert(0, seriesSV); // This ensures that the sample points get displayed at the bottom of the Z order.
                }
                seriesSV.ChartType = SeriesChartType.Point;
                seriesSV.Color = Color.DarkGray;
                seriesSV.MarkerStyle = MarkerStyle.Circle;
                seriesSV.BorderWidth = 2;
                seriesSV.MarkerSize = 10;

                foreach (StageDischarge.SDValue aSample in SDCurve.StageDischargeSamples)
                {
                    int nPoint = seriesSV.Points.AddXY(aSample.Flow, aSample.ElevationSP);
                    seriesSV.Points[nPoint].ToolTip = aSample.ToolTip;
                }
            }
        }

        private void valDischarge_ValueChanged(object sender, EventArgs e)
        {
            if (SDCurve is StageDischarge.SDCurve)
            {
                Nullable<double> fStage = SDCurve.Stage((double)valDischarge.Value);
                if (fStage.HasValue)
                    txtStage.Text = fStage.Value.ToString("#,##0.00");
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Title = "Export Stage Discharge Curve";
            frm.Filter = "Comma Separated Value Files (*.csv)|*.csv";
            frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);
            frm.FileName = string.Format("{0}_stage_discharge_curve", SDCurve.SiteName);

            frm.AddExtension = true;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(frm.FileName, SDCurve.CurveAsCSV(8000, 45000, 500));
                if (System.IO.File.Exists(frm.FileName))
                {
                    System.Diagnostics.Process.Start(frm.FileName);
                }
            }
        }

        private void cboSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSelectedSample = "Selected Sample";

            Series selSampleSeries = chtData.Series.FindByName(sSelectedSample);
            if (selSampleSeries == null)
            {
                selSampleSeries = new Series(sSelectedSample);
                chtData.Series.Insert(0, selSampleSeries);
                selSampleSeries.ChartType = SeriesChartType.Point;
                selSampleSeries.Color = Color.Red;
                selSampleSeries.MarkerStyle = MarkerStyle.Square;
                selSampleSeries.BorderWidth = 2;
                selSampleSeries.MarkerSize = 15;
            }

            selSampleSeries.Points.Clear();
            if (cboSamples.SelectedItem is StageDischarge.SDValue)
            {
                StageDischarge.SDValue sdValue = (StageDischarge.SDValue)cboSamples.SelectedItem;
                int ptIndex = selSampleSeries.Points.AddXY(sdValue.Flow, sdValue.ElevationSP);
                selSampleSeries.Points[ptIndex].ToolTip = sdValue.ToolTip;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StageDischarge.frmSDSample frm = new StageDischarge.frmSDSample(SDCurve.SiteID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                    DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                    sync.SynchronizeLookupTables();

                    LoadStageDischargeValues();
                    cboSamples.DataSource = SDCurve.StageDischargeSamples;

                    for (int i = 0; i < cboSamples.Items.Count; i++)
                    {
                        if (((StageDischarge.SDValue)cboSamples.Items[i]).SampleID == frm.ID)
                        {
                            cboSamples.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
            finally
            {
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (cboSamples.SelectedItem is StageDischarge.SDValue)
            {
                try
                {
                    StageDischarge.frmSDSample frm = new StageDischarge.frmSDSample((StageDischarge.SDValue)cboSamples.SelectedItem);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                        DBHelpers.SyncHelpers sync = new DBHelpers.SyncHelpers();
                        sync.SynchronizeLookupTables();

                        LoadStageDischargeValues();
                        cboSamples.DataSource = SDCurve.StageDischargeSamples;

                        for (int i = 0; i < cboSamples.Items.Count; i++)
                        {
                            if (((StageDischarge.SDValue)cboSamples.Items[i]).SampleID == frm.ID)
                            {
                                cboSamples.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                }
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (cboSamples.SelectedItem is StageDischarge.SDValue)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                    StageDischarge.SDValue.Delete(((StageDischarge.SDValue)cboSamples.SelectedItem).SampleID);
                    LoadStageDischargeValues();
                    cboSamples.DataSource = SDCurve.StageDischargeSamples;
                }
                catch (Exception ex)
                {
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                }

            }
        }

        private void cmdExportSamples_Click(object sender, EventArgs e)
        {
            SaveFileDialog frm = new SaveFileDialog();
            frm.Title = "Export Stage Discharge Samples";
            frm.Filter = "Comma Separated Value Files (*.csv)|*.csv";
            frm.InitialDirectory = System.IO.Path.GetDirectoryName(DBCon.DatabasePath);
            frm.FileName = string.Format("{0}_stage_discharge_samples", SDCurve.SiteName);

            frm.AddExtension = true;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(frm.FileName, SDCurve.SamplesAsCSV());
                if (System.IO.File.Exists(frm.FileName))
                {
                    System.Diagnostics.Process.Start(frm.FileName);
                }
            }
        }
    }
}
