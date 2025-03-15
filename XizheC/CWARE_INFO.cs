using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;

namespace XizheC
{
    public class CWARE_INFO
    {
        basec bc = new basec();
    
        #region nature
        public  string _GETID;
        public  string GETID
        {
            set { _GETID =value ; }
            get { return _GETID; }

        }

        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _CRID;
        public string CRID
        {
            set { _CRID = value; }
            get { return _CRID; }

        }
        private string _WO_COUNT;
        public string WO_COUNT
        {
            set { _WO_COUNT = value; }
            get { return _WO_COUNT; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        #endregion
        #region setsql
        string setsql = @"

SELECT 
A.WAREID AS WAREID,
A.WNAME AS WNAME,
A.CO_WAREID AS CO_WAREID,
A.CWAREID AS CWAREID,
A.SPEC AS SPEC,
A.CUID AS CUID,
CASE WHEN B.CNAME IS NOT NULL THEN B.CNAME 
ELSE D.SNAME 
END
AS CNAME,
A.REMARK AS REMARK,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS MAKER,
SUBSTRING(A.DATE,1,10) AS DATE,
CASE WHEN A.ACTIVE='Y' THEN '正常'
WHEN A.ACTIVE='HOLD' THEN 'HOLD'
ELSE '作废'
END  AS ACTIVE,
A.BOM_UNIT AS BOM_UNIT,
A.BRAND AS BRAND,
A.SKU AS SKU,
A.MPA_UNIT AS MPA_UNIT
FROM  WAREINFO A
LEFT JOIN CUSTOMERINFO_MST B ON A.CUID=B.CUID
LEFT JOIN SUPPLIERINFO_MST D ON A.CUID=D.SUID

";
      
        string setsqlo = @"
SELECT 
A.WAREID AS WAREID,
B.WNAME AS WNAME,
B.CO_WAREID AS CO_WAREID,
B.CWAREID AS CWAREID,
B.SPEC AS SPEC,
C.CUID AS CUID,
C.CNAME AS CNAME,
A.SELLUNITPRICE AS SELLUNITPRICE,
A.CURRENCY AS CURRENCY,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS MAKER,
SUBSTRING(A.DATE,1,10) AS DATE,
B.REMARK AS REMARK,
CASE WHEN B.ACTIVE='Y' THEN '正常'
WHEN B.ACTIVE='HOLD' THEN 'HOLD'
ELSE '作废'
END  AS ACTIVE,
B.BOM_UNIT AS BOM_UNIT,
B.BRAND AS BRAND,
B.SKU AS SKU,
B.MPA_UNIT AS MPA_UNIT
FROM  SELLUNITPRICE A
LEFT JOIN WAREINFO B ON A.WareID =B.WareID 
LEFT JOIN CustomerInfo_MST C ON B.CUID=C.CUID 
";
        /*SNAME TO CNAME FOR SEARCH */string setsqlt = @"
SELECT 
A.WAREID AS WAREID,
B.WNAME AS WNAME,
B.CO_WAREID AS CO_WAREID,
B.CWAREID AS CWAREID,
B.SPEC AS SPEC,
C.SUID AS CUID,
C.SName AS CNAME,   
A.PurchaseUnitPrice AS PURCHASEUNITPRICE,
A.CURRENCY AS CURRENCY,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS MAKER,
SUBSTRING(A.DATE,1,10) AS DATE,
B.REMARK AS REMARK,
CASE WHEN B.ACTIVE='Y' THEN '正常'
WHEN B.ACTIVE='HOLD' THEN 'HOLD'
ELSE '作废'
END  AS ACTIVE,
B.BOM_UNIT AS BOM_UNIT,
B.BRAND AS BRAND,
B.SKU AS SKU,
B.MPA_UNIT AS MPA_UNIT
FROM  PURCHASEUNITPRICE A
LEFT JOIN WAREINFO B ON A.WareID =B.WareID 
LEFT JOIN SUPPLIERInfo_MST C ON A.SUID=C.SUID
";
       
        #endregion
         public CWARE_INFO()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_SCRAP_MST", "WSID", "WS");
            sql = setsql; /*WAREINFO*/
            sqlo = setsqlo; /*ORDER*/
            sqlt = setsqlt; /*PURCHASE*/
        }
     #region GET_MAX_STORAGECOUNT()
     public DataTable GET_MAX_STORAGECOUNT(string SOURCE)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("WAREID", typeof(string));
            dtt.Columns.Add("CO_WAREID", typeof(string));
            dtt.Columns.Add("WNAME", typeof(string));
            dtt.Columns.Add("CWAREID", typeof(string));
            dtt.Columns.Add("SPEC", typeof(string));
            dtt.Columns.Add("CUID", typeof(string));
            dtt.Columns.Add("CNAME", typeof(string));
            /*dtt.Columns.Add("SUID", typeof(string));
            dtt.Columns.Add("SNAME", typeof(string));*/
            dtt.Columns.Add("REMARK", typeof(string));
            dtt.Columns.Add("SELLUNITPRICE", typeof(string));
            dtt.Columns.Add("PURCHASEUNITPRICE", typeof(string));
            dtt.Columns.Add("CURRENCY", typeof(string));
            dtt.Columns.Add("DATE", typeof(string));
            dtt.Columns.Add("MAKER", typeof(string));
            dtt.Columns.Add("ACTIVE", typeof(string));
            dtt.Columns.Add("BRAND", typeof(string));
            dtt.Columns.Add("MPA_UNIT", typeof(string));
            dtt.Columns.Add("SKU", typeof(string));
            dtt.Columns.Add("BOM_UNIT", typeof(string));
            dtt.Columns.Add("STORAGENAME", typeof(string));
            dtt.Columns.Add("STORAGE_LOCATION", typeof(string));
            dtt.Columns.Add("BATCHID", typeof(string));
            dtt.Columns.Add("MAX_STORAGE_COUNT", typeof(string));
            DataTable dtx = new DataTable();
            if (SOURCE == "O")
            {
                dtx = bc.getdt(sqlo);
            }
            else if (SOURCE == "P")
            {
                dtx = bc.getdt(sqlt);
               
            }
            else
            {
                dtx = bc.getdt(sql);
            
            }

            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {

                    DataRow dr = dtt.NewRow();
                    dr["WAREID"] = dr1["WAREID"].ToString();
                    dr["CO_WAREID"] = dr1["CO_WAREID"].ToString();
                    dr["WNAME"] = dr1["WNAME"].ToString();
                    dr["CWAREID"] = dr1["CWAREID"].ToString();
                    dr["SPEC"] = dr1["SPEC"].ToString();

                    if (SOURCE == "O")
                    {
                        dr["SELLUNITPRICE"] = dr1["SELLUNITPRICE"].ToString();
                        dr["CURRENCY"] = dr1["CURRENCY"].ToString();
                    }
                    if (SOURCE == "P")
                    {
                        dr["PURCHASEUNITPRICE"] = dr1["PURCHASEUNITPRICE"].ToString();
                        dr["CURRENCY"] = dr1["CURRENCY"].ToString();
                       
                    }
                    dr["CUID"] = dr1["CUID"].ToString();
                    dr["CNAME"] = dr1["CNAME"].ToString();
                    dr["DATE"] = dr1["DATE"].ToString();
                    dr["MAKER"] = dr1["MAKER"].ToString();
                    dr["ACTIVE"] = dr1["ACTIVE"].ToString();
                    dr["BRAND"] = dr1["BRAND"].ToString();
                    dr["MPA_UNIT"] = dr1["MPA_UNIT"].ToString();
                    dr["SKU"] = dr1["SKU"].ToString();
                    dr["BOM_UNIT"] = dr1["BOM_UNIT"].ToString();

                    /*DataTable dtx1 = bc.getmaxstoragecount(dr1["WAREID"].ToString(), dr1["SKU"].ToString());
                    if (dtx1.Rows.Count > 0)
                    {
                        dr["STORAGENAME"] = dtx1.Rows[0]["仓库"].ToString();
                        dr["STORAGE_LOCATION"] = dtx1.Rows[0]["库位"].ToString();
                        dr["BATCHID"] = dtx1.Rows[0]["批号"].ToString();
                        dr["MAX_STORAGE_COUNT"] = dtx1.Rows[0]["库存数量"].ToString();
                    }*/
                    dtt.Rows.Add(dr);
                }
            }
           
            return dtt;
        }
        #endregion
    }
}
