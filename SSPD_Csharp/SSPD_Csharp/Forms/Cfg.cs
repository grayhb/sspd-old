using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SSPD
{
    public partial class Cfg : Form
    {
        //класс для работы с конфигом
        private Config config = new Config();

        public Cfg()
        {
            InitializeComponent();
            
            this.KeyDown +=new KeyEventHandler(Cfg_KeyDown);

            LoadCFG();
        }

        private void Cfg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
            if (e.KeyCode == Keys.F2) SaveConfig();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadCFG()
        {
            //считываем параметры из конфига
            config.ReadCFG();

            DataSource.Text = Params.ServerSQL.DataSource;
            database.Text = Params.ServerSQL.database;
            SERVERProvider.Text = Params.ServerSQL.SERVERProvider;
            uid.Text = Params.ServerSQL.uid;
            pwd.Text = Params.ServerSQL.pwd;

            DataSourcePCD.Text = Params.ServerSQLPCD.DataSource;
            databasePCD.Text = Params.ServerSQLPCD.database;
            SERVERProviderPCD.Text = Params.ServerSQLPCD.SERVERProvider;
            uidPCD.Text = Params.ServerSQLPCD.uid;
            pwdPCD.Text = Params.ServerSQLPCD.pwd;

            FTPServer.Text = Params.ServerFTP.Adress;
            FTPServerPort.Text = Params.ServerFTP.Port;
            UserNameRead.Text = Params.ServerFTP.UserNameRead;
            UserNameWrite.Text = Params.ServerFTP.UserNameWrite;
            PasswordRead.Text = Params.ServerFTP.PasswordRead;
            PasswordWrite.Text = Params.ServerFTP.PasswordWrite;

            FTPServerFR.Text = Params.ServerFTPFR.Adress;
            FTPServerPortFR.Text = Params.ServerFTPFR.Port;
            UserNameReadFR.Text = Params.ServerFTPFR.UserNameRead;
            UserNameWriteFR.Text = Params.ServerFTPFR.UserNameWrite;
            PasswordReadFR.Text = Params.ServerFTPFR.PasswordRead;
            PasswordWriteFR.Text = Params.ServerFTPFR.PasswordWrite;

            FTPServerFSO.Text = Params.ServerFTPFSO.Adress;
            FTPServerPortFSO.Text = Params.ServerFTPFSO.Port;
            UserNameReadFSO.Text = Params.ServerFTPFSO.UserNameRead;
            UserNameWriteFSO.Text = Params.ServerFTPFSO.UserNameWrite;
            PasswordReadFSO.Text = Params.ServerFTPFSO.PasswordRead;
            PasswordWriteFSO.Text = Params.ServerFTPFSO.PasswordWrite;

        }

        private void SaveConfig()
        {
            Console.WriteLine(config.Code(DataSource.Text, Params.Mask));
            //MessageBox.Show(config.Code(DataSource.Text, Params.Mask));
            Clipboard.SetText(config.Code(DataSource.Text, Params.Mask));
            //•—™•— ’™œ’›£
            return;

            string myCfg = null;

            //Параметры соединения с SQL-сервером
            myCfg = config.Code(DataSource.Text, Params.Mask);

            myCfg = Convert.ToChar((90 - config.Code(database.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(database.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(SERVERProvider.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(SERVERProvider.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(uid.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(uid.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(pwd.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(pwd.Text, Params.Mask);

            
            //Параметры соединения с FTP-сервером (документооборот)
            myCfg += Convert.ToChar((90 - config.Code(FTPServer.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServer.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(FTPServerPort.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServerPort.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameRead.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameRead.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameWrite.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameWrite.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordRead.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordRead.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordWrite.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordWrite.Text, Params.Mask);

            //Параметры соединения с SQL-сервером обмена
            myCfg += Convert.ToChar((90 - config.Code(DataSourcePCD.Text, Params.Mask).Length)).ToString();
            myCfg +=config.Code(DataSourcePCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(databasePCD.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(databasePCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(SERVERProviderPCD.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(SERVERProviderPCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(uidPCD.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(uidPCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(pwdPCD.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(pwdPCD.Text, Params.Mask);

            //Параметры соединения с FTP-сервером (ФСО)
            myCfg += Convert.ToChar((90 - config.Code(FTPServerFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServerFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(FTPServerPortFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServerPortFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameReadFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameReadFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameWriteFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameWriteFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordReadFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordReadFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordWriteFSO.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordWriteFSO.Text, Params.Mask);

            //Параметры соединения с FTP-сервером (ФР)
            myCfg += Convert.ToChar((90 - config.Code(FTPServerFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServerFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(FTPServerPortFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(FTPServerPortFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameReadFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameReadFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(UserNameWriteFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(UserNameWriteFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordReadFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordReadFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(PasswordWriteFR.Text, Params.Mask).Length)).ToString();
            myCfg += config.Code(PasswordWriteFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - config.Code(DataSource.Text, Params.Mask).Length)).ToString();

            Console.WriteLine(myCfg.Substring(0, 1));

            // записываем в файл побайтно начиная с позиции 55 набор байтов
            char[] charArr = myCfg.ToCharArray();
            Console.WriteLine(charArr.Length);
            byte[] byteArr = new byte[charArr.Length];
            try
            {
                FileStream fs = new FileStream(Params.CfgPath+".txt", FileMode.OpenOrCreate, FileAccess.Write);
                
                //Console.WriteLine(Convert.ToByte(charArr[0]));

                //fs.Seek(0, SeekOrigin.Begin);
                Encoder enc = Encoding.Default.GetEncoder();
                enc.GetBytes(charArr, 0, charArr.Length, byteArr, 0, true); // перекодирование
                fs.Write(byteArr, 0, byteArr.Length); // запись массива байт
                fs.Dispose(); // освобождаем ресурсы
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message); return;
            }




            //MessageBox.Show(myCfg);
            //Clipboard.SetText(myCfg);

            //System.IO.File.WriteAllText(Params.CfgPath + "_new.txt", myCfg);
            //System.IO.File.WriteAllBytes(

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        
    }
}
