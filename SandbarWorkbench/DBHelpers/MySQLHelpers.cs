using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SandbarWorkbench.DBHelpers
{
    class MySQLHelpers
    {
        //public static string MySQLConString = "server=mysql.northarrowresearch.com;uid=nar;pwd=5Yuuxf3BhSI7F3Z5;database=SandbarTest;";


        public static void FillTextBox(ref SQLiteDataReader dbRead, string sColumnName, ref TextBox txt)
        {
            if (dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
                txt.Text = string.Empty;
            else
                txt.Text = dbRead.GetString(dbRead.GetOrdinal(sColumnName));
        }

        public static void FillNumericUpDown(ref SQLiteDataReader dbRead, string sColumnName, ref NumericUpDown val, int nExponent = 0)
        {
            if (!dbRead.IsDBNull(dbRead.GetOrdinal(sColumnName)))
            {
                switch (dbRead.GetDataTypeName(dbRead.GetOrdinal(sColumnName)).ToLower())
                {
                    case "Int64":
                    case "int":
                        decimal fRawIntValue = (decimal)dbRead.GetInt64(dbRead.GetOrdinal(sColumnName));
                        if (nExponent != 0)
                            val.Value = fRawIntValue * (decimal)Math.Pow(10, nExponent);
                        else
                            val.Value = fRawIntValue;
                        break;

                    case "double":
                        decimal fRawValue = (decimal)dbRead.GetDouble(dbRead.GetOrdinal(sColumnName));
                        if (nExponent != 0)
                            val.Value = fRawValue * (decimal)Math.Pow(10, nExponent);
                        else
                            val.Value = fRawValue;
                        break;

                    default:
                        throw new Exception(string.Format("Unhandled data type filling numeric up down for type {0}", dbRead.GetDataTypeName(dbRead.GetOrdinal(sColumnName)).ToLower()));
                }
            }
        }

        public static void AddParameter(ref SQLiteCommand dbCom, ref TextBox ctrl, string sParameterName)
        {
            if (string.IsNullOrEmpty(ctrl.Text))
            {
                SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.String);
                p.Value = DBNull.Value;
            }
            else
            {
                dbCom.Parameters.AddWithValue(sParameterName, ctrl.Text);
            }
        }

        public static void AddParameter(ref SQLiteCommand dbCom, ref NumericUpDown ctrl, string sParameterName, int nExponent = 0)
        {
            if (nExponent == 0)
                dbCom.Parameters.AddWithValue(sParameterName, ctrl.Value);
            else
                dbCom.Parameters.AddWithValue(sParameterName, ctrl.Value * (decimal)Math.Pow(10, nExponent));
        }

        public static void AddParameter(ref SQLiteCommand dbCom, ref ComboBox ctrl, string sParameterName)
        {
            if (ctrl.SelectedIndex < 0)
            {
                SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.Int64);
                p.Value = DBNull.Value;
            }
            else
            {
                dbCom.Parameters.AddWithValue(sParameterName, ((ListItem)ctrl.SelectedItem).Value);
            }
        }

        public static void AddParameter(ref SQLiteCommand dbCom, ref CheckBox ctrl, string sParameterName)
        {
            SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.Boolean);
            p.Value = ctrl.Checked;
        }

        public static void AddNParameter(ref SQLiteCommand dbCom, ref CheckBox ctrl, ref DateTimePicker dt, string sParameterName)
        {
            SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.DateTime);
            if (ctrl.Checked)
                p.Value = dt.Value;
            else
                p.Value = DBNull.Value;
        }

        public static void AddNParameter(ref SQLiteCommand dbCom, ref CheckBox ctrl, ref NumericUpDown val, string sParameterName)
        {
            SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.DateTime);
            if (ctrl.Checked)
                p.Value = val.Value;
            else
                p.Value = DBNull.Value;
        }

        /// <summary>
        /// Safely add a string parameter to a SQLite command. Adds empty strings as NULL
        /// </summary>
        /// <param name="dbCom">Insert or update SQL command</param>
        /// <param name="txt">textbox containing string to be inserted</param>
        /// <param name="sParameterName">Name of parameter to create</param>
        /// <returns></returns>
        public static SQLiteParameter AddStringParameterN(ref SQLiteCommand dbCom, ref System.Windows.Forms.TextBox txt, string sParameterName)
        {
            return AddStringParameterN(ref dbCom, txt.Text, sParameterName);
        }

        public static SQLiteParameter AddStringParameterN(ref SQLiteCommand dbCom, string sStringValue, string sParameterName)
        {
            System.Diagnostics.Debug.Assert(dbCom.CommandText.ToLower().Contains("insert") || dbCom.CommandText.ToLower().Contains("update"), "SQL command must be an INSERT or UPDATE command");
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(sParameterName), "The parameter name cannot be empty.");
            System.Diagnostics.Debug.Assert(!dbCom.Parameters.Contains(sParameterName), "The SQL command already contains a parameter with this name.");

            string sValue = sStringValue.Trim();
            SQLiteParameter p = dbCom.Parameters.Add(sParameterName, System.Data.DbType.String);
            if (string.IsNullOrEmpty(sValue))
                p.Value = DBNull.Value;
            else
            {
                p.Value = sValue;
                p.Size = sValue.Length;
            }

            return p;
        }
    }
}
