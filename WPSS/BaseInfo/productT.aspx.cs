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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace WPSS.BaseInfo
{
    public partial class productT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();

        WPSS.Validate va = new Validate();
        int i;
        DataTable dto = new DataTable();
        string sql = @"INSERT INTO WAREINFO(
WAREID,
CO_WAREID,
WNAME,
CWAREID,
SPEC,
CUID,
REMARK,
DATE,
MAKERID,
YEAR,
ACTIVE,
MONTH,
MPA_UNIT,
MPA_TO_STOCK,
SKU,
STOCK_TO_BOM,
BOM_UNIT,
PRODUCTION_PHASE
)
VALUES 
(
@WAREID,
@CO_WAREID,
@WNAME,
@CWAREID,
@SPEC,
@CUID,
@REMARK,
@DATE,
@MAKERID,
@YEAR,
@ACTIVE,
@MONTH,
@MPA_UNIT,
@MPA_TO_STOCK,
@SKU,
@STOCK_TO_BOM,
@BOM_UNIT,
@PRODUCTION_PHASE
)

";
        string sqlo = @"
UPDATE WAREINFO SET 
CO_WAREID=@CO_WAREID,
WNAME=@WNAME,
CWAREID=@CWAREID,
SPEC=@SPEC,
CUID=@CUID,
REMARK=@REMARK,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
ACTIVE=@ACTIVE,
MPA_UNIT=@MPA_UNIT,
MPA_TO_STOCK=@MPA_TO_STOCK,
SKU=@SKU,
STOCK_TO_BOM=@STOCK_TO_BOM,
BOM_UNIT=@BOM_UNIT,
PRODUCTION_PHASE=@PRODUCTION_PHASE
";

        private static string _WAREID;
        public static string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private static string _PPID;
        public static string PPID
        {
            set { _PPID = value; }
            get { return _PPID; }

        }
        private static string _SPID;
        public static string SPID
        {
            set { _SPID = value; }
            get { return _SPID; }

        }
        private string _CUID;
        public string CUID
        {
            set { _CUID = value; }
            get { return _CUID; }

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
        #region page_load
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {


                    Bind1();
                    Bind();
                }
                if (va.returnb() == true)
                    Response.Redirect("\\Default.aspx");

            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region Bind1()
        protected void Bind1()
        {
            hint.Value = "";
            getbinddata();
            Text1.Value = WAREID;
            x2.Value = PPID;
            x3.Value = SPID;
            Text1.Value = WAREID;
            dt = basec.getdts("select * from WareInfo where WAREID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["WAREID"].ToString();
                Text2.Value = dt.Rows[0]["CO_WAREID"].ToString();
                Text3.Value = dt.Rows[0]["WNAME"].ToString();
                Text4.Value = dt.Rows[0]["CWAREID"].ToString();
                Text9.Value = bc.getOnlyString("SELECT CNAME FROM CUSTOMERINFO_MST WHERE CUID='" + dt.Rows[0]["CUID"].ToString() + "'");
                Text10.Value = dt.Rows[0]["SPEC"].ToString();
                Text5.Value = bc.getOnlyString("SELECT CUSTOMER_ID FROM CUSTOMERINFO_MST WHERE CUID='" + dt.Rows[0]["CUID"].ToString() + "'");

                if (dt.Rows[0]["ACTIVE"].ToString() == "Y")
                {
                    DropDownList1.Text = "正常";
                }
                else if (dt.Rows[0]["ACTIVE"].ToString() == "HOLD")
                {
                    DropDownList1.Text = "Hold";
                }
                else
                {
                    DropDownList1.Text = "作废";
                }

                Text6.Value = dt.Rows[0]["MPA_TO_STOCK"].ToString();
                Text7.Value = dt.Rows[0]["STOCK_TO_BOM"].ToString();
                Text8.Value = dt.Rows[0]["PRODUCTION_PHASE"].ToString();
                DropDownList2.Text = dt.Rows[0]["MPA_UNIT"].ToString();
                DropDownList3.Text = dt.Rows[0]["SKU"].ToString();
                DropDownList4.Text = dt.Rows[0]["BOM_UNIT"].ToString();
                TextBox1.Text = dt.Rows[0]["REMARK"].ToString();

            }
            else
            {
                bind2();

            }
        }
        #endregion
        #region bind2
        protected void bind2()
        {

            Text6.Value = "1";
            Text7.Value = "1";
            Text8.Value = "1";
            DropDownList2.Text = bc.GET_PCS();
            DropDownList3.Text = bc.GET_PCS();
            DropDownList4.Text = bc.GET_PCS();
        }
        #endregion
        #region getBindData()
        protected void getbinddata()
        {

            dto = SqlDT.SqlDTM("UNIT", "UNIT");
            if (DropDownList2.Items.Count - 1 != dto.Rows.Count)
            {
                DropDownList2.Items.Add("");
                foreach (DataRow dr1 in dto.Rows)
                {

                    DropDownList2.Items.Add(dr1[0].ToString());


                }
            }
            if (DropDownList3.Items.Count - 1 != dto.Rows.Count)
            {
                DropDownList3.Items.Add("");
                foreach (DataRow dr1 in dto.Rows)
                {

                    DropDownList3.Items.Add(dr1[0].ToString());


                }
            }
            if (DropDownList4.Items.Count - 1 != dto.Rows.Count)
            {
                DropDownList4.Items.Add("");
                foreach (DataRow dr1 in dto.Rows)
                {

                    DropDownList4.Items.Add(dr1[0].ToString());


                }
            }

        }
        #endregion
        #region bind
        protected void Bind()
        {
            DataList1.DataSource = dtx();
            DataList1.DataBind();
            DataTable dt1 = basec.getdts("SELECT * FROM WAREFILE WHERE WAREID='" + Text1.Value + "'");
            GridView1.DataSource = dt1;
            GridView1.DataKeyNames = new string[] { "FLKEY" };
            GridView1.DataBind();
        }
        #endregion
        protected DataTable dtx()
        {
            dt.Columns.Add("C", typeof(string));
            for (i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["C"] = Convert.ToString(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #region ClearText()
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
            Text10.Value  = "";
            DropDownList1.Text = "正常";
            TextBox1.Text = "";
            bind2();

        }
        #endregion
        #region btnonloadfile
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
        #endregion
        #region gridview_rowdatebound

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
        #endregion
        #region GridView1_RowDeleting
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
        #endregion
        #region  GridView1_SelectedIndexChanged
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
        #endregion
        #region  btnAdd_Click
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {
                add();

            }
            catch (Exception)
            {
            }
        }
        #endregion
        #region add()
        protected void add()
        {


            ClearText();
            GENERATE_ID();
        }
        #endregion
        #region GENERATE_ID()
        protected void GENERATE_ID()
        {
            SqlDT sqldt = new SqlDT();
            Text1.Value = sqldt.WAREID;
            /*sellunitprice*/
            string a1 = bc.numYM(10, 4, "0001", "select * from SellUnitPrice", "SPID", "SP");
            if (a1 == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                productT.SPID = a1;

            }
            /*sellunitprice*/
            Bind();
            ADD_OR_UPDATE = "ADD";


        }
        #endregion
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            save();
            if (ADD_OR_UPDATE == "ADD" && IFExecution_SUCCESS == true)
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
        #region save()
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
            string v2 = bc.getOnlyString("SELECT CO_WAREID FROM WAREINFO WHERE  WAREID='" + Text1.Value + "'");
            CUID = bc.getOnlyString("SELECT CUID FROM CUSTOMERINFO_MST WHERE CUSTOMER_ID='" + Text5.Value + "'");
            if (ac1() == 0)
            {
                IFExecution_SUCCESS = false;
            }
            else if (!bc.exists("SELECT WAREID FROM WAREINFO WHERE WAREID='" + Text1.Value + "'"))
            {

                if (bc.exists("SELECT * FROM WAREINFO WHERE CO_WAREID='" + Text2.Value + "'"))
                {

                    hint.Value = "该厂内成品料号已经存在了！";

                }
                else
                {
                   
                    SQlcommandE(sql);
                    if (DropDownList1.Text == "正常")
                    {

                        /*sellunitprice 1/1*/

                        if (!bc.exists("SELECT * FROM SELLUNITPRICE WHERE SPID='" + SPID + "'"))
                        {
                            basec.getcoms(@"insert into SELLUNITPRICE(SPID,WAREID,MakerID,
Date,Year,Month,CURRENCY,CUID) values('" + SPID + "','" + Text1.Value + "','" + varMakerID + "', '" + varDate +
                 "','" + year + "','" + month + "','"+bc.GET_RMB()+"','"+CUID +"')");
                        }
                        /*sellunitprice 1/1*/

                    }
                    IFExecution_SUCCESS = true;

                }

            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("SELECT * FROM WAREINFO WHERE CO_WAREID='" + Text2.Value + "'"))
                {

                    hint.Value = "该厂内成品料号已经存在了！";

                }
                else
                {
                    SQlcommandE(sqlo + " WHERE WAREID='" + Text1.Value + "'");
                    IFExecution_SUCCESS = true;

                }

            }
            else
            {

                SQlcommandE(sqlo + " WHERE WAREID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }


        }
        #endregion
        #region ac1()
        private int ac1()
        {

            int x = 1;
            if (Text3.Value == "")
            {
                x = 0;
                hint.Value = "品名不能为空！";
            }
            else if (Text5.Value == "")
            {
                x = 0;
                hint.Value = "该客户代码不能为空！";
            }
            else if (!bc.exists("select * from customerinfo_MST where CUSTOMER_ID='" + Text5.Value + "'"))
            {
                x = 0;
                hint.Value = "该客户代码不存在于系统中！";

            }
            else if (DropDownList2.Text == "")
            {
                x = 0;
                hint.Value = "单位不能为空！";
               
            }
            else if (DropDownList3.Text == "")
            {
                x = 0;
                hint.Value = "单位不能为空！";

            }
            else if (DropDownList4.Text == "")
            {
                x = 0;
                hint.Value = "单位不能为空！";

            }
            else if (Text6.Value == "")
            {
                x = 0;
                hint.Value = "库存单位量不能为空！";

            }
            else if (bc.yesno(Text6.Value) == 0)
            {
                x = 0;
                hint.Value = "库存单位量只能输入数字！";

            }
            else if (Text7.Value == "")
            {
                x = 0;
                hint.Value = "BOM单位量不能为空！";

            }
            else if (bc.yesno(Text7.Value) == 0)
            {
                x = 0;
                hint.Value = "BOM单位量只能输入数字！";

            }
            else if (bc.yesno(Text8.Value) == 0)
            {
                x = 0;
                hint.Value = "生产周期只能输入数字！";

            }
            return x;

        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/product.aspx" + n2);
        }
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
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@CO_WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@WNAME", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@CWAREID", SqlDbType.VarChar, 20).Value = Text4.Value;
            sqlcom.Parameters.Add("@CUID", SqlDbType.VarChar, 20).Value = CUID;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 1000).Value = TextBox1.Text;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@SPEC", SqlDbType.VarChar, 20).Value = Text10.Value;
            sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = DropDownList2.Text;
            sqlcom.Parameters.Add("@MPA_TO_STOCK", SqlDbType.VarChar, 20).Value = Text6.Value;
            sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = DropDownList3.Text;
            sqlcom.Parameters.Add("@STOCK_TO_BOM", SqlDbType.VarChar, 20).Value = Text7.Value;
            sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = DropDownList4.Text;
            sqlcom.Parameters.Add("@PRODUCTION_PHASE", SqlDbType.VarChar, 20).Value = Text8.Value;
            if (DropDownList1.Text == "正常")
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "Y";
            }
            else if (DropDownList1.Text == "Hold")
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "HOLD";
            }
            else
            {
                sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = "N";

            }

            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

        protected void btnReconcile_Click(object sender, EventArgs e)
        {
            Text2.Value = "";
            Text5.Value = "";
            Text9.Value = "";
            GENERATE_ID();
        }

    }
}
