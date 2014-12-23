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
        public static OleDbConnection LocalConn = new OleDbConnection(ConStr);


        public static DataRowCollection LoadData(string Sql)
        {
            DataRowCollection dra = null;

            try
            {

                DataSet myDataSet = new DataSet();

                OleDbCommand myAccessCommand = new OleDbCommand(Sql, LocalConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                if (LocalConn.State == ConnectionState.Closed)
                    LocalConn.Open();

                myDataAdapter.Fill(myDataSet, "Data");

                dra = myDataSet.Tables["Data"].Rows;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                dra = null;
            }

            return dra;
        }

        public static void InsertData(Dictionary<string, object> DataSet, string TableName)
        {
            string SqlStr = string.Format("INSERT INTO [{0}] ", TableName);
            string SqlNameColumns = "";
            string SqlParValues = "";

            OleDbCommand cmd = new OleDbCommand(SqlStr, LocalConn);

            //создание части SQL запроса по наименованиям полей с использованием параметров

            //foreach (KeyValuePair<string, object> kvp in DataSet) - для добавление данных кроме строк
            foreach (KeyValuePair<string, object> kvp in DataSet)
            {
                if (!string.IsNullOrEmpty(SqlNameColumns))
                {
                    SqlNameColumns += ", ";
                    SqlParValues += ", ";
                }

                SqlNameColumns += kvp.Key;
                SqlParValues += "@" + kvp.Key;
                cmd.Parameters.Add(new OleDbParameter("@" + kvp.Key, kvp.Value));
            }

            if (string.IsNullOrEmpty(SqlNameColumns))
            {
                return;
            }
            else
            {
                SqlStr += string.Format(" ({0}) VALUES ({1})", SqlNameColumns, SqlParValues);
            }

            //выполнение SQL конструкции

            try
            {
                //Console.WriteLine(SqlStr);

                if (LocalConn.State == ConnectionState.Closed)
                    LocalConn.Open();

                cmd.CommandText = SqlStr;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Добавление новой записи в БД");
            }
        }

        public static void UpdateData(Dictionary<string, object> DataSet, string TableName, string WhereValue)
        {
            string SqlStr = string.Format("UPDATE {0} SET ", TableName);
            string SqlNameParColumns = "";

            OleDbCommand cmd = new OleDbCommand(SqlStr, LocalConn);

            //создание части SQL запроса по наименованиям полей с использованием параметров

            foreach (KeyValuePair<string, object> kvp in DataSet)
            {
                if (!string.IsNullOrEmpty(SqlNameParColumns))
                {
                    SqlNameParColumns += ", ";
                }

                SqlNameParColumns += string.Format("{0} = {1}", kvp.Key, "@" + kvp.Key);

                if (kvp.Value != null)
                    if (kvp.Value.ToString() != "")
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                    else
                        cmd.Parameters.AddWithValue("@" + kvp.Key, DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@" + kvp.Key, DBNull.Value);
                    //DBNull.Value

            }

            SqlStr += SqlNameParColumns;

            //условие
            if (!string.IsNullOrEmpty(WhereValue))
                SqlStr += string.Format(" WHERE {0}", WhereValue);


            //выполнение SQL конструкции

            try
            {
                if (LocalConn.State == ConnectionState.Closed)
                    LocalConn.Open();

                cmd.CommandText = SqlStr;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Обновление записи в БД");
            }
        }

        public static void DeleteData(string TableName, string WhereValue)
        {
            string SqlStr = "DELETE FROM " + TableName;
            if (WhereValue.Length > 0) SqlStr += " WHERE " + WhereValue;

            OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
            
            if (LocalConn.State == ConnectionState.Closed)
                LocalConn.Open();

            try
            {
                oledbAdapter.UpdateCommand = LocalConn.CreateCommand();
                oledbAdapter.UpdateCommand.CommandText = SqlStr;
                oledbAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message, "Удаление записи в БД");
            }
        }

        /// <summary>
        /// Экранируем кавычки в SQL запросе
        /// </summary>
        /// <param name="SqlStr">Sql запрос</param>
        /// <returns>Sql запрос с экранированными кавычками</returns>
        public static string SetQuotes(string SqlStr)
        {
            if (SqlStr == null) return "";

            SqlStr = System.Text.RegularExpressions.Regex.Replace(SqlStr, "[']", ((char)34).ToString());

            return SqlStr;
        }


    }
}
