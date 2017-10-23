using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProducer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddProducer_Click(object sender, EventArgs e)
    {
        ProducerModel producerModel = new ProducerModel();
        Producer producer = new Producer();

        producer.name = txtProducerName.Text;
        producer.description = txtProducerDescription.Text;
        if (!(producerModel.HasIdProducer(producer)))
        {
            if (producerModel.AddProducer(producer))
            {
                Response.Redirect("ListProducer.aspx");
            }
        }
        else
        {
            Response.Redirect("Error.aspx");
        }
    }
}