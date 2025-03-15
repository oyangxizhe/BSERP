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
using System.Text.RegularExpressions;

namespace WPSS.PurchaseManage
{
    public partial class PurchaseT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        basec bc = new basec();
        PrintPurchaseBill print = new PrintPurchaseBill();
        CPURCHASE cpurchase = new CPURCHASE();
        WPSS.Validate va = new Validate();
        int i;
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }

        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        string PUKEY, sql;
        #region nature
        private string _MPA_UNIT;
        public string MPA_UNIT
        {
            set { _MPA_UNIT = value; }
            get { return _MPA_UNIT; }

        }
        private string _SKU;
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private string _CURRENCY;
        public string CURRENCY
        {
            set { _CURRENCY = value; }
            get { return _CURRENCY; }

        }
        private string _BOM_UNIT;
        public string BOM_UNIT
        {
            set { _BOM_UNIT = value; }
            get { return _BOM_UNIT; }

        }
        private string _MPA_TO_STOCK;
        public string MPA_TO_STOCK
        {
            set { _MPA_TO_STOCK = value; }
            get { return _MPA_TO_STOCK; }

        }
        private string _STOCK_TO_BOM;
        public string STOCK_TO_BOM
        {
            set { _STOCK_TO_BOM = value; }
            get { return _STOCK_TO_BOM; }

        }
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
        private static int  _CIRCULATION_COUNT;
        public static int  CIRCULATION_COUNT
        {
            set { _CIRCULATION_COUNT = value; }
            get { return _CIRCULATION_COUNT; }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CIRCULATION_COUNT = 10;
                Text1.Value = IDO;
                bind();

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
            RDID.Value = "";
            COKEY.Value = "";
            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();
            dt1 = print.ask(Text1.Value);
            GridView2.DataSource = dt1;
            GridView2.DataKeyNames = new string[] { "索引" };
            GridView2.DataBind();

            DataTable dtx4 = print.asktotal(Text1.Value);
            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[dtx4.Rows.Count - 1]["未税金额"].ToString();
                string v9 = dtx4.Rows[dtx4.Rows.Count - 1]["税额"].ToString();
                string v10 = dtx4.Rows[dtx4.Rows.Count - 1]["含税金额"].ToString();
                if (!string.IsNullOrEmpty(v9))
                {
                    Text7.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                    Text8.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
                    Text9.Value = string.Format("{0:F2}", Convert.ToDouble(v10));
                }
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
B.OLDFILENAME AS OLDFILENAME 
FROM PURCHASE_DET A LEFT JOIN WAREFILE B 
ON A.WAREID=B.WAREID " + " WHERE A.PUID='" + Text1.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
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
            string s1 = bc.getOnlyString("SELECT PURCHASESTATUS_MST FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'");
            if (s1 == "RECONCILE")
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
            if (!bc.exists("SELECT * FROM AUDIT_JURISDICTION WHERE USID='" + _Default.USID + "' AND BILL_NAME='采购单'"))
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
            if (cpurchase .JUAGE_REALTY_IFHAVE_PURCHASE_GODE_COUNT(Text1.Value))
            {
                btnAudit.Enabled = false;
                btnReductionAudit.Enabled = false;
            }
            else
            {
                string s2 = bc.getOnlyString("SELECT IF_AUDIT FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'");
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
            dt = print.asktotal(Text1.Value);
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["供应商代码"].ToString();
                if (string.IsNullOrEmpty(dt.Rows[0]["供应商代码"].ToString()))
                {
                    currentdate();
                }
                else
                {
                    Text3.Value = dt.Rows[0]["采购日期"].ToString();
                    Text4.Value = dt.Rows[0]["采购员工号"].ToString();
                    Label1.Text = dt.Rows[0]["采购员姓名"].ToString();
                }
                Text5.Value = dt.Rows[0]["供应商名称"].ToString();
                Text6.Value = dt.Rows[0]["地址"].ToString();

                Text10.Value = dt.Rows[0]["联系人"].ToString();
                Text11.Value = dt.Rows[0]["电话"].ToString();
                if (dt.Rows[0]["收货人"].ToString() == "")
                {
                    contactinfo();
                }
                else
                {
                    Text12.Value = dt.Rows[0]["收货人"].ToString();
                    Text13.Value = dt.Rows[0]["收货地址"].ToString();
                    Text14.Value = dt.Rows[0]["公司名称"].ToString();
                    Text15.Value = dt.Rows[0]["公司联系人"].ToString();
                    Text16.Value = dt.Rows[0]["公司电话"].ToString();
                    RDID.Value = dt.Rows[0]["RDID"].ToString();
                    COKEY.Value = dt.Rows[0]["COKEY"].ToString();

                }

            }
            else
            {
                contactinfo();
                currentdate();
            }

        }
        #endregion

        protected void contactinfo()
        {
            dt7 = basec.getdts("SELECT * FROM RECEIVINGANDDELIVERY WHERE STATUS='Y'");
            if (dt7.Rows.Count > 0)
            {
                Text12.Value = dt7.Rows[0]["CONTACT"].ToString();
                Text13.Value = dt7.Rows[0]["ADDRESS"].ToString();
                RDID.Value = dt7.Rows[0]["RDID"].ToString();

            }

            dt8 = bc.getdt(cpurchase .sqlth);
            if (dt8.Rows.Count > 0)
            {
                Text14.Value = dt8.Rows[0]["CONAME"].ToString();
                Text15.Value = dt8.Rows[0]["CONTACT"].ToString();
                Text16.Value = dt8.Rows[0]["PHONE"].ToString();
                COKEY.Value = dt8.Rows[0]["COKEY"].ToString();

            }
        }
        protected void currentdate()
        {

            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
            Text4.Value = varMakerID;
            Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");

        }
        #region dtx
        protected DataTable dtx()
        {

            DataTable dtt = new DataTable();
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("品牌", typeof(string));
            dtt.Columns.Add("采购单位", typeof(string));
            dtt.Columns.Add("采购单价", typeof(string));
            dtt.Columns.Add("采购数量", typeof(string));
            dtt.Columns.Add("币别", typeof(string));
            dtt.Columns.Add("税率", typeof(string));
            dtt.Columns.Add("需求日期", typeof(string));
            dtt.Columns.Add("备注", typeof(string));
            string v11 = bc.getOnlyString("SELECT SOURCESTATUS FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'");
            if (!string.IsNullOrEmpty(v11))
            {

                dtt = basec.getdts(@"
SELECT 
A.SN AS 项次,
A.WAREID AS 品号,
B.WNAME AS 品名,
B.CO_WAREID AS 料号,
B.CWAREID AS 客户料号,
B.SPEC AS 规格,
B.BRAND AS 品牌,
A.MPA_UNIT AS 采购单位,
A.PCOUNT AS 采购数量,
A.PURCHASEUNITPRICE AS 采购单价,
A.CURRENCY AS 币别,
A.TAXRATE AS 税率,
A.NEEDDATE AS 需求日期,
A.REMARK AS 备注 
FROM PURCHASE_DET A 
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID 
WHERE A.PUID='" + Text1.Value + "'");
                if (dtt.Rows.Count > 0)
                {
                    CIRCULATION_COUNT = dtt.Rows.Count;
                }

            }
            else
            {
                for (i = 1; i <= CIRCULATION_COUNT; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["项次"] = i;
                    dr["税率"] = 17;
                    dr["币别"] = bc.GET_RMB();
                    dr["需求日期"] = DateTime.Now.ToString("yyy-MM-dd");
                    dr["备注"] = "如有工程费用均分摊在单价中";
                    dtt.Rows.Add(dr);

                }

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
            Text6.Value = "";
            Text7.Value = "";
            Text8.Value = "";
            Text9.Value = "";
            Text10.Value = "";
            Text11.Value = "";
            Text12.Value = "";
            Text13.Value = "";
            Label1.Text = "";

        }
        private bool juage()
        {
            bool b = false;
            if (bc.exists("select * from purchasegode_DET where PUID='" + Text1.Value + "'"))
            {

                hint.Value = "该采购单有了采购入库单不允许修改！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='" + Text2.Value + "'"))
            {
                hint.Value = "供应商代码不存在于系统中！";
                b = true;
            }
            else if (Text4.Value == "")
            {
                hint.Value = "工号不能为空！";
                b = true;
            }
            else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
            {
                hint.Value = "员工工号不存在于系统中！";
                b = true;
            }
            else if (Text12.Value == "")
            {
                hint.Value = "收货人不能为空！";
                b = true;
            }
            else if (Text15.Value == "")
            {
                hint.Value = "公司联系人不能为空！";
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

            else if (PUKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                b = true;
            }
            else if (JUAGE_CURRENCY_IFNO_UNIFICATION())
            {
                b = true;

            }
            return b;
        }
        #region add2()
        private void add2()
        {

            int k;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            for (k = 0; k < CIRCULATION_COUNT ; k++)
            {
                string s1;
                int s2;
                string SN;
                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v7 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                string v8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                MPA_UNIT = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                CURRENCY = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                if (v1 != "")
                {

                    PUKEY = bc.numYMD(20, 12, "000000000001", "select * from PURCHASE_DET", "PUKEY", "PU");
                    DataTable dty = bc.getdt("SELECT * FROM PURCHASE_DET WHERE PUID='" + Text1.Value + "'");
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
                    dt = bc.getdt("SELECT * FROM WAREINFO WHERE WAREID='" +v1 + "'");
                    if (dt.Rows.Count > 0)
                    {
                        MPA_TO_STOCK = dt.Rows[0]["MPA_TO_STOCK"].ToString();
                        STOCK_TO_BOM = dt.Rows[0]["STOCK_TO_BOM"].ToString();
                        SKU = dt.Rows[0]["SKU"].ToString();
                        BOM_UNIT = dt.Rows[0]["BOM_UNIT"].ToString();
                    }
                    basec.getcoms(@"INSERT INTO PURCHASE_DET(PUKEY,PUID,SN,WAREID,PCOUNT,PurchaseUNITPRICE,
           TAXRATE,SUID,NEEDDATE,PURCHASESTATUS_DET,REMARK,YEAR,MONTH,DAY,MPA_UNIT,MPA_TO_STOCK,STOCK_TO_BOM,SKU,BOM_UNIT,CURRENCY) 
                                 VALUES ('" + PUKEY + "','" + Text1.Value + "','" + SN + "','" + v1 + "','" + v5 +
                                  "','" + v6 + "','" + v7 + "','" + Text2.Value + "','" + v8 + "','OPEN','" + v9 +
                                  "','" + year + "','" + month + "','" + day + 
                                  "','"+MPA_UNIT +"','"+MPA_TO_STOCK +"','"+STOCK_TO_BOM +"','"+SKU +"','"+BOM_UNIT +"','"+CURRENCY +"')");
                }
            }
            if (!bc.exists("SELECT * FROM PURCHASE_DET WHERE PUID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT PUID FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'"))
            {

                basec.getcoms("INSERT INTO PURCHASE_MST(PUID,SUID,"
          + "PDATE,PURID,PURCHASESTATUS_MST,Date,RDID,MakerID,Year,Month,Day,COKEY,IF_AUDIT) values('" + Text1.Value
          + "','" + Text2.Value + "','" + Text3.Value + "','" + Text4.Value + "','OPEN','" + varDate + "','" + RDID.Value + "','" + varMakerID +
          "','" + year + "','" + month + "','" + day + "','" + COKEY.Value + "','N')");
                IFExecution_SUCCESS = true;

            }
            else
            {
                basec.getcoms("UPDATE PURCHASE_MST SET SUID='" + Text2.Value + "',PDATE='" + Text3.Value +
                    "',PURID='" + Text4.Value + "',RDID='" + RDID.Value + "',MAKERID='" + varMakerID +
                    "',DATE='" + varDate + "',COKEY='" + COKEY.Value + "' WHERE PUID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }
            bind();
        }
        #endregion

        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM PURCHASE_DET WHERE PUID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT SUID FROM PURCHASE_DET WHERE PUID='" + s1 + "'");
                if (!string.IsNullOrEmpty (s3) && s3  != s2)
                {
                    hint.Value = "同一个采购单下面只能出现一个供应商代码!";
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
                string v9 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                string v12 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                string v13 = bc.getOnlyString("SELECT MPA FROM WAREINFO WHERE WAREID='"+v1+"'");
                DateTime temp = DateTime.MinValue;
                decimal d1 = 0, d2 = 0,d3 = 0;
                string v14 = "";
                if (v5 != "" && v13 != "")
                {
                    d1 = decimal.Parse(v5);
                    d2 = decimal.Parse(v13);
                    d3 = d1 / d2;
                    v14 = d3.ToString("0");
                }
                //bc.Show(v3 + "," + v4 + "," + v5 + "," + v6 + "," + v7);
                if (v1 == "")
                {

                }
                else if (!bc.exists("select * from WAREinfo where WAREid='" + v1 + "' AND ACTIVE='Y'"))
                {
                    x = 0;
                    hint.Value = "该品号不存在于系统中或状态不为正常！";
                    break;
                }
                else if (v5 == "")
                {

                    x = 0;
                    hint.Value = "采购数量不能为空！";
                    break;
                }
                else if (bc.yesno(v5) == 0)
                {
                    x = 0;
                    hint.Value = "数量只能输入数字！";
                    break;

                }
                else if (string.IsNullOrEmpty(v13))
                {
                    x = 0;
                    hint.Value = "原物料编码为：" + v2 + " 的最小采购量不能为空！";
                    break;
                }
                else if (d1 < d2)
                {
                    x = 0;
                    hint.Value = "原物料编码为：" + v2 + " 的最小采购量为：" + v13 + " 采购数量需大于最小采购量！";
                    break;

                }
                else if (Regex.IsMatch(v14, "^\\d+$") == false)
                {
                    x = 0;
                    hint.Value = "原物料编码为：" + v2 + " 的最小采购量为：" + v13 + " 采购数量需为最小采购量的整数倍！";
                    break;

                }
                else if (v9 == "")
                {
                    x = 0;
                    hint.Value = "采购单位不能为空！";
                    break;
                }
                else if (!bc.exists("select * from UNIT where UNIT='" + v9 + "'"))
                {
                    x = 0;
                    hint.Value = "该采购单位不存在于系统中！";
                    break;
                }
                else if (v6 == "")
                {
                    x = 0;
                    hint.Value = "采购单价不能为空！";
                    break;

                }
                else if (bc.yesno(v6) == 0)
                {
                    x = 0;
                    hint.Value = "单价只能输入数字！";
                    break;

                }
                else if (v12 == "")
                {
                    x = 0;
                    hint.Value = "币别不能为空！";
                    break;
                }
                else if (!bc.exists("select * from CURRENCY where CURRENCY='" + v12 + "'"))
                {
                    x = 0;
                    hint.Value = "该币别不存在于系统中！";
                    break;
                }
                else if (v7 == "")
                {
                    x = 0;
                    hint.Value = "税率不能为空！";
                    break;

                }
                else if (bc.yesno(v7) == 0)
                {
                    x = 0;
                    hint.Value = "税率只能输入数字！";
                    break;

                }
                else if (v8 == "")
                {
                    x = 0;
                    hint.Value = "需求日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v8, out temp))
                {
                    x = 0;
                    hint.Value = "需求日期格式不正确！";
                    break;

                }
            }
            return x;
        }
        #endregion
        #region JUAGE_CURRENCY_IFNO_UNIFICATION()
        private bool JUAGE_CURRENCY_IFNO_UNIFICATION()
        {
            bool b = false;
            for (int k = 0; k <CIRCULATION_COUNT -1; k++)
            {
                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v12 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                string v13 = ((TextBox)GridView1.Rows[k+1].Cells[12].FindControl("TextBox13")).Text;
                if (v1!= "")
                {
                    if (v12!=v13)
                    {
                        b = true;
                        hint.Value = "同个采购单里币别不统一！" ;
                        break;
                    }
                    
                }
            }
            return b;
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
                string[] str = new string[] { "" };
                string sql1;
                hint.Value = "";
                string id = GridView2.DataKeys[e.RowIndex][0].ToString();
                str[0] = id;
                sql1 = "DELETE FROM PURCHASE_DET WHERE PUKEY='" + id + "'";
                if (bc.exists("select * from purchasegode_det where PUID='" + Text1.Value + "'"))
                {
                    hint.Value = "该采购单已经在采购入库单中存在不允许删除！";
                }
                else if (bc.juageOne("SELECT * FROM PURCHASE_DET WHERE PUID='" + Text1.Value + "'"))
                {

                    basec.getcoms(sql1);
                    sql = "DELETE PURCHASE_MST WHERE PUID='" + Text1.Value + "'";
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM PURCHASE_MST", "PUID", "PU");
            bind();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

        
            if (juage())
            {
            }
            else
            {

                hint.Value = "";
                string v11 = bc.getOnlyString("SELECT SOURCESTATUS FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'");
                if (!string.IsNullOrEmpty(v11))
                {

                    string sql2 = "DELETE FROM PURCHASE_MST WHERE PUID='" + Text1.Value + "'";
                    string sql3 = "DELETE FROM PURCHASE_DET WHERE PUID='" + Text1.Value + "'";
                    basec.getcoms(sql2);
                    basec.getcoms(sql3);
                }
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
            Response.Redirect("../PurchaseManage/Purchase.aspx" + n2);
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
            basec.getcoms("UPDATE PURCHASE_MST SET IF_AUDIT='Y',AUDIT_MAKERID='" + varMakerID +
                "',AUDIT_DATE='" + varDate + "' WHERE PUID='" + Text1.Value + "'");
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
                if (cpurchase.JUAGE_REALTY_IFHAVE_PURCHASE_GODE_COUNT(Text1.Value ))
                {

                    hint.Value = "该采购单已经有实际入库数量，不能做撤销！";
                }
                else
                {
                    basec.getcoms("UPDATE PURCHASE_MST SET IF_AUDIT='N',AUDIT_MAKERID='" + varMakerID +
                "',AUDIT_DATE='" + varDate + "' WHERE PUID='" + Text1.Value + "'");
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
        #region rconcile
        protected void reconcile()
        {

            hint.Value = "";
            sql = @"SELECT A.PUID AS PUID,A.SN AS SN,B.WAREID AS WAREID,C.PCOUNT AS PCOUNT,SUM(B.GECOUNT) AS GECOUNT FROM PURCHASEGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY 
LEFT JOIN PURCHASE_DET C ON C.PUID=A.PUID AND C.SN=A.SN WHERE  A.PUID='" + Text1.Value + "' GROUP BY A.PUID,A.SN,B.WAREID,C.PCOUNT";
            DataTable dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                if (bc.JuageOrderOrPurchaseStatus(Text1.Value, 1))
                {

                    basec.getcoms("UPDATE PURCHASE_MST SET PURCHASESTATUS_MST='RECONCILE' WHERE PUID='" + Text1.Value + "'");
                    bind();
                }
                else
                {

                    hint.Value = "此采购单没有结案，不允许确认对帐!";
                }

            }
            else
            {
                hint.Value = "没有此采购单的入库记录!";
            }

        }
        #endregion
        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            try
            {
                basec.getcoms("UPDATE PURCHASE_MST SET PURCHASESTATUS_MST='CLOSE' WHERE PUID='" + Text1.Value + "'");
                bind();
            }
            catch (Exception)
            {

            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
         


        }

        protected void excelprint()
        {

            try
            {
                PrintPurchaseBill print = new PrintPurchaseBill();
                DataTable dtn = print.askt(Text1.Value);
                if (dtn.Rows.Count > 1)
                {

                    int i = dtn.Rows.Count - 1;
                    if (i > 0 && i <= 5)
                    {
                        if (bc.JuagePrintModelIfExists(1, "PU"))
                        {

                            bc.ExcelPrint(dtn, "采购单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else if (i > 5 && i <= 10)
                    {
                        if (bc.JuagePrintModelIfExists(2, "PU"))
                        {

                            bc.ExcelPrint(dtn, "采购单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else if (i > 10 && i <= 15)
                    {
                        if (bc.JuagePrintModelIfExists(3, "PU"))
                        {

                            bc.ExcelPrint(dtn, "采购单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else if (i > 15 && i <= 20)
                    {
                        if (bc.JuagePrintModelIfExists(4, "PU"))
                        {

                            bc.ExcelPrint(dtn, "采购单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else
                    {
                        hint.Value = "一张采购单最多支持打印20个采购项。超出20请建多张采购单！";

                    }


                }
                else
                {


                    hint.Value = "无数据可打印！";

                }

            }
            catch (Exception)
            {


            }

        }
    }
}
