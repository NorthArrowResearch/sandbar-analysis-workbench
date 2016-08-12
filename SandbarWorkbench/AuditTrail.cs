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

        public AuditTrail (DateTime dAddedOn, string sAddedBy, DateTime dUpdatedOn, string sUpdatedBy)
        {
            AddedOn = dAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }
    }
}
