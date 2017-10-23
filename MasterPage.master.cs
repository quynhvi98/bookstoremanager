using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["account"] != null)
        {
            string user = Request.Cookies["account"].Values["user"];
            Label1.Text =  user;
        }
    }

    protected void sign_out_Click(object sender, EventArgs e)
    {
        Response.Cookies["account"].Expires = DateTime.Now.AddMilliseconds(-1);
        Response.Redirect("Home.aspx");
    }
}
