using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace SSPD
{
    class DB
    {
        /// <summary>
        /// Возвращает коллекцию строк по запросу
        /// </summary>
        /// <param name="SqlQuery">SQL запрос</param>
        /// <returns></returns>
        public static DataRowCollection GetFields(string SqlQuery)
        {
            try
            {
                OleDbConnection Conn = new OleDbConnection("Provider=SQLOLEDB;" + Params.ConString);
                OleDbCommand myAccessCommand = new OleDbCommand(SqlQuery, Conn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                Conn.Open();
                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "temp");
                DataRowCollection DRC = myDataSet.Tables["temp"].Rows;
                Conn.Close();
                return DRC;
            }
            catch (OleDbException ex)
            {
                SSPDUI.MsgEx(ex.Message, "Подключение к БД");
                return null;
            }

        }



    }
}
