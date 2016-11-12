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
                    foreach (ModelRunMaster masterRun in dMasterRuns.Values)
                    {
                        if (masterRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash)
                        {
                            // Find the local run that has the corresponding master run ID
                            List<ModelRunLocal> lLocalRuns = dLocalRuns.Values.Where<ModelRunLocal>(x => x.MasterID == masterRun.ID).ToList<ModelRunLocal>();
                            if (lLocalRuns != null && lLocalRuns.Count > 0)
                            {
                                // found the corresponding local run. Check if the local run is still set to sync.
                                if (lLocalRuns[0].Sync)
                                {
                                    // Check if either has been updated and then update the older of the two.
                                    if (lLocalRuns[0].UpdatedOn > masterRun.UpdatedOn)
                                        masterRun.Update(lLocalRuns[0], ref transMaster);
                                    else if (masterRun.UpdatedOn > lLocalRuns[0].UpdatedOn)
                                        lLocalRuns[0].Update(masterRun, ref transLocal);
                                }
                                else
                                {
                                    // Run owned by this installation exists on both master and local, but the local is set to not sync. Delete on master.
                                    ModelRunMaster.Delete(masterRun.ID, ref transMaster);
                                }
                            }
                            else
                            {
                                // Run belonging to this installation is on master but no longer on local. Delete on master
                                ModelRunMaster.Delete(masterRun.ID, ref transMaster);
                            }
                        }
                        else
                        {
                            List<ModelRunLocal> lLocalRuns = dLocalRuns.Values.Where<ModelRunLocal>(x => x.MasterID == masterRun.ID).ToList<ModelRunLocal>();
                            if (lLocalRuns == null || lLocalRuns.Count < 1)
                            {
                                // Run found on master that belongs to another installation and doesn't exist on local. Insert to local.
                                // TODO: insert local
                            }
                            else
                            {
                                // Run found on master that belongs to another installation that already exists on local. Update.
                                // Check if either has been updated and then update the older of the two.
                                if (lLocalRuns[0].UpdatedOn > masterRun.UpdatedOn)
                                    masterRun.Update(lLocalRuns[0], ref transMaster);
                                else if (masterRun.UpdatedOn > dLocalRuns[masterRun.ID].UpdatedOn)
                                    lLocalRuns[0].Update(masterRun, ref transLocal);
                            }

                        }
                    }

                    // Loop over all rows on local
                    foreach (ModelRunLocal localRun in dLocalRuns.Values)
                    {
                        if (localRun.Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash)
                        {
                            if (localRun.Sync)
                            {
                                if (!dMasterRuns.ContainsKey(localRun.MasterID))
                                {
                                    // TODO: This run was generated on this installation, its set to sync, but it is missing from master. Insert run to master.
                                }
                            }
                            else
                            {
                                if (dMasterRuns.ContainsKey(localRun.MasterID))
                                {
                                    // This run was generated on this installation and exists on master, but it is no longer set to sync. Delete on master.
                                    ModelRunMaster.Delete(localRun.MasterID, ref transMaster);
                                }
                            }
                        }
                        else
                        {
                            if (!dMasterRuns.ContainsKey(localRun.MasterID))
                            {
                                // This is a run from a different installation that no longer exists on master. Delete local.
                                ModelRunLocal.Delete(localRun.MasterID, ref transLocal);
                            }
                        }
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //if (!(chkLookup.Checked || chkResults.Checked))
            //{
            //    MessageBox.Show("You must choose one or both of the data types to synchronize.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}

            //grpProgress.Visible = true;
            //this.Height += VariableHeight;
            //this.FormBorderStyle = FormBorderStyle.Sizable;

            //try
            //{
            //    DBHelpers.SyncHelpers syncTool = new DBHelpers.SyncHelpers("SandbarData", DBCon.ConnectionStringMaster, DBCon.ConnectionStringLocal);

            //    Cursor.Current = Cursors.WaitCursor;

            //    if (chkLookup.Checked)
            //        syncTool.SynchronizeDatabaseType(SandbarWorkbench.Properties.Settings.Default.TableType_LookupTables);

            //    if (chkResults.Checked)
            //        syncTool.SynchronizeDatabaseType(SandbarWorkbench.Properties.Settings.Default.TableType_ResultsTables);

            //    foreach (Form frm in this.MdiChildren)
            //    {
            //        if (frm is Sandbars.frmSandbars)
            //        {
            //            ((Sandbars.frmSandbars)frm).LoadData();
            //        }
            //    }

            //    Cursor.Current = Cursors.Default;
            //    MessageBox.Show("Local database synchronization with the master database was successful.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    ExceptionHandling.NARException.HandleException(ex);
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}

        }
    }
}
