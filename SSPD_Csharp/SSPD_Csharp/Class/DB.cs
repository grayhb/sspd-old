using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;


namespace SSPD
{
    class DB
    {

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

        /// <summary>
        /// Возвращает коллекцию строк по запросу
        /// </summary>
        /// <param name="SqlQuery">SQL запрос</param>
        /// <returns>Возврат коллекции строк (в типе DataRowCollection)</returns>
        public static DataRowCollection GetFields(string SqlQuery)
        {
            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
            OleDbCommand myAccessCommand = new OleDbCommand(SqlQuery, Conn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
            DataRowCollection DRC;
            Conn.Open();
            try
            {
                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "temp");
                DRC = myDataSet.Tables["temp"].Rows;
            }
            catch (OleDbException ex)
            {
                SSPDUI.MsgEx(ex.Message, "Чтение записей из БД");
                return null;
            }
            finally
            {
                Conn.Close();
            }
            return DRC;
        }

        /// <summary>
        /// Обновление записей
        /// </summary>
        /// <param name="DataSet">Коллекция ключей и значений (ключ - наименование поля)</param>
        /// <param name="TableName">Наименование таблицы</param>
        /// <param name="WhereValue">Условие (указывается без ключего слова WHERE)</param>
        public static void SetFields(Dictionary<string, string> DataSet, string TableName, string WhereValue)
        {
            string SqlStr = "UPDATE " + TableName + " SET ";
            bool flComma = false;
            foreach (KeyValuePair<string, string> kvp in DataSet)
            {
                if (flComma == true) SqlStr += ", "; else flComma = true;
                SqlStr += string.Format("{0}='{1}'", kvp.Key, SetQuotes(kvp.Value));
            }
            if (WhereValue.Length > 0) SqlStr += " WHERE " + WhereValue;

            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
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
                SSPDUI.MsgEx(ex.Message, "Обновление записей в БД");
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Удаление записи из указанной таблицы и условием
        /// </summary>
        /// <param name="TableName">Наименование таблицы</param>
        /// <param name="WhereValue">Условие (указывается без ключего слова WHERE)</param>
        public static void DeleteRow(string TableName, string WhereValue)
        {
            string SqlStr = "DELETE FROM " + TableName;
            if (WhereValue.Length > 0) SqlStr += " WHERE " + WhereValue;

            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
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
                SSPDUI.MsgEx(ex.Message, "Удаление записей в БД");
            }
            finally
            {
                Conn.Close();
            }
        }


        /// <summary>
        /// Добавление новой записи в указанную таблицу
        /// </summary>
        /// <param name="DataSet">Коллекция ключей и значений (ключ - наименование поля)</param>
        /// <param name="TableName">Наименование таблицы</param>
        public static void InsertRow(Dictionary<string, string> DataSet, string TableName)
        {
            string SqlStr = "INSERT INTO " + TableName ;
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

                SqlColumns +=  kvp.Key;
                SqlValues += string.Format("'{0}'", SetQuotes(kvp.Value));
            }
            SqlStr += SqlColumns + ") " + SqlValues + ")";

            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
            OleDbCommand dbCommand = new OleDbCommand(SqlStr, Conn);
            Conn.Open();
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                SSPDUI.MsgEx(ex.Message, "Добавление новой записи в БД");
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Обновление/создание двоичного поля в указанной таблице
        /// </summary>
        /// <param name="ByteArray">Массив байтов</param>
        /// <param name="TableName">Наименование таблицы</param>
        /// <param name="ByteFieldName">Наименование поля для записи двоичных данных</param>
        /// <param name="WhereValue">Условие (указывается без ключего слова WHERE)</param>
        public static void SetByteField(byte[] ByteArray, string TableName, string ByteFieldName, string WhereValue)
        {
            string SqlStr = "UPDATE " + TableName + " SET " + ByteFieldName + " = ? ";
            SqlStr += " WHERE " + WhereValue;

            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
            OleDbCommand dbCommand = new OleDbCommand(SqlStr, Conn);
            Conn.Open();
            try
            {
                dbCommand.Parameters.Add(ByteFieldName, OleDbType.VarBinary).Value = ByteArray;
                dbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                SSPDUI.MsgEx(ex.Message, "Обновление двоичной записи в БД");
            }
            finally
            {
                Conn.Close();
            }
        }


        /// <summary>
        /// Добавление новой записи в указанную таблицу
        /// </summary>
        /// <param name="DataSet">Коллекция ключей и значений (ключ - наименование поля)</param>
        /// <param name="ByteArray">Массив байтов</param>
        /// <param name="ByteFieldName"></param>
        /// <param name="TableName">Наименование таблицы</param>
        public static void InsertByteRow(Dictionary<string, string> DataSet,byte[] ByteArray, string ByteFieldName, string TableName)
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
                SqlValues += string.Format("'{0}'", kvp.Value);
            }
            SqlStr += SqlColumns + ", " + ByteFieldName+ ") " + SqlValues + ", ?)";
            OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
            OleDbCommand dbCommand = new OleDbCommand(SqlStr, Conn);
            Conn.Open();
            try
            {
                dbCommand.Parameters.Add(ByteFieldName, OleDbType.VarBinary).Value = ByteArray;
                dbCommand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.StackTrace);
                SSPDUI.MsgEx(ex.Message, "Добавление новой записи в БД");
            }
            finally
            {
                Conn.Close();
            }
        }

    }
}
