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

namespace WPSS.PurchaseManage
{
    public partial class PurchaseUnitPriceT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();

        string v1,v2;
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
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";
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
        private void bind()
        {
            dto = SqlDT.SqlDTM("CURRENCY", "CURRENCY");
            if (DropDownList1.Items.Count - 1 != dto.Rows.Count)
            {
                DropDownList1.Items.Add("");
                foreach (DataRow dr1 in dto.Rows)
                {

                    DropDownList1.Items.Add(dr1[0].ToString());
                }
            }
            bind2();
            hint.Value = "";
            Text1.Value = IDO;
                dt = basec.getdts(@"
select A.WAREID AS WAREID,
A.SUID AS SUID,
C.SNAME AS SNAME,
A.PURCHASEUNITPRICE AS PURCHASEUNITPRICE,
B.CO_WAREID AS CO_WAREID,
B.WNAME AS WNAME,
B.CWAREID AS CWAREID,
A.REMARK AS REMARK,
A.CURRENCY AS CURRENCY
from PurchaseUnitPrice A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN SUPPLIERINFO_MST C ON A.SUID=C.SUID
where A.PPID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {

                    Text2.Value = dt.Rows[0]["WAREID"].ToString();
                    Text3.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text4.Value = dt.Rows[0]["WNAME"].ToString();
                    Text5.Value = dt.Rows[0]["CWAREID"].ToString();
                    Text6.Value = dt.Rows[0]["SNAME"].ToString();
                    Text7.Value = dt.Rows[0]["PURCHASEUNITPRICE"].ToString();
                    TextBox1.Text = dt.Rows[0]["REMARK"].ToString();
                    DropDownList1.Text = dt.Rows[0]["CURRENCY"].ToString();
                }
            
        }
        #region bind2
        protected void bind2()
        {
        
          DropDownList1.Text = bc.GET_RMB();
            
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
            TextBox1.Text = "";
            DropDownList1.Text = "";
            bind2();
        }
        #region
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
            v1 = bc.getOnlyString("SELECT WAREID FROM PurchaseUnitPrice WHERE  PPID='" + Text1.Value + "'");
            v2 = bc.getOnlyString("SELECT SUID FROM SUPPLIERINFO_MST WHERE SNAME='"+Text6.Value +"'");
            string v3 = bc.getOnlyString("SELECT SUID FROM PurchaseUnitPrice WHERE  PPID='" + Text1.Value + "'");
            if (!juage1(Text6 .Value ))
            {

            }
            else if (!bc.exists("SELECT PPID FROM PurchaseUnitPrice WHERE PPID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from PurchaseUnitPrice where  WAREID='" + Text2.Value + "' AND SUID='"+v2+"'"))
                {
                    hint.Value = "此品号供应商已经有核价信息！";
                }
                else
                {
                    basec.getcoms(@"insert into PurchaseUnitPrice(PPID,WAREID,SUID,PurchaseUnitPrice,MakerID,
Date,Year,Month,Day,REMARK,CURRENCY) values('" + Text1.Value + "','" + Text2.Value + "','" + v2 + "', '"+Text7.Value +
                                               "', '" + varMakerID + "','" + varDate +
                      "','" + year + "','" + month + "','" + day + "','"+TextBox1 .Text +"','"+DropDownList1 .Text +"')");
                    IFExecution_SUCCESS = true;
                }
            }
            else if (v1 != Text2.Value || v2!=v3)
            {
                if (bc.exists("select * from PurchaseUnitPrice where  WAREID='" + Text2.Value + "' AND SUID='"+v2+"'"))
                {

                    hint.Value = "此品号供应商已经有核价信息！";

                }
                else
                {

                    basec.getcoms("UPDATE PurchaseUnitPrice SET WAREID='" + Text2.Value + "',SUID='"+v2+"' ,PurchaseUNITPRICE='" + Text7.Value +
                        "',MAKERID='" + varMakerID + "',DATE='" + varDate + "',REMARK='"+TextBox1 .Text +
                        "' ,CURRENCY='"+DropDownList1 .Text +"' WHERE PPID='" + Text1.Value + "'");
                    IFExecution_SUCCESS = true;
                }
            }
            else
            {

                basec.getcoms("UPDATE PurchaseUnitPrice SET WAREID='" + Text2.Value + "',SUID='" + v2 + "' ,PurchaseUNITPRICE='" + Text7.Value +
                       "',MAKERID='" + varMakerID + "',DATE='" + varDate + "',REMARK='"+TextBox1 .Text +
                       "',CURRENCY='"+DropDownList1 .Text +"' WHERE PPID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }
        }
        #endregion
        private bool juage1(string v2)
        {
            bool ju = true;
       
            if (!bc.exists ("SELECT * FROM WAREINFO WHERE WAREID='"+Text2.Value +"' AND ACTIVE='Y'"))
            {
                ju = false;
                hint.Value = "该品号不存在于系统或状态不为正常！";
            }
            else if (v2=="")
            {
                ju = false;
                hint.Value = "该供应商不能为空！";
            }
            else if (!bc.exists("SELECT * FROM SUPPLIERINFO_MST WHERE SNAME='" +v2 + "'"))
            {
                ju = false;
                hint.Value = "该供应商不存在于系统！";
            }
     
            else if (bc.yesno(Text7.Value) == 0)
            {
                ju = false;
                hint.Value = "采购单价只能输入数字！";
            }

            return ju;

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

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
  
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {
                save();
                if (ADD_OR_UPDATE == "ADD" && IFExecution_SUCCESS ==true )
                {
                    add();
                }
            }
            catch (Exception)
            {


            }
        }
        protected void add()
        {
            hint.Value = "";
            btnSave.Enabled = true;
            ClearText();
            string a = bc.numYM(10, 4, "0001", "select * from PurchaseUnitPrice", "PPID", "PP");
            if (a == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                Text1.Value = a;

            }
            ADD_OR_UPDATE = "ADD";
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/PurchaseUnitPrice.aspx"+n2);
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
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
        protected void Bind()
        {
            DataList1.DataSource = dtx();
            DataList1.DataBind();
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView1.DataSource = dt1;
            GridView1.DataKeyNames = new string[] { "FLKEY" };
            GridView1.DataBind();
        }
        protected DataTable dtx()
        {
            dt.Columns.Add("C", typeof(string));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["C"] = Convert.ToString(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string v1 = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
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

    }
}
