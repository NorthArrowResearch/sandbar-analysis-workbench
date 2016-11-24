using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.ModelRuns
{
    public abstract class ModelRunBase : DBHelpers.DatabaseObject
    {
        public string Remarks { get; internal set; }
        public long RunTypeID { get; internal set; }
        public Guid Installation { get; internal set; }
        public DateTime RunOn { get; internal set; }
        public string RunBy { get; internal set; }

        /// <summary>
        /// Returns whether this model run was performed on the local machine or not
        /// </summary>
        public bool IsLocalRun { get { return (Installation == SandbarWorkbench.Properties.Settings.Default.InstallationHash); } }

        public ModelRunBase(long nID, string sTitle, string sRemarks, long nRunTypeID, string sInstallation, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy, DateTime dtRunOn, string sRunBy)
                : base(nID, sTitle, dtAddedOn, sAddedBy, dtUpdatedOn, sUpdatedBy)
        {
            Remarks = sRemarks;
            RunTypeID = nRunTypeID;
            Installation = new Guid(sInstallation);
            RunOn = dtRunOn;
            RunBy = sRunBy;
        }
    }
}
