using System;
using System.Collections.Generic;
using System.Text;

namespace SSPD
{
    static class Params
    {

        //маска
        public static string Mask = "dgk";      

        //строка подключения к БД
        public static string ConString;         


        //конфиг подключения к SQL серверу (База ССПД)
        public static SQLS ServerSQL;

        //конфиг подключения к SQL серверу (Промежуточная БД)
        public static SQLS ServerSQLPCD;


        //конфиг подключения к ФТП серверу (общий)
        public static SFTP ServerFTP;

        //конфиг подключения к ФТП серверу (Архив скан образов проектов)
        public static SFTP ServerFTPFSO;

        //конфиг подключения к ФТП серверу (Архив формата разработки проектов)
        public static SFTP ServerFTPFR;


        //структура конфига подключения к SQL серверу
        public struct SQLS
        {
            public string DataSource;
            public string database;
            public string SERVERProvider;
            public string uid;
            public string pwd;
        }
        
        //структура конфига подключения к ФТП серверу
        public struct SFTP
        {
            public string Adress;
            public string Port;
            public string UserNameWrite;
            public string PasswordWrite;
            public string UserNameRead;
            public string PasswordRead;
        }



    }
}
