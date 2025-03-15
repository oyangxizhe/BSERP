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


namespace WPSS.STOCKMANAGE
{
    public partial class STORAGE_LOCATIONT : System.Web.UI.Page
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
            dt = basec.getdts("select * from STORAGE_LOCATION where SLID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["STORAGE_LOCATION"].ToString();

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
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM STORAGE_LOCATION", "SLID", "SL");
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

            string v2 = bc.getOnlyString("SELECT STORAGE_LOCATION FROM STORAGE_LOCATION WHERE  SLID='" + Text1.Value + "'");
            if (!bc.exists("SELECT SLID FROM STORAGE_LOCATION WHERE SLID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from STORAGE_LOCATION where STORAGE_LOCATION='" + Text2.Value + "'"))
                {

                    hint.Value = "该库位已经存在了！";

                }
                else
                {
                    basec.getcoms("insert into STORAGE_LOCATION(SLID,STORAGE_LOCATION,"
              + "Date,MakerID,Year,Month) values('" + Text1.Value
              + "','" + Text2.Value + "','" + varDate
              + "','" + varMakerID + "','" + year + "','" + month + "')");


                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from STORAGE_LOCATION where STORAGE_LOCATION='" + Text2.Value + "'"))
                {
                    hint.Value = "该库位已经存在了！";
                }
                else
                {

                    basec.getcoms("UPDATE STORAGE_LOCATION SET STORAGE_LOCATION='" + Text2.Value + "',MAKERID='" + varMakerID +
                        "',DATE='" + varDate + "' WHERE SLID='" + Text1.Value + "'");

                }

            }
            else
            {
                basec.getcoms("UPDATE STORAGE_LOCATION SET STORAGE_LOCATION='" + Text2.Value + "',MAKERID='" + varMakerID +
                     "',DATE='" + varDate + "' WHERE SLID='" + Text1.Value + "'");


            }


        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../STOCKMANAGE/STORAGE_LOCATION.aspx" + n2);
        }
    }
}
