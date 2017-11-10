using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class EditProduct : System.Web.UI.Page
{
    Service service = new Service();
    private static String imgcu;
    private String idGoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && !IsPostBack)
        {
            getdata();
            idGoc = Request.QueryString["id"];
        }
        else
        {
            // Response.Redirect("ListProduct.aspx");
        }
    }
    private void getdata()
    {
        @Producer.Items.Clear();
        ProductType.Items.Clear();
        author.Items.Clear();
        List<String> list = new List<string>();
        //ProducerModel producerModel = new ProducerModel();
        list = service.GetlistProducer().ToList();
        foreach (var item in list)
        {
            @Producer.Items.Add(item);
        }
        //ProductTypeModel productTypeModel = new ProductTypeModel();
        List<String> list1 = new List<string>();
        list1 = service.GetlistProductType().ToList();
        foreach (var item in list1)
        {
            ProductType.Items.Add(item);
        }

        //AuthorModel authorModel = new AuthorModel();
        List<String> list2 = new List<string>();
        list2 = service.GetlistAuthor().ToList();
        foreach (var item in list2)
        {
            author.Items.Add(item);
        }


        String id = Request.QueryString["id"];
        IDProduct.Text = id;
        //ProductModel productModel = new ProductModel();
        DataTable datable = service.getListProductToEdit(id);
        foreach (DataRow item in datable.Rows)
        {
            name.Text = item[1].ToString();
            Image1.ImageUrl = "imGProduct/" + item[2].ToString();
            imgcu = item[2].ToString();
            price.Text = item[3].ToString();
            Pages.Text = item[4].ToString();
            repository.Text= item[12].ToString();
            weight.Text = item[5].ToString();
            conten.Text = item[6].ToString();
            stt.Text = item[7].ToString();
            @Producer.SelectedValue = item[9].ToString();
            ProductType.SelectedValue = item[10].ToString();
            author.SelectedValue = item[11].ToString();
        }
        //CategoryProductModel categoryProductModel = new CategoryProductModel();
        List<String> listCategoryProductModel = service.GetListCategoryProductID(id).ToList();
        for (int i = 0; i < listCategoryProductModel.Count; i++)
        {
            switch (listCategoryProductModel[i])
            {
                case "1":
                    Hot.Checked = true;
                    break;
                case "2":
                    New.Checked = true;
                    break;
                case "3":
                    Sale.Checked = true;
                    break;
            }
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListProduct.aspx");
    }

    protected void Sua_Click(object sender, EventArgs e)
    {
       localhost.Product product = new localhost.Product();
        product.id = IDProduct.Text;
        product.name = name.Text;
        product.price = Decimal.Parse(price.Text);
        
        //if (FileUpload1.HasFile)
        //{
        //    DateTime dtt = DateTime.Now;
        //    product.IMG = dtt.Ticks + FileUpload1.FileName;
        //}
        
        product.IMG = imgcu + FileUpload1.FileName;
        product.pages = Int32.Parse(Pages.Text);
        product.repository = Int32.Parse(repository.Text);
        product.weight = double.Parse(weight.Text);
        product.content = conten.Text;
        product.status = stt.Text;
        //ProducerModel producerModel = new ProducerModel();
        product.idProducer = service.GetIdProducerByName(@Producer.SelectedValue);
       // ProductTypeModel productTypeModel = new ProductTypeModel();
        product.type = service.GetIdProductTypeByName(ProductType.SelectedValue);
        //AuthorModel authorModel = new AuthorModel();
        product.author = service.GetIdProductTypeByName(author.SelectedValue);
       // ProductModel productModel = new ProductModel();
        if (service.updateProduct(product, idGoc))
        {
            if (FileUpload1.HasFile)
            {
                String path = Server.MapPath("imGProduct");
                FileUpload1.SaveAs(path + "\\" + product.IMG);
            }

            List<String> list = new List<String>();
           // CategoryModel categoryModel = new CategoryModel();
           CategoryProductModel categoryProductModel = new CategoryProductModel();
            service.delCategoryProductID(product.id);
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (Hot.Checked)
                        {
                            list.Add(service.GetIdProductTypeByName_CateModel("Hot"));
                        }

                        break;
                    case 1:
                        if (New.Checked)
                        {
                            list.Add(service.GetIdProductTypeByName_CateModel("New"));
                        }
                        break;
                    case 2:
                        if (Sale.Checked)
                        {
                            list.Add(service.GetIdProductTypeByName_CateModel("Sale"));
                        }
                        break;
                }
            }

            categoryProductModel.AddListCategoryProduct(list, product.id);


        }


    }
    protected void stt_TextChanged(object sender, EventArgs e)
    {

    }

}