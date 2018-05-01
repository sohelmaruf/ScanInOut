using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SCANINOUTBL
{
    public class OrderObj
    {
        public int OrderNumber { get; set; }
        public int SourceOrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int CartID { get; set; }
        public string CartName { get; set; }
        public decimal BalanceDue { get; set; }
        public string CustomerName { get; set; }
        public string  CustomerCompany { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerAddress2 { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string ShipName { get; set; }
        public string ShipCompany { get; set; }
        public string ShipAddress { get; set; }
        public string ShipAddress2 { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPhone { get; set; }
        public string Comment { get; set; }
    }
    public class Order
    {
        static SqlConnection cn = Connection.GetConnection();
        public Order()
        {
            
        }
        public static OrderObj GetByOrderNumber(int OrderNumber)
        {
            OrderObj ord = new OrderObj();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orders Where OrderNumber = " + OrderNumber, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ord.BalanceDue = dr["BalanceDue"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["BalanceDue"]);
                    ord.CartID = dr["CartID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CartID"]);
                    ord.Comment = dr["Comments"] == DBNull.Value ? "" : dr["Comments"].ToString();
                    ord.CustomerAddress = dr["Address"] == DBNull.Value ? "" : dr["Address"].ToString();
                    ord.CustomerAddress2 = dr["Address2"] == DBNull.Value ? "" : dr["Address2"].ToString();
                    ord.CustomerCity = dr["City"] == DBNull.Value ? "" : dr["City"].ToString();
                    ord.CustomerCompany = dr["Company"] == DBNull.Value ? "" : dr["Company"].ToString();
                    ord.CustomerCountry = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString();
                    ord.CustomerEmail = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                    ord.CustomerName = dr["Name"] == DBNull.Value ? "" : dr["Name"].ToString();
                    ord.CustomerPhone = dr["Phone"] == DBNull.Value ? "" : dr["Phone"].ToString();
                    ord.CustomerState = dr["State"] == DBNull.Value ? "" : dr["State"].ToString();
                    ord.CustomerZip = dr["Zip"] == DBNull.Value ? "" : dr["Zip"].ToString();
                    ord.OrderDate = dr["OrderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["OrderDate"]);
                    ord.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderNumber"]);
                    ord.ShipAddress = dr["ShipAddress"] == DBNull.Value ? "" : dr["ShipAddress"].ToString();
                    ord.ShipAddress2 = dr["ShipAddress2"] == DBNull.Value ? "" : dr["ShipAddress2"].ToString();
                    ord.ShipCity = dr["ShipCity"] == DBNull.Value ? "" : dr["ShipCity"].ToString();
                    ord.ShipCompany = dr["ShipCompany"] == DBNull.Value ? "" : dr["ShipCompany"].ToString();
                    ord.ShipCountry = dr["ShipCountry"] == DBNull.Value ? "" : dr["ShipCountry"].ToString();
                    ord.ShipName = dr["ShipName"] == DBNull.Value ? "" : dr["ShipName"].ToString();
                    ord.ShipPhone = dr["ShipPhone"] == DBNull.Value ? "" : dr["ShipPhone"].ToString();
                    ord.ShipState = dr["ShipState"] == DBNull.Value ? "" : dr["ShipState"].ToString();
                    ord.ShipZip = dr["ShipZip"] == DBNull.Value ? "" : dr["ShipZip"].ToString();
                    ord.SourceOrderNumber = dr["SourceOrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SourceOrderNumber"]);
                    
                }
                dr.Close();
                dr.Dispose();
                dr = null;
                SqlCommand cmd2 = new SqlCommand("SELECT CartName FROM ShoppingCarts WHERE CartID = " + ord.CartID, cn);
                object obj = cmd2.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    ord.CartName = obj.ToString();
                }

            }
            catch (Exception)
            {

            }
            return ord;
        }
    }
}
