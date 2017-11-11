using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class _Default : System.Web.UI.Page
{
    Service service = new Service();
    string name = null;
    string id = null;
    List<string> customer;


    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.Visible = false;
        //DataProcess dp = new DataProcess();
        if (!IsPostBack)
        {
            LoadData();
            GridView2.DataSource = service.OrderDetailsByID(id);
            GridView2.DataBind();
        }
    }

    protected void LoadData()
    {
        //DataProcess dp = new DataProcess();
        GridView1.DataSource = service.GetListOrder();
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //DataProcess dp = new DataProcess();

        GridView1.EditIndex = e.NewEditIndex;
        LoadData();
        string id = GridView1.DataKeys[e.NewEditIndex].Values[0].ToString();
        List<localhost.Order> edit_item = service.SearchOrder(id, 1).ToList();

        DropDownList TypePayment = (DropDownList)(GridView1.Rows[e.NewEditIndex].Cells[2].FindControl("DropDownList1") as DropDownList);
        if (edit_item[0].content.Equals("Tiền mặt"))
            TypePayment.SelectedValue = "1";
        else
            TypePayment.SelectedValue = "2";
        DropDownList StatusPayment = (DropDownList)(GridView1.Rows[e.NewEditIndex].Cells[3].FindControl("DropDownList2") as DropDownList);
        if (edit_item[0].status_payment.Equals("Đã thanh toán"))
            StatusPayment.SelectedValue = "1";
        else
            StatusPayment.SelectedValue = "2";
        DropDownList StatusDelivery = (DropDownList)(GridView1.Rows[e.NewEditIndex].FindControl("DropDownList3") as DropDownList);
        if (edit_item[0].status_delivery.Equals("Đã giao hàng"))
            StatusDelivery.SelectedValue = "1";
        else
            StatusDelivery.SelectedValue = "2";
       
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        DropDownList txtTypePayment = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1") as DropDownList);
        string type_payment = txtTypePayment.SelectedValue.ToString();
        DropDownList txtStatusPayment = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("DropDownList2") as DropDownList);
        string status_payment = txtStatusPayment.SelectedItem.ToString();
        DropDownList txtStatusDelivery = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("DropDownList3") as DropDownList);
        string status_delivery = txtStatusDelivery.SelectedItem.ToString();
        //DataProcess dt = new DataProcess();
        if (service.UpdateOrderProduct(id, type_payment, status_payment, status_delivery))
        {
            GridView1.EditIndex = -1;
            LoadData();
        }
    }




    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        //DataProcess dt = new DataProcess();
        if (service.DeleteOrder(id))
            LoadData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadData();
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void ck_all_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ck = (CheckBox)GridView1.HeaderRow.FindControl("ck_all");

        foreach (GridViewRow item in GridView1.Rows)
        {
            CheckBox temp = (CheckBox)item.FindControl("ck_check");
            temp.Checked = ck.Checked;

        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        bool flag = false;
        //DataProcess dt = new DataProcess();
        foreach (GridViewRow item in GridView1.Rows)
        {
            CheckBox temp = (CheckBox)item.FindControl("ck_check");
            if (temp.Checked)
            {
                int index = item.RowIndex;
                string id = GridView1.DataKeys[index].Value.ToString();
                if (service.DeleteOrder(id))
                    flag = true;
            }

        }
        if (flag)
            LoadData();
    }



    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {

        //DataProcess dp = new DataProcess();
        GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
        int index = gridViewRow.RowIndex;

        id = GridView1.DataKeys[index].Value.ToString();
        GridView2.Visible = true;
       

        GridView2.DataSource = service.OrderDetailsByID(id);
        GridView2.DataBind();

       
        customer = new List<string>(service.GetInfoCustomer_Order(id));

        Response.Write("<div style='position: absolute; left: 310px; top: 500px; '><b>Tên khách hàng: " + customer[0] + "</b><br><b>Địa chỉ: " + customer[1] + "</b><br><b>Ngày đặt hàng: " + customer[2] + "</b><br><b>Thanh toán: " + customer[3] + "</b><br><b>Tổng tiền: " + customer[4] + "</b></div>");
        //GridView1.Rows[e.RowIndex].Cells[3]

       // Response.Write("<div style='float:right;margin-top:50px;margin-right:100px; clear: both;'>Tổng tiền: " + customer[4] + "</div>");
    }



    protected void SortView_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //DataProcess dp = new DataProcess();
        switch (SortView.SelectedValue)
        {
            case "1":
                GridView1.DataSource = service.GetSortData("[_date]");
                GridView1.DataBind();
                break;
            case "2":
                GridView1.DataSource = service.GetSortData("[_total_bill]");
                GridView1.DataBind();
                break;
            case "3":
                GridView1.DataSource = service.GetSortData("[_status_paymen]");
                GridView1.DataBind();
                break;
            case "4":
                GridView1.DataSource = service.GetSortData("[_status_bill]");
                GridView1.DataBind();
                break;

            case "5":
                GridView1.DataSource = service.GetSortData("[_status_delivery]");
                GridView1.DataBind();
                break;
            default:
                GridView1.DataSource = service.GetListOrder();
                GridView1.DataBind();
                break;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //DataProcess dp = new DataProcess();
        string key_word = txtSearch.Text;
        if (TypeSearch.SelectedValue == "1")
        {
            GridView1.DataSource = service.SearchOrder(key_word, 1);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = service.SearchOrder(key_word, 2);
            GridView1.DataBind();
        }


    }
}