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


namespace WPSS.WareNature
{
    public partial class MATERIALS_TYPET : System.Web.UI.Page
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
        private int  _PURCHASE_PHASE;
        public int PURCHASE_PHASE
        {
            set { _PURCHASE_PHASE = value; }
            get { return _PURCHASE_PHASE; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                Bind();
            }
     
            if (va.returnb() == true)
            Response.Redirect("\\Default.aspx"); 
        }
        protected void Bind()
        {
           
                hint.Value = "";
                Text1.Value =IDO;
                dt = basec.getdts("select * from MATERIALS_TYPE where MAID='" + Text1.Value + "'");
                if (dt.Rows.Count > 0)
                {
                  
                    Text2.Value = dt.Rows[0]["MATERIALS_TYPE"].ToString();
                    Text3.Value = dt.Rows[0]["PURCHASE_PHASE"].ToString();
                }
                else
                {
                    Text3.Value = "7";
                }
        }

        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "7";
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
        protected void add()
        {
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM MATERIALS_TYPE", "MAID", "MA");
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
            
            string v2 = bc.getOnlyString("SELECT MATERIALS_TYPE FROM MATERIALS_TYPE WHERE  MAID='" + Text1.Value + "'");
            if (!bc.exists("SELECT MAID FROM MATERIALS_TYPE WHERE MAID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from MATERIALS_TYPE where MATERIALS_TYPE='" + Text2.Value + "'"))
                {

                    hint.Value = "该原物料类别已经存在了！";

                }
                else
                {
                    basec.getcoms("insert into MATERIALS_TYPE(MAID,MATERIALS_TYPE,"
              + "Date,MakerID,Year,Month,PURCHASE_PHASE) values('" + Text1.Value
              + "','" + Text2.Value + "','" + varDate
              + "','" + varMakerID + "','" + year + "','" + month + "','"+Text3.Value +"')");


                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from MATERIALS_TYPE where MATERIALS_TYPE='" + Text2.Value + "'"))
                {
                    hint.Value = "该原物料类别已经存在了！";
                }
                else
                {

                    basec.getcoms("UPDATE MATERIALS_TYPE SET MATERIALS_TYPE='" + Text2.Value + "',MAKERID='" + varMakerID +
                        "',DATE='" + varDate + "',PURCHASE_PHASE='"+Text3.Value +"' WHERE MAID='" + Text1.Value + "'");

                }

            }
            else
            {
                basec.getcoms("UPDATE MATERIALS_TYPE SET MATERIALS_TYPE='" + Text2.Value + "',MAKERID='" + varMakerID +
                     "',DATE='" + varDate + "',PURCHASE_PHASE='" + Text3.Value + "' WHERE MAID='" + Text1.Value + "'");


            }


        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../WareNature/MATERIALS_TYPE.aspx"+n2);
        }
    }
}
