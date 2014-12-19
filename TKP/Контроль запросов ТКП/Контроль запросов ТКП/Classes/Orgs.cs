using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Контроль_запросов_ТКП
{
    class Orgs
    {




        /// <summary>
        /// Добавление в локальный (ТКП) справочник организации
        /// </summary>
        /// <param name="IDOrg"></param>
        public static void addOrg(string IDOrg)
        {
            if (IDOrg == null) return;

            if (!checkOrgInDB(IDOrg))
            {
                //запрос данных из ССПД
                var rs = SSPD.DB.GetFields("SELECT * FROM Orgs WHERE ID_Org = "  + IDOrg);
                if (rs == null || rs.Count == 0 )
                    return; //организация не найдена, выходим


                //запись данных в локальную базу ТКП
                Dictionary<string, object> DS = new Dictionary<string, object>();
                DS.Add("ID_Org", IDOrg);
                DS.Add("Name_Br",rs[0]["Name_br"].ToString() );
                DS.Add("Name_Full", rs[0]["Name"].ToString());
                LocalDB.InsertData(DS, "КонтрольТКП_Организации");
            }
        }


        /// <summary>
        /// Проверяет наличие организации в таблице КонтрольТКП_Организации
        /// </summary>
        /// <param name="IDOrg">ID организации</param>
        /// <returns>true или false</returns>
        private static bool checkOrgInDB(string IDOrg)
        {
            string sql = "SELECT COUNT(*) as CntOrg FROM КонтрольТКП_Организации WHERE ID_Org = " + IDOrg;
            DataRowCollection dra = LocalDB.LoadData(sql);
            if (dra[0]["CntOrg"].ToString() == "0") 
                return false;
            else
                return true;
        }


        public static void addAllDocOrg()
        {
            string sql = "SELECT КонтрольТКП_Письма.ID, КонтрольТКП_Письма.ID_OutDoc, КонтрольТКП_Письма.ID_InpDoc";
            sql += " FROM КонтрольТКП_Письма";
            DataRowCollection dra = LocalDB.LoadData(sql);

            Console.WriteLine(dra.Count);
            int i = 0;
            foreach (DataRow dr in dra)
            {
                i++;
                Console.WriteLine(i);

                string orgInp = "0";
                string orgOut = "0";

                if (dr["ID_InpDoc"].ToString() != "")
                    orgInp = getDataOrgFromIDInp(dr["ID_InpDoc"].ToString());

                if (dr["ID_OutDoc"].ToString() != "")
                    orgOut = getDataOrgFromIDOut(dr["ID_OutDoc"].ToString());


                Dictionary<string, object> DS = new Dictionary<string, object>();
                
                if (orgInp != "0" && orgInp != null)
                    addOrg(orgInp);

                if (orgOut != "0" && orgOut != orgInp && orgOut != null)
                    addOrg(orgOut);

                DS.Add("ID_OrgOut", orgOut);
                DS.Add("ID_OrgInp", orgInp);

                LocalDB.UpdateData(DS, "КонтрольТКП_Письма", "ID = " + dr["ID"].ToString());

                //Console.WriteLine("Out - " + orgOut["Name_Full"]);
                //Console.WriteLine("Inp - " +  orgOut["Name_Full"]);

                
            }

            System.Windows.Forms.MessageBox.Show("DONE!");

        }

        private static string getDataOrgFromIDOut(string IDOut)
        {

            string sql = "SELECT  TOP 1 DocsOutputRec.ID_Org";
            sql += " FROM DocsOutput INNER JOIN";
            sql += " DocsOutputRec ON DocsOutput.ID_DocOut = DocsOutputRec.ID_DocOut ";
            sql += " WHERE DocsOutput.ID_DocOut = " + IDOut;

            var rs = SSPD.DB.GetFields(sql);

            if (rs != null && rs.Count > 0)
                return rs[0]["ID_Org"].ToString();

            return null;
        }

        private static string getDataOrgFromIDInp(string IDInp)
        {
            string sql = "SELECT  TOP 1 DocsInput.ID_Org";
            sql += " FROM DocsInput";
            sql += " WHERE DocsInput.ID_DocInp = " + IDInp;

            var rs = SSPD.DB.GetFields(sql);

            if (rs != null && rs.Count > 0)
                return rs[0]["ID_Org"].ToString();

            return null;
        }


    }
}
