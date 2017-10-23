using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryProductModel
/// </summary>
public class CategoryProductModel : DataProcess
{
    public CategoryProductModel()
    {
    }
    public Boolean AddCategoryProduct(CategoryProduct categoryProduct)
    {
        String sql = "INSERT dbo.category_product( [_id_product], [_id_category] ) VALUES  ( @idproduct, @idcategory  ))";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Parameters.AddWithValue("idproduct", categoryProduct.idProduct);
        cmd.Parameters.AddWithValue("idcategory", categoryProduct.idCategory);
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        int reuslt = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return reuslt > 0;
    }
    public void AddListCategoryProduct(List<String> list,String productId)
    {
        for (int i = 0; i < list.Count; i++)
        {
            String sql = "INSERT dbo.category_product( [_id_product], [_id_category] ) VALUES  ( @idproduct, @idcategory)";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("idproduct", productId);
            cmd.Parameters.AddWithValue("idcategory", list[i]);
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            int reuslt = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }

    public List<String> GetListCategoryProductID(String productId)
    {
        List<String> list = new List<String>();
             String sql = "SELECT _id_category FROM BookASMWAD.dbo.category_product WHERE _id_product=@id";
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("id", productId);
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(rd.GetString(0));
            }
        return list;
    }
    public void delCategoryProductID(String productId)
    {
        List<int> list = new List<int>();
        String sql = "DELETE FROM BookASMWAD.dbo.category_product WHERE  _id_product=@idproduct";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Parameters.AddWithValue("idproduct", productId);
        cmd.Connection.Open();
        SqlDataReader rd = cmd.ExecuteReader();


    }
}