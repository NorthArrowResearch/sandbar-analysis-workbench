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

namespace SandbarWorkbench.Trips
{
    public partial class frmTripPropertiesEdit : Form
    {
        public long ID { get; internal set; }

        public frmTripPropertiesEdit(long nID = 0)
        {
            InitializeComponent();
            ID = nID;
        }

        private void frmTripPropertiesEdit_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateForm()
        {

            return true;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                this.DialogResult = DialogResult.None;
                return;
            }



        }
    }
}
