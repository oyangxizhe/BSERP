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
    public partial class ReturnT : System.Web.UI.Page
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
        CRETURN creturn = new CRETURN();
        WPSS.Validate va = new Validate();
        int i;

        string sqlo = @"
SELECT
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
D.PCount AS PCOUNT,
D.PurchaseUnitPrice AS  PURCHASEUNITPRICE,
D.TAXRATE AS TAXRATE,
C.STORAGENAME AS STORAGENAME,
B.BATCHID AS BATCHID,
E.STORAGE_LOCATION AS STORAGE_LOCATION,
SUM(B.GECOUNT) AS GECOUNT FROM PURCHASEGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN Purchase_DET D ON D.PUID=A.PUID AND D.SN=A.SN 
LEFT JOIN STORAGE_LOCATION E ON B.SLID=E.SLID
";
        private decimal _P_MRCOUNT;
        public decimal P_MRCOUNT
        {
            set { _P_MRCOUNT = value; }
            get { return _P_MRCOUNT; }

        }
        private decimal _MRCOUNT;
        public decimal MRCOUNT
        {
            set { _MRCOUNT = value; }
            get { return _MRCOUNT; }

        }
        private decimal _BOM_MRCOUNT;
        public decimal BOM_MRCOUNT
        {
            set { _BOM_MRCOUNT = value; }
            get { return _BOM_MRCOUNT; }

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
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public static string[] NEWID = new string[] { "", "" };
        public static string[] GETID = new string[] { "" };
        public static string[] str2 = new string[] { "" };
        string REKEY;
        int j;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            x2.Value = "";
            CUKEY.Value = "";
            ControlFileDisplay.Value = "";
            GridView1.DataSource = as1(Text1.Value, Text2.Value);
            GridView1.DataKeyNames = new string[] { "项次" };
            GridView1.DataBind();

            string sql1 = creturn.sql + " WHERE A.PUID='" + Text2.Value + "' AND A.REID='" + Text1.Value + "'";
            dt4 = basec.getdts(sql1);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }
            DataTable dtx4 = basec.getdts(@"
SELECT 
A.REID,
SUM(A.NOTAX_AMOUNT),
SUM(A.TAX_AMOUNT),
SUM(A.AMOUNT)
FROM Return_DET A 
WHERE A.REID='" + Text1.Value + "'  GROUP BY A.REID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][1].ToString();
                string v9 = dtx4.Rows[0][2].ToString();
                string v10 = dtx4.Rows[0][3].ToString();
                Text7.Value = string.Format("{0:F2}", Convert.ToDouble(v8));
                Text8.Value = string.Format("{0:F2}", Convert.ToDouble(v9));
                Text9.Value = string.Format("{0:F2}", Convert.ToDouble(v10));
                x.Value = Convert.ToString(1);
            }
            else
            {
                Text7.Value = "";
                Text8.Value = "";
                Text9.Value = "";

            }
            string sql3 = @"
