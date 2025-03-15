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


namespace WPSS.UserManage
{
    public partial class EditPwd : System.Web.UI.Page
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
            dt = basec.getdts(M_str_sql + " where Uname='" +WPSS ._Default.UNAME   + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["UNAME"].ToString();
              
            }
         
    
        }
        protected void ClearText()
        {
            Text2.Value = "";

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
            string varDate = DateTime.Now.ToString();
            string varMakerID = WPSS._Default.EMID;
            Byte[] B = bc.GetMD5(Text2.Value);
            if (!juage1())
            {

            }
         
            else
            {
          

                string sql = @"UPDATE USERINFO SET 

PWD=@PWD,
MAKERID=@MAKERID,
DATE=@DATE WHERE UNAME='" + WPSS._Default.UNAME  + "'";
                SqlConnection con = bc.getcon();
                SqlCommand sqlcom = new SqlCommand(sql, con);
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
             if (Text2 .Value =="")
            {
                ju = false;
                hint.Value = "密码不能为空！";

            }
          else  if (bc.checkEmail(Text2.Value) == false)
            {
                ju = false;
                hint.Value = "密码只能输入数字字母的组合！";

            }
             else if (Text2.Value.Length < 8)
             {
                 ju = false;
                 hint.Value = "密码长度需大于8位！";

             }
             else if (!bc.checkNumber(Text2.Value))
             {
                 ju = false;
                 hint.Value = "密码需是数字与字母的组合！";

             }
             else if (!bc.checkLetter(Text2.Value))
             {
                 ju = false;
                 hint.Value = "密码需是数字与字母的组合！";

             }
            return ju;
        }
        #endregion
    
    }
}
