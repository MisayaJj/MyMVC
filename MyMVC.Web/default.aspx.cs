using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMVC.Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("aa");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            Response.Clear();
            Response.Write("111");
        }
    }
}