using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.DBHelpers
{
    public abstract class BaseTableDef
    {
        public string TableName { get; internal set; }
        public string MasterPrimaryKey { get; internal set; }

        public BaseTableDef(string sTableName)
        {
            TableName = sTableName;
        }
    }
}
