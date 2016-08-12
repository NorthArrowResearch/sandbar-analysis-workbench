using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbarProperties : Form
    {
        private SandbarSite m_Site;

        public frmSandbarProperties(ref SandbarSite aSite)
        {
            InitializeComponent();

            m_Site = aSite;
            if (m_Site is SandbarSite)
            {
                ucStageDischarge1.SDCurve = m_Site.SDCurve;
                ucAreaVolumeAnalyses1.SandbarSite = m_Site;
                ConfigureSurveysGrid();
            }
        }

        private void frmSandbarProperties_Load(object sender, EventArgs e)
        {
            if (m_Site is SandbarSite)
            {
                txtName.Text = m_Site.Title;
                valRiverMile.Value = (decimal)m_Site.RiverMile;

                grdSurveys.DataSource = m_Site.Surveys;
            }
        }

        private void ConfigureSurveysGrid()
        {
            grdSurveys.RowHeadersVisible = false;
            grdSurveys.AllowUserToAddRows = false;
            grdSurveys.AllowUserToDeleteRows = false;
            grdSurveys.AllowUserToResizeRows = false;
            grdSurveys.AutoGenerateColumns = false;
            grdSurveys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //add them here
            var auditTrailProvider = new SandbarSurvey.MyTypeDescriptionProvider<AuditTrail>();
            System.ComponentModel.TypeDescriptor.AddProvider((new SandbarSurvey.MyTypeDescriptionProvider<AuditTrail>()), typeof(Sandbars.SandbarSurvey));

            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Survey Date", "SurveyDate", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref grdSurveys, "Trip Date", "TripDate", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewAuditColumns(ref grdSurveys);
        }
    }
}
