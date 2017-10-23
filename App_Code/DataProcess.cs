using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DataProcess
/// </summary>
public class DataProcess
{
    public DataProcess()
    {
       

    }
    public SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection("server=localhost; database=BookASMWAD;" + "uid=sa; pwd=123456");
        return conn;
    }


    //Order
    public DataTable GetListOrder()
    {
        string sql = "SELECT _id,[_total_bill],_content,[_status_paymen],[_status_delivery],[_status_bill],[_date] FROM dbo.order_product JOIN dbo.paymen ON paymen.[_payment_id] = order_product.[_payment_id]";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public bool DeleteOrder(string id)
    {
        string sql = "UPDATE dbo.order_product SET _status_bill = N'Đã hủy' WHERE [_id] = @id";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("@id", id);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;

    }

    public bool UpdateOrderProduct(string id,string payment_type,string status_payment,string status_delivery)
    {
        string sql = "UPDATE dbo.order_product SET _payment_id=@pi, _status_paymen=@sp,_status_delivery=@sd WHERE _id=@id";
            
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("@pi", payment_type);
        cmd.Parameters.AddWithValue("@sp", status_payment);
        cmd.Parameters.AddWithValue("@sd", status_delivery);
        cmd.Parameters.AddWithValue("@id", id);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }

    public DataTable OrderDetailsByID(string id)
    {
        string sql = "SELECT product.[_id],product.[_name],[_quantity],dbo.ref_product_order.[_price],([_quantity]*dbo.ref_product_order.[_price]) AS total FROM dbo.product JOIN dbo.ref_product_order ON ref_product_order.[_id_product] = product.[_id] WHERE [_id_order]='" + id+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public List<string> GetInfoCustomer_Order(string id)
    {
        string sql = "SELECT customer.[_name],[_adddress_full],[_date],[_content],[_total_bill] FROM dbo.customer JOIN dbo.customer_address ON customer_address.[_id_customer] = customer.[_id] JOIN dbo.order_product ON order_product.[_customer] = customer.[_id] JOIN dbo.paymen ON paymen.[_payment_id] = order_product.[_payment_id] WHERE order_product.[_id]='" + id+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        List<string> customer = new List<string>();
        foreach (DataRow item in dt.Rows)
        {
            for (int i = 0; i < 5; i++)
                customer.Add(item[i].ToString());
        }
        return customer;
    }

    public DataTable GetSortData(string sort_type)
    {
        string sql = "SELECT _id,[_total_bill],_content,[_status_paymen],[_status_delivery],[_status_bill],[_date] FROM dbo.order_product JOIN dbo.paymen ON paymen.[_payment_id] = order_product.[_payment_id] ORDER BY "+ sort_type + " ASC";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable SearchOrder(string query,int type)
    {
        string sql = "";
        if (type == 1)
        {
            sql = "SELECT _id,[_total_bill],_content,[_status_paymen],[_status_delivery],[_status_bill],[_date] FROM dbo.order_product JOIN dbo.paymen ON paymen.[_payment_id] = order_product.[_payment_id] WHERE _id = '" + query + "'";
        }
        if (type == 2)
        {
            sql = "SELECT dbo.order_product._id,[_total_bill],_content,[_status_paymen],[_status_delivery],[_status_bill],[_date] FROM dbo.order_product JOIN dbo.paymen ON paymen.[_payment_id] = order_product.[_payment_id] JOIN dbo.customer ON customer.[_id] = order_product.[_customer] WHERE [_name] LIKE N'%"+query+"%'";
        }
        
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public List<string> DataTableToList(DataTable dt)
    {
        List<string> list = new List<string>();
        foreach (DataRow item in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
                list.Add(item[i].ToString());
        }
        return list;
    }
    //customer
    public DataTable GetCustomerInformation()
    {
        string sql = "SELECT dbo.customer._id, dbo.customer.[_email], dbo.customer.[_user], dbo.customer.[_name], SUM(dbo.order_product.[_total_bill]) AS _total_bill, dbo.customer_address.[_adddress_full], dbo.customer._status FROM dbo.customer JOIN dbo.customer_address ON dbo.customer.[_id]= dbo.customer_address.[_id_customer] LEFT JOIN dbo.order_product ON order_product.[_customer] = customer.[_id] GROUP BY dbo.customer.[_id], dbo.customer.[_email],[_user], customer.[_name], dbo.customer_address.[_adddress_full], dbo.customer._status";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    //producer
    public DataTable GetProducerInformation()
    {
        string sql = "SELECT * FROM dbo.producer";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    //author
    public DataTable GetAuthorInformation()
    {
        string sql = "SELECT * FROM dbo.author";
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }


    //lethanh tạo get id dang nhap
    public bool LoginWithAccAndPass(String userAccount, String password)
    {
        String sql = "SELECT* FROM administrator WHERE _user = @userAccount AND _password = @password";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        cmd.Parameters.AddWithValue("@userAccount", userAccount);
        cmd.Parameters.AddWithValue("@password", password);
        SqlDataReader rd = cmd.ExecuteReader();
        if (rd.HasRows != true)
        {
            String sql1 = "SELECT * FROM administrator WHERE  _email=@userAccount AND _password=@password";
            SqlCommand md1 = new SqlCommand(sql1, GetConnection());
            if (md1.Connection.State == ConnectionState.Closed)
            {
                md1.Connection.Open();
            }
            md1.Parameters.AddWithValue("@userAccount", userAccount);
            md1.Parameters.AddWithValue("@password", password);
            SqlDataReader rd1 = md1.ExecuteReader();
            bool check = rd1.HasRows;
            md1.Clone();
            return check;
        }
        cmd.Clone();

        return true;
    }

   
}