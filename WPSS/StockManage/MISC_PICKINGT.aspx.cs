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
namespace WPSS.STOCKMANAGE
{
    public partial class MISC_PICKINGT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
        XizheC.CBOM cbom = new CBOM();
        CCO_ORDER cco_order = new CCO_ORDER();
        CMRP cmrp = new CMRP();
        CMISC_PICKING cMISC_picking = new CMISC_PICKING();

        WPSS.Validate va = new Validate();
        int i = 0;
        DataTable dt4 = new DataTable();
        #region nature
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
        private static string _SKU;
        public static string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private static int _CIRCULATION_COUNT;
        public static int CIRCULATION_COUNT
        {
            set { _CIRCULATION_COUNT = value; }
            get { return _CIRCULATION_COUNT; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        #endregion
        PrintSellTableBill print = new PrintSellTableBill();
        string MPKEY;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Text1.Value = IDO;
                dt = bc.getdt(cMISC_picking.sql + " WHERE A.MPID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["MPID"].ToString();
                    Text3.Value = dt.Rows[0]["PICKING_DATE"].ToString();
                    Text4.Value = dt.Rows[0]["PICKING_MAKERID"].ToString();
                }
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
            CUKEY.Value = "";
            ControlFileDisplay.Value = "";
            CIRCULATION_COUNT = 10;

            GridView1.DataSource = dtx();
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            dt4 = cMISC_picking.ask(Text1.Value);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataKeyNames = new string[] { "索引" };
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            dtx3 = cMISC_picking.ask(Text1.Value);
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["领料日期"].ToString();
                Text4.Value = dtx3.Rows[0]["领料员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["领料员"].ToString();
            }
            else
            {
                string n1 = Request.Url.AbsoluteUri;
                string n2 = n1.Substring(n1.Length - 10, 10);
                string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
                Text3.Value = DateTime.Now.ToString("yyy-MM-dd");
                Text4.Value = varMakerID;
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + varMakerID + "'");
            }
        }
        #endregion
        protected DataTable dtx()
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("项次", typeof(string));
            for (i = 1; i <= CIRCULATION_COUNT; i++)
            {
                DataRow dr = dt4.NewRow();
                dr["项次"] = Convert.ToString(i);
                dt4.Rows.Add(dr);
            }
            return dt4;
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {
            hint.Value = "";
            if (juage())
            {

            }
            else
            {

                bind();
            }

        }
        private bool juage()
        {

            bool b = false;
            if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
            {
                hint.Value = "领料员工工号不存在于系统中！";
                b = true;
            }
            else if (bc.exists("SELECT * FROM MISC_PICKING_MST WHERE MPID='" + Text1.Value + "'"))
            {

                hint.Value = "此领料单已经存在系统中，不能再保存！";
                b = true;
            }
            else if (MPKEY == "Exceed Limited")
            {
                hint.Value = "编码超出限制！";
                b = true;
            }
            /*else if (Text10.Value == "0.00")
            {
                hint.Value = "领料套数需大于0！";
                b = false;
            }
           */
            return b;
        }


