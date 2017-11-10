using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AuthorModel
/// </summary>
public class AuthorModel : DataProcess
{
    public AuthorModel()
    {
    }

    public List<String> GetlistAuthor()
    {
        List<String> list = new List<string>();
        String sql = "SELECT * FROM author";
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
        String sql = "SELECT * FROM author where _name_author=@name";
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
    public bool AddAuthors(Author author)
    {
        string sql = " INSERT INTO dbo.author( _name_author, _description_author,_IMG) VALUES (@name, @description, @img ) ";

        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("name", author.name);
        cmd.Parameters.AddWithValue("description", author.description);
        cmd.Parameters.AddWithValue("img",author.img);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }
    public bool HasIdAuthor(Author author)
    {
        String sql = "SELECT * FROM author WHERE _id='" + author.id + "'";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        //cmd.Parameters.AddWithValue("id", author.id);
        SqlDataReader rd = cmd.ExecuteReader();
        bool reuslt = rd.HasRows;
        cmd.Connection.Close();
        return reuslt;

    }

    public bool UpdateAuthor(Author author)
    {
        string sql = "UPDATE dbo.author SET [_name_author]= @name, [_description_author]= @description where _id=@id";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("id", author.id);
        cmd.Parameters.AddWithValue("name", author.name);
        cmd.Parameters.AddWithValue("description", author.description);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }
    public DataTable SearchAuthor(string query, int type)
    {
        string sql = "";
        if (type == 1)
        {
            sql = "SELECT _id, _name_author, _description_author from author  WHERE _id = '" + query + "'";
        }
        if (type == 2)
        {
            sql = "SELECT _id, _name_author, _description_author from author  WHERE _name_author LIKE N'%" + query + "%'";
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}