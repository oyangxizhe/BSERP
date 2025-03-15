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
    public partial class SupplierInfo : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        protected string M_str_sql = @"
select  A.SUID AS SUID,A.SNAME AS SNAME,B.CONTACT AS CONTACT,B.PHONE AS PHONE,B.FAX AS FAX,
B.EMAIL AS MAIL,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID )  AS MAKER,A.DATE AS DATE,
B.ADDRESS AS ADDRESS,A.PAYMENT AS PAYMENT,A.PAYMENT_CLAUSE AS PAYMENT_CLAUSE from 
SUPPLIERINFO_MST A LEFT JOIN SUPPLIERINFO_DET B ON A.SUKEY=B.SUKEY";
        protected string M_str_sql1;
        WPSS.Validate va = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
            Bind();
           if (va.returnb() == true)
            Response.Redirect("\\Default.aspx");  
        }

        #region Bind()
        private void Bind()
        {
            
            try
            {
                hint.Value = "";
                x.Value = "";
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

            string v5 = "", v6 = "";
            string v1 = StartDate.Value;
            string v2 = EndDate.Value;
            if (!bc.juagedate(v1, v2))
            {
                hint.Value = bc.ErrowInfo;
                return;
            }
            if (v1 != "" && v2 != "")
            {
                DateTime v3 = Convert.ToDateTime(v1);
                DateTime v4 = Convert.ToDateTime(v2);
                v5 = v3.ToString("yyyy-MM-d") + " 00:00:00";
                v6 = v4.ToString("yyyy-MM-d") + " 23:59:59";

            }

            if (Text1.Value != "" && StartDate.Value == "" && EndDate.Value == "")
            {


                M_str_sql1 = M_str_sql + " where A.SUID like '%" + Text1.Value + "%'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    hint.Value = "没有找到记录";

                }

            }
            else if (Text1.Value == "" && StartDate.Value != "" && EndDate.Value != "")
            {
                M_str_sql1 = M_str_sql + " where A.DATE BETWEEN  '" + v5 + "'AND '" + v6 + "'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    hint.Value = "没有找到记录";
                }

            }
            else if (Text1.Value != "" && StartDate.Value != "" && EndDate.Value != "")
            {
                M_str_sql1 = M_str_sql + " where A.DATE BETWEEN  '" + v5 + "'AND '" + v6 + "' AND A.SUID LIKE '%" + Text1.Value + "%'";
                dt = basec.getdts(M_str_sql1);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    hint.Value = "没有找到记录";

                }
            }
            else
            {
                dt = basec.getdts(M_str_sql);
            

            }
            if (dt.Rows.Count > 0)
            {
                x.Value = Convert.ToString(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;

            }
            nextpage();
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "SUID" };
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

            string varSUID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            SupplierInfoT.IDO = varSUID;
            SupplierInfoT.ADD_OR_UPDATE = "UPDATE";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/SUPPLIERINFOT.aspx"+n2);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                hint.Value = "";
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                if (bc.exists("select * from Purchase_det where SUID='" + id + "'"))
                {
                    hint.Value = "该供应商信息已经在采购单中存在不允许删除！";
                }
                else if (bc.exists("select * from QUALITY_INFO where SUID='" + id + "'"))
                {

                    hint.Value = "该供应商信息已经在品质履历中存在不允许删除！";
                }
                else if (bc.exists("select * from limite_search where cuid_or_suid='" + id + "'"))
                {
                    hint.Value = "该供应商信息已经在核价权限过滤信息中存在不允许删除！";
                }
                else
                {

                    string strSql1 = "DELETE FROM SUPPLIERINFO_MST WHERE SUID='" + id + "'";
                    basec.getcoms(strSql1);
                    basec.getcoms("DELETE FROM SUPPLIERINFO_DET WHERE SUID='" + id + "'");
                    GridView1.EditIndex = -1;
                    Bind();
                }
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
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM SUPPLIERINFO_MST", "SUID", "SU");
            SupplierInfoT.IDO = var1;
            SupplierInfoT.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../PurchaseManage/SUPPLIERINFOT.aspx"+n2);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
