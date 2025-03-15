using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;


namespace WPSS.BaseInfo
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://../BaseInfo/WebService1.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public WebService1()
        {


        }
        DataTable dt2 = new DataTable();
        [WebMethod]
        public string  GetPurchaseUnitPrice(string WareID,string SUID)
        {
            basec bc = new basec();
            string a = "";
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            string sql = @"SELECT * FROM PURCHASEUNITPRICE WHERE WAREID='"+WareID +"' AND SUID='"+SUID +"'";
            dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {

                a = dt2.Rows[0]["PURCHASEUNITPRICE"].ToString();
                

            }
         
            return a;
        }
        [WebMethod]
        public string[] GetAutoCompleteExtender_Order(string prefixText)
        {
            basec bc = new basec();
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            List<string> list1 = new List<string>();

            string sql = @"SELECT ORID FROM ORDER_MST WHERE ORID LIKE '%" + prefixText + "%'";
            dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    list1.Add(dr["ORID"].ToString());
                  
                }
            }

            return list1.ToArray();
        }
        [WebMethod]
        public string[] GetAutoCompleteExtender_Purchase(string prefixText)
        {
            basec bc = new basec();
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            List<string> list1 = new List<string>();

            string sql = @"SELECT PUID FROM PURCHASE_MST WHERE PUID LIKE '%" + prefixText + "%'";
            dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    list1.Add(dr["PUID"].ToString());

                }
            }

            return list1.ToArray();
        }

    }
}
