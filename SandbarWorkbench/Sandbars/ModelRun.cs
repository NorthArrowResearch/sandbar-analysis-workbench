using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.Sandbars
{
    public class ModelRun
    {
        public long RunID { get; internal set; }
        public string Title { get; internal set; }
        public long RunTypeID { get; internal set; }
        public string RunType { get; internal set; }
        public DateTime AddedOn { get; internal set; }
        public string AddedBy { get; internal set; }

        public ModelRun(long nRunID, string sTitle, long nRunTypeID, string sRunType, DateTime dAddedOn, string sAddedBy)
        {
            RunID = nRunID;
            Title = sTitle;
            RunTypeID = nRunTypeID;
            RunType = sRunType;
            AddedOn = dAddedOn;
            AddedBy = sAddedBy;
        }

        public static BindingList<ModelRun> Load(string sDB)
        {
            BindingList<ModelRun> lRecords = new BindingList<ModelRun>();

            using (SQLiteConnection dbCon = new SQLiteConnection(sDB))
            {
                dbCon.Open();

                string sSQL = "SELECT M.LocalRunID, M.Title, M.RunTypeID, L.Title AS RunType, M.AddedOn, M.AddedBy FROM ModelRuns M INNER JOIN LookupListItems L ON (M.RunTypeID = L.ItemID) ORDER BY M.AddedOn DESC";
                SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    lRecords.Add(new ModelRun(
                        (long)dbRead["LocalRunID"]
                        , (string)dbRead["Title"]
                        , (long)dbRead["RunTypeID"]
                        , (string)dbRead["RunType"]
                        , (DateTime)dbRead["AddedOn"]
                        , (string)dbRead["AddedBy"]
                        ));
                }
            }

            return lRecords;
        }
    }
}

