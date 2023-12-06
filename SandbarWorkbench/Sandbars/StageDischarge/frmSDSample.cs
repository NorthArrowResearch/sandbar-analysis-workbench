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
            ConfigureToolTips();

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

        private void ConfigureToolTips()
        {
            tt.SetToolTip(cboSite, "The sandbar site with which this stage discharge sample is associated.");
            tt.SetToolTip(chkSampleDate, "Check this box to indicate that this stage discharge sample occurs on a known date. Checking this box requires that a date is provided. Unchecking the box clears any existing sample date value.");
            tt.SetToolTip(txtSampleTime, "Sample time associated with this stage discharge sample.");
            tt.SetToolTip(txtSampleCode, "Sample code associated with this stage discharge sample.");
            tt.SetToolTip(chkLocalElevation, "Check this box to indicate that this stage discharge sample possesses a location elevation value. Checking this box requires that a local elevation is provided. Unchecking the box clears any existing local elevation value.");
            tt.SetToolTip(valSPElevation, "Stateplane elevation in meters. Stateplane. Arizona Central FIPS 0202.");
            tt.SetToolTip(chkSampleCount, "Check this box to indicate that the number of samples is known. Checking this box requires that a sample count is provided. Unchecking this box clears any existing sample count value.");
            tt.SetToolTip(valFlow, "Discharge in cubic feet per second.");
            tt.SetToolTip(valFlowMS, "Dicharge in meters cubed per second.");
            tt.SetToolTip(txtComments, "Opiotnal, miscellaneous remarks and comments about this stage discharge sample.");
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

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();

                SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    SQLiteCommand dbCom = new SQLiteCommand(string.Empty, dbTrans.Connection, dbTrans);
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

                    dbCom.Parameters.AddWithValue("SiteID", ((naru.db.NamedObject)cboSite.SelectedItem).ID);

                    if (chkSampleDate.Checked)
                        dbCom.Parameters.AddWithValue("SampleDate", dtSampleDate.Value);
                    else
                        dbCom.Parameters.AddWithValue("SampleDate", DBNull.Value);

                    naru.db.sqlite.SQLiteHelpers.AddStringParameterN(ref dbCom, txtSampleTime.Text, "SampleTime");
                    naru.db.sqlite.SQLiteHelpers.AddStringParameterN(ref dbCom, txtSampleCode.Text, "SampleTime");
                    dbCom.Parameters.AddWithValue("ElevationLocal", chkLocalElevation.Checked);
                    dbCom.Parameters.AddWithValue("ElevationSP", valSPElevation.Value);

                    if (chkSampleCount.Checked)
                        dbCom.Parameters.AddWithValue("SampleCount", valSampleCount.Value);
                    else
                        dbCom.Parameters.AddWithValue("SampleCount", DBNull.Value);

                    dbCom.Parameters.AddWithValue("Flow", valFlow.Value);
                    dbCom.Parameters.AddWithValue("FlowMS", valFlowMS.Value);
                    naru.db.sqlite.SQLiteHelpers.AddStringParameterN(ref dbCom, txtComments.Text, "Comments");
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);

                    dbCom.ExecuteNonQuery();

                    if (sdValue == null)
                    {
                        ID = dbCon.LastInsertRowId;
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

        private void frmSDSample_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
