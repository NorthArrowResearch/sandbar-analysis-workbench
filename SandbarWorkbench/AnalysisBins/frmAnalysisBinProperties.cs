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
                DBHelpers.DatabaseObject obj = (DBHelpers.DatabaseObject)this.bin;
                crud.Save(ref obj);
            }
            catch(Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }
    }
}
