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
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();

            List<ListItemInt> lItems = new List<ListItemInt>();
            lItems.Add(new ListItemInt("-- None --", 0));
            lItems.Add(new ListItemInt("Sandbar Sites", 1));
            lItems.Add(new ListItemInt("Remote Camera Sites", 2));
            cboStartupView.ValueMember = "Value";
            cboStartupView.DisplayMember = "Text";
            cboStartupView.DataSource = lItems;
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} Options", SandbarWorkbench.Properties.Resources.ApplicationNameLong);

            cboStartupView.SelectedValue = SandbarWorkbench.Properties.Settings.Default.StartupView;
            chkLoadLastDatabase.Checked = SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase;

            txtMasterServer.Text = SandbarWorkbench.Properties.Settings.Default.MasterServer;
            txtMasterDatabase.Text = SandbarWorkbench.Properties.Settings.Default.MasterDatabase;
            txtMasterUserName.Text = SandbarWorkbench.Properties.Settings.Default.MasterUser;
            txtMasterPassword.Text = SandbarWorkbench.Properties.Settings.Default.MasterPassword;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SandbarWorkbench.Properties.Settings.Default.StartupView = (int)cboStartupView.SelectedValue;
            SandbarWorkbench.Properties.Settings.Default.LoadLastDatabase = chkLoadLastDatabase.Checked;

            // Master database connection properties
            SandbarWorkbench.Properties.Settings.Default.MasterServer = txtMasterServer.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterDatabase = txtMasterDatabase.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterUser = txtMasterUserName.Text;
            SandbarWorkbench.Properties.Settings.Default.MasterPassword = txtMasterPassword.Text;

            SandbarWorkbench.Properties.Settings.Default.Save();
        }
    }
}
