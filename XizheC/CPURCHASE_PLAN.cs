﻿
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop;
using System.Security.Cryptography;

namespace XizheC
{
    public class CPURCHASE_PLAN
    {
        basec bc = new basec();
        #region nature
        public string _GETID;
        public string GETID
        {
            set { _GETID = value; }
            get { return _GETID; }

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
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _CO_COUNT;
        public string CO_COUNT
        {
            set { _CO_COUNT = value; }
            get { return _CO_COUNT; }

        }
        private string _WO_COUNT;
        public string WO_COUNT
        {
            set { _WO_COUNT = value; }
            get { return _WO_COUNT; }

        }
        private string _STORAGE_COUNT;
        public string STORAGE_COUNT
        {
            set { _STORAGE_COUNT = value; }
            get { return _STORAGE_COUNT; }

        }
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _PLID;
        public string PLID
        {
            set { _PLID = value; }
            get { return _PLID; }

        }
        private decimal  _PURCHASE_PLANUNITPRICE;
        public  decimal  PURCHASE_PLANUNITPRICE
        {
            set { _PURCHASE_PLANUNITPRICE = value; }
            get { return _PURCHASE_PLANUNITPRICE; }

        }
        private string _P_COUNT;
        public string P_COUNT
        {
            set { _P_COUNT = value; }
            get { return _P_COUNT; }

        }
        private string _XID;
        public string XID
        {
            set { _XID = value; }
            get { return _XID; }
        }
        private string _SUID;
        public string SUID
        {
            set { _SUID = value; }
            get { return _SUID; }
        }
        private string _NEEDDATE;
        public string NEEDDATE
        {
            set { _NEEDDATE = value; }
            get { return _NEEDDATE; }

        }
        #endregion
        string KEY;
        string setsql = @"
SELECT 
A.PLID AS PLID,
B.SUID AS SUID,
B.SNAME AS SNAME,
A.PDATE AS PDATE,
C.WAREID AS WAREID,
CASE WHEN A.IF_AUDIT='Y' THEN '已审核'
ELSE '未审核'
END
AS IF_AUDIT,
CASE WHEN A.PURCHASE_PLANSTATUS_MST='CLOSE' THEN '已入库'
WHEN A.PURCHASE_PLANSTATUS_MST='PROGRESS' THEN '部分入库'
WHEN A.PURCHASE_PLANSTATUS_MST='DELAY' THEN 'DELAY'
ELSE 'OPEN'
END  AS PURCHASE_PLANSTATUS_MST,
C.NEEDDATE AS NEEDDATE,
E.CNAME AS CNAME,
D.WNAME AS WNAME,
D.CWAREID AS CWAREID,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.PURID ) AS PUR,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER,
A.DATE AS DATE FROM PURCHASE_PLAN_MST A  
LEFT JOIN SUPPLIERINFO_MST B ON A.SUID=B.SUID
LEFT JOIN PURCHASE_PLAN_DET C ON A.PLID =C.PLID 
LEFT JOIN WAREINFO D ON C.WAREID =D.WAREID 
LEFT JOIN CUSTOMERINFO_MST E ON D.CUID =E.CUID
";
        string setsqlo = @"
INSERT INTO PURCHASE_PLAN_DET(
PLKEY,
PLID,
SN,
WAREID,
PCOUNT,
PURCHASEUNITPRICE,
CURRENCY,
TAXRATE,
SUID,
NEEDDATE,
PURCHASESTATUS_DET,
MPA_UNIT,
MPA_TO_STOCK,
STOCK_TO_BOM,
SKU,
BOM_UNIT,
REMARK,
YEAR,
MONTH,
DAY
) 
VALUES 
(
@PLKEY,
@PLID,
@SN,
@WAREID,
@PCOUNT,
@PURCHASEUNITPRICE,
@CURRENCY,
@TAXRATE,
@SUID,
@NEEDDATE,
@PURCHASESTATUS_DET,
@MPA_UNIT,
@MPA_TO_STOCK,
@STOCK_TO_BOM,
@SKU,
@BOM_UNIT,
@REMARK,
@YEAR,
@MONTH,
@DAY
)
";

