using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Reaches
{
    public partial class frmReachPropertiesEdit : Form
    {
        public Reach reach { get; internal set; }

        public frmReachPropertiesEdit(long nReachID = 0)
        {
            InitializeComponent();

            if (nReachID > 0)
                reach = Reach.Load(nReachID);
        }

        private void frmReachPropertiesEdit_Load(object sender, EventArgs e)
        {
            tt.SetToolTip(txtReachCode, "Unique reach code. Max 10 characters. This is typically of the form #_XXX where # is an integer and XXX is an acronym identifying the reach.");
            tt.SetToolTip(txtReachName, "Unique reach name. Max 50 characters.");

            if (reach is Reach)
            {
                txtReachCode.Text = reach.ReachCode;
                txtReachName.Text = reach.Title;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtReachCode.Text))
            {
                MessageBox.Show("You must provide a reach code, typically of the form #_XXX", "Missing Reach Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtReachName.Text))
            {
                MessageBox.Show("You must provide a reach name.", "Missing Reach Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ReachCRUD crud = new ReachCRUD();

                if (reach == null)
                {
                    reach = new Reach(txtReachCode.Text, txtReachName.Text, Environment.UserName);
                }
                else
                {
                    reach.Title = txtReachName.Text;
                    reach.ReachCode = txtReachCode.Text;
                }

                DBHelpers.DatabaseObject obj = (DBHelpers.DatabaseObject)this.reach;
                crud.Save(ref obj);
            }
            catch (SQLiteException ex)
            {
                string sNoun = string.Empty;

                if (ex.Message.ToLower().Contains("title_unique"))
                {
                    sNoun = "Reach Name";
                    txtReachName.Select();
                }
                else if (ex.Message.ToLower().Contains("reachcode_unique"))
                {
                    sNoun = "Reach Code";
                    txtReachCode.Select();
                }
                else
                    throw;

                if (!string.IsNullOrEmpty(sNoun))
                {
                    string sMessage = string.Format("A reach with this {0} already exists on the master database. Please choose a unique {0}. {1}", sNoun.ToLower(), SandbarWorkbench.Properties.Resources.SyncRequiredWarning);
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

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmReachPropertiesEdit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
