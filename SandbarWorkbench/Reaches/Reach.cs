using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;

namespace SandbarWorkbench.Reaches
{
    class Reach : DBHelpers.DatabaseObject
    {
        public string ReachCode { get; internal set; }
        
        public Reach(long nID, string sReachCode, string sTitle, DateTime dtAddedOn, string sAddedBy, DateTime dtUpdatedOn, string sUpdatedBy)
            : base(nID, sTitle, dtAddedOn,sAddedBy,dtUpdatedOn,sUpdatedBy )
        {
            ReachCode = sReachCode;
            Title = sTitle;
        }

        public static SortableBindingList<Reach> LoadReaches()
        {
            SortableBindingList<Reach> lItems = new SortableBindingList<Reach>();

            using (SQLiteConnection dbCon = new SQLiteConnection(DBCon.ConnectionStringLocal))
            {
                dbCon.Open();
                SQLiteCommand dbCom = new SQLiteCommand("SELECT ReachID, ReachCode, Title, AddedOn, AddedBy, UpdatedOn, UpdatedBy FROM Reaches ORDER BY Title", dbCon);
                SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    Reach theItem = new Reach(
                        (long)dbRead["ReachID"]
                        , (string)dbRead["ReachCode"]
                        , (string)dbRead["Title"]
                        , (DateTime) dbRead["AddedOn"]
                        , (string) dbRead["AddedBy"]
                        , (DateTime) dbRead["UpdatedOn"]
                        , (string) dbRead["UpdatedBy"]
                        );

                    lItems.Add(theItem);
                }
            }

            return lItems;


        }
    }
}
