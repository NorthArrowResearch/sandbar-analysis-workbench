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

        public frmModelRunProperties(long nModelRunID)
        {
            InitializeComponent();

            ModelRun = ModelRunLocal.LoadSingle(nModelRunID);
        }

        private void frmModelRunProperties_Load(object sender, EventArgs e)
        {
            txtTitle.Text = ModelRun.Title;
            txtRemarks.Text = ModelRun.Remarks;
            chkSync.Checked = ModelRun.Sync;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            using (SQLiteConnection conLocal = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                conLocal.Open();
                using (MySqlConnection conMaster = new MySqlConnection(DBCon.ConnectionStringLocal))
                {
                    conMaster.Open();

                    SQLiteTransaction transLocal = conLocal.BeginTransaction();
                    MySqlTransaction transMaster = conMaster.BeginTransaction();

                    try
                    {
                        // Update the local run first. Note that this will update the properties of the
                        // ModelRun object itself, which can then be used to update the master DB
                        ModelRun.Update(ref transLocal, txtTitle.Text, txtRemarks.Text, chkSync.Checked);

                        // Model run does not exist on master but now needs to sync. INSERT to master
                        if (ModelRun.MasterID == 0 && !ModelRun.Sync && chkSync.Checked)
                            ModelRunMaster.Insert(ModelRun, ref transMaster, ref transLocal);

                        // Model run exists on master. UPDATE master
                        if (ModelRun.MasterID > 0 && ModelRun.Sync && chkSync.Checked)
                        {
                            MySqlCommand comMaster = new MySqlCommand("UPDATE ModelRuns SET Title = @Title, Remarks = @Remarks, UpdatedOn = @UpdatedOn, UpdatedBy = @EditedBy WHERE MasterRunID = @MasterRunID", transMaster.Connection, transMaster);
                            comMaster.Parameters.AddWithValue("MasterRunID", ModelRun.MasterID);
                            comMaster.Parameters.AddWithValue("title", ModelRun.Title);
                            comMaster.Parameters.AddWithValue("EditedBy", Environment.UserName);
                            comMaster.Parameters.AddWithValue("UpdatedOn", ModelRun.UpdatedOn);
                            DBHelpers.MySQLHelpers.AddStringParameterN(ref comMaster, ref txtRemarks, "Remarks");
                            comMaster.ExecuteNonQuery();
                        }

                        // Model Run exists on master but now set to not sync // DELETE on master
                        if (ModelRun.MasterID > 0 && ModelRun.Sync && !chkSync.Checked)
                            ModelRunMaster.Delete(ModelRun.MasterID, ref transMaster);

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
    }
}
