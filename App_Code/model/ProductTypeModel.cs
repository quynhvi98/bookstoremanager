using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeModel
/// </summary>
public class ProductTypeModel : DataProcess
{
    public ProductTypeModel()
    {
    }
    public List<String> GetlistProductType()
    {
        List<String> list = new List<string>();
        String sql = "SELECT * FROM product_type";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Connection.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(rd.GetString(1));
        }
        cmd.Connection.Close();
        return list;
    }
    public int GetIdProductTypeByName(String Name)
    {
        List<String> list = new List<string>();
        String sql = "SELECT * FROM product_type where _name=@name";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Connection.Open();
        cmd.Parameters.AddWithValue("name", Name);
        SqlDataReader rd = cmd.ExecuteReader();
        int index = -1;
        while (rd.Read())
        {
            index = rd.GetInt32(0);
        }
        cmd.Connection.Close();
        return index;
    }
    public List<ProductType> GetlistIDProductType()
    {
        List<ProductType> list = new List<ProductType>();
        String sql = "SELECT _id,_name FROM product_type";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Connection.Open();
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            list.Add(new ProductType()
            {
              id = rd.GetInt32(0),
              name=rd.GetString(1)
            });
        }
        cmd.Connection.Close();
        return list;
    }
}