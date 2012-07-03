using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SSPD
{
    public partial class WorkersSpravCard : Form
    {

        private string IDW = "";


        public WorkersSpravCard(string ID_Worker)
        {
            InitializeComponent();

            if (ID_Worker != null) IDW = ID_Worker;

            //список должностей
            LoadNPost();
            //список отделов
            LoadOtdels();

        }
       


        //private SetStatus(){
            /*
Работает
Уволен
Командировка
Отпуск
Больничный
Декрет
Прочее
    */
       // SSPDUI.ComboType CBItem;
      //  CBItem.ID_Item=0;

       // }

        /// <summary>
        /// Загрузка списка отделов
        /// </summary>
        private void LoadOtdels()
        {
            string SqlStr = "SELECT ID_Otdel, Name_Otdel From Otdels ORDER BY Name_Otdel";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            SSPDUI.ComboType CBItem;

            foreach (DataRow dr in rs)
            {
                CBItem = new SSPDUI.ComboType();
                CBItem.ID_Item = (int)dr["ID_Otdel"];
                CBItem.Name_Item = dr["Name_Otdel"].ToString();
                Otdel.Items.Add(CBItem);
            }
        }


        /// <summary>
        /// Загрузка списка должностей
        /// </summary>
        private void LoadNPost()
        {
            string SqlStr = "SELECT ID_Post, N_Post From Posts ORDER BY N_Post";
            var rs = DB.GetFields(SqlStr);
            if (rs.Count == 0) return;

            SSPDUI.ComboType CBItem;

            foreach (DataRow dr in rs)
            {
                CBItem = new SSPDUI.ComboType();
                CBItem.ID_Item = (int)dr["ID_Post"];
                CBItem.Name_Item = dr["N_Post"].ToString();
                Posts.Items.Add(CBItem);
            }
        }

    }
}
