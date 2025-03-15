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
using System.Collections.Generic;

namespace WPSS.WORKORDER_MANAGE
{
    public partial class WORKORDER_COMPLETIONT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER_COMPLETION cworkorder_completion = new CWORKORDER_COMPLETION();
      
        int i;
        string sql1 = @"
SELECT 
A.WOID AS WOID,
B.WAREID AS WAREID,
C.WO_COUNT AS WO_COUNT,
SUM(B.GECOUNT) AS GECOUNT
FROM WORKORDER_COMPLETION_DET A 
LEFT JOIN GODE B ON A.WMKEY=B.GEKEY
LEFT JOIN WORKORDER_MST C ON C.WOID=A.WOID 
";
        public static string[] NEWID = new string[] { "", "" };
        public static string[] GETID = new string[] { "" };
        string WMKEY;
        int j;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";
                Text1.Value = IDO;
                CIRCULATION_COUNT = 4;
                dt = bc.getdt(cworkorder_completion.getsql + " WHERE A.WMID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["WMID"].ToString();
                    Text5.Value = dt.Rows[0]["CNAME"].ToString();
                    Text2.Value = dt.Rows[0]["WOID"].ToString();
                    Text6.Value = dt.Rows[0]["ID"].ToString();
                    Text7.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text8.Value = dt.Rows[0]["WNAME"].ToString();
                    Text9.Value = dt.Rows[0]["CWAREID"].ToString();


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
            x2.Value = "";
            ControlFileDisplay.Value = "";
            GridView1.DataSource = as1(Text1.Value, Text2.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();


            string sql1 = cworkorder_completion .getsqlfi+ " WHERE A.WOID='" + Text2.Value + "' AND A.WMID='" + Text1.Value + "'";
            dt4 = basec.getdts(sql1);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }

            string sql3 = @"
SELECT 
DISTINCT(A.WAREID) AS WAREID,
B.FLKEY AS FLKEY,
B.OLDFILENAME AS OLDFILENAME 
FROM WORKORDER_MST 
A LEFT JOIN WAREFILE B ON A.WAREID=B.WAREID " + " WHERE A.WOID='" + Text2.Value +
"' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
            dt = basec.getdts(sql3);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "FLKEY" };
                GridView3.DataBind();
                ControlFileDisplay.Value = Convert.ToString(1);

            }
            else
            {

                GridView3.DataSource = null;
            }
            if (bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'"))
            {
                x2.Value = "exists";
            }

            dtx3 = basec.getdts("SELECT * FROM WORKORDER_COMPLETION_MST where WMID='" + Text1.Value + "'");
            if (dtx3.Rows.Count > 0)
            {

                Text3.Value = dtx3.Rows[0]["COMPLETION_DATE"].ToString();
                Text4.Value = dtx3.Rows[0]["COMPLETION_MAKERID"].ToString();
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + dtx3.Rows[0]["COMPLETION_MAKERID"].ToString() + "'");
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

            btnSure.ForeColor = System.Drawing.Color.Blue;
        }
        #endregion

        protected void btnSure_Click(object sender, EventArgs e)
        {

            if (juage())
            {
            }
            else
            {
                bind();
            }
        }

        #region ask
        private DataTable ask(string v1, string v2)
        {
            List<CWORKORDER> list = cworkorder.GET_PROGRESS_COUNT_WOID_LIST(Text2.Value);
            DataTable dtt = new DataTable();
            dtt.Columns.Add("工单号", typeof(string));
            dtt.Columns.Add("项次", typeof(int));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("工单数量", typeof(decimal));
            dtt.Columns.Add("累计领料套数", typeof(decimal));
            dtt.Columns.Add("累计退料套数", typeof(decimal));
            dtt.Columns.Add("累计报废套数", typeof(decimal));
            dtt.Columns.Add("累计入库数量", typeof(decimal));
            dtt.Columns.Add("累计报废数量", typeof(decimal));
            dtt.Columns.Add("可入库量", typeof(decimal));
            dtt.Columns.Add("未入库数量", typeof(decimal), "工单数量-累计入库数量-累计报废数量");
            dtt.Columns.Add("入库数量", typeof(decimal));
            dtt.Columns.Add("入库单位", typeof(string));
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("库位", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("本入库单累计入库数量", typeof(decimal));
            DataTable dtx1 = bc.getdt("SELECT * FROM WORKORDER_MST WHERE WOID='" + v2 + "'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i <CIRCULATION_COUNT ; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["工单号"] = dtx1.Rows[0]["WOID"].ToString();
                    dr["品号"] = dtx1.Rows[0]["WAREID"].ToString();
                    dr["项次"] = i + 1;
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[0]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["工单数量"] = dtx1.Rows[0]["WO_COUNT"].ToString();
                    dr["入库单位"] = dtx2.Rows[0]["SKU"].ToString();
                    dr["可入库量"] = cworkorder.ALLOW_GODE_COUNT;
                    dr["累计入库数量"] = 0;
                    dr["累计报废数量"] = 0;
                    dr["本入库单累计入库数量"] = 0;
                    dr["累计领料套数"] = cworkorder.TOTAL_WP_COUNT;
                    dr["累计退料套数"] = cworkorder.TOTAL_WR_COUNT;
                    dr["累计报废套数"] = cworkorder.TOTAL_WS_COUNT;
                    string STORAGENAME = bc.getOnlyString("SELECT STORAGENAME FROM STORAGEINFO WHERE WORKORDER_GODE='Y'");

                    if (!string.IsNullOrEmpty(STORAGENAME))
                    {
                        dr["仓库"] = STORAGENAME;
                    }
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT 
FROM WORKORDER_COMPLETION_DET A 
LEFT JOIN GODE B ON A.WMKEY=B.GEKEY  
WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
               
                    for (j = 0; j <CIRCULATION_COUNT ; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx4.Rows[0]["WOID"].ToString())
                        {
                            dtt.Rows[j]["累计入库数量"] = dtx4.Rows[0]["GECOUNT"].ToString();
                           
                        }

                    }
            }
            DataTable dtx7 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT 
FROM WORKORDER_SCRAP_DET A 
LEFT JOIN GODE B ON A.WSKEY=B.GEKEY  
WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,B.WAREID");
            if (dtx7.Rows.Count > 0)
            {
                
                    for (j = 0; j <CIRCULATION_COUNT ; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx7.Rows[0]["WOID"].ToString())
                        {
                            dtt.Rows[j]["累计报废数量"] = dtx7.Rows[0]["GECOUNT"].ToString();
                         
                        }

                    }
                

            }
            DataTable dtx5 = bc.getdt(@"
SELECT A.WOID AS WOID,
A.WMID AS WMID,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT 
FROM WORKORDER_COMPLETION_DET A 
LEFT JOIN GODE B ON A.WMKEY=B.GEKEY  WHERE  A.WOID='" + v2 + "' AND A.WMID='" + v1 + "' GROUP BY A.WOID,A.WMID,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                
                    for (j = 0; j < CIRCULATION_COUNT ; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx5.Rows[0]["WOID"].ToString())
                        {
                            dtt.Rows[j]["本入库单累计入库数量"] = dtx5.Rows[0]["GECOUNT"].ToString();
                           
                        }

                    }
            }
            return dtt;
        }
        #endregion
        #region as1
        private DataTable as1(string v1, string v2)
        {
            DataTable dtt = ask(v1, v2);
            for (i = 0; i < CIRCULATION_COUNT; i++)
            {
                //dtt.Rows[i]["入库数量"] = dtt.Rows[i]["未入库数量"].ToString();
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
            Text8.Value = "";
            Text7.Value = "";
            Text9.Value = "";
            Label1.Text = "";
         
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
            {

            }
            else if (GridView1.Rows.Count > 0)
            {
              
                add();

            }
            else
            {
                hint.Value = "点击确定带出工单信息！";
            }

            try
            {


            }
            catch (Exception)
            {

            }
        }
        private bool juage()
        {
            string v = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'");
            bool b = false;
            if (!bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'"))
            {
                hint.Value = "工单号为空或不存在于系统中！";
                b = true;

            }
            else if (v == "CLOSE")
            {
                hint.Value = "此工单号已经结案，不能再做完工入库！";
                b = true;

            }
            else if (v == "CANCEL")
            {
                hint.Value = "此工单号已经作废，不能再做完工入库！";
                b = true;

            }
            else if (bc.JuageWOID_IFNOHAVE_PICKING(Text2.Value))
            {
                
                hint.Value = bc.ErrowInfo;
                b = true;
            }
            else if (bc.JuageDeleteCount_MoreThanStorageCount(Text1.Value))
            {
                hint.Value = bc.ErrowInfo;
                b = true;
            }
            else if (bc.exists("SELECT * FROM WORKORDER_COMPLETION_MST WHERE WMID='"+Text1.Value +"'"))
            {
            
                hint.Value = "此入库单已经存在系统中，不能再保存！";
                b = true;
                
            }
            return b;
        }
        #region add
        protected void add()
        {

            hint.Value = "";
            string sql2 = "SELECT * FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'";
            dt1 = basec.getdts(sql2);
     
            if (dt1.Rows.Count > 0)
            {

                int count = dt1.Rows.Count;
                 if (!ac0(Text1.Value, Text2.Value))
                {

                }
                else if (Text4.Value == "")
                {

                    hint.Value = "工号不能为空！";

                }
                else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
                {
                    hint.Value = "入库员工工号不存在于系统中！";
                }
                else if (WMKEY == "Exceed Limited")
                {
                    hint.Value = "编码超出限制！";

                }

                else
                {
                    add2();
                }

            }

        }
        #endregion
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
            List<CWORKORDER> list = cworkorder.GET_PROGRESS_COUNT_WOID_LIST(Text2.Value);
            for (k = 0; k <CIRCULATION_COUNT ; k++)
            {
                if (ac1(k) == 0)
                {
                   
                }
                else
                {
                    WMKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WORKORDER_COMPLETION_DET", "WMKEY", "WM");
                    string WM_COUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                    //string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string NEEDDATE = bc.getOnlyString("SELECT GODE_NEED_DATE FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'");

                    SQlcommandE(cworkorder_completion.getsqlo, WMKEY, REMARK);/*WORKORDER_COMPLETION_DET*/
                    SQlcommandE(cworkorder_completion.getsqlf, WMKEY, WAREID, WM_COUNT, STORAGEID, SLID, BATCHID);
                    for (int n = 0; n < CIRCULATION_COUNT  ; n++)
                    {
                        ((TextBox)GridView1.Rows[n].Cells[16].FindControl("TextBox17")).Text = cworkorder.ALLOW_GODE_COUNT;
                        ((TextBox)GridView1.Rows[n].Cells[6].FindControl("TextBox7")).Text = cworkorder.HAVE_NO_GODE_COUNT ;
                    }
                 
                }
            }
            cworkorder.UPDATE_WORKORDER_STATUS(Text2.Value);
            if (!bc.exists("SELECT WMID FROM WORKORDER_COMPLETION_DET WHERE WMID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT WMID FROM WORKORDER_COMPLETION_MST WHERE WMID='" + Text1.Value + "'"))
            {

                SQlcommandE(cworkorder_completion.getsqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cworkorder_completion.getsqlth + " WHERE WMID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;

            }
            bind();
        }
        #endregion

        #region ac1()
        private int ac1(int k)
        {
            int x = 1;
            string v1 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string v2 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
            string v3 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
            string v4 = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
            string v6 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string v7 = ((TextBox)GridView1.Rows[k].Cells[16].FindControl("TextBox17")).Text;
            if (v1 == "")
            {

                x = 0;
                hint.Value = "数量不能为空！";

            }
            else if (bc.yesno(v1) == 0)
            {
                x = 0;
                hint.Value = "数量只能输入数字！";

            }
            else if (v2 == "")
            {
                x = 0;
                hint.Value = "仓库不能为空！";

            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + v2 + "'"))
            {
                x = 0;
                hint.Value = "该仓库不存在于系统中！";


            }
            else if (v6 == "")
            {
                x = 0;
                hint.Value = "库位不能为空！";

            }
            else if (!bc.exists("SELECT * FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + v6 + "'"))
            {
                x = 0;
                hint.Value = "该库位不存在于系统中！";


            }
            else if (v4 == "")
            {
                x = 0;
                hint.Value = "批号不能为空！";


            }
            else if (decimal.Parse(v1) <= 0)
            {
                x = 0;
                hint.Value = "入库数量需大于0！";


            }
            /* else if (v5!="" && decimal.Parse(v5) <= 0)
             {
                 x = 0;
                 hint.Value = "Free数量需大于0！";


             }*/
            else if (decimal.Parse(v1) > decimal.Parse(v7))
            {
                x = 0;
                hint.Value = "入库数量不能大于可入库量！";
               
            }
            else if (decimal.Parse(v1) > decimal.Parse(v3))
            {
                x = 0;
                hint.Value = "入库数量不能大于未入库数量！";
             
            }

            return x;

        }
        #endregion
        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM WORKORDER_COMPLETION_DET WHERE WMID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT WOID FROM WORKORDER_COMPLETION_DET WHERE WMID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个入库单下面只能出现一个工单号!";
                    c = false;
                }
            }
            return c;

        }
        #region SQlcommandE
        protected void SQlcommandE(string sql, string WMKEY, string REMARK)
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
            sqlcom.Parameters.Add("@WMKEY", SqlDbType.VarChar, 20).Value = WMKEY;
            sqlcom.Parameters.Add("@WMID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = Text2.Value;
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
            sqlcom.Parameters.Add("@WMID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@COMPLETION_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@COMPLETION_MAKERID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        protected void SQlcommandE(string sql, string GEKEY, string WAREID,
            string GECOUNT, string STORAGEID, string SLID, string BATCHID)
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
            sqlcom.Parameters.Add("@GEKEY", SqlDbType.VarChar, 20).Value = GEKEY;
            sqlcom.Parameters.Add("@GODEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@GECOUNT", SqlDbType.VarChar, 20).Value = GECOUNT;
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_COMPLETION_MST", "WMID", "WM");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_completion.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql2, sql3;
            hint.Value = "";
            string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
            sql2 = "DELETE FROM WORKORDER_COMPLETION_MST WHERE WMID='" + Text1.Value + "'";
            sql3 = "DELETE FROM WORKORDER_COMPLETION_DET WHERE WMID='" + Text1.Value + "'";
            string s1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'");
            if (bc.JuageDeleteCount_MoreThanStorageCount(Text1.Value))
            {

                hint.Value = bc.ErrowInfo;
            }
            else
            {
                basec.getcoms(sql3);
                basec.getcoms("DELETE GODE WHERE GODEID='" + Text1.Value + "'");
                if (!bc.exists("SELECT * FROM WORKORDER_COMPLETION_DET WHERE WMID='" + Text1.Value + "'"))
                {
                    basec.getcoms(sql2);
                }
                string NEEDDATE = bc.getOnlyString("SELECT GODE_NEED_DATE FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "' ");
                string sql4 = sql1 + " WHERE  A.WOID='" + Text2.Value + "' GROUP BY A.WOID,B.WAREID,C.WO_COUNT";

                dt3 = basec.getdts(sql4);
                if (dt3.Rows.Count > 0)
                {
                    if (bc.JuageCurrentDateIFAboveDeliveryDate(Text2.Value, 2))
                    {

                        basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='DELAY' WHERE WOID='" + Text2.Value + "'");
                    }
                    else
                    {
                        basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='PROGRESS' WHERE WOID='" + Text2.Value + "'");
                    }
                }
                else if (bc.JuageCurrentDateIFAboveDeliveryDate(Text2.Value, 2))
                {

                    basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='DELAY' WHERE WOID='" + Text2.Value + "'");
                }
                else
                {
                    basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='OPEN' WHERE WOID='" + Text2.Value + "'");

                }
                GridView1.EditIndex = -1;
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
    }
}
