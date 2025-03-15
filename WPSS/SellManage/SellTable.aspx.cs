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
using System.Net;
using System.Text;
using XizheC;
using System.IO;
using System.Diagnostics;

namespace WPSS.SellManage
{
    public partial class SellTable : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        CORDER corder = new CORDER();
        CSELL_TABLE csell_table = new CSELL_TABLE();
        protected string sql = @"
SELECT
DISTINCT(A.SEID) AS SEID,
B.ORID AS ORID,
B.SN AS SN,
D.CNAME AS CNAME,
A.SELLDATE AS SELLDATE,
E.CUSTOMERORID AS CUSTOMERORID,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.SELLERID )  AS SELLER,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER,
CASE WHEN E.ORDERStatus_MST='CLOSE' THEN '已出货'
WHEN E.ORDERStatus_MST='PROGRESS' THEN '部分出货'
WHEN E.ORDERStatus_MST='DELAY' THEN 'Delay'
ELSE 'Open'
END  AS ORDERStatus_MST,
C.DeliveryDate AS DELIVERYDATE,F.WName AS WNAME,F.CWareID AS CWAREID,
A.DATE AS DATE FROM SELLTABLE_MST A
LEFT JOIN SELLTABLE_DET B ON A.SEID=B.SEID
LEFT JOIN ORDER_DET C ON B.ORID=C.ORID AND B.SN=C.SN 
LEFT JOIN CUSTOMERINFO_MST D ON C.CUID=D.CUID
LEFT JOIN Order_MST E ON C.ORID =E.ORID 
LEFT JOIN WareInfo F ON C.WareID =F.WareID 
";
        protected string M_str_sql1;
        WPSS.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (va.returnb() == true)
            Response.Redirect("\\Default.aspx");  
            bind();
        }
        #region bind()
        private void bind()
        {
            hint.Value = "";
            x.Value = "";
            GridView1.PageSize = 10;
            select();
            try
            {
            
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region select()
        protected void select()
        {

            string v6 = "", v7 = "";
            string v1 = Text1.Value;
            string v2 = StartDate.Value;
            string v3 = EndDate.Value;
            string v9 = Text2.Value;
            string v10 = Text3.Value;
            string v11 = DropDownList1.Text;
            string v12 = Text4.Value;
            string v13 = Text5.Value;
            if (!bc.juagedate(v2, v3))
            {
                hint.Value = bc.ErrowInfo;
                clear();
                return;
            }
            if (v2 != "" && v3 != "")
            {
                DateTime v4 = Convert.ToDateTime(v2);
                DateTime v5 = Convert.ToDateTime(v3);
                v6 = v4.ToString("yyyy-MM-dd") + " 00:00:00";
                v7 = v5.ToString("yyyy-MM-dd") + " 23:59:59";

            }
            if (CheckBox1.Checked)
            {
                showdata(@" where    D.CNAME like '%" + v1 + "%' AND F.CWAREID like '%" + v10 +
                    "%'  AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND F.WNAME like '%" + v9 +
                    "%' AND B.ORID LIKE '%" + v12 + "%' AND A.SEID LIKE '%"+v13+"%'");
            }

            else
            {
                if (v1 == "" && v9 == "" && v10 == "" && DropDownList1.Text == "" && v12 == "" && v13=="")
                {
                    showdata(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7");
                  

                }
                else
                {
                    showdata(@" where    D.CNAME like '%" + v1 + "%' AND F.CWAREID like '%" + v10 +
                  "%'  AND F.WNAME like '%" + v9 + "%' AND B.ORID LIKE '%" + v12 + "%' AND A.SEID LIKE '%" + v13 + "%'");


                }


            }
            nextpage();
        }
        #endregion
        private void clear()
        {

            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Text1.Value = "";
            Text2.Value = "";
            Text3.Value = "";

        }
        #region showdata
        protected void showdata(string sqlo)
        {
            if (DropDownList1.Text == "已出货")
            {
                dt = bc.getdt(sql + sqlo + " AND E.ORDERStatus_MST='CLOSE' order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "部分出货")
            {

                dt = bc.getdt(sql + sqlo + " AND E.ORDERStatus_MST='PROGRESS' order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Delay")
            {

                dt = bc.getdt(sql + sqlo + " AND E.ORDERStatus_MST='DELAY'  order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Open")
            {

                dt = bc.getdt(sql + sqlo + " AND E.ORDERStatus_MST='OPEN'  order by A.DATE DESC");
            }
            else
            {
             
                dt = bc.getdt(sql + sqlo + "  order by A.DATE DESC");
            }
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {

            }

        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "SEID" };
            GridView1.DataBind();
            lblRecordCount.Text = "记录总数" + dt.Rows.Count + "条";
            lblPageCount.Text = "总页数" + (GridView1.PageCount).ToString() + "页";
            lblCurrentIndex.Text = "当前页第" + ((GridView1.PageIndex) + 1).ToString() + "页";
            if (dt.Rows.Count > 0)
            {
                if (GridView1.PageIndex == 0)
                {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                }
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                // 计算生成分页页码,分别为："首 页" "上一页" "下一页" "尾 页"
                btnFirst.CommandName = "1";
                btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

                btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
                btnLast.CommandName = GridView1.PageCount.ToString();
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

        }
        #endregion


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string varID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            String[] str = new string[] { varID };
            WPSS.SellManage.SellTableT.GETID[0] = str[0];
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SellManage/SellTableT.aspx"+n2);

        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string sql2, sql3;
                hint.Value = "";
                string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
                sql2 = "DELETE FROM SELLTABLE_MST WHERE SEID='" + ID + "'";
                sql3 = "DELETE FROM SELLTABLE_DET WHERE SEID='" + ID + "' ";
                string s2 = bc.getOnlyString("SELECT ORID FROM SELLTABLE_DET WHERE SEID='" + ID + "'");
                string s1 = bc.getOnlyString("SELECT ORDERSTATUS_MST FROM ORDER_MST WHERE ORID='" + s2 + "'");
 
                if (s1 == "RECONCILE")
                {
                    hint.Value = "此销货单对应的订单已经对帐，不允许删除";

                }
               else if (csell_table.JUAGE_RESIDUE_SECOUNT_IF_LESSTHAN_SR_COUNT(ID))
               { 

                hint.Value = csell_table.ErrowInfo;

                }
                else
                {

                    basec.getcoms(sql3);
                    basec.getcoms("DELETE MATERE WHERE MATEREID='" + ID + "'");
                    basec.getcoms(sql2);
                    corder.UPDATE_ORDER_STATUS(s2);
                    GridView1.EditIndex = -1;
                    bind();

                }

            }
            catch (Exception)
            {


            }


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
        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            bind();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            #region btngo
            try
            {
                if (txtNum.Text == "")
                {
                    //opAndvalidate.Show("页数不能为空");
                }
                else
                {
                    int vargo = Convert.ToInt32(txtNum.Text);
                    if (vargo <= GridView1.PageCount)
                    {
                        GridView1.PageIndex = Convert.ToInt32(txtNum.Text) - 1;
                        bind();
                    }
                    else
                    {
                        hint.Value = "没有找到记录";
                    }
                }
            }
            catch (Exception)
            {
                //opAndvalidate.Show("输入格式不正确，请检查！");
            }

            #endregion
        }
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            string var2 = bc.numYM(10, 4, "0001", "SELECT * FROM SELLTABLE_MST", "SEID", "SE");
            SellTableT.NEWID[0] = var2;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../SELLManage/SELLTABLET.aspx"+n2);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            bind();
        }

    }
}
