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
        public DateTime TripDate { get; internal set; }
        public AuditTrail Audit { get; internal set ;}

        public SandbarSurvey(long nSurveyID, long nTripID, DateTime dTripDate, DateTime dSurveyDate, DateTime dAddedOn, string sAddedBy, DateTime dUpdatedOn, string sUpdatedBy)
            : base(nSurveyID, dSurveyDate)
        {
            TripID = nTripID;
            TripDate = dTripDate;
            Audit = new AuditTrail(dAddedOn, sAddedBy, dUpdatedOn, sUpdatedBy);
        }

        public static BindingList<SandbarSurvey> LoadSandbarSurveys(string sDB, long nSiteID = 0)
        {
            BindingList<SandbarSurvey> lRecords = new BindingList<SandbarSurvey>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();

                string sSQL = "SELECT S.SurveyID, T.TripID, T.TripDate, S.SurveyDate, S.AddedOn, S.AddedBy, S.UpdatedOn, S.UpdatedBy FROM SandbarSurveys S INNER JOIN Trips T ON (S.TripID = T.TripID)";
                if (nSiteID > 0)
                    sSQL += string.Format(" WHERE S.SiteID = {0}", nSiteID);
                sSQL += " ORDER BY S.SurveyDate DESC";

                SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {

                    lRecords.Add(new SandbarSurvey(
                        (long)dbRead["SurveyID"]
                        , (long)dbRead["TripID"]
                        , (DateTime) dbRead["TripDate"]
                        , (DateTime)dbRead["SurveyDate"]
                        , (DateTime)dbRead["AddedOn"]
                        , (string)dbRead["AddedBy"]
                        , (DateTime)dbRead["UpdatedOn"]
                        , (string)dbRead["UpdatedBy"]
                        ));
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
