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

namespace WPSS.WORKORDER_MANAGE
{
    public partial class WORKORDER_REPICKINGT : System.Web.UI.Page
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
        XizheC.CBOM cbom = new CBOM();
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER_REPICKING cworkorder_repicking = new CWORKORDER_REPICKING();
        int i;
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

        string WRKEY;
        int j;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Text1.Value = IDO;
                dt = bc.getdt(cworkorder_repicking.getsql + " WHERE A.WRID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["WRID"].ToString();
                    Text5.Value = dt.Rows[0]["CNAME"].ToString();
                    Text2.Value = dt.Rows[0]["WOID"].ToString();
                    Text6.Value = dt.Rows[0]["ID"].ToString();
                    Text7.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text8.Value = dt.Rows[0]["WNAME"].ToString();
                    Text9.Value = dt.Rows[0]["CWAREID"].ToString();
                    Text3.Value = dt.Rows[0]["REPICKING_DATE"].ToString();
                    Text4.Value = dt.Rows[0]["REPICKING_MAKERID"].ToString();
                    Text10.Value = dt.Rows[0]["WR_COUNT"].ToString();
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
            CUKEY.Value = "";
            ControlFileDisplay.Value = "";
            GridView1.DataSource = as1(Text1.Value, Text2.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();
           
            string sql1 = cworkorder_repicking.getsqlfi + " WHERE A.WOID='" + Text2.Value + "' AND A.WRID='" + Text1.Value + "'";
            dt4 = basec.getdts(sql1);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }

            string sql3 = @"
SELECT 
DISTINCT(A.DET_WAREID) AS WAREID,
B.FLKEY AS FLKEY,
B.OLDFILENAME AS OLDFILENAME 
FROM 
WORKORDER_DET A 
LEFT JOIN WAREFILE B ON A.DET_WAREID=B.WAREID 
WHERE A.WOID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.DET_WAREID,B.FLKEY,B.OLDFILENAME";
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

            dtx3 = basec.getdts(cworkorder_repicking.getsqlfi + " where A.WRID='" + Text1.Value + "'");
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["退料日期"].ToString();
                Text4.Value = dtx3.Rows[0]["退料员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["退料员"].ToString();

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
                hint.Value = "此工单号已经结案，不能再做退料！";
                b = true;

            }
            else if (v == "CANCEL")
            {
                hint.Value = "此工单号已经作废，不能再做退料！";
                b = true;

            }
            else if (!bc.exists("SELECT * FROM WORKORDER_PICKING_MST WHERE WOID='" + Text2.Value + "'"))
            {
                hint.Value = "此工单号没有领料记录，不能做退料！";
                b = true;

            }
            else if (bc.yesno(Text10.Value) == 0)
            {
                hint.Value = "数量只能输入数字";
                b = true;
            }
            else if (cworkorder.JUAGE_ALLOW_REPICKING_COUNT(Text2.Value, Text10.Value))
            {
                hint.Value = cworkorder.ErrowInfo;
                b = true;

            }
            else if (bc.exists("SELECT * FROM WORKORDER_REPICKING_MST WHERE WRID='" + Text1.Value + "'"))
            {
                hint.Value = "此退料单已经存在系统中，不能再保存！";
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
        #region ask
        private DataTable ask(string v1, string v2)
        {
           
            DataTable dtt = cworkorder_repicking.dt_empty();
            DataTable dtx1 = bc.getdt("SELECT * FROM WORKORDER_DET WHERE WOID='" + v2 + "'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["工单号"] = dtx1.Rows[i]["WOID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["子ID"] = dtx1.Rows[i]["DET_WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["DET_WAREID"].ToString() + "'");
                    dr["子料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["子品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["子规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["子客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    decimal d1 = (decimal.Parse(dtx1.Rows[i]["UNIT_DOSAGE"].ToString()) +
                       decimal.Parse(dtx1.Rows[i]["ATTRITION_DOSAGE"].ToString())) * decimal.Parse(Text10.Value);
                    DataView dv = new DataView(cworkorder.ask());
                    dv.RowFilter = "工单号='"+Text2.Value +"'";
                    dt = dv.ToTable();
             
                    decimal d2 = (decimal.Parse(dtx1.Rows[i]["UNIT_DOSAGE"].ToString()) +
                    decimal.Parse(dtx1.Rows[i]["ATTRITION_DOSAGE"].ToString())) * decimal.Parse(dt.Rows[0]["累计工单入库数量"].ToString());
                    decimal d3 = (decimal.Parse(dtx1.Rows[i]["UNIT_DOSAGE"].ToString()) +
                    decimal.Parse(dtx1.Rows[i]["ATTRITION_DOSAGE"].ToString())) * decimal.Parse(dt.Rows[0]["累计工单报废数量"].ToString());
                    dr["子规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["品牌"] = dtx2.Rows[0]["BRAND"].ToString();
                    dr["生产用量"] = d1.ToString("#0.00");
                    dr["BOM单位"] = dtx1.Rows[i]["BOM_UNIT"].ToString();
                    dr["工单包装领用量"] = Math.Ceiling(decimal.Parse(dtx1.Rows[i]["WO_DOSAGE"].ToString()) *
                        decimal.Parse(cbom.GETBOM_TO_STOCK(dtx1.Rows[i]["DET_WAREID"].ToString())));


                    decimal d4 = decimal.Parse(dtx1.Rows[i]["MPA_TO_STOCK"].ToString());
                    decimal d5 = decimal.Parse(dtx1.Rows[i]["STOCK_TO_BOM"].ToString());
                    dr["工单包装领用量"] = Math.Ceiling(decimal.Parse(dtx1.Rows[i]["WO_DOSAGE"].ToString()) *
                        d4 / d5);
                    dr["退料单包装退料量"] = Math.Ceiling(d1 * d4/d5);
                    dr["工单入库累计耗用量"] = Math.Ceiling(d2 * d4/d5);
                    dr["工单报废累计耗用量"] = Math.Ceiling(d3 * d4/d5);
                    dr["退料单位"] = dtx1.Rows[i]["SKU"].ToString();
                    dr["库存单位"] = dtx1.Rows[i]["SKU"].ToString();
                    dr["累计领料量"] = 0;
                    dr["累计退料量"] = 0;
                    dr["累计报废量"] = 0;
                    dr["本退料单累计退料量"] = 0;
                    dtt.Rows.Add(dr);
                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT
A.WOID AS WOID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.MRCOUNT) AS MRCOUNT 
FROM WORKORDER_PICKING_DET A 
LEFT JOIN MATERE B ON A.WPKEY=B.MRKEY 
WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,A.SN,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx4.Rows[i]["WOID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计领料量"] = dtx4.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx6 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.GECOUNT) AS GECOUNT 
FROM WORKORDER_REPICKING_DET A 
LEFT JOIN GODE B ON A.WRKEY=B.GEKEY  WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,A.SN,B.WAREID");
            if (dtx6.Rows.Count > 0)
            {
                for (i = 0; i < dtx6.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx6.Rows[i]["WOID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx6.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计退料量"] = dtx6.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx7 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.GECOUNT) AS GECOUNT 
FROM WORKORDER_MATERIEL_SCRAP_DET A 
LEFT JOIN GODE B ON A.MSKEY=B.GEKEY  WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,A.SN,B.WAREID");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx7.Rows[i]["WOID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计报废量"] = dtx7.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx5 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
A.WRID AS WRID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.GECOUNT) AS GECOUNT 
FROM WORKORDER_REPICKING_DET A 
LEFT JOIN  GODE B ON A.WRKEY=B.GEKEY  WHERE  A.WOID='" + v2 + "' AND A.WRID='" + v1 + "' GROUP BY A.WOID,A.WRID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx5.Rows[i]["WOID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本退料单累计退料量"] = dtx5.Rows[i]["GECOUNT"].ToString();
                            break;
                        }

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
            for (i = 0; i < dtt.Rows.Count; i++)
            {
                dtt.Rows[i]["可退料量"] = 
                     decimal.Parse(dtt.Rows[i]["累计领料量"].ToString())-
                     decimal.Parse(dtt.Rows[i]["累计退料量"].ToString()) -
                     decimal.Parse(dtt.Rows[i]["累计报废量"].ToString()) -
                     decimal.Parse(dtt.Rows[i]["工单入库累计耗用量"].ToString())-
                     decimal.Parse(dtt.Rows[i]["工单报废累计耗用量"].ToString());
                dtt.Rows[i]["退料数量"] = decimal.Parse(dtt.Rows[i]["退料单包装退料量"].ToString()) -
                                          decimal.Parse(dtt.Rows[i]["本退料单累计退料量"].ToString());
              

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
            Text10.Value = "";

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
                hint.Value = "点击确定带出BOM清单！";
            }

            try
            {

            }
            catch (Exception)
            {

            }
        }
        #region add
        protected void add()
        {

            hint.Value = "";
            string sql2 = "SELECT * FROM WORKORDER_DET WHERE WOID='" + Text2.Value + "'";
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
                    hint.Value = "退料员工工号不存在于系统中！";

                }
                else if (WRKEY == "Exceed Limited")
                {
                    hint.Value = "编码超出限制！";

                }

                else
                {
                    add2(count);
                }

            }

        }
        #endregion
        #region add2
        private void add2(int count)
        {

            int k;
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            for (k = 0; k < count; k++)
            {
                if (ac1(k) == 0)
                {
                    
                }
                else
                {

                    WRKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WORKORDER_REPICKING_DET", "WRKEY", "WR");
                    string WRCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string WOKEY = bc.getOnlyString("SELECT WOKEY FROM WORKORDER_DET WHERE WOID='" + Text2.Value + "' AND SN='" + SN + "'");

                    SQlcommandE(cworkorder_repicking.getsqlo, WRKEY, WOKEY, SN, REMARK);
                    SQlcommandE(cworkorder_repicking.getsqlf, WRKEY, WAREID, SN, WRCOUNT, STORAGEID, SLID, BATCHID);
                }
            }
            if (!bc.exists("SELECT WRID FROM WORKORDER_REPICKING_DET WHERE WRID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT WRID FROM WORKORDER_REPICKING_MST WHERE WRID='" + Text1.Value + "'"))
            {
                SQlcommandE(cworkorder_repicking.getsqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cworkorder_repicking.getsqlth + " WHERE WRID='"+Text1.Value +"'");
                IFExecution_SUCCESS = true;

            }

            bind();
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql, string WRKEY, string WOKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@WRKEY", SqlDbType.VarChar, 20).Value = WRKEY;
            sqlcom.Parameters.Add("@WRID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WOKEY", SqlDbType.VarChar, 20).Value = WOKEY;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = Text2.Value;
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
            sqlcom.Parameters.Add("@WRID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@WR_COUNT", SqlDbType.VarChar, 20).Value = Text10.Value;
            sqlcom.Parameters.Add("@REPICKING_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@REPICKING_MAKERID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        protected void SQlcommandE(string sql, string GEKEY, string WAREID, string SN,
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
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
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
        #region ac1()
        private int ac1(int k)
        {
            int x = 1;
            string WRCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
            string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
            string NOWRCOUNT = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
        
            if (WRCOUNT == "")
            {
                x = 0;
                hint.Value = "数量不能为空！";

            }
            else if (bc.yesno(WRCOUNT) == 0)
            {
                x = 0;
                hint.Value = "数量只能输入数字！";
            }
            else if (decimal.Parse(NOWRCOUNT) == 0)
            {
                x = 0;
                hint.Value = "可退料数量为0时不能做退料！";
            }
            else if (STORAGENAME == "")
            {
                x = 0;
                hint.Value = "仓库不能为空！";
            }
            else if (!bc.exists("SELECT * FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'"))
            {
                x = 0;
                hint.Value = "该仓库不存在于系统中！";
            }
            else if (STORAGE_LOCATION == "")
            {
                x = 0;
                hint.Value = "库位不能为空！";
            }
            else if (!bc.exists("SELECT * FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'"))
            {
                x = 0;
                hint.Value = "该库位不存在于系统中！";
            }
            else if (BATCHID == "")
            {
                x = 0;
                hint.Value = "批号不能为空！";
            }

            else if (decimal.Parse(WRCOUNT) > decimal.Parse(NOWRCOUNT))
            {
                x = 0;
                hint.Value = "退料数量不能大于可退料数量！";
            }
            return x;
        }
        #endregion

        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM WORKORDER_REPICKING_DET WHERE WRID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT WOID FROM WORKORDER_REPICKING_DET WHERE WRID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个退料单下面只能出现一个工单号!";
                    c = false;
                }
            }
            return c;

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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_REPICKING_MST", "WRID", "WR");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_repicking.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM WORKORDER_REPICKING_MST WHERE WRID='" + Text1.Value + "'";
                sql3 = "DELETE FROM WORKORDER_REPICKING_DET WHERE WRID='" + Text1.Value + "' AND SN='" + ID + "'";
                string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE WOID='" + Text2.Value + "'");
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此退料单对应的工单已经对帐，不允许删除";

                }
                else
                {
                    basec.getcoms(sql3);
                    basec.getcoms("DELETE  GODE WHERE GODEID='" + Text1.Value + "' AND SN='" + ID + "'");
                    if (!bc.exists("SELECT * FROM WORKORDER_REPICKING_DET WHERE WRID='" + Text1.Value + "'"))
                    {
                        basec.getcoms(sql2);
                    }
                    GridView1.EditIndex = -1;
                    bind();

                }

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

        protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
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
            string vard1 = Text1.Value;
            String[] Carstr = new string[] { vard1 };
            //WPSS.ReportManage.CRVSellReturn .Array [0]= Carstr[0];
            Response.Redirect("../ReportManage/CRVSellReturn.aspx");
        }
        protected void excelprint()
        {

            DataTable dtn = bc.asko(" WHERE A.WRID='" + Text1.Value + "'", 2);
            if (dtn.Rows.Count > 0)
            {
                string v1 = Server.MapPath("../PrintModelForSellReturn.xls");
                if (File.Exists(v1))
                {
                    bc.ExcelPrint(dtn, "退料单", v1);

                }
                else
                {


                    hint.Value = "指定路径不存在打印模版！";

                }
            }
            else
            {


                hint.Value = "无数据可打印！";

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
