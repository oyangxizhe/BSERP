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

namespace WPSS.STOCKMANAGE
{
    public partial class MISC_GODE : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        basec bc = new basec();
        CMRP mrp = new CMRP();
        CCO_ORDER cco_order = new CCO_ORDER();
        CMISC_GODE cMISC_GODE = new CMISC_GODE();
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
            GridView1.PageSize = 10;
            selecto();
            try
            {

            }
            catch (Exception)
            {

            }

        }
        #endregion

        #region selecto() /*use bom_mst */
        protected void selecto()
        {
            string v1 = Text1.Value;/*cname*/
            string v2 = Text2.Value;/*MGID*/
            string v3 = Text3.Value;/*wname*/
            string v4 = Text4.Value;/*co_wareid*/
            DataView dv = new DataView(dt_empty());
            string xi = "";
            if (CheckBox1.Checked)
            {
                xi = " AND 客户或供应商 like '%" + v1 + "%' ";

            }
            dv.RowFilter = @" 
                        料号 LIKE '%" + v4 +
                                        "%' AND 品名 like '%" + v3 +
                                        "%' AND 入库单号 like '%" + v2 +
                                        "%' "+xi;
            dv.Sort = "制单日期  DESC";
            
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
        #region dt_empty
        public DataTable dt_empty()
        {
            DataTable dtt = new DataTable();
            dtt = bc.getdt(cMISC_GODE.sqlfi);
            return dtt;
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "入库单号" };
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

            string v = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            WPSS.STOCKMANAGE.MISC_GODET.IDO = v;
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../stockmanage/misc_GODEt.aspx" + n2);
        }
        #region delete
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql, sql1;
            hint.Value = "";
            string id = GridView1.DataKeys[e.RowIndex][0].ToString();
            sql = "DELETE MISC_GODE_MST WHERE MGID='" + id + "'";
            sql1 = "DELETE MISC_GODE_DET WHERE MGID='" + id + "'";
            if (cMISC_GODE.JUAGE_CURRENT_STORAGECOUNT_IF_LESSTHAN_DELETE_COUNT(id))
            {
                hint.Value = cMISC_GODE.ErrowInfo;
            }
            else
            {
               
                basec.getcoms(sql);
                basec.getcoms(sql1);
                basec.getcoms("DELETE GODE WHERE GODEID='" + id + "'");
                GridView1.EditIndex = -1;
                Bind();
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
            MISC_GODET.IDO = cMISC_GODE.GETID;
            MISC_GODET.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../stockmanage/misc_GODEt.aspx" + n2);

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
