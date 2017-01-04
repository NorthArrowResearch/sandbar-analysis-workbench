using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
                    reach = new Reach(txtReachName.Text, txtReachCode.Text, Environment.UserName);
                }
                else
                {
                    reach.Title = txtReachName.Text;
                    reach.ReachCode = txtReachCode.Text;
                }

                DBHelpers.DatabaseObject obj = (DBHelpers.DatabaseObject)this.reach;
                crud.Save(ref obj);
            }
            catch (Exception ex)
            {
                ExceptionHandling.NARException.HandleException(ex);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
