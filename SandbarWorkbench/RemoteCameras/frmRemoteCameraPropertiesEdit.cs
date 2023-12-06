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

namespace SandbarWorkbench.RemoteCameras
{
    public partial class frmRemoteCameraPropertiesEdit : Form
    {
        private RemoteCamera m_RemoteCamera { get; set; }
        public long RemoteCameraID { get; internal set; }
        public bool Editable { get; internal set; }
        int OriginalFormWidth;

        public frmRemoteCameraPropertiesEdit()
        {
            Init(null, true);
        }

        public frmRemoteCameraPropertiesEdit(RemoteCamera rc, bool bEditable)
        {
            Init(rc, bEditable);
        }

        private void Init(RemoteCamera rc, bool bEditable)
        {
            InitializeComponent();
            m_RemoteCamera = rc;
            Editable = bEditable;
            OriginalFormWidth = this.Width;
        }

        private void frmRemoteCameraPropertiesEdit_Load(object sender, EventArgs e)
        {
            ConfigureTooltips();

            long nCameraRiverBank = 0;
            long nTargetRiverBank = 0;
            long nSandbarSite = 0;
            long nCardType = 0;

            if (m_RemoteCamera is RemoteCamera)
            {
                RemoteCameraID = m_RemoteCamera.CameraID;
                nCameraRiverBank = m_RemoteCamera.CameraRiverBankID;
                nTargetRiverBank = m_RemoteCamera.TargetRiverBankID;
                nCardType = m_RemoteCamera.CardTypeID;

                if (m_RemoteCamera.SiteID.HasValue)
                    nSandbarSite = m_RemoteCamera.SiteID.Value;

                valRiverMile.Value = (decimal)m_RemoteCamera.RiverMile;
                txtSiteCode.Text = m_RemoteCamera.SiteCode;
                txtSiteName.Text = m_RemoteCamera.SiteName;
                txtNAUName.Text = m_RemoteCamera.NAUName;
                chkCurrentNSPPermit.Checked = m_RemoteCamera.CurrentNPSPermit;

                txtSubject.Text = m_RemoteCamera.Subject;
                txtView.Text = m_RemoteCamera.View;
                txtBestPhotoTime.Text = m_RemoteCamera.BestPhotoTime;
                chkHavePhotos.Checked = m_RemoteCamera.HavePhotos;

                txtBeginFilm.Text = m_RemoteCamera.BeginFilmRecord;
                txtEndFilm.Text = m_RemoteCamera.EndFilmRecord;

                txtBeginDigital.Text = m_RemoteCamera.BeginDigitalRecord;
                txtEndDigital.Text = m_RemoteCamera.EndDigitalRecord;
                txtRemarks.Text = m_RemoteCamera.Remarks;

                if (Editable)
                {
                    this.Text = "Edit Remote Camera Setup";
                    cmdPictures.Visible = false;
                }
                else
                {
                    this.Text = "View Remote Camera Setup";

                    // Set all the controls to read only.
                    valRiverMile.Enabled = false;
                    cboCameraRiverBank.Enabled = false;
                    cboTargetRiverBank.Enabled = false;
                    cboSandbarSite.Enabled = false;
                    txtSiteName.ReadOnly = true;
                    txtNAUName.ReadOnly = true;
                    txtSiteCode.ReadOnly = true;
                    chkCurrentNSPPermit.Enabled = false;

                    txtSubject.ReadOnly = true;
                    txtView.ReadOnly = true;
                    cboCardType.Enabled = false;
                    txtBestPhotoTime.ReadOnly = true;
                    chkHavePhotos.Enabled = false;
                    txtBeginFilm.ReadOnly = true;
                    txtEndFilm.ReadOnly = true;
                    txtBeginDigital.ReadOnly = true;
                    txtEndDigital.ReadOnly = true;
                    txtRemarks.ReadOnly = true;

                    cmdOK.Visible = false;
                    cmdCancel.Text = "Close";
                }
            }
            else
            {
                this.Text = "Add New Remote Camera Setup";
                cmdPictures.Visible = false;
            }

            ListItem.LoadComboWithLookupListItems(ref cboCameraRiverBank, DBCon.ConnectionStringLocal, SandbarWorkbench.Properties.Settings.Default.ListID_RiverBanks, nCameraRiverBank);
            ListItem.LoadComboWithLookupListItems(ref cboTargetRiverBank, DBCon.ConnectionStringLocal, SandbarWorkbench.Properties.Settings.Default.ListID_RiverBanks, nTargetRiverBank);
            ListItem.LoadComboWithLookupListItems(ref cboCardType, DBCon.ConnectionStringLocal, SandbarWorkbench.Properties.Settings.Default.ListID_CameraCardTypes, nCardType);

            // Special method that loads combo with sandbar site information (which is then available to help with other controls)
            SandbarSiteInfo.LoadSandbarSiteInfo(ref cboSandbarSite, nSandbarSite);

            ShowHidePictureViewer(false);
            ucPictureViewer.Dock = DockStyle.Fill;
        }

