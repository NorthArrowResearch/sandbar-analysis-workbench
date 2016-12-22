using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench.Trips
{
    public class Trip : DBHelpers.DatabaseObject
    {
        public DateTime TripDate { get; internal set; }
        public string Remarks { get; internal set; }

        public Trip(long nID, DateTime dtTripDate, string sRemarks, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
            : base(nID, string.Empty, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            TripDate = dtTripDate;
            Remarks = sRemarks;
        }
    }     
}
