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

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSandbarPropertiesEdit : Form
    {
        public string conMaster { get; internal set; }
        public long ID { get; internal set; }

        public frmSandbarPropertiesEdit(string sConMaster, long nID = 0)
        {
            InitializeComponent();
            conMaster = sConMaster;
            ID = nID;
        }

        private void frmSandbarPropertiesEdit_Load(object sender, EventArgs e)
        {
            if (ID > 0)
            {

            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string sSQL = string.Empty;
            string[] sFields = { };

            //if (ID>0)
            //{
            //    sSQL = string.Format("UPDATE SandbarSites SET {0} WHERE SiteID = @SiteID", )
            //}
            //else
            //{
            //    dbCom = new MySqlCommand
            //}
        }
    }
}