        private void ConfigureTooltips()
        {
            tt.SetToolTip(valRiverMile, "The river mile at which this remote camera is set up.");
            tt.SetToolTip(cboCameraRiverBank, "The river bank, left or right, on which this remote camera setup is located.");
            tt.SetToolTip(cboTargetRiverBank, "The river bank, left or right, at which this remote camera is targeted.");
            tt.SetToolTip(cboSandbarSite, "The sandbar site associated with this remote camera setup.");
            tt.SetToolTip(txtSiteName, "The full, verbose, name for the sandbar site. Max 50 characters.");
            tt.SetToolTip(txtNAUName, "The name by which Northern Arizona University (NAU) refers to this remote camera setup.");
            tt.SetToolTip(txtSiteCode, "The five digit site code associated with this remote camera setup. Typically four digit river mile followed by L or R for the left or right bank.");
            tt.SetToolTip(chkCurrentNSPPermit, "Check this box to indicate that the remote camera setup possesses a current National Park Service (NPS) permit");
            tt.SetToolTip(txtSubject, "The subject at which this remote camera setup is targeted; a sandbar or fan etc.");
            tt.SetToolTip(txtView, "Description of the view covered by this remote camera setup.");
            tt.SetToolTip(cboCardType, "The memory card type used by this remote camera setup.");
            tt.SetToolTip(txtBestPhotoTime, "Time of day when pictures contain the least amount of shadow. Typical format is HHMM using the 24 hour clock.");
            tt.SetToolTip(chkHavePhotos, "Check this box to indicate that GCMRC possesses photos from this remote camera setup.");
            tt.SetToolTip(txtBeginFilm, "Date when the analog film record began for this remote camera setup. Leave blank if no film record exists.");
            tt.SetToolTip(txtEndFilm, "Date when the analog film record ended for this remote camera setup. Leave blank if there is no film record or the film record is ongoing.");
            tt.SetToolTip(txtBeginDigital, "Date when the digital record began for this remote camera setup. Leave blank if there is no digital record.");
            tt.SetToolTip(txtEndDigital, "Date when the digital record ended for this remote camera setup. Leave blank if there is no digital record or the digital record is ongoing.");
            tt.SetToolTip(txtRemarks, "Optional, miscellaneous remarks and comments about this remote camera setup.");
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
                Cursor.Current = Cursors.WaitCursor;

                dbCon.Open();
                SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                string[] sFields = { "RiverMile", "CameraRiverBankID", "TargetRiverBankID",
                    "SiteID", "SiteName", "SiteCode", "CurrentNPSPermit", "NAUName", "HavePhotos",
                    "TheSubject", "TheView", "BestPhotoTime", "BeginFilmRecord", "EndFilmRecord",
                    "BeginDigitalRecord", "EndDigitalRecord", "CardTypeID"};

                try
                {
                    SQLiteCommand dbCom = new SQLiteCommand();
                    dbCom.Connection = dbCon;

                    if (m_RemoteCamera is RemoteCamera)
                    {
                        dbCom.CommandText = string.Format("UPDATE RemoteCameras SET {0}, UpdatedBy = @EditedBy WHERE SiteID = @SiteID", string.Join(", ", sFields.Select(x => string.Format("{0} = @{0}", x))));
                        dbCom.Parameters.AddWithValue("CameraID", m_RemoteCamera.CameraID);
                    }
                    else
                    {
                        dbCom.CommandText = string.Format("INSERT INTO RemoteCameras ({0}, AddedBy, UpdatedBy) VALUES (@{1}, @EditedBy, @EditedBy)", string.Join(", ", sFields), string.Join(", @", sFields));
                    }

                    dbCom.Parameters.AddWithValue("RiverMile", valRiverMile.Value);
                    dbCom.Parameters.AddWithValue("CameraRiverBankID", ((ListItem)cboCameraRiverBank.SelectedItem).Value);
                    dbCom.Parameters.AddWithValue("TargetRiverBankID", ((ListItem)cboTargetRiverBank.SelectedItem).Value);
                    dbCom.Parameters.AddWithValue("SiteID", ((ListItem) cboSandbarSite.SelectedItem).Value);        
                    dbCom.Parameters.AddWithValue("SiteCode", txtSiteCode.Text);
                    dbCom.Parameters.AddWithValue("SiteName", txtSiteName.Text);
                    dbCom.Parameters.AddWithValue("NAUName", txtNAUName.Text);
                    dbCom.Parameters.AddWithValue("CurrentNPSPermit", chkCurrentNSPPermit.Checked);
                    dbCom.Parameters.AddWithValue("HavePhotos", chkHavePhotos.Checked);
                    dbCom.Parameters.AddWithValue("TheSubject", txtSubject.Text);
                    dbCom.Parameters.AddWithValue("TheView", txtView.Text);
                    dbCom.Parameters.AddWithValue("CardTypeID", ((ListItem)cboCardType.SelectedItem).Value);
                    dbCom.Parameters.AddWithValue("BestPhotoTime", txtBestPhotoTime.Text);
                    dbCom.Parameters.AddWithValue("BeginFilmRecord", txtBeginFilm.Text);
                    dbCom.Parameters.AddWithValue("EndFilmRecord", txtEndFilm.Text);
                    dbCom.Parameters.AddWithValue("BeginDigitalRecord", txtBeginDigital.Text);
                    dbCom.Parameters.AddWithValue("EndDigitalRecord", txtEndDigital.Text);

       
                    // Both queries require the user name
                    dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);

                    System.Diagnostics.Debug.Print(dbCom.CommandText);
                    dbCom.ExecuteNonQuery();
                    dbTrans.Commit();

                    if (m_RemoteCamera == null)
                        RemoteCameraID =dbCon.LastInsertRowId;

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Remote camera data saved to the remote, master database. Your local database will now be updated when you click OK.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ExceptionHandling.NARException.HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private bool ValidateForm()
        {
            if (valRiverMile.Value == 0)
            {
                if (MessageBox.Show("Are you sure that the river mile is zero for this remote camera?",
                    SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }

            if (!(cboCameraRiverBank.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select the river bank on which the remote camera is situated.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCameraRiverBank.Select();
                return false;
            }

            if (!(cboTargetRiverBank.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select the river bank on which the remote camera is targeted.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTargetRiverBank.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtSiteName.Text))
            {
                MessageBox.Show("You must provide a site name for this camera location.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSiteName.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtSiteCode.Text))
            {
                MessageBox.Show("You must provide the site code associated with this remote camera location.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSiteCode.Select();
                return false;
            }

            return true;
        }

        private void cboSandbarSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSandbarSite.SelectedItem is SandbarSiteInfo)
            {
                SandbarSiteInfo selSite = cboSandbarSite.SelectedItem as SandbarSiteInfo;

                //if (string.IsNullOrEmpty(txtSiteCode.Text))
                txtSiteCode.Text = selSite.SiteCode;

                //if (string.IsNullOrEmpty(txtSiteName.Text))
                txtSiteName.Text = selSite.Text;
            }
        }

        /// <summary>
        /// Lightweight class for sandbar site information so that when the user picks 
        /// a sandbar site from the dropdown, the relevant properties can be populated into the other
        /// controls on this form.
        /// </summary>
        private class SandbarSiteInfo : ListItem
        {
            public string SiteCode { get; internal set; }

            public override string ToString()
            {
                return string.Format("{0} - {1}", SiteCode, Text);
            }

            public SandbarSiteInfo(long nSiteID, string sSiteCode, string sSiteName) : base(sSiteName, nSiteID)
            {
                SiteCode = sSiteCode;
            }

            public static void LoadSandbarSiteInfo(ref ComboBox cbo, long nSelectedSiteID)
            {
                cbo.Items.Clear();

                using (System.Data.SQLite.SQLiteConnection dbCon = new System.Data.SQLite.SQLiteConnection(DBCon.ConnectionStringLocal))
                {
                    dbCon.Open();

                    System.Data.SQLite.SQLiteCommand dbCom = new System.Data.SQLite.SQLiteCommand("SELECT SiteID, SiteCode5, Title FROM SandbarSites ORDER BY RiverMile", dbCon);
                    System.Data.SQLite.SQLiteDataReader dbRead = dbCom.ExecuteReader();
                    while (dbRead.Read())
                    {
                        int nIn = cbo.Items.Add(new SandbarSiteInfo(dbRead.GetInt64(dbRead.GetOrdinal("SiteID")),
                            dbRead.GetString(dbRead.GetOrdinal("SiteCode5")), dbRead.GetString(dbRead.GetOrdinal("Title"))));

                        if (nSelectedSiteID == dbRead.GetInt64(dbRead.GetOrdinal("SiteID")))
                            cbo.SelectedIndex = nIn;
                    }
                }
            }
        }

        private void cmdPictures_Click(object sender, EventArgs e)
        {
            ShowHidePictureViewer(splitContainer1.Panel2Collapsed);            
        }

        private void ShowHidePictureViewer(bool bShow)
        {
            if (bShow)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
                this.Width = OriginalFormWidth;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                cmdPictures.Text = "<<< Hide Pictures";
                ucPictureViewer.UpdateViewer(m_RemoteCamera.RemoteCameraSetupInfo, Pictures.PictureInfo.PictureSizes.Thumbnail, 0, true);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
                this.Width = groupBox1.Width + 30;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                cmdPictures.Text = "Show Pictures >>>";
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }

        private void frmRemoteCameraPropertiesEdit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
