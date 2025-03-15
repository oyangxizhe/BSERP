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
    public partial class EmployeeInfoT : System.Web.UI.Page
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
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

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

            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Value = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Value = "";
            }
            Text1.Value = IDO;
            dt = basec.getdts("select * from EmployeeInfo where EMID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["ENAME"].ToString();
                DropDownList1.Items[0].Text = dt.Rows[0]["DEPART"].ToString();
                DropDownList2.Items[0].Text = dt.Rows[0]["POSITION"].ToString();
                Text3.Value = dt.Rows[0]["PHONE"].ToString();
            }
        
        }
        protected void ClearText()
        {
            Text2.Value = "";
            DropDownList1.Items[0].Text = "";
            DropDownList2.Items[0].Text = "";
            DropDownList1.Text = "";
            DropDownList2.Text = "";
            Text3.Value = "";
        }
 

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(7, 3, "001", "SELECT * FROM EMPLOYEEINFO", "EMID", "");
            ADD_OR_UPDATE = "ADD";

        }
        private void add()
        {

            Bind();
            ClearText();
            Text1.Value = bc.numYM(7, 3, "001", "SELECT * FROM EMPLOYEEINFO", "EMID", "");
           
            ADD_OR_UPDATE = "ADD";


        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {
                if (!bc.checkphone(Text3.Value))
                {

                    hint.Value = "电话号码输入字符不正确！";

                }
                else
                {
                    save();
                    if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
                    {
                        add();
                    }
                    else if (IFExecution_SUCCESS == true)
                    {
                        Bind();
                    }
                }
            }
            catch (Exception)
            {
                hint.Value = "名字长度限定五个汉字";
            }
  
        }
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
           if (!bc.exists("SELECT EMID FROM EMPLOYEEINFO WHERE EMID='" + Text1.Value + "'"))
            {

                basec.getcoms(@"INSERT INTO EMPLOYEEINFO(EMID,ENAME,DEPART,POSITION,MAKERID,DATE,YEAR,
                                   MONTH,PHONE) VALUES ('" + Text1.Value + "','" + Text2.Value +
                 "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + varMakerID + "','" + varDate +
                 "','" + year + "','" + month + "','"+Text3 .Value +"')");
                IFExecution_SUCCESS = true;
                
            }
            else
           {
               basec.getcoms(@"UPDATE EMPLOYEEINFO SET ENAME='" + Text2.Value + "',DEPART='" + DropDownList1.Text +
                     "',POSITION='" + DropDownList2.Text + "',MAKERID='" + varMakerID +
                     "',DATE='" + varDate + "',PHONE='"+Text3.Value +"' WHERE EMID='" + Text1.Value + "'");
               IFExecution_SUCCESS = true;

            }
      

        }
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {   string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../BaseInfo/EmployeeInfo.aspx"+n2);
        }
    }
}
