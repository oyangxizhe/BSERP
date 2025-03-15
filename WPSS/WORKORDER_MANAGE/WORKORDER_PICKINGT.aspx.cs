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
    public partial class WORKORDER_PICKINGT : System.Web.UI.Page
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
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER_PICKING cworkorder_picking = new CWORKORDER_PICKING();
        WPSS.Validate va = new Validate();
        int i = 0;
        int j;
        DataTable dt4 = new DataTable();
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
        private  string _SKU;
        public  string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        PrintSellTableBill print = new PrintSellTableBill();
        string WPKEY;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Text1.Value = IDO;
                dt = bc.getdt(cworkorder_picking.getsql + " WHERE A.WPID='" + IDO + "'");
                if (dt.Rows.Count > 0)
                {
                    Text1.Value = dt.Rows[0]["WPID"].ToString();
                    Text5.Value = dt.Rows[0]["CNAME"].ToString();
                    Text2.Value = dt.Rows[0]["WOID"].ToString();
                    Text6.Value = dt.Rows[0]["ID"].ToString();
                    Text7.Value = dt.Rows[0]["CO_WAREID"].ToString();
                    Text8.Value = dt.Rows[0]["WNAME"].ToString();
                    Text9.Value = dt.Rows[0]["CWAREID"].ToString();
                    Text3.Value = dt.Rows[0]["PICKING_DATE"].ToString();
                    Text4.Value = dt.Rows[0]["PICKING_MAKERID"].ToString();
                    Text10.Value = dt.Rows[0]["WP_COUNT"].ToString();
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

            dt4 = cworkorder_picking.ask(Text1.Value);
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
B.OLDFILENAME AS OLDFILENAME FROM 
WORKORDER_MST A 
LEFT JOIN WAREFILE B ON A.WAREID=B.WAREID 
WHERE A.WOID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
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

            dtx3 = cworkorder_picking.ask(Text1.Value);
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
            string v = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='"+Text2.Value +"'");
            bool b = false;
            if (!bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'"))
            {
                hint.Value = "工单号为空或不存在于系统中！";
                b = true;
            }
            else if (v=="CLOSE" )
            {
                hint.Value = "此工单号已经结案，不能再做领料！";
                b = true;

            }
            else if (v == "CANCEL")
            {
                hint.Value = "此工单号已经作废，不能再做领料！";
                b = true;

            }
            else if (bc.yesno(Text10.Value) == 0)
            {
                hint.Value = "数量只能输入数字";
                b = true;
            }
            else if (cworkorder.JUAGE_ALLOW_PICKING_COUNT(Text2.Value, Text10.Value))
            {

                hint.Value = cworkorder.ErrowInfo;
                b = true;
            }
            else if (bc.JuagePICKING_DATE_IFLESSTHEN_GODE_DATE(Text1.Value, Text2.Value))
            {
                hint.Value = bc.ErrowInfo;
                b = true;

            }
            else if (bc.exists("SELECT * FROM WORKORDER_PICKING_MST WHERE WPID='" + Text1.Value + "'"))
            {
             
                hint.Value = "此领料单已经存在系统中，不能再保存！";
                b = true;

            }
            else if (cworkorder_picking .JUAGE_RESIDUE_PICKING_COUNT_IF_LESSTHAN_REPICING_COUNT (Text1.Value ))
            {

                hint.Value = cworkorder_picking.ErrowInfo;
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
            DataTable dtt = cworkorder_picking.dt_empty();
            DataTable dtx1 = bc.getdt(@"SELECT * FROM WORKORDER_DET WHERE WOID='" + v2 + "'");
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
                    dr["子客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    decimal d1 = (decimal.Parse(dtx1.Rows[i]["UNIT_DOSAGE"].ToString()) +
                        decimal.Parse(dtx1.Rows[i]["ATTRITION_DOSAGE"].ToString())) * decimal.Parse(Text10.Value);
                    dr["子规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["品牌"] = dtx2.Rows[0]["BRAND"].ToString();
                    dr["生产用量"] = d1.ToString("#0.00");
                    dr["BOM单位"] = dtx1.Rows[i]["BOM_UNIT"].ToString();
                    decimal d4 = decimal.Parse(dtx1.Rows[i]["MPA_TO_STOCK"].ToString());
                    decimal d5 = decimal.Parse(dtx1.Rows[i]["STOCK_TO_BOM"].ToString());
                    dr["工单包装领用量"] = Math.Ceiling(decimal.Parse(dtx1.Rows[i]["WO_DOSAGE"].ToString()) *
                        d4 / d5);
                    dr["领料单包装领用量"] = Math.Ceiling(d1 *d4/d5);
                    dr["领用单位"] = dtx1.Rows[i]["SKU"].ToString();
                    dr["库存单位"] = dtx1.Rows[i]["SKU"].ToString();
                    SKU = dtx1.Rows[i]["SKU"].ToString();
                    dr["累计领用量"] = 0;
                    dr["累计退料量"] = 0;
                    dr["未领用量"] = 0;
                    dr["本领料单累计领用量"] = 0;
                    dtt.Rows.Add(dr);

                    DataTable dtx6 = bc.getmaxstoragecount(dtx1.Rows[i]["DET_WAREID"].ToString(), dtx1.Rows[i]["SKU"].ToString());
                    if (dtx6.Rows.Count > 0)
                    {
                        dr["仓库"] = dtx6.Rows[0]["仓库"].ToString();
                        dr["库位"] = dtx6.Rows[0]["库位"].ToString();
                        dr["批号"] = dtx6.Rows[0]["批号"].ToString();
                        dr["库存数量"] = dtx6.Rows[0]["库存数量"].ToString();

                    }
                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT
A.WOID AS WOID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.MRCOUNT),2) AS DECIMAL(18,2)) AS MRCOUNT 
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
                            dtt.Rows[j]["累计领用量"] = dtx4.Rows[i]["MRCOUNT"].ToString();

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
CAST(ROUND(SUM(B.GECOUNT),2) AS DECIMAL(18,2)) AS GECOUNT 
FROM WORKORDER_REPICKING_DET A 
LEFT JOIN GODE B ON A.WRKEY=B.GEKEY  
WHERE  A.WOID='" + v2 + "' GROUP BY A.WOID,A.SN,B.WAREID");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx7.Rows[i]["WOID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计退料量"] = dtx7.Rows[i]["GECOUNT"].ToString();

                            break;
                        }

                    }
                }

            }
            DataTable dtx5 = bc.getdt(@"
SELECT 
A.WOID AS WOID,
A.WPID AS WPID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.MRCOUNT),2) AS DECIMAL(18,2)) AS MRCOUNT
FROM WORKORDER_PICKING_DET A LEFT JOIN  MATERE B
ON A.WPKEY=B.MRKEY 
WHERE  A.WOID='" + v2 + "' AND A.WPID='" + v1 + "' GROUP BY A.WOID,A.WPID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["工单号"].ToString() == dtx5.Rows[i]["WOID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本领料单累计领用量"] = dtx5.Rows[i]["MRCOUNT"].ToString();
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
                //dtt.Rows[i]["未领用量"] = decimal.Parse(dtt.Rows[i]["工单包装领用量"].ToString()) - decimal.Parse(dtt.Rows[i]["累计领用量"].ToString());
                dtt.Rows[i]["领用量"] = decimal.Parse(dtt.Rows[i]["领料单包装领用量"].ToString()) - decimal.Parse(dtt.Rows[i]["本领料单累计领用量"].ToString());
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
        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM WORKORDER_PICKING_DET WHERE WPID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT WOID FROM WORKORDER_PICKING_DET WHERE WPID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个领料单下面只能出现一个工单号!";
                    c = false;
                }
            }
            return c;

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
                else if (Text2.Value == "")
                {
                    hint.Value = "工单号不能为空！";

                }
                else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
                {
                    hint.Value = "领料员工工号不存在于系统中！";

                }
                else if (WPKEY == "Exceed Limited")
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
               
                if (ac1(k))
                {
                   

                }
                else
                {
                
                    WPKEY = bc.numYMD(20, 12, "000000000001", "select * from WORKORDER_PICKING_DET", "WPKEY", "WP");
                    string WPCOUNT = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[14].FindControl("TextBox15")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[19].FindControl("TextBox20")).Text;
                    string WOKEY = bc.getOnlyString("SELECT WOKEY FROM WORKORDER_DET WHERE WOID='" + Text2.Value + "' AND SN='" + SN + "'");
           
                    SQlcommandE(cworkorder_picking.getsqlo, WPKEY, WOKEY, SN, REMARK);
                    SQlcommandE(cworkorder_picking.getsqlf, WPKEY, WAREID, SN, WPCOUNT, STORAGEID, SLID, BATCHID);
                    DataTable dtx6 = bc.getmaxstoragecount(WAREID,SKU);
                    if (dtx6.Rows.Count > 0)
                    {
                        for (int n = 0; n < count; n++)
                        {
                            if (((TextBox)GridView1.Rows[n].Cells[1].FindControl("TextBox2")).Text == WAREID)
                            {
                                ((TextBox)GridView1.Rows[n].Cells[13].FindControl("TextBox14")).Text = dtx6.Rows[0]["仓库"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[14].FindControl("TextBox15")).Text = dtx6.Rows[0]["库位"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[15].FindControl("TextBox16")).Text = dtx6.Rows[0]["批号"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[16].FindControl("TextBox17")).Text = dtx6.Rows[0]["库存数量"].ToString();
                            }
                        }

                    }
                    else
                    {

                        for (int n = 0; n < count; n++)
                        {
                            if (((TextBox)GridView1.Rows[n].Cells[1].FindControl("TextBox2")).Text == WAREID)
                            {
                                ((TextBox)GridView1.Rows[n].Cells[13].FindControl("TextBox14")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[14].FindControl("TextBox15")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[15].FindControl("TextBox16")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[16].FindControl("TextBox17")).Text = "";
                            }
                        }
                    }
                }

            }/*under FOR OUTSIDE*/

            if (!bc.exists("SELECT WPID FROM WORKORDER_PICKING_DET WHERE WPID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT WPID FROM WORKORDER_PICKING_MST WHERE WPID='" + Text1.Value + "'"))
            {

                SQlcommandE(cworkorder_picking.getsqlt);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cworkorder_picking.getsqlth + " WHERE WPID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;

            }

            bind();
        }
        #endregion

        #region ac1()
        private bool ac1(int k)
        {

            bool b = false;
            string WPCOUNT = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[14].FindControl("TextBox15")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
            string NOWPCOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[16].FindControl("TextBox17")).Text;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            string v1 = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + WAREID + "'");
            string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME, STORAGE_LOCATION, BATCHID, v1);
            if (WPCOUNT=="")
            {
                b = true;
                hint.Value = "领用量不能为空！";
            }
            else if (decimal.Parse(WPCOUNT) == 0)
            {
                b = true;
                hint.Value = "领用量不能为0！";
            }
            else if (bc.yesno(WPCOUNT) == 0)
            {
                b = true;
                hint.Value = "数量只能输入数字！";
            }
            else if (STORAGENAME =="")
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

            /*else if (decimal.Parse(WPCOUNT) > decimal.Parse(NOWPCOUNT))
            {
                b=true;
                hint.Value = "领用量不能大于未领用量！";
            }*/
            else if (k1 != STORAGECOUNT)
            {
                b = true;
                hint.Value = "选择的库存品号与此项次领料品号不一致！";
            }
            else if (decimal.Parse(WPCOUNT) > decimal.Parse(STORAGECOUNT))
            {
                b = true;

                hint.Value = "领用量不能大于库存数量！";
            }
            return b;
        }
        #endregion

        #region SQlcommandE
        protected void SQlcommandE(string sql, string WPKEY, string WOKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@WPKEY", SqlDbType.VarChar, 20).Value = WPKEY;
            sqlcom.Parameters.Add("@WPID", SqlDbType.VarChar, 20).Value = Text1.Value;
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
            sqlcom.Parameters.Add("@WPID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@WP_COUNT", SqlDbType.VarChar, 20).Value = Text10.Value;
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_PICKING_MST", "WPID", "WP");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_picking.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql2, sql3;
            hint.Value = "";
            string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
            sql2 = "DELETE FROM WORKORDER_PICKING_MST WHERE WPID='" + Text1.Value + "'";
            sql3 = "DELETE FROM WORKORDER_PICKING_DET WHERE WPID='" + Text1.Value + "' AND SN='" + ID + "'";
            string s1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" + Text2.Value + "'");
            if (s1 == "CLOSE")
            {
                hint.Value = "此领料单对应的工单已经结案，不允许删除";

            }
            else if (bc.JuagePICKING_DATE_IFLESSTHEN_GODE_DATE(Text1.Value, Text2.Value))
            {
                hint.Value = bc.ErrowInfo;

            }
            else if (cworkorder_picking.JUAGE_RESIDUE_PICKING_COUNT_IF_LESSTHAN_REPICING_COUNT(Text1.Value))
            {
                hint.Value = cworkorder_picking.ErrowInfo;
              
            }
            else
            {
                basec.getcoms(sql3);
                basec.getcoms("DELETE  MATERE WHERE MATEREID='" + Text1.Value + "' AND SN='" + ID + "'");
                if (!bc.exists("SELECT * FROM WORKORDER_PICKING_DET WHERE WPID='" + Text1.Value + "'"))
                {
                    basec.getcoms(sql2);
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



        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
          


        }

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
