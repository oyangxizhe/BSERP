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

namespace WPSS.BaseInfo
{
    public partial class CompanyInfoP : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dtx2 = new DataTable();
        basec bc = new basec();

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
           if (Text1.Value != "")
            {
           
                DataRow[] dr = ask().Select("公司名称 LIKE '%" + Text1 .Value + "%'");
                if (dr.Length > 0)
                {
                    dt = asko();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        DataRow dr1 = dt.NewRow();
                        dr1["公司代码"] = dr[i]["公司代码"].ToString();
                        dr1["公司名称"] = dr[i]["公司名称"].ToString();
                        dr1["联系人"] = dr[i]["联系人"].ToString();
                        dr1["联系电话"] = dr[i]["联系电话"].ToString();
                        dr1["地址"] = dr[i]["地址"].ToString();
                        dt.Rows.Add(dr1);
                    }
                }
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
                dt = ask();
                GridView1.DataSource =ask();
                GridView1.DataKeyNames = new string[] { "公司代码" };
                GridView1.DataBind();

            }
            nextpage();
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "公司代码" };
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

        #region ask
        private DataTable ask()
        {
            int i,j;
            DataTable dtt = asko();
            DataTable dtx1 = bc.getdt(@"SELECT A.CUID AS CUID,B.CNAME AS CNAME,A.CONTACT AS CONTACT,A.PHONE AS PHONE,A.ADDRESS AS ADDRESS  
           FROM CUSTOMERINFO_DET A LEFT JOIN CUSTOMERINFO_MST B ON A.CUID=B.CUID ");
            if (dtx1.Rows.Count > 0)
            {
                for (i = 0; i < dtx1.Rows.Count; i++)
                {
                    DataRow dr = dtt.NewRow();
                    dr["公司代码"] = dtx1.Rows[i]["CUID"].ToString();
                    dr["公司名称"] = dtx1.Rows[i]["CNAME"].ToString();
                    dr["联系人"] = dtx1.Rows[i]["CONTACT"].ToString();
                    dr["联系电话"] = dtx1.Rows[i]["PHONE"].ToString();
                    dr["地址"] = dtx1.Rows[i]["ADDRESS"].ToString();
                    dtt.Rows.Add(dr);

                }

            }

            DataTable dtx4 = bc.getdt(@"SELECT A.COID AS COID,B.CONAME AS CONAME,A.CONTACT AS CONTACT,A.PHONE AS PHONE,A.ADDRESS AS ADDRESS 
           FROM COMPANYINFO_DET A LEFT JOIN COMPANYINFO_MST B ON A.COID=B.COID ");
            if (dtx4.Rows.Count > 0)
            {
                for (j = 0; j < dtx4.Rows.Count; j++)
                {
                    DataRow dr1 = dtt.NewRow();
                    dr1["公司代码"] = dtx4.Rows[j]["COID"].ToString();
                    dr1["公司名称"] = dtx4.Rows[j]["CONAME"].ToString();
                    dr1["联系人"] = dtx4.Rows[j]["CONTACT"].ToString();
                    dr1["联系电话"] = dtx4.Rows[j]["PHONE"].ToString();
                    dr1["地址"] = dtx4.Rows[j]["ADDRESS"].ToString();
                    dtt.Rows.Add(dr1);

                }

            }

            return dtt;
        }
        #endregion
        #region ask
        private DataTable asko()
        {
           
            DataTable dtt = new DataTable();
            dtt.Columns.Add("公司代码", typeof(string));
            dtt.Columns.Add("公司名称", typeof(string));
            dtt.Columns.Add("联系人", typeof(string));
            dtt.Columns.Add("联系电话", typeof(string));
            dtt.Columns.Add("地址", typeof(string));
            return dtt;
        }
        #endregion
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            Bind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            

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
          
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }

    }
}
