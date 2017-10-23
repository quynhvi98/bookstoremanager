using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListProducer : System.Web.UI.Page
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
        DataProcess dataProducer = new DataProcess();
        GridView1.DataSource = dataProducer.GetProducerInformation();
        GridView1.DataBind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Producer producer = new Producer();
        ProducerModel producerModel = new ProducerModel();

        string id = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        producer.id = id;
        TextBox txtName = (TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0]);
        producer.name = txtName.Text;
        TextBox txtDes = (TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0]);
        producer.description = txtDes.Text;

        if (producerModel.UpdateProducer(producer))
        {
            GridView1.EditIndex = -1;
            loadData();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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

    protected void btnNSX_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProducer.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ProducerModel producerModel = new ProducerModel();
        string key_word = txtSearch.Text;
        if (TypeSearch.SelectedValue == "1")
        {
            GridView1.DataSource = producerModel.SearchProducer(key_word, 1);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = producerModel.SearchProducer(key_word, 2);
            GridView1.DataBind();
        }
    }

    protected void TypeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}