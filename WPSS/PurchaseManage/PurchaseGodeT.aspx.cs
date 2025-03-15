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
    public partial class PurchaseGodeT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx3 = new DataTable();
        basec bc = new basec();
        CPURCHASE cpurchase = new CPURCHASE();
        CPURCHASE_GODE cpurchase_gode = new CPURCHASE_GODE();
        WPSS.Validate va = new Validate();
        int i;
        private decimal _P_GECOUNT;
        public decimal P_GECOUNT
        {
            set { _P_GECOUNT = value; }
            get { return _P_GECOUNT; }

        }
        private decimal _GECOUNT;
        public decimal GECOUNT
        {
            set { _GECOUNT = value; }
            get { return _GECOUNT; }

        }
        private decimal _BOM_GECOUNT;
        public decimal BOM_GECOUNT
        {
            set { _BOM_GECOUNT = value; }
            get { return _BOM_GECOUNT; }

        }
        private string _MPA_UNIT;
        public string MPA_UNIT
        {
            set { _MPA_UNIT = value; }
            get { return _MPA_UNIT; }

        }
        private string _SKU;
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        private string _BOM_UNIT;
        public string BOM_UNIT
        {
            set { _BOM_UNIT = value; }
            get { return _BOM_UNIT; }

        }
        private decimal _FREECOUNT;
        public decimal FREECOUNT
        {
            set { _FREECOUNT = value; }
            get { return _FREECOUNT; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public static string[] NEWID = new string[] { "", "" };
        public static string[] GETID = new string[] { "" };
        public static string[] str2 = new string[] { "" };
        string PGKEY;
        int j;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["pageindex"] = "0";

                if (NEWID[0] != "")
                {
                    Text1.Value = NEWID[0];
                    NEWID[0] = "";

                }
                else
                {
                    Assignment();

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
            ControlFileDisplay.Value = "";
            GridView1.DataSource = as1(Text1.Value, Text2.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();


            string sql1 =cpurchase_gode .sql + " WHERE A.PUID='" + Text2.Value + "' AND A.PGID='" + Text1.Value + "'";
            dt4 = basec.getdts(sql1);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }

            string sql3 = @"SELECT DISTINCT(A.WAREID) AS WAREID,B.FLKEY AS FLKEY,B.OLDFILENAME AS OLDFILENAME FROM PURCHASE_DET A LEFT JOIN WAREFILE B 
            ON A.WAREID=B.WAREID " + " WHERE A.PUID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
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
            if (bc.exists("SELECT * FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'"))
            {
                x2.Value = "exists";
            }

            dtx3 = basec.getdts("SELECT * FROM PURCHASEGODE_MST where PGID='" + Text1.Value + "'");
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["GODEDATE"].ToString();
                Text4.Value = dtx3.Rows[0]["GODERID"].ToString();
                Label1.Text = bc.getOnlyString("SELECT ENAME FROM EMPLOYEEINFO WHERE EMID='" + dtx3.Rows[0]["GODERID"].ToString() + "'");
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
        #region assignment
        protected void Assignment()
        {

            #region Assignment
            Text1.Value = GETID[0];
            string s = bc.getOnlyString("SELECT PUID FROM PURCHASEGODE_DET WHERE PGID='" + GETID[0] + "'");
            GETID[0] = "";
            Text2.Value = s;
            Text5.Value = bc.getOnlyString("SELECT SNAME FROM SUPPLIERINFO_MST A LEFT JOIN PURCHASE_DET B ON A.SUID=B.SUID WHERE B.PUID='" + s + "'");

            #endregion
        }
        #endregion
        protected void btnSure_Click(object sender, EventArgs e)
        {

            if (!bc.exists("SELECT * FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'"))
            {
                hint.Value = "采购单号为空或不存在于系统中！";
                return;

            }
            else if (cpurchase.JUAGE_PURCHASE_IF_AREADY_AUDIT(Text2.Value))
            {
                bind();
            }
            else
            {
                hint.Value =cpurchase.ErrowInfo;
            }
           
        }

        #region ask
        private DataTable ask(string v1, string v2)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("采购单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("采购数量", typeof(decimal));
            dtt.Columns.Add("采购单位", typeof(string));
            dtt.Columns.Add("累计入库数量", typeof(decimal));
            dtt.Columns.Add("累计退货数量", typeof(decimal));
            dtt.Columns.Add("未入库数量", typeof(decimal), "采购数量-累计入库数量+累计退货数量");
            dtt.Columns.Add("入库数量", typeof(decimal));
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("库位", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("本入库单累计入库数量", typeof(decimal));
            DataTable dtx1 = bc.getdt("SELECT * FROM PURCHASE_DET WHERE PUID='" + v2 + "'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["采购单号"] = dtx1.Rows[i]["PUID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["品号"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["采购单位"] = dtx1.Rows[i]["MPA_UNIT"].ToString();
                    dr["采购数量"] = dtx1.Rows[i]["PCOUNT"].ToString();
                    dr["累计入库数量"] = 0;
                    dr["累计退货数量"] = 0;
                    dr["本入库单累计入库数量"] = 0;
                    string STORAGENAME= bc.getOnlyString("SELECT STORAGENAME FROM STORAGEINFO WHERE PURCHASE_GODE='Y'");
                    if (!string.IsNullOrEmpty(STORAGENAME))
                    {
                        dr["仓库"] = STORAGENAME;
                    }
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT 
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.P_GECOUNT),2) AS DECIMAL(18,2)) AS P_GECOUNT 
FROM PURCHASEGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY  
WHERE  A.PUID='" + v2 + "' GROUP BY A.PUID,A.SN,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx4.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计入库数量"] = dtx4.Rows[i]["P_GECOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx7 = bc.getdt(@"
SELECT 
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.P_MRCOUNT),2) AS DECIMAL(18,2)) AS P_MRCOUNT 
FROM RETURN_DET A 
LEFT JOIN MATERE B ON A.REKEY=B.MRKEY  
WHERE  A.PUID='" + v2 + "' GROUP BY A.PUID,A.SN,B.WAREID");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx7.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计退货数量"] = dtx7.Rows[i]["P_MRCOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx5 = bc.getdt(@"
SELECT
A.PUID AS PUID,
A.PGID AS PGID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.P_GECOUNT),2) AS DECIMAL(18,2)) AS P_GECOUNT
FROM PURCHASEGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY 
WHERE  A.PUID='" + v2 + "' AND A.PGID='" + v1 + "' GROUP BY A.PUID,A.PGID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购单号"].ToString() == dtx5.Rows[i]["PUID"].ToString() &&
                            dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本入库单累计入库数量"] = dtx5.Rows[i]["P_GECOUNT"].ToString();
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
                dtt.Rows[i]["入库数量"] = dtt.Rows[i]["未入库数量"].ToString();
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
            Label1.Text = "";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            
            if (cpurchase.JUAGE_PURCHASE_IF_AREADY_AUDIT(Text2.Value))
            {
                add();
            }
            else
            {
                hint.Value = cpurchase.ErrowInfo;
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
            string sql2 = "SELECT * FROM PURCHASE_DET WHERE PUID='" + Text2.Value + "'";
            dt1 = basec.getdts(sql2);
            string s1 = bc.getOnlyString("SELECT PURCHASESTATUS_MST FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'");

            if (dt1.Rows.Count > 0)
            {

                int count = dt1.Rows.Count;
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此入库单对应的采购已经对帐，不允许修改!";
                }

                else if (!ac0(Text1.Value, Text2.Value))
                {

                }
                else if (Text2.Value == "")
                {

                    hint.Value = "采购单号不能为空！";

                }
                else if (Text4.Value == "")
                {

                    hint.Value = "工号不能为空！";

                }
                else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
                {
                    hint.Value = "入库员工工号不存在于系统中！";
                }
                else if (bc.exists("SELECT * FROM PURCHASEGODE_MST WHERE PGID='" + Text1.Value + "'"))
                {
                  
                    hint.Value = "此采购入库单已经存在系统中，不能再保存！";
                  
                }
                else if (PGKEY == "Exceed Limited")
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
                    PGKEY = bc.numYMD(20, 12, "000000000001", "select * from PURCHASEGODE_DET", "PGKEY", "PG");
                    string PGCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[14].FindControl("TextBox15")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox11")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string P_FREECOUNT = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                    MPA_UNIT = bc.getOnlyString("SELECT MPA_UNIT FROM PURCHASE_DET WHERE PUID='"+Text2.Value +"' AND SN='"+SN+"'");
                    string GET_MPA_UNIT,MPA_TO_STOCK, STOCK_TO_BOM;
                    string PUKEY = bc.getOnlyString("SELECT PUKEY FROM PURCHASE_DET WHERE PUID='"+Text2.Value +"' AND SN='"+SN+"'");
                    decimal d1, d2, d3;
                    dt = bc.getdt("SELECT * FROM PURCHASE_DET WHERE PUID='"+Text2.Value +"' AND SN='"+SN+"'");
                    if (PGCOUNT == "")
                    {
                        PGCOUNT = Convert.ToString(0);
                    }
                    if (string.IsNullOrEmpty(P_FREECOUNT))
                    {
                        P_FREECOUNT = Convert.ToString(0);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        GET_MPA_UNIT = dt.Rows[0]["MPA_UNIT"].ToString();
                        MPA_TO_STOCK = dt.Rows[0]["MPA_TO_STOCK"].ToString();
                        STOCK_TO_BOM  = dt.Rows[0]["STOCK_TO_BOM"].ToString();
                        SKU = dt.Rows[0]["SKU"].ToString();
                        BOM_UNIT = dt.Rows[0]["BOM_UNIT"].ToString();
                        if (MPA_UNIT != SKU)
                        {
                            d1 = decimal.Parse(PGCOUNT) * decimal.Parse(MPA_TO_STOCK);
                            d2 = decimal.Parse(PGCOUNT) * decimal.Parse(STOCK_TO_BOM);/*current reality mpa_to_bom*/
                            GECOUNT = d1;
                            BOM_GECOUNT = d2;
                            d3 = decimal.Parse(P_FREECOUNT) * decimal.Parse(MPA_TO_STOCK);
                            FREECOUNT = d3;
                        }
                        else
                        {
                            d1 = decimal.Parse(PGCOUNT);
                            d2 = decimal.Parse(PGCOUNT);
                            GECOUNT = d1;
                            BOM_GECOUNT = d2;
                            d3 = decimal.Parse(P_FREECOUNT);
                            FREECOUNT = d3;
                        }
                    }
                    P_GECOUNT = decimal.Parse(PGCOUNT);
                    string NEEDDATE = bc.getOnlyString("SELECT NEEDDATE FROM PURCHASE_DET WHERE PUID='" + Text2.Value + "' AND SN='" + SN + "'");
                    SQlcommandE(cpurchase_gode.sqlo, PGKEY, PUKEY, SN, REMARK);
                    SQlcommandE(cpurchase_gode.sqlf, PGKEY, WAREID, SN, STORAGEID, SLID, BATCHID);
                }

            }/*under FOR OUTSIDE*/
            cpurchase.UPDATE_PURCHASE_STATUS(Text2.Value);

            if (!bc.exists("SELECT PGID FROM PURCHASEGODE_DET WHERE PGID='" + Text1.Value + "'"))
            {
                return;
            }
            if (!bc.exists("SELECT PGID FROM PURCHASEGODE_MST WHERE PGID='" + Text1.Value + "'"))
            {
                  SQlcommandE (cpurchase_gode .sqlt);
                  IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE(cpurchase_gode.sqlth+" WHERE PGID='"+Text1.Value +"'");
                IFExecution_SUCCESS = true;
            }
            bind();
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql, string PGKEY, string PUKEY, string SN, string REMARK)
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
            sqlcom.Parameters.Add("@PGKEY", SqlDbType.VarChar, 20).Value = PGKEY;
            sqlcom.Parameters.Add("@PGID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@PUKEY", SqlDbType.VarChar, 20).Value = PUKEY;
            sqlcom.Parameters.Add("@PUID", SqlDbType.VarChar, 20).Value = Text2.Value;
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
            sqlcom.Parameters.Add("@PGID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@GODEDATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@GODERID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        protected void SQlcommandE(string sql, string GEKEY, string WAREID, string SN,string STORAGEID, string SLID, string BATCHID)
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
            sqlcom.Parameters.Add("@GEKEY", SqlDbType.VarChar, 20).Value = GEKEY;
            sqlcom.Parameters.Add("@GODEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@P_GECOUNT", SqlDbType.VarChar, 20).Value = P_GECOUNT;
            sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = MPA_UNIT;
            sqlcom.Parameters.Add("@GECOUNT", SqlDbType.VarChar, 20).Value = GECOUNT;
            sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = SKU;
            sqlcom.Parameters.Add("@BOM_GECOUNT", SqlDbType.VarChar, 20).Value = BOM_GECOUNT;
            sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = BOM_UNIT;
            sqlcom.Parameters.Add("@FREECOUNT", SqlDbType.VarChar, 20).Value = FREECOUNT;
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
            string v1 = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string v2 = ((TextBox)GridView1.Rows[k].Cells[9].FindControl("TextBox10")).Text;
            string v3 = ((TextBox)GridView1.Rows[k].Cells[6].FindControl("TextBox7")).Text;
            string v4 = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string v5 = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string v6 = ((TextBox)GridView1.Rows[k].Cells[14].FindControl("TextBox15")).Text;
            if (v1 == "")
            {

                x = 0;
                hint.Value = "数量不能为空！";

            }
            else if (bc.yesno(v1) == 0 || bc.yesno(v5) == 0)
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
            /*else if (decimal.Parse(v1)<=0)
            {
                x = 0;
                hint.Value = "入库数量需大于0！";


            }
            else if (v5!="" && decimal.Parse(v5) <= 0)
            {
                x = 0;
                hint.Value = "Free数量需大于0！";


            }*/
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
            if (bc.exists("SELECT * FROM PURCHASEGODE_DET WHERE PGID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT PUID FROM PURCHASEGODE_DET WHERE PGID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个入库单下面只能出现一个采购单号!";
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM PURCHASEGODE_MST", "PGID", "PG");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/PURCHASEGODE.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM PurchaseGode_MST WHERE PGID='" + Text1.Value + "'";
                sql3 = "DELETE FROM PurchaseGode_DET WHERE PGID='" + Text1.Value + "' AND SN='" + ID + "'";
                string s1 = bc.getOnlyString("SELECT PURCHASESTATUS_MST FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'");
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此入库单对应的采购已经对帐，不允许删除";
                }
                else if (bc.JuageDeleteCount_MoreThanStorageCount(Text1.Value))
                {

                    hint.Value = bc.ErrowInfo;
                }
                else
                {
                    basec.getcoms(sql3);
                    basec.getcoms("DELETE GODE WHERE GODEID='" + Text1.Value + "' AND SN='" + ID + "'");
                    if (!bc.exists("SELECT * FROM PURCHASEGODE_DET WHERE PGID='" + Text1.Value + "'"))
                    {
                        basec.getcoms(sql2);
                    }
                    cpurchase.UPDATE_PURCHASE_STATUS(Text2.Value);
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
    }
}
