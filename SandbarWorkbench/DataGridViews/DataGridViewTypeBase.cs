using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.DataGridViews
{
    public class DataGridViewTypeBase
    {
        public string Noun { get; internal set; }
        public string MenuItemText { get; internal set; }
        public string SelectSQL { get; internal set; }
        public string DeleteSQL { get; internal set; }

        public DataGridViewTypeBase(string sNoun, string sMenuItemText, string sSelectSQL, string sDeleteSQL)
        {
            Noun = sNoun;
            MenuItemText = sMenuItemText;
            SelectSQL = sSelectSQL;
            DeleteSQL = sDeleteSQL;
        }
    }
}
