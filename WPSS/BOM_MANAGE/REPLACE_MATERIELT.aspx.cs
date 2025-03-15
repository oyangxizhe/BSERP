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
namespace WPSS.BOM_MANAGE
{
    public partial class REPLACE_MATERIELT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        basec bc = new basec();
        XizheC.CBOM cbom = new CBOM();
        WPSS.Validate va = new Validate();
        CFileInfo cfileinfo = new CFileInfo();
        CWARE_INFO cware_info = new CWARE_INFO();
        CREPLACE_MATERIEL creplace_materiel = new CREPLACE_MATERIEL();
        int i;
        private string _BEFORE_WAREID;
        public string BEFORE_WAREID
        {
            set { _BEFORE_WAREID = value; }
            get { return _BEFORE_WAREID; }

        }
        #region nature
        string RMKEY;
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
        private static bool _IFExecutionSUCCESS;
        public static bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private static bool _SAVE_OR_EDIT;
        public static bool SAVE_OR_EDIT
        {
            set { _SAVE_OR_EDIT = value; }
            get { return _SAVE_OR_EDIT; }

        }
        private static int _EXECUTIONS;
        public static int EXECUTIONS
        {
            set { _EXECUTIONS = value; }
            get { return _EXECUTIONS; }

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Text1.Value = IDO;
                EXECUTIONS = 10;
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
            x2.Value = "";
            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();
            IFExecution_SUCCESS = false;

            string sql2 = creplace_materiel.sql + " WHERE A.RMID='" + Text1.Value + "' ORDER BY A.RMKEY";
            dt1 = basec.getdts(sql2);
            if (dt1.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView2.DataSource = dt1;
                GridView2.DataKeyNames = new string[] { "索引" };
                GridView2.DataBind();

            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }

            dt = basec.getdts(creplace_materiel.sql + " where A.RMID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["ID"].ToString();
                Text3.Value = dt.Rows[0]["料号"].ToString();
                Text4.Value = dt.Rows[0]["品名"].ToString();
                Text5.Value = dt.Rows[0]["客户料号"].ToString();
                Text8.Value = dt.Rows[0]["客户名称"].ToString();
                Text9.Value = dt.Rows[0]["规格"].ToString();
            }
            else
            {

                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            }
        }
        #endregion
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text8.Value = "";
            Text9.Value = "";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            hint.Value = "";
            if (ac1() == 0)
            {
            }
            else if (Text2.Value == "")
            {
                hint.Value = "ID不能为空！";
            }
            else if (!bc.exists("SELECT * FROM WAREINFO WHERE WAREID='" + Text2.Value + "' AND ACTIVE='Y'"))
            {

                hint.Value = "ID：" + Text2.Value + "不存在于系统中或状态不为正常！";

            }

