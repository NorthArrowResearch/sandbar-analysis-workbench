using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Segments
{
    public partial class frmSegmentPropertiesEdit : Form
    {
        public Segment segment { get; internal set; }

        public frmSegmentPropertiesEdit(long nID = 0)
        {
            InitializeComponent();

            if (nID > 0)
                segment = Segment.Load(nID);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }

        private void frmSegmentPropertiesEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
