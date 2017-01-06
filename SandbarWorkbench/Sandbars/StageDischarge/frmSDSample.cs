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

namespace SandbarWorkbench.Sandbars.StageDischarge
{
    public partial class frmSDSample : Form
    {
        public long ID { get; internal set; }
        public SDValue sdValue { get; internal set; }
        public long SiteID { get; internal set; }

        public frmSDSample(SDValue aValue)
        {
            InitializeComponent();
            sdValue = aValue;
            SiteID = sdValue.SiteID;
        }

        public frmSDSample(long nSiteID)
        {
            InitializeComponent();
            sdValue = null;
            SiteID = nSiteID;
        }

        private void frmSDSample_Load(object sender, EventArgs e)
        {
            if (sdValue is SDValue)
            {
                ID = sdValue.SampleID;
                cboSite.Enabled = false;

                chkSampleDate.Checked = sdValue.SampleDate.HasValue;
                if (sdValue.SampleDate.HasValue)
                    dtSampleDate.Value = sdValue.SampleDate.Value;

                txtSampleTime.Text = sdValue.SampleTime;
                txtSampleCode.Text = sdValue.SampleCode;

                chkLocalElevation.Checked = sdValue.ElevationLocal.HasValue;
                if (sdValue.ElevationLocal.HasValue)
                    valLocalElevation.Value = (decimal)sdValue.ElevationLocal.Value;

                valSPElevation.Value = (decimal)sdValue.ElevationSP;

                chkSampleCount.Checked = sdValue.SampleCount.HasValue;
                if (sdValue.SampleCount.HasValue)
                    valSampleCount.Value = sdValue.SampleCount.Value;

                valFlow.Value = (decimal)sdValue.Flow;
                valFlowMS.Value = (decimal)sdValue.FlowMS;

                txtComments.Text = sdValue.Comments;
            }

            // Load all the sites into the combo box, but lock it if there is not site selected so that user can select their own.
            ListItem.LoadComboWithListItems(ref cboSite, DBCon.ConnectionStringLocal, "SELECT SiteID, SiteCode5 || ' - ' || Title FROM SandbarSites ORDER BY SiteCode5", SiteID);
            cboSite.Enabled = SiteID == 0;

            UpdateControls(null, null);
        }

        private void UpdateControls(object sender, EventArgs e)
        {
            dtSampleDate.Enabled = chkSampleDate.Checked;
            valLocalElevation.Enabled = chkLocalElevation.Checked;
            valSampleCount.Enabled = chkSampleCount.Checked;
        }

        private bool ValidateForm()
        {
            if (!(cboSite.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select a site for this stage discharge sample.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSite.Select();
                return false;
            }

            if (chkLocalElevation.Checked && valLocalElevation.Value == 0)
            {
                if (MessageBox.Show("Are you sure that the local elevation should be zero?" +
                    " Uncheck the box to indicate that a local elevation value was not collected as part of this sample.",
                    "Zero Local Elevation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    valLocalElevation.Select();
                    return false;
                }
            }

            if (valSPElevation.Value == 0)
            {
                if (MessageBox.Show("Are you sure that the state plane elevation should be zero?",
                    "Zero State Plane Elevation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    valSPElevation.Select();
                    return false;
                }
            }

            if (chkSampleCount.Checked && valSampleCount.Value == 0)
            {
                if (MessageBox.Show("Are you sure that the sample count should be zero?" +
                    " Uncheck the box to indicate that a sample count was not collected as part of this record.",
                    "Zero Local Elevation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    valLocalElevation.Select();
                    return false;
                }
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

            using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
            {
                dbCon.Open();

                MySqlTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    MySqlCommand dbCom = new MySqlCommand(string.Empty, dbTrans.Connection, dbTrans);
                    if (sdValue is SDValue)
                    {
                        dbCom.CommandText = "UPDATE StageDischarges SET SiteID = @SiteID, SampleDate = @SampleDate, SampleTime=@SampleTime, SampleCode =@SampleCode" +
                           ", ElevationLocal = @ElevationLocal, ElevationSP=@ElevationSP, SampleCount=@SampleCount, Flow=@Flow, FlowMS=@FlowMS, Comments =@Comments" +
                           ", UpdatedBy=@EditedBy WHERE SampleID=@SampleID";
                        dbCom.Parameters.AddWithValue("SampleID", sdValue.SampleID);
                    }
                    else
                    {
                        dbCom.CommandText = "INSERT INTO StageDischarges (SiteID, SampleDate, SampleTime, SampleCode, ElevationLocal, ElevationSP, SampleCount, Flow, FlowMS, Comments, AddedBy, UpdatedBy)" +
                         " VALUES (@SiteID, @SampleDate, @SampleTime, @SampleCode, @ElevationLocal, @ElevationSP, @SampleCount, @Flow, @FlowMS, @Comments, @EditedBy, @EditedBy)";
                    }

                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref cboSite, "SiteID");
                    DBHelpers.MySQLHelpers.AddNParameter(ref dbCom, ref chkSampleDate, ref dtSampleDate, "SampleDate");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtSampleTime, "SampleTime");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref txtSampleCode, "SampleCode");
                    DBHelpers.MySQLHelpers.AddNParameter(ref dbCom, ref chkLocalElevation, ref valLocalElevation, "ElevationLocal");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valSPElevation, "ElevationSP");
                    DBHelpers.MySQLHelpers.AddNParameter(ref dbCom, ref chkSampleCount, ref valSampleCount, "SampleCount");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valFlow, "Flow");
                    DBHelpers.MySQLHelpers.AddParameter(ref dbCom, ref valFlowMS, "FlowMS");
                    DBHelpers.MySQLHelpers.AddStringParameterN(ref dbCom, txtComments.Text, "Comments");
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                    dbCom.ExecuteNonQuery();

                    if (sdValue == null)
                    {
                        ID = dbCom.LastInsertedId;
                    }

                    dbTrans.Commit();
                    MessageBox.Show("Stage discharge sample saved to the remote, master database. Your local database will now be updated when you click OK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ExceptionHandling.NARException.HandleException(ex);
                }
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
