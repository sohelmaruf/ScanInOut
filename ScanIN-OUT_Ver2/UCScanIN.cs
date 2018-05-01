using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SCANINOUTBL;
using GenCode128;

namespace ScanINOUTVer2
{
    public partial class UCScanIN : UserControl
    {
        public bool IsRestore = false;
        public Form1 frmMain;
        public UCScanIN()
        {
            InitializeComponent();
        }

        //private void dataGridView1_SizeChanged(object sender, EventArgs e)
        //{            
        //    if (dgvIN.Width == 0)
        //    {
        //        return;
        //    }
        //    int xl = 0;
        //    foreach (Control item in this.Controls)
        //    {
        //        if (item.Name.Contains("lblclm"))
        //        {
        //            xl += item.Width;
        //        }
                
        //    }
            
        //    int x = (dgvIN.Width - xl) / 12;
            
        //    for (int i = 1; i < dgvIN.Columns.Count; i++)
        //    {
        //        Label l = (Label)this.Controls["lblclm" + (i-1).ToString()];
        //        l.Width = l.Width + x;
        //        l.Left += (i-1) * x;
        //        dgvIN.Columns[i].Width = l.Width -1 ;
        //    }
            
        //}

        private void UCScanIN_Load(object sender, EventArgs e)
        {
            dgvIN.Width =0;
            dgvIN.Width = 931;

            HeardersName();

            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine().Trim();
                    if (dgvIN.Columns.Contains(x.Split('^')[0]))
                    {
                        dgvIN.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);
                        if (x.Split('^').Length >= 3)
                        {
                            dgvIN.Columns[x.Split('^')[0]].Visible = bool.Parse(x.Split('^')[2]);
                            if (x.Split('^').Length == 4) dgvIN.Columns[x.Split('^')[0]].HeaderText = x.Split('^')[3];
                        }
                        else
                        {
                            dgvIN.Columns[x.Split('^')[0]].Visible = true;
                        }
                    }

                }
                sr.Close();
                sr.Dispose();
                sr = null;
                icc++;
            }
        }
        public void HeardersName()
        {
            FileInfo fhnin = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNIN.txt");
            if (fhnin.Exists)
            {
                StreamReader sr = new StreamReader(fhnin.FullName);                
                Column1.HeaderText = sr.ReadLine();
                Column2.HeaderText = sr.ReadLine();
                Column3.HeaderText = sr.ReadLine();
                Column4.HeaderText = sr.ReadLine();
                Column5.HeaderText = sr.ReadLine();
                Column6.HeaderText = sr.ReadLine();
                Column7.HeaderText = sr.ReadLine();
                Column8.HeaderText = sr.ReadLine();
                Column9.HeaderText = sr.ReadLine();
                Column10.HeaderText = sr.ReadLine();
                Column11.HeaderText = sr.ReadLine();
                Column12.HeaderText = sr.ReadLine();

                sr.Close();

            }
        }

        private void cbPrintAllBarcodes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrintAllBarcodes.Checked)
            {
                btnINUpdate.Text = "Update&&Print barcodes";
            }
            else
            {
                btnINUpdate.Text = "Update";
            }
        }

        private void barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 126)
            {
                txtINBarcode.Focus();

            }
            
        }

        private void btnINCLS_Click(object sender, EventArgs e)
        {
            if (dgvIN.Rows.Count > 0)
            {
                if (dgvIN.Rows[dgvIN.Rows.Count - 1].Cells["Column7"].Value.ToString() == "1")
                {
                    dgvIN.Rows.RemoveAt(dgvIN.Rows.Count - 1);
                    frmMain.IL.RemoveAt(frmMain.IL.Count - 1);
                    txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - 1).ToString();
                    txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) - 1).ToString();
                }
                else
                {
                    frmMain.IL[frmMain.IL.Count - 1].Quantity = frmMain.IL[frmMain.IL.Count - 1].Quantity - 1;
                    dgvIN.Rows[dgvIN.Rows.Count - 1].Cells["Column7"].Value = int.Parse(dgvIN.Rows[dgvIN.Rows.Count - 1].Cells["Column7"].Value.ToString()) - 1;
                    txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - 1).ToString();
                    frmMain.datalogObj.UpdateLog(frmMain.IL[frmMain.IL.Count - 1], "IN");
                }
            }
        }                       

        void c_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            
            if (t.Text.Contains('~'))
            {
                t.Text=   t.Text.Replace("~", "");
                txtINBarcode.Focus();                
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                
                DataGridViewTextBoxEditingControl c = (DataGridViewTextBoxEditingControl)e.Control;
                c.TextChanged += new EventHandler(c_TextChanged);
            }
            catch (Exception)
            {
                DataGridViewComboBoxEditingControl cb = (DataGridViewComboBoxEditingControl)e.Control;
                
                cb.KeyPress += new KeyPressEventHandler(cb_KeyPress);
                
            }
            
        }

        void cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 126)
            {
                txtINBarcode.Focus();

            } 
        }
        public bool GetDataIN()
        {
            string res = "";
            string sku, barcode;
            sku = txtINSKU.Text;
            barcode = txtINBarcode.Text;

            if (sku.Contains('~'))
            {
                sku = sku.Substring(sku.IndexOf('~'), sku.Length - sku.IndexOf('~'));

            }
            if (sku.Contains('/'))
            {
                sku = sku.Remove(sku.IndexOf('/'), sku.Length - sku.IndexOf('/'));
            }

            if (barcode.Contains('~'))
            {
                barcode = barcode.Substring(barcode.IndexOf('~'), barcode.Length - barcode.IndexOf('~'));

            }
            if (barcode.Contains('/'))
            {
                barcode = barcode.Remove(barcode.IndexOf('/'), barcode.Length - barcode.IndexOf('/'));
            }


            InventoryRecord ir = frmMain.inventory.GetData(sku.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), barcode.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), ref res);
            if (frmMain.IL.Find(x => x.SKU == ir.SKU) != null)
            {
                int o = frmMain.IL.FindIndex(x => x.SKU == ir.SKU);
                frmMain.IL[o].Quantity += 1;
                dgvIN.Rows[o].Cells["Column7"].Value = int.Parse(dgvIN.Rows[o].Cells["Column7"].Value.ToString()) + 1;

                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    frmMain.datalogObj.UpdateLog(frmMain.IL[o], "IN");
                }
                return true;
            }
            if (res == "0")
            {
                dgvIN.Rows.Add();
                ir.Quantity = 1;
                frmMain.IL.Add(ir);
                DataGridViewRow r = dgvIN.Rows[dgvIN.Rows.Count - 1];
                r.Cells["Column2"].Value = ir.Barcode;
                r.Cells["Column3"].Value = ir.SKU;
                r.Cells["Column4"].Value = ir.SupplierSKU;
                r.Cells["Column5"].Value = ir.ProductName;
                r.Cells["Column6"].Value = Math.Round(ir.Price, 2);
                r.Cells["Column7"].Value = 1;
                r.Cells["Column1"].Value = dgvIN.Rows.Count;

                r.Cells["Column13"].Value = ir.QOH;
                r.Cells["Column14"].Value = ir.Price2;
                r.Cells["Column15"].Value = ir.Price3;
                r.Cells["Column16"].Value = ir.Price4;
                r.Cells["Column17"].Value = ir.Price5;
                r.Cells["Column18"].Value = ir.Price6;
                r.Cells["Column19"].Value = ir.Price7;
                r.Cells["Column20"].Value = ir.Price8;
                r.Cells["Column21"].Value = ir.Price9;
                r.Cells["Column22"].Value = ir.Price10;
                r.Cells["Column23"].Value = ir.Location;
                r.Cells["Column24"].Value = ir.Weight;
                r.Cells["Column25"].Value = ir.ReorderPoint;
                r.Cells["Column26"].Value = ir.Backordered;
                r.Cells["Column27"].Value = ir.Actualweight;
                r.Cells["Column28"].Value = ir.Text1;
                r.Cells["Column29"].Value = ir.Text2;
                r.Cells["Column30"].Value = ir.Text3;
                r.Cells["Column31"].Value = ir.Text4;
                r.Cells["Column32"].Value = ir.Text5;
                r.Cells["Column33"].Value = ir.Integer1;
                r.Cells["Column34"].Value = ir.Integer2;
                r.Cells["Column35"].Value = ir.Integer3;
                r.Cells["Column36"].Value = ir.Integer4;
                r.Cells["Column37"].Value = ir.Integer5;

                FileInfo dpf = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPF.txt");
                if (dpf.Exists)
                {
                    StreamReader sr = new StreamReader(dpf.FullName);
                    string xx = sr.ReadToEnd().Trim();
                    sr.Close();
                    r.Cells["Column10"].Value = xx;

                }
                else
                {
                    r.Cells["Column10"].Value = "BarcodePrice";
                }
                
                if (ir.OrderNumber != 0)
                {
                    r.Cells["Column12"].Value = ir.OrderNumber;
                }

                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) + 1).ToString();
                txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    frmMain.datalogObj.AddToLog(ir, "IN");
                }

                //Creating Image for this barcode
                FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + ir.Barcode + ".jpg");
                if (!fi.Exists)
                {
                    Image i = Code128Rendering.MakeBarcodeImage(ir.Barcode,1,true);
                    i.Save(fi.FullName);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnINAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtINBarcode.Text + txtINSKU.Text))
            {
                MessageBox.Show("Please Scan Barcode or Insert SKU/Barcode First!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);               
                return;
            }

            if (GetDataIN())
            {
                if(!IsRestore)Console.Beep();                
                txtINBarcode.Text = "";
                txtINSKU.Text = "";
            }
            else
            {
                MessageBox.Show("Item Not Found!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtINBarcode.Text = "";
                txtINSKU.Text = "";
            }
   
        }

        private void txtINBarcode_TextChanged(object sender, EventArgs e)
        {

            TextBox t = (TextBox)sender;
            if (t.Text == "")
            {
                return;
            }
            if (t.Text.Contains('~') && t.Text.Contains('/'))
            {
                btnINAdd_Click(sender, e);
                t.Focus();
           
                return;
            }
            if (t.Name.Contains("SKU") && t.Text != "")
            {
                txtINBarcode.Text = "";
            }
            else if (t.Name.Contains("Barcode") && t.Text != "")
            {
                txtINSKU.Text = "";
            }
      
        }

        private void txtINBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tt = (TextBox)sender;
          
            if (e.KeyChar == 13 && tt.Text != "")
            {
                btnINAdd_Click(sender, e);
                tt.Focus();
            }
        }

        private void dgvIN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvIN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                try
                {
                    int x = 0;
                    if (!int.TryParse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out x) || dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("-"))
                    {
                        MessageBox.Show("Not Valid Quantity");
                        dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frmMain.IL[e.RowIndex].Quantity;
                        return;
                    }
                    if (frmMain.IL[e.RowIndex].Quantity != int.Parse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        frmMain.IL[e.RowIndex].Quantity = int.Parse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        txtINTotalSKU.Text = frmMain.IL.Sum(m => m.Quantity).ToString();
                        frmMain.datalogObj.UpdateLog(frmMain.IL[e.RowIndex], "IN");
                    }
                }
                catch (Exception)
                {

                    dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frmMain.IL[e.RowIndex].Quantity;
                }
                

            }
        }

        private void btnINCEL_Click(object sender, EventArgs e)
        {
            dgvIN.Rows.Clear();
            frmMain.IL.Clear();
            txtINTotalSKU.Text = "0";
            txtINTotalUSKU.Text = "0";
        }

        private void btnINUpdate_Click(object sender, EventArgs e)
        {
            if (frmMain.inventory.SaveList(frmMain.IL, "IN"))
            {
                //frmReceviedReport f = new frmReceviedReport();
                //f.IRlist = IL;
                //f.pn = comboBox1.Text;
                frmMain.datalogObj.SubmiteLog("IN");
                int x = 1;
                int q = 0;
                frmMain.receivedreport.ReportDataSet.Clear();
                foreach (InventoryRecord  item in frmMain.IL)
                {
                    ReportDataSet.InventoryRow r = frmMain.receivedreport.ReportDataSet.Inventory.NewInventoryRow();
                    r.Barcode = item.Barcode;
                    r.BarcodeImage = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + item.Barcode + ".jpg";
                    r.ID = x;
                    r.ItemName = item.ProductName;
                    r.Location = item.Location;
                    r.Price = "$" + Math.Round(item.Price,2).ToString();
                    r.Price3 = "$" + Math.Round(item.Price3, 2).ToString();
                    r.Qty = item.Quantity;
                    q += item.Quantity;
                    r.SKU = item.SKU;
                    r.OrderNumber = item.OrderNumber.ToString();
                    frmMain.receivedreport.ReportDataSet.Tables[0].Rows.Add(r);
                    x++;
                }                
                //frmMain.receivedreport.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtTQty",q.ToString()));
                frmMain.receivedreport.WindowState = FormWindowState.Normal;
                frmMain.receivedreport.StartPosition = FormStartPosition.CenterScreen;
                frmMain.receivedreport.reportViewer1.RefreshReport();

                frmMain.receivedreport.ShowDialog();
                if (btnINUpdate.Text == "Update&&Print barcodes")
                {
                    for (int i = 0; i < dgvIN.Rows.Count; i++)
                    {
                        dgvIN_CellClick(dgvIN, new DataGridViewCellEventArgs(Column9.Index,i));
                    }
                }
                btnINCEL_Click(sender, e);
            }
        }

        private void dgvIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column11.Index)
            {
                //cancel
                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - frmMain.IL[e.RowIndex].Quantity).ToString();
                txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) - 1).ToString();
                frmMain.IL.RemoveAt(e.RowIndex);
                dgvIN.Rows.RemoveAt(e.RowIndex);
                foreach (DataGridViewRow item in dgvIN.Rows)
                {
                    item.Cells["Column1"].Value = item.Index + 1;
                }
            }



            if (e.ColumnIndex == Column8.Index)
            {
                //print

                //frmPrintIN f = new frmPrintIN();
                //f.Barcode = dgvIN.Rows[e.RowIndex].Cells[clmINBarCode.Name].Value.ToString();
                //f.SKU = dgvIN.Rows[e.RowIndex].Cells[clmINSKU.Name].Value.ToString();
                //f.Price = dgvIN.Rows[e.RowIndex].Cells[clmINPrice.Name].Value.ToString();
                //f.ItemName = dgvIN.Rows[e.RowIndex].Cells[clmINItemName.Name].Value.ToString();

                //f.ShowDialog();

                string Barcode = dgvIN.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                string SKU = dgvIN.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                string Price = "";
                try
                {
                    Price = "$" + Math.Round((decimal)dgvIN.Rows[e.RowIndex].Cells["Column6"].Value, 2).ToString();
                }
                catch (Exception)
                {
                    
                }
                
                string ItemName = dgvIN.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                switch (dgvIN.Rows[e.RowIndex].Cells["Column10"].Value.ToString())
                {
                    case "BarcodeNOPrice":
                        Price = " ";
                        break;
                    case "BarcodePrice3":
                        Price ="$"+Math.Round(frmMain.IL[e.RowIndex].Price3,2).ToString();
                        break;
                    case "BarcodePrice4":
                        Price = "$" + Math.Round(frmMain.IL[e.RowIndex].Price4, 2).ToString();
                        
                        break;
                }


                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 225, 125);
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

                printDocument1.DocumentName = SKU + "," + Barcode + "," + ItemName + "," + Price;
                FileInfo fr = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPB.txt");
                if (fr.Exists)
                {
                    StreamReader sr = new StreamReader(fr.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = xx.Trim();

                }
                 int Width=225;
                int hieght=125;
                
                FileInfo frW = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBW.txt");
                if (frW.Exists)
                {
                    StreamReader sr = new StreamReader(frW.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    Width = Convert.ToInt16(Convert.ToDecimal(xx)*100);

                }
                FileInfo frH = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBH.txt");
                if (frH.Exists)
                {
                    StreamReader sr = new StreamReader(frH.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    hieght = Convert.ToInt16(Convert.ToDecimal(xx) * 100);

                }
                printDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(dgvIN.Rows[e.RowIndex].Cells["Column7"].Value.ToString());
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom",Width,hieght);
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog.Document = printDocument1;

                printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);

                printPreviewDialog.ShowDialog();
                

            }
            if (e.ColumnIndex==Column9.Index)
            {
                //quickprint

                string Barcode = dgvIN.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                string SKU = dgvIN.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                string Price = "";
                try
                {
                    Price = "$" + Math.Round((decimal)dgvIN.Rows[e.RowIndex].Cells["Column6"].Value, 2).ToString();
                }
                catch (Exception)
                {

                }
                string ItemName = dgvIN.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                switch (dgvIN.Rows[e.RowIndex].Cells["Column10"].Value.ToString())
                {
                    case "BarcodeNOPrice":
                        Price = " ";
                        break;
                    case "BarcodePrice3":
                        Price = "$" + Math.Round(frmMain.IL[e.RowIndex].Price3, 2).ToString();
                        break;
                    case "BarcodePrice4":
                        Price = "$" + Math.Round(frmMain.IL[e.RowIndex].Price4, 2).ToString();

                        break;
                }


                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 225, 125);
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

                printDocument1.DocumentName = SKU + "," + Barcode + "," + ItemName + "," + Price;
                FileInfo fr = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPB.txt");
                if (fr.Exists)
                {
                    StreamReader sr = new StreamReader(fr.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = xx.Trim();

                }
                
                int Width = 225;
                int hieght = 125;

                FileInfo frW = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBW.txt");
                if (frW.Exists)
                {
                    StreamReader sr = new StreamReader(frW.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    Width = Convert.ToInt16(Convert.ToDecimal(xx) * 100);

                }
                FileInfo frH = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBH.txt");
                if (frH.Exists)
                {
                    StreamReader sr = new StreamReader(frH.FullName);
                    string xx = sr.ReadToEnd();
                    sr.Close();
                    hieght = Convert.ToInt16(Convert.ToDecimal(xx) * 100);

                }
                printDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(dgvIN.Rows[e.RowIndex].Cells["Column7"].Value.ToString());
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", Width, hieght);
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                //printPreviewDialog.Document = printDocument1;

                //printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);

                //printPreviewDialog.ShowDialog();
                
                printDocument1.Print();
                
            }
        }

        void printPreviewDialog_Shown(object sender, EventArgs e)
        {

            PrintPreviewDialog s = (PrintPreviewDialog)sender;
            s.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (s.Width / 2);
            s.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (s.Height / 2);
        }
        private void txtINSKU_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text.Contains('~') && t.Text.Contains('/'))
            {
                btnINAdd_Click(sender, e);
                t.Focus();

                return;
            }
        }

        private void btnINSearch_Click(object sender, EventArgs e)
        {
            frmSearchcs s = new frmSearchcs();
            s.frmMain = frmMain;
            frmMain.SearchIsIn = true;
            s.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            System.Drawing.Printing.PrintDocument p = (System.Drawing.Printing.PrintDocument)sender;
            Graphics g = e.Graphics;

            Image myimg = Code128Rendering.MakeBarcodeImage(p.DocumentName.Split(',')[1], 2, true);

            //Locate the logo image on the location set on new Point
            g.DrawString("SKU:", new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 30, 5);
            g.DrawString(p.DocumentName.Split(',')[0], new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 60, 5);
            if (p.DocumentName.Split(',')[2].Length <= 40)
            {
                g.DrawString(p.DocumentName.Split(',')[2], new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);

            }
            else if (p.DocumentName.Split(',')[2].Length <= 80)
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 40) , new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(40, p.DocumentName.Split(',')[2].Length - 40), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
            }
            else
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 40) , new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(40, 40) , new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(80, p.DocumentName.Split(',')[2].Length - 80), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 44);
            }

            g.DrawImage(myimg, 0, 60, 225, 30);
            string barcode = p.DocumentName.Split(',')[1].Replace("~", "").Replace("/", "") ;
            float x = float.Parse((112.5 - barcode.Length * 3.3).ToString());
            g.DrawString(barcode, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x, 95);
            string price = p.DocumentName.Split(',')[3];
            float x2 = float.Parse((112.5 - price.Length * 3.3).ToString());
            g.DrawString(price, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x2, 108);   
         
        }

        private void lblclm9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvIN.Rows.Count; i++)
            {
                dgvIN.Rows[i].Cells["Column10"].Value = dgvIN.Rows[0].Cells["Column10"].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblclm9_Click(sender, e);
            dgvIN.Refresh();
        }

        int icc = 0;
        private void dgvIN_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //if (icc<13)
            //{
            //    FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt");
            //    if (fi.Exists)
            //    {
            //        StreamReader sr = new StreamReader(fi.FullName);
            //        while (!sr.EndOfStream)
            //        {
            //            string x = sr.ReadLine().Trim();
            //            if (dgvIN.Columns.Contains(x.Split('^')[0]))
            //            {
            //                dgvIN.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);

            //            }

            //        }
            //        sr.Close();
            //        sr.Dispose();
            //        sr = null;
            //        icc++;
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 1;
            int q = 0;
            frmMain.receivedreport.ReportDataSet.Clear();
            foreach (InventoryRecord item in frmMain.IL)
            {
                ReportDataSet.InventoryRow r = frmMain.receivedreport.ReportDataSet.Inventory.NewInventoryRow();
                r.Barcode = item.Barcode;
                r.BarcodeImage = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + item.Barcode + ".jpg";
                r.ID = x;
                r.ItemName = item.ProductName;
                r.Location = item.Location;
                r.Price = "$" + Math.Round(item.Price, 2).ToString();
                r.Price3 = "$" + Math.Round(item.Price3, 2).ToString();
                r.Qty = item.Quantity;
                q += item.Quantity;
                r.SKU = item.SKU;
                r.OrderNumber = item.OrderNumber.ToString();
                frmMain.receivedreport.ReportDataSet.Tables[0].Rows.Add(r);
                x++;
            }
            //frmMain.receivedreport.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtTQty",q.ToString()));
            frmMain.receivedreport.WindowState = FormWindowState.Normal;
            frmMain.receivedreport.StartPosition = FormStartPosition.CenterScreen;
            frmMain.receivedreport.reportViewer1.RefreshReport();
            frmMain.receivedreport.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCustomizeColumnsIN f = new frmCustomizeColumnsIN();
            f.mode = "IN";
            f.ShowDialog();

            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine().Trim();
                    if (dgvIN.Columns.Contains(x.Split('^')[0]))
                    {
                        dgvIN.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);
                        if (x.Split('^').Length >= 3)
                        {
                            dgvIN.Columns[x.Split('^')[0]].Visible = bool.Parse(x.Split('^')[2]);
                            if (x.Split('^').Length == 4) dgvIN.Columns[x.Split('^')[0]].HeaderText = x.Split('^')[3];
                        }
                        else
                        {
                            dgvIN.Columns[x.Split('^')[0]].Visible = false;
                        }
                    }

                }
                sr.Close();
                sr.Dispose();
                sr = null;                
            }

        }

        

        

        

        

        

       
        

       
    }
}
