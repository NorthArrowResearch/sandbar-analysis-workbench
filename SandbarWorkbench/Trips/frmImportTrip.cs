using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Globalization;

namespace SandbarWorkbench.Trips
{
    public partial class frmImportTrip : Form
    {
        public frmImportTrip()
        {
            InitializeComponent();
        }

        private void frmImportTrip_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helpers.IOHelpers.BrowseFillTextBoxFile("Sandbar Survey Trip CSV File", "CSV Files (*.csv)|*.csv", ref txtCSVFile, true);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtCSVFile.Text) || !System.IO.File.Exists(txtCSVFile.Text))
            {
                MessageBox.Show("Click the browse button to select a valid CSV file.", "Invalid Trip CSV File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteTransaction dbTrans = dbCon.BeginTransaction();

                try
                {
                    ImportTrip(dbTrans, txtCSVFile.Text);
                    dbTrans.Commit();
                }
                catch (Exception ex)
                {
                    dbTrans.Rollback();
                    MessageBox.Show(ex.Message, "Error Importing Trip", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
        }

        private void ImportTrip(SQLiteTransaction dbTrans, string file_path)
        {
            Dictionary<string, long> sites = new Dictionary<string, long>();
            Dictionary<string, long> instruments = new Dictionary<string, long>();
            Dictionary<string, long> sectionTypes = new Dictionary<string, long>();

            // Load the sites into memory so that we can check their validity.
            using (SQLiteCommand dbCom = new SQLiteCommand("SELECT SiteID, SiteCode5 FROM SandbarSites", dbTrans.Connection, dbTrans))
            {
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    sites[dbRead.GetString(dbRead.GetOrdinal("SiteCode5"))] = dbRead.GetInt64(dbRead.GetOrdinal("SiteID"));
                }
                dbRead.Close();
            }

            // Load the instruments
            using (SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @InstrumentListID", dbTrans.Connection, dbTrans))
            {
                dbCom.Parameters.AddWithValue("InstrumentListID", Properties.Settings.Default.ListID_InstrumentTypes);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    instruments[dbRead.GetString(dbRead.GetOrdinal("Title"))] = dbRead.GetInt64(dbRead.GetOrdinal("ItemID"));
                }
                dbRead.Close();
            }

            // Load the survey types
            using (SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID", dbTrans.Connection, dbTrans))
            {
                dbCom.Parameters.AddWithValue("ListID", Properties.Settings.Default.ListID_SectionTypes);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    sectionTypes[dbRead.GetString(dbRead.GetOrdinal("Title"))] = dbRead.GetInt64(dbRead.GetOrdinal("ItemID"));
                }
                dbRead.Close();
            }

            // Insert the one and only trip record
            long tripID = InsertTrip(dbTrans, dtTripDate.Value, txtRemarks.Text, Environment.UserName);

            // SiteID keyed to dictionary of survey dates keyed to survey IDs
            Dictionary<long, Dictionary<DateTime, long>> surveyDates = new Dictionary<long, Dictionary<DateTime, long>>();

            using (TextFieldParser parser = new TextFieldParser(file_path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                int lineNumber = 0;
                string[] headers = null;

                // Iterate through each row in the CSV file
                while (!parser.EndOfData)
                {
                    lineNumber++;

                    // Read the current row
                    string[] fields = parser.ReadFields();

                    // If it's the first row, store the headers
                    if (lineNumber == 1)
                    {
                        headers = fields;
                        continue;
                    }

                    int siteCodeIndex = GetFieldIndex(headers, "SiteCode5");
                    int surveyDateIndex = GetFieldIndex(headers, "SurveyDate");
                    int instrumentIndex = GetFieldIndex(headers, "Instrument");
                    int uncertaintyIndex = GetFieldIndex(headers, "Uncertainty");
                    int sectionTypeIndex = GetFieldIndex(headers, "SectionType");

                    // Check for empty values and print line number
                    if (fields.Length == 5)
                    {
                        if (siteCodeIndex >= 0 && surveyDateIndex >= 0 &&
                            (string.IsNullOrEmpty(fields[siteCodeIndex]) || string.IsNullOrEmpty(fields[surveyDateIndex])))
                        {
                            Console.WriteLine($"Empty value found at line {lineNumber}");
                        }

                        string siteCode5 = fields[siteCodeIndex];
                        if (string.IsNullOrEmpty(siteCode5) || !sites.ContainsKey(siteCode5))
                            throw new ArgumentException(string.Format("The site '{0}' on line number {1} does not exist.", siteCode5, lineNumber));

                        string instrument = fields[instrumentIndex];
                        string uncertaintyString = fields[uncertaintyIndex];
                        string sectionType = fields[sectionTypeIndex];
                        string surveyDate = fields[surveyDateIndex];
                        float uncertainty;
                        DateTime surveyDateVal;

                        if (!instruments.ContainsKey(instrument))
                            throw new ArgumentException(string.Format("The instrument '{0}' on line number {1} does not exist.", instrument, lineNumber));

                        if (!sectionTypes.ContainsKey(sectionType))
                            throw new ArgumentException(string.Format("The section type '{0}' on line number {1} does not exist.", sectionType, lineNumber));

                        if (!DateTime.TryParseExact(surveyDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out surveyDateVal))
                            throw new ArgumentException(string.Format("The survey date '{0}' is not of the correct YYYY-MM-DD format on line {1}.", surveyDate, lineNumber));

                        if (!float.TryParse(uncertaintyString, out uncertainty))
                            throw new ArgumentException(string.Format("The uncertainty '{0}' on line number {1} cannot be converted to a floating point number.", uncertainty, lineNumber));

                        long surveyID = InsertSurvey(dbTrans, sites[siteCode5], tripID, surveyDateVal, surveyDates);
                        InsertSection(dbTrans, surveyID,  sectionTypes[sectionType], instruments[instrument],uncertainty, Environment.UserName);
                    }
                }
            }
        }

        private long InsertSurvey(SQLiteTransaction dbTrans, long siteid, long tripid, DateTime surveyDate, Dictionary<long, Dictionary<DateTime, long>> surveyDates)
        {
            if (surveyDates.ContainsKey(siteid))
                if (surveyDates[siteid].ContainsKey(surveyDate))
                    return surveyDates[siteid][surveyDate];

            using (SQLiteCommand dbCom = new SQLiteCommand("INSERT INTO SandbarSurveys (SiteID, TripID, SurveyDate, AddedBy, UpdatedBy) VALUES (@SiteID, @TripID, @SurveyDate, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans))
            {
                dbCom.Parameters.AddWithValue("SiteID", siteid);
                dbCom.Parameters.AddWithValue("TripID", tripid);
                dbCom.Parameters.AddWithValue("SurveyDate", surveyDate);
                dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
                dbCom.ExecuteNonQuery();

                if (!surveyDates.ContainsKey(siteid))
                    surveyDates[siteid] = new Dictionary<DateTime, long>();

                surveyDates[siteid][surveyDate] = dbCom.Connection.LastInsertRowId;
                return dbCom.Connection.LastInsertRowId;
            }
        }

        private long InsertTrip(SQLiteTransaction dbTrans, DateTime tripDate, string remarks, string userName)
        {
            using (SQLiteCommand dbCom = new SQLiteCommand("INSERT INTO Trips (TripDate, Remarks, AddedBy, UpdatedBy) VALUES (@TripDate, @Remarks, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans))
            {
                dbCom.Parameters.AddWithValue("TripDate", tripDate);
                if (string.IsNullOrEmpty(remarks))
                    dbCom.Parameters.AddWithValue("Remarks", DBNull.Value);
                else
                    dbCom.Parameters.AddWithValue("Remarks", remarks);
                dbCom.Parameters.AddWithValue("EditedBy", userName);
                dbCom.ExecuteNonQuery();
                return dbCom.Connection.LastInsertRowId;
            }
        }

        private long InsertSection(SQLiteTransaction dbTrans, long surveyID, long sectionTypeID, long instrumentID, float uncertainty, string userName)
        {
            using (SQLiteCommand dbCom = new SQLiteCommand("INSERT INTO SandbarSections (SurveyID, SectionTypeID, Uncertainty, InstrumentID, AddedBy, UpdatedBy) VALUES (@SurveyID, @SectionTypeID, @Uncertainty, @InstrumentID, @EditedBy, @EditedBy)", dbTrans.Connection, dbTrans))
            {
                dbCom.Parameters.AddWithValue("SurveyID", surveyID);
                dbCom.Parameters.AddWithValue("SectionTypeID", sectionTypeID);
                dbCom.Parameters.AddWithValue("InstrumentID", instrumentID);
                dbCom.Parameters.AddWithValue("Uncertainty", uncertainty);
                dbCom.Parameters.AddWithValue("EditedBy", userName);
                dbCom.ExecuteNonQuery();
                return dbCom.Connection.LastInsertRowId;
            }
        }

        // Helper method to get the index of a field by name
        static int GetFieldIndex(string[] headers, string fieldName)
        {
            int idx = Array.IndexOf(headers, fieldName);
            if (idx < 0)
                throw new ArgumentException(String.Format("Cannot find the column called '{0}'.", fieldName));
            return idx;
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Helpers.OnlineHelp.FormHelp(this.Name);
        }
    }
}
