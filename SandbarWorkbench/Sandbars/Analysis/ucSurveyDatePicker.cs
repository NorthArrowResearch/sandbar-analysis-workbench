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

        public Nullable<DateTime> SelectedDate
        {
            get
            {
                if (cboDates.SelectedItem is DateTime)
                    return new Nullable<DateTime>((DateTime)cboDates.SelectedItem);
                else
                    return new Nullable<DateTime>();
            }
        }

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

            if (cboDates.Items.Count > 0)
            {
                if (DefaultSelection == DefaultSelectionType.Latest)
                    cboDates.SelectedIndex = 0;
                else
                    cboDates.SelectedIndex = cboDates.Items.Count - 1;
            }
        }

        public bool ValidateForm(string sType, ucSurveyDatePicker ucStart = null)
        {
            bool bResult = false;
            Nullable<DateTime> selDate = SelectedDate;

            if (selDate.HasValue)
            {
                if (ucStart is ucSurveyDatePicker && ucStart.SelectedDate.HasValue)
                {
                    // This control should possess a date that is after the start
                    if (selDate.Value > ucStart.SelectedDate.Value)
                    {
                        bResult = true;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("The {0} date must occur after the start date.", sType), SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboDates.Select();
                    }
                }
                else
                {
                    // If no comparison control then a valid date is all we need
                    bResult = true;
                }
            }
            else
            {
                MessageBox.Show(string.Format("Invalid {0}", sType), SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDates.Select();
            }
            return bResult;
        }
    }
}
