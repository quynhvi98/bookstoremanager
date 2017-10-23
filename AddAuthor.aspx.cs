using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddAuthor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addAuthors_Click(object sender, EventArgs e)
    {
        AuthorModel authorModel = new AuthorModel();
        Author author = new Author();
        DateTime dateTime = DateTime.Now;
        long nameimg = dateTime.Ticks;

        author.name = txtAuthorName.Text;
        author.description = txtAuthorDescription.Text;
        author.img = nameimg + FileIMG.FileName;
        if (!(authorModel.HasIdAuthor(author)))
        {
            if (authorModel.AddAuthors(author))
            {
                String path = Server.MapPath("image");
                FileIMG.SaveAs(path + "\\" + author.img);
                Response.Redirect("ListAuthor.aspx");
            }
        }
        else
        {
            Response.Redirect("Error.aspx"); //Nếu có id rồi thì chưa biết làm gì nên in tạm ra cái error
        }
    }


}