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
    public partial class WORKORDER_PICKING : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        CMRP mrp = new CMRP();
        CCO_ORDER cco_order = new CCO_ORDER();
        CWORKORDER cworkorder = new CWORKORDER();
        CWORKORDER_PICKING cworkorder_picking = new CWORKORDER_PICKING();
        protected string M_str_sql1;
        WPSS.Validate va = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
            Bind();
        }
        #region Bind()
        private void Bind()
        {

            hint.Value = "";
            x.Value = "";
            GridView1.PageSize = 15;
            select();
            try
            {

            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region select() /*no cuid*/
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
                showdata(@" where    F.CNAME like '%" + v1 + "%' AND E.CWAREID like '%" + v10 +
                    "%'  AND A.DATE BETWEEN  '" + v6 + "'AND '" + v7 + "' AND E.WNAME like '%" + v9 +
                    "%' AND A.WOID LIKE '%" + v12 + "%' AND A.WPID LIKE '%" + v13 + "%'");
            }

            else
            {
                if (v1 == "" && v9 == "" && v10 == "" && DropDownList1.Text == "" && v12 == "" && v13 == "")
                {
                    showdata(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7");


                }
                else
                {
                    showdata(@" where    F.CNAME like '%" + v1 + "%' AND E.CWAREID like '%" + v10 +
                  "%'  AND E.WNAME like '%" + v9 + "%' AND A.WOID LIKE '%" + v12 + "%' AND A.WPID LIKE '%" + v13 + "%'");


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
            if (DropDownList1.Text == "已结案")
            {
              
                dt = bc.getdt(cworkorder_picking.getsql + sqlo + " AND D.WORKORDER_STATUS_MST='CLOSE' order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "部分入库")
            {

                dt = bc.getdt(cworkorder_picking.getsql + sqlo + " AND D.WORKORDER_STATUS_MST='PROGRESS'  order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Delay")
            {

                dt = bc.getdt(cworkorder_picking.getsql + sqlo + " AND D.WORKORDER_STATUS_MST='DELAY'  order by A.DATE DESC");
            }
            else if (DropDownList1.Text == "Open")
            {

                dt = bc.getdt(cworkorder_picking.getsql + sqlo + " AND D.WORKORDER_STATUS_MST='OPEN'  order by A.DATE DESC");
            }
            else
            {
                dt = bc.getdt(cworkorder_picking.getsql + sqlo + " order by A.DATE DESC");
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

            GridView1.DataKeyNames = new string[] { "WPID" };
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

            string varORID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            WPSS.WORKORDER_MANAGE.WORKORDER_PICKINGT.IDO = varORID;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../WORKORDER_MANAGE/workorder_pickingT.aspx" + n2);
        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql, sql1;
            hint.Value = "";
            string id = GridView1.DataKeys[e.RowIndex][0].ToString();
            string v1 = bc.getOnlyString("SELECT WOID FROM WORKORDER_PICKING_MST WHERE WPID='" +id+ "'");
            string s1 = bc.getOnlyString("SELECT WORKORDER_STATUS_MST FROM WORKORDER_MST WHERE WOID='" +v1 + "'");
            if (s1 == "CLOSE")
            {
                hint.Value = "此领料单对应的工单已经结案，不允许删除";

            }
            else if (bc.JuagePICKING_DATE_IFLESSTHEN_GODE_DATE(id, v1))
            {
                hint.Value = bc.ErrowInfo;

            }
            else if (cworkorder_picking.JUAGE_RESIDUE_PICKING_COUNT_IF_LESSTHAN_REPICING_COUNT(id))
            {
                hint.Value = cworkorder_picking.ErrowInfo;

            }
            else
            {
                sql = "DELETE WORKORDER_PICKING_MST WHERE WPID='" + id + "'";
                sql1 = "DELETE WORKORDER_PICKING_DET WHERE WPID='" + id + "'";
                basec.getcoms(sql);
                basec.getcoms(sql1);
                basec.getcoms("DELETE MATERE WHERE MATEREID='" + id + "'");
                GridView1.EditIndex = -1;
                Bind();
            }
            try
            {

            
                /*
                if (bc.exists("select * from selltable_DET where orid='" + id + "'"))
                {
                    hint.Value = "该订单已经在销货单中存在不允许删除！";
                    return;
                }
                else
                {

                
                }
                */
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
            WORKORDER_PICKINGT.IDO = cworkorder_picking.GETID;
            WORKORDER_PICKINGT.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../workorder_manage/workorder_pickingT.aspx" + n2);

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
