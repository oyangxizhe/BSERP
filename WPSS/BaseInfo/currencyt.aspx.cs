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


namespace WPSS.BaseInfo
{
    public partial class CURRENCYT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Bind();
            }
            Text2.Focus();
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        protected void Bind()
        {

            hint.Value = "";
            Text1.Value = IDO;
            dt = basec.getdts("select * from CURRENCY where CYID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["CURRENCY"].ToString();

            }
        }

        protected void ClearText()
        {
            Text2.Value = "";


        }
        #region juage()
        private bool juage()
        {

            bool b = true;

            return b;
        }
        #endregion


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {


            add();

        }
        private void add()
        {

            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM CURRENCY", "CYID", "CY");
            ADD_OR_UPDATE = "ADD";

        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
                hint.Value = "";
                if (juage())
                {
                    save();
                    if (ADD_OR_UPDATE == "ADD")
                    {
                        add();
                    }
                   
                }
            }
            catch (Exception)
            {

            }

        }
        #region save
        protected void save()
        {
            hint.Value = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 10, 10);
            string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");

            string v2 = bc.getOnlyString("SELECT CURRENCY FROM CURRENCY WHERE  CYID='" + Text1.Value + "'");
            if (!bc.exists("SELECT CYID FROM CURRENCY WHERE CYID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from CURRENCY where CURRENCY='" + Text2.Value + "'"))
                {

                    hint.Value = "该属性已经存在了！";

                }
                else
                {
                    basec.getcoms("insert into CURRENCY(CYID,CURRENCY,"
              + "Date,MakerID,Year,Month) values('" + Text1.Value
              + "','" + Text2.Value + "','" + varDate
              + "','" + varMakerID + "','" + year + "','" + month + "')");


                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from CURRENCY where CURRENCY='" + Text2.Value + "'"))
                {
                    hint.Value = "该属性已经存在了！";
                }
                else
                {

                    basec.getcoms("UPDATE CURRENCY SET CURRENCY='" + Text2.Value + "',MAKERID='" + varMakerID +
                        "',DATE='" + varDate + "' WHERE CYID='" + Text1.Value + "'");

                }

            }
            else
            {
                basec.getcoms("UPDATE CURRENCY SET CURRENCY='" + Text2.Value + "',MAKERID='" + varMakerID +
                     "',DATE='" + varDate + "' WHERE CYID='" + Text1.Value + "'");


            }


        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/CURRENCY.aspx" + n2);
        }
    }
}
