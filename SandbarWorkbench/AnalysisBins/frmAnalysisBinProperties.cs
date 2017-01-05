using MySql.Data.MySqlClient;
using System;
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

        public frmAnalysisBinProperties(long nBinID = 0)
        {
            InitializeComponent();

            if (nBinID > 0)
                bin = AnalysisBin.Load(nBinID);
        }

        private void frmAnalysisBinProperties_Load(object sender, EventArgs e)
        {
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
                    bin = new AnalysisBin(txtTitle.Text, fLower, fUpper, chkActive.Checked, pictureBox1.BackColor, Environment.UserName);
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
            catch (MySqlException ex)
            {
                string sNoun = string.Empty;

                if (ex.Message.ToLower().Contains("ix_analysisbins_title"))
                {
                    sNoun = "Analysis Bin Name";
                    txtTitle.Select();
                }

                if (!string.IsNullOrEmpty(sNoun))
                {
                    string sMessage = string.Format("An analysis bin with this {0} already exists on the master database. Please choose a unique {0}. {1}", sNoun.ToLower(), SandbarWorkbench.Properties.Resources.SyncRequiredWarning);
                    string sTitle = string.Format("Duplicate {0}", sNoun);

                    MessageBox.Show(sMessage, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
