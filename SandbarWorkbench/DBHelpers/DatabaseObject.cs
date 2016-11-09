using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.DBHelpers
{
    public class DatabaseObject
    {
        public long ID { get; internal set; }
        public string Title { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public DateTime UpdatedOn { get; internal set; }
        public string UpdatedBy { get; internal set; }

        public DatabaseObject(long nID, string sTitle, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
        {
            ID = nID;
            Title = sTitle;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            UpdatedOn = dtUpdatedOn;
            UpdatedBy = sUpdatedBy;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
