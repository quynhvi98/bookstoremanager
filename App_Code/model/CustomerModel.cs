using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerModel
/// </summary>
public class CustomerModel: DataProcess
{
    public CustomerModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool UpdateCustomer(Customer customer)
    {
        string sql = "UPDATE dbo.customer SET [_status]=@status where _id=@id";
        SqlCommand cmd = new SqlCommand(sql, GetConnection());
        if (cmd.Connection.State == ConnectionState.Closed)
            cmd.Connection.Open();
        cmd.Parameters.AddWithValue("@id", customer.id);
        cmd.Parameters.AddWithValue("@status", customer.status);
        int result = cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return result > 0;
    }
    public DataTable SearchCustomer(string query, int type)
    {
        string sql = "";
        if (type == 1)
        {
            sql = "SELECT dbo.customer._id, dbo.customer.[_email], dbo.customer.[_user], dbo.customer.[_name], SUM(dbo.order_product.[_total_bill]) AS _total_bill, dbo.customer_address.[_adddress_full], dbo.customer._status FROM dbo.customer JOIN dbo.customer_address ON dbo.customer.[_id]= dbo.customer_address.[_id_customer] LEFT JOIN dbo.order_product ON order_product.[_customer] = customer.[_id] WHERE customer._id = '" + query + "'" + "GROUP BY dbo.customer.[_id], customer.[_email],[_user], customer.[_name], dbo.customer_address.[_adddress_full], dbo.customer._status" ;
        }
        if (type == 2)
        {
            sql = "SELECT dbo.customer._id, dbo.customer.[_email], dbo.customer.[_user], dbo.customer.[_name], SUM(dbo.order_product.[_total_bill]) AS _total_bill, dbo.customer_address.[_adddress_full], dbo.customer._status FROM dbo.customer JOIN dbo.customer_address ON dbo.customer.[_id]= dbo.customer_address.[_id_customer] LEFT JOIN dbo.order_product ON order_product.[_customer] = customer.[_id]  WHERE customer.[_name] LIKE N'%" + query + "%'" + "GROUP BY dbo.customer.[_id], customer.[_email],[_user], customer.[_name], dbo.customer_address.[_adddress_full], dbo.customer._status";
        }
        if(type == 3)
        {
            sql = "SELECT dbo.customer._id, dbo.customer.[_email], dbo.customer.[_user], dbo.customer.[_name], SUM(dbo.order_product.[_total_bill]) AS _total_bill, dbo.customer_address.[_adddress_full], dbo.customer._status FROM dbo.customer JOIN dbo.customer_address ON dbo.customer.[_id]= dbo.customer_address.[_id_customer] LEFT JOIN dbo.order_product ON order_product.[_customer] = customer.[_id]  WHERE dbo.customer_address._adddress_full LIKE N'%" + query + "%'" + "GROUP BY dbo.customer.[_id], customer.[_email],[_user], customer.[_name], dbo.customer_address.[_adddress_full], dbo.customer._status";
        }
        if (type == 4)
        {
            sql = "SELECT dbo.customer._id, dbo.customer.[_email], dbo.customer.[_user], dbo.customer.[_name], SUM(dbo.order_product.[_total_bill]) AS _total_bill, dbo.customer_address.[_adddress_full], dbo.customer._status FROM dbo.customer JOIN dbo.customer_address ON dbo.customer.[_id]= dbo.customer_address.[_id_customer] LEFT JOIN dbo.order_product ON order_product.[_customer] = customer.[_id]   WHERE dbo.order_product.[_total_bill] > '" + query + "'" + "GROUP BY dbo.customer.[_id], customer.[_email],[_user], customer.[_name], dbo.customer_address.[_adddress_full], dbo.customer._status";
        }
        SqlDataAdapter da = new SqlDataAdapter(sql, GetConnection());
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}