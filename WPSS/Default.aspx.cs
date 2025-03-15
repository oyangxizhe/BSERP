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
using System.Web.SessionState;
namespace WPSS
{
    public partial class _Default : System.Web.UI.Page
    {
        #region nature
        private static string _USID;
        public static string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }
        private static string _UNAME;
        public static string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private static string _EMID;
        public static string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static string _DEPART;
        public static string DEPART
        {
            set { _DEPART = value; }
            get { return _DEPART; }

        }
        private string _GEID;
        public string GEID
        {
            set { _GEID = value; }
            get { return _GEID; }

        }
        #endregion
        public byte[] PWD;

        basec bc = new basec();
        string pwd;
        CUSER cuser = new CUSER();
        protected void Page_Load(object sender, EventArgs e)
        {

            //Text1.Value = "jxcadmin";
            //Text2.Value = "admin555";
             
        }

        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            
            
            try
            {
                UNAME = Text1.Value;
                pwd = Text2.Value;
                hint.Value = "";
                if (juage())
                {
                }
                else
                {

                    login();

                }
            }
            catch (Exception)
            {


            }

        }
        #region login
        private void login()
        {
            byte[] B = bc.GetMD5(pwd);
            if (cuser.JUAGE_LOGIN_IF_SUCCESS(UNAME   ,pwd  ))
            {

               
                DEPART = cuser.DEPART;
                ENAME = cuser.ENAME;
                PWD = B;
                EMID = cuser.EMID;
                USID = cuser.USID;
                Session["UName"] = UNAME;
                Session["Pwd"] = PWD;
                Session["USID"] = USID;
                GEID = cuser.GETID();
                cuser.USID = USID;
                cuser.GEID = GEID;
                cuser.SQlcommandE(cuser.sqlo);
                Session["AUID"] = GEID;
                Response.Redirect("main.aspx?USID=" + USID + "");


            }
            else
            {

                hint.Value  = "密码不正确，请重新输入！";
                Text2.Focus();
            }

        }
        #endregion
        #region juage()
        private bool juage()
        {
            
            bool b = false;
            if (UNAME == "")
            {
                b = true;
                hint.Value = "用户名不能为空！";
                Text1.Focus();

            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + UNAME + "'"))
            {
                b = true;
                hint.Value  = "用户名不存在！";
                Text1.Focus();
            }
            else if (pwd == "")
            {
                b = true;
                hint.Value = "密码不能为空！";
                Text2.Focus();

            }
            else if (JUAGE_AUTHORIZATION_USER_IF_DROP())
            {

                b = true;
                hint.Value = "数据库表损坏！";
            }
            /*else if (JUAGE_IF_MAX_USER_COUNT ())
            {

                b = true;
                hint.Value = "已经达到最大用户数！";

            }*/
            return b;

        }
        #endregion
        private bool JUAGE_AUTHORIZATION_USER_IF_DROP()
        {
            bool b = true;
            try
            {
                //DataTable dt = bc.getdt("SELECT * FROM AUTHORIZATION_USER");
                string v1 = "Xizhedream555";
                byte[] AKEY;
                AKEY = bc.GetMD5(v1);
                string sql="SELECT * FROM AUTHORIZATION_USER WHERE AKEY=@AKEY";
                SqlConnection sqlcon = bc.getcon();
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                sqlcom.Parameters.Add("@AKEY",SqlDbType.Binary,50 ).Value  = AKEY;
                sqlcon.Open();

                sqlcom.ExecuteNonQuery();
                if (sqlcom.ExecuteScalar().ToString() != "")
                {
                   
                }
             
                sqlcon.Close();
                b = false;
                
             
            }
            catch (Exception)
            {


            }
            return b;
        }

        private bool JUAGE_IF_MAX_USER_COUNT()
        {
            bool b = true;
            try
            {
                string v1 = bc.getOnlyString("SELECT COUNT(*) FROM AUTHORIZATION_USER WHERE STATUS='Y'");
                int count = 0;
                if (v1 != "")
                {
                    count = Convert.ToInt32(v1);

                }
                if (count<3)
                {
                    b = false;

                }
            }
            catch (Exception)
            {


            }
            return b;
        }
    }
}