            else if (RMKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
            }
            else
            {
                SAVE_OR_EDIT = true;
                save();
                if (IFExecution_SUCCESS == true)
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
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            edit();
        }
        private void edit()
        {
            try
            {
                hint.Value = "";
                if (ac1_edit() == 0)
                {
                }
                else if (RMKEY == "Exceed Limited")
                {
                    hint.Value = "编码超出限制！";
                }
                else
                {
                    SAVE_OR_EDIT = false;
                    save();
                    if (IFExecution_SUCCESS == true)
                    {
                        bind();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        #region save
        private void save()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string v2 = bc.getOnlyString("SELECT WAREID FROM REPLACE_MATERIEL_MST WHERE  RMID='" + Text1.Value + "'");
        
            if (!bc.exists("SELECT RMID FROM REPLACE_MATERIEL_MST WHERE RMID='" + Text1.Value + "'"))
            {
                if (bc.exists("SELECT * FROM REPLACE_MATERIEL_MST WHERE WAREID='" + Text2.Value + "'"))
                {
                    hint.Value = "该料号在系统中已经存在了！";
                }
                else
                {
                    if (SAVE_OR_EDIT == true)
                    {
                        save_det();
                    }
                    else
                    {
                        save_det_edit();
                    }
                }
            }
            else
            {
                if (v2 != Text2.Value)
                {
                    if (bc.exists("SELECT * FROM REPLACE_MATERIEL_MST WHERE WAREID='" + Text2.Value + "'"))
                    {
                        hint.Value = "该料号在系统中已经存在了！";

                    }
                    else
                    {
                        if (SAVE_OR_EDIT == true)
                        {
                            save_det();
                        }
                        else
                        {
                            save_det_edit();
                        }
                    }
                }
                else
                {
                    if (SAVE_OR_EDIT == true)
                    {
                        save_det();
                    }
                    else
                    {
                        save_det_edit();
                    }
                }

            }


            if (!bc.exists("SELECT * FROM REPLACE_MATERIEL_DET WHERE RMID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT RMID FROM REPLACE_MATERIEL_MST WHERE RMID='" + Text1.Value + "'"))
            {
                if (bc.exists("SELECT * FROM REPLACE_MATERIEL_MST WHERE WAREID='" + Text2.Value + "'"))
                {
                    hint.Value = "该料号在系统中已经存在了！";
                }
                else
                {
                    SQlcommandE(creplace_materiel.sqlt);
                    IFExecution_SUCCESS = true;
                }
            }
            else
            {
                if (v2 != Text2.Value)
                {
                    if (bc.exists("SELECT * FROM REPLACE_MATERIEL_MST WHERE WAREID='" + Text2.Value + "'"))
                    {
                        hint.Value = "该料号在系统中已经存在了！";

                    }
                    else
                    {
                        SQlcommandE(creplace_materiel.sqlth + " WHERE RMID='" + Text1.Value + "'");
                        IFExecution_SUCCESS = true;
                    }
                }
                else
                {
                    SQlcommandE(creplace_materiel.sqlth + " WHERE RMID='" + Text1.Value + "'");
                    IFExecution_SUCCESS = true;
                }

            }

        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql, string KEY, string sn, string v1, string v2, string v3, string v4, string v5, string v6, string v7)
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
            sqlcom.Parameters.Add("@RMKEY", SqlDbType.VarChar, 20).Value = KEY;
            sqlcom.Parameters.Add("@RMID", SqlDbType.VarChar, 20).Value = Text1.Value;
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
            sqlcom.Parameters.Add("@BIT_NUMBER", SqlDbType.VarChar, 20).Value = v7;
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
            sqlcom.Parameters.Add("@RMID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region ac1()
        private int ac1()
        {

            int x = 1;
            for (int k = 0; k < EXECUTIONS; k++)
            {

                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView1.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v7 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                string v8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*picking_stage*/


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
                    hint.Value = "组成用量不能为空！";
                    break;
                }
                else if (bc.yesno(v6) == 0)
                {
                    x = 0;
                    hint.Value = "组成用量只能输入数字！";
                    break;

                }
                else if (v8 == "")
                {
                    x = 0;
                    hint.Value = "损耗率不能为空！";
                    break;

                }
                else if (bc.yesno(v8) == 0)
                {
                    x = 0;
                    hint.Value = "损耗率只能输入数字！";
                    break;

                }
                else if (v9 != "" && !bc.exists("select * from picking_stage where picking_stage='" + v9 + "'"))
                {
                    x = 0;
                    hint.Value = "该发料阶段：" + v9 + " 不存在于系统中！";
                    break;
                }
            }
            return x;

        }
        #endregion
        #region ac1_edit()
        private int ac1_edit()
        {

            int x = 1;
            for (int k = 0; k < GridView2.Rows.Count; k++)
            {

                string v1 = ((TextBox)GridView2.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v2 = ((TextBox)GridView2.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string v3 = ((TextBox)GridView2.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string v4 = ((TextBox)GridView2.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                string v5 = ((TextBox)GridView2.Rows[k].Cells[4].FindControl("TextBox5")).Text;
                string v6 = ((TextBox)GridView2.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v7 = ((TextBox)GridView2.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                string v8 = ((TextBox)GridView2.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((TextBox)GridView2.Rows[k].Cells[8].FindControl("TextBox9")).Text;/*picking_stage*/

                DateTime temp = DateTime.MinValue;
                if (v1 == "")
                {

                }
                else if (!bc.exists("select * from WAREinfo where WAREid='" + v1 + "' AND ACTIVE='Y'"))
                {
                    x = 0;
                    hint.Value = "品号：" + v1 + " 不存在于系统中或状态不为正常！";
                    break;
                }

                else if (v6 == "")
                {

                    x = 0;
                    hint.Value = "组成用量不能为空！";
                    break;
                }
                else if (bc.yesno(v6) == 0)
                {
                    x = 0;
                    hint.Value = "组成用量只能输入数字！";
                    break;

                }
                else if (v8 == "")
                {
                    x = 0;
                    hint.Value = "损耗率不能为空！";
                    break;

                }
                else if (bc.yesno(v8) == 0)
                {
                    x = 0;
                    hint.Value = "损耗率只能输入数字！";
                    break;

                }
                else if (v9 != "" && !bc.exists("select * from picking_stage where picking_stage='" + v9 + "'"))
                {
                    x = 0;
                    hint.Value = "该发料阶段：" + v9 + " 不存在于系统中！";
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
        private void save_det()
        {
            int k;

            for (k = 0; k < EXECUTIONS; k++)
            {
                string s1;
                int s2;
                string SN;
                string v1 = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v6 = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v8 = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((DropDownList)GridView1.Rows[k].Cells[0].FindControl("DropDownList1")).Text;
                string v10 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                string v11 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                string v12 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                if (v1 != "")
                {

                    RMKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM REPLACE_MATERIEL_DET", "RMKEY", "RM");
                    DataTable dty = bc.getdt("SELECT * FROM REPLACE_MATERIEL_DET WHERE RMID='" + Text1.Value + "'");
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
                    SQlcommandE(creplace_materiel.sqlo, RMKEY, SN, v1, v6, v8, v9, v10, v11, v12);

                }
            }
            IFExecution_SUCCESS = true;
        }
        private void save_det_edit()
        {
            basec.getcoms("DELETE REPLACE_MATERIEL_DET WHERE RMID='" + Text1.Value + "'");
            int k;
            int s2 = 1;
            string SN;
            for (k = 0; k < GridView2.Rows.Count; k++)
            {
                string v1 = ((TextBox)GridView2.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string v6 = ((TextBox)GridView2.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                string v8 = ((TextBox)GridView2.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string v9 = ((DropDownList)GridView2.Rows[k].Cells[0].FindControl("DropDownList1")).Text;
                string v10 = ((TextBox)GridView2.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                string v11 = ((TextBox)GridView2.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                string v12 = ((TextBox)GridView2.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                if (v1 != "")
                {

                    RMKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM REPLACE_MATERIEL_DET", "RMKEY", "RM");
                    SN = Convert.ToString(s2);
                    SQlcommandE(creplace_materiel.sqlo, RMKEY, SN, v1, v6, v8, v9, v10, v11, v12);
                    s2 = Convert.ToInt32(s2) + 1;
                }
            }
            IFExecution_SUCCESS = true;
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

            /*try
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

            }*/
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
        }
        protected void add()
        {
            ClearText();
            GENERATE_ID();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../bom_manage/replace_materiel.aspx" + n2);
        }
        protected DataTable dtx()
        {

            DataTable dt4 = emptydatatable();
            for (i = 1; i <= EXECUTIONS; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dr["客供否"] = "N";
                dr["组成用量"] = 1;
                dr["损耗率"] = 0;
                dt4.Rows.Add(dr);
            }
            return dt4;
        }
        protected DataTable dtx1()
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
        protected DataTable emptydatatable()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("BOM编号", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("BOM版本", typeof(string));
            dtt.Columns.Add("BOM日期", typeof(string));
            dtt.Columns.Add("子ID", typeof(string));
            dtt.Columns.Add("子料号", typeof(string));
            dtt.Columns.Add("子品名", typeof(string));
            dtt.Columns.Add("子客户料号", typeof(string));
            dtt.Columns.Add("子规格", typeof(string));
            dtt.Columns.Add("品牌", typeof(string));
            dtt.Columns.Add("BOM单位", typeof(string));
            dtt.Columns.Add("生效否", typeof(string));
            dtt.Columns.Add("组成用量", typeof(string));
            dtt.Columns.Add("损耗率", typeof(string));
            dtt.Columns.Add("客供否", typeof(string));
            dtt.Columns.Add("发料阶段", typeof(string));
            dtt.Columns.Add("位号", typeof(string));
            dtt.Columns.Add("备注", typeof(string));
            return dtt;
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

            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM REPLACE_MATERIEL_MST", "RMID", "RM");
            edit();
            ADD_OR_UPDATE = "ADD";
        }
        #region GENERATE_ID()
        protected void GENERATE_ID()
        {
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM REPLACE_MATERIEL_MST", "RMID", "RM");
            bind();
            ADD_OR_UPDATE = "ADD";
        }
        #endregion
        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnOnloadFile_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception)
            {

            }
        }


        protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            /* try
             {
                 string id = GridView4.DataKeys[e.RowIndex][0].ToString();
                 delete_wareid_file(id);
             
             }
             catch (Exception)
             {


             }
             */
        }
        protected void delete_wareid_file(string v1)
        {
            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + v1 + "'");
            string s1 = Server.MapPath(FilePath);
            if (File.Exists(s1))
            {
                File.Delete(s1);
            }
            string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + v1 + "'";
            basec.getcoms(strSql);
            GridView1.EditIndex = -1;
            bind();
        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try
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
             */
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

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql1;
            hint.Value = "";
            hint.Value = "";
            x.Value = "";
            x1.Value = "";
            x2.Value = "";
            string id = GridView2.DataKeys[e.RowIndex][0].ToString();
            sql1 = "DELETE FROM REPLACE_MATERIEL_DET WHERE RMKEY='" + id + "'";
       
            if (bc.juageOne("SELECT * FROM REPLACE_MATERIEL_DET WHERE RMID='" + Text1.Value + "'"))
            {

                basec.getcoms(sql1);
                string sql = "DELETE REPLACE_MATERIEL_MST WHERE RMID='" + Text1.Value + "'";
                basec.getcoms(sql);
                GridView2.EditIndex = -1;
                basec.getcoms("DELETE WAREFILE WHERE WAREID='" + Text1.Value + "'");
                bind();
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

    }
}
