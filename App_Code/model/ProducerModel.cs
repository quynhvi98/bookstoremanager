using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProducerModel
/// </summary>
public class ProducerModel : DataProcess
{
    public ProducerModel()
    {

    }

    public List<String> GetlistProducer()
    {
        List<String> list = new List<string>();
        String sql = "SELECT * FROM producer";
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
    public int GetIdProducerByName(String Name)
    {
        String sql = "SELECT _id FROM producer where _name=@name";
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
    public bool AddProducer(Producer producer)
    {
        string sql = "INSERT INTO dbo.producer( _name, _description) VALUES ( @name, @description) ";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("name", producer.name);
        cmd.Parameters.AddWithValue("description", producer.description);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }
    public bool HasIdProducer(Producer producer)
    {
        String sql = "SELECT * FROM producer WHERE _id='" + producer.id + "'";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        //cmd.Parameters.AddWithValue("@id", producer.id);
        SqlDataReader rd = cmd.ExecuteReader();
        bool reuslt = rd.HasRows;
        cmd.Connection.Close();
        return reuslt;
    }
    public bool UpdateProducer(Producer producer)
    {
        string sql = "UPDATE dbo.producer SET [_name]=@name, [_description]=@description where _id=@id";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("id", producer.id);
        cmd.Parameters.AddWithValue("name", producer.name);
        cmd.Parameters.AddWithValue("description", producer.description);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }
    public DataTable SearchProducer(string query, int type)
    {
        string sql = "";
        if (type == 1)
        {
            sql = "SELECT _id, _name, _description from producer  WHERE _id = '" + query + "'";
        }
        if (type == 2)
        {
            sql = "SELECT _id, _name, _description from producer  WHERE _name LIKE N'%" + query + "%'";
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}