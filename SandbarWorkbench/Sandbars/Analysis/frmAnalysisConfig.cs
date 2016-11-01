using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars.Analysis
{
    public partial class frmAnalysisConfig : Form
    {
        private List<SandbarSite> SitesToProcess { get; set; }

        public frmAnalysisConfig(List<SandbarSite> lSites)
        {
            InitializeComponent();
            SitesToProcess = lSites;

            // Unique dates across all sites
            List<DateTime> lDates = new List<DateTime>();
            foreach (SandbarSite aSite in SitesToProcess)
            {
                lDates = lDates.Union<DateTime>(aSite.Surveys.Select<SandbarSurvey, DateTime>(x => x.SurveyDate).ToList<DateTime>()).ToList<DateTime>();
            }

            ucAnalysisFrom.SurveyDates = lDates;
            ucAnalysisTo.SurveyDates = lDates;
            ucMinimumFrom.SurveyDates = lDates;
            ucMinimumTo.SurveyDates = lDates;

            ucAnalysisFrom.DefaultSelection = ucSurveyDatePicker.DefaultSelectionType.Earliest;
            ucMinimumFrom.DefaultSelection = ucSurveyDatePicker.DefaultSelectionType.Earliest;
        }

        private void frmAnalysisConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
