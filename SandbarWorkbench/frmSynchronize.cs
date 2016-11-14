﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SandbarWorkbench.ModelRuns;

namespace SandbarWorkbench
{
    public partial class frmSynchronize : Form
    {
        DBHelpers.SyncHelpers syncEngine;
        int nTaskPercentage = 0;

        public frmSynchronize()
        {
            InitializeComponent();
        }

        private int VariableHeight
        {
            get
            {
                return grpProgress.Height - (grpProgress.Top - chkResults.Bottom);
            }
        }

        private void frmSynchronize_Load(object sender, EventArgs e)
        {
            // Hide the progress group box and resize the form. Note the border is fixed until user clicks OK.
            grpProgress.Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = this.Height - VariableHeight;
            this.MinimumSize = new Size(this.Width, this.Height);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!(chkLookup.Checked || chkResults.Checked))
            {
                MessageBox.Show("You must choose one or both of the data types to synchronize.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                return;
            }

            grpProgress.Visible = true;
            this.Height += VariableHeight;
            this.MinimumSize = new Size(this.Width, this.Height);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            grpProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            try
            {
                txtProgress.Text = string.Empty;
                cmdOK.Enabled = false;
                syncEngine = new DBHelpers.SyncHelpers("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);
                syncEngine.OnProgressUpdate += syncEngine_OnProgressUpdate;

                syncEngine.LookupTables = chkLookup.Checked || chkResults.Checked;
                syncEngine.ModelRunTables = chkResults.Checked;

                bgWorker.RunWorkerAsync();

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm is Sandbars.frmSandbars)
                    {
                        ((Sandbars.frmSandbars)frm).LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        #region Background worker events

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                syncEngine.Synchronize();
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
        }

        private void syncEngine_OnProgressUpdate(int nOverall, int nTask)
        {
            nTaskPercentage = nTask;
            bgWorker.ReportProgress(nOverall);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int i = txtProgress.Lines.Count<string>(); i < syncEngine.Messages.Count<string>(); i++)
                txtProgress.AppendText(syncEngine.Messages[i] + "\r\n");

            if (e.ProgressPercentage != -1)
                pgrOverall.Value = e.ProgressPercentage;

            if (nTaskPercentage != -1)
                pgrTask.Value = nTaskPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmdOK.Enabled = true;
            cmdCancel.Text = "Close";
        }

        #endregion
    }
}
