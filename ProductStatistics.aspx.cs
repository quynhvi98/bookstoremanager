using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class ProductStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["account"] == null)
        {
            Response.Redirect("testlogin.aspx");
        }
    }

    Service service = new Service();
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BoundField boundField = new BoundField();
        //ProductModel product1 = new ProductModel();
        GridView1.Columns.Clear();
        switch (DropDownList1.SelectedValue)
        {
            case "1":
                boundField.DataField = "_id_product";
                boundField.HeaderText = "Id Sản Phẩm";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "_name";
                boundField.HeaderText = "Tên Sản Phẩm";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "soluongban";
                boundField.HeaderText = "Số Lượng Bán được";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "tongtien";
                boundField.HeaderText = "Tổng số tiền bán được";
                GridView1.Columns.Add(boundField);

                GridView1.DataSource = service.getListTongDoanhThuBanTheoSanPham();
                GridView1.DataBind();
                break;
            case "2":
                boundField = new BoundField();
                boundField.DataField = "tongdoanhthu";
                boundField.HeaderText = "Tổng Doanh Thu";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "_name";
                boundField.HeaderText = "Loại Sách";
                GridView1.Columns.Add(boundField);
                GridView1.DataSource = service.getListTongDoanhThuBanTheoType();
                GridView1.DataBind();
                break;
            case "3":
                boundField = new BoundField();
                boundField.DataField = "tongdoanhthu";
                boundField.HeaderText = "Tổng Doanh Thu";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "_name";
                boundField.HeaderText = "Loại Sách";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "thang";
                boundField.HeaderText = "Tháng";
                GridView1.Columns.Add(boundField);
                GridView1.DataSource = service.getListTongDoanhThuBanTheoThangNayVoiType();
                GridView1.DataBind();
                break;
            case "4":
                boundField = new BoundField();
                boundField.DataField = "name";
                boundField.HeaderText = "Name";
                GridView1.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "tongsoluong";
                boundField.HeaderText = "Số Lượng Kho";
                GridView1.Columns.Add(boundField);
                GridView1.DataSource = service.getSoLuongCoTrongKhoHang();
                GridView1.DataBind();
                break;
        }
    }
}