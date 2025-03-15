using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using XizheC;

namespace WPSS
{
    public partial class Main : System.Web.UI.Page
    {
        WPSS.Validate va = new Validate();
        string UNAME = WPSS._Default.UNAME;
        string ENAME = WPSS._Default.ENAME;
        string USID = WPSS._Default.USID;
        basec bc = new basec();
        public static string[] v1 = new string[] { "" };
        public static string[] v2 = new string[] { "" };
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (va.returnb() == true)
            {
                Response.Redirect("\\Default.aspx");
            }
            else if (Session["USID"].ToString ()!=Request .QueryString ["USID"])
            {
                Response.Redirect("\\Default.aspx");
            }
            else
            {
               
                v1[0] = Request.QueryString["USID"];
                L1.Text = bc.getOnlyString("SELECT B.ENAME FROM USERINFO A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID WHERE USID='" + v1[0] + "'");
                L2.Text = bc.getOnlyString("SELECT B.DEPART FROM USERINFO A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID WHERE USID='" + v1[0] + "'");
                L3.Text = DateTime.Now.ToShortDateString();
                //DataSet ds = bc.getds("select * from RightList where USID='" + v1[0] + "' order by NodeID ASC ", "RightList");
                //this.ViewState["ds"] = ds;
                TreeView1.Nodes.Clear();
                AddTree();
                TreeView1.ImageSet = TreeViewImageSet.Arrows;
                TreeView1.ExpandDepth = 0;
                TreeView1.NodeStyle.BackColor = Color.FromName("#EEF7DD");
            }
        }
        //递归添加树的节点
        public void AddTree()
        {
            //DataSet ds = (DataSet)this.ViewState["ds"];
            //DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点
            DataTable dt = bc.getdt("select distinct(parentnodeid) as parentnodeid from rightlist where parentnodeid<>0 and USID='" + v1[0] + "' ");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode PNode = new TreeNode();
                    PNode.SelectAction = TreeNodeSelectAction.Expand;
                    //添加根节点
                    PNode.Text = bc.getOnlyString("SELECT NODECONTEXT FROM RIGHTNAME WHERE NODEID='" + dr["parentnodeid"].ToString() + "'");
                    // Node.NavigateUrl = dr["URL"].ToString();
                    //Node.Target = "ContentP";
                    TreeView1.Nodes.Add(PNode);
                    PNode.Expanded = true;//展开根节点
                    DataTable dt1 = bc.getdt(@"SELECT * FROM RIGHTLIST WHERE PARENTNODEID='" + dr["parentnodeid"].ToString() + 
                        "' AND USID='" + v1[0] + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {

                            TreeNode Node = new TreeNode();
                            //?添加当前节点的子节点
                            Node.Text = dr1["NodeConText"].ToString();
                            Node.NavigateUrl = dr1["URL"].ToString() + "?USID=" + v1[0];
                            Node.Target = "ContentP";
                            PNode.ChildNodes.Add(Node);
                            //Node.Expanded = true;
                        }
                    }
                }
            }
   
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string varDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bc.getcom(@"UPDATE AUTHORIZATION_USER SET STATUS='N' ,LEAVE_DATE='" + varDate + "'WHERE AUID='" + Session["AUID"].ToString() + "'");

            Session["UName"] = null;
            Session["USID"] = null;
            Session["Pwd"] = null;
            ClearClientPageCache();
           Response.Redirect("~/Default.aspx"); 

        }
        public void ClearClientPageCache() 
        { 
        //清除浏览器缓存 
　　   Response.Buffer = true; 
       Response.ExpiresAbsolute = DateTime.Now.AddDays(-1); 
       Response.Cache.SetExpires(DateTime.Now.AddDays(-1)); 
       Response.Expires = 0; 
       Response.CacheControl = "no-cache"; 
       Response.Cache.SetNoStore(); 
} 

    }
}
