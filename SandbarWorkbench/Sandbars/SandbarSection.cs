using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SandbarWorkbench.Sandbars
{
    // : INotifyPropertyChanged

    public class SandbarSection
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public enum ItemStates
        {
            Unchanged,
            New,
            Edited
        }

        public long SectionID { get; set; }
        public ItemStates State { get; set; }
        private long sectionTypeID { get; set; }
        private long instrumentID { get; set; }
        private double uncertainty { get; set; }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public long SectionTypeID
        {
            get
            {
                return this.sectionTypeID;
            }
            set
            {
                if (this.sectionTypeID != value)
                {
                    State = ItemStates.Edited;
                    this.sectionTypeID = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        public long InstrumentID
        {
            get { return this.instrumentID; }
            set
            {
                if (this.instrumentID != value)
                {
                    State = ItemStates.Edited;
                    this.instrumentID = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        public double Uncertainty
        {
            get { return this.uncertainty; }
            set
            {
                if (this.uncertainty != value)
                {
                    State = ItemStates.Edited;
                    this.uncertainty = value;
                    //NotifyPropertyChanged();
                }
            }
        }

        public SandbarSection(long nSectionID, long nSectionTypeID, long nInstrumentID, double fUncertainty)
        {
            SectionID = nSectionID;
            SectionTypeID = nSectionTypeID;
            InstrumentID = nInstrumentID;
            Uncertainty = fUncertainty;
            State = ItemStates.Unchanged;
        }

        public SandbarSection()
        {
            SectionID = 0;
            SectionTypeID = 0;
            InstrumentID = 0;
            Uncertainty = 0;
            State = ItemStates.New;

            //using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            //{
            //    dbCon.Open();
            //    SQLiteCommand dbCom = new SQLiteCommand("SELECT ItemID FROM LookupListItems WHERE ListID = @ListID ORDER BY Title LIMIT 1", dbCon);
            //    SQLiteParameter pListID = dbCom.Parameters.Add("ListID", System.Data.DbType.Int64);

            //    pListID.Value = SandbarWorkbench.Properties.Settings.Default.ListID_SectionTypes;
            //    SectionTypeID = (long)dbCom.ExecuteScalar();

            //    pListID.Value = SandbarWorkbench.Properties.Settings.Default.ListID_InstrumentTypes;
            //    InstrumentID = (long)dbCom.ExecuteScalar();
            //}
        }
    }
}
