using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryModel
/// </summary>
public class CategoryModel : DataProcess
{
    public CategoryModel()
    {
    }
    public String GetIdProductTypeByName(String Name)
    {
        List<String> list = new List<string>();
        String sql = "SELECT * FROM category where _name=@name";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        cmd.Connection.Open();
        cmd.Parameters.AddWithValue("name", Name);
        SqlDataReader rd = cmd.ExecuteReader();
        String index = "";
        while (rd.Read())
        {
            index = rd.GetString(0);
        }
        cmd.Connection.Close();
        return index;
    }
}