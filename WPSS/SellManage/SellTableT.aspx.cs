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

namespace WPSS.SellManage
{
    public partial class SellTableT : System.Web.UI.Page
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
        PrintSellTableBill print = new PrintSellTableBill();
        CORDER corder = new CORDER();
        CSELL_TABLE csell_table = new CSELL_TABLE();
        int i;
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _SKU;
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }

        }
        public static string[] NEWID = new string[] { "", "" };
        public static string[] GETID = new string[] { "" };
        public static string[] str2 = new string[] { "" };
        string SEKEY;
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

            dt4 = print.ask(Text1.Value);
            if (dt4.Rows.Count > 0)
            {
                GridView2.DataSource = dt4;
                GridView2.DataBind();
                x.Value = Convert.ToString(1);
            }
            DataTable dtx4 = basec.getdts(@"
SELECT 
A.SEID,
A.ORID,
SUM(C.MRcount*B.sellunitprice),
SUM(C.MRcount*B.sellunitprice*
B.taxrate/100),
SUM(C.MRcount*B.sellunitprice*(1+B.taxrate/100)) 
FROM SELLTABLE_DET A 
LEFT JOIN ORDER_DET B ON A.ORID=B.ORID AND A.SN=B.SN
LEFT JOIN MATERE C ON A.SEKEY=C.MRKEY 
WHERE A.SEID='" + Text1.Value + "' AND A.ORID='" + Text2.Value + "' GROUP BY A.ORID,A.SEID ");

            if (dtx4.Rows.Count > 0)
            {
                string v8 = dtx4.Rows[0][2].ToString();
                string v9 = dtx4.Rows[0][3].ToString();
                string v10 = dtx4.Rows[0][4].ToString();
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
B.OLDFILENAME AS OLDFILENAME FROM 
ORDER_DET A 
LEFT JOIN WAREFILE B ON A.WAREID=B.WAREID 
WHERE A.ORID='" + Text2.Value + "' AND B.FLKEY IS NOT NULL ORDER BY A.WAREID,B.FLKEY,B.OLDFILENAME";
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
            if (bc.exists("SELECT * FROM ORDER_MST WHERE ORID='" + Text2.Value + "'"))
            {
                x2.Value = "exists";
            }

            dtx3 = print.ask(Text1.Value);
            if (dtx3.Rows.Count > 0)
            {
                Text3.Value = dtx3.Rows[0]["销货日期"].ToString();
                Text4.Value = dtx3.Rows[0]["销货员工号"].ToString();
                Label1.Text = dtx3.Rows[0]["销货员"].ToString();
                Text6.Value = dtx3.Rows[0]["联系人"].ToString();
                Text10.Value = dtx3.Rows[0]["联系电话"].ToString();
                Text11.Value = dtx3.Rows[0]["送货地址"].ToString();
                CUKEY.Value = dtx3.Rows[0]["CUKEY"].ToString();
            }
            else
            {
                DataTable dtx8 = basec.getdts(@"
SELECT 
B.CUKEY 
FROM ORDER_MST A
LEFT JOIN CUSTOMERINFO_MST 
B ON A.CUID=B.CUID
WHERE A.ORID='" + Text2.Value + "'");
                if (dtx8.Rows.Count > 0)
                {

                    CUKEY.Value = dtx8.Rows[0]["CUKEY"].ToString();
                }
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
            string s = bc.getOnlyString("SELECT ORID FROM SELLTABLE_DET WHERE SEID='" + GETID[0] + "'");
            GETID[0] = "";
            Text2.Value = s;
            Text5.Value = bc.getOnlyString("SELECT CNAME FROM CUSTOMERINFO_MST A LEFT JOIN ORDER_DET B ON A.CUID=B.CUID WHERE B.ORID='" + s + "'");
            #endregion
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
            if (!bc.exists("SELECT * FROM ORDER_MST WHERE ORID='" + Text2.Value + "'"))
            {
                hint.Value = "订单号为空或不存在于系统中！";
                b = true;
            }
            else if (csell_table.JUAGE_RESIDUE_SECOUNT_IF_LESSTHAN_SR_COUNT(Text1.Value))
            {

                hint.Value = csell_table.ErrowInfo;
                b = true;
            }
            else if (corder.JUAGE_ORDER_IF_HAVE_NO_AUDIT (Text2.Value ))
            {
                hint.Value = corder.ErrowInfo;
                b = true;
            }
            return b;
        }
        #region ask
        private DataTable ask(string v1, string v2)
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("订单号", typeof(string));
            dtt.Columns.Add("项次", typeof(string));
            dtt.Columns.Add("品号", typeof(string));
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("品名", typeof(string));
            dtt.Columns.Add("规格", typeof(string));
            dtt.Columns.Add("客户料号", typeof(string));
            dtt.Columns.Add("销售单价", typeof(decimal));
            dtt.Columns.Add("税率", typeof(decimal));
            dtt.Columns.Add("订单数量", typeof(decimal));
            dtt.Columns.Add("累计销货数量", typeof(decimal));
            dtt.Columns.Add("累计销退数量", typeof(decimal));
            dtt.Columns.Add("未销货数量", typeof(decimal), "订单数量-累计销货数量+累计销退数量");
            dtt.Columns.Add("仓库", typeof(string));
            dtt.Columns.Add("库位", typeof(string));
            dtt.Columns.Add("批号", typeof(string));
            dtt.Columns.Add("库存数量", typeof(decimal));
            dtt.Columns.Add("销货数量", typeof(decimal));
            dtt.Columns.Add("本销货单累计销货数量", typeof(decimal));
            dtt.Columns.Add("未税金额", typeof(decimal), "销售单价*销货数量");
            dtt.Columns.Add("税额", typeof(decimal), "销售单价*销货数量*税率/100");
            dtt.Columns.Add("含税金额", typeof(decimal), "销售单价*销货数量*(1+税率/100)");


            DataTable dtx1 = bc.getdt("SELECT * FROM ORDER_DET WHERE ORID='" + v2 + "'");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["订单号"] = dtx1.Rows[i]["ORID"].ToString();
                    dr["项次"] = dtx1.Rows[i]["SN"].ToString();
                    dr["品号"] = dtx1.Rows[i]["WAREID"].ToString();
                    dtx2 = bc.getdt("select * from wareinfo where wareid='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    dr["料号"] = dtx2.Rows[0]["CO_WAREID"].ToString();
                    dr["品名"] = dtx2.Rows[0]["WNAME"].ToString();
                    dr["规格"] = dtx2.Rows[0]["SPEC"].ToString();
                    dr["客户料号"] = dtx2.Rows[0]["CWAREID"].ToString();
                    dr["订单数量"] = dtx1.Rows[i]["OCOUNT"].ToString();
                    dr["销售单价"] = dtx1.Rows[i]["SELLUNITPRICE"].ToString();
                    dr["税率"] = dtx1.Rows[i]["TAXRATE"].ToString();
                    dr["累计销货数量"] = 0;
                    dr["累计销退数量"] = 0;
                    dr["本销货单累计销货数量"] = 0;
                    dtt.Rows.Add(dr);
                    SKU = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + dtx1.Rows[i]["WAREID"].ToString() + "'");
                    DataTable dtx6 = bc.getmaxstoragecount(dtx1.Rows[i]["WAREID"].ToString(),SKU );
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
A.ORID AS ORID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.MRCOUNT),2) AS DECIMAL(18,2)) AS MRCOUNT 
FROM SELLTABLE_DET A 
LEFT JOIN MATERE 
B ON A.SEKEY=B.MRKEY  
WHERE  A.ORID='" + v2 + "' GROUP BY A.ORID,A.SN,B.WAREID");
            if (dtx4.Rows.Count > 0)
            {
                for (i = 0; i < dtx4.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx4.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx4.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计销货数量"] = dtx4.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx5 = bc.getdt(@"
SELECT 
A.ORID AS ORID,
A.SEID AS SEID,
A.SN AS SN,
B.WAREID AS WAREID,
CAST(ROUND(SUM(B.MRCOUNT),2) AS DECIMAL(18,2)) AS MRCOUNT
FROM SELLTABLE_DET A 
LEFT JOIN  MATERE B
ON A.SEKEY=B.MRKEY 
WHERE  A.ORID='" + v2 + "' AND A.SEID='" + v1 + "' GROUP BY A.ORID,A.SEID,A.SN,B.WAREID");
            if (dtx5.Rows.Count > 0)
            {
                for (i = 0; i < dtx5.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx5.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx5.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["本销货单累计销货数量"] = dtx5.Rows[i]["MRCOUNT"].ToString();
                            break;
                        }

                    }
                }

            }
            DataTable dtx7 = bc.getdt(@"
SELECT 
A.ORID AS ORID,
A.SN AS SN,
B.WAREID AS WAREID,
SUM(B.GECOUNT) AS GECOUNT
FROM SELLRETURN_DET A 
LEFT JOIN GODE B ON A.SRKEY=B.GEKEY  
GROUP BY 
A.ORID,
A.SN,
B.WAREID

");
            if (dtx7.Rows.Count > 0)
            {
                for (i = 0; i < dtx7.Rows.Count; i++)
                {
                    for (j = 0; j < dtt.Rows.Count; j++)
                    {
                        if (dtt.Rows[j]["订单号"].ToString() == dtx7.Rows[i]["ORID"].ToString() && dtt.Rows[j]["项次"].ToString() == dtx7.Rows[i]["SN"].ToString())
                        {
                            dtt.Rows[j]["累计销退数量"] = dtx7.Rows[i]["GECOUNT"].ToString();
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
                dtt.Rows[i]["销货数量"] = dtt.Rows[i]["未销货数量"].ToString();
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
            Text6.Value = "";
            Text10.Value = "";
            Text11.Value = "";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (juage())
            {
            }
            else
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
        #region add
        protected void add()
        {

            hint.Value = "";
            string sql2 = "SELECT * FROM ORDER_DET WHERE ORID='" + Text2.Value + "'";
            dt1 = basec.getdts(sql2);
            string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + Text2.Value + "'");

            if (dt1.Rows.Count > 0)
            {

                int count = dt1.Rows.Count;

                if (s1 == "RECONCILE")
                {
                    hint.Value = "此销货单对应的订单已经对帐，不允许修改";
                }

                else if (!ac0(Text1.Value, Text2.Value))
                {

                }
                else if (Text2.Value == "")
                {
                    hint.Value = "订单号不能为空！";

                }
                else if (Text4.Value == "")
                {
                    hint.Value = "工号不能为空！";

                }
                else if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='" + Text4.Value + "'"))
                {
                    hint.Value = "销货员工工号不存在于系统中！";

                }
                else if (bc.exists("SELECT * FROM SELLTABLE_MST WHERE SEID='"+Text1.Value +"'"))
                {
                    hint.Value = "此销货单已经存在系统中，不能再保存！";
                }
                else if (SEKEY == "Exceed Limited")
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

                    SEKEY = bc.numYMD(20, 12, "000000000001", "select * from SELLTABLE_DET", "SEKEY", "SE");
                    string SECOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                    string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
                    string STORAGEID = bc.getOnlyString("SELECT STORAGEID FROM STORAGEINFO WHERE STORAGENAME='" + STORAGENAME + "'");
                    string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[17].FindControl("TextBox18")).Text;
                    string SLID = bc.getOnlyString("SELECT SLID FROM STORAGE_LOCATION WHERE STORAGE_LOCATION='" + STORAGE_LOCATION + "'");
                    string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                    string SN = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                    string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                    string REMARK = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
                    string DELIVERYDATE = bc.getOnlyString("SELECT DELIVERYDATE FROM ORDER_DET WHERE ORID='" + Text2.Value +
                        "' AND SN='" + SN + "'");
                    SKU = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='" + WAREID + "'");
                    string FREECOUNT = ((TextBox)GridView1.Rows[k].Cells[16].FindControl("TextBox17")).Text;
                    if (string.IsNullOrEmpty(FREECOUNT))
                    {
                        FREECOUNT = Convert.ToString(0);
                    }
                    basec.getcoms("INSERT INTO SELLTABLE_DET(SEKEY,SEID,ORID,SN,REMARK,"
              + "Year,Month,Day) values('" + SEKEY + "','" + Text1.Value
              + "','" + Text2.Value + "','" + SN + "','" + REMARK + "','" + year + "','" + month + "','" + day + "')");

                    basec.getcoms("INSERT INTO MATERE(MRKEY,MATEREID,SN,WAREID,"
           + "MRCOUNT,STORAGEID,SLID,BATCHID,Date,MakerID,Year,Month,Day,FREECOUNT,SKU) values('" + SEKEY + "','" + Text1.Value
           + "','" + SN + "','" + WAREID + "','" + SECOUNT + "','" + STORAGEID + "','"+SLID +"','" + BATCHID + "','" + varDate +
           "','" + varMakerID + "','" + year + "','" + month + "','" + day + "','" + FREECOUNT + "','"+SKU+"')");


                    DataTable dtx6 = bc.getmaxstoragecount(WAREID,SKU);
                    if (dtx6.Rows.Count > 0)
                    {
                        for (int n = 0; n < count; n++)
                        {
                            if (((TextBox)GridView1.Rows[n].Cells[1].FindControl("TextBox2")).Text == WAREID)
                            {
                                ((TextBox)GridView1.Rows[n].Cells[11].FindControl("TextBox12")).Text = dtx6.Rows[0]["仓库"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox18")).Text = dtx6.Rows[0]["库位"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox13")).Text = dtx6.Rows[0]["批号"].ToString();
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox14")).Text = dtx6.Rows[0]["库存数量"].ToString();
                            }
                        }

                    }
                    else
                    {

                        for (int n = 0; n < count; n++)
                        {
                            if (((TextBox)GridView1.Rows[n].Cells[1].FindControl("TextBox2")).Text == WAREID)
                            {
                                ((TextBox)GridView1.Rows[n].Cells[11].FindControl("TextBox12")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox18")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox13")).Text = "";
                                ((TextBox)GridView1.Rows[n].Cells[12].FindControl("TextBox14")).Text = "";
                            }
                        }
                    }
                    
                }

            }/*under FOR OUTSIDE*/
            corder.UPDATE_ORDER_STATUS(Text2.Value);
            if (!bc.exists("SELECT SEID FROM SELLTABLE_DET WHERE SEID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT SEID FROM SELLTABLE_MST WHERE SEID='" + Text1.Value + "'"))
            {

                basec.getcoms("INSERT INTO SELLTABLE_MST(SEID,SELLDATE,SELLERID,CUKEY,MAKERID,DATE,"
+ "Year,Month,Day) values('" + Text1.Value + "','" + Text3.Value
+ "','" + Text4.Value + "','" + CUKEY.Value + "','" + varMakerID + "','" + varDate + "','" + year + "','" + month + "','" + day + "')");
                IFExecution_SUCCESS = true;

            }
            else
            {
                basec.getcoms("UPDATE SELLTABLE_MST SET SELLDATE='" + Text3.Value + "',SELLERID='" + Text4.Value +
                    "',CUKEY='" + CUKEY.Value + "',MAKERID='" + varMakerID + "',DATE='" + varDate + "' WHERE SEID='" + Text1.Value + "'");
                IFExecution_SUCCESS = true;
            }

            bind();
        }
        #endregion
        #region ac1()
        private int ac1(int k)
        {
            int x = 1;
            string SECOUNT = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
            string STORAGENAME = ((TextBox)GridView1.Rows[k].Cells[11].FindControl("TextBox12")).Text;
            string STORAGE_LOCATION = ((TextBox)GridView1.Rows[k].Cells[17].FindControl("TextBox18")).Text;
            string BATCHID = ((TextBox)GridView1.Rows[k].Cells[12].FindControl("TextBox13")).Text;
            string NOSECOUNT = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
            string STORAGECOUNT = ((TextBox)GridView1.Rows[k].Cells[13].FindControl("TextBox14")).Text;
            string WAREID = ((TextBox)GridView1.Rows[k].Cells[1].FindControl("TextBox2")).Text;
            string v1 = bc.getOnlyString("SELECT SKU FROM WAREINFO WHERE WAREID='"+WAREID +"'");
            string k1 = bc.CheckingWareidAndStorage(WAREID, STORAGENAME,STORAGE_LOCATION , BATCHID,v1);
            string FREECOUNT = ((TextBox)GridView1.Rows[k].Cells[16].FindControl("TextBox17")).Text;
          
            if (FREECOUNT == "")
            {

                FREECOUNT = Convert.ToString(0);
            }
            if (SECOUNT=="")
            {
                x = 0;
                hint.Value = "销货数量不能为空！";
            }
            else if (decimal.Parse (SECOUNT)==0)
            {
                x = 0;
                hint.Value = "销货数量不能为0！";
            }
            else  if (bc.yesno(SECOUNT) == 0 || bc.yesno(FREECOUNT) == 0)
            {
                x = 0;
                hint.Value = "数量只能输入数字！";
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

            else if (decimal.Parse(SECOUNT) > decimal.Parse(NOSECOUNT))
            {
                x = 0;
                hint.Value = "销货数量不能大于未销货数量！";


            }
            else if (k1 != STORAGECOUNT)
            {
                x = 0;
                hint.Value = "选择的库存品号与此项次销货品号不一致！";
               

            }
            else if (decimal.Parse(SECOUNT) + decimal.Parse(FREECOUNT) > decimal.Parse(STORAGECOUNT))
            {
                x = 0;
                hint.Value = "销货数量+FREE数量不能大于库存数量！";
            }
          
            return x;

        }
        #endregion

        private bool ac0(string s1, string s2)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM SELLTABLE_DET WHERE SEID='" + s1 + "'"))
            {
                string s3 = bc.getOnlyString("SELECT ORID FROM SELLTABLE_DET WHERE SEID='" + s1 + "'");
                if (s3 != s2)
                {
                    hint.Value = "同一个销货单下面只能出现一个订单号!";
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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM SELLTABLE_MST", "SEID", "SE");
            bind();
        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SellManage/SELLTABLE.aspx" + n2);
        }
        #region gridview deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM SELLTABLE_MST WHERE SEID='" + Text1.Value + "'";
                sql3 = "DELETE FROM SELLTABLE_DET WHERE SEID='" + Text1.Value + "' AND SN='" + ID + "'";
                string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + Text2.Value + "'");
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此销货单对应的订单已经对帐，不允许删除";

                }
                else if (juage())
                {


                }
                else
                {
                    basec.getcoms(sql3);
                    basec.getcoms("DELETE  MATERE WHERE MATEREID='" + Text1.Value + "' AND SN='" + ID + "'");
                    if (!bc.exists("SELECT * FROM SELLTABLE_DET WHERE SEID='" + Text1.Value + "'"))
                    {
                        basec.getcoms(sql2);
                    }

                    corder.UPDATE_ORDER_STATUS(Text2.Value);
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

                            bc.ExcelPrint(dtn, "销货单", "");
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

                            bc.ExcelPrint(dtn, "销货单", "");
                        }
                        else
                        {
                            hint.Value = bc.ErrowInfo;

                        }

                    }
                    else
                    {
                        hint.Value = "一张销货单最多支持打印20个销货项。超出20请建多张销货单！";

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
