using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public Product()
    {
    }
    public String id { get; set; }
    public String name { get; set; }
    public String IMG { get; set; }
    public Decimal price { get; set; }
    public int pages { get; set; }
    public int repository { get; set; }
    public Double weight { get; set; }
    public String content { get; set; }
    public String status { get; set; }
    public DateTime date { get; set; }
    public String year_of_creation { get; set; }
    public int idProducer { get; set; }
    public int type { get; set; }
    public int author { get; set; }
    public Decimal price_pages { get; set; }
}