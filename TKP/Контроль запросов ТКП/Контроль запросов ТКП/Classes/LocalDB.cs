using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Контроль_запросов_ТКП
{
    class LocalDB
    {

        private static string ConStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\10.105.21.69\share\SSPD_TO\StaticDB.mde";

        public static DataRowCollection LoadData(string Sql)
        {
            DataRowCollection dra = null;

            OleDbConnection Conn = new OleDbConnection(ConStr);

            try
            {

                DataSet myDataSet = new DataSet();

                OleDbCommand myAccessCommand = new OleDbCommand(Sql, Conn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                Conn.Open();
                myDataAdapter.Fill(myDataSet, "Data");

                dra = myDataSet.Tables["Data"].Rows;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                dra = null;
            }
            finally
            {
                Conn.Close();
            }

            return dra;
        }

        public static void InsertData(Dictionary<string, string> DataSet, string TableName)
        {
            string SqlStr = "INSERT INTO " + TableName;
            string SqlColumns = " (";
            string SqlValues = " VALUES (";
            bool flComma = false;
            foreach (KeyValuePair<string, string> kvp in DataSet)
            {
                if (flComma == true)
                {
                    SqlColumns += ", ";
                    SqlValues += ", ";
                }
                else flComma = true;

                SqlColumns += kvp.Key;
                string val = SetQuotes(kvp.Value);
                if (val == "Null")
                    SqlValues += val;
                else
                    SqlValues += string.Format("'{0}'", val);
            }
            SqlStr += SqlColumns + ") " + SqlValues + ")";

            try
            {
                OleDbConnection Conn = new OleDbConnection(ConStr);
                OleDbCommand dbCommand = new OleDbCommand(SqlStr, Conn);
                Conn.Open();
                dbCommand.ExecuteNonQuery();
                Conn.Close();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Добавление новой записи в БД");
            }
        }

        public static void UpdateData(Dictionary<string, string> DataSet, string TableName, string WhereValue)
        {
            string SqlStr = "UPDATE " + TableName + " SET ";
            bool flComma = false;
            foreach (KeyValuePair<string, string> kvp in DataSet)
            {
                if (flComma == true) SqlStr += ", "; else flComma = true;
                string val = SetQuotes(kvp.Value);
                if (val == "Null")
                    SqlStr += string.Format("{0}={1}", kvp.Key, val);
                else
                {
                    if (val != "")
                        SqlStr += string.Format("{0}='{1}'", kvp.Key, val);
                    else
                        SqlStr += string.Format("{0}={1}", kvp.Key, "NULL");
                }
                
            }
            if (WhereValue.Length > 0) SqlStr += " WHERE " + WhereValue;

            OleDbConnection Conn = new OleDbConnection(ConStr);
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            Conn.Open();
            try
            {
                oledbAdapter.UpdateCommand = Conn.CreateCommand();
                oledbAdapter.UpdateCommand.CommandText = SqlStr;
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Обновление записи в БД");
            }
            finally
            {
                Conn.Close();
            }
        }

        public static void DeleteData(string TableName, string WhereValue)
        {
            string SqlStr = "DELETE FROM " + TableName;
            if (WhereValue.Length > 0) SqlStr += " WHERE " + WhereValue;

            OleDbConnection Conn = new OleDbConnection(ConStr);
            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            Conn.Open();
            try
            {
                oledbAdapter.UpdateCommand = Conn.CreateCommand();
                oledbAdapter.UpdateCommand.CommandText = SqlStr;
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Удаление записи в БД");
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Экранируем кавычки в SQL запросе
        /// </summary>
        /// <param name="SqlStr">Sql запрос</param>
        /// <returns>Sql запрос с экранированными кавычками</returns>
        public static string SetQuotes(string SqlStr)
        {
            SqlStr = System.Text.RegularExpressions.Regex.Replace(SqlStr, "[']", ((char)34).ToString());

            return SqlStr;
        }


    }
}
