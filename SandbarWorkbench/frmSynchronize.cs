using System;
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
            Dictionary<long, ModelRuns.ModelRunMaster> dMasterRuns = ModelRuns.ModelRunMaster.Load();
            Dictionary<long, ModelRuns.ModelRunLocal> dLocalRuns = ModelRuns.ModelRunLocal.Load();

            using (MySql.Data.MySqlClient.MySqlConnection conMaster = new MySql.Data.MySqlClient.MySqlConnection(DBCon.ConnectionStringMaster))
            {
                conMaster.Open();
                MySql.Data.MySqlClient.MySqlTransaction transMaster = conMaster.BeginTransaction();

                using (System.Data.SQLite.SQLiteConnection conLocal = new System.Data.SQLite.SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    conLocal.Open();
                    System.Data.SQLite.SQLiteTransaction transLocal = conLocal.BeginTransaction();

                    // Loop over all runs on master
                    foreach (ModelRunMaster masterRun in dMasterRuns.Values.Where<ModelRunMaster>(x => x.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash))
                    {
                        // Find the local run that has the corresponding master run ID
                        IEnumerable<ModelRunLocal> lLocalRuns = dLocalRuns.Values.Where<ModelRunLocal>(x => x.MasterID == masterRun.ID);
                        if (lLocalRuns.Count<ModelRunLocal>() > 0)
                        {
                            // Delete runs on master that are local to this machine but not longer set to sync
                            foreach (ModelRunLocal aLocal in lLocalRuns.Where<ModelRunLocal>(x => !x.Sync))
                                ModelRunMaster.Delete(masterRun.ID, ref transMaster);

                            // Update runs on local that are newer on master
                            foreach (ModelRunLocal aLocal in lLocalRuns.Where<ModelRunLocal>(x => x.UpdatedOn < masterRun.UpdatedOn))
                                aLocal.Update(masterRun, ref transLocal);
                        }
                        else
                        {
                            // Local run is on master but no longer on local. Delete on master
                            ModelRunMaster.Delete(masterRun.ID, ref transMaster);
                        }
                    }

                    // Delete runs on local that were generated on other machines but no longer on master
                    foreach (ModelRun masterRun in dMasterRuns.Values.Where<ModelRun>(x => x.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash))
                    {
                        if (dLocalRuns.Values.Where<ModelRun>(x => x.OtherID == masterRun.ID).Count<ModelRun>() > 0)
                            ModelRun.DeleteMasterRun(masterRun.ID, ref transMaster);
                    }


                }

            }



            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            


            if (!(chkLookup.Checked || chkResults.Checked))
            {
                MessageBox.Show("You must choose one or both of the data types to synchronize.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                return;
            }

            grpProgress.Visible = true;
            this.Height += VariableHeight;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            try
            {
                DBHelpers.SyncHelpers syncTool = new DBHelpers.SyncHelpers("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);

                Cursor.Current = Cursors.WaitCursor;

                if (chkLookup.Checked)
                    syncTool.SynchronizeDatabaseType(SandbarWorkbench.Properties.Settings.Default.TableType_LookupTables);

                if (chkResults.Checked)
                    syncTool.SynchronizeDatabaseType(SandbarWorkbench.Properties.Settings.Default.TableType_ResultsTables);

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm is Sandbars.frmSandbars)
                    {
                        ((Sandbars.frmSandbars)frm).LoadData();
                    }
                }

                Cursor.Current = Cursors.Default;
                MessageBox.Show("Local database synchronization with the master database was successful.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
