using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel :DataProcess
{
    public ProductModel()
    {
    }
    public Boolean AddProduct(Product product)
    {
        String sql = " INSERT dbo.product ( " +
            "[_id] ,[_name] , [_IMG] ,dbo.product.[_price_pages],[_price] ,[_pages],[_repository] ,[_weight] ,[_content] ,[_status] ,[_date] , [_year_of_creation] ,[_id_producer] ,[_type] ,[_author]) VALUES " +
            " (@id, @name, @IMG, @_price_pages, @price ,  @pages ,@repository, @weight ,@content , @status , GETDATE() , @yearOfCreation ,@_id_producer , @type,@author)";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Parameters.AddWithValue("id", product.id);
        cmd.Parameters.AddWithValue("name", product.name);
        cmd.Parameters.AddWithValue("IMG", product.IMG);
        cmd.Parameters.AddWithValue("@_price_pages", product.price_pages);
        cmd.Parameters.AddWithValue("price", product.price);
        cmd.Parameters.AddWithValue("pages", product.pages);
        cmd.Parameters.AddWithValue("repository", product.repository);
        cmd.Parameters.AddWithValue("weight", product.weight);
        cmd.Parameters.AddWithValue("content", product.content);
        cmd.Parameters.AddWithValue("status", product.status);
        cmd.Parameters.AddWithValue("yearOfCreation", product.year_of_creation);
        cmd.Parameters.AddWithValue("_id_producer", product.idProducer);
        cmd.Parameters.AddWithValue("type", product.type);
        cmd.Parameters.AddWithValue("author", product.author);
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }

        int reuslt = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return reuslt > 0;
    }
    public DataTable getListProduct()
    {
        string sql = "SELECT product._id,product._name,_price,_status,producer._name as 'NhaXuatBan',product_type._name as productType,_name_author,_repository" +
            " FROM BookASMWAD.dbo.product JOIN BookASMWAD.dbo.producer on product._id_producer = producer._id JOIN BookASMWAD.dbo.product_type on product._type = product_type._id JOIN BookASMWAD.dbo.author on product._author = author._id";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;  
    }
    public DataTable getListProductToEdit(String id)
    {
        string sql = "SELECT product._id,product._name,dbo.product.[_IMG],_price,_pages,_weight,_content,_status,_year_of_creation, producer._name as 'NhaXuatBan',product_type._name as productType,_name_author,_repository FROM BookASMWAD.dbo.product JOIN BookASMWAD.dbo.producer on product._id_producer = producer._id JOIN BookASMWAD.dbo.product_type on product._type = product_type._id JOIN BookASMWAD.dbo.author on product._author = author._id WHERE product._id='" + id+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public bool updateProduct(Product product,String IDCu)
    {
        String sql = "UPDATE BookASMWAD.dbo.product SET " +
            "_id=@id ," +
            "_name=@name," +
             "_IMG=@IMG," +
            "_price=@price," +
            "_pages=@page," +
            "_repository=@repository," +
            "_weight=@weight," +
            "_content=@content," +
            "_status=@status," +
            "_id_producer=@procucer" +
            ",_type=@type" +
            ",_author=@author " +
            "WHERE _id=@idCu";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.Parameters.AddWithValue("@id", product.id);
        cmd.Parameters.AddWithValue("@name", product.name);
        cmd.Parameters.AddWithValue("@IMG", product.IMG);
        cmd.Parameters.AddWithValue("@price", product.price);
        cmd.Parameters.AddWithValue("@page", product.pages);
        cmd.Parameters.AddWithValue("@repository", product.repository);
        cmd.Parameters.AddWithValue("@weight", product.weight);
        cmd.Parameters.AddWithValue("@content", product.content);
        cmd.Parameters.AddWithValue("@status", product.status);
        cmd.Parameters.AddWithValue("@procucer", product.idProducer);
        cmd.Parameters.AddWithValue("@type", product.type);
        cmd.Parameters.AddWithValue("@author", product.author);
        cmd.Parameters.AddWithValue("@idCu", product.id);
        int reuslt = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return reuslt > 0;
    }
    public DataTable getListTongDoanhThuBanTheoSanPham()
    {
        string sql = "SELECT SUM(dbo.ref_product_order.[_quantity] * dbo.ref_product_order.[_price]) AS 'tongtien',SUM(dbo.ref_product_order.[_quantity]) AS 'soluongban',dbo.product.[_name],[_id_product] FROM dbo.ref_product_order JOIN dbo.product ON product.[_id] = ref_product_order.[_id_product] GROUP BY [_id_product],dbo.product.[_name]";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getListTongDoanhThuBanTheoType()
    {
        string sql = "SELECT SUM(dbo.ref_product_order.[_price] * [_quantity]) AS 'tongdoanhthu',dbo.product_type.[_name] FROM dbo.ref_product_order JOIN dbo.product ON product.[_id] = ref_product_order.[_id_product] JOIN dbo.product_type ON product_type.[_id] = product.[_type] GROUP BY dbo.product.[_type],dbo.product_type.[_name]";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getListTongDoanhThuBanTheoThangNayVoiType()
    {
        string sql = "SELECT SUM(dbo.ref_product_order.[_price] * [_quantity]) AS 'tongdoanhthu',dbo.product_type.[_name], DATEPART(MM,GETDATE()) AS 'thang' FROM dbo.ref_product_order JOIN dbo.product ON product.[_id] = ref_product_order.[_id_product] JOIN dbo.product_type ON product_type.[_id] = product.[_type] JOIN dbo.order_product ON order_product.[_id] = ref_product_order.[_id_order] WHERE  DATEPART(MM,order_product.[_date]) = DATEPART(MM,getdate()) GROUP BY dbo.product.[_type],dbo.product_type.[_name]";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable getSoLuongCoTrongKhoHang()
    {
        string sql = "SELECT N'Tổng Số Lượng ' AS 'name' ,SUM(_repository) AS'tongsoluong'   FROM dbo.product ";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        ProductTypeModel productTypeModel = new ProductTypeModel();
        List<ProductType> list = productTypeModel.GetlistIDProductType();
        for (int i = 0; i < list.Count; i++)
        {
            sql = "SELECT N'"+ list[i].name+"' AS 'name' ,SUM(_repository) AS'tongsoluong'   FROM dbo.product WHERE [_type]="+list[i].id+" GROUP BY [_type]";
            da = new SqlDataAdapter(sql, GetConnection());
            da.Fill(dt);
        }
        return dt;
    }
    public DataTable SearchProduct(string query, int type)
    {
        string sql = "";
        if (type == 1)
        {
            sql = "SELECT product._id,product._name,_price,_status,producer._name as 'NhaXuatBan',product_type._name as productType,_name_author,_repository" +
            " FROM BookASMWAD.dbo.product JOIN BookASMWAD.dbo.producer on product._id_producer = producer._id JOIN BookASMWAD.dbo.product_type on product._type = product_type._id JOIN BookASMWAD.dbo.author on product._author = author._id WHERE dbo.product.[_id]='" + query + "'";
        }
        if (type == 2)
        {
            sql = "SELECT product._id,product._name,_price,_status,producer._name as 'NhaXuatBan',product_type._name as productType,_name_author,_repository" +
            " FROM BookASMWAD.dbo.product JOIN BookASMWAD.dbo.producer on product._id_producer = producer._id JOIN BookASMWAD.dbo.product_type on product._type = product_type._id JOIN BookASMWAD.dbo.author on product._author = author._id WHERE dbo.product.[_name] LIKE N'%" + query + "%'";
        }
        if (type == 3)
        {
            sql = "SELECT product._id,product._name,_price,_status,producer._name as 'NhaXuatBan',product_type._name as productType,_name_author,_repository" +
            " FROM BookASMWAD.dbo.product JOIN BookASMWAD.dbo.producer on product._id_producer = producer._id JOIN BookASMWAD.dbo.product_type on product._type = product_type._id JOIN BookASMWAD.dbo.author on product._author = author._id WHERE dbo.product.[_price] = '" + query + "'";
        }
        
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}