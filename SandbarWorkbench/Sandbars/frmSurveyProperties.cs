﻿using System;
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
        public SandbarSurvey Survey { get; internal set; }
        public bool Editable { get; internal set; } // true when the argument survey can be edited

        public SortableBindingList<ListItem> SectionTypes { get; internal set; }

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
            Survey = aSurvey;
            Editable = bEditable;

            SectionTypes = new SortableBindingList<ListItem>();
        }

        private void frmSurveyProperties_Load(object sender, EventArgs e)
        {
            // Load the survey section types into the data grid view combo cell column
            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID ORDER BY Title", dbCon);
                dbCom.Parameters.AddWithValue("ListID", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                    SectionTypes.Add(new ListItem((string)dbRead["Title"], (long)dbRead["ItemID"]));
            }

            DataGridViewComboBoxColumn colSectionTypes = (DataGridViewComboBoxColumn)grdData.Columns["colSectionType"];
            colSectionTypes.DataSource = SectionTypes;

            long nTripID = 0;
            if (Survey is SandbarSurvey)
            {
                dtSurveyDate.Value = Survey.SurveyDate;
                nTripID = Survey.TripID;
            }

            ListItem.LoadComboWithListItems(ref cboTrips, DBCon.ConnectionStringLocal, "SELECT TripID, TripDate FROM Trips ORDER BY TripDate Desc", nTripID);
        }
    }
}