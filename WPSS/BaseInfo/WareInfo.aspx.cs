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
    public partial class WareInfo : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        CWARE_INFO cware_info = new CWARE_INFO();
        basec bc = new basec();

        protected string M_str_sql1;
        WPSS.Validate va = new Validate();
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
            //Bind();
          
            if (va.returnb() == true)
            Response.Redirect("\\Default.aspx");
    
        }
        #region Bind()
        private void Bind()
        {
            x.Value = "";
            x1.Value = "";
            hint.Value = "";
            GridView1.PageSize = 6;
            if (Request.QueryString["cuid"] != null && Request.QueryString["nature"] != null)
            {
             
                selecto(Request.QueryString["cuid"], Request.QueryString["nature"]);
              
            }
            else if (Request.QueryString["nature"] != null)
            {
             
                selecto("", Request.QueryString["nature"]);
                
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
        protected void selecto(string cuid,string nature)
        {
            string v1 = Text1.Value;/*co_wareid*/
            string v9 = Text2.Value;/*wname*/
            string v10 = Text3.Value;/*spec*/
            string v11 = Text4.Value;/*brand*/
            string v12 = Text5.Value;/*cname*/
            string v13 = DropDownList1.Text;/*active*/
            string v14 =Text6.Value ;/*cwareid*/
            string v15 = Text7.Value;/*cwareid*/
            DataView dv = new DataView();
            if (nature == "order_det")
            {
                dv = new DataView(cware_info .GET_MAX_STORAGECOUNT ("O"));
            }
            else if (nature == "purchase_det")
            {
                dv = new DataView(cware_info .GET_MAX_STORAGECOUNT ("P"));
               
            }
            else
            {
             
                dv = new DataView(cware_info .GET_MAX_STORAGECOUNT ("W"));
            }
           string xi = "";
            string xi1 = "";
            if (nature == "bom_mst")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (8,9) AND CUID LIKE '%" + cuid + "%'";
            }
            else if (nature == "bom_det" )
            {
                xi = "SUBSTRING(WAREID,1,1) IN (5,8)";
            }
            else if (nature == "order_det")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (9)  AND CUID LIKE '%" + cuid + "%'";
            }
            else if (nature == "purchase_det")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (5)  AND CUID LIKE '%" + cuid + "%'";
           
            }
            else if (nature =="workorder_mst")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (8,9)";
            }
            else if (nature == "purchase_unitprice")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (5) AND CUID LIKE '%" + cuid + "%'";
            }
            else if (nature == "sell_unitprice")
            {
                xi = "SUBSTRING(WAREID,1,1) IN (9) AND CUID LIKE '%" + cuid + "%'";
            }
            else
            {
                xi = "SUBSTRING(WAREID,1,1) IN (5,8,9)";
            }
            if (CheckBox1.Checked)
            {
                xi1 = " AND BRAND like '%" + v11 + "%'";
            }
    
            if (DropDownList1.Text == "正常" || DropDownList1.Text == "")
            {

                dv.RowFilter = xi + @" 
                        AND CO_WAREID LIKE '%" + v1 +
                                       "%' AND WNAME like '%" + v9 +
                                       "%' AND SPEC like '%" + v10 +
                                       "%' "+xi1+" AND CNAME like '%" + v12 +
                                       "%' AND CWAREID like '%" + v14 +
                                       "%' AND WAREID LIKE '%"+v15+"%' AND ACTIVE='正常'";


            }
            else if (DropDownList1.Text == "Hold")
            {
                dv.RowFilter = xi + @" 
                        AND CO_WAREID LIKE '%" + v1 +
                                      "%' AND WNAME like '%" + v9 +
                                      "%' AND SPEC like '%" + v10 +
                                      "%' " + xi1 + " AND CNAME like '%" + v12 +
                                      "%' AND CWAREID like '%" + v14 +
                                      "%' AND WAREID LIKE '%" + v15 + "%' AND ACTIVE='Hold'";


            }
            else if (DropDownList1.Text == "作废")
            {

                dv.RowFilter = xi + @" 
                        AND CO_WAREID LIKE '%" + v1 +
                                      "%' AND WNAME like '%" + v9 +
                                      "%' AND SPEC like '%" + v10 +
                                      "%' " + xi1 + " AND CNAME like '%" + v12 +
                                      "%' AND CWAREID like '%" + v14 +
                                      "%' AND WAREID LIKE '%" + v15 + "%' AND ACTIVE='作废'";
            }
            else
            {
                dv.RowFilter = xi + @" 
                        AND CO_WAREID LIKE '%" + v1 +
                                        "%' AND WNAME like '%" + v9 +
                                        "%' AND SPEC like '%" + v10 +
                                        "%' " + xi1 + " AND CNAME like '%" + v12 +
                                        "%' AND CWAREID like '%" + v14 +
                                        "%' AND WAREID LIKE '%" + v15 + "%'";
            }
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

            GridView1.DataKeyNames = new string[] { "WAREID" };
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
      
        #region btnAdd_Click
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           


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
        #region GridView1_RowDeleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
             
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                if (bc.JuageIfAllowDeleteWareID(id))
                {
                    hint.Value = bc.ErrowInfo;
                }
                else
                {
                    string sql = "SELECT * FROM WAREFILE WHERE WAREID='" + id + "'";
                    DataTable dt1 = basec.getdts(sql);
                    if (dt1.Rows.Count > 0)
                    {
                        for (i = 0; i < dt1.Rows.Count; i++)
                        {
                            string FilePath = bc.getOnlyString("SELECT PATH FROM WAREFILE WHERE FLKEY='" + dt1.Rows[i]["FLKEY"].ToString() + "'");
                            string s1 = Server.MapPath(FilePath);
                            if (File.Exists(s1))
                            {
                                File.Delete(s1);
                            }
                        }
                    }
                    string strSql = "DELETE FROM WAREFILE WHERE WAREID='" + id + "'";
                    basec.getcoms(strSql);
                    string strSql1 = "DELETE FROM WareInfo WHERE WAREID='" + id + "'";
                    basec.getcoms(strSql1);
                    GridView1.EditIndex = -1;
                    Bind();
                }
            }
            catch (Exception)
            {


            }

        }
        #endregion
        #region  GridView1_RowDataBound
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
        #endregion
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

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Bind();
        }
        

    }
}
