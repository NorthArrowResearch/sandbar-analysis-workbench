﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.AnalysisBins
{
    public partial class frmAnalysisBinProperties : Form
    {
        public AnalysisBin bin { get; internal set; }
        public readonly AnalysisBins.AnalysisBin.BinnedAnalysisTypes BinType;

        public frmAnalysisBinProperties(AnalysisBin.BinnedAnalysisTypes eType, long nBinID = 0)
        {
            InitializeComponent();
            BinType = eType;

            if (nBinID > 0)
                bin = AnalysisBin.Load(nBinID, BinType);
        }

        private void frmAnalysisBinProperties_Load(object sender, EventArgs e)
        {
            tt.SetToolTip(txtTitle, "Unique name for the analysis bin. Max 50 characters.");
            tt.SetToolTip(chkUpper, "Check this box to include a an upper discharge limit for this analysis bin. Uncheck to disable the upper discharge limit.");
            tt.SetToolTip(valUpper, "The upper discharge limit for this analysis bin in cubic feet per second. Uncheck the adjacent box for bins that do not have an upper discharge limit.");
            tt.SetToolTip(chkLower, "Check this box to include a an Lower discharge limit for this analysis bin. Uncheck to disable the Lower discharge limit.");
            tt.SetToolTip(valLower, "The lower discharge limit for this analysis bin in cubic feet per second. Uncheck the adjacent box for bins that do not have an lower discharge limit.");
            tt.SetToolTip(pictureBox1, "The color used to display this analysis bin on charts and visualizations. Click this area to pick a different color.");
            tt.SetToolTip(chkActive, "Check this box to include this analysis bin in future runs of the sandbar analysis script.");

            if (bin is AnalysisBin)
            {
                txtTitle.Text = bin.Title;
                chkActive.Checked = bin.IsActive;

                chkUpper.Checked = bin.UpperDischarge.HasValue;
                if (bin.UpperDischarge.HasValue)
                    valUpper.Value = (decimal)bin.UpperDischarge.Value;

                chkLower.Checked = bin.LowerDischarge.HasValue;
                if (bin.LowerDischarge.HasValue)
                    valLower.Value = (decimal)bin.LowerDischarge.Value;

                pictureBox1.BackColor = bin.DisplayColor;
                frmColourPicker.SolidColorOnly = true;
                frmColourPicker.ShowHelp = false;
            }
            else
            {
                // Pick a random known color.
                // http://stackoverflow.com/questions/5805774/how-to-generate-random-color-names-in-c-sharp
                Random randomGen = new Random(DateTime.Now.Millisecond);
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                pictureBox1.BackColor = Color.FromKnownColor(randomColorName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmColourPicker.Color = pictureBox1.BackColor;
            if (frmColourPicker.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = frmColourPicker.Color;
        }

        public void UpdateControls(object sender, EventArgs e)
        {
            valUpper.Enabled = chkUpper.Checked;
            valLower.Enabled = chkLower.Checked;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("The analysis bin name cannot be empty.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Select();
                return false;
            }

            if (chkLower.Checked && chkUpper.Checked)
            {
                if (valLower.Value >= valUpper.Value)
                {
                    MessageBox.Show("The lower discharge must be below the upper bin discharge.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    valLower.Select();
                    return false;
                }
            }

            if (!chkLower.Checked && ! chkUpper.Checked)
            {
                MessageBox.Show("You must specify either a lower or upper bin discharge.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                valLower.Select();
                return false;
            }

            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                AnalysisBinCRUD crud = new AnalysisBinCRUD();

                Nullable<double> fLower = new Nullable<double>();
                if (chkLower.Checked)
                    fLower = (double)valLower.Value;

                Nullable<double> fUpper = new Nullable<double>();
                if (chkUpper.Checked)
                    fUpper = (double)valUpper.Value;

                if (bin == null)
                {
                    bin = new AnalysisBin(txtTitle.Text, fLower, fUpper, chkActive.Checked, BinType, pictureBox1.BackColor, Environment.UserName);
                }
                else
                {
                    bin.Title = txtTitle.Text;
                    bin.LowerDischarge = fLower;
                    bin.UpperDischarge = fUpper;
                    bin.DisplayColor = pictureBox1.BackColor;
                    bin.IsActive = chkActive.Checked;
                }

                DBHelpers.DatabaseObject obj = (DBHelpers.DatabaseObject)this.bin;
                crud.Save(ref obj);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmAnalysisBinProperties_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
