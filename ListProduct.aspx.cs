using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class ListProduct : System.Web.UI.Page
{
    Service service = new Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProductModel dt = new ProductModel();
            ListView.DataSource = service.getListProduct();
            ListView.DataBind();
        }
    }

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        //ProductModel dt = new ProductModel();
        GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gridViewRow.RowIndex;
        String a = ListView.Rows[index].Cells[0].Text;

        localhost.Product product = service.getListProductToEdit(a);
       
            Label1.Text = product.id;
            Label2.Text = product.name;
            Image1.ImageUrl = "~/imGProduct/" + product.IMG;
            Label4.Text = product.price.ToString();
            Label13.Text = product.pages.ToString();
            Label5.Text = product.weight.ToString();
            Label6.Text = product.content;
            Label7.Text = product.status;
            Label8.Text = product.year_of_creation;
            Label9.Text = product.producer;
            Label10.Text = product.TypeName;
            Label11.Text = product.AuthorName;
            Label12.Text = product.repository.ToString();
            HyperLink1.NavigateUrl = "~/EditProduct.aspx?id=" + product.id;

        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //ProductModel productModel = new ProductModel();
        string key_word = txtSearch.Text;
        if (TypeSearch.SelectedValue == "1")
        {
            ListView.DataSource = service.SearchProduct(key_word, 1);
            ListView.DataBind();
        }
        else if (TypeSearch.SelectedValue == "2")
        {
            ListView.DataSource = service.SearchProduct(key_word, 2);
            ListView.DataBind();
        }
        else
        {
            ListView.DataSource = service.SearchProduct(key_word, 3);
            ListView.DataBind();
        }
    }



    protected void ListView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //ProductModel dt = new ProductModel();
        ListView.PageIndex = e.NewPageIndex;
        ListView.DataSource = service.getListProduct();
        ListView.DataBind();
    }
}