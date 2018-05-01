using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SCANINOUTBL
{
    public class POLogObj
    {
        public POLogObj()
        {
            POLogID = 0;
            SupplierID = 0;
            SupplierName = "";
            PONumber = 0;
            ItemNumber = 0;
            SKU = "";
            SupplierSKU = "";
            ItemName = "";
            Location = "";
            OrderNumber = 0;
            QtyReceived = 0;
            Cost = 0;
            Price = 0;
            Price2 = 0;
            Price3 = 0;
            QtyOrdered = 0;
            QtyRemaining = 0;
            IsUpdated = false;
            Text1 = "";
            Text2 = "";
            Text3 = "";
            Num1 = 0;
            Num2 = 0;
            Num3 = 0;
        }
        public int POLogID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int PONumber { get; set; }
        public int ItemNumber { get; set; }
        public string SKU { get; set; }
        public string SupplierSKU { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public int OrderNumber { get; set; }
        public int QtyReceived { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyRemaining { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsUpdated { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
    }
    public class POLog
    {
        static SqlConnection cn = Connection.GetConnection();
        public POLog()
        {
            
        }

        public static POLogObj GetByID(int POLogID)
        {
            POLogObj polog = new POLogObj();
            
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GPLPOLog Where POLogID = " + POLogID.ToString(), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    polog.POLogID = dr["POLogID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["POLogID"]);
                    polog.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierID"]);
                    polog.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
                    polog.PONumber = dr["PONumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PONumber"]);
                    polog.ItemNumber = dr["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemNumber"]);
                    polog.SKU = dr["SKU"] == DBNull.Value ? "" : Convert.ToString(dr["SKU"]);
                    polog.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierSKU"]);
                    polog.ItemName = dr["ItemName"] == DBNull.Value ? "" : Convert.ToString(dr["ItemName"]);
                    polog.Location = dr["Location"] == DBNull.Value ? "" : Convert.ToString(dr["Location"]);
                    polog.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderNumber"]);
                    polog.QtyReceived = dr["QtyReceived"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyReceived"]);
                    polog.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    polog.Price = dr["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price"]);
                    polog.Price2 = dr["Price2"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price2"]);
                    polog.Price3 = dr["Price3"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price3"]);
                    polog.QtyOrdered = dr["QtyOrdered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyOrdered"]);
                    polog.QtyRemaining = dr["QtyRemaining"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyRemaining"]);
                    polog.CreationDate = dr["CreationDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreationDate"]);
                    polog.Text1 = dr["Text1"] == DBNull.Value ? "" : Convert.ToString(dr["Text1"]);
                    polog.Text2 = dr["Text2"] == DBNull.Value ? "" : Convert.ToString(dr["Text2"]);
                    polog.Text3 = dr["Text3"] == DBNull.Value ? "" : Convert.ToString(dr["Text3"]);
                    polog.Num1 = dr["Num1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num1"]);
                    polog.Num2 = dr["Num2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num2"]);
                    polog.Num3 = dr["Num3"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num3"]);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
            }
            finally
            {
                
            }
            return polog;
        }
        public static List<POLogObj> GetAll(int SupplierID)
        {
            List<POLogObj> pologlist = new List<POLogObj>();
            
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GPLPOLog Where SupplierID = " + SupplierID.ToString(), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    POLogObj polog = new POLogObj();
                    polog.POLogID = dr["POLogID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["POLogID"]);
                    polog.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierID"]);
                    polog.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
                    polog.PONumber = dr["PONumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PONumber"]);
                    polog.ItemNumber = dr["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemNumber"]);
                    polog.SKU = dr["SKU"] == DBNull.Value ? "" : Convert.ToString(dr["SKU"]);
                    polog.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierSKU"]);
                    polog.ItemName = dr["ItemName"] == DBNull.Value ? "" : Convert.ToString(dr["ItemName"]);
                    polog.Location = dr["Location"] == DBNull.Value ? "" : Convert.ToString(dr["Location"]);
                    polog.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderNumber"]);
                    polog.QtyReceived = dr["QtyReceived"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyReceived"]);
                    polog.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    polog.Price = dr["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price"]);
                    polog.Price2 = dr["Price2"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price2"]);
                    polog.Price3 = dr["Price3"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price3"]);
                    polog.QtyOrdered = dr["QtyOrdered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyOrdered"]);
                    polog.QtyRemaining = dr["QtyRemaining"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyRemaining"]);
                    polog.CreationDate = dr["CreationDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreationDate"]);
                    polog.Text1 = dr["Text1"] == DBNull.Value ? "" : Convert.ToString(dr["Text1"]);
                    polog.Text2 = dr["Text2"] == DBNull.Value ? "" : Convert.ToString(dr["Text2"]);
                    polog.Text3 = dr["Text3"] == DBNull.Value ? "" : Convert.ToString(dr["Text3"]);
                    polog.Num1 = dr["Num1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num1"]);
                    polog.Num2 = dr["Num2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num2"]);
                    polog.Num3 = dr["Num3"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num3"]);
                    pologlist.Add(polog);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
            }
            finally
            {
                
            }
            return pologlist;
        }
        public static List<POLogObj> GetAll(int SupplierID, int PONumber)
        {
            List<POLogObj> pologlist = new List<POLogObj>();
            
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GPLPOLog Where SupplierID = " + SupplierID.ToString() + " AND PONumber = " + PONumber.ToString(), cn);
                SqlDataReader dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    POLogObj polog = new POLogObj();
                    polog.POLogID = dr["POLogID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["POLogID"]);
                    polog.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierID"]);
                    polog.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
                    polog.PONumber = dr["PONumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PONumber"]);
                    polog.ItemNumber = dr["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemNumber"]);
                    polog.SKU = dr["SKU"] == DBNull.Value ? "" : Convert.ToString(dr["SKU"]);
                    polog.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierSKU"]);
                    polog.ItemName = dr["ItemName"] == DBNull.Value ? "" : Convert.ToString(dr["ItemName"]);
                    polog.Location = dr["Location"] == DBNull.Value ? "" : Convert.ToString(dr["Location"]);
                    polog.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderNumber"]);
                    polog.QtyReceived = dr["QtyReceived"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyReceived"]);
                    polog.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    polog.Price = dr["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price"]);
                    polog.Price2 = dr["Price2"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price2"]);
                    polog.Price3 = dr["Price3"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price3"]);
                    polog.QtyOrdered = dr["QtyOrdered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyOrdered"]);
                    polog.QtyRemaining = dr["QtyRemaining"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyRemaining"]);
                    polog.CreationDate = dr["CreationDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreationDate"]);
                    polog.Text1 = dr["Text1"] == DBNull.Value ? "" : Convert.ToString(dr["Text1"]);
                    polog.Text2 = dr["Text2"] == DBNull.Value ? "" : Convert.ToString(dr["Text2"]);
                    polog.Text3 = dr["Text3"] == DBNull.Value ? "" : Convert.ToString(dr["Text3"]);
                    polog.Num1 = dr["Num1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num1"]);
                    polog.Num2 = dr["Num2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num2"]);
                    polog.Num3 = dr["Num3"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num3"]);
                    pologlist.Add(polog);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
            }
            finally
            {
                
            }
            return pologlist;
        }
        public static List<POLogObj> GetAll()
        {
            List<POLogObj> pologlist = new List<POLogObj>();
            
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GPLPOLog ", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    POLogObj polog = new POLogObj();
                    polog.POLogID = dr["POLogID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["POLogID"]);
                    polog.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierID"]);
                    polog.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierName"]);
                    polog.PONumber = dr["PONumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PONumber"]);
                    polog.ItemNumber = dr["ItemNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemNumber"]);
                    polog.SKU = dr["SKU"] == DBNull.Value ? "" : Convert.ToString(dr["SKU"]);
                    polog.SupplierSKU = dr["SupplierSKU"] == DBNull.Value ? "" : Convert.ToString(dr["SupplierSKU"]);
                    polog.ItemName = dr["ItemName"] == DBNull.Value ? "" : Convert.ToString(dr["ItemName"]);
                    polog.Location = dr["Location"] == DBNull.Value ? "" : Convert.ToString(dr["Location"]);
                    polog.OrderNumber = dr["OrderNumber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OrderNumber"]);
                    polog.QtyReceived = dr["QtyReceived"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyReceived"]);
                    polog.Cost = dr["Cost"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Cost"]);
                    polog.Price = dr["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price"]);
                    polog.Price2 = dr["Price2"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price2"]);
                    polog.Price3 = dr["Price3"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Price3"]);
                    polog.QtyOrdered = dr["QtyOrdered"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyOrdered"]);
                    polog.QtyRemaining = dr["QtyRemaining"] == DBNull.Value ? 0 : Convert.ToInt32(dr["QtyRemaining"]);
                    polog.CreationDate = dr["CreationDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CreationDate"]);
                    polog.Text1 = dr["Text1"] == DBNull.Value ? "" : Convert.ToString(dr["Text1"]);
                    polog.Text2 = dr["Text2"] == DBNull.Value ? "" : Convert.ToString(dr["Text2"]);
                    polog.Text3 = dr["Text3"] == DBNull.Value ? "" : Convert.ToString(dr["Text3"]);
                    polog.Num1 = dr["Num1"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num1"]);
                    polog.Num2 = dr["Num2"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num2"]);
                    polog.Num3 = dr["Num3"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Num3"]);
                    pologlist.Add(polog);
                }
                dr.Close();
                dr.Dispose();
                dr = null;
            }
            catch (Exception)
            {
            }
            finally
            {
                
            }
            return pologlist;
        }

        public static bool Insert(POLogObj polog)
        {
            string InsertCommand = "INSERT INTO GPLPOLog " +
                                   "( SupplierID, SupplierName, PONumber, ItemNumber, SKU, SupplierSKU, ItemName, Location, OrderNumber, QtyReceived, Cost, Price, Price2, Price3, QtyOrdered, QtyRemaining, CreationDate, IsUpdated, Text1, Text2, Text3, Num1, Num2, Num3) " +
                                   "VALUES " +
                                   "(@SupplierID,@SupplierName,@PONumber,@ItemNumber,@SKU,@SupplierSKU,@ItemName,@Location,@OrderNumber,@QtyReceived,@Cost,@Price,@Price2,@Price3,@QtyOrdered,@QtyRemaining,@CreationDate,@IsUpdated,@Text1,@Text2,@Text3,@Num1,@Num2,@Num3) " ;
            SqlCommand cmd = new SqlCommand(InsertCommand, cn);
            cmd.Parameters.AddWithValue("@SupplierID",polog.SupplierID);
            cmd.Parameters.AddWithValue("@SupplierName",polog.SupplierName);
            cmd.Parameters.AddWithValue("@PONumber",polog.PONumber);
            cmd.Parameters.AddWithValue("@ItemNumber",polog.ItemNumber);
            cmd.Parameters.AddWithValue("@SKU",polog.SKU);
            cmd.Parameters.AddWithValue("@SupplierSKU",polog.SupplierSKU);
            cmd.Parameters.AddWithValue("@ItemName",polog.ItemName);
            cmd.Parameters.AddWithValue("@Location",polog.Location);
            cmd.Parameters.AddWithValue("@OrderNumber",polog.OrderNumber);
            cmd.Parameters.AddWithValue("@QtyReceived",polog.QtyReceived);
            cmd.Parameters.AddWithValue("@Cost",polog.Cost);
            cmd.Parameters.AddWithValue("@Price",polog.Price);
            cmd.Parameters.AddWithValue("@Price2",polog.Price2);
            cmd.Parameters.AddWithValue("@Price3",polog.Price3);
            cmd.Parameters.AddWithValue("@QtyOrdered",polog.QtyOrdered);
            cmd.Parameters.AddWithValue("@QtyRemaining",polog.QtyRemaining);
            cmd.Parameters.AddWithValue("@CreationDate",DateTime.Now);
            cmd.Parameters.AddWithValue("@IsUpdated",polog.IsUpdated);
            cmd.Parameters.AddWithValue("@Text1",polog.Text1);
            cmd.Parameters.AddWithValue("@Text2",polog.Text2);
            cmd.Parameters.AddWithValue("@Text3",polog.Text3);
            cmd.Parameters.AddWithValue("@Num1",polog.Num1);
            cmd.Parameters.AddWithValue("@Num2",polog.Num2);
            cmd.Parameters.AddWithValue("@Num3",polog.Num3);
            try
            {
                int EffRowsCount = cmd.ExecuteNonQuery();
                if (EffRowsCount > 0)
                {
                    cmd.CommandText = "SELECT Ident_Current('GPLPOLog')";
                    polog.POLogID = Convert.ToInt32(cmd.ExecuteScalar());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public static bool Update(int POLogID)
        {
            SqlCommand cmd = new SqlCommand("UPDATE GPLPOLog Set IsUpdated = 'true' WHERE POLogID = " + POLogID, cn);
            int effrowscount = cmd.ExecuteNonQuery();
            if (effrowscount>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
