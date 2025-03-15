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
    public partial class WDate : System.Web.UI.Page
    {
        WPSS.Validate va = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (va.returnb() == true)
                Response.Redirect("\\Default.aspx"); 
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            hint.Value = "";
            hint.Value = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
}
