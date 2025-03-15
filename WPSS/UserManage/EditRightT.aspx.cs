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
    public partial class EditRightT : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        basec bc = new basec();
        WPSS.Validate va = new Validate();
        public static string[] str1 = new string[] { "" };
        public static string[] strE = new string[] { "" };
        protected string M_str_sql = @"select A.USID AS USID,A.UNAME AS UNAME,B.ENAME AS ENAME,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=C.MAKERID) AS MAKER,
C.NodeContext AS NODECONTEXT,C.DATE AS DATE from  
USERINFO  A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID 
LEFT JOIN RIGHTLIST C ON A.USID=C.USID";
        int i, j;
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
            dt = basec.getdts(M_str_sql + " where A.UNAME='" + Text1.Value + "'");
            if (dt.Rows.Count > 0)
            {

                Text1.Value = dt.Rows[0]["UNAME"].ToString();
                Label1.Text = dt.Rows[0]["ENAME"].ToString();
                Assignment(dt);
            }

    
        }
        protected void ClearText()
        {
            Text1.Value = "";
            Label1.Text = "";
        }
        protected void Assignment(DataTable dt)
        {
           
            #region Assignment
            for (j = 0; j < dt.Rows.Count; j++)
            {
                bool b = false;
                string vargetNodeContext = dt.Rows[j][4].ToString();
                for (i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (vargetNodeContext == CheckBoxList1.Items[i].ToString())
                    {
                        CheckBoxList1.Items[i].Selected = true;
                        b = true;
                        break;
                    }

                }
                if (!b)
                {
                    for (i = 0; i < CheckBoxList2.Items.Count; i++)
                    {
                        if (vargetNodeContext == CheckBoxList2.Items[i].ToString())
                        {
                            CheckBoxList2.Items[i].Selected = true;
                            b = true;
                            break;
                        }

                    }
                }
                if (!b)
                {
                    for (i = 0; i < CheckBoxList3.Items.Count; i++)
                    {
                        if (vargetNodeContext == CheckBoxList3.Items[i].ToString())
                        {
                            CheckBoxList3.Items[i].Selected = true;
                            b = true;
                            break;
                        }

                    }
                }
                if (!b)
                {
                    for (i = 0; i < CheckBoxList4.Items.Count; i++)
                    {
                        if (vargetNodeContext == CheckBoxList4.Items[i].ToString())
                        {
                            CheckBoxList4.Items[i].Selected = true;
                            b = true;
                            break;
                        }

                    }
                }
                if (!b)
                {
                    for (i = 0; i < CheckBoxList5.Items.Count; i++)
                    {
                        if (vargetNodeContext == CheckBoxList5.Items[i].ToString())
                        {
                            CheckBoxList5.Items[i].Selected = true;
                            b = true;
                            break;
                        }

                    }
                }
            }
            #endregion
        }
        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Clear();
        }
        protected void Clear()
        {
           
            Text1.Value = "";
            Label1.Text = "";
            for (i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                CheckBoxList1.Items[i].Selected = false;

            }
            for (i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                CheckBoxList2.Items[i].Selected = false;
            }
            for (i = 0; i < CheckBoxList3.Items.Count; i++)
            {
                CheckBoxList3.Items[i].Selected = false;
            }
            for (i = 0; i < CheckBoxList4.Items.Count; i++)
            {
                CheckBoxList4.Items[i].Selected = false;
            }
            for (i = 0; i < CheckBoxList5.Items.Count; i++)
            {
                CheckBoxList5.Items[i].Selected = false;
            }
            SelectAll.Checked = false;
            Inverse.Checked = false;

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
            #region Save
            if (!juage1())
            {

            }
            else
            {
                string v1;
                string v2 = bc.getOnlyString("SELECT USID FROM USERINFO WHERE  UNAME='" + Text1.Value + "'");
                int varNodeID, varParentNodeID;
                string varNodeContext, varURL;
                basec.getcoms ("delete RightList where USID='" +v2 + "'");
                #region CheckBoxList1
                for (i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        v1 = CheckBoxList1.Items[i].ToString();
                        dt = basec.getdts("select * from RightName where NodeContext='" + v1 + "'");
                        if (dt.Rows.Count > 0)
                        {
                            varNodeID = Convert.ToInt32(dt.Rows[0]["NodeID"].ToString());
                            varNodeContext = dt.Rows[0]["NodeContext"].ToString();
                            varParentNodeID = Convert.ToInt32(dt.Rows[0]["ParentNodeID"].ToString());
                            varURL = dt.Rows[0]["URL"].ToString();

                            if (!bc.exists("select * from RightList where USID='" + v2 + "' and NodeID='" + varNodeID + "'"))
                            {
                                string tempSendStrSQL = "insert RightList (USID,NodeID,NodeContext,"
                                   + "ParentNodeID,URL,MakerID,Date) values ('" + v2 + "','" + varNodeID + "','" + v1 + 
                                   "','" + varParentNodeID + "','" + varURL + "','" + varMakerID +
                                   "','" + varDate + "' )";
                                basec.getcoms(tempSendStrSQL);
                            }
                        }
                    }
                }
                #endregion

                #region CheckBoxList2
                for (i = 0; i < CheckBoxList2.Items.Count; i++)
                {
                    if (CheckBoxList2.Items[i].Selected == true)
                    {
                        v1 = CheckBoxList2.Items[i].ToString();
                        dt = basec.getdts("select * from RightName where NodeContext='" + v1 + "'");
                        if (dt.Rows.Count > 0)
                        {
                            varNodeID = Convert.ToInt32(dt.Rows[0]["NodeID"].ToString());
                            varNodeContext = dt.Rows[0]["NodeContext"].ToString();
                            varParentNodeID = Convert.ToInt32(dt.Rows[0]["ParentNodeID"].ToString());
                            varURL = dt.Rows[0]["URL"].ToString();

                            if (!bc.exists("select * from RightList where USID='" + v2 + "' and NodeID='" + varNodeID + "'"))
                            {
                                string tempSendStrSQL = "insert RightList (USID,NodeID,NodeContext,"
                                   + "ParentNodeID,URL,MakerID,Date) values ('" + v2 + "','" + varNodeID + "','" + v1 +
                                   "','" + varParentNodeID + "','" + varURL + "','" + varMakerID +
                                   "','" + varDate + "' )";
                                basec.getcoms(tempSendStrSQL);
                            }
                        }
                    }
                }
                #endregion

                #region CheckBoxList3
                for (i = 0; i < CheckBoxList3.Items.Count; i++)
                {
                    if (CheckBoxList3.Items[i].Selected == true)
                    {
                        v1 = CheckBoxList3.Items[i].ToString();
                        dt = basec.getdts("select * from RightName where NodeContext='" + v1 + "'");
                        if (dt.Rows.Count > 0)
                        {
                            varNodeID = Convert.ToInt32(dt.Rows[0]["NodeID"].ToString());
                            varNodeContext = dt.Rows[0]["NodeContext"].ToString();
                            varParentNodeID = Convert.ToInt32(dt.Rows[0]["ParentNodeID"].ToString());
                            varURL = dt.Rows[0]["URL"].ToString();

                            if (!bc.exists("select * from RightList where USID='" + v2 + "' and NodeID='" + varNodeID + "'"))
                            {
                                string tempSendStrSQL = "insert RightList (USID,NodeID,NodeContext,"
                                   + "ParentNodeID,URL,MakerID,Date) values ('" + v2 + "','" + varNodeID + "','" + v1 +
                                   "','" + varParentNodeID + "','" + varURL + "','" + varMakerID +
                                   "','" + varDate + "' )";
                                basec.getcoms(tempSendStrSQL);
                            }
                        }
                    }
                }
                #endregion

                #region CheckBoxList4
                for (i = 0; i < CheckBoxList4.Items.Count; i++)
                {
                    if (CheckBoxList4.Items[i].Selected == true)
                    {
                        v1 = CheckBoxList4.Items[i].ToString();
                        dt = basec.getdts("select * from RightName where NodeContext='" + v1 + "'");
                        if (dt.Rows.Count > 0)
                        {
                            varNodeID = Convert.ToInt32(dt.Rows[0]["NodeID"].ToString());
                            varNodeContext = dt.Rows[0]["NodeContext"].ToString();
                            varParentNodeID = Convert.ToInt32(dt.Rows[0]["ParentNodeID"].ToString());
                            varURL = dt.Rows[0]["URL"].ToString();

                            if (!bc.exists("select * from RightList where USID='" + v2 + "' and NodeID='" + varNodeID + "'"))
                            {
                                string tempSendStrSQL = "insert RightList (USID,NodeID,NodeContext,"
                                   + "ParentNodeID,URL,MakerID,Date) values ('" + v2 + "','" + varNodeID + "','" + v1 +
                                   "','" + varParentNodeID + "','" + varURL + "','" + varMakerID +
                                   "','" + varDate + "' )";
                                basec.getcoms(tempSendStrSQL);
                            }
                        }
                    }
                }
                #endregion

                #region CheckBoxList5
                for (i = 0; i < CheckBoxList5.Items.Count; i++)
                {
                    if (CheckBoxList5.Items[i].Selected == true)
                    {
                        v1 = CheckBoxList5.Items[i].ToString();
                        dt = basec.getdts("select * from RightName where NodeContext='" + v1 + "'");
                        if (dt.Rows.Count > 0)
                        {
                            varNodeID = Convert.ToInt32(dt.Rows[0]["NodeID"].ToString());
                            varNodeContext = dt.Rows[0]["NodeContext"].ToString();
                            varParentNodeID = Convert.ToInt32(dt.Rows[0]["ParentNodeID"].ToString());
                            varURL = dt.Rows[0]["URL"].ToString();

                            if (!bc.exists("select * from RightList where USID='" + v2 + "' and NodeID='" + varNodeID + "'"))
                            {
                                string tempSendStrSQL = "insert RightList (USID,NodeID,NodeContext,"
                                   + "ParentNodeID,URL,MakerID,Date) values ('" + v2 + "','" + varNodeID + "','" + v1 +
                                   "','" + varParentNodeID + "','" + varURL + "','" + varMakerID +
                                   "','" + varDate + "' )";
                                basec.getcoms(tempSendStrSQL);
                            }
                        }
                    }
                }
                #endregion
             

            }
       
            #endregion

        }
        #endregion
        #region juage1()
        private bool juage1()
        {

            bool ju = true;
            if (Text1 .Value =="")
            {
                ju = false;
                hint.Value = "用户名不能为空！";

            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + Text1.Value + "'"))
            {
                ju = false;
                hint.Value = "用户名在系统中不存在！";

            }

            return ju;

        }
        #endregion
        protected void btnExit_Click(object sender, ImageClickEventArgs e)
        {
            string n1 = Request.Url.AbsoluteUri;
            string n2 = n1.Substring(n1.Length - 16, 16);
            Response.Redirect("../UserManage/EditRight.aspx"+n2);
        }

        protected void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            #region SelectAll
            int i;
            if (SelectAll.Checked)
            {
                for (i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    CheckBoxList1.Items[i].Selected = true;
                }
                for (i = 0; i < CheckBoxList2.Items.Count; i++)
                {
                    CheckBoxList2.Items[i].Selected = true;

                }
                for (i = 0; i < CheckBoxList3.Items.Count; i++)
                {
                    CheckBoxList3.Items[i].Selected = true;
                }
                for (i = 0; i < CheckBoxList4.Items.Count; i++)
                {
                    CheckBoxList4.Items[i].Selected = true;

                }
                for (i = 0; i < CheckBoxList5.Items.Count; i++)
                {
                    CheckBoxList5.Items[i].Selected = true;
                }

            }
            else
            {
                for (i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    CheckBoxList1.Items[i].Selected = false;

                }
                for (i = 0; i < CheckBoxList2.Items.Count; i++)
                {
                    CheckBoxList2.Items[i].Selected = false;

                }
                for (i = 0; i < CheckBoxList3.Items.Count; i++)
                {
                    CheckBoxList3.Items[i].Selected = false;

                }
                for (i = 0; i < CheckBoxList4.Items.Count; i++)
                {
                    CheckBoxList4.Items[i].Selected = false;


                }
                for (i = 0; i < CheckBoxList5.Items.Count; i++)
                {
                    CheckBoxList5.Items[i].Selected = false;


                }
            }
            #endregion
         
        }

        protected void Inverse_CheckedChanged(object sender, EventArgs e)
        {
            #region Inverse
            int i;
            for (i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    CheckBoxList1.Items[i].Selected = false;

                }
                else
                {
                    CheckBoxList1.Items[i].Selected = true;
                }

            }
            for (i = 0; i < CheckBoxList2.Items.Count; i++)
            {
                if (CheckBoxList2.Items[i].Selected == true)
                {
                    CheckBoxList2.Items[i].Selected = false;
                }
                else
                {
                    CheckBoxList2.Items[i].Selected = true;
                }

            }
            for (i = 0; i < CheckBoxList3.Items.Count; i++)
            {
                if (CheckBoxList3.Items[i].Selected == true)
                {
                    CheckBoxList3.Items[i].Selected = false;
                }
                else
                {
                    CheckBoxList3.Items[i].Selected = true;
                }

            }
            for (i = 0; i < CheckBoxList4.Items.Count; i++)
            {
                if (CheckBoxList4.Items[i].Selected == true)
                {
                    CheckBoxList4.Items[i].Selected = false;
                }
                else
                {
                    CheckBoxList4.Items[i].Selected = true;
                }

            }
            for (i = 0; i < CheckBoxList5.Items.Count; i++)
            {
                if (CheckBoxList5.Items[i].Selected == true)
                {
                    CheckBoxList5.Items[i].Selected = false;
                }
                else
                {
                    CheckBoxList5.Items[i].Selected = true;
                }

            }
            #endregion
        }
    }
}