        protected void ClearText()
        {
            Text3.Value = "";
            Text4.Value = "";
            Label1.Text = "";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
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


        #region add2
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
            int count = GridView1.Rows.Count;
            string s1;
            int s2;
            for (k = 0; k < GridView1.Rows.Count; k++)
            {

                if (ac1(k))
                {

                   
                }
                else
                {

                    MPKEY = bc.numYMD(20, 12, "000000000001", "select * from MISC_PICKING_DET", "MPKEY", "MP");
                    string MPCOUNT = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                    string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                    if (WAREID == "")
                    {
                      
                    }
                    else
                    {
                        
                        DataTable dty = bc.getdt("SELECT * FROM MISC_PICKING_DET WHERE MPID='" + Text1.Value + "'");
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
                        SQlcommandE(cMISC_picking.sqlo, MPKEY, SN, REMARK);
                        SQlcommandE(cMISC_picking.sqlf, MPKEY, WAREID, SN, MPCOUNT, STORAGEID, SLID, BATCHID);
                        DataTable dtx6 = bc.getmaxstoragecount(WAREID, SKU);
                        if (dtx6.Rows.Count > 0)
                        {
                            for (int n = 0; n < count; n++)
                            {
                                if (((TextBox)GridView1.Rows[n].Cells[0].FindControl("TextBox1")).Text == WAREID)
                                {
                                    ((TextBox)GridView1.Rows[n].Cells[5].FindControl("TextBox6")).Text = dtx6.Rows[0]["仓库"].ToString();
                                    ((TextBox)GridView1.Rows[n].Cells[6].FindControl("TextBox7")).Text = dtx6.Rows[0]["库位"].ToString();
                                    ((TextBox)GridView1.Rows[n].Cells[7].FindControl("TextBox8")).Text = dtx6.Rows[0]["批号"].ToString();
                                    ((TextBox)GridView1.Rows[n].Cells[8].FindControl("TextBox9")).Text = dtx6.Rows[0]["库存数量"].ToString();
                                }
                            }
                        }
                        else
                        {
                            
                            for (int n = 0; n < count; n++)
                            {
                                if (((TextBox)GridView1.Rows[n].Cells[0].FindControl("TextBox1")).Text == WAREID)
                                {
                                    ((TextBox)GridView1.Rows[n].Cells[5].FindControl("TextBox6")).Text = "";
                                    ((TextBox)GridView1.Rows[n].Cells[6].FindControl("TextBox7")).Text = "";
                                    ((TextBox)GridView1.Rows[n].Cells[7].FindControl("TextBox8")).Text = "";
                                    ((TextBox)GridView1.Rows[n].Cells[8].FindControl("TextBox9")).Text = "";
                                }
                            }
                        }
                    }
                }

            }/*under FOR OUTSIDE*/

            if (!bc.exists("SELECT MPID FROM MISC_PICKING_DET WHERE MPID='" + Text1.Value + "'"))
            {
               
                return;
            }
            if (!bc.exists("SELECT MPID FROM MISC_PICKING_MST WHERE MPID='" + Text1.Value + "'"))
            {

                SQlcommandE(cMISC_picking.sqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cMISC_picking.sqlth + " WHERE MPID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }

            bind();
        }
        #endregion

        #region ac1()
        private bool ac1(int k)
        {
          
            bool b = false;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
            string MPCOUNT = ((TextBox)GridView1.Rows[k].Cells[3].FindControl("TextBox4")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[5].FindControl("TextBox6")).Text;
            string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
           
            SKU= bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + WAREID + "'");
            string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME, STORAGE_LOCATION, BATCHID, SKU);
            if (WAREID == "")
            {
                b = true;
            }
            else if (string.IsNullOrEmpty (MPCOUNT ))
            {
                b = true;
                hint.Value = "领用量不能为空或为0！";
              
            }
            else if (bc.yesno(MPCOUNT) == 0)
            {
                b = true;
                hint.Value = "数量只能输入数字！";
            }
            else if (STORAGENAME == "")
            {
                b = true;
                hint.Value = "仓库不能为空！";

            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'"))
            {
                b = true;
                hint.Value = "该仓库不存在于系统中！";
            }
            else if (STORAGE_LOCATION == "")
            {
                b = true;
                hint.Value = "库位不能为空！";
            }
            else if (!bc.exists("SELECT * FROM Storage_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'"))
            {
                b = true;
                hint.Value = "该库位不存在于系统中！";
            }
            else if (BATCHID == "")
            {
                b = true;
                hint.Value = "批号不能为空！";
            }

            /*else if (decimal.Parse(MPCOUNT) > decimal.Parse(NOMPCOUNT))
            {
                b=true;
                hint.Value = "领用量不能大于未领用量！";
            }*/
            else if (k1 != STORAGECOUNT)
            {
                b = true;
                hint.Value = "选择的库存品号与此项次领料品号不一致！";
            }
            else if (decimal.Parse(MPCOUNT) > decimal.Parse(STORAGECOUNT))
            {
                b = true;

                hint.Value = "领用量不能大于库存数量！";
            }
         
            return b;
        }
        #endregion

        #region SQlcommandE
        protected void SQlcommandE(string sql, string MPKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@MPKEY", SqlDbType.VarChar, 20).Value = MPKEY;
            sqlcom.Parameters.Add("@MPID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@REMARK", SqlDbType.VarChar, 20).Value = REMARK;
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
            sqlcom.Parameters.Add("@MPID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@PICKING_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@PICKING_MAKERID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        protected void SQlcommandE(string sql, string MRKEY, string WAREID, string SN,
            string MRCOUNT, string STORAGEID, string SLID, string BATCHID)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string SKU = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + WAREID + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@MRKEY", SqlDbType.VarChar, 20).Value = MRKEY;
            sqlcom.Parameters.Add("@MATEREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@MRCOUNT", SqlDbType.VarChar, 20).Value = MRCOUNT;
            sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = SKU;
            sqlcom.Parameters.Add("@STORAGEID", SqlDbType.VarChar, 20).Value = STORAGEID;
            sqlcom.Parameters.Add("@SLID", SqlDbType.VarChar, 20).Value = SLID;
            sqlcom.Parameters.Add("@BATCHID", SqlDbType.VarChar, 20).Value = BATCHID;
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
            ClearText();
            Text1.Value = cMISC_picking.GETID;
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../stockmanage/misc_picking.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql2, sql3;
            hint.Value = "";
            string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
            sql2 = "DELETE FROM MISC_PICKING_MST WHERE MPID='" + Text1.Value + "'";
            sql3 = "DELETE FROM MISC_PICKING_DET WHERE MPID='" + Text1.Value + "' AND SN='" + ID + "'";

            basec.getcoms(sql3);
            basec.getcoms("DELETE  MATERE WHERE MATEREID='" + Text1.Value + "' AND SN='" + ID + "'");
            if (!bc.exists("SELECT * FROM MISC_PICKING_DET WHERE MPID='" + Text1.Value + "'"))
            {
                basec.getcoms(sql2);
            }
            GridView1.EditIndex = -1;
            bind();


            try
            {


            }
            catch (Exception)
            {


            }
        }
        #endregion

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



        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
           
        }
        #region gridview2 delete
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql;
            string sql1;
            hint.Value = "";
            string id = GridView2.DataKeys[e.RowIndex][0].ToString();
            
