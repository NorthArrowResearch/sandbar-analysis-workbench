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
            : base (sNoun,sMenuItemText, "SELECT ItemID AS ID, Title, AddedOn AS [Added On], AddedBy AS [Added By], UpdatedOn AS [Updated On], UpdatedBy AS [Updated By] FROM LookupListItems WHERE ListID = @ListID ORDER BY Title", "DELETE FROM LookupListItems WHERE ItemID = @ID")
        {
            ListID = nListID;
        }
    }
}
