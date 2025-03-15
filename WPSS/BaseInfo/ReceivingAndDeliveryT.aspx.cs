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

namespace WPSS.BaseInfo
{
    public partial class ReceivingAndDeliveryT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        int i;
    
        int k;
        string c1, c2, c3, c4;
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
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
           
            try
            {
                bindo(); 

            }
            catch (Exception)
            {


            }
        }
        protected void bindo()
        {

            if (!IsPostBack)
            {
               
                RDID .Value  = strE[0];
                strE[0] = "";
                bind(0);
                at(@"select * from ReceivingAndDelivery where status='Y' ");
            }

            if (va.returnb() == true)
               Response.Redirect("\\Default.aspx"); 


        }
        protected void at(string sql)
        {
            dt = basec.getdts(sql);
            if (dt.Rows.Count > 0)
            {
                
                Text1.Value = dt.Rows[0]["CONAME"].ToString();
                Text2.Value = dt.Rows[0]["CONTACT"].ToString();
                Text3.Value = dt.Rows[0]["PHONE"].ToString();
                Text4.Value = dt.Rows[0]["ADDRESS"].ToString();
            }
        }
        protected void bind(int t)
        {
            hint.Value = "";
            string v1;
            if (t == 0)
            {
                
               v1="SELECT * FROM ReceivingAndDelivery WHERE RDID='" + RDID.Value + "'";
            }
            else
            {
                v1 = "SELECT * FROM ReceivingAndDelivery ";
            }
            DataTable dt1 = basec.getdts(v1);
            GridView2.DataSource = dt1;
            GridView2.DataKeyNames = new string[] { "RDID" };
            GridView2.DataBind();
            GridView1.DataSource = dtx();
            GridView1.DataBind();
      
        }
        #region dtx
        protected DataTable dtx()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            dt4.Columns.Add("公司名称", typeof(string));
            dt4.Columns.Add("联系人", typeof(string));
            dt4.Columns.Add("联系电话", typeof(string));
            dt4.Columns.Add("地址", typeof(string));
                for (i = 1; i <= 4; i++)
                {
                    DataRow dr = dt4.NewRow();
                    dr["项次"] = i;
                    dt4.Rows.Add(dr);

                }

            
            return dt4;
        }
        #endregion

        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
        

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
       
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            try
            {
                string id = GridView2.DataKeys[e.RowIndex][0].ToString();
                if (bc.exists("SELECT * FROM RECEIVINGANDDELIVERY WHERE RDID='" + id + "' AND STATUS='Y'"))
                {
                    hint.Value = "该地址为该公司的默认地址，如果要删除改默认地址请指定其它地址为该公司的地址!";
                }
                else if (bc.exists("SELECT * FROM PURCHASE_MST WHERE RDID='" + id + "'"))
                {
                    hint.Value = "该地址在采购单信息中存在不允许删除!";
                }
                else
                {

                    string strSql = "DELETE FROM ReceivingAndDelivery WHERE RDID='" + id + "'";
                    basec.getcoms(strSql);
                    GridView2.EditIndex = -1;
                    bind(1);

                }
            }
            catch (Exception)
            {


            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            try
            {
                string key = GridView2.DataKeys[GridView2.SelectedIndex].Values[0].ToString();
                at(@"select * from ReceivingAndDelivery where RDID='" + key + "' ");
                basec.getcoms("UPDATE RECEIVINGANDDELIVERY SET STATUS='N' WHERE STATUS='Y'");
                basec.getcoms("UPDATE RECEIVINGANDDELIVERY SET STATUS='Y' WHERE RDID='"+key +"'");
            }
            catch (Exception)
            {

            }

        }

   
        #region addADDRESS
        protected void AddContactInfo()
        {


            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
         

            for (k = 0; k < 4; k++)
            {

                c1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                c2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                c3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                c4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
  

                if (c1 != "")
                {
                  
                    if (juage1(k))
                    {

                        string key = bc.numYM(10, 4, "0001", "SELECT * FROM RECEIVINGANDDELIVERY", "RDID", "RD");
                        basec.getcoms(@"INSERT INTO ReceivingAndDelivery(RDID,CONAME,CONTACT,PHONE,ADDRESS,MAKERID,STATUS,
             DATE,YEAR,MONTH,DAY) VALUES 
                    ('" + key + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + 
                        "','"+varMakerID +"','N','" + varDate + "','" + year + "','" + month + "','" + day + "')");
                           
                        
                    }
                }
            }
            bind(1);
           
        }
        #endregion
     
        #region juage1()
        private bool juage1(int k)
        {
            string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
            string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
            string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
 
       
            bool ju = true;
            if (bc.checkphone(v3) == false)
            {
                ju = false;
                hint.Value = "电话号码只能输入数字！";

            }
 
            else if (v4=="")
            {
            
                ju = false;
                hint.Value = "地址不能为空！";

            }
       
            return ju;

        }
        #endregion
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
      
        }
    
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
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
            Response.Redirect("../BaseInfo/ReceivingAndDelivery.aspx"+n2);
        }

        protected void btnAddContactInfo_Click(object sender, EventArgs e)
        {
          
            try
            {
                AddContactInfo();
            }
            catch (Exception)
            {

            }
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            for (k = 0; k < 4; k++)
            {
                ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text = "";
                ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text = "";
            }
        }
    }
}
