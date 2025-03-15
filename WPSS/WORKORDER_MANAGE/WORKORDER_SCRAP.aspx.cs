
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

namespace WPSS.WORKORDER_MANAGE
{
    public partial class WORKORDER_SCRAP : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER_SCRAP cworkorder_scrap = new CWORKORDER_SCRAP();
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
                showdata(@" where    E.CNAME like '%" + v1 + "%' AND D.CWAREID like '%" + v10 +
                    "%'  AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND D.WNAME like '%" + v9 +
                    "%' AND A.WOID LIKE '%" + v12 + "%' AND A.WSID LIKE '%" + v13 + "%'");
            }

            else
            {
                if (v1 == "" && v9 == "" && v10 == "" && DropDownList1.Text == "" && v12 == "" && v13 == "")
                {
                    showdata(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7");


                }
                else
                {
                    showdata(@" where    E.CNAME like '%" + v1 + "%' AND D.CWAREID like '%" + v10 +
                  "%'  AND D.WNAME like '%" + v9 + "%' AND A.WOID LIKE '%" + v12 + "%' AND A.WSID LIKE '%" + v13 + "%'");


                }


            }
            nextpage();
        }
        #endregion
        #region showdata
        protected void showdata(string sqlo)
        {
            if (DropDownList1.Text == "已结案")
            {
                dt = bc.getdt(cworkorder_scrap.getsql + sqlo + " AND F.WORKORDER_Status_MST='CLOSE' order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "部分入库")
            {

                dt = bc.getdt(cworkorder_scrap.getsql + sqlo + " AND F.WORKORDER_Status_MST='PROGRESS'  order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Delay")
            {

                dt = bc.getdt(cworkorder_scrap.getsql + sqlo + " AND F.WORKORDER_Status_MST='DELAY'  order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Open")
            {

                dt = bc.getdt(cworkorder_scrap.getsql + sqlo + " AND F.WORKORDER_Status_MST='OPEN'  order by A.DATE DESC");
            }
            else
            {
                dt = bc.getdt(cworkorder_scrap.getsql + sqlo + " order by A.DATE DESC");
            }
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
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

        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "WSID" };
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
            WORKORDER_SCRAPT.IDO = varID;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_SCRAPt.aspx" + n2);

        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql2, sql3;
            hint.Value = "";
            string ID = GridView1.DataKeys[e.RowIndex][0].ToString();
            sql2 = "DELETE FROM WORKORDER_SCRAP_MST WHERE WSID='" + ID + "'";
            sql3 = "DELETE FROM WORKORDER_SCRAP_DET WHERE WSID='" + ID + "' ";
            string s2 = bc.getOnlyString("SELECT WOID FROM WORKORDER_SCRAP_DET WHERE WSID='" + ID + "'");
            string s1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" + s2 + "'");
            string sqlo = @"SELECT * FROM WORKORDER_MST A";
            if (bc.JuageDeleteCount_MoreThanStorageCount(ID))
            {

                hint.Value = bc.ErrowInfo;
            }
            else
            {
                basec.getcoms(sql3);
                basec.getcoms("DELETE GODE WHERE GODEID='" + ID + "'");
                basec.getcoms(sql2);
                dt = bc.getdt(sqlo + " WHERE A.WOID='" + s2 + "'");
                cworkorder.UPDATE_WORKORDER_STATUS(s2);
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
            string var2 = bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_SCRAP_MST", "WSID", "WS");
            WORKORDER_SCRAPT.IDO = var2;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_SCRAPt.aspx" + n2);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            bind();
        }

    }
}
