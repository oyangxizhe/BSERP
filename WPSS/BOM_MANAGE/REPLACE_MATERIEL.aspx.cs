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

namespace WPSS.BOM_MANAGE
{
    public partial class REPLACE_MATERIEL : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        CBOM cbom = new CBOM();
        CREPLACE_MATERIEL creplace_materiel = new CREPLACE_MATERIEL();
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
            x.Value = "";
            x1.Value = "";
            hint.Value = "";
            GridView1.PageSize = 9;
            if (Request.QueryString["wareid"] != null && Request.QueryString["nature"] != null)
            {

                selecto(Request.QueryString["wareid"], Request.QueryString["nature"]);

            }
            else
            {

                selecto("", "");

            }
            try
            {

            }
            catch (Exception)
            {

            }

        }
        #endregion

        #region selecto() /*use bom_mst */
        protected void selecto(string wareid, string nature)
        {
            string v1 = Text1.Value;/*cname_or_sname*/
            string v9 = Text2.Value;/*rmid*/
            string v10 = Text3.Value;/*wname*/
            string v11 = Text4.Value;/*co_wareid*/
            DataView dv = new DataView(bc.getdt(creplace_materiel.sql));
            string xi = "";
            string xio = "";
            if (nature == "workorder_det")
            {
                xi = "ID  LIKE '%" + wareid + "%' AND ";
            }
            if (CheckBox1.Checked)
            {
                xio = " AND 客户名称 like '%" + v1 + "%' ";

            }
            dv.RowFilter = xi + @" 
料号 LIKE '%" + v11 +
"%' AND 品名 like '%" + v10 +
"%' AND 替代编号 like '%" + v9 +
"%'" + xio ;
            
            dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                x1.Value = Convert.ToString(1);

            }
      
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "替代编号" };
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

            string v1= GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            WPSS.BOM_MANAGE.REPLACE_MATERIELT.IDO = v1;
            REPLACE_MATERIELT.ADD_OR_UPDATE = "UPDATE";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BOM_MANAGE/REPLACE_MATERIELT.aspx" + n2);

        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string sql, sql1;
            hint.Value = "";
            string id = GridView1.DataKeys[e.RowIndex][0].ToString();

            sql = "DELETE REPLACE_MATERIEL_MST WHERE RMID='" + id + "'";
            sql1 ="DELETE  REPLACE_MATERIEL_DET WHERE RMID='" + id + "'";
                basec.getcoms(sql);
                basec.getcoms(sql1);
                GridView1.EditIndex = -1;
                Bind();
            
     
            /*if (bc.exists("select * from selltable_DET where BOID='" + id + "'"))
            {
                hint.Value = "该订单已经在销货单中存在不允许删除！";
                return;
            }
            else
            {

               
            }*/
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
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM REPLACE_MATERIEL_Mst", "RMID", "RM");
            REPLACE_MATERIELT.IDO = var1;
            REPLACE_MATERIELT.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BOM_MANAGE/REPLACE_MATERIELT.aspx" + n2);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
