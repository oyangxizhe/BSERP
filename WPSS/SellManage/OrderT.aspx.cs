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
    public partial class OrderT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        CORDER corder = new CORDER();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        CBOM cbom = new CBOM();
        CMRP cmrp = new CMRP();
        int i;
        protected string M_str_sql = @"
select
A.ORKEY AS 索引,
A.ORID as 订单号,
D.CUSTOMERORID AS 客户订单号,
A.LEADDAYS AS 前置天数,
A.SN as 项次,
A.WareID as 品号,
B.WNAME AS 品名,
B.SPEC as 规格,
B.CO_WAREID AS 料号,
B.CWAREID AS 客户料号,
A.OCount as 订单数量 ,
A.SellUnitPrice as 销售单价 ,
A.CURRENCY AS 币别,
A.TaxRate as 税率,
A.SELLUNITPRICE*A.OCOUNT AS 未税金额,
A.TAXRATE/100*A.SELLUNITPRICE*OCOUNT AS 税额,
A.SELLUNITPRICE*(1+(A.TAXRATE)/100)*OCOUNT AS 含税金额,
A.CuID as 客户ID,
C.CUSTOMER_ID AS 客户代码,
C.CName as 客户名称,
D.ORDERDATE AS 订货日期,
A.DELIVERYDATE AS  交货日期,
D.SALEID AS 业务员工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=D.SALEID ) AS 业务员,
A.LEADDAYS AS 前置天数,
A.NEEDDATE AS 需求日期 ,
A.STOCK_PREPOSITION AS 备料前置,
A.REMARK AS 备注,
E.ADDRESS AS 送货地址,
E.CONTACT AS 联系人,
E.PHONE AS 联系电话  
from Order_DET A 
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN CUSTOMERINFO_MST C ON A.CUID=C.CUID
LEFT JOIN ORDER_MST D ON A.ORID=D.ORID
LEFT JOIN CUSTOMERINFO_DET E ON C.CUKEY=E.CUKEY
";
        string sqlo = @"
INSERT INTO CO_ORDER(
ORKEY,
ORID,
SN,
CRID,
CO_COUNT,
SOURCE_STATUS,
YEAR,
MONTH,
DAY,
DELIVERY_DATE,
GODE_NEED_DATE,
LAST_PICKING_DATE,
LAST_COMPLETE_DATE,
ADVICE_DELIVERY_DATE,
IF_GENERATE_MRP
)
VALUES 
(
@ORKEY,
@ORID,
@SN,
@CRID,
@CO_COUNT,
@SOURCE_STATUS,
@YEAR,
@MONTH,
@DAY,
@DELIVERY_DATE,
@GODE_NEED_DATE,
@LAST_PICKING_DATE,
@LAST_COMPLETE_DATE,
@ADVICE_DELIVERY_DATE,
@IF_GENERATE_MRP
)

