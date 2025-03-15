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
using XizheC;
using System.IO;
using System.Diagnostics;

namespace WPSS.StockManage
{
    public partial class StorageInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        CSTORAGE_INFO cstorage_info = new CSTORAGE_INFO();
        WPSS.Validate va = new Validate();
        private static string _IDO;
        public static string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private static string _ADD_OR_UPDATE;
        public static string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }

        }
        string v2;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            hint.Value = "";
            if (!IsPostBack)
            {
             

                    Text1.Value = IDO;
                    dt = basec.getdts("select * from StorageINFO where STORAGEID='" + Text1.Value + "'");
                    if (dt.Rows.Count > 0)
                    {

                        Text2.Value = dt.Rows[0]["STORAGENAME"].ToString();
                        DropDownList1.Text = dt.Rows[0]["IFMRP_CALCULATE"].ToString();
                        DropDownList2.Text = dt.Rows[0]["PURCHASE_GODE"].ToString();
                        DropDownList3.Text = dt.Rows[0]["WORKORDER_GODE"].ToString();
                        DropDownList4.Text = dt.Rows[0]["WORKORDER_SCRAP"].ToString();
                        DropDownList5.Text = dt.Rows[0]["WORKORDER_MATERIEL_SCRAP"].ToString();
                    }
            }

            if (va.returnb() == true)
            Response.Redirect("\\Default.aspx"); 
        }
        protected void ClearText()
        {
            Text2.Value = "";
            DropDownList1.Text = "";
            DropDownList2.Text = "N";
            DropDownList3.Text = "N";
            DropDownList4.Text = "N";
            DropDownList5.Text = "N";
        }

        protected void save()
        {
          
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            v2 = bc.getOnlyString("SELECT STORAGENAME FROM StorageINFO WHERE  STORAGEID='" + Text1.Value + "'");
            if (!bc.exists("SELECT SToRAGEID FROM StorageINFO WHERE STORAGEID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from StorageINFO where STORAGENAME='" + Text2.Value + "'"))
                {

                    hint.Value = "该仓库名称已经存在了！";
                }
                else
                {
                    SQlcommandE(cstorage_info.sqlt);
                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from StorageINFO where storageName='" + Text2.Value + "'"))
                {
                    hint.Value = "该仓库名称已经存在了！";
                }
                else
                {
                    SQlcommandE(cstorage_info.sqlth + " WHERE STORAGEID='" + Text1.Value + "'");
                }
            }
            else
            {
                SQlcommandE(cstorage_info.sqlth + " WHERE STORAGEID='" + Text1.Value + "'");
            }
        }
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@STORAGEID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@STORAGENAME", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@IFMRP_CALCULATE", SqlDbType.VarChar, 20).Value = DropDownList1.Text;
            if (DropDownList2.Text =="Y")
            {
                basec.getcoms("UPDATE STORAGEINFO SET PURCHASE_GODE='N' WHERE STORAGEID NOT IN ('"+Text1.Value +"')");
            }
            if (DropDownList3.Text == "Y")
            {
                basec.getcoms("UPDATE STORAGEINFO SET WORKORDER_GODE='N' WHERE STORAGEID NOT IN ('" + Text1.Value + "')");
            }
            if (DropDownList4.Text == "Y")
            {
                basec.getcoms("UPDATE STORAGEINFO SET WORKORDER_SCRAP='N' WHERE STORAGEID NOT IN ('" + Text1.Value + "')");
            }
            if (DropDownList5.Text == "Y")
            {
                basec.getcoms("UPDATE STORAGEINFO SET WORKORDER_MATERIEL_SCRAP='N' WHERE STORAGEID NOT IN ('" + Text1.Value + "')");
            }
            sqlcom.Parameters.Add("@PURCHASE_GODE", SqlDbType.VarChar, 20).Value = DropDownList2.Text;
            sqlcom.Parameters.Add("@WORKORDER_GODE", SqlDbType.VarChar, 20).Value = DropDownList3.Text;
            sqlcom.Parameters.Add("@WORKORDER_SCRAP", SqlDbType.VarChar, 20).Value = DropDownList4.Text;
            sqlcom.Parameters.Add("@WORKORDER_MATERIEL_SCRAP", SqlDbType.VarChar, 20).Value = DropDownList5.Text;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {

            add();
        }
        private void add()
        {
            hint.Value = "";
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM StorageINFO", "STORAGEID", "ST");
            ADD_OR_UPDATE = "ADD";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            if (Text2.Value == "")
            {
                hint.Value = "仓库名称不能为空！";
            }
            else if (DropDownList2 .Text  == "")
            {
                hint.Value = "采购入库默认不能为空！";
            }
            else
            {
                save();
                if (ADD_OR_UPDATE == "ADD")
                {
                    add();
                }
              
            }
         
            try
            {
             
            }
            catch (Exception)
            {


            }

        }

        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../StockManage/StorageINFO.aspx"+n2);
        }

    }
}
