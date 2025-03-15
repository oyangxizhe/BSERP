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
    public partial class CO_ORDERT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        basec bc = new basec();
        CCO_ORDER cco_order = new CCO_ORDER();
        WPSS.Validate va = new Validate();
        CBOM cbom = new CBOM();
        CMRP cmrp = new CMRP();
        CORDER corder = new CORDER();
        public static string[] str1 = new string[] { "", "" };
        public static string[] strE = new string[] { "" };
        string sql;
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
        private static string _WAREID;
        public static string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _CO_COUNT;
        public string CO_COUNT
        {
            set { _CO_COUNT = value; }
            get { return _CO_COUNT; }

        }
  
        protected void Page_Load(object sender, EventArgs e)
        {
           
        
            try
            {
                if (!IsPostBack)
                {
                    //ViewState["pageindex"] = "0";
                    Text1.Value = IDO;
                    bind();
                    Bind();
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
            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            dt = dtx();
            WAREID = "";
            if (dt.Rows.Count > 0)
            {
                WAREID = dt.Rows[0]["ID"].ToString();
            }
            string ADVICE_DELIVERY_DATE =cco_order.GET_ADVICE_DELIVERY_DATE(WAREID);
            if (ADVICE_DELIVERY_DATE != "")
            {

                basec.getcoms("UPDATE CO_ORDER SET ADVICE_DELIVERY_DATE='" + ADVICE_DELIVERY_DATE + "' WHERE CRID='" + Text1.Value + "'");
                dt = bc.getdt("SELECT * FROM BOM_MST WHERE WAREID='"+WAREID +"' AND ACTIVE='Y'");
                if (dt.Rows.Count > 0)
                {
                    Text10.Value = dt.Rows[0]["BOID"].ToString();
                    Text11.Value = dt.Rows[0]["BOM_EDITION"].ToString();
                }
            }
            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "索引" };
            GridView1.DataBind();
        
            string sql2 = cco_order.getsql +" WHERE F.CRID='"+Text1.Value +"' AND F.CRID IS NOT NULL";
            dt1 = basec.getdts(sql2);
            if (dt1.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView2.DataSource = dt1;
                GridView2.DataKeyNames = new string[] { "索引" };
                GridView2.DataBind();
          
            }
            dt = basec.getdts(cco_order.getsql + " where F.CRID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Text14.Value = dt.Rows[0]["订单号"].ToString();
                Text2.Value = dt.Rows[0]["客户ID"].ToString();
                Text3.Value = dt.Rows[0]["订货日期"].ToString();
                Text5.Value = dt.Rows[0]["客户名称"].ToString();
                Text6.Value = dt.Rows[0]["客户代码"].ToString();
                Text4.Value = dt.Rows[0]["客户订单号"].ToString();
              
                string v = bc.getOnlyString("SELECT PUID FROM ORDER_MST WHERE ORID='" + Text14.Value + "' ");
                if (!string.IsNullOrEmpty(v))
                {
                    x2.Value = v;
                }
            }
            else
            {
                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
            }
            DataTable dtx4 = basec.getdts(@"
SELECT 
B.CRID,
CASE WHEN B.SOURCE_STATUS ='Y' THEN SUM(A.ocount*A.sellunitprice)
ELSE SUM(B.CO_COUNT*A.SELLUNITPRICE)
END AS 未税金额,
CASE WHEN B.SOURCE_STATUS ='Y' THEN SUM(A.ocount*A.sellunitprice*A.taxrate/100)
ELSE SUM(B.CO_COUNT*A.sellunitprice*A.taxrate/100)
END AS 税额,
CASE WHEN B.SOURCE_STATUS='Y' THEN SUM(A.ocount*A.sellunitprice*(1+A.taxrate/100))
ELSE SUM(B.CO_COUNT *A.sellunitprice*(1+A.taxrate/100)) 
END AS 含税金额
FROM ORDER_DET A
LEFT JOIN CO_ORDER B ON A.ORKEY=B.ORKEY
WHERE B.CRID='"+Text1.Value +"' GROUP BY B.CRID,B.SOURCE_STATUS  ");

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
            ON A.WAREID=B.WAREID " + " WHERE A.ORID='" + Text14.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
            dt = basec.getdts(sql3);
            if (dt.Rows.Count > 0)
            {
               /* GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "FLKEY" };
                GridView3.DataBind();
                x1.Value = Convert.ToString(1);*/
            }
            else
            {

             
            }

            string s1 = bc.getOnlyString("SELECT * FROM WORKORDER_MST WHERE CRID='" + Text1.Value + "'");
            string s2 = bc.getOnlyString("SELECT * FROM MRP WHERE CRID='" + Text1.Value + "'");
            string s3 = bc.getOnlyString("SELECT IF_GENERATE_MRP FROM CO_ORDER WHERE CRID='" + Text1.Value + "'");
            if (!string.IsNullOrEmpty(s1) || !string.IsNullOrEmpty(s2))
            {
                btnReconcile.Text = "已产生MRP";
                btnReconcile.Enabled = false;
                //btnReductionReconcil.Enabled = true;

            }
            else if (s3=="DO_WITHOUT")              /*click reconcile generate*/
            {
                btnReconcile.Text = "无需产生";
                btnReconcile.Enabled = false;
            }
            else
            {
                btnReconcile.Text = "产生MRP";
                btnReconcile.Enabled = true;
                //btnReductionReconcil.Enabled = false;

            }
       
        }
        #endregion
        #region dtx
        protected DataTable dtx()
        {
          
            DataTable dt4 = new DataTable();
            dt4.Columns.Add("ID", typeof(string));
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("料号", typeof(string));
            dt4.Columns.Add("客户料号", typeof(string));
            dt4.Columns.Add("品名", typeof(string));
            dt4.Columns.Add("规格", typeof(string));
            dt4.Columns.Add("单位", typeof(string));
            dt4.Columns.Add("订单数量", typeof(string));
            dt4.Columns.Add("销售单价", typeof(string));
            dt4.Columns.Add("税率", typeof(string));
            dt4.Columns.Add("交货日期", typeof(string));
            dt4.Columns.Add("前置天数", typeof(string));
            dt4.Columns.Add("需求日期", typeof(string));
            dt4.Columns.Add("入库需求日期", typeof(string));
            dt4.Columns.Add("最晚下料日期", typeof(string));
            dt4.Columns.Add("最晚齐套日期", typeof(string));
            dt4.Columns.Add("建议客户交期", typeof(string));

            dt4 = basec.getdts(@cco_order.getsql +" WHERE F.CRID='" + Text1.Value + "'");

            if (dt4.Rows.Count > 0)
            {
                //dr["建议客户交期"] = DateTime.Now.ToString("yyy-MM-dd");
               
             
            }
            return dt4;
        }
        #endregion

        protected DataTable dtxo()
        {
            DataTable dtxo = new DataTable();
            dtxo.Columns.Add("C", typeof(string));
            for (int i = 0; i < 4; i++)
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
            Text5.Value = "";
            Text7.Value = "";
        
        }
        #region add
        protected void save()
        {
            hint.Value = "";
           if (cco_order .IFNOALLOW_DELETE_CRID (Text1.Value ))
            {

                hint.Value = cco_order.ErrowInfo;
            }
            else if (ac1() == 0)
            {

            }
            else
            {
                add2();
            }
        }
        #endregion
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
            for (k = 0; k < 1; k++)
            {

                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;/*OCOUNT*/
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*DELIVERY_DATE*/
                string v13 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;/*GODE_NEEDDATE*/
                string v14 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;/*LAST_PICKING_DATE*/
                string v15 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*COMPLETE_DATE*/
                string v16 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;/*ADVICE_DELIVERY_DATE*/
               
                SQlcommandE(cco_order.getsqlo + " WHERE CRID='"+Text1.Value +"'",v6,v9,v13,v14,v15,v16);
                bind();
            }
        }

        #region SQlcommandE

        protected void SQlcommandE(string sql,string v6,string v9,string v13,string v14,string v15,string v16)
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
            sqlcom.Parameters.Add("@CO_COUNT", SqlDbType.VarChar, 20).Value = v6;
            sqlcom.Parameters.Add("@DELIVERY_DATE", SqlDbType.VarChar, 20).Value = v9;
            sqlcom.Parameters.Add("@GODE_NEED_DATE", SqlDbType.VarChar, 20).Value = v13;
            sqlcom.Parameters.Add("@LAST_PICKING_DATE", SqlDbType.VarChar, 20).Value = v14;
            sqlcom.Parameters.Add("@LAST_COMPLETE_DATE", SqlDbType.VarChar, 20).Value = v15;
            sqlcom.Parameters.Add("@ADVICE_DELIVERY_DATE", SqlDbType.VarChar, 20).Value = v16;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@SOURCE_STATUS", SqlDbType.VarChar, 20).Value = "USED";
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
           
        }
        #endregion

        #region ac1()
        private int ac1()
        {

            int x = 1;
            for (int k = 0; k < 1; k++)
            {

                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;/*OCOUNT*/
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*DELIVERY_DATE*/
                string v13 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;/*GODE_NEEDDATE*/
                string v14 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;/*LAST_PICKING_DATE*/
                string v15 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;/*COMPLETE_DATE*/
                string v16 = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;/*ADVICE_DELIVERY_DATE*/
              
                DateTime temp = DateTime.MinValue;
                if (v6 == "")
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
                else if (v13 == "")
                {
                    x = 0;
                    hint.Value = "日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v13, out temp))
                {
                    x = 0;
                    hint.Value = "日期格式不正确！";
                    break;

                }
                else if (v14 == "")
                {
                    x = 0;
                    hint.Value = "日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v14, out temp))
                {
                    x = 0;
                    hint.Value = "日期格式不正确！";
                    break;

                }
                else if (v15 == "")
                {
                    x = 0;
                    hint.Value = "日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v15, out temp))
                {
                    x = 0;
                    hint.Value = "日期格式不正确！";
                    break;

                }
                else if (v16 == "")
                {
                    x = 0;
                    hint.Value = "日期不能为空！";
                    break;

                }
                else if (!DateTime.TryParse(v16, out temp))
                {
                    x = 0;
                    hint.Value = "日期格式不正确！";
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
            string sql1;
            hint.Value = "";
            string id = GridView2.DataKeys[e.RowIndex][0].ToString();
            sql1 = "DELETE FROM CO_ORDER WHERE ORKEY='" + id + "'";
            if (cco_order .IFNOALLOW_DELETE_CRID(Text1.Value))
            {
                hint.Value = cco_order.ErrowInfo;
                return;
              
            }
            else 
            {
                basec.getcoms(sql1);
                GridView2.EditIndex = -1;
             
                bind();
        
            }
            try
            {

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
            x2.Value = bc.numYM(10, 4, "0001", "SELECT * FROM PURCHASE_Mst", "PUID", "PU");
            bind();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            if (corder.JUAGE_ORDER_IF_HAVE_NO_AUDIT(Text14.Value))
            {
                hint.Value = corder.ErrowInfo;
            }
            else
            {
                
                save();
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
            Response.Redirect("../MRP_MANAGE/CO_ORDER.aspx"+n2);
        }

        protected void btnReconcile_Click(object sender, EventArgs e)
        {
            if (corder.JUAGE_ORDER_IF_HAVE_NO_AUDIT(Text14.Value))
            {
                hint.Value = corder.ErrowInfo;
            }
            else if (Text11.Value == "")
            {
                hint.Value = "BOM版本不能为空！";

            }
            else
            {
                dt = basec.getdts(@cco_order.getsql + " WHERE F.CRID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["订单数量"].ToString()))
                    {
                        CO_COUNT = dt.Rows[0]["订单数量"].ToString();
                    }
                    else
                    {
                        CO_COUNT = "0";
                    }
                }
                reconcile();
            }
            try
            {

            }
            catch (Exception)
            {

            }
        }
        #region reconcile
        protected void reconcile()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            hint.Value = "";
          
            sql = @"
SELECT 
A.CRID
FROM WORKORDER_MST A 
LEFT JOIN CO_ORDER B ON A.CRID=B.CRID
WHERE A.CRID='"+ Text1 .Value +"'";
            DataTable dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                hint.Value = "该厂内订单已经发放成工单不允许再次产生！";
               
            }
            else if (cbom.IFNOEXISTS_BOM(WAREID))
            {
               
                hint.Value = cbom.ErrowInfo;
            }
            else if (cmrp.GET_MRP_WO_COUNT(CO_COUNT, Text1.Value) && cmrp.JUAGE_MRPIFNOT_NEED_GENERATE_PURCHASE())
            {
              
                hint.Value = cmrp.ErrowInfo;
                basec.getcoms("UPDATE CO_ORDER SET IF_GENERATE_MRP='DO_WITHOUT' WHERE CRID='" + Text1.Value + "'");
            }
            else 
            {
               
                basec.getcoms("UPDATE CO_ORDER SET SOURCE_STATUS='USED' WHERE CRID='"+Text1 .Value +"'");
                basec.getcoms("UPDATE CO_ORDER SET IF_GENERATE_MRP='Y' WHERE CRID='" + Text1.Value + "'");
                string boid=bc.getOnlyString ("SELECT BOID FROM BOM_MST WHERE WAREID='"+WAREID+"' AND ACTIVE='Y'");
                basec.getcoms("INSERT INTO MRP(CRID,SOURCE_STATUS,BOID,MAKERID,DATE) VALUES ('"+Text1.Value +"','OPEN','"+boid+
                    "','"+varMakerID +"','"+varDate +"')");
                bind();
            }

        }
        #endregion
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
            /*DataList1.DataSource = dtxo();
            DataList1.DataBind();
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView4.DataSource = dt1;
            GridView4.DataKeyNames = new string[] { "FLKEY" };
            GridView4.DataBind();*/
        }

  

        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           /* try
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
            */
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* try
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

            }*/
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
