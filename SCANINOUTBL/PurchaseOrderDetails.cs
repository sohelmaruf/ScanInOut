using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SCANINOUTBL
{
    public class PurchaseOrderDetailsObj
    {
        public int PONumber { get; set; }
        public int ItemNumber { get; set; }
        public int Ordered { get; set; }
        public int Received { get; set; }
        public decimal ExpectedCost { get; set; }
        public decimal ActualCost { get; set; }
        public int OrderNumber { get; set; }
        public string Notes { get; set; }
        public DateTime DateExpected { get; set; }
        public DateTime DateClosed { get; set; }
        public string Lot { get; set; }
        public string LocalSKU { get; set; }
        public string SuppliersSKU { get; set; }
        public int PiecesPerLot { get; set; }
        public int NumberOfLots { get; set; }
        public int QuantityRemaining { get; set; }
        public string ItemName { get; set; }

    }
    public class PurchaseOrderDetails
    {
        static SqlConnection cn = Connection.GetConnection();
        public static List<PurchaseOrderDetailsObj> GetByPONumber(int PONumber)
        {
            List<PurchaseOrderDetailsObj> purchaseorderdetailslist = new List<PurchaseOrderDetailsObj>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PurchaseOrderDetails WHERE PONumber =  " + PONumber.ToString(), cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PurchaseOrderDetailsObj purchaseorderdetails = new PurchaseOrderDetailsObj();
                purchaseorderdetails.PONumber = int.Parse(dr["PONumber"].ToString());
                purchaseorderdetails.ItemNumber = int.Parse(dr["ItemNumber"].ToString());
                purchaseorderdetails.Ordered = int.Parse(dr["Ordered"].ToString());
                purchaseorderdetails.ExpectedCost = decimal.Parse(dr["ExpectedCost"].ToString());
                purchaseorderdetails.OrderNumber = int.Parse(dr["OrderNumber"].ToString());
                purchaseorderdetails.Lot = dr["Lot"] == DBNull.Value ? "" : dr["Lot"].ToString();
                purchaseorderdetails.LocalSKU = dr["LocalSKU"] == DBNull.Value ? "" : dr["LocalSKU"].ToString();
                purchaseorderdetails.SuppliersSKU = dr["SuppliersSKU"] == DBNull.Value ? "" : dr["SuppliersSKU"].ToString();                
                purchaseorderdetailslist.Add(purchaseorderdetails);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            foreach (PurchaseOrderDetailsObj item in purchaseorderdetailslist)
            {
                item.QuantityRemaining = item.Ordered - POHistory.GetReceivedQuantity(item.PONumber, item.LocalSKU);
                item.ItemName = Inventory.GetItemName(item.LocalSKU);
            }
            return purchaseorderdetailslist;
        }
        public static void Insert(InventoryRecord inventoryrecord, int ItemNumber, DateTime DateExpected)
        {
            SqlConnection con = cn;
            SqlCommand cmd = new SqlCommand(" insert into PurchaseOrderDetails(PONumber,ItemNumber,Ordered,Received,ExpectedCost,OrderNumber,DateExpected,Lot,PiecesPerLot,NumberOfLots,LocalSKU,SuppliersSKU) values (( select MAX(PONumber) from PurchaseOrders),@ItemNumber,@Ordered,0,@ExpectedCost,@OrderNumber,@DateExpected,'pieces',1,@NumberOfLots,@LocalSKU,@SuppliersSKU)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ItemNumber", ItemNumber);
            cmd.Parameters.AddWithValue("@Ordered", inventoryrecord.QtyToOrder);
            cmd.Parameters.AddWithValue("@ExpectedCost", inventoryrecord.ExtendedCost);
            cmd.Parameters.AddWithValue("@OrderNumber", inventoryrecord.OrderNumber);
            cmd.Parameters.AddWithValue("@DateExpected", DateExpected);
            cmd.Parameters.AddWithValue("@NumberOfLots", inventoryrecord.QtyToOrder);
            cmd.Parameters.AddWithValue("@LocalSKU", inventoryrecord.SKU);
            cmd.Parameters.AddWithValue("@SuppliersSKU", inventoryrecord.SupplierSKU);
            cmd.ExecuteNonQuery();
        }

    }
}
