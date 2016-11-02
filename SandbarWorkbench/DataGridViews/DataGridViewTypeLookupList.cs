using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.DataGridViews
{
    public class DataGridViewTypeLookupList : DataGridViewTypeBase
    {
        public long ListID { get; internal set; }

        public DataGridViewTypeLookupList(long nListID, string sNoun, string sMenuItemText)
            : base (sNoun,sMenuItemText, "SELECT ItemID, Title FROM LookupListItems ORDER BY Title", "DELETE FROM LookupListItems WHERE ItemID = @ID")
        {
            ListID = nListID;
        }
    }
}
