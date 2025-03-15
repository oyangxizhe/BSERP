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
using System.IO;
using System.Diagnostics;

namespace WPSS.SellManage
{
    public partial class SellReturnT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        CORDER corder = new CORDER();
        int i;

        string sql = @"
SELECT 
A.SRID AS 销退单号,
A.ORID as 订单号, 
A.SN as 项次,
E.WareID as 品号,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
B.CWAREID AS 客户料号,
B.SPEC as 规格,
C.OCOUNT AS 订单数量,
C.SELLUNITPRICE AS 销售单价,
C.TAXRATE AS 税率,
E.GECount as 销退数量 ,
A.NOTAX_AMOUNT AS 销退未税金额,
A.TAX_AMOUNT AS 销退税额,
A.AMOUNT AS 销退含税金额,
C.CUID as 客户代码,
D.CName as 客户名称 ,
F.SELLRETURN_DATE AS 销退日期,
F.SELLRETURN_ID AS 销退员工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.SELLRETURN_ID )  AS 销退员,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=E.MAKERID )  AS 制单人,
E.DATE AS 制单日期,
A.REMARK AS 备注
from SellReturn_DET A 
LEFT JOIN ORDER_DET C ON A.ORID=C.ORID AND A.SN=C.SN
LEFT JOIN CUSTOMERINFO_MST D ON C.CUID=D.CUID
LEFT JOIN GODE E ON A.SRKEY=E.GEKEY
LEFT JOIN WAREINFO B ON E.WAREID=B.WAREID
LEFT JOIN SellReturn_MST F ON A.SRID=F.SRID
";

        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public static string[] NEWID = new string[] { "", "" };
        public static string[] GETID = new string[] { "" };
        public static string[] str2 = new string[] { "" };
        string SRKEY;
        int j;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if (NEWID[0] != "")
                    {
                        Text1.Value = NEWID[0];
                        NEWID[0] = "";

                    }
                    else
                    {
                        Assignment();

                    }
                    bind();
                }
            }
            catch (Exception)
            {


            }
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        #region bind
        protected void bind()
        {
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }
            x.Value = "";
            x2.Value = "";
            CUKEY.Value = "";
            ControlFileDisplay.Value = "";
            GridView1.DataSource = as1(Text1.Value, Text2.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            string sql1 = sql + " WHERE A.ORID='" + Text2.Value + "' AND A.SRID='" + Text1.Value + "'";
            dt4 = basec.getdts(sql1);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }
            DataTable dtx4 = basec.getdts(@"
SELECT
A.SRID,
SUM(A.NOTAX_AMOUNT),
SUM(A.TAX_AMOUNT),
SUM(A.AMOUNT) FROM SellReturn_DET A 
WHERE A.SRID='" + Text1.Value + "'  GROUP BY A.SRID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][1].ToString();
                string v9 = dtx4.Rows[0][2].ToString();
                string v10 = dtx4.Rows[0][3].ToString();
                Text7.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                Text8.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
                Text9.Value = string.Format("{0:F2}", Convert.ToDouble(v10));
                x.Value = Convert.ToString(1);
            }
            else
            {
                Text7.Value = "";
                Text8.Value = "";
                Text9.Value = "";

            }
            string sql3 = @"
