using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Drawing;

namespace SandbarWorkbench.AnalysisBins
{
    class AnalysisBinCRUD : DBHelpers.CRUDManager
    {
        public AnalysisBinCRUD()
            : base("AnalysisBins", "BinID", new string[] { "Title", "LowerDischarge", "UpperDischarge", "IsActive", "DisplayColor" })
        {

        }

        protected override void SaveLocal(ref SQLiteTransaction dbTrans, ref DBHelpers.DatabaseObject obj, string sSQL)
        {
            SQLiteCommand dbCom = new SQLiteCommand(sSQL, dbTrans.Connection, dbTrans);

            if (obj.ID > 0)
            {
                dbCom.Parameters.AddWithValue(PrimaryKey, obj.ID);
            }
            else
            {
                dbCom.Parameters.AddWithValue(PrimaryKey, DBNull.Value);
            }

            dbCom.Parameters.AddWithValue("Title", obj.Title);
            dbCom.Parameters.AddWithValue("IsActive", ((AnalysisBin)obj).IsActive);
            dbCom.Parameters.AddWithValue("EditedBy", Environment.UserName);
            dbCom.Parameters.AddWithValue("DisplayColor", ColorTranslator.ToHtml(Color.FromArgb(((AnalysisBin)obj).DisplayColor.ToArgb())));

            SQLiteParameter pLowerdischarge = dbCom.Parameters.Add("LowerDischarge", System.Data.DbType.Double);
            if (((AnalysisBin)obj).LowerDischarge.HasValue)
                pLowerdischarge.Value = ((AnalysisBin)obj).LowerDischarge;
            else
                pLowerdischarge.Value = DBNull.Value;

            SQLiteParameter pUpper = dbCom.Parameters.Add("UpperDischarge", System.Data.DbType.Double);
            if (((AnalysisBin)obj).UpperDischarge.HasValue)
                pUpper.Value = ((AnalysisBin)obj).UpperDischarge;
            else
                pLowerdischarge.Value = DBNull.Value;

            dbCom.ExecuteNonQuery();
            DBCon.BackupRequiredOnClose = true;

            if (obj.ID == 0)
            {
                obj.ID = dbTrans.Connection.LastInsertRowId;
            }
        }
    }
}
