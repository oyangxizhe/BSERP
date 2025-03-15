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
    public partial class OFFERSEARCH : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx2 = new DataTable();
        DataTable dtx4 = new DataTable();
        basec bc = new basec();
    
        string sqlo = @"
SELECT A.OFID AS 报价单号,
A.WareID as ID,
B.EUJ_WAREID AS EUJ料号,
B.WNAME AS 品名,
B.CWAREID AS 客户料号,
D.CName as 客户 ,
A.DATE AS 日期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID )  AS 制单人,
A.QUANTITY_UNITPRICE AS 量产单价,
A.QUANTITY_COUNT AS 量产数量,
A.SAMPLE_UNITPRICE AS Sample单价,
A.SAMPLE_COUNT AS Sample数量,
A.SMALLQUANTITY_UNITPRICE AS 小量单价,
C.PROJECT_COST AS 工程费
FROM OFFER A 
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN SPEC C ON C.SPEC=B.SPEC
LEFT JOIN CUSTOMERINFO_MST D ON B.CUID=D.CUID
";

        WPSS.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
             //if (va.returnb() == true)
            //Response.Redirect("\\Default.aspx");

        }
        #region bind()
        private void bind()
        {
           
         
            try
            {

                hint.Value = "";
                x.Value = "";
                x1.Value = "";
                GridView1.AllowPaging = true;
                GridView1.PageSize = 10;
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
            string v1 = Text1.Value;
            string v2 = StartDate.Value;
            string v3 = EndDate.Value;
            string v9 = Text2.Value;
            string v10 = Text3.Value;
        
            string v12 = Text4.Value;
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
                showdata(@" where    D.CNAME like '%" + v1 + "%' AND B.CWAREID like '%" + v10 +
                    "%'  AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND B.WNAME like '%" + v9 +
                    "%' AND A.OFID LIKE '%" + v12 + "%'");
            }

            else
            {
                
                showdata(@" where    D.CNAME like '%" + v1 + "%' AND B.CWAREID like '%" + v10 +
              "%'  AND B.WNAME like '%" + v9 + "%' AND A.OFID LIKE '%" + v12 + "%'");
            }

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
        protected void showdata(string sql)
        {
            dt = basec.getdts(sqlo+sql+" ORDER BY A.DATE DESC");
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                hint.Value = "没有找到记录！";
            }

            nextpage();
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "报价单号" };
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
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            bind();
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




    }
}
