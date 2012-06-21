using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class Cfg : Form
    {
        public Cfg()
        {
            InitializeComponent();
            
            this.KeyDown +=new KeyEventHandler(Cfg_KeyDown);
        }

        private void Cfg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
            if (e.KeyCode == Keys.F2) return; //добавить ссылку на сохранение
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cfg_Load(object sender, EventArgs e)
        {
            Config config = new Config();
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
            //запись в файл

        }

        
    }
}
