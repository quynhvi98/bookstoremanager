using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using localhost;

public partial class AddProduct : System.Web.UI.Page
{
    Service service = new Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            Producer.Items.Clear();
            productType.Items.Clear();
            author.Items.Clear();
            List<String> list = new List<string>();
            //ProducerModel producerModel = new ProducerModel();
            list = service.GetlistProducer().ToList();
            foreach (var item in list)
            {
                Producer.Items.Add(item);
            }
            //ProductTypeModel productTypeModel = new ProductTypeModel();
            List<String> list1 = new List<string>();
            list1 = service.GetlistProductType().ToList();
            foreach (var item in list1)
            {
                productType.Items.Add(item);
            }
            //AuthorModel authorModel = new AuthorModel();
            List<String> list2 = new List<string>();
            list2 = service.GetlistAuthor().ToList();
            foreach (var item in list2)
            {
                author.Items.Add(item);
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime dateTime = DateTime.Now;
        long nameimg = dateTime.Ticks;
        ProducerModel producerModel = new ProducerModel();
        int ProducerId = producerModel.GetIdProducerByName(Producer.SelectedValue);
        ProductTypeModel productTypeModel = new ProductTypeModel();
        int aproductTypeModelID = productTypeModel.GetIdProductTypeByName(productType.SelectedValue);
        AuthorModel authorModel = new AuthorModel();
        int authorModelID = authorModel.GetIdProductTypeByName(author.SelectedValue);
        Product product = new Product();

        product.id = id.Text;
        product.name = name.Text;
        product.IMG = nameimg + FileIMG.FileName;
        product.price_pages = Decimal.Parse(price_pages.Text);
        product.price = Decimal.Parse(price.Text);
        product.pages = Int32.Parse(pages.Text);
        product.repository = Int32.Parse(repository.Text);
        product.weight = Double.Parse(weight.Text);
        product.content = content.Text;
        product.status = status.Text;
        product.year_of_creation = Namsanxuat.Text;
        product.idProducer = ProducerId;
        product.type = aproductTypeModelID;
        product.author = authorModelID;
        ProductModel productModel = new ProductModel();
        if (productModel.AddProduct(product))
        {
            String path = Server.MapPath("imGProduct");
            FileIMG.SaveAs(path + "\\" + product.IMG);
            List<String> list = new List<String>();
            CategoryModel categoryModel = new CategoryModel();
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (hot.Checked)
                        {
                            list.Add(categoryModel.GetIdProductTypeByName("Hot"));
                        }

                        break;
                    case 1:
                        if (@new.Checked)
                        {
                            list.Add(categoryModel.GetIdProductTypeByName("New"));
                        }
                        break;
                    case 2:
                        if (sale.Checked)
                        {
                            list.Add(categoryModel.GetIdProductTypeByName("Sale"));
                        }
                        break;
                }
            }
            CategoryProductModel categoryProductModel = new CategoryProductModel();
            categoryProductModel.AddListCategoryProduct(list, product.id);
            Response.Redirect("ListProduct.aspx");
        }

    }
}