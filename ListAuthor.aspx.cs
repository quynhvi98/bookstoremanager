using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class ListAuthor : System.Web.UI.Page
{

    Service service = new Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }
    private void loadData()
    {
        //DataProcess authorModel = new DataProcess();
        List<localhost.Author> list = new List<localhost.Author>();
        
        list = service.GetAuthorInformation().ToList();
        GridView1.DataSource = list;
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
        localhost.Author author = new localhost.Author();
        //AuthorModel authorModel = new AuthorModel();

        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        author.id_author = int.Parse(id);
        TextBox txtName = (TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0]);
        author.name_author = txtName.Text;
        TextBox txtDes = (TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0]);
        author.description = txtDes.Text;
        if (service.UpdateAuthor(author))
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
        List<localhost.Author> list = new List<localhost.Author>();
        string key_word = txtSearch.Text;
        GridView1.DataSource = list;
        GridView1.DataBind();
        
        if (TypeSearch.SelectedValue == "1")
        {
            GridView1.DataSource = service.SearchAuthor(key_word, 1);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = service.SearchAuthor(key_word, 2);
            GridView1.DataBind();
        }
    }
}