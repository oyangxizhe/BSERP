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

namespace WPSS.PurchaseManage
{
    public partial class PurchaseUnitPrice : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        protected string sql = @"
SELECT 
A.PPID AS PPID,
A.WAREID AS WAREID,
B.CO_WAREID AS CO_WAREID,
B.WNAME AS WNAME,
B.CWAREID AS CWAREID,
A.PURCHASEUNITPRICE AS PURCHASEUNITPRICE,
C.SNAME AS SNAME,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER ,
A.DATE AS DATE,
A.CURRENCY AS CURRENCY
FROM PURCHASEUNITPRICE A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN SUPPLIERINFO_MST C ON A.SUID=C.SUID
";
        protected string M_str_sql1;
        WPSS.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        #region Bind()
        private void Bind()
        {
         
            try
            {

                x.Value = "";
                x1.Value = "";
                hint.Value = "";
                GridView1.PageSize = 15;
                select();
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
            string v1 = Text1.Value;/*sname*/
            string v2 = StartDate.Value;
            string v3 = EndDate.Value;
            string v9 = Text2.Value;/*wname*/
            string v10 = Text3.Value;/*cwareid*/
            string v11 = Text4.Value;/*co_wareid*/
            string xi = "";
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
            if (CheckBox2.Checked)
            {
                xi = "C.SNAME like '%" + v1 + "%' AND ";

            }
            if (CheckBox1.Checked)
            {
                showdata(" WHERE "+xi+" B.CWAREID like '%" + v10 +
                    "%'  AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND B.WNAME like '%" + v9 +
                    "%'  AND B.CO_WAREID like '%" + v11 +"%'");
            }
            else
            {
                if (v1 == "" && v9 == "" && v10 == "" && v11=="" )
                {
                    showdata(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7 ");

                }
                else
                {
                    showdata(@" where "+xi +"  B.CWAREID like '%" + v10 +
                  "%'  AND B.WNAME like '%" + v9 + "%'  AND B.CO_WAREID like '%" + v11 +"%'");
                }
            }
            nextpage();
        }
        #endregion
        private void clear()
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Text1.Value = "";
            Text2.Value = "";
            Text3.Value = "";
        }
        #region showdata
        protected void showdata(string sqlo)
        {
            dt = bc.getdt(sql + sqlo + " AND B.ACTIVE='Y' order by A.DATE DESC");
            if (dt.Rows.Count > 0)
            {
                x1.Value = Convert.ToString(1);
                x.Value = Convert.ToString(1);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "PPID" };
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
            Bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string v1 = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            WPSS.PurchaseManage.PurchaseUnitPriceT.IDO = v1;
            PurchaseUnitPriceT.ADD_OR_UPDATE = "UPDATE";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/PurchaseUnitPriceT.aspx" + n2);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                hint.Value = "";
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                string strSql1 = "DELETE FROM PurchaseUnitPrice WHERE PPID='" + id + "'";
                basec.getcoms(strSql1);
                GridView1.EditIndex = -1;
                Bind();
            }
            catch (Exception)
            {


            }

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


        protected void PageButton_Click(object sender, EventArgs e)
        {
            GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
            Bind();
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
                        Bind();
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
            string a = bc.numYM(10, 4, "0001", "select * from PurchaseUnitPrice", "PPID", "PP");
            if (a == "Exceed limited")
            {

                hint.Value = "编码超出限制！";
            }
            else
            {
                PurchaseUnitPriceT.IDO = a;
                PurchaseUnitPriceT.ADD_OR_UPDATE = "ADD";

            }
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/PurchaseUnitPriceT.aspx" + n2);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