";
        private static string _IDO;
        public static string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private static string _ADD_OR_UPDATE;
        public static string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }

        }
        private static int _CIRCULATION_COUNT;
        public static int CIRCULATION_COUNT
        {
            set { _CIRCULATION_COUNT = value; }
            get { return _CIRCULATION_COUNT; }

        }
        private string _CURRENCY;
        public string CURRENCY
        {
            set { _CURRENCY = value; }
            get { return _CURRENCY; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        CCO_ORDER cco_order = new CCO_ORDER();
        string ORKEY, sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";
                CIRCULATION_COUNT = 10;
                if (str1[0] != "")
                {
                    Text1.Value = str1[0];
                    x2.Value = str1[1];
                    str1[0] = "";
                    str1[1] = "";

                }
                else
                {
                    Assignment();

                }
                bind();
                Bind();
            }
            try
            {
              
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
            x1.Value = "";
            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            string sql2 = M_str_sql + " WHERE A.ORID='" + Text1.Value + "' ORDER BY A.ORKEY";
            dt1 = basec.getdts(sql2);
            GridView2.DataSource = dt1;
            GridView2.DataKeyNames = new string[] { "索引" };
            GridView2.DataBind();


            DataTable dtx4 = basec.getdts(@"SELECT ORID,SUM(ocount*sellunitprice),SUM(ocount*sellunitprice*
taxrate/100),SUM(ocount*sellunitprice*(1+taxrate/100)) 
FROM ORDER_DET WHERE ORID='" + Text1.Value + "' GROUP BY ORID ");

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
            string sql3 = @"SELECT DISTINCT(A.WAREID) AS WAREID,B.FLKEY AS FLKEY,B.OLDFILENAME AS OLDFILENAME FROM ORDER_DET A LEFT JOIN WAREFILE B 
            ON A.WAREID=B.WAREID " + " WHERE A.ORID='" + Text1.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
            dt = basec.getdts(sql3);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "FLKEY" };
                GridView3.DataBind();
                x1.Value = Convert.ToString(1);
            }
            else
            {

                GridView3.DataSource = null;
            }

            string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + Text1.Value + "'");
            if (s1=="RECONCILE")
            {
                btnReconcile.Text = "已对帐";
                btnReconcile.Enabled = false;
                btnReductionReconcil.Enabled = true;

            }
            else
            {
                btnReconcile.Text = "确认对帐";
                btnReconcile.Enabled = true;
                btnReductionReconcil.Enabled = false;

            }
            if (!bc.exists("SELECT * FROM AUDIT_JURISDICTION WHERE USID='"+_Default .USID +"' AND BILL_NAME='订单'"))
            {
                btnAudit.Visible = false;
                btnReductionAudit.Visible = false;
                btnAudit.Enabled = false;
                btnReductionAudit.Enabled = false;
            }
            else
            {
                btnAudit.Visible = true;
                btnReductionAudit.Visible = true;

            }
            if (corder.JUAGE_REALTY_IFHAVE_SELLCOUNT(Text1.Value))
            {
                btnAudit.Enabled = false;
                btnReductionAudit.Enabled = false;
            }
            else
            {
                string s2 = bc.getOnlyString("SELECT IF_AUDIT FROM ORDER_MST WHERE ORID='" + Text1.Value + "'");
                if (s2 == "Y")
                {
                    btnAudit.Text = "已审核";
                    btnAudit.Enabled = false;
                    btnReductionAudit.Enabled = true;

                }
                else
                {
                    btnAudit.Text = "审核";
                    btnAudit.Enabled = true;
                    btnReductionAudit.Enabled = false;

                }

            }
          
    
            dt = basec.getdts(M_str_sql + " where A.ORID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["客户ID"].ToString();
                Text3.Value = dt.Rows[0]["订货日期"].ToString();
                Text5.Value = dt.Rows[0]["客户名称"].ToString();
                Text6.Value = dt.Rows[0]["送货地址"].ToString();
                Text10.Value = dt.Rows[0]["业务员工号"].ToString();
                Text4.Value = dt.Rows[0]["联系人"].ToString();
                Text11.Value = dt.Rows[0]["联系电话"].ToString();
                Text12.Value = dt.Rows[0]["客户代码"].ToString();
                Text13.Value = dt.Rows[0]["客户订单号"].ToString();
                string v = bc.getOnlyString("SELECT PUID FROM ORDER_MST WHERE ORID='" + Text1.Value + "' ");
                if (!string.IsNullOrEmpty(v))
                {
                    x2.Value = v;
                }
                Label1.Text = dt.Rows[0]["业务员"].ToString();
            }
            else
            {
               
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text10.Value =varMakerID ;
            Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='"+varMakerID +"'");
           
            }

        }
        #endregion
        #region assignment
        protected void Assignment()
        {
            #region Assignment
            Text1.Value = strE[0];
            strE[0] = "";
 
            #endregion
        }
        #endregion
        protected DataTable dtx()
        {
          
            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("税率", typeof(string));
            dt4.Columns.Add("币别", typeof(string));
            dt4.Columns.Add("交货日期", typeof(string));
            dt4.Columns.Add("前置天数", typeof(string));
            dt4.Columns.Add("需求日期", typeof(string));
            dt4.Columns.Add("备料前置", typeof(string));
            // string sql = "";
            for (i = 1; i <= CIRCULATION_COUNT ; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dr["税率"] = 17;
                dr["币别"] = bc.GET_RMB();
                dr["交货日期"] =DateTime.Now.ToString("yyy-MM-dd");
                dr["前置天数"] = "2";
                dr["需求日期"] = DateTime.Now.ToString("yyy-MM-dd");
                dr["备料前置"] = "4";
                dt4.Rows.Add(dr);
            }
            return dt4;
        }
        protected DataTable dtxo()
        {
            DataTable dtxo = new DataTable();
            dtxo.Columns.Add("C", typeof(string));
            for (int i = 0; i < CIRCULATION_COUNT ; i++)
            {
                DataRow dr = dtxo.NewRow();
                dr["C"] = Convert.ToString(i);
                dtxo.Rows.Add(dr);
            }
            return dtxo;
        }
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text10.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            Label1.Text = "";
        }
        private bool juage()
        {
            bool b = false;
            if (bc.exists("select * from SELLTABLE_DET where ORID='" + Text1.Value + "'"))
            {
                hint.Value = "该订单有了销货单不允许修改！";
                b = true;
            }
            else if (ac1() == 0)
            {
                b = true;
            }
            else if (!ac0(Text1.Value, Text2.Value))
            {
                b = true;
            }
            else if (ORKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                b = true;
            }
            else if (Text2.Value == "")
            {
                hint.Value = "客户ID不能为空！";
                b = true;
            }
            else if (Text10.Value == "")
            {
                hint.Value = "工号不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text10.Value + "'"))
            {
                hint.Value = "业务员工工号不存在于系统中！";
                b = true;
            }
            else if (JUAGE_CURRENCY_IFNO_UNIFICATION())
            {
                b = true;

            }
            return b;
        }
        private void add2()
        {

            int k;
            string w14, GODE_NEED_DATE;
            DateTime w13;
           
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            for (k = 0; k < 10; k++)
            {
                string s1;
                int s2;
                string SN;
                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string OCOUNT = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;/*ocount*/
                string v7 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                string v8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string DELIVERY_DATE = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*delivery_date*/
                string v10 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;/*leaddays*/
                string v11= ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;/*needdate*/
                string v12 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*stock_prepostion*/
                string v13 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                CURRENCY= ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
             
        
                if (v1 != "")
                {
                    w14 = DELIVERY_DATE  + " 00:00:00";
                    w13 = Convert.ToDateTime(w14);
                    int LEADDAYS = Convert.ToInt32(v10);
                    GODE_NEED_DATE = w13.AddDays(-LEADDAYS).ToString("yyyy-MM-dd");
                    string w18=GODE_NEED_DATE +" 00:00:00";
                    DateTime w19=Convert .ToDateTime (w18);/*gode_need_date*/
                    string v20=bc.getOnlyString ("SELECT PRODUCTION_PHASE FROM WAREINFO WHERE WAREID='"+v1+"'");
                    int PRODUCTION_PHASE;
                    if (v20 == "")
                    {
                        PRODUCTION_PHASE = 0;
                    }
                    else
                    {
                         PRODUCTION_PHASE = Convert.ToInt32(v20);
                    }
                    string LAST_PICKING_DATE = w19.AddDays(-PRODUCTION_PHASE).ToString("yyyy-MM-dd");
                    int STOCK_PREPOSTION = Convert.ToInt32(v12);
                    string LAST_COMPLETE_DATE = w13.AddDays(-LEADDAYS  - PRODUCTION_PHASE - STOCK_PREPOSTION).ToString("yyyy-MM-dd");
                    string ADVICE_DELIVERY_DATE =cco_order.GET_ADVICE_DELIVERY_DATE(v1);
                 
                    ORKEY = bc.numYMD(20, 12, "000000000001", "select * from Order_DET", "ORKEY", "OR");
                    /*generate co_order 1/2*/
                  
                    x2.Value = bc.numYM(10, 4, "0001", "SELECT * FROM CO_ORDER", "CRID", "CR");
                    /*generate co_order 1/2*/
                    DataTable dty = bc.getdt("SELECT * FROM ORDER_DET WHERE ORID='" + Text1.Value + "'");
                    if (dty.Rows.Count > 0)
                    {
                        s1 = dty.Rows[dty.Rows.Count - 1]["SN"].ToString();
                        s2 = Convert.ToInt32(s1) + 1;
                    }
                    else
                    {
                        s2 = 1;
                    }
                    SN = Convert.ToString(s2);
                    basec.getcoms(@"INSERT INTO ORDER_DET(ORKEY,ORID,SN,WAREID,OCOUNT,SELLUNITPRICE,TAXRATE,DELIVERYDATE,LEADDAYS,
NEEDDATE,STOCK_PREPOSITION,REMARK,CUID,ORDERSTATUS_DET,YEAR,MONTH,DAY,CURRENCY)  VALUES ('" + ORKEY + "','" + Text1.Value + "','" + SN + "','" + v1 +
                                  "','" + OCOUNT + "','" + v7 + "','" + v8 + "','" + DELIVERY_DATE  + "','" +LEADDAYS+ "','" + GODE_NEED_DATE  + "','" + v12 + 
                                  "','" + v13 + "','" + Text2.Value +
                                  "','OPEN','" + year + "','" + month + "','" + day + "','"+CURRENCY +"')");

                   
                   
                  /*generate co_order 2/2*/

                    SQlcommandE(sqlo, ORKEY, SN, OCOUNT ,DELIVERY_DATE ,GODE_NEED_DATE ,LAST_PICKING_DATE ,LAST_COMPLETE_DATE ,ADVICE_DELIVERY_DATE );
                    /*generate co_order 2/2*/
                          

                }
            }
           if (!bc.exists("SELECT * FROM ORDER_DET WHERE ORID='"+Text1.Value +"'"))
            {
                return;
               
            }
           if (!bc.exists("SELECT ORID FROM Order_MST WHERE ORID='" + Text1.Value + "'"))
           {

               basec.getcoms("INSERT INTO ORDER_MST(ORID,CUID,"
         + "ORDERDATE,SaleID,PUID,ORDERSTATUS_MST,Date,MakerID,Year,Month,Day,CUSTOMERORID,IF_AUDIT) values('" + Text1.Value
         + "','" + Text2.Value + "','" + Text3.Value
         + "','" + Text10.Value + "','"+x2.Value +"','OPEN','" + varDate + "','" + varMakerID + "','" + year + "','" + month +
         "','" + day + "','"+Text13.Value +"','N')");

               IFExecution_SUCCESS = true;

           }
           else
           {
               basec.getcoms("UPDATE ORDER_MST SET CUID='" + Text2.Value + "',ORDERDATE='" + Text3.Value +
                   "',SaleID='" + Text10.Value + "',MAKERID='" + varMakerID + "',DATE='" + varDate +
                   "',CUSTOMERORID='"+Text13 .Value +"' WHERE ORID='" + Text1.Value + "'");
               IFExecution_SUCCESS = true;
           }
            bind();
        }
        #region JUAGE_CURRENCY_IFNO_UNIFICATION()
        private bool JUAGE_CURRENCY_IFNO_UNIFICATION()
        {
            bool b = false;
            for (int k = 0; k < CIRCULATION_COUNT - 1; k++)
            {
                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v12 = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                string v13 = ((TextBox)GridView1.Rows[k + 1].Cells[13].FindControl("TextBox14")).Text;
                if (v1 != "")
                {
                    if (v12 != v13)
                    {
                        b = true;
                        hint.Value = "同个订单里币别不统一！" ;

                        break;
                    }

                }
            }
            return b;
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql,string ORKEY,string SN,string OCOUNT,string DELIVERY_DATE,string GODE_NEED_DATE,
            string LAST_PICKING_DATE,string LAST_COMPLETE_DATE,string ADVICE_DELIVERY_DATE)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@ORKEY", SqlDbType.VarChar, 20).Value = ORKEY;
            sqlcom.Parameters.Add("@ORID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@CRID", SqlDbType.VarChar, 20).Value = x2.Value;
            sqlcom.Parameters.Add("@CO_COUNT", SqlDbType.VarChar, 20).Value = OCOUNT;
            sqlcom.Parameters.Add("@SOURCE_STATUS", SqlDbType.VarChar, 20).Value = "ORDER";
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;

            sqlcom.Parameters.Add("@DELIVERY_DATE", SqlDbType.VarChar, 20).Value = DELIVERY_DATE;
            sqlcom.Parameters.Add("@GODE_NEED_DATE", SqlDbType.VarChar, 20).Value = GODE_NEED_DATE;
            sqlcom.Parameters.Add("@LAST_PICKING_DATE", SqlDbType.VarChar, 20).Value = LAST_PICKING_DATE;
            sqlcom.Parameters.Add("@LAST_COMPLETE_DATE", SqlDbType.VarChar, 20).Value = LAST_COMPLETE_DATE;
            sqlcom.Parameters.Add("@ADVICE_DELIVERY_DATE", SqlDbType.VarChar, 20).Value = ADVICE_DELIVERY_DATE;
            sqlcom.Parameters.Add("@IF_GENERATE_MRP", SqlDbType.VarChar, 20).Value ='N';
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
   
        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM ORDER_DET WHERE ORID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT CUID FROM ORDER_DET WHERE ORID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个订单下面只能出现一个客户代码!";
                    c = false;
                }
            }
            return c;

        }
        #region ac1()
        private int ac1()
        {

            int x = 1;
            for (int k = 0; k < CIRCULATION_COUNT ; k++)
            {

                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v7 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                string v8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                string v10 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                string v11= ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                string v12 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                string v13 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                string v14 = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                //bc.Show(v3 + "," + v4 + "," + v5 + "," + v6 + "," + v7);
                DateTime temp = DateTime.MinValue;
                if (v1 == "")
                {

                }
                else if (!bc.exists("select * from WAREinfo where WAREid='" + v1 + "' AND ACTIVE='Y'"))
                {
                    x = 0;
                    hint.Value = "该品号不存在于系统中或状态不为正常！";
                    break;
                }
          
                else if (v6 == "")
                {

                    x = 0;
                    hint.Value = "订单数量不能为空！";
                    break;
                }
                else if (bc.yesno(v6) == 0)
                {
                    x = 0;
                    hint.Value = "数量只能输入数字！";
                    break;

                }
                else if (v7 == "")
                {
                    x = 0;
                    hint.Value = "销售单价不能为空！";
                    break;

                }
                else if (bc.yesno(v7) == 0)
                {
                    x = 0;
                    hint.Value = "单价只能输入数字！";
                    break;

                }
                else if (v14 == "")
                {
                    x = 0;
                    hint.Value = "币别不能为空！";
                    break;
                }
                else if (!bc.exists("select * from CURRENCY where CURRENCY='" + v14 + "'"))
                {
                    x = 0;
                    hint.Value = "该币别不存在于系统中！";
                    break;
                }
                else if (v8 == "")
                {
                    x = 0;
                    hint.Value = "税率不能为空！";
                    break;

                }
                else if (bc.yesno(v8) == 0)
                {
                    x = 0;
                    hint.Value = "税率只能输入数字！";
                    break;

                }
                else if (v9=="")
                {
                    x = 0;
                    hint.Value = "交货日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v9, out temp))
                {
                    x = 0;
                    hint.Value = "交货日期格式不正确！";
                    break;

                }
                else if (v10 == "")
                {
                    x = 0;
                    hint.Value = "前置天数不能为空！";
                    break;

                }
                else if (bc.yesno(v10)==0)
                {
                    x = 0;
                    hint.Value = "前置天数只能输入数字！";
                    break;

                }
                else if (v12 == "")
                {
                    x = 0;
                    hint.Value = "备料前置天数不能为空！";
                    break;

                }
                else if (bc.yesno(v12) == 0)
                {
                    x = 0;
                    hint.Value = "备料前置天数只能输入数字！";
                    break;

                }
           
            }
            return x;

        }
        #endregion
   
        private bool juage(string s1, string s2, string filed)
        {
            bool a = true;
            string w1 = bc.getOnlyString("select " + filed + " from WAREinfo where WAREid='" + s1 + "'");
            if (!string.IsNullOrEmpty(w1))
            {
                if (w1 != s2)
                {
                    a = false;
                }
            }
            return a;

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
        #region gridview2 delete
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
  
         
           
            try
            {
                if (corder.IFNOALLOW_DELETE_ORID(Text1.Value))
                {
                    hint.Value = corder.ErrowInfo;
                }
                else
                {
                    string[] str = new string[] { "" };
                    string sql1, sql2;
                    hint.Value = "";
                    string id = GridView2.DataKeys[e.RowIndex][0].ToString();
                    str[0] = id;
                    /*PURCHASE first delete purchaseinfo*/
                    sql2 = "DELETE FROM CO_ORDER WHERE ORKEY='" + str[0] + "'";
                    if (bc.exists("SELECT * FROM CO_ORDER WHERE ORKEY='" + id + "' AND SOURCE_STATUS='ORDER'"))
                    {
                        basec.getcoms(sql2);
                        GridView2.EditIndex = -1;
                        bind();
                    }
                    str[0] = "";
                    /*PURCHASE*/
                    sql1 = "DELETE FROM ORDER_DET WHERE ORKEY='" + id + "'";
                    if (bc.exists("select * from SELLTABLE_DET where orid='" + Text1.Value + "'"))
                    {
                        hint.Value = "该订单已经在销货单中存在不允许删除！";
                        return;
                    }
                    else if (bc.juageOne("SELECT * FROM ORDER_DET WHERE ORID='" + Text1.Value + "'"))
                    {

                        basec.getcoms(sql1);
                        sql = "DELETE ORDER_MST WHERE ORID='" + Text1.Value + "'";
                        basec.getcoms(sql);
                        GridView2.EditIndex = -1;
                        bind();

                    }
                    else
                    {

                        basec.getcoms(sql1);
                        GridView2.EditIndex = -1;
                        bind();


                    }

                }

            }
            catch (Exception)
            {


            }
        }
        #endregion
 
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM ORDER_MST", "ORID", "OR");
            x2.Value = bc.numYM(10, 4, "0001", "SELECT * FROM CO_ORDER", "CRID", "CR");
            bind();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            if (corder.IFNOALLOW_DELETE_ORID(Text1.Value))
            {
                hint.Value = corder.ErrowInfo;

            }
            else if (juage())
            {

            }
            else
            {
                add2();
            }
            try
            {
               
               
            }
            catch (Exception)
            {

            }
        }

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SellManage/Order.aspx"+n2);
        }
        protected void btnAudit_Click(object sender, EventArgs e)
        {

            try
            {
                if (juage())
                {

                }
                else
                {
                    Audit();
                }
            }
            catch (Exception)
            {

            }
        }
        protected void Audit()
        {
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            hint.Value = "";
            basec.getcoms("UPDATE ORDER_MST SET IF_AUDIT='Y',AUDIT_MAKERID='"+varMakerID+
                "',AUDIT_DATE='"+varDate +"' WHERE ORID='" + Text1.Value + "'");
            bind();
        }

        protected void btnReductionAudit_Click(object sender, EventArgs e)
        {
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            hint.Value = "";
            try
            {
                if (corder.JUAGE_REALTY_IFHAVE_SELLCOUNT(Text1.Value))
                {

                    hint.Value = "该订单已经有实际销货数量，不能做撤销！";
                }
                else
                {
                    basec.getcoms("UPDATE ORDER_MST SET IF_AUDIT='N',AUDIT_MAKERID='" + varMakerID +
                "',AUDIT_DATE='" + varDate + "' WHERE ORID='" + Text1.Value + "'");
                    bind();
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnReconcile_Click(object sender, EventArgs e)
        {
           
            try
            {
                reconcile();
            }
            catch (Exception)
            {

            }
        }
        protected void reconcile()
        {

            hint.Value = "";
            sql = @"SELECT A.ORID AS ORID,A.SN AS SN,B.WAREID AS WAREID,C.OCOUNT AS OCOUNT,SUM(B.MRCOUNT) AS MRCOUNT FROM SELLTABLE_DET A 
LEFT JOIN MATERE B ON A.SEKEY=B.MRKEY 
LEFT JOIN ORDER_DET C ON C.ORID=A.ORID AND C.SN=A.SN WHERE  A.ORID='" + Text1.Value + "' GROUP BY A.ORID,A.SN,B.WAREID,C.OCOUNT";
            DataTable dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                if (bc.JuageOrderOrPurchaseStatus (Text2 .Value ,0))
                {
                    basec.getcoms("UPDATE ORDER_MST SET ORDERSTATUS_MST='RECONCILE' WHERE ORID='" + Text1.Value + "'");
                    bind();
                }
                else
                {
                    hint.Value = "此订单没有结案，不允许确认对帐!";
                }
               
            }
            else
            {
                hint.Value = "没有此订单的销货记录!";
            }

        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            try
            {
                basec.getcoms("UPDATE ORDER_MST SET ORDERSTATUS_MST='CLOSE' WHERE ORID='" + Text1.Value + "'");
                bind();
            }
            catch (Exception)
            {

            }
        }

        protected void btnOnloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                CFileInfo cf = new CFileInfo();
                cf.OnloadFile(Text1.Value);
                hint.Value = cf.ErrowInfo;
                Bind();
            }
            catch (Exception)
            {

            }
        }
        protected void Bind()
        {
            DataList1.DataSource = dtxo();
            DataList1.DataBind();
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView4.DataSource = dt1;
            GridView4.DataKeyNames = new string[] { "FLKEY" };
            GridView4.DataBind();
        }


        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView4.DataKeys[e.RowIndex][0].ToString();
                string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + id + "'");
                string s1 = Server.MapPath(FilePath);
                if (File.Exists(s1))
                {
                    File.Delete(s1);
                }
                string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + id + "'";
                basec.getcoms(strSql);
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {


            }
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string v1 = GridView4.DataKeys[GridView4.SelectedIndex].Values[0].ToString();
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

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
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

    }
}
