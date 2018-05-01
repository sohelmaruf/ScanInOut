using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace SCANINOUTBL
{
    public class DataLog
    {
        OleDbConnection cn;
        public string LogKeyIN,LogKeyOUT;
        public DataLog()
        {
            try
            {
                FileInfo f = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DataLog.mdb");
                if (f.Exists)
                {
                    cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + f.FullName + ";");
                    cn.Open();
                }
                else
                {
                    FileInfo fn = new FileInfo("DataLog.mdb");
                    fn.CopyTo(f.FullName);
                    cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + f.FullName + ";");
                    cn.Open();
                }
            }
            catch (Exception)
            {
                                
            }            
        }
        public void AddToLog(InventoryRecord IR, string TrType)
        {
            if (string.IsNullOrEmpty(LogKeyIN) && TrType=="IN")
            {
                LogKeyIN = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString();
            }
            if (string.IsNullOrEmpty(LogKeyOUT) && TrType == "OUT")
            {
                LogKeyOUT = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString();
            }
            OleDbCommand Cmd = new OleDbCommand("insert into [Log](SKU,Barcode,ProductName,QOH,OrderNumber,Quantity,Price,Price3,Location,OrderID,[Status],LogType) values('" + IR.SKU + "','" + IR.Barcode + "','" + IR.ProductName + "','" + IR.QOH + "','" + IR.OrderNumber + "','1','" + IR.Price + "','" + IR.Price3 + "','" + IR.Location + "','" + (TrType == "IN"?LogKeyIN:LogKeyOUT) + "','false','"+TrType+"')", cn);
            Cmd.ExecuteNonQuery();

        }
        public void SubmiteLog(string TrType)
        {

            OleDbCommand Cmd = new OleDbCommand("update [Log] set  [Status]='true'where OrderID='" + (TrType == "IN" ? LogKeyIN : LogKeyOUT )+ "'", cn);
            Cmd.ExecuteNonQuery();
            if (TrType == "IN")
            {
                LogKeyIN = null;
            }
            else
            {
                LogKeyOUT = null;
            
            }

        }
        public void UpdateLog(InventoryRecord IR, string TrType)
        {

            OleDbCommand Cmd = new OleDbCommand("update [Log] set Quantity="+ IR.Quantity+" where OrderID='" + (TrType == "IN" ? LogKeyIN : LogKeyOUT) + "' And SKU ='" + IR.SKU + "' And LogType='" + TrType + "'", cn);
            Cmd.ExecuteNonQuery();

        }
        public  void RemoveFromLog(string LogKey)
        {
            OleDbCommand Cmd = new OleDbCommand("delete from [Log] where OrderID='" +LogKey +"'", cn);
            Cmd.ExecuteNonQuery();

        }

        public DataTable GetLogsbyOrderID(string OrderID)
        {

            OleDbCommand Cmd = new OleDbCommand("select SKU,Barcode,ProductName,QOH,OrderNumber,Quantity,Price,Price3,Location,OrderID,[Status],LogType from [log] where OrderID='" + OrderID + "' ORDER BY ID DESC ", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;

        }

        public DataTable GetLogs()
        {
            DataTable dt = new DataTable();
            try
            {
                OleDbCommand Cmd = new OleDbCommand("select SKU,Barcode,ProductName,QOH,OrderNumber,Quantity,Price,Price3,Location,OrderID,[Status],LogType from [log] ORDER BY ID DESC", cn);
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
                
                da.Fill(dt);
                da.Dispose();
                
            }
            catch (Exception)
            {
                
                
            }
            return dt;

        }
        public DataTable GetLogsOrderID()
        {

            OleDbCommand Cmd = new OleDbCommand("select OrderID as OrderID,MAX(ID) as IDD from [log] GROUP BY OrderID ORDER BY MAX(ID) DESC", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                
            }
            catch (Exception)
            {
                
                
            }
            
            da.Dispose();
            return dt;

        }
    }
}
