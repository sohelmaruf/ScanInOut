using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SCANINOUTBL
{
    public class OrderDetailObj
    {
        public string SKU { get; set; }
        public string ItemName { get; set; }
        public decimal PricePerUnit { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityShipped { get; set; }
        public int BackOrdered { get; set; }
        public string Status { get; set; }
        public DateTime PODate { get; set; }
        public int PONumber { get; set; }
    }
    public class OrderDetail
    {
        static SqlConnection cn = Connection.GetConnection();
        public OrderDetail()
        {
            
        }
        public static List<OrderDetailObj> GetByOrderNumber(int OrderNumber,int PONumber,DateTime PODate)
        {
            List<OrderDetailObj> ordlist = new List<OrderDetailObj>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT od.*,i.ItemName FROM [Order Details] od LEFT JOIN Inventory i on od.SKU = i.LocalSKU Where od.OrderNumber = " + OrderNumber, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OrderDetailObj odo = new OrderDetailObj();
                    odo.BackOrdered = dr["Backordered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Backordered"]);
                    odo.PricePerUnit = dr["PricePerUnit"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["PricePerUnit"]);
                    odo.QuantityOrdered = dr["QuantityOrdered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QuantityOrdered"]);
                    odo.QuantityShipped = dr["QuantityShipped"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QuantityShipped"]);
                    odo.SKU = dr["SKU"] == DBNull.Value ? "" : dr["SKU"].ToString();
                    odo.Status = dr["Status"] == DBNull.Value ? "" : dr["Status"].ToString();
                    odo.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();
                    odo.PONumber = PONumber;
                    odo.PODate = PODate;
                    ordlist.Add(odo);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
                                
            }
            return ordlist;
        }
    }
}
