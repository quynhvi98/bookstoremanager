using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testlogin : System.Web.UI.Page
{
    string status = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["account"] != null)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            status = Request.QueryString["error"];
            Response.Write("<div style='Position:absolute;top:400px;left:707px;z-index:1000;color:red;'><span><b>" + status + "</b></span></div>");

        }
    }
}