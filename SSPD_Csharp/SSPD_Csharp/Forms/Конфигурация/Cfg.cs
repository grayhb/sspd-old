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
        //private Config config = new Config();

        public Cfg()
        {

            InputPassword InpPass = new InputPassword();
            InpPass.ShowDialog();
            if (InpPass.retVal == false) { System.Environment.Exit(0); }

            InitializeComponent();
            
            this.KeyDown +=new KeyEventHandler(Cfg_KeyDown);

            LoadCFG();

        }

        private void Cfg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) System.Environment.Exit(0);
            if (e.KeyCode == Keys.F2) SaveConfig();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LoadCFG()
        {
            //считываем параметры из конфига
            Config.ReadCFG();

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
            string myCfg = null;

            //Параметры соединения с SQL-сервером
            myCfg = Config.Code(DataSource.Text, Params.Mask);


            myCfg += Convert.ToChar((90 - Config.Code(database.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(database.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(SERVERProvider.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(SERVERProvider.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(uid.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(uid.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(pwd.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(pwd.Text, Params.Mask);

            
            //Параметры соединения с FTP-сервером (документооборот)
            myCfg += Convert.ToChar((90 - Config.Code(FTPServer.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServer.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(FTPServerPort.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServerPort.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameRead.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameRead.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameWrite.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameWrite.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordRead.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordRead.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordWrite.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordWrite.Text, Params.Mask);

            //Параметры соединения с SQL-сервером обмена
            myCfg += Convert.ToChar((90 - Config.Code(DataSourcePCD.Text, Params.Mask).Length)).ToString();
            myCfg +=Config.Code(DataSourcePCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(databasePCD.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(databasePCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(SERVERProviderPCD.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(SERVERProviderPCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(uidPCD.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(uidPCD.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(pwdPCD.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(pwdPCD.Text, Params.Mask);

            //Параметры соединения с FTP-сервером (ФСО)
            myCfg += Convert.ToChar((90 - Config.Code(FTPServerFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServerFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(FTPServerPortFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServerPortFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameReadFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameReadFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameWriteFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameWriteFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordReadFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordReadFSO.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordWriteFSO.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordWriteFSO.Text, Params.Mask);

            //Параметры соединения с FTP-сервером (ФР)
            myCfg += Convert.ToChar((90 - Config.Code(FTPServerFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServerFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(FTPServerPortFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(FTPServerPortFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameReadFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameReadFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(UserNameWriteFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(UserNameWriteFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordReadFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordReadFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(PasswordWriteFR.Text, Params.Mask).Length)).ToString();
            myCfg += Config.Code(PasswordWriteFR.Text, Params.Mask);

            myCfg += Convert.ToChar((90 - Config.Code(DataSource.Text, Params.Mask).Length)).ToString();


            // записываем в файл
            try
            {
                FileStream fs = new FileStream(Params.CfgPath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs,Encoding.GetEncoding(1251));
                sw.Write(myCfg);
                sw.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message); return;
            }

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        
    }
}
