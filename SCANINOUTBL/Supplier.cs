using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SCANINOUTBL
{
    public class SupplierObj
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierSKU { get; set; }
        public string Terms { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ShippingMethod { get; set; }
        public string Fax { get; set; }
        public string Comments { get; set; }
        public string Instructions { get; set; }
        public bool Isordered { get; set; }
    }

    public class Supplier
    {
        static SqlConnection cn = Connection.GetConnection();
        public Supplier()
        {
            
        }
        

        public static SupplierObj GetByID(int SupplierID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers Where SupplierID = " + SupplierID.ToString(), cn);
            SqlDataReader dr = cmd.ExecuteReader();
            SupplierObj supplier = new SupplierObj();
            while (dr.Read())
            {
                supplier.SupplierID = SupplierID;
                supplier.SupplierName = dr["SupplierName"]== DBNull.Value?"":dr["SupplierName"].ToString();
                supplier.Address1 = dr["Address1"] == DBNull.Value ? "" : dr["Address1"].ToString();
                supplier.Address2 = dr["Address2"] == DBNull.Value ? "" : dr["Address2"].ToString();
                supplier.City = dr["City"] == DBNull.Value ? "" : dr["City"].ToString();
                supplier.State = dr["State"] == DBNull.Value ? "" : dr["State"].ToString();
                supplier.Zip = dr["Zip"] == DBNull.Value ? "" : dr["Zip"].ToString();
                supplier.Country = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString();
                supplier.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                supplier.Fax = dr["Fax"] == DBNull.Value ? "" : dr["Fax"].ToString();
                supplier.Phone = dr["Phone"] == DBNull.Value ? "" : dr["Phone"].ToString();
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return supplier;
        }

        public static List<SupplierObj> GetAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers ORDER BY SupplierName", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<SupplierObj> SupplierList = new List<SupplierObj>();
            while (dr.Read())
            {
                SupplierObj supplier = new SupplierObj();
                supplier.SupplierID = int.Parse(dr["SupplierID"].ToString());
                supplier.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : dr["SupplierName"].ToString();
                supplier.Address1 = dr["Address1"] == DBNull.Value ? "" : dr["Address1"].ToString();
                supplier.Address2 = dr["Address2"] == DBNull.Value ? "" : dr["Address2"].ToString();
                supplier.City = dr["City"] == DBNull.Value ? "" : dr["City"].ToString();
                supplier.State = dr["State"] == DBNull.Value ? "" : dr["State"].ToString();
                supplier.Zip = dr["Zip"] == DBNull.Value ? "" : dr["Zip"].ToString();
                supplier.Country = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString();
                supplier.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                supplier.Fax = dr["Fax"] == DBNull.Value ? "" : dr["Fax"].ToString();
                supplier.Phone = dr["Phone"] == DBNull.Value ? "" : dr["Phone"].ToString();
                SupplierList.Add(supplier);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return SupplierList;
        }
        public static List<SupplierObj> GetAllWithOpenPO()
        {
            SqlCommand cmd = new SqlCommand("SELECT s.* FROM Suppliers s WHERE s.SupplierID IN (SELECT p.SupplierID FROM PurchaseOrders p  WHERE p.DateClosed is null)  ORDER BY SupplierName", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<SupplierObj> SupplierList = new List<SupplierObj>();
            while (dr.Read())
            {
                SupplierObj supplier = new SupplierObj();
                supplier.SupplierID = int.Parse(dr["SupplierID"].ToString());
                supplier.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : dr["SupplierName"].ToString();
                supplier.Address1 = dr["Address1"] == DBNull.Value ? "" : dr["Address1"].ToString();
                supplier.Address2 = dr["Address2"] == DBNull.Value ? "" : dr["Address2"].ToString();
                supplier.City = dr["City"] == DBNull.Value ? "" : dr["City"].ToString();
                supplier.State = dr["State"] == DBNull.Value ? "" : dr["State"].ToString();
                supplier.Zip = dr["Zip"] == DBNull.Value ? "" : dr["Zip"].ToString();
                supplier.Country = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString();
                supplier.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                supplier.Fax = dr["Fax"] == DBNull.Value ? "" : dr["Fax"].ToString();
                supplier.Phone = dr["Phone"] == DBNull.Value ? "" : dr["Phone"].ToString();
                SupplierList.Add(supplier);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return SupplierList;
        }

        public static List<SupplierObj> GetSupplierNameAndID()
        {
            SqlCommand cmd = new SqlCommand("SELECT SupplierID,SupplierName FROM Suppliers ORDER BY SupplierName", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<SupplierObj> SupplierList = new List<SupplierObj>();
            while (dr.Read())
            {
                SupplierObj supplier = new SupplierObj();
                supplier.SupplierID = int.Parse(dr["SupplierID"].ToString());
                supplier.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : dr["SupplierName"].ToString();
                SupplierList.Add(supplier);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return SupplierList;
        }

        public List<SupplierObj> GetSupplierByListLocalSKU(string ListLocalSKU)
        {
            string SelectCommand = "select distinct s.SupplierID,s.SupplierName,s.Email,s.Phone,si.Terms,s.Address1,s.Country,s.City,s.[State],s.Zip from Suppliers s left join SupplierInfo si on s.SupplierID=si.SupplierID join InventorySuppliers isu on isu.SupplierID=s.SupplierID and isu.PrimarySupplier=1  and isu.LocalSKU in(" + ListLocalSKU + ")";
            SqlCommand cmd = new SqlCommand(SelectCommand, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<SupplierObj> suppliers = new List<SupplierObj>();
            while (dr.Read())
            {
                SupplierObj SupplierObj = new SupplierObj();
                SupplierObj.SupplierID = dr["SupplierID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SupplierID"].ToString());
                SupplierObj.SupplierName = dr["SupplierName"] == DBNull.Value ? "" : dr["SupplierName"].ToString();
                SupplierObj.Email = dr["Email"] == DBNull.Value ? "" : dr["Email"].ToString();
                SupplierObj.Phone = dr["Phone"] == DBNull.Value ? "" : dr["Phone"].ToString();
                SupplierObj.Terms = dr["Terms"] == DBNull.Value ? "" : dr["Terms"].ToString();
                SupplierObj.Address1 = dr["Address1"] == DBNull.Value ? "" : dr["Address1"].ToString();
                SupplierObj.Country = dr["Country"] == DBNull.Value ? "" : dr["Country"].ToString();
                SupplierObj.City = dr["City"] == DBNull.Value ? "" : dr["City"].ToString();
                SupplierObj.State = dr["State"] == DBNull.Value ? "" : dr["State"].ToString();
                SupplierObj.Zip = dr["Zip"] == DBNull.Value ? "" : dr["Zip"].ToString();
                SupplierObj.Isordered = true;
                suppliers.Add(SupplierObj);
            }
            dr.Close();
            dr.Dispose();
            dr = null;
            return suppliers;
        }
    }
}
