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
    public partial class Date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Expires = 0;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            hint.Value = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            
        }
    }
}
