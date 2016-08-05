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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void sandbarSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sandbars.frmSandbars frm = null;
            foreach (Form frmChild in this.MdiChildren)
            {
                if (frmChild is Sandbars.frmSandbars)
                {
                    frm = (Sandbars.frmSandbars)frmChild;
                    break;
                }
            }

            if (frm == null)
            {
                frm = new Sandbars.frmSandbars();
                frm.MdiParent = this;

// Only maximize the form if there are no other MDI forms and this is a new version
                if (this.MdiChildren.Count<Form>() < 2)
                    frm.WindowState = FormWindowState.Maximized;
            }

            frm.Show();
        }
    }
}
