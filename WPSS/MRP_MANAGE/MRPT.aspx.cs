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
    public partial class MRPT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        basec bc = new basec();
        XizheC.CBOM cbom = new CBOM();
        CCO_ORDER cco_order = new CCO_ORDER();
        CMRP cmrp = new CMRP();
        WPSS.Validate va = new Validate();
        int i=0;
        DataTable dt4 = new DataTable();
        CWORKORDER cworkorder = new CWORKORDER();
        CORDER corder = new CORDER();
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
        private static string _ORKEY;
        public static string ORKEY
        {
            set { _ORKEY = value; }
            get { return _ORKEY; }

        }
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
        private string _DELIVERY_DATE;
        public string DELIVERY_DATE
        {
            set { _DELIVERY_DATE = value; }
            get { return _DELIVERY_DATE; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                hint.Value = "";
                x.Value = "";
                x1.Value = "";
                x2.Value = "";
                Text1.Value = IDO;
                DataTable dtx = bc.getdt(cco_order.getsql + " WHERE G.CRID='" + Text1.Value + "'");
                if (dtx.Rows.Count > 0)
                {
                    x.Value = Convert.ToString(1);
                    Text2.Value = dtx.Rows[0]["ID"].ToString();
                    Text3.Value = dtx.Rows[0]["料号"].ToString();
                    Text4.Value = dtx.Rows[0]["品名"].ToString();
                    Text5.Value = dtx.Rows[0]["客户料号"].ToString();
                    Text6.Value = dtx.Rows[0]["订单数量"].ToString();
                    ORKEY = dtx.Rows[0]["索引"].ToString();
                }
                bind();
                cmrp.IDO = Text2.Value;
                cmrp.CO_COUNT = Text6.Value;
                cmrp.ORDER_PRECESS_COUNT = corder.GET_ORDER_PROGRESS_COUNT(Text2.Value, ORKEY);
                cmrp.WORKORDER_PRECESS_COUNT = cworkorder.GET_WORKORDER_PROGRESS_COUNT(Text2.Value);
                dt = cmrp.getdigui(Text2.Value, 1, 1);
                Text7.Value = cmrp.STORAGE_COUNT;
                Text8.Value = cmrp.WO_COUNT;

                Text9.Value = corder.GET_ORDER_PROGRESS_COUNT(Text2.Value, ORKEY);
                Text10.Value = cworkorder.GET_WORKORDER_PROGRESS_COUNT(Text2.Value);
                GridView1.DataSource = dt;
                GridView1.DataBind();
               
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

            string s1 = bc.getOnlyString("SELECT SOURCE_STATUS FROM WORKORDER_MST WHERE CRID='" + Text1.Value + "'");
            if (s1 == "MRP")
            {
                btnReconcile.Text = "已产生工单与采购计划";
                btnReconcile.Enabled = false;
                //btnReductionReconcil.Enabled = true;

            }
            else
            {
                btnReconcile.Text = "产生工单与采购计划";
                btnReconcile.Enabled = true;
                //btnReductionReconcil.Enabled = false;

            }
     
        }
        #endregion
        protected DataTable dtx()
        {
          
            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("组成用量", typeof(string));
            dt4.Columns.Add("损耗率", typeof(string));;
            for (i = 1; i <= 4; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dr["组成用量"] =1;
                dr["损耗率"] = 0;
                dt4.Rows.Add(dr);
            }
            return dt4;
        }
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
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
          
          
        }
        #region add
        protected void save()
        {
            hint.Value = "";
           if (bc.exists("select * from WORKORDER_MST where BOID='" + Text1.Value + "'"))
            {

                hint.Value = "该BOM有了工单不允许修改！";
            }
      
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

     
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
        }
        protected void add()
        {
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM BOM_MST", "BOID", "BO");
            bind();
            ADD_OR_UPDATE = "ADD";


        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            save();
            if (ADD_OR_UPDATE == "ADD")
            {
                add();

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
            Response.Redirect("../MRP_MANAGE/MRP.aspx"+n2);
        }

        protected void btnReconcile_Click(object sender, EventArgs e)
        {
            reconcile(); 
            try
            {
               
            }
            catch (Exception)
            {

            }
        }
        protected void reconcile()
        {
           
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            MAKERID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            hint.Value = "";
           string  sql = @"
SELECT 
A.CRID FROM WORKORDER_MST A
WHERE  A.CRID='" + Text1.Value + "' ";
            DataTable dt2 = basec.getdts(sql);
            if (dt2.Rows.Count > 0)
            {
                hint.Value = "该厂内订单已经发放成工单与采购单不允许再次产生！";
                
            }
            else
            {
                cmrp.IDO = Text2.Value;
                cmrp.CO_COUNT = Text6.Value;
                cmrp.ORDER_PRECESS_COUNT = corder.GET_ORDER_PROGRESS_COUNT(Text2.Value, ORKEY);
                DataTable dtx = bc.getdt("SELECT * FROM CO_ORDER WHERE CRID='" + Text1.Value + "'");
                if (dtx.Rows.Count > 0)
                {
                    //bc.Show(dtx.Rows[0]["DELIVERY_DATE"].ToString());
                     DELIVERY_DATE = dtx.Rows[0]["DELIVERY_DATE"].ToString();
                    cworkorder.GODE_NEED_DATE = dtx.Rows[0]["GODE_NEED_DATE"].ToString();
                    NEEDDATE = dtx.Rows[0]["GODE_NEED_DATE"].ToString();
                    cworkorder.LAST_PICKING_DATE = dtx.Rows[0]["LAST_PICKING_DATE"].ToString();
                    cworkorder.COMPLETE_DATE = dtx.Rows[0]["LAST_COMPLETE_DATE"].ToString();
                    cworkorder.ADVICE_DELIVER_DATE = dtx.Rows[0]["ADVICE_DELIVERY_DATE"].ToString();
                    cworkorder.WOID = cworkorder.GETID;
                }
                dt = cmrp.getdigui(Text2.Value, 1, 1);
                if (cmrp.WO_COUNT == "0" && !cmrp.JUAGE_MRPIFNOT_NEED_GENERATE_PURCHASE())
                {
                    hint.Value = "生产数量为0无需产生工单 "+cmrp .ErrowInfo ;
                   
                        EXECUTION_PURCHASE_PLAN();
                    
                    bc.getcom("DELETE MRP WHERE CRID='" + Text1.Value + "'");
                    bind();
                }
                else if (cmrp.WO_COUNT != "0" && cmrp.JUAGE_MRPIFNOT_NEED_GENERATE_PURCHASE())
                {

                    hint.Value = "采购单位量为0无需产生采购单 " + cmrp.ErrowInfo;
                  
                    EXECUTION_WORKORDER();
                    
                    bc.getcom("DELETE MRP WHERE CRID='" + Text1.Value + "'");
                    bind();
                }
                else if (cmrp.WO_COUNT != "0" && !cmrp.JUAGE_MRPIFNOT_NEED_GENERATE_PURCHASE())
                {
                   
                    EXECUTION_PURCHASE_PLAN();
                    EXECUTION_WORKORDER();
                    
                    bc.getcom("DELETE MRP WHERE CRID='" + Text1.Value + "'");
                    bind();
                }
                else
                {
                    hint.Value = "生产数量为0无需产生工单 " + " " + "采购单位量为0无需产生采购单";
                }

            }
        }
       
        protected void EXECUTION_PURCHASE_PLAN()
        {
            CPURCHASE_PLAN cpurchase_plan = new CPURCHASE_PLAN();
            cpurchase_plan.MAKERID = MAKERID;
            cpurchase_plan.NEEDDATE = NEEDDATE;
            cpurchase_plan.save(dt);
        }
        protected void EXECUTION_WORKORDER()
        {
           
            foreach (DataRow dr in dt.Rows)
            {
                cworkorder.CRID = Text1.Value;
                cworkorder.WAREID = dr["ID"].ToString();
                cworkorder.DET_WAREID = dr["子ID"].ToString();
                cworkorder.BOM_WAREID = dr["子ID"].ToString();
                cworkorder.SN = dr["项次"].ToString();
                cworkorder.UNIT_DOSAGE = dr["组成用量"].ToString();
                cworkorder.ATTRITION_DOSAGE = dr["损耗量"].ToString();
                cworkorder.IFC_SUPPLY = dr["客供否"].ToString();
                cworkorder.PICKING_STAGE = dr["发料阶段"].ToString();
                cworkorder.MAKERID = MAKERID;
                cworkorder.WO_COUNT = cmrp.WO_COUNT;
                decimal d1=(decimal .Parse (dr["组成用量"].ToString ())+decimal .Parse (dr["损耗量"].ToString ()))*decimal.Parse (cmrp.WO_COUNT);
                cworkorder.WO_DOSAGE = d1.ToString("#0.00");
                cworkorder.DELIVERY_DATE = DELIVERY_DATE;
                cworkorder.SOURCE_STATUS = "MRP";
                cworkorder.BOID = bc.getOnlyString("SELECT BOID FROM MRP WHERE CRID='" + Text1.Value + "'");
                cworkorder.SQlcommandE();
            }
            cworkorder.SQlcommandEo(cworkorder.getsqlt);
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql, string KEY, string sn, string v1, string v2, string v3, string v4, string v5, string v6)
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
            sqlcom.Parameters.Add("@BOKEY", SqlDbType.VarChar, 20).Value = KEY;
            sqlcom.Parameters.Add("@BOID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@DET_WAREID", SqlDbType.VarChar, 20).Value = v1;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = sn;
            sqlcom.Parameters.Add("@UNIT_DOSAGE", SqlDbType.VarChar, 20).Value = v2;
            sqlcom.Parameters.Add("@ATTRITION_RATE", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@IFC_SUPPLY", SqlDbType.VarChar, 20).Value = v4;
            sqlcom.Parameters.Add("@PICKING_STAGE", SqlDbType.VarChar, 20).Value = v5;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = v6;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region SQlcommandE

        protected void SQlcommandE(string sql)
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
            sqlcom.Parameters.Add("@BOID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@BOM_EDITION", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            try
            {
                basec.getcoms("UPDATE BOM_MST SET BOMSTATUS_MST='CLOSE' WHERE BOID='" + Text1.Value + "'");
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
               
            }
            catch (Exception)
            {

            }
        }
        protected void delete_wareid_file(string v1)
        {

         
            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" +v1+ "'");
            string s1 = Server.MapPath(FilePath);
            if (File.Exists(s1))
            {
                File.Delete(s1);
            }
            string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + v1+ "'";
            basec.getcoms(strSql);
        }
     
    }
}