SELECT 
DISTINCT(A.WAREID) AS WAREID,
B.FLKEY AS FLKEY,
B.OLDFILENAME AS OLDFILENAME FROM 
ORDER_DET A 
LEFT JOIN WAREFILE B ON A.WAREID=B.WAREID 
WHERE A.ORID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
            dt = basec.getdts(sql3);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "FLKEY" };
                GridView3.DataBind();
                ControlFileDisplay.Value = Convert.ToString(1);

            }
            else
            {

                GridView3.DataSource = null;
            }
            if (bc.exists("SELECT * FROM ORDER_MST WHERE ORID='" + Text2.Value + "'"))
            {
                x2.Value = "exists";
            }

            dtx3 = basec.getdts(sql + " where A.SRID='" + Text1.Value + "'");
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["销退日期"].ToString();
                Text4.Value = dtx3.Rows[0]["销退员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["销退员"].ToString();

            }
            else
            {

                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
                Text4.Value = varMakerID;
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            }
            btnSure.ForeColor = System.Drawing.Color.Blue;
        }
        #endregion
        #region assignment
        protected void Assignment()
        {
            #region Assignment
            Text1.Value = GETID[0];
            string s = bc.getOnlyString("SELECT ORID FROM SellReturn_DET WHERE SRID='" + GETID[0] + "'");
            GETID[0] = "";
            Text2.Value = s;
            Text5.Value = bc.getOnlyString("SELECT CNAME FROM CUSTOMERINFO_MST A LEFT JOIN ORDER_DET B ON A.CUID=B.CUID WHERE B.ORID='" + s + "'");
            #endregion
        }
        #endregion
        protected void btnSure_Click(object sender, EventArgs e)
        {

            if (!bc.exists("SELECT * FROM ORDER_MST WHERE ORID='" + Text2.Value + "'"))
            {
                hint.Value = "订单号为空或不存在于系统中！";
                return;

            }
            bind();
        }

        #region ask
        private DataTable ask(string v1, string v2)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("订单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("销售单价", typeof(decimal));
            dtt.Columns.Add("税率", typeof(decimal));
            dtt.Columns.Add("订单数量", typeof(decimal));
            dtt.Columns.Add("累计销货数量", typeof(decimal));
            dtt.Columns.Add("累计销退数量", typeof(decimal));
            dtt.Columns.Add("可销退数量", typeof(decimal), "累计销货数量-累计销退数量");
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("库位", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("库存数量", typeof(decimal));
            dtt.Columns.Add("销退数量", typeof(decimal));
            dtt.Columns.Add("本销退单累计销退数量", typeof(decimal));
            dtt.Columns.Add("未税金额", typeof(decimal), "销售单价*销退数量");
            dtt.Columns.Add("税额", typeof(decimal), "销售单价*销退数量*税率/100");
            dtt.Columns.Add("含税金额", typeof(decimal), "销售单价*销退数量*(1+税率/100)");
            dtt.Columns.Add("累计销退未税金额", typeof(decimal));
            dtt.Columns.Add("累计销退税额", typeof(decimal));
            dtt.Columns.Add("累计销退含税金额", typeof(decimal));
            dtt.Columns.Add("可销退未税金额", typeof(decimal), "销售单价*累计销货数量-累计销退未税金额");
            dtt.Columns.Add("可销退税额", typeof(decimal), "销售单价*累计销货数量*税率/100-累计销退税额");
            dtt.Columns.Add("可销退含税金额", typeof(decimal), "销售单价*累计销货数量*(1+税率/100)-累计销退含税金额");
            dtt.Columns.Add("销退未税金额", typeof(decimal));
            dtt.Columns.Add("销退税额", typeof(decimal));
            dtt.Columns.Add("销退含税金额", typeof(decimal));

            DataTable dtx1 = bc.getdt("SELECT * FROM ORDER_DET WHERE ORID='" + v2 + "'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["订单号"] = dtx1.Rows[i]["ORID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["品号"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["订单数量"] = dtx1.Rows[i]["OCOUNT"].ToString();
                    dr["销售单价"] = dtx1.Rows[i]["SELLUNITPRICE"].ToString();
                    dr["税率"] = dtx1.Rows[i]["TAXRATE"].ToString();
                    dr["累计销货数量"] = 0;
                    dr["累计销退数量"] = 0;
                    dr["本销退单累计销退数量"] = 0;
                    dr["累计销退未税金额"] = 0;
                    dr["累计销退税额"] = 0;
                    dr["累计销退含税金额"] = 0;
                    dtt.Rows.Add(dr);
                }

            }
            DataTable dtx4 = bc.getdt(@"
SELECT
A.ORID AS ORID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.MRCOUNT) AS MRCOUNT 
FROM SellTABLE_DET A 
LEFT JOIN MATERE B ON A.SEKEY=B.MRKEY 
WHERE  A.ORID='" + v2 + "' GROUP BY A.ORID,A.SN,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx4.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计销货数量"] = dtx4.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx6 = bc.getdt(@"SELECT A.ORID AS ORID,A.SN AS SN,B.WAREID AS WAREID,SUM(B.GECOUNT) AS GECOUNT FROM SellReturn_DET A 
LEFT JOIN GODE B ON A.SRKEY=B.GEKEY  WHERE  A.ORID='" + v2 + "' GROUP BY A.ORID,A.SN,B.WAREID");
            if (dtx6.Rows.Count > 0)
            {
                for (i = 0; i < dtx6.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx6.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx6.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计销退数量"] = dtx6.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx5 = bc.getdt(@"SELECT A.ORID AS ORID,A.SRID AS SRID,A.SN AS SN,B.WAREID AS WAREID,SUM(B.GECOUNT) AS GECOUNT FROM SellReturn_DET A 
LEFT JOIN  GODE B ON A.SRKEY=B.GEKEY  WHERE  A.ORID='" + v2 + "' AND A.SRID='" + v1 + "' GROUP BY A.ORID,A.SRID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx5.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本销退单累计销退数量"] = dtx5.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx7 = bc.getdt(@"SELECT A.ORID AS ORID,A.SN AS SN,B.WAREID AS WAREID,SUM(A.NOTAX_AMOUNT) AS NOTAX_AMOUNT
,SUM(A.TAX_AMOUNT) AS TAX_AMOUNT,SUM(A.AMOUNT) AS AMOUNT FROM SellReturn_DET A 
LEFT JOIN ORDER_DET B ON A.ORID=B.ORID AND A.SN=B.SN
  WHERE  A.ORID='" + v2 + "' GROUP BY A.ORID,A.SN,B.WAREID");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx7.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计销退未税金额"] = dtx7.Rows[i]["NOTAX_AMOUNT"].ToString();
                            dtt.Rows[j]["累计销退税额"] = dtx7.Rows[i]["TAX_AMOUNT"].ToString();
                            dtt.Rows[j]["累计销退含税金额"] = dtx7.Rows[i]["AMOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            return dtt;

        }
        #endregion
        #region as1
        private DataTable as1(string v1, string v2)
        {
            DataTable dtt = ask(v1, v2);
            for (i = 0; i < dtt.Rows.Count; i++)
            {
                dtt.Rows[i]["销退数量"] = dtt.Rows[i]["可销退数量"].ToString();
                dtt.Rows[i]["销退未税金额"] = dtt.Rows[i]["可销退未税金额"].ToString();
                dtt.Rows[i]["销退税额"] = dtt.Rows[i]["可销退税额"].ToString();
                dtt.Rows[i]["销退含税金额"] = dtt.Rows[i]["可销退含税金额"].ToString();
            }
            return dtt;
        }
        #endregion
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Label1.Text = "";

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            add();

            try
            {
                
            }
            catch (Exception)
            {

            }
        }
        #region add
        protected void add()
        {

            hint.Value = "";
            string sql2 = "SELECT * FROM ORDER_DET WHERE ORID='" + Text2.Value + "'";
            dt1 = basec.getdts(sql2);
            string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + Text2.Value + "'");

            if (dt1.Rows.Count > 0)
            {

                int count = dt1.Rows.Count;

                if (s1 == "RECONCILE")
                {
                    hint.Value = "此销退单对应的订单已经对帐，不允许修改";
                }

                else if (!ac0(Text1.Value, Text2.Value))
                {

                }
                else if (Text2.Value == "")
                {
                    hint.Value = "订单号不能为空！";

                }
                else if (Text4.Value == "")
                {
                    hint.Value = "工号不能为空！";

                }
                else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
                {
                    hint.Value = "销退员工工号不存在于系统中！";

                }
                else if (bc.exists("SELECT * FROM SELLRETURN_MST WHERE SRID='" + Text1.Value + "'"))
                {
                 
                    hint.Value = "此销退单已经存在系统中，不能再保存！";

                }
                else if (SRKEY == "Exceed Limited")
                {
                    hint.Value = "编码超出限制！";

                }

                else
                {
                    add2(count);
                }

            }

        }
        #endregion
        #region add2
        private void add2(int count)
        {

            int k;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            for (k = 0; k < count; k++)
            {
                if (ac1(k) == 0)
                {

                }
                else
                {

                    SRKEY = bc.numYMD(20, 12, "000000000001", "select * from SellReturn_DET", "SRKEY", "SR");
                    string SRCOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox26")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
                    string v1 = ((TextBox)GridView1.Rows[k].Cells[22].FindControl("TextBox23")).Text;
                    string v2 = ((TextBox)GridView1.Rows[k].Cells[23].FindControl("TextBox24")).Text;
                    string v3 = ((TextBox)GridView1.Rows[k].Cells[24].FindControl("TextBox25")).Text;
                    string SKU = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + WAREID + "'");

                    basec.getcoms("INSERT INTO SellReturn_DET(SRKEY,SRID,ORID,SN,REMARK,NOTAX_AMOUNT,TAX_AMOUNT,AMOUNT,"
              + "Year,Month,Day) values('" + SRKEY + "','" + Text1.Value
              + "','" + Text2.Value + "','" + SN + "','" + REMARK + "','" + v1 + "','" + v2 + "','" + v3 + "','" + year + "','" + month + "','" + day + "')");

                    basec.getcoms("INSERT INTO GODE(GEKEY,GODEID,SN,WAREID,"
           + "GECOUNT,STORAGEID,SLID,BATCHID,Date,MakerID,Year,Month,Day,SKU) values('" + SRKEY + "','" + Text1.Value
           + "','" + SN + "','" + WAREID + "','" + SRCOUNT + "','" + STORAGEID + "','"+SLID+"','" + BATCHID + "','" + varDate +
           "','" + varMakerID + "','" + year + "','" + month + "','" + day + "','"+SKU+"')");

                }
               


            }
            /*under FOR OUTSIDE*/
            corder.UPDATE_ORDER_STATUS(Text2.Value);

            if (!bc.exists("SELECT SRID FROM SellReturn_DET WHERE SRID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT SRID FROM SellReturn_MST WHERE SRID='" + Text1.Value + "'"))
            {

                basec.getcoms("INSERT INTO SellReturn_MST(SRID,SELLRETURN_DATE,SELLRETURN_ID,MAKERID,DATE,"
+ "Year,Month,Day) values('" + Text1.Value + "','" + Text3.Value
+ "','" + Text4.Value + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");
                IFExecution_SUCCESS = true;

            }
            else
            {
                basec.getcoms("UPDATE SellReturn_MST SET SELLRETURN_DATE='" + Text3.Value + "',SELLRETURN_ID='" + Text4.Value +
                    "',MAKERID='" + varMakerID + "',DATE='" + varDate + "' WHERE SRID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }

            bind();
        }
        #endregion
        #region ac1()
        private int ac1(int k)
        {
            int x = 1;
            string SRCOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
            string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox26")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
            string NOSRCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            //string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME,"", BATCHID);

            string k2 = ((TextBox)GridView1.Rows[k].Cells[19].FindControl("TextBox20")).Text;
            string k3 = ((TextBox)GridView1.Rows[k].Cells[20].FindControl("TextBox21")).Text;
            string k4 = ((TextBox)GridView1.Rows[k].Cells[21].FindControl("TextBox22")).Text;

            string k5 = ((TextBox)GridView1.Rows[k].Cells[22].FindControl("TextBox23")).Text;
            string k6 = ((TextBox)GridView1.Rows[k].Cells[23].FindControl("TextBox24")).Text;
            string k7 = ((TextBox)GridView1.Rows[k].Cells[24].FindControl("TextBox25")).Text;
            if (SRCOUNT == "")
            {
                x = 0;
                hint.Value = "数量不能为空！";

            }
            else if (bc.yesno(SRCOUNT) == 0)
            {
                x = 0;
                hint.Value = "数量只能输入数字！";


            }
            else if (decimal.Parse(NOSRCOUNT) == 0)
            {

                x = 0;
                hint.Value = "可销退数量为0时不能做销退！";


            }
            else if (decimal.Parse(k2) == 0)
            {

                x = 0;
                hint.Value = "可销退未税金额为0时不能做销退！";


            }
            else if (decimal.Parse(k3) == 0)
            {

                x = 0;
                hint.Value = "可销退税额为0时不能做销退！";


            }
            else if (decimal.Parse(k4) == 0)
            {

                x = 0;
                hint.Value = "可销退含税金额为0时不能做销退！";


            }
            else if (decimal.Parse(k5) > decimal.Parse(k2))
            {
                x = 0;
                hint.Value = "销退未税金额不能大于可销退未税金额！";


            }
            else if (decimal.Parse(k6) > decimal.Parse(k3))
            {
                x = 0;
                hint.Value = "销退税额不能大于可销退税额！";


            }
            else if (decimal.Parse(k7) > decimal.Parse(k4))
            {
                x = 0;
                hint.Value = "销退含税金额不能大于可销退含税金额！";


            }
            else if (STORAGENAME == "")
            {
                x = 0;
                hint.Value = "仓库不能为空！";
            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'"))
            {
                x = 0;
                hint.Value = "该仓库不存在于系统中！";
            }
            else if (STORAGE_LOCATION == "")
            {
                x = 0;
                hint.Value = "库位不能为空！";
            }
            else if (!bc.exists("SELECT * FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'"))
            {
                x = 0;
                hint.Value = "该库位不存在于系统中！";
            }
            else if (BATCHID == "")
            {
                x = 0;
                hint.Value = "批号不能为空！";


            }

            else if (decimal.Parse(SRCOUNT) > decimal.Parse(NOSRCOUNT))
            {
                x = 0;
                hint.Value = "销退数量不能大于可销退数量！";


            }

            return x;

        }
        #endregion

        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM SellReturn_DET WHERE SRID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT ORID FROM SellReturn_DET WHERE SRID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个销退单下面只能出现一个订单号!";
                    c = false;
                }
            }
            return c;

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }
        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string v1 = GridView3.DataKeys[GridView3.SelectedIndex].Values[0].ToString();
                string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + v1 + "'");
                FileInfo file = new FileInfo(Server.MapPath(FilePath));
                if (file.Exists)
                {
                    Response.Clear();
                    string fileName = HttpUtility.UrlEncode(file.Name);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    //Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream;charset=gb2312";
                    Response.Filter.Close();
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM SellReturn_MST", "SRID", "SR");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SellManage/SellReturn.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM SellReturn_MST WHERE SRID='" + Text1.Value + "'";
                sql3 = "DELETE FROM SellReturn_DET WHERE SRID='" + Text1.Value + "' AND SN='" + ID + "'";
                string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + Text2.Value + "'");
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此销退单对应的订单已经对帐，不允许删除";

                }
                else
                {
                    
                    basec.getcoms(sql3);
                    basec.getcoms("DELETE  GODE WHERE GODEID='" + Text1.Value + "' AND SN='" + ID + "'");
                    if (!bc.exists("SELECT * FROM SellReturn_DET WHERE SRID='" + Text1.Value + "'"))
                    {
                        basec.getcoms(sql2);
                    }
                    corder.UPDATE_ORDER_STATUS(Text2.Value);
                    GridView1.EditIndex = -1;
                    bind();

                }

            }
            catch (Exception)
            {


            }
        }
        #endregion

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }

        protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色 
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C9D3E2',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
                e.Row.Attributes["style"] = "Cursor:pointer";
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            string vard1 = Text1.Value;
            String[] Carstr = new string[] { vard1 };
            //WPSS.ReportManage.CRVSellReturn .Array [0]= Carstr[0];
            Response.Redirect("../ReportManage/CRVSellReturn.aspx");
        }
        protected void excelprint()
        {

            DataTable dtn = bc.asko(" WHERE A.SRID='" + Text1.Value + "'", 2);
            if (dtn.Rows.Count > 0)
            {
                string v1 = Server.MapPath("../PrintModelForSellReturn.xls");
                if (File.Exists(v1))
                {
                    bc.ExcelPrint(dtn, "销退单", v1);

                }
                else
                {


                    hint.Value = "指定路径不存在打印模版！";

                }
            }
            else
            {


                hint.Value = "无数据可打印！";

            }
            try
            {


            }
            catch (Exception)
            {


            }

        }


    }
}
