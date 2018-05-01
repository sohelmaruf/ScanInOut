using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SCANINOUTBL
{
    public class POHistoryobj
    {
        public string Type { get; set; }
        public int PONumber { get; set; }
        public int ItemNumber { get; set; }                        
        public string EnteredBy { get; set; }        
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public string LocalSKU { get; set; }
        public string SuppliersSKU { get; set; }
        public string  ItemName { get; set; }
        
    }
    public class POHistory
    {
        static SqlConnection cn = Connection.GetConnection();
        public static List<POHistoryobj> GetReceivedItems(int PONumber)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Type,PONumber,ItemNumber,EnteredBy,Quantity,Cost,LocalSKU,SuppliersSKU FROM POHistory Where Type = 'R' AND PONumber =" + PONumber.ToString(), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                List<POHistoryobj> polist = new List<POHistoryobj>();
                while (dr.Read())
                {
                    POHistoryobj poh = new POHistoryobj();
                    poh.Type = dr["Type"] == DBNull.Value ? "" : Convert.ToString(dr["Type"]);
                    poh.PONumber = dr["PONumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PONumber"]);
                    poh.ItemNumber = dr["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemNumber"]);
                    poh.EnteredBy = dr["EnteredBy"] == DBNull.Value ? "" : Convert.ToString(dr["EnteredBy"]);
                    poh.Quantity = dr["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Quantity"]);
                    poh.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    poh.LocalSKU = dr["LocalSKU"] == DBNull.Value ? "" : Convert.ToString(dr["LocalSKU"]);
                    poh.SuppliersSKU = dr["SuppliersSKU"] == DBNull.Value ? "" : Convert.ToString(dr["SuppliersSKU"]);
                    polist.Add(poh);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
                foreach (POHistoryobj item in polist)
                {
                    item.ItemName = Inventory.GetItemName(item.LocalSKU);
                }
                return polist;
            }
            catch (Exception)
            {
                return new List<POHistoryobj>();               
            }
        }
        public static int GetReceivedQuantity(int PONumber, string LocalSKU)
        {            
            SqlCommand cmd = new SqlCommand("SELECT IsNull(SUM(Quantity),0) FROM POHistory WHERE PONumber =  " + PONumber.ToString() + " AND LocalSKU = '" + LocalSKU + "' AND TYPE = 'R'", cn);

            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public static bool Insert(POHistoryobj poh)
        {
            cn = Connection.GetConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO POHistory(Type,PONumber,ItemNumber,Date,EnteredBy,Quantity,Cost,LocalSKU,SuppliersSKU,Lot) VALUES(@Type,@PONumber,@ItemNumber,@Date,@EnteredBy,@Quantity,@Cost,@LocalSKU,@SuppliersSKU,'Pieces')", cn);
            cmd.Parameters.AddWithValue("@Type", "R");
            cmd.Parameters.AddWithValue("@PONumber", poh.PONumber);
            cmd.Parameters.AddWithValue("@ItemNumber", poh.ItemNumber);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@EnteredBy", poh.EnteredBy);
            cmd.Parameters.AddWithValue("@Quantity", poh.Quantity);
            cmd.Parameters.AddWithValue("@Cost", poh.Cost);
            cmd.Parameters.AddWithValue("@LocalSKU", poh.LocalSKU);
            cmd.Parameters.AddWithValue("@SuppliersSKU", poh.SuppliersSKU);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void Insert(InventoryRecord inventoryrecord, int ItemNumber, string cancelBy)
        {
            SqlConnection con = cn;
            SqlCommand cmd = new SqlCommand("insert into POHistory([Type],PONumber,ItemNumber,[Date],EnteredBy,Quantity,Cost,LocalSKU,Lot,PiecesPerLot,NumberOfLots,TempQuantity,SuppliersSKU) values ('E',( select MAX(PONumber) from PurchaseOrders),@ItemNumber,GETDATE(),@EnteredBy,@Quantity,@Cost,@LocalSKU,'pieces',1,@NumberOfLots,@TempQuantity,@SuppliersSKU)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ItemNumber", ItemNumber);
            cmd.Parameters.AddWithValue("@EnteredBy", cancelBy);
            cmd.Parameters.AddWithValue("@Quantity", inventoryrecord.QtyToOrder);
            cmd.Parameters.AddWithValue("@Cost", inventoryrecord.Cost);
            cmd.Parameters.AddWithValue("@LocalSKU", inventoryrecord.SKU);
            cmd.Parameters.AddWithValue("@NumberOfLots", inventoryrecord.QtyToOrder);
            cmd.Parameters.AddWithValue("@TempQuantity", inventoryrecord.QtyToOrder);
            cmd.Parameters.AddWithValue("@SuppliersSKU", inventoryrecord.SupplierSKU);
            int x = cmd.ExecuteNonQuery();
        }
    }
}
