using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench
{
    class LookupDataVersion
    {
        public long MHashID { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }
        public Guid InstallationHash { get; internal set; }

        public LookupDataVersion(long nMHashID, DateTime dtAddedOn, string sAddedBy, Guid gInstallationHash)
        {
            MHashID = nMHashID;
            AddedOn = dtAddedOn;
            AddedBy = sAddedBy;
            InstallationHash = gInstallationHash;
        }

        public LookupDataVersion()
        {
            MHashID = 0;
            AddedOn = new DateTime(1970, 1, 1);
            AddedBy = string.Empty;
        }

        public static bool IsUpToDate(ref LookupDataVersion aVersion)
        {
            return true;
        }

        public override string ToString()
        {
            return string.Format("Version {0}, added on {1} by {2}", MHashID, AddedOn, AddedBy);
        }
    }
}
