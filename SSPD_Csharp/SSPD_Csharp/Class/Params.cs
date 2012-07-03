﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSPD
{
    class Params
    {
        /// <summary>
        /// путь до файла с конфигурацией ССПД
        /// </summary>
        public static string CfgPath = Environment.CurrentDirectory + "\\sspd.cfg";

        /// <summary>
        /// маска (solt)
        /// </summary>
        public static string Mask = "dgk";      

        /// <summary>
        /// строка подключения к БД
        /// </summary>
        public static string ConString;         


        /// <summary>
        /// структура параметров для подключения к SQL серверу (База ССПД)
        /// </summary>
        public static SQLS ServerSQL;

        /// <summary>
        /// структура параметров для подключения к SQL серверу (Промежуточная БД)
        /// </summary>
        public static SQLS ServerSQLPCD;


        /// <summary>
        /// структура параметров для подключения к ФТП серверу (общий)
        /// </summary>
        public static SFTP ServerFTP;

        /// <summary>
        /// структура параметров для подключения к ФТП серверу (Архив скан образов проектов)
        /// </summary>
        public static SFTP ServerFTPFSO;

        /// <summary>
        /// структура параметров для подключения к ФТП серверу (Архив формата разработки проектов)
        /// </summary>
        public static SFTP ServerFTPFR;

        /// <summary>
        /// объявление структуры параметров пользователя
        /// </summary>
        public static SUser UserInfo;

        /// <summary>
        /// подсказка в строке поиска
        /// </summary>
        public static string StrFindLabel = "Введите строку для поиска";


        /// <summary>
        /// структура параметров пользователя
        /// </summary>
        public struct SUser
        {
            //параметры пользователя
            public string ID_Worker;
            public string ID_Post;
            public string FIO;
            public string RightUser;

            //параметры отдела
            public string ID_Otdel;
            public string NBOtdel;

            //параметры организации
            public string ID_CurOrg;
            public string NameCurOrg;
            public string NameBrCurOrg;

        }

        /// <summary>
        /// структура конфигурации подключения к SQL серверу
        /// </summary>
        public struct SQLS
        {
            public string DataSource;
            public string database;
            public string SERVERProvider;
            public string uid;
            public string pwd;
        }
        
        /// <summary>
        /// структура конфигурации подключения к ФТП серверу
        /// </summary>
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
