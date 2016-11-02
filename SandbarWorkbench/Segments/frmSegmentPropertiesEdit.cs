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
        public long ID { get; internal set; }

        public frmSegmentPropertiesEdit(long nID = 0)
        {
            InitializeComponent();
            ID = nID;
        }
    }
}
