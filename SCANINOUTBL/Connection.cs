using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace SCANINOUTBL
{
    public class Connection
    {

        private static OleDbConnection _DBConn;
        public static OleDbConnection DBConn
        {
            get
            {
                if (_DBConn == null)
                {
                    _DBConn = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\SIO\\DataLog.mdb"));
                    try
                    {
                        System.IO.FileInfo f = new System.IO.FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\.NETFramework,Version=v4.0.AssemblyAttributes.cpp");
                        if (f.Exists) f.Delete();
                        _DBConn.Open();
                        if (_DBConn.State != System.Data.ConnectionState.Open)
                        {
                            throw new Exception("Can't Connect to the Application Database. Please Contact The Admin");
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Can't Connect to the Application Database. Please Contact The Admin or try to restart the application.");

                    }

                }
                else
                {
                    if (_DBConn.State != System.Data.ConnectionState.Open)
                    {
                        try
                        {
                            _DBConn.Open();
                        }
                        catch (Exception)
                        {
                            throw new Exception("Can't Connect to the Application Database. Please Contact The Admin");
                        }

                    }
                }
                return _DBConn;
            }
        }

        static SqlConnection PrimaryConn;
        public static bool HasConnection()
        {
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconn.txt");
            if (fi.Exists)
            {
                try
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    SqlConnection cn = new SqlConnection(sr.ReadToEnd());
                    sr.Close();
                    cn.Open();
                    
                    return true;
                }
                catch (Exception)
                {
                    return false;                    
                }                
            }
            else
            {
                return false;
            }
        }
        public static void SetConnection(string ConnectionString)
        {                        
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconn.txt",false);
            sw.Write(ConnectionString);
            sw.Close();
        }
        public static SqlConnection GetConnection()
        {
            if (PrimaryConn != null)
            {
                if (PrimaryConn.State == ConnectionState.Open)
                {
                    return PrimaryConn;
                }
                else
                {
                    PrimaryConn.Open();
                    return PrimaryConn;
                }
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI");
                if (!di.Exists)
                {
                    di.Create();
                }

                StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconn.txt");
                string connstring = sr.ReadToEnd();
                sr.Close();
                PrimaryConn = new SqlConnection(connstring);
                PrimaryConn.Open();

                return PrimaryConn;
            }
            
        }
    }
}
