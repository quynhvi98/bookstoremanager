using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class login : System.Web.UI.Page
{
    Service service = new Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["account"] != null)
        {
            Response.Redirect("Home.aspx");
        }
        if (Request.QueryString["user"] != null)
        {
            var UserAccount = Request.QueryString["user"];
            var PasswordAccount = Request.QueryString["pass"];
            Response.Write(UserAccount);
            if (Request.Cookies["account"] == null)
            {
                //DataProcess dataProcess = new DataProcess();
                if (service.LoginWithAccAndPass_DataProcess(UserAccount, PasswordAccount))
                {
                    Response.Write("đăng nhập Thành công");
                    int cooki = UserAccount.GetHashCode() + PasswordAccount.GetHashCode();
                    HttpCookie httpCookie = new HttpCookie("account");
                    httpCookie.Values.Add("user", UserAccount.ToString());
                    httpCookie.Values.Add("password", PasswordAccount.GetHashCode().ToString());
                    httpCookie.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(httpCookie);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    string error = "Sai tài khoản hoặc mật khẩu!";
                    Response.Redirect("testlogin.aspx?error="+error);
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
        else
        {
            Response.Redirect("testlogin.aspx");
        }
      


    }

    protected void loginAccount_Click(object sender, EventArgs e)
    {
        var UserAccount = userAccount.Text;
        var PasswordAccount = passwordAccount.Text;
        if (Request.Cookies["account"] == null)
        {
           // DataProcess dataProcess = new DataProcess();
            if (service.LoginWithAccAndPass_DataProcess(UserAccount, PasswordAccount))
            {
                Response.Write("đăng nhập Thành công");
                int cooki = UserAccount.GetHashCode() + PasswordAccount.GetHashCode();
                HttpCookie httpCookie = new HttpCookie("account");
                httpCookie.Values.Add("user", UserAccount.GetHashCode().ToString());
                httpCookie.Values.Add("password", PasswordAccount.GetHashCode().ToString());
                httpCookie.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Add(httpCookie);
            }
            else
            {
                Response.Write("đăng nhập Thất Bại");
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Cookies["account"].Expires = DateTime.Now.AddDays(-1);
    }
}