SELECT 
DISTINCT(A.WAREID) AS WAREID,
B.FLKEY AS FLKEY,
B.OLDFILENAME AS OLDFILENAME
FROM PURCHASE_DET A LEFT JOIN WAREFILE B  ON A.WAREID=B.WAREID 
WHERE A.PUID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL  ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
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

            dtx3 = basec.getdts(creturn.sql + " where A.REID='" + Text1.Value + "'");
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["退货日期"].ToString();
                Text4.Value = dtx3.Rows[0]["退货员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["退货员"].ToString();

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
            string s = bc.getOnlyString("SELECT PUID FROM Return_DET WHERE REID='" + GETID[0] + "'");
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
                hint.Value = "采购号为空或不存在于系统中！";
                return;

            }
            bind();
        }

        #region ask
        private DataTable ask(string v1, string v2)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("采购号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("采购单价", typeof(decimal));
            dtt.Columns.Add("税率", typeof(decimal));
            dtt.Columns.Add("采购数量", typeof(decimal));
            dtt.Columns.Add("累计采购入库数量", typeof(decimal));
            dtt.Columns.Add("累计退货数量", typeof(decimal));
            dtt.Columns.Add("可退货数量", typeof(decimal), "累计采购入库数量-累计退货数量");
            dtt.Columns.Add("入库仓库", typeof(string));
            dtt.Columns.Add("入库库位", typeof(string));
            dtt.Columns.Add("入库批号", typeof(string));
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("库位", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("库存数量", typeof(decimal));
            dtt.Columns.Add("退货数量", typeof(decimal));
            dtt.Columns.Add("本退货单累计退货数量", typeof(decimal));
            dtt.Columns.Add("未税金额", typeof(decimal), "采购单价*退货数量");
            dtt.Columns.Add("税额", typeof(decimal), "采购单价*退货数量*税率/100");
            dtt.Columns.Add("含税金额", typeof(decimal), "采购单价*退货数量*(1+税率/100)");

            dtt.Columns.Add("累计退货未税金额", typeof(decimal));
            dtt.Columns.Add("累计退货税额", typeof(decimal));
            dtt.Columns.Add("累计退货含税金额", typeof(decimal));
            dtt.Columns.Add("可退货未税金额", typeof(decimal), "采购单价*累计采购入库数量-累计退货未税金额");
            dtt.Columns.Add("可退货税额", typeof(decimal), "采购单价*累计采购入库数量*税率/100-累计退货税额");
            dtt.Columns.Add("可退货含税金额", typeof(decimal), "采购单价*累计采购入库数量*(1+税率/100)-累计退货含税金额");
            dtt.Columns.Add("退货未税金额", typeof(decimal));
            dtt.Columns.Add("退货税额", typeof(decimal));
            dtt.Columns.Add("退货含税金额", typeof(decimal));
            dtt.Columns.Add("项次1", typeof(string));
            DataTable dtx1 = bc.getdt(sqlo + " WHERE A.PUID ='" + v2 + 
                "' GROUP BY A.PUID,A.SN,B.WAREID,D.PCOUNT,D.PurchaseUnitPrice,D.TAXRATE,C.STORAGENAME,E.STORAGE_LOCATION,B.BATCHID");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["采购号"] = dtx1.Rows[i]["PUID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["项次1"] = Convert.ToString(i + 1);
                    dr["品号"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["采购数量"] = dtx1.Rows[i]["PCOUNT"].ToString();
                    if (string.IsNullOrEmpty(dtx1.Rows[i]["PURCHASEUNITPRICE"].ToString()))
                    {
                        dr["采购单价"] = 0;
                    }
                    else
                    {
                        dr["采购单价"] = dtx1.Rows[i]["PURCHASEUNITPRICE"].ToString();
                    }

                    dr["税率"] = dtx1.Rows[i]["TAXRATE"].ToString();
                    dr["累计采购入库数量"] = 0;
                    dr["累计退货数量"] = 0;
                    dr["本退货单累计退货数量"] = 0;

                    dr["累计退货未税金额"] = 0;
                    dr["累计退货税额"] = 0;
                    dr["累计退货含税金额"] = 0;
                    dr["入库仓库"] = dtx1.Rows[i]["STORAGENAME"].ToString();
                    dr["入库库位"] = dtx1.Rows[i]["STORAGE_LOCATION"].ToString();
                    dr["入库批号"] = dtx1.Rows[i]["BATCHID"].ToString();
                    dtt.Rows.Add(dr);


                }

            }

            DataTable dtx4 = bc.getdt(@"
SELECT 
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
C.STORAGENAME AS STORAGENAME,
D.STORAGE_LOCATION AS STORAGE_LOCATION,
B.BATCHID AS BATCHID,
SUM(B.P_GECOUNT) AS P_GECOUNT
FROM PURCHASEGODE_DET A 
LEFT JOIN GODE B ON A.PGKEY=B.GEKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN STORAGE_LOCATION D ON B.SLID=D.SLID
WHERE  A.PUID='" + v2 + "' GROUP BY A.PUID,A.SN,B.WAREID,C.STORAGENAME,D.STORAGE_LOCATION,B.BATCHID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购号"].ToString() == dtx4.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString() &&
                            dtt.Rows[j]["入库仓库"].ToString() == dtx4.Rows[i]["STORAGENAME"].ToString() &&
                            dtt.Rows[j]["入库库位"].ToString() == dtx4.Rows[i]["STORAGE_LOCATION"].ToString() && 
                            dtt.Rows[j]["入库批号"].ToString() == dtx4.Rows[i]["BATCHID"].ToString())
                        {
                            dtt.Rows[j]["累计采购入库数量"] = dtx4.Rows[i]["P_GECOUNT"].ToString();

                            break;
                        }

                    }
                }

            }
            DataTable dtx6 = bc.getdt(@"
SELECT 
A.PUID AS PUID,
A.SN AS SN,
B.WAREID AS WAREID,
D.PCount AS PCOUNT,
D.PurchaseUnitPrice AS PURCHASEUNITPRICE,
D.TAXRATE AS TAXRATE,
C.STORAGENAME AS STORAGENAME,
E.STORAGE_LOCATION AS STORAGE_LOCATION,
B.BATCHID AS BATCHID,
SUM(B.P_MRCount) AS P_MRCOUNT 
FROM RETURN_DET A 
LEFT JOIN MateRe  B ON A.REKEY=B.MRKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN Purchase_DET D ON D.PUID=A.PUID AND D.SN=A.SN 
LEFT JOIN STORAGE_LOCATION E ON B.SLID=E.SLID
WHERE A.PUID ='" + v2 + "' GROUP BY A.PUID,A.SN,B.WAREID,D.PCOUNT,D.PurchaseUnitPrice,D.TAXRATE,C.STORAGENAME,E.STORAGE_LOCATION,B.BATCHID");
            if (dtx6.Rows.Count > 0)
            {
                for (i = 0; i < dtx6.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购号"].ToString() == dtx6.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx6.Rows[i]["SN"].ToString() && 
                            dtt.Rows[j]["入库仓库"].ToString() == dtx6.Rows[i]["STORAGENAME"].ToString() &&
                            dtt.Rows[j]["入库库位"].ToString() == dtx6.Rows[i]["STORAGE_LOCATION"].ToString() && 
                            dtt.Rows[j]["入库批号"].ToString() == dtx6.Rows[i]["BATCHID"].ToString())
                        {
                            dtt.Rows[j]["累计退货数量"] = dtx6.Rows[i]["P_MRCOUNT"].ToString();
                            break;
                        }

                    }

                }

            }
            DataTable dtx5 = bc.getdt(@"
SELECT
A.PUID AS PUID,
A.REID AS REID,
A.SN AS SN,
B.WAREID AS WAREID,
D.PCount AS PCOUNT,
D.PurchaseUnitPrice AS PURCHASEUNITPRICE,
D.TAXRATE AS TAXRATE,
C.STORAGENAME AS STORAGENAME,
E.STORAGE_LOCATION AS STORAGE_LOCATION,
B.BATCHID AS BATCHID,
SUM(B.P_MRCount) AS P_MRCOUNT
FROM RETURN_DET A 
LEFT JOIN MateRe  B ON A.REKEY=B.MRKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN Purchase_DET D ON D.PUID=A.PUID AND D.SN=A.SN 
LEFT JOIN STORAGE_LOCATION E ON B.SLID=E.SLID
WHERE  A.PUID='" + v2 + "' AND A.REID='" + v1 +
"'  GROUP BY A.PUID,A.REID,A.SN,B.WAREID,D.PCOUNT,D.PurchaseUnitPrice,D.TAXRATE,C.STORAGENAME,E.STORAGE_LOCATION,B.BATCHID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购号"].ToString() == dtx5.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString() && 
                            dtt.Rows[j]["入库仓库"].ToString() == dtx5.Rows[i]["STORAGENAME"].ToString() &&
                            dtt.Rows[j]["入库库位"].ToString() == dtx5.Rows[i]["STORAGE_LOCATION"].ToString() && 
                            dtt.Rows[j]["入库批号"].ToString() == dtx5.Rows[i]["BATCHID"].ToString())
                        {
                            dtt.Rows[j]["本退货单累计退货数量"] = dtx5.Rows[i]["P_MRCOUNT"].ToString();
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
D.PCount AS PCOUNT,
D.PurchaseUnitPrice AS PURCHASEUNITPRICE,
D.TAXRATE AS TAXRATE,
C.STORAGENAME AS STORAGENAME,
E.STORAGE_LOCATION AS STORAGE_LOCATION,
B.BATCHID AS BATCHID,
SUM(B.P_MRCount) AS P_MRCOUNT,
SUM(A.NOTAX_AMOUNT) AS NOTAX_AMOUNT,
SUM(A.TAX_AMOUNT) AS TAX_AMOUNT,
SUM(A.AMOUNT) AS AMOUNT 
FROM RETURN_DET A 
LEFT JOIN MateRe  B ON A.REKEY=B.MRKEY
LEFT JOIN STORAGEINFO C ON B.STORAGEID=C.STORAGEID
LEFT JOIN Purchase_DET D ON D.PUID=A.PUID AND D.SN=A.SN 
LEFT JOIN STORAGE_LOCATION E ON B.SLID=E.SLID
WHERE A.PUID ='" + v2 + "' GROUP BY A.PUID,A.SN,B.WAREID,D.PCOUNT,D.PurchaseUnitPrice,D.TAXRATE,C.STORAGENAME,E.STORAGE_LOCATION,B.BATCHID");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["采购号"].ToString() == dtx7.Rows[i]["PUID"].ToString() && 
                            dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString() &&
                            dtt.Rows[j]["入库仓库"].ToString() == dtx7.Rows[i]["STORAGENAME"].ToString() &&
                            dtt.Rows[j]["入库库位"].ToString() == dtx7.Rows[i]["STORAGE_LOCATION"].ToString() &&
                            dtt.Rows[j]["入库批号"].ToString() == dtx7.Rows[i]["BATCHID"].ToString())
                        {
                            dtt.Rows[j]["累计退货未税金额"] = dtx7.Rows[i]["NOTAX_AMOUNT"].ToString();
                            dtt.Rows[j]["累计退货税额"] = dtx7.Rows[i]["TAX_AMOUNT"].ToString();
                            dtt.Rows[j]["累计退货含税金额"] = dtx7.Rows[i]["AMOUNT"].ToString();
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
                dtt.Rows[i]["退货数量"] = dtt.Rows[i]["可退货数量"].ToString();

                dtt.Rows[i]["退货未税金额"] = dtt.Rows[i]["可退货未税金额"].ToString();
                dtt.Rows[i]["退货税额"] = dtt.Rows[i]["可退货税额"].ToString();
                dtt.Rows[i]["退货含税金额"] = dtt.Rows[i]["可退货含税金额"].ToString();
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

            add();
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
            string sql2 = sqlo + " WHERE A.PUID='" + Text2.Value + 
                "' GROUP BY A.PUID,A.SN,B.WAREID,D.PCOUNT,D.PurchaseUnitPrice,D.TAXRATE,C.STORAGENAME,E.STORAGE_LOCATION,B.BATCHID";
            dt1 = basec.getdts(sql2);
            string s1 = bc.getOnlyString("SELECT PURCHASESTATUS_MST FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'");

            if (dt1.Rows.Count > 0)
            {

                int count = dt1.Rows.Count;

                if (s1 == "RECONCILE")
                {
                    hint.Value = "此退货单对应的采购已经对帐，不允许修改";
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
                    hint.Value = "退货员工工号不存在于系统中！";

                }
                else if (bc.exists("SELECT * FROM RETURN_MST WHERE REID='" + Text1.Value + "'"))
                {
                
                    hint.Value = "此退货单已经存在系统中，不能再保存！";

                }
                else if (REKEY == "Exceed Limited")
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

                    REKEY = bc.numYMD(20, 12, "000000000001", "select * from Return_DET", "REKEY", "RE");
                    string RECOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[27].FindControl("TextBox28")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
                    string v1 = ((TextBox)GridView1.Rows[k].Cells[22].FindControl("TextBox23")).Text;
                    string v2 = ((TextBox)GridView1.Rows[k].Cells[23].FindControl("TextBox24")).Text;
                    string v3 = ((TextBox)GridView1.Rows[k].Cells[24].FindControl("TextBox25")).Text;
                    string v41 = ((TextBox)GridView1.Rows[k].Cells[25].FindControl("TextBox26")).Text;
                    string v4 = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + v41 + "'");
                    string v51 = ((TextBox)GridView1.Rows[k].Cells[28].FindControl("TextBox29")).Text;
                    string v5 = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + v51 + "'");
                    string v6 = ((TextBox)GridView1.Rows[k].Cells[26].FindControl("TextBox27")).Text;
                    MPA_UNIT = bc.getOnlyString("SELECT MPA_UNIT FROM PURCHASE_DET WHERE PUID='" + Text2.Value + "' AND SN='" + SN + "'");
                    string GET_MPA_UNIT, MPA_TO_STOCK, STOCK_TO_BOM;
                    string PUKEY = bc.getOnlyString("SELECT PUKEY FROM PURCHASE_DET WHERE PUID='" + Text2.Value + "' AND SN='" + SN + "'");

                    decimal d1, d2;
                    dt = bc.getdt("SELECT * FROM PURCHASE_DET WHERE PUID='" + Text2.Value + "' AND SN='" + SN + "'");
                    if (RECOUNT == "")
                    {
                        RECOUNT = Convert.ToString(0);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        GET_MPA_UNIT = dt.Rows[0]["MPA_UNIT"].ToString();
                        MPA_TO_STOCK = dt.Rows[0]["MPA_TO_STOCK"].ToString();
                        STOCK_TO_BOM = dt.Rows[0]["STOCK_TO_BOM"].ToString();
                        SKU = dt.Rows[0]["SKU"].ToString();
                        BOM_UNIT = dt.Rows[0]["BOM_UNIT"].ToString();
                        if (MPA_UNIT != SKU)
                        {
                            d1 = decimal.Parse(RECOUNT) * decimal.Parse(MPA_TO_STOCK);
                            d2 = decimal.Parse(RECOUNT) * decimal.Parse(STOCK_TO_BOM);/*current reality mpa_to_bom*/
                            MRCOUNT = d1;
                            BOM_MRCOUNT = d2;
                           

                        }
                        else
                        {
                            d1 = decimal.Parse(RECOUNT);
                            d2 = decimal.Parse(RECOUNT);
                            MRCOUNT = d1;
                            BOM_MRCOUNT = d2;
                           

                        }
                    }
                    P_MRCOUNT = decimal.Parse(RECOUNT);

                    SQlcommandE(creturn.sqlo, REKEY, PUKEY, SN, REMARK,v1,v2,v3);
                    SQlcommandE(creturn.sqlf, REKEY, WAREID, SN, STORAGEID, SLID, BATCHID);
                    SQlcommandE_MRCOUNT(creturn.sqlsi, REKEY, WAREID, SN, v4,v5,v6);
                    IFExecution_SUCCESS = true;
                }
            }

            cpurchase.UPDATE_PURCHASE_STATUS(Text2.Value);
            if (!bc.exists("SELECT REID FROM Return_DET WHERE REID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT REID FROM Return_MST WHERE REID='" + Text1.Value + "'"))
            {
                SQlcommandE(creturn.sqlt);
            }
            else
            {
                SQlcommandE(creturn.sqlth + " WHERE REID='" + Text1.Value + "'");
            }

            bind();
        }
        #endregion
        #region ac1()
        private int ac1(int k)
        {
            int x = 1;
            string SRCOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
            string STORAGE_LOCATION= ((TextBox)GridView1.Rows[k].Cells[27].FindControl("TextBox28")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
            string NOSRCOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            //string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME,"", BATCHID);

            string k2 = ((TextBox)GridView1.Rows[k].Cells[19].FindControl("TextBox20")).Text;
            string k3 = ((TextBox)GridView1.Rows[k].Cells[20].FindControl("TextBox21")).Text;
            string k4 = ((TextBox)GridView1.Rows[k].Cells[21].FindControl("TextBox22")).Text;

            string k5 = ((TextBox)GridView1.Rows[k].Cells[22].FindControl("TextBox23")).Text;
            string k6 = ((TextBox)GridView1.Rows[k].Cells[23].FindControl("TextBox24")).Text;
            string k7 = ((TextBox)GridView1.Rows[k].Cells[24].FindControl("TextBox25")).Text;
            if (SRCOUNT == "")
            {

                x = 0;
                hint.Value = "数量不能为空！";

            }
            else if (bc.yesno(SRCOUNT) == 0)
            {
                x = 0;
                hint.Value = "数量只能输入数字！";


            }
            else if (decimal.Parse(NOSRCOUNT) == 0)
            {

                x = 0;
                hint.Value = "可退货数量为0时不能做退货！";


            }
            else if (decimal.Parse(k2) == 0)
            {

                x = 0;
                hint.Value = "可退货未税金额为0时不能做退货！";


            }
            else if (decimal.Parse(k3) == 0)
            {

                x = 0;
                hint.Value = "可退货税额为0时不能做退货！";


            }
            else if (decimal.Parse(k4) == 0)
            {

                x = 0;
                hint.Value = "可退货含税金额为0时不能做退货！";


            }
            else if (decimal.Parse(k5) > decimal.Parse(k2))
            {
                x = 0;
                hint.Value = "退货未税金额不能大于可退货未税金额！";


            }
            else if (decimal.Parse(k6) > decimal.Parse(k3))
            {
                x = 0;
                hint.Value = "退货税额不能大于可退货税额！";


            }
            else if (decimal.Parse(k7) > decimal.Parse(k4))
            {
                x = 0;
                hint.Value = "退货含税金额不能大于可退货含税金额！";


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

            else if (decimal.Parse(SRCOUNT) > decimal.Parse(NOSRCOUNT))
            {
                x = 0;
                hint.Value = "退货数量不能大于可退货数量！";


            }
            return x;

        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql, string PGKEY, string PUKEY, string SN, string REMARK,string v1,string v2,string v3)
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
            sqlcom.Parameters.Add("@REKEY", SqlDbType.VarChar, 20).Value = REKEY;
            sqlcom.Parameters.Add("@REID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@PUKEY", SqlDbType.VarChar, 20).Value = PUKEY;
            sqlcom.Parameters.Add("@PUID", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@NOTAX_AMOUNT", SqlDbType.VarChar, 20).Value = v1;
            sqlcom.Parameters.Add("@TAX_AMOUNT", SqlDbType.VarChar, 20).Value = v2;
            sqlcom.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 20).Value = v3;
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
            sqlcom.Parameters.Add("@REID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@RETURN_DATE", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@RETURN_ID", SqlDbType.VarChar, 20).Value = Text4.Value;
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
        protected void SQlcommandE(string sql, string GEKEY, string WAREID, string SN, string STORAGEID, string SLID, string BATCHID)
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
            sqlcom.Parameters.Add("@P_GECOUNT", SqlDbType.VarChar, 20).Value = P_MRCOUNT;
            sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = MPA_UNIT;
            sqlcom.Parameters.Add("@GECOUNT", SqlDbType.VarChar, 20).Value = MRCOUNT;
            sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = SKU;
            sqlcom.Parameters.Add("@BOM_GECOUNT", SqlDbType.VarChar, 20).Value = BOM_MRCOUNT;
            sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = BOM_UNIT;
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


        #region SQlcommandE
        protected void SQlcommandE_MRCOUNT(string sql, string MRKEY, string WAREID, string SN, string STORAGEID, string SLID, string BATCHID)
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
            sqlcom.Parameters.Add("@MRKEY", SqlDbType.VarChar, 20).Value = MRKEY;
            sqlcom.Parameters.Add("@MATEREID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@P_MRCOUNT", SqlDbType.VarChar, 20).Value = P_MRCOUNT;
            sqlcom.Parameters.Add("@MPA_UNIT", SqlDbType.VarChar, 20).Value = MPA_UNIT;
            sqlcom.Parameters.Add("@MRCOUNT", SqlDbType.VarChar, 20).Value = MRCOUNT;
            sqlcom.Parameters.Add("@SKU", SqlDbType.VarChar, 20).Value = SKU;
            sqlcom.Parameters.Add("@BOM_MRCOUNT", SqlDbType.VarChar, 20).Value = BOM_MRCOUNT;
            sqlcom.Parameters.Add("@BOM_UNIT", SqlDbType.VarChar, 20).Value = BOM_UNIT;
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
        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM Return_DET WHERE REID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT PUID FROM Return_DET WHERE REID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个退货单下面只能出现一个采购号!";
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM Return_MST", "REID", "RE");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/Return.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM Return_MST WHERE REID='" + Text1.Value + "'";
                sql3 = "DELETE FROM Return_DET WHERE REID='" + Text1.Value + "' AND SN='" + ID + "'";
                string s1 = bc.getOnlyString("SELECT PURCHASESTATUS_MST FROM PURCHASE_MST WHERE PUID='" + Text2.Value + "'");
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此退货单对应的采购已经对帐，不允许删除";

                }
                else
                {
                    basec.getcoms(sql3);
                    basec.getcoms("DELETE  GODE WHERE GODEID='" + Text1.Value + "' AND SN='" + ID + "'");
                    basec.getcoms("DELETE  MATERE WHERE MATEREID='" + Text1.Value + "' AND SN='" + ID + "'");
                    if (!bc.exists("SELECT * FROM Return_DET WHERE REID='" + Text1.Value + "'"))
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
            //WPSS.ReportManage.CRVReturn .Array [0]= Carstr[0];
            Response.Redirect("../ReportManage/CRVReturn.aspx");
        }
        protected void excelprint()
        {

            DataTable dtn = bc.asko(" WHERE A.REID='" + Text1.Value + "'", 2);
            if (dtn.Rows.Count > 0)
            {
                string v1 = Server.MapPath("../PrintModelForReturn.xls");
                if (File.Exists(v1))
                {
                    bc.ExcelPrint(dtn, "退货单", v1);

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
