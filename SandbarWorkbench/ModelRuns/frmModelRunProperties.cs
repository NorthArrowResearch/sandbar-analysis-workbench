using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.ModelRuns
{
    public partial class frmModelRunProperties : Form
    {
        private ModelRunLocal ModelRun { get; set; }

        // Track whether this model run is the official published model run
        // when the form first opens. This is used to decide whether a confirm
        // message is needed on OK.
        private bool InitialPublishState { get; set; }

        public frmModelRunProperties(long nModelRunID)
        {
            InitializeComponent();

            ModelRun = ModelRunLocal.LoadSingle(nModelRunID);
            InitialPublishState = ModelRun.Published;
        }

        public frmModelRunProperties(ref ModelRunLocal aRun)
        {
            InitializeComponent();

            ModelRun = aRun;
        }

        private void frmModelRunProperties_Load(object sender, EventArgs e)
        {
            tt.SetToolTip(txtTitle, "Name that identifies the model run. Max 50 characters.");
            tt.SetToolTip(txtRemarks, "Remarks describing the purpose of the model run and provide relevant background information. Max 1000 characters.");
            tt.SetToolTip(chkSync, "Check this box to include this model run when synchronizing data between the master and your local copy of the workbench. Only models that are set to synchronize are present on the master database.");
            tt.SetToolTip(chkPublished, "Check this box to make this the one and only model run that is connected to the public web site showing sandbar analysis results.");

            txtTitle.Text = ModelRun.Title;
            txtRemarks.Text = ModelRun.Remarks;
            chkSync.Checked = ModelRun.Sync;
            chkPublished.Checked = ModelRun.Published;
            UpdateCheckBoxes(null, null);
        }

        private DialogResult ConfirmPublish()
        {
            DialogResult eResult = MessageBox.Show("Please confirm that you want to make this the one and only model run that is used to populate the Sandbar Analysis web site data tables and plots?",
                 "Confirmation Required", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (eResult == DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            return eResult;
        }

        /// <summary>
        /// Published state has changed. Confirm with the user that they want to do this. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Saying "no" should uncheck the checkbox. Clicking "Cancel"
        /// should close the form, cancelling the whole operation.</remarks>
        private void chkPublished_Changed(object sender, EventArgs e)
        {
            if (chkPublished.Checked)
            {
                if (ConfirmPublish() != DialogResult.Yes)
                    chkPublished.Checked = false;
            }

            UpdateCheckBoxes(sender, e);
        }

        private void UpdateCheckBoxes(object sender, EventArgs e)
        {

            // The publish is only available for synced model runs
            chkPublished.Enabled = chkSync.Checked;

            // The sync can only be changed if the model run is not the official run
            chkSync.Enabled = !chkPublished.Checked;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            // If the model run was not originally selected as the official
            // published run but is now, then reconfirm with the user.
            if (!InitialPublishState && chkPublished.Checked)
            {
                if (ConfirmPublish() != DialogResult.Yes)
                    return;
            }

            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            using (SQLiteConnection conLocal = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                conLocal.Open();
                using (MySqlConnection conMaster = new MySqlConnection(DBCon.ConnectionStringMaster))
                {
                    conMaster.Open();

                    SQLiteTransaction transLocal = conLocal.BeginTransaction();
                    MySqlTransaction transMaster = conMaster.BeginTransaction();

                    try
                    {
                        // Update the local run first. Note that this will update the properties of the
                        // ModelRun object itself, which can then be used to update the master DB
                        ModelRun.Update(ref transLocal, txtTitle.Text, txtRemarks.Text, chkSync.Checked);

                        if (ModelRun.MasterID > 0)
                        {
                            if (chkSync.Checked)
                            {
                                // Model run exists on master. UPDATE master
                                MySqlCommand comMaster = new MySqlCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @EditedBy WHERE MasterRunID = @MasterRunID", transMaster.Connection, transMaster);
                                comMaster.Parameters.AddWithValue("MasterRunID", ModelRun.MasterID);
                                comMaster.Parameters.AddWithValue("title", ModelRun.Title);
                                comMaster.Parameters.AddWithValue("EditedBy", Environment.UserName);
                                comMaster.Parameters.AddWithValue("UpdatedOn", ModelRun.UpdatedOn);
                                DBHelpers.MySQLHelpers.AddStringParameterN(ref comMaster, ref txtRemarks, "Remarks");
                                comMaster.ExecuteNonQuery();
                            }
                            else
                            {
                                // Model Run exists on master but now set to not sync // DELETE on master
                                ModelRunMaster.Delete(ModelRun.MasterID, ref transMaster);
                            }
                        }
                        else
                        {
                            if (chkSync.Checked)
                            {     // Model run does not exist on master but now needs to sync. INSERT to master
                                ModelRun.MasterID = ModelRunMaster.Insert(ModelRun, ref transMaster, ref transLocal).ID;
                            }
                        }

                        transLocal.Commit();
                        transMaster.Commit();
                    }
                    catch (Exception ex)
                    {
                        transLocal.Rollback();
                        transMaster.Rollback();
                        ExceptionHandling.NARException.HandleException(ex);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                MessageBox.Show("You must provide a title for the model run.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
