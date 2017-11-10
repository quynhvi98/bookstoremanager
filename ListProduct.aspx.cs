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

        DataTable datable = service.getListProductToEdit(a);
        foreach (DataRow item in datable.Rows)
        {
            Label1.Text = item[0].ToString();
            Label2.Text = item[1].ToString();
            Image1.ImageUrl = "~/imGProduct/" + item[2].ToString();
            Label4.Text = item[3].ToString();
            Label13.Text = item[4].ToString();
            Label5.Text = item[12].ToString();
            Label6.Text = item[5].ToString();
            Label7.Text = item[6].ToString();
            Label8.Text = item[7].ToString();
            Label9.Text = item[8].ToString();
            Label10.Text = item[9].ToString();
            Label11.Text = item[10].ToString();
            Label12.Text = item[11].ToString();
            HyperLink1.NavigateUrl = "~/EditProduct.aspx?id=" + item[0].ToString();

        }
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