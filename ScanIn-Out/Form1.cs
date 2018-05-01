using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
using GenCode128;
using System.IO;

namespace ScanIn_Out
{
    public partial class Form1 : Form
    {
        public Inventory inventory;
        public DataLog datalog;
        List<InventoryRecord> IL;
        List<InventoryRecord> ILOUT;

        bool IsRestore = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(item);
            }

            FileInfo f = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DP.txt");
            if (f.Exists)
            {
                StreamReader sr = new StreamReader(f.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                comboBox1.Text = xx;
                
            }
            //this.Height = 480;            
            ScanIN();

        }

        public void ScanIN()
        {
            gbScanningIN.Left = 12;
            gbScanningIN.Top = 66;

            gbScanningIN.Visible = true;
            gbScanningOUT.Visible = false;
            pnlScanIn.BackColor = Color.SteelBlue;
            label6.ForeColor = Color.White;
            pnlScanOut.BackColor = Color.Azure;
            label7.ForeColor = Color.SteelBlue;

            tmrBarcodeOut.Enabled = false;
            tmrOUTFocus.Enabled = false;
            tmrINFocus.Enabled = true;            
            //tmrBarcodeIN.Enabled = true;
            x = 0;
            

            

        }
        public void ScanOUT()
        {
            gbScanningOUT.Left = 12;
            gbScanningOUT.Top = 66;

            gbScanningOUT.Visible = true;
            gbScanningIN.Visible = false;
            pnlScanOut.BackColor = Color.SteelBlue;
            label7.ForeColor = Color.White;

            pnlScanIn.BackColor = Color.Azure;
            label6.ForeColor = Color.SteelBlue;

            tmrINFocus.Enabled = false;
            tmrBarcodeIN.Enabled = false;
            //tmrBarcodeOut.Enabled = true;
            tmrOUTFocus.Enabled = true;
            x = 0;

        }
        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            pnlScanIn.BackColor = Color.SteelBlue;
            label6.ForeColor = Color.White;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            if (!gbScanningIN.Visible)
            {
                pnlScanIn.BackColor = Color.Azure;
                label6.ForeColor = Color.SteelBlue;
            }

        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            pnlScanOut.BackColor = Color.SteelBlue;
            label7.ForeColor = Color.White;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            if (!gbScanningOUT.Visible)
            {
                pnlScanOut.BackColor = Color.Azure;
                label7.ForeColor = Color.SteelBlue;
            }
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            pnlDBConnection.BackColor = Color.SteelBlue;
            label8.ForeColor = Color.White;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            pnlDBConnection.BackColor = Color.Azure;
            label8.ForeColor = Color.SteelBlue;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            ScanIN();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ScanOUT();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            gbScanningIN.Width = this.Width - 30;
            gbScanningIN.Height = this.Height - 100;
            lineShape1.X2 = gbScanningIN.Width;
            gbScanningOUT.Width = this.Width - 30;
            gbScanningOUT.Height = this.Height - 100;
            lineShape2.X2 = gbScanningIN.Width;
        }

        private void pnlDBConnection_Click(object sender, EventArgs e)
        {
            frmDBConnection f = new frmDBConnection();
            f.f1 = this;
            f.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!Connection.HasConnection())
            {
                frmDBConnection f = new frmDBConnection();
                f.f1 = this;
                f.ShowDialog();
            }

            if (!Connection.HasConnection())
            {
                Application.Exit();
                return;
            }

            lblConnection.Text = "Connected to: " + Connection.GetConnection().Database;
            inventory = new Inventory();
            datalog = new DataLog();
            IL = new List<InventoryRecord>();
            ILOUT = new List<InventoryRecord>();
      
        
        
       
        
        
        }

        private void tmrINFocus_Tick(object sender, EventArgs e)
        {
            if (!txtINBarcode.Focused)
            {
                txtINBarcode.Focus();
                
            }
            

        }

        int f1 = 0;
        private void dgvIN_SizeChanged(object sender, EventArgs e)
        {
            if (clmINBarCode.Width == 120)
            {
                clmINBarCode.Width += (dgvIN.Width - 938) / 8;
                clmINCancel.Width += (dgvIN.Width - 938) / 8;
                clmINItemName.Width += (dgvIN.Width - 938) / 8;
                clmINOrderNumber.Width += (dgvIN.Width - 938) / 8;
                clmINPrint.Width += (dgvIN.Width - 938) / 8;
                clmINSKU.Width += (dgvIN.Width - 938) / 8;
                clmINTotalQuantity.Width += (dgvIN.Width - 938) / 8;
                clmINPrice.Width += (dgvIN.Width - 938) / 8;
                f1 = 1;
                return;
            }
            if (f1 == 0)
            {
                clmINBarCode.Width = 120;
                clmINCancel.Width = 80;
                clmINItemName.Width = 170;
                clmINPrice.Width = 60;
                clmINOrderNumber.Width = 120;
                clmINPrint.Width = 80;
                clmINSKU.Width = 120;
                clmINTotalQuantity.Width = 120;
            }
            f1 = 0;

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
            if ( sku.Contains('/'))
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


            InventoryRecord ir = inventory.GetData(sku.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), barcode.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), ref res);
            if (IL.Find(x => x.SKU == ir.SKU) != null)
            {
                int o = IL.FindIndex(x => x.SKU == ir.SKU);
                IL[o].Quantity += 1;
                dgvIN.Rows[o].Cells[clmINTotalQuantity.Name].Value = int.Parse(dgvIN.Rows[o].Cells[clmINTotalQuantity.Name].Value.ToString()) + 1;
                
                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    datalog.UpdateLog(IL[o], "IN");    
                }                
                return true;
            }
            if (res == "0")
            {
                dgvIN.Rows.Add();
                ir.Quantity = 1;
                IL.Add(ir);
                DataGridViewRow r = dgvIN.Rows[dgvIN.Rows.Count - 1];
                r.Cells[clmINBarCode.Name].Value = ir.Barcode;
                r.Cells[clmINSKU.Name].Value = ir.SKU;
                r.Cells[clmINItemName.Name].Value = ir.ProductName;
                r.Cells[clmINPrice.Name].Value = Math.Round(ir.Price, 2);
                r.Cells[clmINTotalQuantity.Name].Value = 1;
                r.Cells[seq.Name].Value = dgvIN.Rows.Count;
                if (ir.OrderNumber != 0)
                {
                    r.Cells[clmINOrderNumber.Name].Value = ir.OrderNumber;
                }

                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) + 1).ToString();
                txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    datalog.AddToLog(ir, "IN");    
                }                
                return true;
            }
            else
            {
                return false;
            }
        }
        public int  GetDataOUT()
        {
            string res = "";
            string sku, barcode;
            sku = txtOUTSKU.Text;
            barcode = txtOUTBarcode.Text;

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


            InventoryRecord ir = inventory.GetData(txtOUTSKU.Text.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), txtOUTBarcode.Text.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), ref res);
            if (ir.SKU != null)
            {                
                if (ir.QOH == 0)
                {
                    return 1;
                }
            }

            if (ILOUT.Find(x => x.SKU == ir.SKU) != null)
            {
                int o = ILOUT.FindIndex(x => x.SKU == ir.SKU);
                if (ILOUT[o].QOH <= ILOUT[o].Quantity)
                {
                    return 1;
                }
                ILOUT[o].Quantity += 1;
                dgvOUT.Rows[o].Cells[clmOUTTotalQuantity.Name].Value = int.Parse(dgvOUT.Rows[o].Cells[clmOUTTotalQuantity.Name].Value.ToString()) + 1;
                
                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    datalog.UpdateLog(ILOUT[o], "OUT");    
                }                
                return 0;
            }
            if (res == "0")
            {
                dgvOUT.Rows.Add();
                ir.Quantity = 1;
                ILOUT.Add(ir);
                DataGridViewRow r = dgvOUT.Rows[dgvOUT.Rows.Count - 1];
                r.Cells[clmOutBarcode.Name].Value = ir.Barcode;
                r.Cells[clmOUTSKU.Name].Value = ir.SKU;
                r.Cells[clmOUTItemName.Name].Value = ir.ProductName;
                r.Cells[clmOUTTotalQuantity.Name].Value = 1;
                r.Cells[seqOut.Name].Value = dgvOUT.Rows.Count;
                r.Cells[clmOUTPrice.Name].Value = Math.Round(ir.Price, 2);

                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) + 1).ToString();
                txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    datalog.AddToLog(ir, "OUT");
                }
                return 0;
            }
            else
            {
                return 2;
            }
        }

        private void btnINAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtINBarcode.Text + txtINSKU.Text))
            {
                MessageBox.Show("Please Scan Barcode or Insert SKU/Barcode First!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tmrINFocus.Enabled = true;

                return;
            }

            if (GetDataIN())
            {
                
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

        private void btnINCIL_Click(object sender, EventArgs e)
        {
            dgvIN.Rows.Clear();
            IL.Clear();
            txtINTotalSKU.Text = "0";
            txtINTotalUSKU.Text = "0";
        }

        private void btnINCLSI_Click(object sender, EventArgs e)
        {
            if (dgvIN.Rows.Count > 0)
            {
                if (dgvIN.Rows[dgvIN.Rows.Count - 1].Cells[clmINTotalQuantity.Name].Value.ToString() == "1")
                {
                    dgvIN.Rows.RemoveAt(dgvIN.Rows.Count - 1);
                    IL.RemoveAt(IL.Count - 1);
                    txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - 1).ToString();
                    txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) - 1).ToString();
                }
                else
                {
                    IL[IL.Count - 1].Quantity = IL[IL.Count - 1].Quantity - 1;
                    dgvIN.Rows[dgvIN.Rows.Count - 1].Cells[clmINTotalQuantity.Name].Value = int.Parse(dgvIN.Rows[dgvIN.Rows.Count - 1].Cells[clmINTotalQuantity.Name].Value.ToString()) - 1;                    
                    txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - 1).ToString();
                    datalog.UpdateLog(IL[IL.Count - 1], "IN");
                }
            }
        }

        private void dgvIN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                txtINTotalSKU.Text = (int.Parse(txtINTotalSKU.Text) - IL[e.RowIndex].Quantity).ToString();
                txtINTotalUSKU.Text = (int.Parse(txtINTotalUSKU.Text) - 1).ToString();
                IL.RemoveAt(e.RowIndex);
                dgvIN.Rows.RemoveAt(e.RowIndex);
                foreach (DataGridViewRow item in dgvIN.Rows)
                {
                    item.Cells[seq.Name].Value = item.Index + 1;
                }
            }

            if (e.ColumnIndex == 6)
            {
                //frmPrintIN f = new frmPrintIN();
                //f.Barcode = dgvIN.Rows[e.RowIndex].Cells[clmINBarCode.Name].Value.ToString();
                //f.SKU = dgvIN.Rows[e.RowIndex].Cells[clmINSKU.Name].Value.ToString();
                //f.Price = dgvIN.Rows[e.RowIndex].Cells[clmINPrice.Name].Value.ToString();
                //f.ItemName = dgvIN.Rows[e.RowIndex].Cells[clmINItemName.Name].Value.ToString();

                //f.ShowDialog();

                string Barcode = dgvIN.Rows[e.RowIndex].Cells[clmINBarCode.Name].Value.ToString();
                string SKU = dgvIN.Rows[e.RowIndex].Cells[clmINSKU.Name].Value.ToString();
                string Price = dgvIN.Rows[e.RowIndex].Cells[clmINPrice.Name].Value.ToString();
                string ItemName = dgvIN.Rows[e.RowIndex].Cells[clmINItemName.Name].Value.ToString();


                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 225, 125);
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

                printDocument1.DocumentName = SKU + "," + Barcode + "," + ItemName + "," + Price;
                PrintDialog pd = new PrintDialog();
                
                pd.ShowDialog();
                printDocument1.PrinterSettings = pd.PrinterSettings;
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 225, 125);
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog.Document = printDocument1;
                
                printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);
                
                printPreviewDialog.ShowDialog();
                
            }
        }

       

       

        void printPreviewDialog_Shown(object sender, EventArgs e)
        {

            PrintPreviewDialog s = (PrintPreviewDialog)sender;            
            s.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (s.Width / 2);
            s.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (s.Height / 2);
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Printing.PrintDocument p = (System.Drawing.Printing.PrintDocument)sender;                                               
            Graphics g = e.Graphics;

            Image myimg = Code128Rendering.MakeBarcodeImage(p.DocumentName.Split(',')[1], 2, true);
            
            //Locate the logo image on the location set on new Point
            g.DrawString("SKU:", new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 30, 5);
            g.DrawString(p.DocumentName.Split(',')[0], new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 60, 5);
            if (p.DocumentName.Split(',')[2].Length <=30)
            {
                g.DrawString(p.DocumentName.Split(',')[2], new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);

            }
            else if (p.DocumentName.Split(',')[2].Length <= 60)
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 30) + "-", new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(30, p.DocumentName.Split(',')[2].Length - 30), new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
            }
            else
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 30) + "-", new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(30, 30) + "-", new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(60, p.DocumentName.Split(',')[2].Length - 60), new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 44);
            }
            
            g.DrawImage(myimg,0,60,225,30);
            string barcode = p.DocumentName.Split(',')[1];
            float x = float.Parse((112.5 - barcode.Length * 3.3).ToString());
            g.DrawString(barcode, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x, 95);
            string price = "$" + p.DocumentName.Split(',')[3];
            float x2 = float.Parse((112.5 - price.Length * 3.3).ToString());
            g.DrawString(price, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x2, 108);   
         
        }
        private void dgvOUT_SizeChanged(object sender, EventArgs e)
        {
            if (clmOutBarcode.Width == 130)
            {
                clmOutBarcode.Width += (dgvOUT.Width - 938) / 7;
                clmOUTCancel.Width += (dgvOUT.Width - 938) / 7;
                clmOUTItemName.Width += (dgvOUT.Width - 938) / 7;
                clmOUTPrint.Width += (dgvOUT.Width - 938) / 7;
                clmOUTSKU.Width += (dgvOUT.Width - 938) / 7;
                clmOUTTotalQuantity.Width += (dgvOUT.Width - 938) / 7;
                clmOUTPrice.Width += (dgvOUT.Width - 938) / 7;
                f1 = 1;
                return;
            }
            if (f1 == 0)
            {
                clmOutBarcode.Width = 130;
                clmOUTCancel.Width = 100;
                clmOUTItemName.Width = 200;
                clmOUTPrint.Width = 100;
                clmOUTSKU.Width = 130;
                clmOUTTotalQuantity.Width = 120;
                clmOUTPrice.Width = 80;
            }
            f1 = 0;
        }

        private void tmrOUTFocus_Tick(object sender, EventArgs e)
        {
            if (!txtOUTBarcode.Focused)
            {
                txtOUTBarcode.Focus();
            }

        }

        private void dgvOUT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - ILOUT[e.RowIndex].Quantity).ToString();
                txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) - 1).ToString();
                ILOUT.RemoveAt(e.RowIndex);
                dgvOUT.Rows.RemoveAt(e.RowIndex);
                foreach (DataGridViewRow item in dgvOUT.Rows)
                {
                    item.Cells[seqOut.Name].Value = item.Index + 1;
                }
            }
            if (e.ColumnIndex == 6)
            {
                //frmPrintIN f = new frmPrintIN();
                //f.Barcode = dgvOUT.Rows[e.RowIndex].Cells[clmOutBarcode.Name].Value.ToString();
                //f.SKU = dgvOUT.Rows[e.RowIndex].Cells[clmOUTSKU.Name].Value.ToString();
                //f.Price = dgvOUT.Rows[e.RowIndex].Cells[clmOUTPrice.Name].Value.ToString();
                //f.ItemName = dgvOUT.Rows[e.RowIndex].Cells[clmOUTItemName.Name].Value.ToString();

                //f.ShowDialog();


                string Barcode = dgvOUT.Rows[e.RowIndex].Cells[clmOutBarcode.Name].Value.ToString();
                string SKU = dgvOUT.Rows[e.RowIndex].Cells[clmOUTSKU.Name].Value.ToString();
                string Price = dgvOUT.Rows[e.RowIndex].Cells[clmOUTPrice.Name].Value.ToString();
                string ItemName = dgvOUT.Rows[e.RowIndex].Cells[clmOUTItemName.Name].Value.ToString();


                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 225, 125);
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printDocument1.DocumentName = SKU + "," + Barcode + "," + ItemName + "," + Price;
                PrintDialog pd = new PrintDialog();
                pd.ShowDialog();
                printDocument1.PrinterSettings = pd.PrinterSettings;
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog.Document = printDocument1;

                printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);
                printPreviewDialog.ShowDialog(); 
            }
        }

        private void btnOUTAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOUTBarcode.Text + txtOUTSKU.Text))
            {
                MessageBox.Show("Please Scan Barcode or Insert SKU/Barcode First!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tmrOUTFocus.Enabled = true;

                return;
            }

            if (GetDataOUT() == 0)
            {
                txtOUTBarcode.Text = "";
                txtOUTSKU.Text = "";
            }
            else if (GetDataOUT() == 1)
            {
                MessageBox.Show("Item Not available (Quantity is zero)", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOUTBarcode.Text = "";
                txtOUTSKU.Text = "";
            }
            else
            {
                MessageBox.Show("Item Not Found!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOUTBarcode.Text = "";
                txtOUTSKU.Text = "";
            }
        }

        private void btnOUTCEL_Click(object sender, EventArgs e)
        {
            dgvOUT.Rows.Clear();
            ILOUT.Clear();
            txtOUTTotalSKU.Text = "0";
            txtOUTTotalUSKU.Text = "0";
        }

        private void btnOUTCLSI_Click(object sender, EventArgs e)
        {
            if (dgvOUT.Rows.Count > 0)
            {
                if (dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells[clmOUTTotalQuantity.Name].Value.ToString() == "1")
                {
                    dgvOUT.Rows.RemoveAt(dgvOUT.Rows.Count - 1);
                    ILOUT.RemoveAt(ILOUT.Count - 1);
                    txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - 1).ToString();
                    txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) - 1).ToString();
                }
                else
                {
                    ILOUT[ILOUT.Count - 1].Quantity = ILOUT[ILOUT.Count - 1].Quantity - 1;
                    dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells[clmOUTTotalQuantity.Name].Value = int.Parse(dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells[clmOUTTotalQuantity.Name].Value.ToString()) - 1;
                    
                    txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - 1).ToString();
                    datalog.UpdateLog(ILOUT[ILOUT.Count - 1], "OUT");
                }
            }
        }

        private void btnINAdd_MouseDown(object sender, MouseEventArgs e)
        {
            tmrINFocus.Enabled = false;
        }

        private void btnINAdd_MouseUp(object sender, MouseEventArgs e)
        {
            tmrINFocus.Enabled = true;
        }

        private void btnOUTAdd_MouseDown(object sender, MouseEventArgs e)
        {
            tmrOUTFocus.Enabled = false;
        }

        private void btnOUTAdd_MouseUp(object sender, MouseEventArgs e)
        {
            tmrOUTFocus.Enabled = true;
        }

        private void btnINUpdate_Click(object sender, EventArgs e)
        {
            if (inventory.SaveList(IL, "IN"))
            {
                frmReceviedReport f = new frmReceviedReport();
                f.IRlist = IL;
                f.pn = comboBox1.Text;
                datalog.SubmiteLog("IN");
                MessageBox.Show("Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f.ShowDialog();
                btnINCIL_Click(sender, e);

            }

        }

        private void btnOUTUpdate_Click(object sender, EventArgs e)
        {
            if (inventory.SaveList(ILOUT, "OUT"))
            {
                datalog.SubmiteLog("OUT");
                frmpackinglist fbl = new frmpackinglist();
                fbl.IRList = ILOUT;
                fbl.pn = comboBox1.Text;
                MessageBox.Show("Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fbl.ShowDialog();
                btnOUTCEL_Click(sender, e);
            }
        }

        private void txtINSKU_Enter(object sender, EventArgs e)
        {
            tmrINFocus.Enabled = false;
        }

        private void txtINSKU_Leave(object sender, EventArgs e)
        {
            tmrINFocus.Enabled = true;
        }

        private void txtOUTSKU_Enter(object sender, EventArgs e)
        {
            tmrOUTFocus.Enabled = false;
        }

        private void txtOUTSKU_Leave(object sender, EventArgs e)
        {
            tmrOUTFocus.Enabled = true;
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
                y = 0;
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
            if (y == 0 && t.Text.Length>1)
            {
                btnINAdd_Click(sender, e);                
                t.Focus();
                y = 0;
            }
            else
            {
                y = 1;
            }
            if (t.Text.Length == 0)
            {
                y = 0;
            }
        }
        
        int x = 0;
        int y = 0;
        private void txtINBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tt = (TextBox)sender;
            if (e.KeyChar == 8)
            {
                return;
            }
            if (e.KeyChar == 13 && tt.Text !="")
            {
                btnINAdd_Click(sender, e);                
                tt.Focus();
            }
            x++;
            
        }

        private void tmrBarcodeIN_Tick(object sender, EventArgs e)
        {
            if (x > 8)
            {
                x = 0;
                btnINAdd_Click(sender, e);
                
            }
            else
            {
                x = 0;
            }
        }
        int yy = 0;
        private void txtOUTBarcode_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text == "")
            {
                return;
            }
            if (t.Text.Contains('~') && t.Text.Contains('/'))
            {
                btnOUTAdd_Click(sender, e);
                t.Focus();
                yy = 0;
                return;
            }
            if (t.Name.Contains("SKU") && t.Text != "")
            {
                txtOUTBarcode.Text = "";
            }
            else if (t.Name.Contains("Barcode") && t.Text != "")
            {
                txtOUTSKU.Text = "";
            }
            if (yy == 0 && t.Text.Length > 1)
            {
                btnOUTAdd_Click(sender, e);
                t.Focus();
                yy = 0;
            }
            else
            {
                yy = 1;
            }
            if (t.Text.Length == 0)
            {
                yy = 0;
            }
        }

        private void txtOUTBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tt = (TextBox)sender;
            if (e.KeyChar == 8)
            {
                return;
            }
            if (e.KeyChar == 13 && tt.Text != "")
            {
                btnOUTAdd_Click(sender, e);
                tt.Focus();
            }
            x++;

        }
        

        private void tmrBarcodeOut_Tick(object sender, EventArgs e)
        {
            if (x > 8)
            {
                x = 0;
                btnOUTAdd_Click(sender, e);

            }
            else
            {
                x = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            y = 0;
            x = 0;
            IsRestore = true;
            frmRestor f = new frmRestor();
            f.logdata = datalog;
            f.f1 = this;
            f.ShowDialog();
            IsRestore = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tmrINFocus.Enabled == true)
            {
                tmrINFocus.Enabled = false;
                button1.Tag = "in";
            }
            if (tmrOUTFocus.Enabled == true)
            {
                tmrOUTFocus.Enabled = false;
                button1.Tag = "out";
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (button1.Tag == "in")
            {
                tmrINFocus.Enabled = true;
            }
            if (button1.Tag == "out")
            {
                tmrOUTFocus.Enabled = true;
            }
        }

        

        private void dgvIN_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmrINFocus.Enabled = false;
        }

        private void dgvIN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tmrINFocus.Enabled = true;
        }

        private void dgvIN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                int x = 0;
                if (!int.TryParse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out x) || dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("-"))
                {
                    MessageBox.Show("Not Valid Quantity");
                    dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = IL[e.RowIndex].Quantity;
                    return;
                }
                if (IL[e.RowIndex].Quantity != int.Parse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    IL[e.RowIndex].Quantity = int.Parse(dgvIN.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    txtINTotalSKU.Text = IL.Sum(m => m.Quantity).ToString();
                    datalog.UpdateLog(IL[e.RowIndex], "IN");     
                }
                
            }
            
            
        }

        private void dgvOUT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tmrOUTFocus.Enabled = false;
        }

        private void dgvOUT_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tmrOUTFocus.Enabled = true;
        }

        private void dgvOUT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                int x = 0;
                if (!int.TryParse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out x) || dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("-"))
                {
                    MessageBox.Show("Not Valid Quantity");
                    dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ILOUT[e.RowIndex].Quantity;
                    return;
                }
                if (ILOUT[e.RowIndex].QOH < int.Parse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) )
                {
                    MessageBox.Show("Quantity Can't be more than QOH");
                    dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ILOUT[e.RowIndex].Quantity;
                    return;
                }

                if (ILOUT[e.RowIndex].Quantity != int.Parse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    ILOUT[e.RowIndex].Quantity = int.Parse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    txtOUTTotalSKU.Text = ILOUT.Sum(m => m.Quantity).ToString();
                    datalog.UpdateLog(ILOUT[e.RowIndex], "OUT");
                }

            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (tmrINFocus.Enabled)
            {
                tmrINFocus.Enabled = false;
                comboBox1.Tag = "in";
            }
            if (tmrOUTFocus.Enabled)
            {
                tmrOUTFocus.Enabled = false;
                comboBox1.Tag = "out";
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Tag.ToString() == "in")
            {
                tmrINFocus.Enabled = true;
            }
            else
            {
                tmrOUTFocus.Enabled = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(comboBox1.Text ))
            {
                StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DP.txt", false);
                sw.Write(comboBox1.Text);
                sw.Close();
            }
        }

        private void gbScanningIN_Enter(object sender, EventArgs e)
        {

        }

        private void dgvIN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbScanningOUT_Enter(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        

        

        

        






    }
}
