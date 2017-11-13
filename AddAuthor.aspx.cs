using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using localhost;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddAuthor : System.Web.UI.Page
{
    Service service = new Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["account"] == null)
        {
            Response.Redirect("testlogin.aspx");
        }
    }

    protected void addAuthors_Click(object sender, EventArgs e)
    {
       
        localhost.Author author = new localhost.Author();
        DateTime dateTime = DateTime.Now;
        long nameimg = dateTime.Ticks;

        author.name_author = txtAuthorName.Text;
        author.description = txtAuthorDescription.Text;
        author.img_author = nameimg + FileIMG.FileName;
        if (!(service.HasIdAuthor(author)))
        {
            if (service.AddAuthors(author))
            {
                String path = Server.MapPath("image");
                FileIMG.SaveAs(path + "\\" + author.img_author);
                Response.Redirect("ListAuthor.aspx");
            }
        }
        else
        {
            Response.Redirect("Error.aspx"); //Nếu có id rồi thì chưa biết làm gì nên in tạm ra cái error
        }
    }


}