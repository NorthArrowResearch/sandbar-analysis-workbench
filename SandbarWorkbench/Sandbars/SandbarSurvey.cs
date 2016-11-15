using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    public class SandbarSurvey : SandbarSurveyBase
    {
        public long TripID { get; internal set; }
        public long SiteID { get; internal set; }
        public DateTime TripDate { get; internal set; }
        public AuditTrail Audit { get; internal set; }

        public SortableBindingList<SandbarSection> Sections { get; set; }
        public int SectionCount { get { return Sections.Count; } }

        public bool HasChannel { get; internal set; }
        public string HasChannelStr { get { return HasChannel ? "True" : "False"; } }

        public int EddyCount { get; internal set; }
        public bool HasEddy { get { return EddyCount > 0; } }
        public string HasEddyStr { get { return EddyCount > 0 ? "True" : "False"; } }

        public SandbarSurvey(long nSurveyID, long nSiteID, long nTripID, DateTime dTripDate, DateTime dSurveyDate, DateTime dAddedOn, string sAddedBy, DateTime dUpdatedOn, string sUpdatedBy)
            : base(nSurveyID, dSurveyDate)
        {
            Init(nSiteID, nTripID, dTripDate, dAddedOn, sAddedBy, dUpdatedOn, sUpdatedBy);
        }

        public SandbarSurvey(long nSiteID) : base(0, DateTime.Now)
        {
            Init(nSiteID, 0, DateTime.Now, DateTime.Now, string.Empty, DateTime.Now, string.Empty);
        }

        private void Init(long nSiteID, long nTripID, DateTime dTripDate, DateTime dAddedOn, string sAddedBy, DateTime dUpdatedOn, string sUpdatedBy)
        {
            SiteID = nSiteID;
            TripID = nTripID;
            TripDate = dTripDate;
            Audit = new AuditTrail(dAddedOn, sAddedBy, dUpdatedOn, sUpdatedBy);
            Sections = new SortableBindingList<SandbarSection>();
            HasChannel = false;
            EddyCount = 0;
        }

        public static BindingList<SandbarSurvey> LoadSandbarSurveys(string sDB, long nSiteID = 0)
        {
            BindingList<SandbarSurvey> lRecords = new BindingList<SandbarSurvey>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();

                string sSQL = "SELECT S.SurveyID, S.SiteID, T.TripID, T.TripDate, S.SurveyDate, S.AddedOn, S.AddedBy, S.UpdatedOn, S.UpdatedBy FROM SandbarSurveys S INNER JOIN Trips T ON (S.TripID = T.TripID)";
                if (nSiteID > 0)
                    sSQL += string.Format(" WHERE S.SiteID = {0}", nSiteID);
                sSQL += " ORDER BY S.SurveyDate DESC";

                SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {

                    lRecords.Add(new SandbarSurvey(
                        (long)dbRead["SurveyID"]
                        , (long) dbRead["SiteID"]
                        , (long)dbRead["TripID"]
                        , (DateTime)dbRead["TripDate"]
                        , (DateTime)dbRead["SurveyDate"]
                        , (DateTime)dbRead["AddedOn"]
                        , (string)dbRead["AddedBy"]
                        , (DateTime)dbRead["UpdatedOn"]
                        , (string)dbRead["UpdatedBy"]
                        ));
                }
                dbRead.Close();

                // Load a dictionary of section types
                //Dictionary<long, string> dSectionTypes = new Dictionary<long, string>();
                dbCom = new SQLiteCommand("SELECT ItemID, Title FROM LookupListItems WHERE ListID = @ListID", dbCon);
                dbCom.Parameters.AddWithValue("ListID", SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes);
                dbRead = dbCom.ExecuteReader();
                long nChannelSectionTypeID = 0;
                while (dbRead.Read())
                {
                    //dSectionTypes[(long)dbRead["ItemID"]] = (string)dbRead["Title"]);

                    // Determine the one section type that identifies the channel. There can be multiple channel types that represent eddies
                    if (dbRead.GetString(dbRead.GetOrdinal("Title")).ToLower().Contains("chan"))
                        nChannelSectionTypeID = (long)dbRead["ItemID"];
                }
                // Now load all the surveyed sections
                Dictionary<long, string> dSections = new Dictionary<long, string>();
                dbCom = new SQLiteCommand("SELECT SectionID, SectionTypeID, InstrumentID, Uncertainty FROM SandbarSections WHERE SurveyID = @SurveyID", dbCon);
                SQLiteParameter pSurveyID = dbCom.Parameters.Add("SurveyID", System.Data.DbType.Int64);

                foreach (SandbarSurvey aSurvey in lRecords)
                {
                    pSurveyID.Value = aSurvey.SurveyID;
                    dbRead = dbCom.ExecuteReader();
                    while (dbRead.Read())
                    {
                        long nSectionTypeID = (long)dbRead["SectionTypeID"];
                        aSurvey.Sections.Add(new SandbarSection((long)dbRead["SectionID"], nSectionTypeID, (long)dbRead["InstrumentID"], (double)dbRead["Uncertainty"]));

                        if (nSectionTypeID == nChannelSectionTypeID)
                            aSurvey.HasChannel = true;
                        else
                            aSurvey.EddyCount += 1;
                    }
                    dbRead.Close();
                }
            }

            return lRecords;
        }

        /// <summary>
        /// Class to help bind attributes of the AuditTrail to data gridiews
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class MyTypeDescriptionProvider<T> : TypeDescriptionProvider
        {
            private ICustomTypeDescriptor td;

            public MyTypeDescriptionProvider()
                : this(TypeDescriptor.GetProvider(typeof(Sandbars.SandbarSurvey)))
            {
            }

            public MyTypeDescriptionProvider(TypeDescriptionProvider parent)
                : base(parent)
            {
            }

            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
            {
                if (td == null)
                {
                    td = base.GetTypeDescriptor(objectType, instance);
                    td = new Helpers.MyCustomTypeDescriptor(td, typeof(T));
                }
                return td;
            }
        }
    }
}
