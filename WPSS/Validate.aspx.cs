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

namespace WPSS
{
    public partial class Validate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool returnb()
        {
            bool re = false;
            if (Session["UName"] == null || Session["UName"].ToString() == "" || (string.IsNullOrEmpty(Session["Pwd"].ToString()))
                || Session["USID"] == null || Session["USID"].ToString() == "")
                re = true;

            return re;

        }
    }
}
