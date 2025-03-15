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
    public partial class WORKORDERT : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        basec bc = new basec();
        XizheC.CBOM cbom = new CBOM();
        CCO_ORDER cco_order = new CCO_ORDER();
        CMRP cmrp = new CMRP();
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER cworkorder1 = new CWORKORDER();
        CWORKORDER_PICKING cworkorder_picking = new CWORKORDER_PICKING();
        WPSS.Validate va = new Validate();
        
        DataTable dt4 = new DataTable();
        private static string _IDO;
        public static string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private bool _FORCE_USE_BOM;
        public bool FORCE_USE_BOM
        {
            set { _FORCE_USE_BOM = value; }
            get { return _FORCE_USE_BOM; }

        }
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private static string _ADD_OR_UPDATE;
        public static string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }

        }
        private bool _SAVE_OR_EDIT;
        public bool SAVE_OR_EDIT
        {
            set { _SAVE_OR_EDIT = value; }
            get { return _SAVE_OR_EDIT; }

        }
        private int _EXECUTIONS;
        public int EXECUTIONS
        {
            set { _EXECUTIONS = value; }
            get { return _EXECUTIONS; }

        }
        string WOKEY;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
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
            Text1.Value = IDO;
            DataTable dtx = bc.getdt(cworkorder.getsql + " WHERE A.WOID='" + Text1.Value + "'");
            if (dtx.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                Text2.Value = dtx.Rows[0]["ID"].ToString();
                Text3.Value = dtx.Rows[0]["料号"].ToString();
                Text4.Value = dtx.Rows[0]["品名"].ToString();
                Text5.Value = dtx.Rows[0]["客户料号"].ToString();
                Text6.Value = dtx.Rows[0]["工单数量"].ToString();
                Text7.Value = dtx.Rows[0]["厂内订单号"].ToString();
                Text8.Value = dtx.Rows[0]["交货日期"].ToString();
                Text9.Value = dtx.Rows[0]["入库需求日期"].ToString();
                Text10.Value = dtx.Rows[0]["最晚下料日期"].ToString();
                Text11.Value = dtx.Rows[0]["齐套日期"].ToString();
                Text12.Value = dtx.Rows[0]["建议客户交期"].ToString();
                Text13.Value = dtx.Rows[0]["BOM编号"].ToString();
                Text14.Value = dtx.Rows[0]["BOM版本"].ToString();
                Text17.Value = dtx.Rows[0]["客户ID"].ToString();
                Text18.Value = dtx.Rows[0]["客户代码"].ToString();
                Text19.Value = dtx.Rows[0]["客户名称"].ToString();
            }
    
            else
            {

                string varDate = DateTime.Now.ToString("yyy-MM-dd");
                Text2.Value = "";
                Text3.Value = "";
                Text4.Value = "";
                Text5.Value = "";
                Text6.Value = "";
                Text7.Value = "";
                Text8.Value = varDate;
                Text9.Value = varDate;
                Text10.Value = varDate;
                Text11.Value = varDate;
                Text12.Value = varDate;
                Text13.Value = "";
                Text14.Value = "";
                Text17.Value = "";
                Text18.Value = "";
                Text19.Value = "";
                Text20.Value = "";
            }
            bind2();
            DataView dv = new DataView(cworkorder.ask());
            dv.RowFilter = "工单号='" + Text1.Value  + "'";
            DataTable dtx2 = dv.ToTable();
            if (dtx2.Rows.Count > 0)
            {

                Text15.Value = dtx2.Rows[0]["累计工单入库数量"].ToString();
                Text16.Value = dtx2.Rows[0]["未入库数量"].ToString();
                Text20.Value = dtx2.Rows[0]["累计工单报废数量"].ToString();
            }
            else
            {
                Text15.Value = "0";
                Text16.Value = "0";
                Text20.Value = "0";
            }
          
          
        }
        #endregion
        private void bind2()
        {
            DataTable dtx1 = new DataTable();
            cmrp.IDO = Text2.Value;
            cmrp.WO_COUNT = Text6.Value;
            dt = cmrp.getdigui(Text2.Value, 1, 1);
            dtx1 = dt;
            DataTable dtx2 = cworkorder.GET_WORKORDER_DET_DATA(Text1.Value);
            if (dtx2.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
            }
            else
            {
                dtx2 = dt;
            }
            if (FORCE_USE_BOM == true)
            {
                dtx2 = dt;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            GridView2.DataSource = dtx2;
            GridView2.DataBind();

            string s1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" + Text1.Value + "'");
            if (s1 == "CANCEL")
            {
                btnCancellation.Text = "已作废";
                btnCancellation.Enabled = false;
                btnReduction_Cancellation.Enabled = true;

            }
            else if (!bc.exists("SELECT * FROM WORKORDER_PICKING_MST WHERE WOID='" + Text1.Value + "'"))
            {
                btnCancellation.Text = "作废";
                btnCancellation.Enabled = true;
                btnReduction_Cancellation.Enabled = false;

            }
            else
            {

                btnCancellation.Enabled = false;
                btnReduction_Cancellation.Enabled = false;

            }
        }
      
      
        private void save()
        {
            hint.Value = "";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            basec.getcoms("DELETE WORKORDER_DET WHERE WOID='" + Text1.Value + "'");
            cworkorder1.BOID = Text13.Value;
            cworkorder1.WAREID = Text2.Value;
            cworkorder1.XID = Text1.Value;
            cworkorder1.CRID = Text7.Value;
            cworkorder1.MAKERID = varMakerID;
            cworkorder1.WO_COUNT = Text6.Value;
            cworkorder1.SOURCE_STATUS = "MRP";
            cworkorder1.DELIVERY_DATE = Text8.Value;
            cworkorder1.GODE_NEED_DATE = Text9.Value;
            cworkorder1.LAST_PICKING_DATE = Text10.Value;
            cworkorder1.COMPLETE_DATE = Text11.Value;
            cworkorder1.ADVICE_DELIVER_DATE = Text12.Value;
        

            int k;
            int s2 = 1;
            for (k = 0; k < GridView2.Rows.Count; k++)
            {
                string DET_WAREID = ((TextBox)GridView2.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string SN = ((TextBox)GridView2.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string BOM_WAREID= ((TextBox)GridView2.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string UNIT_DOSAGE = ((TextBox)GridView2.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string ATTRITION_DOSAGE = ((TextBox)GridView2.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                string WO_DOSAGE = ((TextBox)GridView2.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                string IF_SUPPLY = ((TextBox)GridView2.Rows[k].Cells[19].FindControl("TextBox20")).Text;
                string PICKING_STORAGE = ((TextBox)GridView2.Rows[k].Cells[20].FindControl("TextBox21")).Text;
                
                if (DET_WAREID != "")
                {
                   
                        WOKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WORKORDER_DET", "WOKEY", "WO");
                        SN = Convert.ToString(s2);
                        cworkorder1.WOID = Text1.Value;
                        cworkorder1.DET_WAREID = DET_WAREID;
                        cworkorder1.BOM_WAREID = BOM_WAREID;
                        cworkorder1.IFC_SUPPLY = IF_SUPPLY;
                        cworkorder1.PICKING_STAGE = PICKING_STORAGE;
                        cworkorder1.SN = SN;
                        cworkorder1.UNIT_DOSAGE = UNIT_DOSAGE;
                        cworkorder1.ATTRITION_DOSAGE = ATTRITION_DOSAGE;
                        cworkorder1.WO_DOSAGE = WO_DOSAGE;
                        cworkorder1.SQlcommandE();
                        s2 = Convert.ToInt32(s2) + 1;
                } 
            }
    
            dt = bc.getdt(cbom.getsql + " WHERE B.WAREID='"+Text2.Value +"' AND B.ACTIVE='Y'");
            if (dt.Rows.Count > 0)
            {
                EXECUTIONS = dt.Rows.Count;

            }
            for (k = 0; k < EXECUTIONS; k++)
            {
                
                string DET_WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string BOM_WAREID = ((TextBox)GridView1.Rows[k].Cells[2].FindControl("TextBox3")).Text;
                string UNIT_DOSAGE = ((TextBox)GridView1.Rows[k].Cells[7].FindControl("TextBox8")).Text;
                string ATTRITION_DOSAGE = ((TextBox)GridView1.Rows[k].Cells[8].FindControl("TextBox9")).Text;
                string WO_DOSAGE = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                string IF_SUPPLY = ((TextBox)GridView1.Rows[k].Cells[15].FindControl("TextBox16")).Text;
                string PICKING_STORAGE = ((TextBox)GridView1.Rows[k].Cells[16].FindControl("TextBox17")).Text;
                if (DET_WAREID != "")
                {

                    WOKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM WORKORDER_DET", "WOKEY", "WO");
                    cworkorder1.WOID = Text1.Value;
                    cworkorder1.DET_WAREID = DET_WAREID;
                    cworkorder1.BOM_WAREID = BOM_WAREID;
                    cworkorder1.IFC_SUPPLY = IF_SUPPLY;
                    cworkorder1.PICKING_STAGE = PICKING_STORAGE;
                    cworkorder1.SN = Convert.ToString(s2);
                    cworkorder1.UNIT_DOSAGE = UNIT_DOSAGE;
                    cworkorder1.ATTRITION_DOSAGE = ATTRITION_DOSAGE;
                    cworkorder1.WO_DOSAGE = WO_DOSAGE;
                    cworkorder1.SQlcommandE();
                    s2 = Convert.ToInt32(s2) + 1;
                }
            }
     
            if (!bc.exists("SELECT * FROM WORKORDER_DET WHERE WOID='" + Text1.Value + "'"))
            {
                return;

            }
            if (!bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + Text1.Value + "'"))
            {
                cworkorder1.SQlcommandEo(cworkorder1 .getsqlt );
                IFExecution_SUCCESS = true;
            }
            else
            {
                cworkorder1.SQlcommandEo(cworkorder1.getsqlth+" WHERE  WOID='"+Text1.Value +"'");
                IFExecution_SUCCESS = true;
               

            }
            if (IFExecution_SUCCESS)
            {
                bind();
            }
        }
        private bool juage_2()
        {
            int k;
            bool b = false;
            for (k = 0; k < GridView2.Rows.Count; k++)
            {
                string DET_WAREID = ((TextBox)GridView2.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string SN = ((TextBox)GridView2.Rows[k].Cells[1].FindControl("TextBox2")).Text;
                string WO_DOSAGE = ((TextBox)GridView2.Rows[k].Cells[10].FindControl("TextBox11")).Text;
                string MPA_TO_STOCK = ((TextBox)GridView2.Rows[k].Cells[12].FindControl("TextBox13")).Text;
                string STOCK_TO_BOM = ((TextBox)GridView2.Rows[k].Cells[13].FindControl("TextBox14")).Text;
                decimal d1 = decimal.Parse(MPA_TO_STOCK);
                decimal d2 = decimal.Parse(STOCK_TO_BOM);
                //decimal d3 = Math.Ceiling(decimal .Parse (WO_DOSAGE )*d1/d2);
                decimal d4 = cworkorder.GET_REALITY_PICKING_DOSAGE(Text1.Value, SN);
                string GET_DET_WAREID = bc.getOnlyString("SELECT DET_WAREID FROM WORKORDER_DET WHERE WOID='"+Text1.Value +"' AND SN='"+SN+"'");
                if (DET_WAREID != "")
                {
                    if (WO_DOSAGE == "")
                    {
                        hint.Value = "工单用量不能为空！";
                        b = true;
                        break;
                    }
                    else if (bc.yesno(WO_DOSAGE) == 0)
                    {
                        hint.Value = "数量只能输入数字！";
                        b = true;
                        break;
                    }
                    else if (Math.Ceiling(decimal.Parse(WO_DOSAGE) * d1 / d2) < d4)
                    {
                        hint.Value = "修改的工单用量：" + WO_DOSAGE + " 换算成包装用量为：" + decimal.Parse(WO_DOSAGE) + " *" + d1 + 
                            " /" + d2 + "=" + Math.Ceiling(decimal.Parse(WO_DOSAGE) * d1 / d2) +
                                                " 不能小于实际领料量！：" + d4;
                        b = true;
                        break;
                    }
                    else if (DET_WAREID != GET_DET_WAREID && d4>0)
                    {
                        hint.Value = "要更换的料号ID："+GET_DET_WAREID +" 已经有实际领料量 "+d4 +" 不允许变更该料号！";
                        b = true;
                        break;
                    }
                   
                }

            }
            return b;
        }
        private bool juage_1()
        {
            int k;
            bool b = false;
            dt = bc.getdt(cbom.getsql + " WHERE B.WAREID='" + Text2.Value + "' AND B.ACTIVE='Y'");
            if (dt.Rows.Count > 0)
            {
                EXECUTIONS = dt.Rows.Count;

            }
            for (k = 0; k < EXECUTIONS; k++)
            {

                string DET_WAREID = ((TextBox)GridView1.Rows[k].Cells[0].FindControl("TextBox1")).Text;
                string WO_DOSAGE = ((TextBox)GridView1.Rows[k].Cells[10].FindControl("TextBox11")).Text;
           
                if (DET_WAREID != "")
                {
                    if (WO_DOSAGE == "")
                    {
                        hint.Value = "工单用量不能为空！";
                        b = true;
                        break;
                    }
                    else if (bc.yesno(WO_DOSAGE) == 0)
                    {
                        hint.Value = "数量只能输入数字！";
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }
        protected void btnSure_Click(object sender, EventArgs e)
        {
            hint.Value = "";
            if (ac1() == 0)
            {
             
            }
            else if(cworkorder .JUAGE_REALITY_PICKING_COUNT(Text1.Value ))
            {
                hint.Value = "该工单已经有实际领料，不能重新展开BOM用量！";
            }
            else 
            {
                x.Value = Convert.ToString(1);
                FORCE_USE_BOM = true;
                bind2();

            }
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (ac1() == 0)
            {


            }
            else if (IFPRESS_SURE ())
            {
                

            }
            else if (juage_1())
            {

            }
            else if (juage_2())
            {

            }
            else
            {
                save();
            }
        }
        private bool IFPRESS_SURE()
        {
            bool b = false;
            if (GridView1.Rows.Count > 0)
            {
              

            }
            else
            {
                b = true;
                hint.Value = "点击确定带出BOM清单！";
            }

            return b;
        }
        protected DataTable dtxo()
        {
            DataTable dtxo = new DataTable();
            dtxo.Columns.Add("C", typeof(string));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dtxo.NewRow();
                dr["C"] = Convert.ToString(i);
                dtxo.Rows.Add(dr);
            }
            return dtxo;
        }
        protected void ClearText()
        {
            string varDate = DateTime.Now.ToString("yyy-MM-dd");
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
            Text6.Value = "";
            Text7.Value = "";
            Text8.Value = varDate;
            Text9.Value = varDate;
            Text10.Value = varDate;
            Text11.Value = varDate;
            Text12.Value = varDate;
            Text17.Value = "";
            Text18.Value = "";
            Text19.Value = "";
        }
        private bool ac0(string IDVALUE, string COMPARE_CONTENT)
        {
            bool c = true;
            if (bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + IDVALUE + "'"))
            {
                string s3 = bc.getOnlyString("SELECT WAREID FROM WORKORDER_MST WHERE WOID='" + IDVALUE + "'");
                if (s3 != COMPARE_CONTENT)
                {
                    hint.Value = "单头料号与单身展开的BOM料号不一致,因该工单号来自厂内订单!";
                    c = false;
                }
            }
            return c;

        }
        #region ac1()
        private int ac1()
        {
                int x = 1;
                DateTime temp = DateTime.MinValue;
                string v1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='"+Text1.Value +"'");
                if (v1 == "CLOSE")
                {
                    x = 0;
                    hint.Value = "该工单号已经结案，不能对其操作！";
                }
                else if (decimal .Parse (Text6.Value )<cworkorder .GET_REALITY_PICKING_COUNT (Text1.Value ))
                {
                    x = 0;
                    hint.Value = "工单数量：" + Text6.Value + "不能小于工单已经领料数量：" + cworkorder.GET_REALITY_PICKING_COUNT(Text1.Value);
                }
                else if (Text2.Value == "")
                {
                    x = 0;
                    hint.Value = "ID不能为空！";
                }
                else if (!bc.exists("select * from WAREinfo where WAREid='" + Text2.Value  + "' AND ACTIVE='Y'"))
                {
                    x = 0;
                    hint.Value = "该品号不存在于系统中或状态不为正常！";

                }
                else if (Text6.Value == "")
                {

                    x = 0;
                    hint.Value = "工单数量不能为空！";
                   
                }
                else if (bc.yesno(Text6.Value) == 0)
                {
                    x = 0;
                    hint.Value = "数量只能输入数字！";
                 
                }
                else if (cbom.IFNOEXISTS_BOM(Text2.Value))
                {
                    x = 0;
                    hint.Value = cbom.ErrowInfo;
                }
                else  if (Text7.Value != "" && !ac0(Text1.Value, Text2.Value))
                {
                    x = 0;
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
        #region gridview2 delete
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
           
        }
        #endregion
 
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

     
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            add();
        }
        protected void add()
        {
            //ClearText();
            IDO = cworkorder.GETID; 
            bind();
            ADD_OR_UPDATE = "ADD";
        }
   
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../WORKORDER_MANAGE/workorder.aspx"+n2);
        }

        protected void btnReconcile_Click(object sender, EventArgs e)
        {
            reconcile();
            try
            {
               
            }
            catch (Exception)
            {

            }
        }
  
        protected void reconcile()
        {
            
            hint.Value = "";
            basec.getcoms("UPDATE BOM_MST SET ACTIVE='Y' WHERE BOID='" + Text1.Value + "'");
            bind();
   

        }

        protected void btnReductionReconcile_Click(object sender, EventArgs e)
        {
            try
            {
                basec.getcoms("UPDATE BOM_MST SET BOMSTATUS_MST='CLOSE' WHERE BOID='" + Text1.Value + "'");
                bind();
            }
            catch (Exception)
            {

            }
        }
        protected void btnCancellation_Click(object sender, EventArgs e)
        {
            if (bc.exists("SELECT * FROM WORKORDER_PICKING_MST WHERE WOID='"+Text1.Value +"'"))
            {

                hint.Value = "此工单已有领料记录不能作废！";
            }
            else
            {
                basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='CANCEL' WHERE WOID='"+Text1.Value +"'");
                bind();
            }
            try
            {

            }
            catch (Exception)
            {

            }
        }
        protected void btnReduction_Cancellation_Click(object sender, EventArgs e)
        {
              if (bc.JuageCurrentDateIFAboveDeliveryDate(Text1.Value, 2))
                {

                    basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='DELAY' WHERE WOID='" + Text1.Value + "'");
                }
                else
                {
                    basec.getcoms("UPDATE WORKORDER_MST SET WORKORDER_STATUS_MST='OPEN' WHERE WOID='" + Text1.Value + "'");

                }
              bind();
            try
            {

            }
            catch (Exception)
            {

            }
        }
        protected void btnOnloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                CFileInfo cf = new CFileInfo();
                cf.OnloadFile(Text1.Value);
                hint.Value = cf.ErrowInfo;
               
            }
            catch (Exception)
            {

            }
        }
        protected void delete_wareid_file(string v1)
        {

         
            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" +v1+ "'");
            string s1 = Server.MapPath(FilePath);
            if (File.Exists(s1))
            {
                File.Delete(s1);
            }
            string strSql = "DELETE FROM WAREFILE WHERE FLKEY='" + v1+ "'";
            basec.getcoms(strSql);
        }
 
    }
}
