using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace SCANINOUTBL
{
    public class Inventory
    {
        SqlConnection cn;
        public static SqlConnection conn;        
        public Inventory()
        {
            cn = Connection.GetConnection();
            conn = Connection.GetConnection();
        }

        public bool UpdatePrice(string LocalSKU, decimal Price, decimal Price2, decimal Price3,int Quantity)
        {
            string UpdateCommand = " UPDATE Inventory SET " +                                    
                                    "Price = @Price, " +
                                    "Price2 = @Price2, " +
                                    "Price3 = @Price3, " +
                                    "QOH = QOH + @QOH " +                                                                        
                                    "WHERE LocalSKU = @LocalSKU";
            SqlCommand cmd = new SqlCommand(UpdateCommand, cn);            
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@Price2", Price2);
            cmd.Parameters.AddWithValue("@Price3", Price3);
            cmd.Parameters.AddWithValue("@QOH", Quantity);            
            cmd.Parameters.AddWithValue("@LocalSKU", LocalSKU);
            int res = cmd.ExecuteNonQuery();
            if (res <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool UpDateLookUp(DataRow datarow)
        {
            string UpdateCommand = " UPDATE Inventory SET " +
                                    "ItemName = @ItemName, " +
                                    "Price = @Price, " +
                                    "Price2 = @Price2, " +
                                    "Price3 = @Price3, " +
                                    "QOH = @QOH, " +
                                    "Integer1 = @Integer1, " +
                                    "Integer2 = @Integer2, " +
                                    "Integer3 = @Integer3, " +
                                    "Integer4 = @Integer4, " +
                                    "Integer5 = @Integer5, " +
                                    "Barcode = @Barcode, " +
                                    "ReorderPoint = @ReorderPoint, " +
                                    "ReorderQuantity = @ReorderQuantity " +
                                    "WHERE LocalSKU = @LocalSKU";
            SqlCommand cmd = new SqlCommand(UpdateCommand,cn);
            cmd.Parameters.AddWithValue("@ItemName", datarow["ItemName"]);
            cmd.Parameters.AddWithValue("@Price", datarow["Price"]);
            cmd.Parameters.AddWithValue("@Price2", datarow["Price2"]);
            cmd.Parameters.AddWithValue("@Price3", datarow["Price3"]);
            cmd.Parameters.AddWithValue("@QOH", datarow["QOH"]);
            cmd.Parameters.AddWithValue("@Integer1", datarow["Integer1"]);
            cmd.Parameters.AddWithValue("@Integer2", datarow["Integer2"]);
            cmd.Parameters.AddWithValue("@Integer3", datarow["Integer3"]);
            cmd.Parameters.AddWithValue("@Integer4", datarow["Integer4"]);
            cmd.Parameters.AddWithValue("@Integer5", datarow["Integer5"]);
            cmd.Parameters.AddWithValue("@Barcode", datarow["Barcode"]);
            cmd.Parameters.AddWithValue("@ReorderPoint", datarow["ReorderPoint"]);
            cmd.Parameters.AddWithValue("@ReorderQuantity", datarow["ReorderQuantity"]);
            cmd.Parameters.AddWithValue("@LocalSKU", datarow["LocalSKU"]);
            int res = cmd.ExecuteNonQuery();
            if (res <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public DataTable GetDataLookUP(string Barcode, string SKU)
        {
            string SelectCommand = "SELECT LocalSKU, ItemName, Price, Price2, Price3, QOH, Integer1, Integer2, Integer3, Integer4, Integer5, " +
                                    "Barcode, ReorderPoint, ReorderQuantity FROM Inventory WHERE ";
            if (!string.IsNullOrWhiteSpace(Barcode))
            {
                if (!string.IsNullOrWhiteSpace(SKU))
                {
                    SelectCommand += "(barcode like '%" + Barcode.Replace("'", "''") + "%' OR LocalSKU IN (SELECT Text2 fROM Lists WHERE Text1 like '%" + Barcode.Replace("'","''") + "%'))  AND LocalSKU like '%" + SKU.Replace("'", "''") + "%'";
                }
                else
                {
                    SelectCommand += "barcode like '%" + Barcode.Replace("'", "''") + "%' OR LocalSKU IN (SELECT Text2 fROM Lists WHERE Text1 like '%" + Barcode.Replace("'","''") + "%') ";
                }
                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(SKU))
                {
                    SelectCommand += "1 = 1";
                }
                else
                {
                    SelectCommand += "LocalSKU like '%" + SKU.Replace("'", "''") + "%' ";
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(SelectCommand, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SearchData(string Filter)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            if (Filter.Contains("SupplierSKU"))
            {
                cmd.CommandText = "select i.LocalSKU,i.ItemName,i.Price,i.QOH,i.Integer1,i.Integer2,i.Integer3,i.Integer4,i.Integer5" +
                        " from  Inventory i join InventorySuppliers s on i.LocalSKU=s.LocalSKU where " + Filter + "";
            }
            else {

                cmd.CommandText = "select i.LocalSKU,i.ItemName,i.Price,i.QOH,i.Integer1,i.Integer2,i.Integer3,i.Integer4,i.Integer5" +
                            " from  Inventory i where " + Filter + "";
            
            }
      
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            return dt;
        }

        public List<string> GetSKUs(string SupplierSKU)
        {
            List<string> SKUs = new List<string>();
            string SelectStatement = "SELECT i.LocalSKU FROM  Inventory i left join (SELECT * FROM InventorySuppliers WHERE PrimarySupplier='true') s on i.LocalSKU=S.LocalSKU WHERE s.SupplierSKU = '" + SupplierSKU + "' ";
            SqlCommand cmd = new SqlCommand(SelectStatement, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                try
                {
                    SKUs.Add(dr["LocalSKU"].ToString());
                }
                catch (Exception)
                {
                }    
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            
            return SKUs;
        }
        public List<InventoryRecord> GetBySKU(string FillterType, string SKU)
        {
            string SelectCommand = "SELECT SupplierID,i.[LocalSKU] as SKU,[ItemName],isup.SupplierSKU as SupplierSKU ,ReorderPoint,ReorderQuantity,QOH,i.Price10 as Cost,i.Integer1,i.Integer2,i.Integer3,i.Backordered,i.Price10 as ExtendedCost,isnull((select sum(Quantity) from POHistory poh where i.LocalSKU=poh.LocalSKU and type='E'),0) as OnOrder,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(day,-14,getdate()) and DetailDate <= getdate()),0) as SoldLast14,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(day,-30,getdate()) and DetailDate <= getdate()),0) as SoldLast30,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND year(od.DetailDate) = year(getdate())) ,0)as SoldYTD,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND YEAR(od.DetailDate)=year(getdate())-1 ),0) as SoldLY,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(MONTH,-24,getdate()) and DetailDate <= getdate()),0) as SoldL24M,isnull((SELECT MAX(Orders.OrderNumber) FROM [Order Details] INNER JOIN Orders ON ([Order Details].OrderNumber = Orders.OrderNumber) WHERE SKU =i.[LocalSKU]  AND Approved = 'False' AND Cancelled = 'False'),0) as OrderNumber FROM [dbo].[Inventory] i join InventorySuppliers isup on i.LocalSKU=isup.LocalSKU where PrimarySupplier=1 and " + (FillterType.ToLower() == "s" ? "isup.SupplierSKU" : "i.LocalSKU") + "='" + SKU + "'";
            SqlCommand cmd = new SqlCommand(SelectCommand, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<InventoryRecord> inventoryrecords = new List<InventoryRecord>();
            while (dr.Read())
            {
                InventoryRecord inventoryrecord = new InventoryRecord();
                inventoryrecord.SKU = dr["SKU"] == DBNull.Value ? "" : dr["SKU"].ToString();
                inventoryrecord.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();
                inventoryrecord.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : dr["SupplierSKU"].ToString();
                inventoryrecord.SupplierID = dr["SupplierID"] == DBNull.Value ? "" : dr["SupplierID"].ToString();
                inventoryrecord.QOH = dr["QOH"] == DBNull.Value ? 0 : int.Parse(dr["QOH"].ToString());
                inventoryrecord.ReorderPoint = dr["ReorderPoint"] == DBNull.Value ? 0 : int.Parse(dr["ReorderPoint"].ToString());
                inventoryrecord.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                inventoryrecord.QtyToOrder = 0;
                inventoryrecord.ExtendedCost = dr["ExtendedCost"] == DBNull.Value ? 0 : decimal.Parse(dr["ExtendedCost"].ToString());
                inventoryrecord.Backordered = dr["Backordered"] == DBNull.Value ? 0 : decimal.Parse(dr["Backordered"].ToString());
                inventoryrecord.SoldL24M = dr["SoldL24M"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldL24M"].ToString());
                inventoryrecord.SoldLY = dr["SoldLY"] == DBNull.Value ? 0 : int.Parse(dr["SoldLY"].ToString());
                inventoryrecord.SoldYTD = dr["SoldYTD"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldYTD"].ToString());
                inventoryrecord.SoldLast30 = dr["SoldLast30"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast30"].ToString());
                inventoryrecord.SoldLast14 = dr["SoldLast14"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast14"].ToString());
                inventoryrecord.OnOrder = dr["OnOrder"] == DBNull.Value ? 0 : decimal.Parse(dr["OnOrder"].ToString());
                inventoryrecord.Integer3 = dr["Integer3"] == DBNull.Value ? 0 : int.Parse(dr["Integer3"].ToString());
                inventoryrecord.Integer2 = dr["Integer2"] == DBNull.Value ? 0 : int.Parse(dr["Integer2"].ToString());
                inventoryrecord.Integer1 = dr["Integer1"] == DBNull.Value ? 0 : int.Parse(dr["Integer1"].ToString());
                inventoryrecord.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : int.Parse(dr["OrderNumber"].ToString());
                inventoryrecord.Cost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                inventoryrecord.HideCost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                inventoryrecords.Add(inventoryrecord);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return inventoryrecords;
        }
        public List<InventoryRecord> GetReorderQty(string SupplierID, string NumberOfDays, out string listOfLocalSKU)
        {
            listOfLocalSKU = "";
            string StartDate = DateTime.Now.ToShortDateString();
            string EndDate = DateTime.Now.AddDays(-1 * Convert.ToInt32(NumberOfDays)).ToShortDateString();
            string SelectCommand = "SELECT SupplierID,i.[LocalSKU] as SKU,[ItemName],isup.SupplierSKU as SupplierSKU ,ReorderPoint,ReorderQuantity,QOH,i.Price10 as Cost,i.Integer1,i.Integer2,i.Integer3,i.Backordered,i.Price10 as ExtendedCost,isnull((select sum(Quantity) from POHistory poh where i.LocalSKU=poh.LocalSKU and type='E'),0) as OnOrder,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(day,-14,getdate()) and DetailDate <= getdate()),0) as SoldLast14,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(day,-30,getdate()) and DetailDate <= getdate()),0) as SoldLast30,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND year(od.DetailDate) = year(getdate())) ,0)as SoldYTD,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND YEAR(od.DetailDate)=year(getdate())-1 ),0) as SoldLY,isnull((SELECT SUM(QuantityOrdered) FROM [dbo].[Order Details] od WHERE od.SKU = i.LocalSKU AND od.DetailDate >= DATEADD(MONTH,-24,getdate()) and DetailDate <= getdate()),0) as SoldL24M,isnull((SELECT MAX(Orders.OrderNumber) FROM [Order Details] INNER JOIN Orders ON ([Order Details].OrderNumber = Orders.OrderNumber) WHERE SKU =i.[LocalSKU]  AND Approved = 'False' AND Cancelled = 'False'),0) as OrderNumber,isnull( (select SUM([QuantityNeeded]) as [QuantityNeeded] from [Order Details] od   group by SKU ,DetailDate having SUM([QuantityNeeded])>0 and DetailDate between '" + DateTime.Now + "' and '" + EndDate + "' and od.SKU=i.LocalSKU),0) as QuantityNeeded FROM [dbo].[Inventory] i join InventorySuppliers isup on i.LocalSKU=isup.LocalSKU where  ReorderQuantity > 0  And primarySupplier=1 and i.LocalSKU in (select LocalSKU from [InventorySuppliers] where SupplierID= " + SupplierID + "  And primarySupplier=1 )";
            SqlCommand cmd = new SqlCommand(SelectCommand, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<InventoryRecord> inventoryrecords = new List<InventoryRecord>();
            while (dr.Read())
            {
                int ReorderPoint = dr["ReorderPoint"] == DBNull.Value ? 0 : int.Parse(dr["ReorderPoint"].ToString());
                int QuantityNeeded = dr["QuantityNeeded"] == DBNull.Value ? 0 : int.Parse(dr["QuantityNeeded"].ToString());
                int QOH = dr["QOH"] == DBNull.Value ? 0 : int.Parse(dr["QOH"].ToString());
                if ((ReorderPoint + QuantityNeeded) >= QOH)
                {
                    InventoryRecord inventoryrecord = new InventoryRecord();
                    inventoryrecord.SupplierID = dr["SupplierID"] == DBNull.Value ? "" : dr["SupplierID"].ToString();
                    inventoryrecord.SKU = dr["SKU"] == DBNull.Value ? "" : dr["SKU"].ToString();
                    inventoryrecord.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : dr["SupplierSKU"].ToString();
                    inventoryrecord.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();
                    inventoryrecord.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                    inventoryrecord.ExtendedCost = dr["ExtendedCost"] == DBNull.Value ? 0 : decimal.Parse(dr["ExtendedCost"].ToString());
                    inventoryrecord.Backordered = dr["Backordered"] == DBNull.Value ? 0 : decimal.Parse(dr["Backordered"].ToString());
                    inventoryrecord.SoldL24M = dr["SoldL24M"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldL24M"].ToString());
                    inventoryrecord.SoldLY = dr["SoldLY"] == DBNull.Value ? 0 : int.Parse(dr["SoldLY"].ToString());
                    inventoryrecord.SoldYTD = dr["SoldYTD"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldYTD"].ToString());
                    inventoryrecord.SoldLast30 = dr["SoldLast30"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast30"].ToString());
                    inventoryrecord.SoldLast14 = dr["SoldLast14"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast14"].ToString());
                    inventoryrecord.OnOrder = dr["OnOrder"] == DBNull.Value ? 0 : decimal.Parse(dr["OnOrder"].ToString());
                    inventoryrecord.Integer3 = dr["Integer3"] == DBNull.Value ? 0 : int.Parse(dr["Integer3"].ToString());
                    inventoryrecord.Integer2 = dr["Integer2"] == DBNull.Value ? 0 : int.Parse(dr["Integer2"].ToString());
                    inventoryrecord.Integer1 = dr["Integer1"] == DBNull.Value ? 0 : int.Parse(dr["Integer1"].ToString());
                    inventoryrecord.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : int.Parse(dr["OrderNumber"].ToString());
                    inventoryrecord.Cost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                    inventoryrecord.HideCost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                    inventoryrecord.QOH = QOH;
                    inventoryrecord.ReorderPoint = ReorderPoint;
                    inventoryrecord.QuantityNeeded = QuantityNeeded;
                    inventoryrecord.QtyToOrder = QuantityNeeded + inventoryrecord.ReorderQuantity;
                    inventoryrecord.SupplierID = SupplierID;
                    inventoryrecord.ISordered = true;
                    listOfLocalSKU += "'" + inventoryrecord.SKU + "',";
                    inventoryrecords.Add(inventoryrecord);
                }
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            listOfLocalSKU = inventoryrecords.Count > 0 ? listOfLocalSKU.Substring(0, listOfLocalSKU.Length - 1) : "";
            return inventoryrecords;
        }


        public InventoryRecord GetData(string SKU, string Barcode,ref string result)
        {
            InventoryRecord IR = new InventoryRecord();
            try
            {
                if (string.IsNullOrWhiteSpace(SKU) && string.IsNullOrWhiteSpace(Barcode))
                {
                    result = "1";
                    return IR;
                }
                SqlCommand cmd = new SqlCommand();
                if (string.IsNullOrWhiteSpace(Barcode))
                {
                    Barcode = SKU;
                }

                string SelectStatement = "SELECT i.ItemName,i.Barcode,i.LocalSKU,i.Price,i.Price2,i.Price3,i.Price4,i.Price5,i.Price6,i.Price7,i.Price8,i.Price9,i.Price10,i.Text1,i.Text2,i.Text3,i.Text4,i.Text5,i.Integer1,i.Integer2,i.Integer3,i.Integer4,i.Integer5,i.QOH,i.Location,i.weight,i.Actualweight,i.Reorderpoint,i.Backordered,s.SupplierSKU FROM  Inventory i left join (SELECT * FROM InventorySuppliers WHERE PrimarySupplier='true') s on i.LocalSKU=S.LocalSKU WHERE i.Barcode = '" + Barcode + "' OR i.LocalSKU = '" + Barcode + "' ";
                //if (string.IsNullOrWhiteSpace(SKU))
                //{
                //    SelectStatement = "SELECT * FROM Inventory WHERE Barcode = '" + Barcode + "'";
                //}
                //else
                //{
                //    if (string.IsNullOrWhiteSpace(Barcode))
                //    {
                //        SelectStatement = "SELECT * FROM Inventory WHERE LocalSKU = '" + SKU + "'";   
                //    }
                //    else
                //    {
                //        SelectStatement = "SELECT * FROM Inventory WHERE Barcode = '" + Barcode + "' AND LocalSKU = '" + SKU + "'";
                //    }
                //}
                cmd.CommandText = SelectStatement;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {                    
                    while (dr.Read())
                    {
                        IR.ProductName = dr["ItemName"].ToString();
                        IR.Barcode = dr["Barcode"].ToString();
                        IR.SKU = dr["LocalSKU"].ToString();
                        IR.Price = dr["Price"] == DBNull.Value ? 0 : (decimal)dr["Price"];
                        IR.QOH = (int)dr["QOH"];
                        IR.Price4 = dr["Price4"] == DBNull.Value ? 0 : (decimal)dr["Price4"];
                        IR.Price3 = dr["Price3"]==DBNull.Value ? 0 : (decimal)dr["Price3"];
                        IR.Price2 = dr["Price2"] == DBNull.Value ? 0 : (decimal)dr["Price2"];
                        IR.Price = dr["Price"] == DBNull.Value ? 0 : (decimal)dr["Price"];
                        IR.Location = dr["Location"] == DBNull.Value ? "" : dr["Location"].ToString();
                        IR.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : dr["SupplierSKU"].ToString();


                        IR.Price5 = dr["Price5"] == DBNull.Value ? 0 : (decimal)dr["Price5"];
                        IR.Price6 = dr["Price6"] == DBNull.Value ? 0 : (decimal)dr["Price6"];
                        IR.Price7 = dr["Price7"] == DBNull.Value ? 0 : (decimal)dr["Price7"];
                        IR.Price8 = dr["Price8"] == DBNull.Value ? 0 : (decimal)dr["Price8"];
                        IR.Price9 = dr["Price9"] == DBNull.Value ? 0 : (decimal)dr["Price9"];
                        IR.Price10 = dr["Price10"] == DBNull.Value ? 0 : (decimal)dr["Price10"];

                        IR.Text1 = dr["Text1"] == DBNull.Value ? "" : dr["Text1"].ToString();
                        IR.Text2 = dr["Text2"] == DBNull.Value ? "" : dr["Text2"].ToString();
                        IR.Text3 = dr["Text3"] == DBNull.Value ? "" : dr["Text3"].ToString();
                        IR.Text4 = dr["Text4"] == DBNull.Value ? "" : dr["Text4"].ToString();
                        IR.Text5 = dr["Text5"] == DBNull.Value ? "" : dr["Text5"].ToString();

                        IR.Integer1 = dr["Integer1"] == DBNull.Value ? 0 : (int)dr["Integer1"];
                        IR.Integer2 = dr["Integer2"] == DBNull.Value ? 0 : (int)dr["Integer2"];
                        IR.Integer3 = dr["Integer3"] == DBNull.Value ? 0 : (int)dr["Integer3"];
                        IR.Integer4 = dr["Integer4"] == DBNull.Value ? 0 : (int)dr["Integer4"];
                        IR.Integer5 = dr["Integer5"] == DBNull.Value ? 0 : (int)dr["Integer5"];

                        IR.Weight = dr["Weight"] == DBNull.Value ? 0 : decimal.Parse(dr["Weight"].ToString());
                        IR.Actualweight = dr["Actualweight"] == DBNull.Value ? 0 : decimal.Parse(dr["Actualweight"].ToString());
                        IR.Backordered = dr["Backordered"] == DBNull.Value ? 0 : (int)dr["Backordered"];
                        IR.ReorderPoint = dr["ReorderPoint"] == DBNull.Value ? 0 : (int)dr["ReorderPoint"];

                    }
                    dr.Close();
                    SqlCommand cmdOD = new SqlCommand("SELECT MAX(Orders.OrderNumber) FROM [Order Details] INNER JOIN Orders ON ([Order Details].OrderNumber = Orders.OrderNumber) WHERE SKU = '" + IR.SKU + "' AND Approved = 'False' AND Cancelled = 'False'", cn);
                    try
                    {
                        IR.OrderNumber = (int)cmdOD.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {                        
                        IR.OrderNumber = 0;
                    }
                    
                }
                else
                {
                    dr.Close();
                    if (!string.IsNullOrWhiteSpace(Barcode))
                    {
                        SqlCommand cmdList = new SqlCommand("SELECT Text2 fROM Lists WHERE Text1 = '" + Barcode + "'", cn);
                        string SKU2 = cmdList.ExecuteScalar() == null ? "" : cmdList.ExecuteScalar().ToString();
                        if (!string.IsNullOrWhiteSpace(SKU2))
                        {
                            cmd.CommandText = "SELECT i.ItemName,i.Barcode,i.LocalSKU,i.Price,i.Price2,i.Price3,i.Price4,i.Price5,i.Price6,i.Price7,i.Price8,i.Price9,i.Price10,i.Text1,i.Text2,i.Text3,i.Text4,i.Text5,i.Integer1,i.Integer2,i.Integer3,i.Integer4,i.Integer5,i.QOH,i.Location,i.weight,i.Actualweight,i.Reorderpoint,i.Backordered,s.SupplierSKU FROM  Inventory i left join (SELECT * FROM InventorySuppliers WHERE PrimarySupplier='true') s on i.LocalSKU=S.LocalSKU WHERE i.LocalSKU = '" + SKU2 + "'";
                            SqlDataReader dr2 = cmd.ExecuteReader();
                            if (dr2.HasRows)
                            {
                                
                                while (dr2.Read())
                                {
                                    IR.ProductName = dr2["ItemName"].ToString();
                                    IR.Barcode = dr2["Barcode"].ToString();
                                    IR.SKU = dr2["LocalSKU"].ToString();
                                    IR.Price = dr2["Price"] == DBNull.Value ? 0 : (decimal)dr2["Price"];
                                    IR.QOH = (int)dr2["QOH"];
                                    IR.SupplierSKU = dr2["SupplierSKU"] == DBNull.Value ? "" : dr2["SupplierSKU"].ToString();
                                    IR.Price3 = dr2["Price3"] == DBNull.Value ? 0 : (decimal)dr2["Price3"];
                                    IR.Price4 = dr2["Price4"] == DBNull.Value ? 0 : (decimal)dr2["Price4"];
                                    IR.Price2 = dr2["Price2"] == DBNull.Value ? 0 : (decimal)dr2["Price2"];
                                    IR.Price = dr2["Price"] == DBNull.Value ? 0 : (decimal)dr2["Price"];
                                    IR.Location = dr2["Location"] == DBNull.Value ? "" : dr2["Location"].ToString();

                                    IR.Price5 = dr2["Price5"] == DBNull.Value ? 0 : (decimal)dr2["Price5"];
                                    IR.Price6 = dr2["Price6"] == DBNull.Value ? 0 : (decimal)dr2["Price6"];
                                    IR.Price7 = dr2["Price7"] == DBNull.Value ? 0 : (decimal)dr2["Price7"];
                                    IR.Price8 = dr2["Price8"] == DBNull.Value ? 0 : (decimal)dr2["Price8"];
                                    IR.Price9 = dr2["Price9"] == DBNull.Value ? 0 : (decimal)dr2["Price9"];
                                    IR.Price10 = dr2["Price10"] == DBNull.Value ? 0 : (decimal)dr2["Price10"];

                                    IR.Text1 = dr2["Text1"] == DBNull.Value ? "" : dr2["Text1"].ToString();
                                    IR.Text2 = dr2["Text2"] == DBNull.Value ? "" : dr2["Text2"].ToString();
                                    IR.Text3 = dr2["Text3"] == DBNull.Value ? "" : dr2["Text3"].ToString();
                                    IR.Text4 = dr2["Text4"] == DBNull.Value ? "" : dr2["Text4"].ToString();
                                    IR.Text5 = dr2["Text5"] == DBNull.Value ? "" : dr2["Text5"].ToString();

                                    IR.Integer1 = dr2["Integer1"] == DBNull.Value ? 0 : (int)dr2["Integer1"];
                                    IR.Integer2 = dr2["Integer2"] == DBNull.Value ? 0 : (int)dr2["Integer2"];
                                    IR.Integer3 = dr2["Integer3"] == DBNull.Value ? 0 : (int)dr2["Integer3"];
                                    IR.Integer4 = dr2["Integer4"] == DBNull.Value ? 0 : (int)dr2["Integer4"];
                                    IR.Integer5 = dr2["Integer5"] == DBNull.Value ? 0 : (int)dr2["Integer5"];

                                    IR.Weight = dr2["Weight"] == DBNull.Value ? 0 : decimal.Parse(dr2["Weight"].ToString());
                                    IR.Actualweight = dr2["Actualweight"] == DBNull.Value ? 0 : decimal.Parse(dr2["Actualweight"].ToString());
                                    IR.Backordered = dr2["Backordered"] == DBNull.Value ? 0 : (int)dr2["Backordered"];
                                    IR.ReorderPoint = dr2["ReorderPoint"] == DBNull.Value ? 0 : (int)dr2["ReorderPoint"];
                                    
                                }
                                dr2.Close();
                                SqlCommand cmdOD = new SqlCommand("SELECT MAX(OrderNumber) FROM [Order Details] WHERE SKU = '" + IR.SKU + "'", cn);
                                try
                                {
                                    IR.OrderNumber = (int)cmdOD.ExecuteScalar();
                                }
                                catch (Exception ex)
                                {
                                    IR.OrderNumber = 0;
                                }
                            }
                            else
                            {
                                dr2.Close();
                                result = "2";
                                return IR;
                            }
                        }
                        else
                        {
                            dr.Close();
                            result = "2";
                            return IR;
                        }
                    }
                    else
                    {
                        dr.Close();
                        result = "2";
                        return IR;
                    }
                    

                }                
            }
            catch (Exception)
            {
                
                throw;
            }
            result = "0";
            return IR;
        }
        private void updateIN(InventoryRecord i)
        {
            string UpdateStatement = string.Format("UPDATE INVENTORY SET QOH = QOH + {0} WHERE LocalSKU = '{1}'",i.Quantity,i.SKU);
            SqlCommand cmd= new SqlCommand(UpdateStatement, cn);
            cmd.ExecuteNonQuery();
        }
        private void updateOUT(InventoryRecord i)
        {
            string UpdateStatement = string.Format("UPDATE INVENTORY SET QOH = QOH - {0} WHERE LocalSKU = '{1}'", i.Quantity, i.SKU);
            SqlCommand cmd = new SqlCommand(UpdateStatement, cn);
            cmd.ExecuteNonQuery();
        }
        public bool SaveList(List<InventoryRecord> IRL, string UpdateType)
        {
            if (IRL.Count == 0)
            {
                return false;
            }
            try
            {
                if (UpdateType == "IN")
                {
                    foreach (InventoryRecord item in IRL)
                    {
                        updateIN(item);
                    }
                }
                else if (UpdateType == "OUT")
                {
                    foreach (InventoryRecord item in IRL)
                    {
                        updateOUT(item);
                    }
                    
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetItemName(string LocalSKU)
        {
            conn = Connection.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT ItemName FROM Inventory WHERE LocalSKU =  '" + LocalSKU + "'", conn);
            return cmd.ExecuteScalar().ToString();
        }

        public static int AddToLogAccDB(InventoryRecord ir)
        {
            int ID = 0;
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Connection.DBConn;
                cmd.CommandText = "SELECT ID FROM POLog WHERE SKU = @SKU";
                cmd.Parameters.AddWithValue("@SKU", ir.SKU);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                ir.CretionDate = DateTime.Now;
                ir.ISordered = ir.ISordered == null ? false : ir.ISordered;
                if (ID > 0)
                {
                    cmd.CommandText = "UPDATE POLog SET IsAuto = @IsAuto , ISordered = @ISordered, CretionDate=@CretionDate , ISDeleted=@ISDeleted, QtyToOrder = @QtyToOrder ,Cost=@Cost,Backordered=@Backordered,ExtendedCost=@ExtendedCost,OnOrder=@OnOrder,SoldLast14=@SoldLast14,SoldLast30=@SoldLast30,SoldYTD=@SoldYTD,SoldLY=@SoldLY,SoldL24M=@SoldL24M,OrderNumber=@OrderNumber,HideCost=@HideCost WHERE SKU = @SKU";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IsAuto", ir.IsAuto);
                    cmd.Parameters.AddWithValue("@ISordered", ir.ISordered);
                    cmd.Parameters.AddWithValue("@CretionDate", ir.CretionDate.ToString("dd/MM/yyyy h:mm:ss tt"));
                    cmd.Parameters.AddWithValue("@ISDeleted", ir.ISDeleted);
                    cmd.Parameters.AddWithValue("@QtyToOrder", ir.QtyToOrder);
                    cmd.Parameters.AddWithValue("@Cost", ir.Cost);
                    cmd.Parameters.AddWithValue("@Backordered", ir.Backordered);
                    cmd.Parameters.AddWithValue("@ExtendedCost", ir.ExtendedCost);
                    cmd.Parameters.AddWithValue("@OnOrder", ir.OnOrder);
                    cmd.Parameters.AddWithValue("@SoldLast14", ir.SoldLast14);
                    cmd.Parameters.AddWithValue("@SoldLast30", ir.SoldLast30);
                    cmd.Parameters.AddWithValue("@SoldYTD", ir.SoldYTD);
                    cmd.Parameters.AddWithValue("@SoldLY", ir.SoldLY);
                    cmd.Parameters.AddWithValue("@SoldL24M", ir.SoldL24M);
                    cmd.Parameters.AddWithValue("@OrderNumber", ir.OrderNumber);
                    cmd.Parameters.AddWithValue("@HideCost", ir.HideCost);
                    cmd.Parameters.AddWithValue("@SKU", ir.SKU);


                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = "INSERT INTO POLog ([IsAuto],[ISDeleted],[ItemName],[SKU],[ReorderPoint],[ReorderQuantity],[QuantityNeeded],[QtyToOrder],[QOH],[CretionDate],[ISordered],[SupplierSKU],[SupplierID],[Cost],[Integer1],[Integer2],[Integer3],[Backordered],[ExtendedCost],[OnOrder],[SoldLast14],[SoldLast30],[SoldYTD],[SoldLY],[SoldL24M],[OrderNumber],[HideCost]) VALUES (@IsAuto,@ISDeleted,@ItemName,@SKU,@ReorderPoint,@ReorderQuantity,@QuantityNeeded,@QtyToOrder,@QOH,@CretionDate,@ISordered,@SupplierSKU,@SupplierID,@Cost,@Integer1,@Integer2,@Integer3,@Backordered,@ExtendedCost,@OnOrder,@SoldLast14,@SoldLast30,@SoldYTD,@SoldLY,@SoldL24M,@OrderNumber,@HideCost)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@IsAuto", ir.IsAuto);
                    cmd.Parameters.AddWithValue("@ISDeleted", ir.ISDeleted);
                    cmd.Parameters.AddWithValue("@ItemName", ir.ItemName);
                    cmd.Parameters.AddWithValue("@SKU", ir.SKU);
                    cmd.Parameters.AddWithValue("@ReorderPoint", ir.ReorderPoint);
                    cmd.Parameters.AddWithValue("@ReorderQuantity", ir.ReorderQuantity);
                    cmd.Parameters.AddWithValue("@QuantityNeeded", ir.QuantityNeeded);
                    cmd.Parameters.AddWithValue("@QtyToOrder", ir.QtyToOrder);
                    cmd.Parameters.AddWithValue("@QOH", ir.QOH);
                    cmd.Parameters.AddWithValue("@CretionDate", ir.CretionDate.ToString("dd/MM/yyyy h:mm:ss tt"));
                    cmd.Parameters.AddWithValue("@ISordered", ir.ISordered);
                    cmd.Parameters.AddWithValue("@SupplierSKU", ir.SupplierSKU);
                    cmd.Parameters.AddWithValue("@SupplierID", ir.SupplierID);
                    cmd.Parameters.AddWithValue("@Cost", ir.Cost);
                    cmd.Parameters.AddWithValue("@Integer1", ir.Integer1);
                    cmd.Parameters.AddWithValue("@Integer2", ir.Integer2);
                    cmd.Parameters.AddWithValue("@Integer3", ir.Integer3);
                    cmd.Parameters.AddWithValue("@Backordered", ir.Backordered);
                    cmd.Parameters.AddWithValue("@ExtendedCost", ir.ExtendedCost);
                    cmd.Parameters.AddWithValue("@OnOrder", ir.OnOrder);
                    cmd.Parameters.AddWithValue("@SoldLast14", ir.SoldLast14);
                    cmd.Parameters.AddWithValue("@SoldLast30", ir.SoldLast30);
                    cmd.Parameters.AddWithValue("@SoldYTD", ir.SoldYTD);
                    cmd.Parameters.AddWithValue("@SoldLY", ir.SoldLY);
                    cmd.Parameters.AddWithValue("@SoldL24M", ir.SoldL24M);
                    cmd.Parameters.AddWithValue("@OrderNumber", ir.OrderNumber);
                    cmd.Parameters.AddWithValue("@HideCost", ir.HideCost);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception)
            {

                throw;
            }
            return ID;
        }

        public static List<InventoryRecord> GetAllNotOrderedRecord(out string listOfLocalSKU)
        {
            List<InventoryRecord> irs = new List<InventoryRecord>();
            listOfLocalSKU = "";
            try
            {

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM POLog WHERE ISordered = @ISordered And IsDeleted=@IsDeleted", Connection.DBConn);
                cmd.Parameters.AddWithValue("@ISordered", false);
                cmd.Parameters.AddWithValue("@IsDeleted", false);
                OleDbDataReader dr = cmd.ExecuteReader();
                InventoryRecord ir;
                while (dr.Read())
                {
                    ir = new InventoryRecord();
                    ir.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();
                    ir.SupplierID = dr["SupplierID"] == DBNull.Value ? "" : dr["SupplierID"].ToString();
                    ir.SKU = dr["SKU"] == DBNull.Value ? "" : dr["SKU"].ToString();
                    ir.ReorderPoint = dr["ReorderPoint"] == DBNull.Value ? 0 : int.Parse(dr["ReorderPoint"].ToString());
                    ir.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                    ir.QuantityNeeded = dr["QuantityNeeded"] == DBNull.Value ? 0 : int.Parse(dr["QuantityNeeded"].ToString());
                    ir.QtyToOrder = dr["QtyToOrder"] == DBNull.Value ? 0 : int.Parse(dr["QtyToOrder"].ToString());
                    ir.QOH = dr["QOH"] == DBNull.Value ? 0 : int.Parse(dr["QOH"].ToString());
                    ir.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : dr["SupplierSKU"].ToString();
                    ir.CretionDate = dr["CretionDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CretionDate"].ToString());
                    ir.ISordered = dr["ISordered"] == DBNull.Value ? false : Convert.ToBoolean(dr["ISordered"].ToString());
                    ir.ExtendedCost = dr["ExtendedCost"] == DBNull.Value ? 0 : decimal.Parse(dr["ExtendedCost"].ToString());
                    ir.Backordered = dr["Backordered"] == DBNull.Value ? 0 : decimal.Parse(dr["Backordered"].ToString());
                    ir.SoldL24M = dr["SoldL24M"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldL24M"].ToString());
                    ir.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                    ir.SoldYTD = dr["SoldYTD"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldYTD"].ToString());
                    ir.SoldLast30 = dr["SoldLast30"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast30"].ToString());
                    ir.SoldLast14 = dr["SoldLast14"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast14"].ToString());
                    ir.OnOrder = dr["OnOrder"] == DBNull.Value ? 0 : decimal.Parse(dr["OnOrder"].ToString());
                    ir.Integer3 = dr["Integer3"] == DBNull.Value ? 0 : int.Parse(dr["Integer3"].ToString());
                    ir.Integer2 = dr["Integer2"] == DBNull.Value ? 0 : int.Parse(dr["Integer2"].ToString());
                    ir.Integer1 = dr["Integer1"] == DBNull.Value ? 0 : int.Parse(dr["Integer1"].ToString());
                    ir.Cost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                    ir.HideCost = dr["HideCost"] == DBNull.Value ? 0 : decimal.Parse(dr["HideCost"].ToString());
                    ir.SoldLY = dr["SoldLY"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLY"].ToString());
                    ir.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : int.Parse(dr["OrderNumber"].ToString());
                    listOfLocalSKU += "'" + ir.SKU + "',";
                    irs.Add(ir);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
                throw;
            }
            listOfLocalSKU = irs.Count > 0 ? listOfLocalSKU.Substring(0, listOfLocalSKU.Length - 1) : "";
            return irs;
        }
        public static List<InventoryRecord> GetAllPerPerioud(DateTime DateFrom, DateTime DateTo)
        {
            List<InventoryRecord> irs = new List<InventoryRecord>();
            try
            {

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM POLog WHERE CretionDate >= @DateFrom And CretionDate <=@DateTo ORDER BY CretionDate DESC", Connection.DBConn);
                cmd.Parameters.AddWithValue("@DateFrom", DateFrom.ToString("dd/MM/yyyy h:mm:ss tt"));
                cmd.Parameters.AddWithValue("@DateTo", DateTo.ToString("dd/MM/yyyy h:mm:ss tt"));
                OleDbDataReader dr = cmd.ExecuteReader();
                InventoryRecord ir;
                while (dr.Read())
                {
                    ir = new InventoryRecord();
                    ir.ItemName = dr["ItemName"] == DBNull.Value ? "" : dr["ItemName"].ToString();
                    ir.SKU = dr["SKU"] == DBNull.Value ? "" : dr["SKU"].ToString();
                    ir.ReorderPoint = dr["ReorderPoint"] == DBNull.Value ? 0 : int.Parse(dr["ReorderPoint"].ToString());
                    ir.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                    ir.QuantityNeeded = dr["QuantityNeeded"] == DBNull.Value ? 0 : int.Parse(dr["QuantityNeeded"].ToString());
                    ir.QtyToOrder = dr["QtyToOrder"] == DBNull.Value ? 0 : int.Parse(dr["QtyToOrder"].ToString());
                    ir.QOH = dr["QOH"] == DBNull.Value ? 0 : int.Parse(dr["QOH"].ToString());
                    ir.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : dr["SupplierSKU"].ToString();
                    ir.CretionDate = dr["CretionDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CretionDate"].ToString());
                    ir.ISordered = dr["ISordered"] == DBNull.Value ? false : Convert.ToBoolean(dr["ISordered"].ToString());
                    ir.ExtendedCost = dr["ExtendedCost"] == DBNull.Value ? 0 : decimal.Parse(dr["ExtendedCost"].ToString());
                    ir.Backordered = dr["Backordered"] == DBNull.Value ? 0 : decimal.Parse(dr["Backordered"].ToString());
                    ir.SoldL24M = dr["SoldL24M"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldL24M"].ToString());
                    ir.ReorderQuantity = dr["ReorderQuantity"] == DBNull.Value ? 0 : int.Parse(dr["ReorderQuantity"].ToString());
                    ir.SoldYTD = dr["SoldYTD"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldYTD"].ToString());
                    ir.SoldLast30 = dr["SoldLast30"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast30"].ToString());
                    ir.SoldLast14 = dr["SoldLast14"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLast14"].ToString());
                    ir.OnOrder = dr["OnOrder"] == DBNull.Value ? 0 : decimal.Parse(dr["OnOrder"].ToString());
                    ir.Integer3 = dr["Integer3"] == DBNull.Value ? 0 : int.Parse(dr["Integer3"].ToString());
                    ir.Integer2 = dr["Integer2"] == DBNull.Value ? 0 : int.Parse(dr["Integer2"].ToString());
                    ir.Integer1 = dr["Integer1"] == DBNull.Value ? 0 : int.Parse(dr["Integer1"].ToString());
                    ir.Cost = dr["Cost"] == DBNull.Value ? 0 : decimal.Parse(dr["Cost"].ToString());
                    ir.HideCost = dr["HideCost"] == DBNull.Value ? 0 : decimal.Parse(dr["HideCost"].ToString());
                    ir.SoldLY = dr["SoldLY"] == DBNull.Value ? 0 : decimal.Parse(dr["SoldLY"].ToString());
                    ir.ISDeleted = dr["ISDeleted"] == DBNull.Value ? false : Convert.ToBoolean(dr["ISDeleted"].ToString());
                    ir.IsAuto = dr["IsAuto"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsAuto"].ToString());
                    ir.ISDeleted = dr["ISDeleted"] == DBNull.Value ? false : Convert.ToBoolean(dr["ISDeleted"].ToString());
                    ir.CreateType = ir.IsAuto ? "Automatically" : "Individually";
                    ir.CretionDate = dr["CretionDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CretionDate"]);
                    ir.Status = !ir.ISDeleted && !ir.ISordered ? "Pending" : ir.ISDeleted ? "Deleted" : "Ordered";
                    irs.Add(ir);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
                throw;
            }
            return irs;
        }
    }
    public class InventoryRecord
    {
        public InventoryRecord()
        {

        }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public int QOH { get; set; }
        public int OrderNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
        public decimal Price6 { get; set; }
        public decimal Price7 { get; set; }
        public decimal Price8 { get; set; }
        public decimal Price9 { get; set; }
        public decimal Price10 { get; set; }
        public string Location { get; set; }
        public string  SupplierSKU { get; set; }
        public int Integer1 { get; set; }
        public int Integer2 { get; set; }
        public int Integer3 { get; set; }
        public int Integer4 { get; set; }
        public int Integer5 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }

        //new properties. Added by M.Nasar 
        public string SupplierID { get; set; }
        public string ItemName { get; set; }        
        public int ReorderPoint { get; set; }
        public int ReorderQuantity { get; set; }
        public int QuantityNeeded { get; set; }
        public int QtyToOrder { get; set; }        
        public DateTime CretionDate { get; set; }
        public bool ISordered { get; set; }
        public bool ISDeleted { get; set; }
        public bool IsAuto { get; set; }
        public decimal Cost { get; set; }
        public decimal HideCost { get; set; }
        public decimal Backordered { get; set; }
        public decimal ExtendedCost { get; set; }
        public decimal OnOrder { get; set; }
        public decimal SoldLast14 { get; set; }
        public decimal SoldLast30 { get; set; }
        public decimal SoldYTD { get; set; }
        public decimal SoldLY { get; set; }
        public decimal SoldL24M { get; set; }
        public string CreateType { get; set; }
        public string Status { get; set; }

        public decimal Weight { get; set; }
        public decimal Actualweight { get; set; }
    }
    
}