        string setsqlt = @"
INSERT INTO PURCHASE_PLAN_MST
(
PLID,
SUID,
PDATE,
PURID,
SOURCESTATUS,
PURCHASESTATUS_MST,
RDID,
COKEY,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@PLID,
@SUID,
@PDATE,
@PURID,
@SOURCESTATUS,
@PURCHASESTATUS_MST,
@RDID,
@COKEY,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
SELECT  
B.COKEY AS COKEY,
A.COID AS COID,
A.CONAME AS CONAME,
B.PHONE AS PHONE,
B.FAX AS FAX,
B.EMAIL AS MAIL,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID )  AS MAKER,
A.DATE AS DATE,
B.ADDRESS AS ADDRESS,
B.CONTACT AS CONTACT
 FROM 
COMPANYINFO_MST A 
LEFT JOIN COMPANYINFO_DET B ON A.COKEY=B.COKEY
";
        string setsqlf = @"
SELECT 
C.SName AS 供应商,
A.PLKEY AS 索引,
A.PLID AS 采购计划批号,
A.SN AS 项次,
A.WAREID AS 品号,
B.WNAME AS 品名,
B.CO_WAREID AS 料号,
B.MPA AS 最小采购量,
B.CWAREID AS 客户料号,
B.SPEC AS 规格,
B.BRAND AS 品牌,
B.MPA_UNIT AS 采购单位,
A.PCOUNT AS 采购数量,
A.CURRENCY AS 币别,
A.TAXRATE AS 税率,
A.NEEDDATE AS 需求日期,
A.REMARK AS 备注
FROM PURCHASE_PLAN_DET A 
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID 
LEFT JOIN SUPPLIERINFO_MST C ON B.CUID=C.SUID ORDER BY C.SUID ASC

";
        DataTable dtx2 = new DataTable();
        DataTable dt4 = new DataTable();
        int i, j;
        public CPURCHASE_PLAN()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            GETID = bc.numYM(10, 4, "0001", "SELECT * FROM PURCHASE_PLAN_MST", "PLID", "PL");
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
        }
        public void save(DataTable dt)
        {

            SQlcommandE(dt, sqlo);
            SQlcommandEo(dt, sqlt);
        }
        #region SQlcommandE
        protected void SQlcommandE(DataTable dt, string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string CURRENCY = bc.GET_RMB();
            i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (decimal.Parse(dr["采购单位量"].ToString()) > 0 && dr["客供否"].ToString() == "N")
                {
                KEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM PURCHASE_PLAN_DET", "PLKEY", "PL");
                SqlConnection sqlcon = bc.getcon();
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                sqlcom.Parameters.Add("@PLKEY", SqlDbType.VarChar, 20).Value = KEY;
                sqlcom.Parameters.Add("@PLID", SqlDbType.VarChar, 20).Value = GETID;
                sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = i + 1;
                sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = dr["子ID"].ToString();
                sqlcom.Parameters.Add("@PCOUNT", SqlDbType.VarChar, 20).Value = dr["采购单位量"].ToString();
                sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = "";
                sqlcom.Parameters.Add("@PURCHASEUNITPRICE", SqlDbType.VarChar, 20).Value = DBNull.Value;
                sqlcom.Parameters.Add("@CURRENCY", SqlDbType.VarChar, 20).Value = CURRENCY;
                sqlcom.Parameters.Add("@TAXRATE", SqlDbType.VarChar, 20).Value = "17";
                sqlcom.Parameters.Add("@NEEDDATE", SqlDbType.VarChar, 20).Value = NEEDDATE;
                sqlcom.Parameters.Add("@PURCHASESTATUS_DET", SqlDbType.VarChar, 20).Value = "OPEN";
                DataTable dt2 = bc.getdt("SELECT * FROM WAREINFO WHERE WAREID='" + dr["子ID"].ToString() + "'");
                if (dt2.Rows.Count > 0)
                {
                    sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["MPA_UNIT"].ToString();
                    sqlcom.Parameters.Add("@MPA_TO_STOCK", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["MPA_TO_STOCK"].ToString();
                    sqlcom.Parameters.Add("@STOCK_TO_BOM", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["STOCK_TO_BOM"].ToString();
                    sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["SKU"].ToString();
                    sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["BOM_UNIT"].ToString();
                }
                sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = "如有工程费用均分摊在单价中";
                sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
                sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
                sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;

                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                }
                i = i + 1;
            }
        }
        #endregion
        #region SQlcommandEo
        protected void SQlcommandEo(DataTable dt, string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@PLID", SqlDbType.VarChar, 20).Value = GETID;
            sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@PDATE", SqlDbType.VarChar, 20).Value = DateTime.Now.ToString("yyyy-MM-dd");
            sqlcom.Parameters.Add("@SOURCESTATUS", SqlDbType.VarChar, 20).Value = "MRP";
            sqlcom.Parameters.Add("@PURID", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@PURCHASESTATUS_MST", SqlDbType.VarChar, 24).Value = "OPEN";
            DataTable dt7 = basec.getdts("SELECT * FROM RECEIVINGANDDELIVERY WHERE STATUS='Y'");
            if (dt7.Rows.Count > 0)
            {
                sqlcom.Parameters.Add("@RDID", SqlDbType.VarChar, 20).Value = dt7.Rows[0]["RDID"].ToString();

            }
            else
            {
                sqlcom.Parameters.Add("@RDID", SqlDbType.VarChar, 20).Value = null;
            }
            DataTable dt8 = bc.getdt(sqlth);
            if (dt8.Rows.Count > 0)
            {
                sqlcom.Parameters.Add("@COKEY", SqlDbType.VarChar, 20).Value = dt8.Rows[0]["COKEY"].ToString();

            }
            else
            {
                sqlcom.Parameters.Add("@COKEY", SqlDbType.VarChar, 20).Value = null;
            }
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

        #region GET_TOTAL_PURCHASE_PLAN
        public DataTable GET_TOTAL_PURCHASE_PLAN()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("采购单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("采购数量", typeof(decimal));
            dtt.Columns.Add("采购单位", typeof(string));
            dtt.Columns.Add("采购库存换算", typeof(decimal));
            dtt.Columns.Add("采购折合库存", typeof(decimal), "采购数量*采购库存换算");
            dtt.Columns.Add("库存单位", typeof(string));
            dtt.Columns.Add("累计采购入库数量P", typeof(decimal));
            dtt.Columns.Add("累计采购入库数量S", typeof(decimal));
            dtt.Columns.Add("累计退货数量P", typeof(decimal));
            dtt.Columns.Add("累计退货数量S", typeof(decimal));
            dtt.Columns.Add("采购未结数量P", typeof(decimal), "采购数量-累计采购入库数量P+累计退货数量P");
            dtt.Columns.Add("采购未结数量S", typeof(decimal), "采购数量*采购库存换算-累计采购入库数量S+累计退货数量S");
            dtt.Columns.Add("状态", typeof(string));
            dtt.Columns.Add("需求日期", typeof(string));
            DataTable dtx1 = bc.getdt("SELECT * FROM PURCHASE_PLAN_DET");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["采购单号"] = dtx1.Rows[i]["PLID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["ID"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("SELECT * FROM WAREINFO WHERE WAREID='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["采购数量"] = dtx1.Rows[i]["PCOUNT"].ToString();
                    dr["采购单位"] = dtx1.Rows[i]["MPA_UNIT"].ToString();
                    dr["库存单位"] = dtx1.Rows[i]["SKU"].ToString();
                    dr["采购库存换算"] = dtx1.Rows[i]["MPA_TO_STOCK"].ToString();
                    dr["累计采购入库数量P"] = 0;
                    dr["累计采购入库数量S"] = 0;
                    dr["累计退货数量P"] = 0;
                    dr["累计退货数量S"] = 0;
                    dr["需求日期"] = dtx1.Rows[i]["NEEDDATE"].ToString();
                    if (dtx1.Rows[i]["PURCHASE_PLANSTATUS_DET"].ToString() == "OPEN")
                    {
                        dr["状态"] = "OPEN";
                    }
                    else if (dtx1.Rows[i]["PURCHASE_PLANSTATUS_DET"].ToString() == "PROGRESS")
                    {
                        dr["状态"] = "部分入库";
                    }
                    else if (dtx1.Rows[i]["PURCHASE_PLANSTATUS_DET"].ToString() == "DELAY")
                    {
                        dr["状态"] = "DELAY";
                    }
                    else
                    {
                        dr["状态"] = "已入库";
                    }
                    dtt.Rows.Add(dr);
                }
            }

            DataTable dtx4 = bc.getdt(@"
SELECT 
A.PLID AS PLID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.P_GECOUNT) AS P_GECOUNT,
SUM(B.GECOUNT) AS GECOUNT
FROM PURCHASE_PLANGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY
GROUP BY
A.PLID,
A.SN,
B.WAREID
");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx4.Rows[i]["PLID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计采购入库数量P"] = dtx4.Rows[i]["P_GECOUNT"].ToString();
                            dtt.Rows[j]["累计采购入库数量S"] = dtx4.Rows[i]["GECOUNT"].ToString();
                            break;
                        }
                    }
                }
            }
            DataTable dtx6 = bc.getdt(@"
SELECT 
A.PLID AS PLID,
A.SN AS SN,
B.WAREID AS WAREID,
CASE WHEN SUM(B.P_MRCount) IS NULL THEN 0
ELSE SUM(B.P_MRCount)
END
AS P_MRCOUNT,
CASE WHEN SUM(B.MRCount) IS NULL THEN 0
ELSE SUM(B.MRCount)
END
AS MRCOUNT
FROM RETURN_DET A 
LEFT JOIN MateRe  B ON A.REKEY=B.MRKEY
LEFT JOIN PURCHASE_PLAN_DET D ON D.PLID=A.PLID AND D.SN=A.SN 
GROUP BY 
A.PLID,
A.SN,
B.WAREID
");/*NORMAL P_MRCOUNT NOT NULL ,BUT DB EDIT*/
            if (dtx6.Rows.Count > 0)
            {
                for (i = 0; i < dtx6.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx6.Rows[i]["PLID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx6.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计退货数量P"] = dtx6.Rows[i]["P_MRCOUNT"].ToString();
                            dtt.Rows[j]["累计退货数量S"] = dtx6.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }
                    }
                }
            }
            return dtt;
        }
        #endregion

   
    }
}
