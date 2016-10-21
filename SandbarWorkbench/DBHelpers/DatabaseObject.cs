using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.DBHelpers
{
    class DatabaseObject
    {
        public long ID { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public DateTime UpdatedOn { get; internal set; }
        public string UpdatedBy { get; internal set; }

        public DatabaseObject(long nID, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
        {
            ID = nID;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dtUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }
    }
}
