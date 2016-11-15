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
        public frmSurveyProperties(SandbarSurvey aSurvey, bool bEditable)
        {
            Init(aSurvey, bEditable);
        }

        /// <summary>
        /// Call for new surveys
        /// </summary>
        public frmSurveyProperties()
        {
            Init(null, false);
        }

        private void Init(SandbarSurvey aSurvey, bool bEditable)
        {
            InitializeComponent();
            Editable = bEditable;
            DeletedItems = new List<long>();

            grdData.AutoGenerateColumns = false;

            if (aSurvey is SandbarSurvey)
            {
                Survey = aSurvey;
            }
            else
                Survey = new SandbarSurvey();

            Survey.Sections.ListChanged += Sections_ListChanged;
        }

        private void frmSurveyProperties_Load(object sender, EventArgs e)
        {
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
            if ((long)grdData.Rows[e.RowIndex].Cells[1].Value < 1)
            {
                MessageBox.Show("You must select a valid section type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if ((long)grdData.Rows[e.RowIndex].Cells[2].Value < 1)
            {
                MessageBox.Show("You must select a valid instrument type or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if (grdData.Rows[e.RowIndex].Cells[3] == null)
            {
                MessageBox.Show("You must provide an uncertainty value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {
                double fValue = 0;
                if (!double.TryParse(grdData.Rows[e.RowIndex].Cells[3].Value.ToString(), out fValue) || fValue < 0)
                {
                    MessageBox.Show("The uncertainty value must be a positive real value or press the Escape key to discard the row being edited.", SandbarWorkbench.Properties.Resources.ApplicationNameLong, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
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

            foreach (SandbarSection aSection in Survey.Sections)
            {
                //Survey.Sections.
            }

        }
    }
}
