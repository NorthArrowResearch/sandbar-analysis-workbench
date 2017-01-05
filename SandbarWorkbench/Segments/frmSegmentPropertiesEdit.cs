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

        private void frmSegmentPropertiesEdit_Load(object sender, EventArgs e)
        {
            if (segment is Segment)
            {
                txtName.Text = segment.Title;
                txtCode.Text = segment.SegmentCode;
                valDownstream.Value = (decimal)segment.DownstreamRiverMile;
                valUpstream.Value = (decimal)segment.UpstreamRiverMile;
            }

        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("You must provide a segment code, typically of the form Seg_XXX", "Missing Segment Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("You must provide a segment name.", "Missing Segment Name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Select();
                return false;
            }

            if (valDownstream.Value >= valUpstream.Value)
            {
                MessageBox.Show("The downstream river mile must be greater than the upstream river mile.", "Invalid River Mile Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valDownstream.Select();
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
                SegmentCRUD crud = new SegmentCRUD();

                if (segment == null)
                {
                    segment = new Segment(txtName.Text, txtCode.Text, (double)valUpstream.Value, (double)valDownstream.Value, Environment.UserName);
                }
                else
                {
                    segment.Title = txtName.Text;
                    segment.SegmentCode = txtCode.Text;
                    segment.DownstreamRiverMile = (double)valDownstream.Value;
                    segment.UpstreamRiverMile = (double)valUpstream.Value;
                }

                DBHelpers.DatabaseObject obj = (DBHelpers.DatabaseObject)this.segment;
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
