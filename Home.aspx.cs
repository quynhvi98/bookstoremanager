using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["account"] == null)
        {
            Response.Redirect("testlogin.aspx");
        }
        else
        {
            //string user = Request.Cookies["account"].Values["user"].ToString();
            //Response.Write("<div>Tài khoản: "+user+"</div>");
        }
    }
}