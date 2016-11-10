using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
