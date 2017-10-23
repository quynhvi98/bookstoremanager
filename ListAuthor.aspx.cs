using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListAuthor : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        DataProcess authorModel = new DataProcess();
        GridView1.DataSource = authorModel.GetAuthorInformation();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadData();
    }


    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAuthor.aspx");
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Author author = new Author();
        AuthorModel authorModel = new AuthorModel();

        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        author.id = id;
        TextBox txtName = (TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0]);
        author.name = txtName.Text;
        TextBox txtDes = (TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0]);
        author.description = txtDes.Text;
        if (authorModel.UpdateAuthor(author))
        {
            GridView1.EditIndex = -1;
            loadData();
        }
    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadData();
    }

    protected void TypeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AuthorModel authorModel = new AuthorModel();
        string key_word = txtSearch.Text;
        if (TypeSearch.SelectedValue == "1")
        {
            GridView1.DataSource = authorModel.SearchAuthor(key_word, 1);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = authorModel.SearchAuthor(key_word, 2);
            GridView1.DataBind();
        }
    }
}