            sql1 = "DELETE FROM MISC_PICKING_DET WHERE MPKEY='" + id + "'";
            if (bc.juageOne("SELECT * FROM MISC_PICKING_DET WHERE MPID='" + Text1.Value + "'"))
            {
                basec.getcoms(sql1);
                sql = "DELETE MISC_PICKING_MST WHERE MPID='" + Text1.Value + "'";
                basec.getcoms(sql);
                basec.getcoms("DELETE MATERE WHERE MRKEY='"+id+"'");
                GridView2.EditIndex = -1;
                bind();
            }
            else
            {
                basec.getcoms(sql1);
                GridView2.EditIndex = -1;
                basec.getcoms("DELETE MATERE WHERE MRKEY='" + id + "'");
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
        protected void excelprint()
        {


            try
            {
                DataTable dtn = print.askt(Text1.Value);
                if (dtn.Rows.Count > 1)
                {

                    int i = dtn.Rows.Count - 1;
                    if (i > 0 && i <= 10)
                    {
                        if (bc.JuagePrintModelIfExists(1, "SE"))
                        {

                            bc.ExcelPrint(dtn, "领料单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else if (i > 10 && i <= 20)
                    {
                        if (bc.JuagePrintModelIfExists(2, "SE"))
                        {

                            bc.ExcelPrint(dtn, "领料单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else
                    {
                        hint.Value = "一张领料单最多支持打印20个领料项。超出20请建多张领料单！";

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
