using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SCANINOUTBL
{
    public class PurchaseOrdersObj
    {
        public int PONumber { get; set; }
        public DateTime PODate { get; set; }
        public int SupplierID { get; set; }
        public DateTime DateClosed { get; set; }
        public string Notes { get; set; }
        public string Comments { get; set; }
    }
    public class PurchaseOrders
    {
        static SqlConnection cn = Connection.GetConnection();
        public PurchaseOrders()
        {
            
        }
        public static PurchaseOrdersObj GetByID(int PONumber)
        {
            PurchaseOrdersObj purchaseorder = new PurchaseOrdersObj();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PurchaseOrders WHERE PONumber = " + PONumber.ToString(), cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                purchaseorder.PONumber = int.Parse(dr["PONumber"].ToString());
                purchaseorder.PODate = dr["PODate"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["PODate"].ToString());
                purchaseorder.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : int.Parse(dr["SupplierID"].ToString());
                purchaseorder.DateClosed = dr["DateClosed"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["DateClosed"].ToString());
                purchaseorder.Notes = dr["Notes"] == DBNull.Value ? "" : dr["Notes"].ToString();
                purchaseorder.Comments = dr["Comments"] == DBNull.Value ? "" : dr["Comments"].ToString();
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return purchaseorder;
        }
        public static List<PurchaseOrdersObj> GetAll()
        {
            List<PurchaseOrdersObj> purchaseorders = new List<PurchaseOrdersObj>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PurchaseOrders ", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PurchaseOrdersObj purchaseorder = new PurchaseOrdersObj();
                purchaseorder.PONumber = int.Parse(dr["PONumber"].ToString());
                purchaseorder.PODate = dr["PODate"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["PODate"].ToString());
                purchaseorder.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : int.Parse(dr["SupplierID"].ToString());
                purchaseorder.DateClosed = dr["DateClosed"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["DateClosed"].ToString());
                purchaseorder.Notes = dr["Notes"] == DBNull.Value ? "" : dr["Notes"].ToString();
                purchaseorder.Comments = dr["Comments"] == DBNull.Value ? "" : dr["Comments"].ToString();
                purchaseorders.Add(purchaseorder);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return purchaseorders;
        }
        public static List<PurchaseOrdersObj> GetAll(int SupplierID)
        {
            
            List<PurchaseOrdersObj> purchaseorders = new List<PurchaseOrdersObj>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PurchaseOrders WHERE SupplierID = " + SupplierID.ToString(), cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PurchaseOrdersObj purchaseorder = new PurchaseOrdersObj();
                purchaseorder.PONumber = int.Parse(dr["PONumber"].ToString());
                purchaseorder.PODate = dr["PODate"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["PODate"].ToString());
                purchaseorder.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : int.Parse(dr["SupplierID"].ToString());
                purchaseorder.DateClosed = dr["DateClosed"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["DateClosed"].ToString());
                purchaseorder.Notes = dr["Notes"] == DBNull.Value ? "" : dr["Notes"].ToString();
                purchaseorder.Comments = dr["Comments"] == DBNull.Value ? "" : dr["Comments"].ToString();
                purchaseorders.Add(purchaseorder);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return purchaseorders;
        }

        public static void Insert(SupplierObj supplier, string sendvia, DateTime Datedue, decimal totalPrice)
        {
            SqlConnection con = cn;
            SqlCommand cmd = new SqlCommand("insert into PurchaseOrders(PONumber,PODate,SupplierID,Comments,SentVia,Terms,DateDue,Subtotal,ExpectedTotal,Closed,Instructions,ShippingMethod,Address1,City,[State],Zipcode,[Name],Country) values (( select MAX(PONumber)+1 from PurchaseOrders),@PODate,@SupplierID,@Comments,@SentVia,@Terms,@DateDue,@Subtotal,@ExpectedTotal,0,@Instructions,@ShippingMethod,@Address1,@City,@State,@Zipcode,@Name,@Country)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@PODate", DateTime.Now);
            cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
            cmd.Parameters.AddWithValue("@Comments", supplier.Comments == null ? "" : supplier.Comments);
            cmd.Parameters.AddWithValue("@SentVia", sendvia);
            cmd.Parameters.AddWithValue("@Terms", supplier.Terms);
            cmd.Parameters.AddWithValue("@DateDue", Datedue);
            cmd.Parameters.AddWithValue("@Subtotal", totalPrice);
            cmd.Parameters.AddWithValue("@ExpectedTotal", totalPrice);
            cmd.Parameters.AddWithValue("@Instructions", supplier.Instructions == null ? "" : supplier.Instructions);
            cmd.Parameters.AddWithValue("@ShippingMethod", supplier.ShippingMethod == null ? "" : supplier.ShippingMethod);
            cmd.Parameters.AddWithValue("@Address1", supplier.Address1);
            cmd.Parameters.AddWithValue("@City", supplier.City);
            cmd.Parameters.AddWithValue("@State", supplier.State);
            cmd.Parameters.AddWithValue("@Zipcode", supplier.Zip);
            cmd.Parameters.AddWithValue("@Name", supplier.SupplierName);
            cmd.Parameters.AddWithValue("@Country", supplier.Country);
            cmd.ExecuteNonQuery();

        }
    }
}
