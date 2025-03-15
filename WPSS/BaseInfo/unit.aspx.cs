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

namespace WPSS.BaseInfo
{
    public partial class UNIT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        protected string sql = @"
SELECT 
A.UNID AS UNID,
A.UNIT AS UNIT,
(SELECT ENAME FROM EMPLOYEEINFO
WHERE EMID=A.MAKERID ) AS MAKER,
A.MAKERID,
A.DATE,
A.YEAR,
A.MONTH 
FROM UNIT A ";
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
            x.Value = "";
            x1.Value = "";
            hint.Value = "";

            if (Request.QueryString["wareid"] != null && Request.QueryString["nature"] != null)
            {

                selecto(Request.QueryString["wareid"],Request.QueryString["nature"]);

            }
            else
            {

                selecto("","");

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
        protected void selecto(string wareid,string nature)
        {
            string v1 = Text1.Value;/*UNIT*/
            
            if (nature == "purchase_det" && wareid!="")
            {
                DataView dv = new DataView(dt_empty(wareid));
                dv.RowFilter = "UNIT LIKE '%" + Text1.Value + "%'";
                dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    x.Value = Convert.ToString(1);
                    x1.Value = Convert.ToString(1);

                }
            }
            else
            {
                DataView dv = new DataView(dt_empty());
                dv.RowFilter = "UNIT LIKE '%" + Text1.Value + "%'";
                dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    x.Value = Convert.ToString(1);
                    x1.Value = Convert.ToString(1);

                }
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
        }
        #region dt_empty
        public DataTable dt_empty()
        {
            DataTable dtt = new DataTable();
            dtt = bc.getdt(sql);
            return dtt;
        }
        #endregion
        #region dt_empty
        public DataTable dt_empty(string WAREID)
        {

            DataTable dtt = new DataTable();
            dtt.Columns.Add("UNID", typeof(string));
            dtt.Columns.Add("UNIT", typeof(string));
            dtt.Columns.Add("MAKER", typeof(string));
            dtt.Columns.Add("DATE", typeof(string));
            dt = basec.getdts("SELECT * FROM WAREINFO WHERE WAREID='" +WAREID + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dtt.NewRow();
                dr["UNID"] = bc.getOnlyString ("SELECT UNID FROM UNIT WHERE UNIT='"+dt.Rows[0]["MPA_UNIT"].ToString()+"'");
                dr["UNIT"] = dt.Rows[0]["MPA_UNIT"].ToString();
                dr["MAKER"] = bc.getOnlyString(@"SELECT (SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER 
                              FROM UNIT A WHERE A.UNIT='" + dt.Rows[0]["MPA_UNIT"].ToString() + "'");
                dr["DATE"] = bc.getOnlyString("SELECT DATE FROM UNIT WHERE UNIT='" + dt.Rows[0]["MPA_UNIT"].ToString() + "'");
                dtt.Rows.Add(dr);

                DataRow dr1 = dtt.NewRow();
                dr1["UNID"] = bc.getOnlyString("SELECT UNID FROM UNIT WHERE UNIT='" + dt.Rows[0]["SKU"].ToString() + "'");
                dr1["UNIT"] = dt.Rows[0]["SKU"].ToString();
                dr1["MAKER"] = bc.getOnlyString(@"SELECT (SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER 
                              FROM UNIT A WHERE A.UNIT='" + dt.Rows[0]["SKU"].ToString() + "'");
                dr1["DATE"] = bc.getOnlyString("SELECT DATE FROM UNIT WHERE UNIT='" + dt.Rows[0]["SKU"].ToString() + "'");
                dtt.Rows.Add(dr1);

                DataRow dr2 = dtt.NewRow();
                dr2["UNID"] = bc.getOnlyString("SELECT UNID FROM UNIT WHERE UNIT='" + dt.Rows[0]["BOM_UNIT"].ToString() + "'");
                dr2["UNIT"] = dt.Rows[0]["BOM_UNIT"].ToString();
                dr2["MAKER"] = bc.getOnlyString(@"SELECT (SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER 
                              FROM UNIT A WHERE A.UNIT='" + dt.Rows[0]["BOM_UNIT"].ToString() + "'");
                dr2["DATE"] = bc.getOnlyString("SELECT DATE FROM UNIT WHERE UNIT='" + dt.Rows[0]["BOM_UNIT"].ToString() + "'");
                dtt.Rows.Add(dr2);

            }
            return dtt;
        }
        #endregion
        #region nextpage()
        protected void nextpage()
        {

            GridView1.DataKeyNames = new string[] { "UNID" };
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

            string varID = GridView1.DataKeys[GridView1.SelectedIndex].Values[0].ToString();
            WPSS.BaseInfo.UNITT.IDO = varID;
            WPSS.BaseInfo.UNITT.ADD_OR_UPDATE = "UPDATE";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/UNITT.aspx"+n2);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex][0].ToString();
                string name = bc.getOnlyString("SELECT UNIT FROM UNIT WHERE UNID='"+id+"'");
                if (bc.exists ("SELECT * FROM WAREINFO WHERE MPA_UNIT='"+name +"' OR SKU='"+name +"' OR BOM_UNIT='"+name +"'"))
                {
                    hint.Value = "品号信息中已经存在此属性，不允许删除！";/*use purchase search mpa_unit*/
                }
                /*else if (bc.exists("SELECT * FROM PURCHASE_DET WHERE MPA_UNIT='" + name + "'"))
                {
                    hint.Value = "采购信息中已经存在此属性，不允许删除！";
                }*/
                else
                {
                    string strSql = "DELETE FROM UNIT WHERE UNID='" + id + "'";
                    basec.getcoms(strSql);
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

                        hint.Value = "索引超出范围'";
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

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            string var1 = bc.numYM(10, 4, "0001", "SELECT * FROM UNIT", "UNID", "UN");
            UNITT.IDO= var1;
            UNITT.ADD_OR_UPDATE = "ADD";
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/UNITT.aspx"+n2);
        }
    }
}
