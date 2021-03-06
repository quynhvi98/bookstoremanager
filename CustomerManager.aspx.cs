﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManager : System.Web.UI.Page
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
        DataProcess dataCustomer = new DataProcess();
        GridView1.DataSource = dataCustomer.GetCustomerInformation();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        loadData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        loadData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Customer customer = new Customer();
        CustomerModel customerModel = new CustomerModel();

        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        customer.id = id;
        TextBox txtStatus = (TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0]);
        customer.status = txtStatus.Text;

        if (customerModel.UpdateCustomer(customer))
        {
            GridView1.EditIndex = -1;
            loadData();
        }
    }


    protected void TypeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataProcess dp = new DataProcess();
        CustomerModel customerModel = new CustomerModel();
        string key_word = txtSearch.Text;
        if (TypeSearch.SelectedValue == "1")
        {
            GridView1.DataSource = customerModel.SearchCustomer(key_word, 1);
            GridView1.DataBind();
        }
        else if (TypeSearch.SelectedValue == "2")
        {
            GridView1.DataSource = customerModel.SearchCustomer(key_word, 2);
            GridView1.DataBind();
        }
        else if (TypeSearch.SelectedValue == "3")
        {
            GridView1.DataSource = customerModel.SearchCustomer(key_word, 3);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = customerModel.SearchCustomer(key_word, 4);
            GridView1.DataBind();
        }
    }
}