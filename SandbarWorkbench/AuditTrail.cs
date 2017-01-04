using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench
{
    public class AuditTrail
    {
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public DateTime UpdatedOn { get; internal set; }
        public string UpdatedBy { get; internal set; }

        /// <summary>
        /// Get the AddedOn date time in the local time zone.
        /// </summary>
        public DateTime AddedOnLT
        {
            get { return AddedOn.ToLocalTime(); }
        }

        /// <summary>
        /// Get the UpdatedOn time in the local time zone.
        /// </summary>
        public DateTime UpdatedOnLT
        {
            get { return UpdatedOn.ToLocalTime(); }
        }

        public AuditTrail (DateTime dAddedOn, string sAddedBy, DateTime dUpdatedOn, string sUpdatedBy)
        {
            AddedOn = dAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }
    }
}
