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
using System.Collections.Generic;

namespace WPSS.UserManage
{
    public partial class AUDIT_JURISDICTIONT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        CAUDIT_JURISDICTION caudit_jurisdiction = new CAUDIT_JURISDICTION();
        protected string M_str_sql = @"
SELECT 
A.USID AS USID,
A.UNAME AS UNAME,
B.ENAME AS ENAME,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=C.MAKERID) AS MAKER,
C.DATE AS DATE 
FROM  USERINFO  A
LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID 
LEFT JOIN RIGHTLIST C ON A.USID=C.USID

";
        private static string _NUMID;
        public static string NUMID
        {
            set { _NUMID = value; }
            get { return _NUMID; }

        }

        private static string _ADD_OR_UPDATE;
        public static string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }

        }
        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _USID;
        public string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    Bind();
                }
                if (va.returnb() == true)
                    Response.Redirect("\\Default.aspx");
            }
            catch (Exception)
            {


            }
          
            
        }
        public  void Bind()
        {

            hint.Value = "";
            Text1.Value = NUMID;
            DataTable dtt = new DataTable();
            dtt.Columns.Add("选择", typeof(bool));
            dtt.Columns.Add("单据名称", typeof(string));
            DataTable dtx1=basec.getdts("SELECT * FROM CUSTOMERINFO_MST ");
            List<string> list1 = new List<string>();
            list1.Add("订单");
            list1.Add("采购单");
      
            for (int i = 0; i < list1.Count ; i++)
            {
                DataRow dr1 = dtt.NewRow();
                dr1["选择"] = false;
                dr1["单据名称"] = list1[i];
                dtt.Rows.Add(dr1);
            }
     

            dt = basec.getdts(caudit_jurisdiction.sqlth + " where B.UNAME='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {
                Label1.Text = dt.Rows[0]["UNAME"].ToString();
                foreach (DataRow dr in dt.Rows)
                {

                    foreach (DataRow dr1 in dtt.Rows)
                    {

                        if (dr["BILL_NAME"].ToString() == dr1["单据名称"].ToString())
                        {
                            dr1["选择"] = true;
                            break;
                        }
                    }
                }
            }
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            NUMID = "";/*load after release value*/
        }
        protected void ClearText()
        {
            Text1.Value = "";
            Label1.Text = "";
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Clear();
            Bind();
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
        protected void Clear()
        {
           
            Text1.Value = "";
            Label1.Text = "";

    

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                save();             
            }
            catch (Exception)
            {
               
            }
        }
        #region save
        protected void save()
        {
            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            #region Save
            if (!juage1())
            {

            }
            else
            {
                USID =bc.getOnlyString("SELECT USID FROM USERINFO WHERE UNAME='" + Text1.Value + "'");
                basec.getcoms("DELETE AUDIT_JURISDICTION WHERE USID='"+USID+"'");
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (((CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1")).Checked)
                    {
                        string CUID = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TextBox1")).Text;
                        SQlcommandE(caudit_jurisdiction.sqlo, CUID);
                    }

                }
           
                NUMID = Text1.Value;/*set release value*/
                Bind();
            }
            #endregion
        }
        #endregion
        #region juage1()
        private bool juage1()
        {

            bool ju = true;
            if (Text1 .Value =="")
            {
                ju = false;
                hint.Value = "用户名不能为空！";

            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + Text1.Value + "'"))
            {
                ju = false;
                hint.Value = "用户名在系统中不存在！";

            }
            return ju;
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql,string BILL_NAME)
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
            sqlcom.Parameters.Add("@USID", SqlDbType.VarChar, 20).Value = USID;
            sqlcom.Parameters.Add("@BILL_NAME", SqlDbType.VarChar, 20).Value =BILL_NAME ;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../UserManage/AUDIT_JURISDICTION.aspx"+n2);
        }


     
    }
}
