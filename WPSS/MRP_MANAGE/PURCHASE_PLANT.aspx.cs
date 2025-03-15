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

namespace WPSS.MRP_MANAGE
{
    public partial class PURCHASE_PLANT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        basec bc = new basec();
        CPURCHASE cpurchase = new CPURCHASE();
        CPURCHASE_PLAN cpurchase_plan = new CPURCHASE_PLAN();
        Validate va = new Validate();
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        int i;
        #region nature
        private string _MPA_UNIT;
        public string MPA_UNIT
        {
            set { _MPA_UNIT = value; }
            get { return _MPA_UNIT; }

        }
        private string _PUID;
        public string PUID
        {
            set { _PUID = value; }
            get { return _PUID; }

        }
        private string _SKU;
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private string _PLKEY;
        public string PLKEY
        {
            set { _PLKEY = value; }
            get { return _PLKEY; }

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
        private decimal _TAX_RATE;
        public decimal TAX_RATE
        {
            set { _TAX_RATE = value; }
            get { return _TAX_RATE; }

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
        private  int  _CIRCULATION_COUNT;
        public  int  CIRCULATION_COUNT
        {
            set { _CIRCULATION_COUNT = value; }
            get { return _CIRCULATION_COUNT; }

        }
        #endregion
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        private string _NEEDDATE;
        public string NEEDDATE
        {
            set { _NEEDDATE = value; }
            get { return _NEEDDATE; }

        }
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _PCOUNT;
        public string PCOUNT
        {
            set { _PCOUNT = value; }
            get { return _PCOUNT; }

        }
        private string _NEED_PCOUNT;
        public string NEED_PCOUNT
        {
            set { _NEED_PCOUNT = value; }
            get { return _NEED_PCOUNT; }

        }
        string  KEY;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckBox2.AutoPostBack = true;
                CheckBox3.AutoPostBack = true;
                currentdate();
                if (juageo())
                {

                }
                else
                {
                    bind();
                }

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
        private bool juageo()
        {
            bool b = false;
            dt=bc.getdt(cpurchase_plan .sqlf );
           foreach (DataRow dr in dt.Rows)
            {
                if (string.IsNullOrEmpty(dr["最小采购量"].ToString()))
                {

                    hint.Value = "检测到料号："+dr["料号"].ToString ()+" 没有维护过最小采购量，需维护后才能产生批次采购计划数据！";
                    b = true;
                    break;
                 

                }
            }
            return b;
        }
     
        #region bind
        protected void bind()
        {
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = "成功产生采购单号："+PUID ;
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
        }
        #endregion

 
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
            dtt.Columns.Add("PLKEY", typeof(string));
            dtt.Columns.Add("采购计划批号", typeof(string));
            dtt.Columns.Add("选择", typeof(bool));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("供应商", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("品牌", typeof(string));
            dtt.Columns.Add("采购单位", typeof(string));
            dtt.Columns.Add("采购数量", typeof(string));
            dtt.Columns.Add("最小采购量", typeof(string));
            dtt.Columns.Add("需采购量", typeof(string));
            dtt.Columns.Add("币别", typeof(string));
            dtt.Columns.Add("税率", typeof(string));
            dtt.Columns.Add("需求日期", typeof(string));
            dtt.Columns.Add("备注", typeof(string));


            DataTable  dt4 = basec.getdts(cpurchase_plan .sqlf );
            if (dt4.Rows.Count > 0)
            {
                i = 0;
                foreach (DataRow dr1 in dt4.Rows)
                {
                    DataRow dr = dtt.NewRow();
                    dr["PLKEY"] = dr1["索引"].ToString();
                    dr["采购计划批号"] = dr1["采购计划批号"].ToString();
                    dr["选择"] = false;
                    dr["项次"] = i + 1;
                    dr["品号"] = dr1["品号"].ToString();
                    dr["料号"] = dr1["料号"].ToString();
                    dr["客户料号"] = dr1["客户料号"].ToString();
                    dr["供应商"] = dr1["供应商"].ToString();
                    dr["品名"] = dr1["品名"].ToString();
                    dr["规格"] = dr1["规格"].ToString();
                    dr["品牌"] = dr1["品牌"].ToString();
                    dr["采购单位"] = dr1["采购单位"].ToString();
                    dr["采购数量"] = dr1["采购数量"].ToString();
                    dr["最小采购量"] = dr1["最小采购量"].ToString();
                    decimal d1 = decimal.Parse(dr1["采购数量"].ToString());
                    decimal d2 = decimal.Parse(dr1["最小采购量"].ToString());
                    decimal d3;
                    d3 = d1 / d2;
                    string v1 = d3.ToString("0");
                    decimal d4 = decimal.Parse(v1) * d2;
                    dr["需采购量"] = d4;
                    dr["币别"] = dr1["币别"].ToString();
                    dr["税率"] = dr1["税率"].ToString();
                    dr["需求日期"] = dr1["需求日期"].ToString();
                    dr["备注"] = dr1["备注"].ToString();
                    i = i + 1;
                    dtt.Rows.Add(dr);
                }
                x.Value = "1";
                CIRCULATION_COUNT = dt4.Rows.Count;
            }
            else
            {
                btnReconcile.Enabled = false;

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
        private bool juage()
        {
            bool b = false;
            if (!bc.exists("SELECT * FROM SUPPLIERINFO_MST WHERE SUID='" + Text2.Value + "'"))
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
 
            else if (ac1() == 0)
            {
                b = true;
            }
            else if (JUAGE_CURRENCY_IFNO_UNIFICATION())
            {
                b = true;

            }
            else if (JUAGE_IFEXISTS_SELECT() == false)
            {
                b = true;
            }
            return b;
        }
     

        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM PURCHASE_PLAN_DET WHERE PLID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT SUID FROM PURCHASE_PLAN_DET WHERE PLID='" + s1 + "'");
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

                //string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;/*plid*/
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;/*sn*/
                WAREID  = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;/*wareid*/
             
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*pcount*/
                string v10 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;/*mpa_unit*/

                string v11 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;/*purchase_unitprice*/
                string v12 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*currency*/

                string v13 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;/*tax_rate*/
                string v14 = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;/*needdate*/
             
                CheckBox chb = ((CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1"));
                DateTime temp = DateTime.MinValue;

                if (chb.Checked==false )
                {
                }
                else if (!bc.exists("select * from WAREinfo where WAREid='" + WAREID  + "' AND ACTIVE='Y'"))
                {
                    x = 0;
                    hint.Value = "该品号不存在于系统中或状态不为正常！";
                    break;
                }
                else if (v9 == "")
                {

                    x = 0;
                    hint.Value = "采购数量不能为空！";
                    break;
                }
                else if (bc.yesno(v9) == 0)
                {
                    x = 0;
                    hint.Value = "数量只能输入数字！";
                    break;

                }
                else if (v10 == "")
                {
                    x = 0;
                    hint.Value = "采购单位不能为空！";
                    break;
                }
                else if (!bc.exists("select * from UNIT where UNIT='" + v10 + "'"))
                {
                    x = 0;
                    hint.Value = "该采购单位不存在于系统中！";
                    break;
                }
                /*else if (v11 == "")
                {
                    x = 0;
                    hint.Value = "采购单价不能为空！";
                    break;

                }
                else if (bc.yesno(v11) == 0)
                {
                    x = 0;
                    hint.Value = "单价只能输入数字！";
                    break;

                }*/
                else if (v12 == "")
                {
                    x = 0;
                    hint.Value = "币别不能为空！";
                    break;
                }
                else if (!bc.exists("select * from CURRENCY where CURRENCY='" + v12+ "'"))
                {
                    x = 0;
                    hint.Value = "该币别不存在于系统中！";
                    break;
                }
                else if (v13 == "")
                {
                    x = 0;
                    hint.Value = "税率不能为空！";
                    break;

                }
                else if (bc.yesno(v13) == 0)
                {
                    x = 0;
                    hint.Value = "税率只能输入数字！";
                    break;

                }
                else if (v14== "")
                {
                    x = 0;
                    hint.Value = "需求日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v14, out temp))
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
                CheckBox chb = ((CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1"));
                string v12 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*currency*/
                string v13 = ((TextBox)GridView1.Rows[k+1].Cells[11].FindControl("TextBox12")).Text;
                
                if (chb.Checked == false)
                {
                 

                }
                else  if (v12 != v13)
                {
                    b = true;
                    hint.Value = "同一个采购单里币别不统一！";
                    break;
                }
            }
            return b;
        }
        #endregion
        #region JUAGE_IFEXISTS_SELECT()
        private bool JUAGE_IFEXISTS_SELECT()
        {
            bool b = false;
            for (int k = 0; k <GridView1 .Rows .Count ; k++)
            {
                CheckBox chb = ((CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1"));
                if (chb.Checked)
                {
                    b = true;
                    break;
                }
            }
            if (b == false)
            {
                hint.Value = "无选中项！";
            }
            return b;
        }
        #endregion
        #region DELETE_SELECT()
        private void  DELETE_SELECT()
        {
            string sql;
            for (int k = 0; k < GridView1.Rows.Count; k++)
            {
                CheckBox chb = ((CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1"));
                PLKEY = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;/*PLKEY*/
                string PLID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;/*PLID*/

                string sql1 = "DELETE FROM  PURCHASE_PLAN_DET WHERE PLKEY='" + PLKEY + "'";
                if(chb.Checked ==false )
                {

                }
                else  if (bc.juageOne("SELECT * FROM PURCHASE_PLAN_DET WHERE PLID='" +PLID+ "'"))
                {
                    basec.getcoms(sql1);
                    sql = "DELETE PURCHASE_PLAN_MST WHERE PLID='" + PLID + "'";
                    basec.getcoms(sql);
                }
                else
                {
                    basec.getcoms(sql1);
                }
            }
            IFExecution_SUCCESS = true;
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

   
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
         
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

        
            
        }

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../main.aspx" + n2);
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
          
            }
            catch (Exception)
            {

            }
        }
        protected void btnReconcile_Click(object sender, EventArgs e)
        {
            
        
         
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            MAKERID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            if (juage())
            {

            }
            else
            {
                dt = GET_DATA();
                SQlcommandE(cpurchase.sqlo, dt);
                SQlcommandEo(cpurchase.sqlt);
                DELETE_SELECT();
                bind();
            }
             
            try
            {
              

            }
            catch (Exception)
            {

            }
           

        }
        #region SQlcommandE
        protected void SQlcommandE(string sql,DataTable dt)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            foreach (DataRow dr in dt.Rows )
            {
               
                    KEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM PURCHASE_DET", "PUKEY", "PU");
                    SqlConnection sqlcon = bc.getcon();
                    SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                    sqlcom.Parameters.Add("@PUKEY", SqlDbType.VarChar, 20).Value = KEY;
                    sqlcom.Parameters.Add("@PUID", SqlDbType.VarChar, 20).Value = cpurchase.GETID;
                    PUID = cpurchase.GETID;
                    sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = dr["项次"].ToString();
                    sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = dr["品号"].ToString();
                    sqlcom.Parameters.Add("@PCOUNT", SqlDbType.VarChar, 20).Value = dr["采购数量"].ToString();
                    sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = Text2.Value;
                    if (!string.IsNullOrEmpty(dr["采购单价"].ToString()))
                    {
                        sqlcom.Parameters.Add("@PURCHASEUNITPRICE", SqlDbType.VarChar, 20).Value = dr["采购单价"].ToString();
                    }
                    else
                    {
                        sqlcom.Parameters.Add("@PURCHASEUNITPRICE", SqlDbType.VarChar, 20).Value = DBNull.Value;
                    }
                    sqlcom.Parameters.Add("@CURRENCY", SqlDbType.VarChar, 20).Value = dr["币别"].ToString();
                    sqlcom.Parameters.Add("@TAXRATE", SqlDbType.VarChar, 20).Value = dr["税率"].ToString();
                    sqlcom.Parameters.Add("@NEEDDATE", SqlDbType.VarChar, 20).Value = dr["需求日期"].ToString();
                    sqlcom.Parameters.Add("@PURCHASESTATUS_DET", SqlDbType.VarChar, 20).Value = "OPEN";
                    sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = dr["采购单位"].ToString();
                    DataTable dt2 = bc.getdt("SELECT * FROM WAREINFO WHERE WAREID='" +dr["品号"].ToString()+ "'");
                    if (dt2.Rows.Count > 0)
                    {
                       
                        sqlcom.Parameters.Add("@MPA_TO_STOCK", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["MPA_TO_STOCK"].ToString();
                        sqlcom.Parameters.Add("@STOCK_TO_BOM", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["STOCK_TO_BOM"].ToString();
                        sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["SKU"].ToString();
                        sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = dt2.Rows[0]["BOM_UNIT"].ToString();
                    }
                    sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = dr["备注"].ToString();
                    sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
                    sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
                    sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;

                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();
            }
        }
        #endregion
        #region SQlcommandEo
        protected void SQlcommandEo(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@PUID", SqlDbType.VarChar, 20).Value = cpurchase.GETID;
            sqlcom.Parameters.Add("@SUID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@PDATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@SOURCESTATUS", SqlDbType.VarChar, 20).Value = "MRP";
            sqlcom.Parameters.Add("@PURID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
            DataTable dt8 = bc.getdt(cpurchase_plan .sqlth);
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
        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception)
            {

            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
       


        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked)
            {
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = true;

                }
            }
            else
            {
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = false;

                }

            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked)
            {
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cbx = ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1"));
                    if (cbx.Checked)
                    {
                        ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = false;
                    }
                    else
                    {
                        ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = true;

                    }

                }
            }
            else
            {
                for (i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cbx = ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1"));
                    if (cbx.Checked)
                    {
                        ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = false;
                    }
                    else
                    {
                        ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked = true;

                    }

                }

            }
        }
        private DataTable GET_DATA()
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            DataTable dtx = emptyTable();
            DataTable dtt = emptyTable();
            int j = 0;
            for (int k = 0; k < GridView1.Rows.Count; k++)
            {
                //string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;/*plid*/
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;/*sn*/
                WAREID = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;/*wareid*/

                PCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*pcount*/
                MPA_UNIT = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;/*mpa_unit*/

                string v11 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;/*purchase_unitprice*/
                CURRENCY = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*currency*/

                string v13 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;/*tax_rate*/
                NEEDDATE = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;/*needdate*/
                string REMARK = ((TextBox)GridView1.Rows[k].Cells[14].FindControl("TextBox15")).Text;/*remark*/

             

                NEED_PCOUNT = ((TextBox)GridView1.Rows[k].Cells[18].FindControl("TextBox19")).Text;/*NEED_pcount*/
                CheckBox chb = ((CheckBox)GridView1.Rows[k].Cells[0].FindControl("CheckBox1"));
                DateTime temp = DateTime.MinValue;

                if (chb.Checked == false)
                {
                }
                else
                {
                    DataRow dr = dtx.NewRow();
                    
                    dr["品号"] = WAREID;
                    dr["采购数量"] = NEED_PCOUNT;
                    dr["采购单位"] = MPA_UNIT;
                    dr["税率"] = v13;
                    dr["币别"] = CURRENCY;
                    dr["需求日期"] = NEEDDATE;
                    dr["备注"] = REMARK;
                    dtx.Rows.Add(dr);
                   
                }
            }

            if (dtx.Rows.Count > 0)
            {
                
                foreach (DataRow dr1 in dtx.Rows)
                {
                    DataView dv = new DataView(dtt);
                    DataRow dr = dtt.NewRow();
                    dv.RowFilter = "品号='" + dr1["品号"].ToString() + "' AND 采购单位='" + dr1["采购单位"].ToString() + "' ";
                    DataTable dtx1 = dv.ToTable();
                    if (dtx1.Rows.Count > 0)
                    {


                    }
                    else
                    {
                        dr["项次"] = j + 1;
                        dr["品号"] = dr1["品号"].ToString();
                        dr["采购单位"] = dr1["采购单位"].ToString();
                        DataTable dtx2 = bc.getdt("SELECT * FROM PURCHASEUNITPRICE WHERE WAREID='" + dr1["品号"].ToString() +
                            "' AND SUID='" + Text2.Value + "'");
                        if (dtx2.Rows.Count > 0)
                        {

                            dr["采购单价"] = dtx2.Rows[0]["PURCHASEUNITPRICE"].ToString();
                        }
                        dr["税率"] = dr1["税率"].ToString();
                        dr["币别"] = dr1["币别"].ToString();
                        dr["需求日期"] = dr1["需求日期"].ToString();
                        dr["备注"] = dr1["备注"].ToString();
                        dtt.Rows.Add(dr);
                        j = j + 1;
                    }
                }
            }
            foreach (DataRow dr in dtt.Rows)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {

                    if (dr["品号"].ToString() == dr1["品号"].ToString() && dr["采购单位"].ToString() == dr1["采购单位"].ToString())
                    {

                        DataView dv = new DataView(dtx);

                        dv.RowFilter = "品号='" + dr1["品号"].ToString() + "' AND 采购单位='" + dr1["采购单位"].ToString() + "' ";
                        DataTable dtx1 = dv.ToTable();
                        if (dtx1.Rows.Count > 0)
                        {
                            dr["采购数量"] = dtx1.Compute("SUM(采购数量)", "").ToString();

                        }
                        break;
                    }
                }
            }
            return dtt;
        }
        private DataTable emptyTable()
        {

            DataTable dtt = new DataTable();
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("品牌", typeof(string));
            dtt.Columns.Add("采购数量", typeof(decimal));
            dtt.Columns.Add("采购单位", typeof(string ));
            dtt.Columns.Add("采购单价", typeof(string));
            dtt.Columns.Add("币别", typeof(string));
            dtt.Columns.Add("税率", typeof(string));
            dtt.Columns.Add("需求日期", typeof(string));
            dtt.Columns.Add("备注", typeof(string));
            return dtt;
        }
    }
}
