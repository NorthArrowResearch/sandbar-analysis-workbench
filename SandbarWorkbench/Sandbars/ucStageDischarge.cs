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
        public StageDischargeCurve SDCurve { get; set; }

        public ucStageDischarge()
        {
            InitializeComponent();
        }

        private void ucStageDischarge_Load(object sender, EventArgs e)
        {


            LoadStageDischargeCurve();


        }

        private void LoadStageDischargeCurve()
        {
            chtData.Series.Clear();
            Series theSeries = chtData.Series.Add("Stage Discharge");
            theSeries.ChartType = SeriesChartType.Line;

            if (SDCurve.HasAllValues)
            {
                for (double fQ = 7500; fQ < 50000; fQ += 1000)
                {
                    theSeries.Points.AddXY(fQ, SDCurve.Stage(fQ));
                }

                chtData.ChartAreas[0].AxisY.Minimum = 900;
            }
        }
    }
}
