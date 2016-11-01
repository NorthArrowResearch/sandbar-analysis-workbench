using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Sandbars.Analysis
{
    public partial class ucSurveyDatePicker : UserControl
    {
        public enum DefaultSelectionType
        {
            Earliest,
            Latest
        }

        public List<DateTime> SurveyDates { get; set; }
        public DefaultSelectionType DefaultSelection { get; set; }

        public ucSurveyDatePicker()
        {
            InitializeComponent();
            DefaultSelection = DefaultSelectionType.Latest;
            cboDates.FormatString = "d MMM";
        }

        private void ucSurveyDatePicker_Load(object sender, EventArgs e)
        {
            if (SurveyDates == null)
                return;

            cboYear.Items.AddRange(SurveyDates.Select(x => x.Year as object).Distinct<object>().ToArray());

            // Default select either the earliest or latest survey depending on if this is a "from" or "to" usage
            if (cboYear.Items.Count > 0)
            {
                if (DefaultSelection == DefaultSelectionType.Latest)
                    cboYear.SelectedIndex = 0;
                else
                    cboYear.SelectedIndex = cboYear.Items.Count - 1;
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDates.Items.Clear();
            foreach (DateTime aDate in SurveyDates.Where(x => x.Year == (Int32)cboYear.SelectedItem))
            {
                cboDates.Items.Add(aDate);
            }

            if (cboDates.Items.Count >0)
            {
                if (DefaultSelection == DefaultSelectionType.Latest)
                    cboDates.SelectedIndex = 0;
                else
                    cboDates.SelectedIndex = cboDates.Items.Count - 1;
            }
        }
    }
}
