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
using System.Security.Cryptography;


namespace WPSS.UserManage
{
    public partial class UserInfoT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"select A.USID AS USID,A.UNAME AS UNAME,A.EMID AS EMID,B.ENAME AS ENAME,A.PWD AS PWD,
(SELECT ENAME FROM EMPLOYEEINFO  WHERE EMID=A.MAKERID) AS MAKER,A.DATE AS DATE from   USERINFO  A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID";
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
            if (str1[0] != "")
            {
                Text1.Value = str1[0];
                str1[0] = "";
            }
            else
            {

                Text1.Value = strE[0];
                strE[0] = "";
           

            }
            dt = basec.getdts(M_str_sql + " where USID='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text2.Value = dt.Rows[0]["UNAME"].ToString();
                Text3.Value = dt.Rows[0]["EMID"].ToString();
                Label1.Text = dt.Rows[0]["ENAME"].ToString();
            }
    
        }
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Label1.Text = "";
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            btnSave.Enabled = true;
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM USERINFO", "USID", "US");

        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
           
            try
            {

                save();
               
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
            string v2 = bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE  USID='" + Text1.Value + "'");
            Byte[] B = bc.GetMD5(Text4.Value);
            if (!juage1())
            {

            }
            else if (!bc.exists("SELECT USID FROM USERINFO WHERE USID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from USERINFO where Uname='" + Text2.Value + "'"))
                {

                    hint.Value = "该用户名已经存在了！";

                }
                else
                {

                  
                    //建立SQL Server链接
                    SqlConnection Con = bc.getcon();
                    String SqlCmd = "INSERT INTO USERINFO (USID,UNAME,EMID,PWD,"
+ "DATE,Year,Month,Day) valueS (@USID,@UName,@EMID,@PWD,@DATE,@YEAR,@MONTH,@DAY)";
                    SqlCommand CmdObj = new SqlCommand(SqlCmd, Con);
                    CmdObj.Parameters.Add("@USID", SqlDbType.VarChar, 20).Value = Text1.Value;
                    CmdObj.Parameters.Add("@UName", SqlDbType.VarChar,20).Value = Text2.Value;
                    CmdObj.Parameters.Add("@EMID", SqlDbType.VarChar,20).Value = Text3.Value;
                    CmdObj.Parameters.Add("@PWD", SqlDbType.Binary, 50).Value = B;
                    CmdObj.Parameters.Add("@MAKEID", SqlDbType.VarChar,20).Value = varMakerID;
                    CmdObj.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
                    CmdObj.Parameters.Add("@YEAR", SqlDbType.VarChar,20).Value = year;
                    CmdObj.Parameters.Add("@MONTH", SqlDbType.VarChar,20).Value = month;
                    CmdObj.Parameters.Add("@DAY", SqlDbType.VarChar,20).Value = day;
                    Con.Open();
                    CmdObj.ExecuteNonQuery();
                    Con.Close();

                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from USERINFO where Uname='" + Text2.Value + "'"))
                {

                    hint.Value = "该用户名已经存在了！";

                }
                else
                {
                    string sql=@"UPDATE USERINFO SET UNAME=@UNAME,
EMID=@EMID,
PWD=@PWD,
DATE=@DATE,
MAKERID=@MAKERID 
WHERE USID='"+Text1.Value +"'";
                    SqlConnection con = bc.getcon();
                    SqlCommand sqlcom = new SqlCommand(sql, con);
                    sqlcom.Parameters.Add("@UNAME", SqlDbType.VarChar, 20).Value = Text2.Value;
                    sqlcom.Parameters.Add("@EMID", SqlDbType.VarChar, 20).Value = Text3.Value;
                    sqlcom.Parameters.Add("@PWD", SqlDbType.Binary, 50).Value = B;
                    sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
                    sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
                    con.Open();
                    sqlcom.ExecuteNonQuery();
                    con.Close();

                }

            }
            else
            {
                string sql = @"UPDATE USERINFO SET UNAME=@UNAME,
EMID=@EMID,
PWD=@PWD,
DATE=@DATE,
MAKERID=@MAKERID 
WHERE USID='" + Text1.Value + "'";
                SqlConnection con = bc.getcon();
                SqlCommand sqlcom = new SqlCommand(sql, con);
                sqlcom.Parameters.Add("@UNAME", SqlDbType.VarChar, 20).Value = Text2.Value;
                sqlcom.Parameters.Add("@EMID", SqlDbType.VarChar, 20).Value = Text3.Value;
                sqlcom.Parameters.Add("@PWD", SqlDbType.Binary, 50).Value = B;
                sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
                sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
                con.Open();
                sqlcom.ExecuteNonQuery();
                con.Close();
              
            }


        }
        #endregion
        #region juage1()
        private bool juage1()
        {

            bool ju = true;
            if (!bc.exists("SELECT * FROM EMPLOYEEINFO WHERE EMID='"+Text3.Value +"'"))
            {
                ju = false;
                hint.Value = "员工工号在系统中不存在！";
         
            }
            else if (Text4 .Value =="")
            {
                ju = false;
                hint.Value = "密码不能为空！";

            }
            else if (bc.checkEmail(Text4.Value) == false)
            {
                ju = false;
                hint.Value = "密码只能输入数字字母的组合！";

            }
            else if (Text4.Value.Length < 8)
            {
                ju = false;
                hint.Value = "密码长度需大于8位！";

            }
            else if (!bc.checkNumber (Text4 .Value ))
            {
                ju = false;
                hint.Value = "密码需是数字与字母的组合！";

            }
            else if (!bc.checkLetter(Text4.Value))
            {
                ju = false;
                hint.Value = "密码需是数字与字母的组合！";

            }
            return ju;

        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../UserManage/USERInfo.aspx"+n2);
        }
    }
}
