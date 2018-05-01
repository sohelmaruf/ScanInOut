using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScanINOUTVer2
{
    public partial class frmCustomizeColumnsIN : Form
    {
        public string mode;
        public List<clm> clms;
        public List<clmprop> clmprops;
        public frmCustomizeColumnsIN()
        {
            InitializeComponent();
            clmprops = new List<clmprop>();
            clmprops.Add(new clmprop("ProductName", "Column5"));
            clmprops.Add(new clmprop("Barcode", "Column2"));
            clmprops.Add(new clmprop("SKU", "Column3"));
            clmprops.Add(new clmprop("Price", "Column6"));
            clmprops.Add(new clmprop("QOH", "Column13"));
            clmprops.Add(new clmprop("SupplierSKU", "Column4"));
            clmprops.Add(new clmprop("Price2", "Column14"));
            clmprops.Add(new clmprop("Price3", "Column15"));
            clmprops.Add(new clmprop("Price4", "Column16"));
            clmprops.Add(new clmprop("Price5", "Column17"));
            clmprops.Add(new clmprop("Price6", "Column18"));
            clmprops.Add(new clmprop("Price7", "Column19"));
            clmprops.Add(new clmprop("Price8", "Column20"));
            clmprops.Add(new clmprop("Price9", "Column21"));
            clmprops.Add(new clmprop("Price10", "Column22"));
            clmprops.Add(new clmprop("Location", "Column23"));
            clmprops.Add(new clmprop("OrderNumber", "Column12"));
            clmprops.Add(new clmprop("Weight", "Column24"));
            clmprops.Add(new clmprop("ReorderPoint", "Column25"));
            clmprops.Add(new clmprop("Backordered", "Column26"));
            clmprops.Add(new clmprop("ActualWeight", "Column27"));
            clmprops.Add(new clmprop("Text1", "Column28"));
            clmprops.Add(new clmprop("Text2", "Column29"));
            clmprops.Add(new clmprop("Text3", "Column30"));
            clmprops.Add(new clmprop("Text4", "Column31"));
            clmprops.Add(new clmprop("Text5", "Column32"));
            clmprops.Add(new clmprop("Integer1", "Column33"));
            clmprops.Add(new clmprop("Integer2", "Column34"));
            clmprops.Add(new clmprop("Integer3", "Column35"));
            clmprops.Add(new clmprop("Integer4", "Column36"));
            clmprops.Add(new clmprop("Integer5", "Column37"));            
        }

        private void frmCustomizeColumnsIN_Load(object sender, EventArgs e)
        {            
            
            if (mode == "IN")
            {
                FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt");
                if (fi.Exists)
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    clms = new List<clm>();
                    while (!sr.EndOfStream)
                    {
                        string x = sr.ReadLine().Trim();
                        clm c = new clm();
                        c.clmname = x.Split('^')[0];
                        int n = 100;
                        int.TryParse(x.Split('^')[1],out n);
                        c.clmwidth = n;
                        if (x.Split('^').Length >= 3)
                        {
                            clmprop cp = clmprops.FirstOrDefault<clmprop>(m => m.clmValue.Trim().ToLower() == x.Split('^')[0].Trim().ToLower());
                            if (cp == null)
                            {
                                continue;
                            }
                            int k = checkedListBox1.Items.IndexOf(cp.clmName);
                            if (k < 0) continue;                            
                            bool b = true;
                            bool.TryParse(x.Split('^')[2], out b);
                            c.clmvisible = b;
                            checkedListBox1.SetItemChecked(k, b);
                            if (x.Split('^').Length == 4) c.clmtext = x.Split('^')[3];
                        }
                        clms.Add(c);
                    }
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
                else
                {

                }                
            }
            else if (mode == "OUT")
            {
                FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt");
                if (fi.Exists)
                {
                    StreamReader sr = new StreamReader(fi.FullName);
                    clms = new List<clm>();
                    while (!sr.EndOfStream)
                    {
                        string x = sr.ReadLine().Trim();
                        clm c = new clm();
                        c.clmname = x.Split('^')[0];
                        int n = 100;
                        int.TryParse(x.Split('^')[1], out n);
                        c.clmwidth = n;
                        if (x.Split('^').Length >= 3)
                        {
                            clmprop cp = clmprops.FirstOrDefault<clmprop>(m => m.clmValue.Trim().ToLower() == x.Split('^')[0].Trim().ToLower());
                            if (cp == null)
                            {
                                continue;
                            }
                            int k = checkedListBox1.Items.IndexOf(cp.clmName);
                            if (k < 0) continue;
                            bool b = true;
                            bool.TryParse(x.Split('^')[2], out b);
                            c.clmvisible = b;
                            checkedListBox1.SetItemChecked(k, b);
                            if (x.Split('^').Length == 4) c.clmtext = x.Split('^')[3];
                        }
                        clms.Add(c);
                    }
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
                else
                {

                } 
            }
            
        }

        private void frmCustomizeColumnsIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (mode == "IN")
                {
                    FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt");
                    //if (!fi.Exists)
                    //{
                    //    fi.Create();
                    //}
                    StreamWriter sw = new StreamWriter(fi.FullName, false);
                    sw.Flush();
                    
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        clmprop cp = clmprops.FirstOrDefault<clmprop>(m => m.clmName.Trim().ToLower() == checkedListBox1.Items[i].ToString().Trim().ToLower());
                        if (cp != null)
                        {
                            if (clms == null)
                            {
                                sw.WriteLine(cp.clmValue + "^100^" + checkedListBox1.GetItemChecked(i).ToString());
                                continue;
                            }
                            clm c = clms.FirstOrDefault<clm>(m => m.clmname.ToLower().Trim() == cp.clmValue.ToLower().Trim());
                            if (c != null)
                            {
                                sw.WriteLine(c.clmname + "^" + c.clmwidth + "^" + checkedListBox1.GetItemChecked(i).ToString() + (string.IsNullOrWhiteSpace(c.clmtext)?"":"^" + c.clmtext));
                            }
                            else
                            {
                                sw.WriteLine(cp.clmValue + "^100^" + checkedListBox1.GetItemChecked(i).ToString());
                            }
                        }
                        
                    }

                    sw.WriteLine("Column1^38^True");
                    sw.WriteLine("Colmun7^59^True");
                    sw.WriteLine("Colmun8^39^True");
                    sw.WriteLine("Colmun9^59^True");
                    sw.WriteLine("Colmun10^69^True");
                    sw.WriteLine("Colmun11^47^True");
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
                else if (mode == "OUT")
                {
                    FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt");
                    //if (!fi.Exists)
                    //{
                    //    fi.Create();
                    //}
                    StreamWriter sw = new StreamWriter(fi.FullName, false);
                    sw.Flush();
                    
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        clmprop cp = clmprops.FirstOrDefault<clmprop>(m => m.clmName.Trim().ToLower() == checkedListBox1.Items[i].ToString().Trim().ToLower());
                        if (cp != null)
                        {
                            if (clms == null)
                            {
                                sw.WriteLine(cp.clmValue + "^100^" + checkedListBox1.GetItemChecked(i).ToString());
                                continue;
                            }
                            clm c = clms.FirstOrDefault<clm>(m => m.clmname.ToLower().Trim() == cp.clmValue.ToLower().Trim());
                            if (c != null)
                            {
                                sw.WriteLine(c.clmname + "^" + c.clmwidth + "^" + checkedListBox1.GetItemChecked(i).ToString() + (string.IsNullOrWhiteSpace(c.clmtext) ? "" : "^" + c.clmtext));
                            }
                            else
                            {
                                sw.WriteLine(cp.clmValue + "^100^" + checkedListBox1.GetItemChecked(i).ToString());
                            }
                        }
                        
                    }

                    sw.WriteLine("Column1^38^True");
                    sw.WriteLine("Colmun7^59^True");
                    sw.WriteLine("Colmun8^39^True");
                    sw.WriteLine("Colmun9^59^True");
                    sw.WriteLine("Colmun10^69^True");
                    sw.WriteLine("Colmun11^47^True");
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnChangeHeader_Click(object sender, EventArgs e)
        {
            frmChangeColumnHeader f = new frmChangeColumnHeader();
            clmprop cp = clmprops.FirstOrDefault(m => m.clmName == checkedListBox1.SelectedItem.ToString());
            if (cp != null && string.IsNullOrWhiteSpace(cp.clmValue) == false)
            {
                f.c = clms.FirstOrDefault(n => n.clmname == cp.clmValue);
            }
            else
            {
                f.c = new clm();
            }
            f.ShowDialog();
        }
    }
    public class clmprop
    {
        public clmprop(string n,string v)
        {
            clmName = n;
            clmValue = v;
        }
        public string clmName { get; set; }
        public string clmValue { get; set; }
    }
    public class clm
    {
        public string clmname { get; set; }
        public int clmwidth { get; set; }
        public bool clmvisible { get; set; }
        public string clmtext { get; set; }
    }
}
