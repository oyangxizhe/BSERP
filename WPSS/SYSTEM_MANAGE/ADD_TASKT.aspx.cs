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

namespace WPSS.SYSTEM_MANAGE
{
    public partial class ADD_TASKT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        CADD_TASK cadd_task = new CADD_TASK();
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
                    dt = basec.getdts(cadd_task .sql +" where A.ATID='" + Text1.Value + "'");
                    if (dt.Rows.Count > 0)
                    {

                        Text2.Value = dt.Rows[0]["AT_NAME"].ToString();
                        Text3.Value = dt.Rows[0]["PARENT_NODEID"].ToString();
                        Text4.Value = dt.Rows[0]["PARENT_NAME"].ToString();
                        Text5.Value = dt.Rows[0]["URL"].ToString();
                    }
            }
         

            TreeNodeCollection trc = new TreeNodeCollection();
            dt = bc.getdt("SELECT * FROM RIGHTNAME");
            TreeView1.Nodes.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode();

                node.Text = dr["NODECONTEXT"].ToString()+dr["URL"].ToString ();

                TreeView1.Nodes.Add(node);

            }



            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx");
        }
        protected void ClearText()
        {
            Text2.Value = "";
            Text3.Value = "";
            Text4.Value = "";
            Text5.Value = "";
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

            v2 = bc.getOnlyString("SELECT AT_NAME FROM ADD_TASK WHERE  ATID='" + Text1.Value + "'");
            if (!bc.exists("SELECT ATID FROM ADD_TASK WHERE ATID='" + Text1.Value + "'"))
            {
                if (bc.exists("select * from ADD_TASK where AT_NAME='" + Text2.Value + "'"))
                {

                    hint.Value = "该作业名称已经存在了！";
                }
                else
                {
                    SQlcommandE(cadd_task.sqlt);
                }
            }
            else if (v2 != Text2.Value)
            {
                if (bc.exists("select * from ADD_TASK where AT_NAME='" + Text2.Value + "'"))
                {
                    hint.Value = "该作业名称已经存在了！";
                }
                else
                {
                    SQlcommandE(cadd_task.sqlth + " WHERE ATID='" + Text1.Value + "'");
                }
            }
            else
            {
                SQlcommandE(cadd_task.sqlth + " WHERE ATID='" + Text1.Value + "'");
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
            sqlcom.Parameters.Add("@ATID", SqlDbType.VarChar, 20).Value = Text1.Value;
            sqlcom.Parameters.Add("@AT_NAME", SqlDbType.VarChar, 20).Value = Text2.Value;
            sqlcom.Parameters.Add("@PARENT_NODEID", SqlDbType.VarChar, 20).Value = Text3.Value;
            sqlcom.Parameters.Add("@URL", SqlDbType.VarChar, 50).Value = Text5.Value;
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
            ClearText();
            Text1.Value = bc.numYM(10, 4, "0001", "SELECT * FROM ADD_TASK", "ATID", "AT");
            ADD_OR_UPDATE = "ADD";
        }
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            hint.Value = "";
            if (Text2.Value == "")
            {
                hint.Value = "作业名称不能为空！";
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
            Response.Redirect("../SYSTEM_MANAGE/ADD_TASK.aspx" + n2);
        }

    }
}
