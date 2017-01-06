using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Sandbars
{
    public partial class frmSurveyProperties : Form
    {
        public SandbarSurvey Survey { get; set; }
        public bool Editable { get; internal set; } // true when the argument survey can be edited

        private List<long> DeletedItems;

        /// <summary>
        ///  call for viewing survey properties or editing
        /// </summary>
        /// <param name="aSurvey"></param>
        /// <param name="bEditable"></param>
        public frmSurveyProperties(ref SandbarSurvey aSurvey, bool bEditable)
        {
            Init(ref aSurvey, bEditable);
        }

        /// <summary>
        /// Call for new surveys
        /// </summary>
        public frmSurveyProperties(long nSiteID)
        {
            SandbarSurvey aSurvey = new SandbarSurvey(nSiteID);
            Init(ref aSurvey, true);
        }

        private void Init(ref SandbarSurvey aSurvey, bool bEditable)
        {
            InitializeComponent();
            Editable = bEditable;
            DeletedItems = new List<long>();

            grdData.AutoGenerateColumns = false;
            grdData.AllowUserToResizeRows = false;

            Survey = aSurvey;
            if (bEditable)
            {
                if (Survey.SurveyID == 0)
                    this.Text = "Create New Survey";
                else
                    this.Text = "Edit Survey Properties";
            }
            else
            {
                this.Text = "Survey Properties";
                grdData.ReadOnly = true;
                grdData.AllowUserToAddRows = false;
                grdData.AllowUserToDeleteRows = false;
                grdData.RowHeadersVisible = false;
                cboTrips.Enabled = false;
                dtSurveyDate.Enabled = false;
                cmdOK.Visible = false;
                cmdCancel.Text = "Close";
                this.AcceptButton = cmdCancel;
            }

            Survey.Sections.ListChanged += Sections_ListChanged;
        }

        private void frmSurveyProperties_Load(object sender, EventArgs e)
        {
            tt.SetToolTip(cboTrips, "The river trip on which this sandbar survey occurred. See the Trips view to add a missing trip.");
            tt.SetToolTip(dtSurveyDate, "The date on which this sandbar site survey occurred.");
            grdData.Columns["colSectionType"].ToolTipText = "Channel, eddy, or eddy type collected as part of this survey.";
            grdData.Columns["colInstrumentType"].ToolTipText = "Survey instrument type used to collect data in this section.";
            grdData.Columns["colUncertainty"].ToolTipText = "Elevation uncertainty associated with data collected in this section.";

            LoadComboColumnItems("colSectionType", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
            LoadComboColumnItems("colInstrumentType", SandbarWorkbench.Properties.Settings.Default.ListID_InstrumentTypes);

            long nTripID = 0;
            if (Survey is SandbarSurvey)
            {
                dtSurveyDate.Value = Survey.SurveyDate;
                nTripID = Survey.TripID;

                grdData.DataSource = Survey.Sections;
            }
            else
            {
                cmdOK.Visible = false;
                cmdCancel.Text = "Close";
            }

            ListItem.LoadComboWithListItems(ref cboTrips, DBCon.ConnectionStringLocal, "SELECT TripID, TripDate FROM Trips ORDER BY TripDate Desc", nTripID);
        }

        private void LoadComboColumnItems(string sColName, long nListID)
        {
            SortableBindingList<ListItem> lResult = new SortableBindingList<ListItem>();

            // Load the survey section types into the data grid view combo cell column
            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID ORDER BY Title", dbCon);
                dbCom.Parameters.AddWithValue("ListID", nListID);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                    lResult.Add(new ListItem((string)dbRead["Title"], (long)dbRead["ItemID"]));
            }

            // Add the empty item for new list items.
            lResult.Add(new ListItem(string.Empty, 0));

            DataGridViewComboBoxColumn aCol = (DataGridViewComboBoxColumn)grdData.Columns[sColName];
            aCol.DataSource = lResult;
            aCol.ValueMember = "Value";
            aCol.DisplayMember = "Text";
        }

        private void grdData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void grdData_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            //if (grdData.Rows[e.RowIndex].Cells[1].Value == null || (long)grdData.Rows[e.RowIndex].Cells[1].Value < 1)
            //{
            //    MessageBox.Show("You must select a valid section type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Cancel = true;
            //}

            //if (grdData.Rows[e.RowIndex].Cells[2].Value == null || (long)grdData.Rows[e.RowIndex].Cells[2].Value < 1)
            //{
            //    MessageBox.Show("You must select a valid instrument type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Cancel = true;
            //}

            //if (grdData.Rows[e.RowIndex].Cells[3] == null)
            //{
            //    MessageBox.Show("You must provide an uncertainty value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Cancel = true;
            //}
            //else
            //{
            //    double fValue = 0;
            //    if (grdData.Rows[e.RowIndex].Cells[3].Value == null || !double.TryParse(grdData.Rows[e.RowIndex].Cells[3].Value.ToString(), out fValue) || fValue < 0)
            //    {
            //        MessageBox.Show("The uncertainty value must be a positive real value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        e.Cancel = true;
            //    }
            //}
        }

        void Sections_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (Survey.Sections.Count > e.NewIndex)
                    DeletedItems.Add(Survey.Sections[e.NewIndex].SectionID);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!Editable)
            {
                // Nothing should have changed. Exit
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DialogResult eResult = ValidateForm();
            if (eResult != DialogResult.OK)
            {
                this.DialogResult = eResult;
                return;
            }

            using (MySqlConnection dbCon = new MySqlConnection(DBCon.ConnectionStringMaster))
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                dbCon.Open();
                MySqlTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    if (Survey.SurveyID == 0)
                    {
                        // This is a new survey insert it.
                        MySqlCommand dbCom = new MySqlCommand("INSERT INTO SandbarSurveys (SiteID, TripID, SurveyDate, AddedBy, UpdatedBy) VALUES (@SiteID, @TripID, @SurveyDate, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans);
                        dbCom.Parameters.AddWithValue("SiteID", Survey.SiteID);
                        dbCom.Parameters.AddWithValue("TripID", ((ListItem)cboTrips.SelectedItem).Value);
                        dbCom.Parameters.AddWithValue("SurveyDate", dtSurveyDate.Value);
                        dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                        dbCom.ExecuteNonQuery();

                        // Update the survey object with the primary key ID
                        Survey.SurveyID = dbCom.LastInsertedId;
                    }

                    // Remove all the sections that were removed. Do this first, in case the user accidentally removed then re-added the same section
                    MySqlCommand comDelete = new MySqlCommand("DELETE FROM SandbarSections WHERE SectionID = @SectionID", dbTrans.Connection, dbTrans);
                    MySqlParameter pSectionID = comDelete.Parameters.Add("SectionID", MySqlDbType.Int64);
                    foreach (long nSectionID in DeletedItems)
                    {
                        pSectionID.Value = nSectionID;
                        comDelete.ExecuteNonQuery();
                    }

                    // Insert new and update existing
                    foreach (SandbarSection aSection in Survey.Sections)
                    {
                        if (aSection.SectionID == 0)
                        {
                            // New section. Insert it.
                            MySqlCommand dbCom = new MySqlCommand("INSERT INTO SandbarSections (SurveyID, SectionTypeID, Uncertainty, InstrumentID, Addedby, UpdatedBy) VALUES (@SurveyID, @SectionTypeID, @Uncertainty, @InstrumentID, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans);
                            dbCom.Parameters.AddWithValue("SurveyID", Survey.SurveyID);
                            dbCom.Parameters.AddWithValue("SectionTypeID", aSection.SectionTypeID);
                            dbCom.Parameters.AddWithValue("InstrumentID", aSection.InstrumentID);
                            dbCom.Parameters.AddWithValue("Uncertainty", aSection.Uncertainty);
                            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                            dbCom.ExecuteNonQuery();
                            aSection.SectionID = dbCom.LastInsertedId;
                        }
                        else
                        {
                            if (aSection.State == SandbarSection.ItemStates.Edited)
                            {
                                // Existing section that has changed.
                                MySqlCommand dbCom = new MySqlCommand("UPDATE SandbarSections SET SectionTypeID = @SectionTypeID, Uncertainty = @Uncertainty, InstrumentID = @InstrumentID, UpdatedBy = @EditedBy WHERE SectionID = @SectionID", dbTrans.Connection, dbTrans);
                                dbCom.Parameters.AddWithValue("SectionID", aSection.SectionID);
                                dbCom.Parameters.AddWithValue("SectionTypeID", aSection.SectionTypeID);
                                dbCom.Parameters.AddWithValue("InstrumentID", aSection.InstrumentID);
                                dbCom.Parameters.AddWithValue("Uncertainty", aSection.Uncertainty);
                                dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                                dbCom.ExecuteNonQuery();
                            }
                        }
                    }

                    dbTrans.Commit();
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    ExceptionHandling.NARException.HandleException(ex);
                    this.DialogResult = DialogResult.None;
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                }
            }
        }

        private DialogResult ValidateForm()
        {
            if (!(cboTrips.SelectedItem is ListItem))
            {
                MessageBox.Show("You must select the trip on which this survey occurred. If the trip is not present in the list then cancel this form and return to the main menu where you can define a new trip.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.None;
            }

            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            DateTime dtTrip = DateTime.Parse(cboTrips.SelectedItem.ToString(), culture, System.Globalization.DateTimeStyles.AssumeLocal);

            if (Editable)
            {
                int nMaxTripLength = SandbarWorkbench.Properties.Settings.Default.MaxTripLength;
                if (dtTrip.AddDays(nMaxTripLength) < dtSurveyDate.Value || dtTrip.AddDays(-1 * nMaxTripLength) > dtSurveyDate.Value)
                {
                    switch (MessageBox.Show(string.Format("The trip date should typically be within {0} days of the survey date. Do you have the correct survey and/or trip dates? Click Yes to proceed, No to change dates.", nMaxTripLength), SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        case DialogResult.No:
                            return DialogResult.None;

                        case DialogResult.Cancel:
                            return DialogResult.Cancel;

                    }
                }
            }

            if (Survey.Sections.Count < 1)
            {
                MessageBox.Show("You must define at least one section that was surveyed as part of this survey.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.None;
            }

            return DialogResult.OK;
        }

        private void cboTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrips.SelectedItem is ListItem)
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                dtSurveyDate.Value = DateTime.Parse(cboTrips.SelectedItem.ToString(), culture, System.Globalization.DateTimeStyles.AssumeLocal);
            }
        }

        private void grdData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("You must select a valid section type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if (e.ColumnIndex == 2 && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("You must select a valid instrument type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if (e.ColumnIndex == 3)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("You must provide an uncertainty value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    double fValue = 0;
                    if (!double.TryParse(e.FormattedValue.ToString(), out fValue) || fValue < 0)
                    {
                        MessageBox.Show("The uncertainty value must be a positive real value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
