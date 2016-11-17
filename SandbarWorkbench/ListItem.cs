using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace SandbarWorkbench
{
    public class ListItem
    {
        private string m_sText;
        private long m_nValue;

        public ListItem(string sText, Int64 nValue)
        {
            m_sText = sText;
            m_nValue = nValue;
        }

        public string Text { get { return m_sText; } }

        public long Value { get { return m_nValue; } }

        public override string ToString()
        {
            return m_sText;
        }

        public static int LoadComboWithListItems(ref System.Windows.Forms.ComboBox cbo, string sDBCon, string sSQL, long nSelectID = 0)
        {
            cbo.Items.Clear();

            using (System.Data.SQLite.SQLiteConnection dbCon = new System.Data.SQLite.SQLiteConnection(sDBCon))
            {
                dbCon.Open();

                System.Data.SQLite.SQLiteCommand dbCom = new System.Data.SQLite.SQLiteCommand(sSQL, dbCon);
                System.Data.SQLite.SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nID = (long)dbRead.GetValue(0);
                    int nIn = cbo.Items.Add(new ListItem(dbRead.GetString(1), nID));
                    if (nID == nSelectID)
                        cbo.SelectedIndex = nIn;
                }
            }

            return cbo.Items.Count;
        }

        public static int LoadComboWithLookupListItems(ref System.Windows.Forms.ComboBox cbo, string sDBCon, long nListID, long nSelectID = 0)
        {
            return LoadComboWithListItems(ref cbo, sDBCon, string.Format("SELECT ItemID, Title FROM LookupListItems WHERE ListID = {0} ORDER BY Title", nListID), nSelectID);
        }

        public static int LoadComboWithListItemsMySQL(ref System.Windows.Forms.ComboBox cbo, string sDBCon, string sSQL, long nSelectID = 0)
        {
            cbo.Items.Clear();

            using (MySqlConnection dbCon = new MySqlConnection(sDBCon))
            {
                dbCon.Open();

                MySqlCommand dbCom = new MySqlCommand(sSQL, dbCon);
                MySqlDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    long nID = dbRead.GetInt64(0);
                    int nIn = cbo.Items.Add(new ListItem(dbRead.GetString(1), nID));
                    if (nID == nSelectID)
                        cbo.SelectedIndex = nIn;
                }
            }

            return cbo.Items.Count;
        }
    }

    public class ListItemInt
    {
        public string Text { get; internal set; }
        public int Value { get; internal set; }

        public ListItemInt(string sText, int nValue)
        {
            Text = sText;
            Value = nValue;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class CheckedListItem : ListItem
    {
        private Boolean m_bChecked;

        public Boolean Checked { get; set; }

        public CheckedListItem(string sText, int nValue, Boolean bChecked = true)
            : base(sText, nValue)
        {
            m_bChecked = bChecked;
        }

        public static int LoadComboWithListItems(ref System.Windows.Forms.CheckedListBox lst, string sDBCon, string sSQL, bool bCheckItems)
        {
            lst.Items.Clear();

            using (System.Data.SQLite.SQLiteConnection dbCon = new System.Data.SQLite.SQLiteConnection(sDBCon))
            {
                dbCon.Open();

                System.Data.SQLite.SQLiteCommand dbCom = new System.Data.SQLite.SQLiteCommand(sSQL, dbCon);
                System.Data.SQLite.SQLiteDataReader dbRead = dbCom.ExecuteReader();
                while (dbRead.Read())
                {
                    int nID = 0;
                    if (dbRead.GetFieldType(0) == Type.GetType("System.Int16"))
                        nID = (int)dbRead.GetInt16(0);
                    else if (dbRead.GetFieldType(0) == Type.GetType("System.Int32"))
                        nID = dbRead.GetInt32(0);
                    else if (dbRead.GetFieldType(0) == Type.GetType("System.Int64"))
                        nID = (int)dbRead.GetInt64(0);
                    else
                        throw new Exception("Unhandled field type in column 0");

                    int nIn = lst.Items.Add(new ListItem(dbRead.GetString(1), nID));
                    lst.SetItemChecked(nIn, bCheckItems);
                }
            }

            return lst.Items.Count;
        }
    }
}
