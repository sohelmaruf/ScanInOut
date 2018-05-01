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
    public partial class UCScanOUT : UserControl
    {
        public Form1 frmMain;
        public bool IsRestore;
        public UCScanOUT()
        {
            InitializeComponent();
        }
        public void HeadersName()
        {
            FileInfo fhnout = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNOUT.txt");
            if (fhnout.Exists)
            {
                StreamReader sr = new StreamReader(fhnout.FullName);
                lblclm0.Text = sr.ReadLine();
                lblclm1.Text = sr.ReadLine();
                lblclm2.Text = sr.ReadLine();
                lblclm3.Text = sr.ReadLine();
                lblclm4.Text = sr.ReadLine();
                lblclm5.Text = sr.ReadLine();
                lblclm6.Text = sr.ReadLine();
                lblclm7.Text = sr.ReadLine();
                lblclm8.Text = sr.ReadLine();
                lblclm9.Text = sr.ReadLine();
                lblclm10.Text = sr.ReadLine();
                lblclm11.Text = sr.ReadLine();

                sr.Close();

            }
        }
        private void UCScanOUT_Load(object sender, EventArgs e)
        {
            dgvOUT.Width = 0;
            dgvOUT.Width = 931;
            HeadersName();

            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine().Trim();
                    if (dgvOUT.Columns.Contains(x.Split('^')[0]))
                    {
                        dgvOUT.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);
                        if (x.Split('^').Length >= 3)
                        {
                            dgvOUT.Columns[x.Split('^')[0]].Visible = bool.Parse(x.Split('^')[2]);
                            if (x.Split('^').Length == 4) dgvOUT.Columns[x.Split('^')[0]].HeaderText = x.Split('^')[3];
                        }
                        else
                        {
                            dgvOUT.Columns[x.Split('^')[0]].Visible = true;
                        }
                    }

                }
                sr.Close();
                sr.Dispose();
                sr = null;
                icc++;
            }

        }
        //private void dataGridView1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (dgvOUT.Width == 0)
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

        //    int x = (dgvOUT.Width - xl) / 12;

        //    for (int i = 1; i < dgvOUT.Columns.Count; i++)
        //    {
        //        Label l = (Label)this.Controls["lblclm" + (i - 1).ToString()];
        //        l.Width = l.Width + x;
        //        l.Left += (i-1) * x;
        //        dgvOUT.Columns[i].Width = l.Width - 1;


        //    }

        //}

        private void cbPrintAllBarcodes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrintAllBarcodes.Checked)
            {
                btnOUTUpdate.Text = "Update&&Print barcodes";
            }
            else
            {
                btnOUTUpdate.Text = "Update";
            }
        }

        private void barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 126)
            {
                txtOUTBarcode.Focus();

            }
            
           
        }

        void c_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text.Contains('~'))
            {
                t.Text = t.Text.Replace("~", "");
                txtOUTBarcode.Focus();
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

        }

        private void txtOUTBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tt = (TextBox)sender;

            if (e.KeyChar == 13 && tt.Text != "")
            {
                btnOUTAdd_Click(sender, e);
                tt.Focus();
            }
        }
        public int GetDataOUT()
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


            InventoryRecord ir = frmMain.inventory.GetData(txtOUTSKU.Text.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), txtOUTBarcode.Text.Replace("~", "").Replace("/", "").Replace("?", "").Replace(@"\\", ""), ref res);
            if (ir.SKU != null)
            {
                if (ir.QOH == 0)
                {
                    return 1;
                }
            }

            if (frmMain.ILOUT.Find(x => x.SKU == ir.SKU) != null)
            {
                int o = frmMain.ILOUT.FindIndex(x => x.SKU == ir.SKU);
                if (frmMain.ILOUT[o].QOH <= frmMain.ILOUT[o].Quantity)
                {
                    return 1;
                }
                frmMain.ILOUT[o].Quantity += 1;
                dgvOUT.Rows[o].Cells["Column7"].Value = int.Parse(dgvOUT.Rows[o].Cells["Column7"].Value.ToString()) + 1;

                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    frmMain.datalogObj.UpdateLog(frmMain.ILOUT[o], "OUT");
                }
                return 0;
            }
            if (res == "0")
            {
                dgvOUT.Rows.Add();
                ir.Quantity = 1;
                frmMain.ILOUT.Add(ir);
                DataGridViewRow r = dgvOUT.Rows[dgvOUT.Rows.Count - 1];
                r.Cells["Column2"].Value = ir.Barcode;
                r.Cells["Column3"].Value = ir.SKU;
                r.Cells["Column5"].Value = ir.ProductName;
                r.Cells["Column7"].Value = 1;
                r.Cells["Column4"].Value = ir.SupplierSKU;
                r.Cells["Column1"].Value = dgvOUT.Rows.Count;
                r.Cells["Column6"].Value = Math.Round(ir.Price, 2);


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

                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) + 1).ToString();
                txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) + 1).ToString();
                if (!IsRestore)
                {
                    frmMain.datalogObj.AddToLog(ir, "OUT");
                }

                FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + ir.Barcode + ".jpg");
                if (!fi.Exists)
                {
                    Image i = Code128Rendering.MakeBarcodeImage(ir.Barcode, 1, true);
                    i.Save(fi.FullName);
                }

                return 0;
            }
            else
            {
                return 2;
            }
        }
        private void btnOUTAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOUTBarcode.Text + txtOUTSKU.Text))
            {
                MessageBox.Show("Please Scan Barcode or Insert SKU/Barcode First!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                

                return;
            }

            if (GetDataOUT() == 0)
            {
                if (!IsRestore) Console.Beep(); 
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
        }

        private void dgvOUT_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                try
                {
                    int x = 0;
                    if (!int.TryParse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out x) || dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("-"))
                    {
                        MessageBox.Show("Not Valid Quantity");
                        dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frmMain.ILOUT[e.RowIndex].Quantity;
                        return;
                    }
                    if (frmMain.ILOUT[e.RowIndex].Quantity != int.Parse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        frmMain.ILOUT[e.RowIndex].Quantity = int.Parse(dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        txtOUTTotalSKU.Text = frmMain.ILOUT.Sum(m => m.Quantity).ToString();
                        frmMain.datalogObj.UpdateLog(frmMain.ILOUT[e.RowIndex], "OUT");
                    }
                }
                catch (Exception)
                {

                    dgvOUT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frmMain.ILOUT[e.RowIndex].Quantity;
                }


            }
        }

        private void dgvOUT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - frmMain.ILOUT[e.RowIndex].Quantity).ToString();
                txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) - 1).ToString();
                frmMain.ILOUT.RemoveAt(e.RowIndex);
                dgvOUT.Rows.RemoveAt(e.RowIndex);
                foreach (DataGridViewRow item in dgvOUT.Rows)
                {
                    item.Cells["Column1"].Value = item.Index + 1;
                }
            }
            else
            {



                string Barcode = dgvOUT.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                string SKU = dgvOUT.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                string Price = "$" + dgvOUT.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
                string ItemName = dgvOUT.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                switch (dgvOUT.Rows[e.RowIndex].Cells["Column10"].Value.ToString())
                {
                    case "BarcodeNOPrice":
                        Price = " ";
                        break;
                    case "BarcodePrice3":
                        Price = "$" + Math.Round(frmMain.ILOUT[e.RowIndex].Price3, 2).ToString();
                        break;
                    case "BarcodePrice4":
                        Price = "$" + Math.Round(frmMain.ILOUT[e.RowIndex].Price4, 2).ToString();

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
                printDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(dgvOUT.Rows[e.RowIndex].Cells["Column7"].Value.ToString());
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", Width, hieght);
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

                if (e.ColumnIndex == 7)
                {


                    printPreviewDialog.Document = printDocument1;

                    printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);

                    printPreviewDialog.ShowDialog();

                }
                if (e.ColumnIndex == 8)
                {
                    printDocument1.Print();

                }
            }
        }

        void printPreviewDialog_Shown(object sender, EventArgs e)
        {

            PrintPreviewDialog s = (PrintPreviewDialog)sender;
            s.Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (s.Width / 2);
            s.Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (s.Height / 2);
        }
        private void btnOUTCEL_Click(object sender, EventArgs e)
        {
            dgvOUT.Rows.Clear();
            frmMain.ILOUT.Clear();
            txtOUTTotalSKU.Text = "0";
            txtOUTTotalUSKU.Text = "0";
        }

        private void btnOUTCLS_Click(object sender, EventArgs e)
        {
            if (dgvOUT.Rows.Count > 0)
            {
                if (dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells["Column7"].Value.ToString() == "1")
                {
                    dgvOUT.Rows.RemoveAt(dgvOUT.Rows.Count - 1);
                    frmMain.ILOUT.RemoveAt(frmMain.ILOUT.Count - 1);
                    txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - 1).ToString();
                    txtOUTTotalUSKU.Text = (int.Parse(txtOUTTotalUSKU.Text) - 1).ToString();
                }
                else
                {
                    frmMain.ILOUT[frmMain.ILOUT.Count - 1].Quantity = frmMain.ILOUT[frmMain.ILOUT.Count - 1].Quantity - 1;
                    dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells["Column7"].Value = int.Parse(dgvOUT.Rows[dgvOUT.Rows.Count - 1].Cells["Column7"].Value.ToString()) - 1;

                    txtOUTTotalSKU.Text = (int.Parse(txtOUTTotalSKU.Text) - 1).ToString();
                    frmMain.datalogObj.UpdateLog(frmMain.ILOUT[frmMain.ILOUT.Count - 1], "OUT");
                }
            }
        }

        private void txtOUTSKU_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (t.Text.Contains('~') && t.Text.Contains('/'))
            {
                btnOUTAdd_Click(sender, e);
                t.Focus();

                return;
            }
        }

        private void btnOUTUpdate_Click(object sender, EventArgs e)
        {
            if (frmMain.inventory.SaveList(frmMain.ILOUT, "OUT"))
            {
                frmMain.datalogObj.SubmiteLog("OUT");
                int x = 1;
                int q = 0;
                frmMain.packinglistreport.ReportDataSet.Clear();
                foreach (InventoryRecord item in frmMain.ILOUT)
                {
                    ReportDataSet.InventoryRow r = frmMain.packinglistreport.ReportDataSet.Inventory.NewInventoryRow();
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
                    frmMain.packinglistreport.ReportDataSet.Tables[0].Rows.Add(r);
                    x++;
                }
                //frmMain.receivedreport.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtTQty",q.ToString()));
                frmMain.packinglistreport.reportViewer1.RefreshReport();
                frmMain.packinglistreport.WindowState = FormWindowState.Normal;
                frmMain.packinglistreport.StartPosition = FormStartPosition.CenterScreen;
                frmMain.packinglistreport.ShowDialog();
                if (btnOUTUpdate.Text == "Update&&Print barcodes")
                {
                    for (int i = 0; i < dgvOUT.Rows.Count; i++)
                    {
                        dgvOUT_CellClick(dgvOUT, new DataGridViewCellEventArgs(Column9.Index, i));
                    }
                }
                btnOUTCEL_Click(sender, e);
            }
        }

        private void btnOUTSearch_Click(object sender, EventArgs e)
        {
            frmSearchcs s = new frmSearchcs();

            s.frmMain = frmMain;
            frmMain.SearchIsIn = false;
            s.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            System.Drawing.Printing.PrintDocument p = (System.Drawing.Printing.PrintDocument)sender;
            Graphics g = e.Graphics;

            Image myimg = Code128Rendering.MakeBarcodeImage(p.DocumentName.Split(',')[1], 2, true);

            //Locate the logo image on the location set on new Point
            g.DrawString("SKU:", new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 30, 5);
            g.DrawString(p.DocumentName.Split(',')[0], new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, 60, 5);
            if (p.DocumentName.Split(',')[2].Length <= 40)
            {
                g.DrawString(p.DocumentName.Split(',')[2], new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);

            }
            else if (p.DocumentName.Split(',')[2].Length <= 80)
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 40), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(40, p.DocumentName.Split(',')[2].Length - 40), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
            }
            else
            {
                g.DrawString(p.DocumentName.Split(',')[2].Substring(0, 40), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 20);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(40, 40), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 32);
                g.DrawString(p.DocumentName.Split(',')[2].Substring(80, p.DocumentName.Split(',')[2].Length - 80), new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, 10, 44);
            }

            g.DrawImage(myimg, 0, 60, 225, 30);
            string barcode = p.DocumentName.Split(',')[1];
            float x = float.Parse((112.5 - barcode.Length * 3.3).ToString());
            g.DrawString(barcode, new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, x, 95);
            string price = p.DocumentName.Split(',')[3];
            float x2 = float.Parse((112.5 - price.Length * 3.3).ToString());
            g.DrawString(price, new System.Drawing.Font("Arial", 7, FontStyle.Bold), System.Drawing.Brushes.Black, x2, 108);   
        }

        private void lblclm9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvOUT.Rows.Count; i++)
            {
                dgvOUT.Rows[i].Cells["Column10"].Value = dgvOUT.Rows[0].Cells["Column10"].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblclm9_Click(sender, e);
            dgvOUT.Refresh();
        }
        int icc = 0;
        private void dgvOUT_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (icc < 13)
            {
                //FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt");
                //if (fi.Exists)
                //{
                //    StreamReader sr = new StreamReader(fi.FullName);
                //    while (!sr.EndOfStream)
                //    {
                //        string x = sr.ReadLine().Trim();
                //        if (dgvOUT.Columns.Contains(x.Split('^')[0]))
                //        {
                //            dgvOUT.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);

                //        }

                //    }
                //    sr.Close();
                //    sr.Dispose();
                //    sr = null;
                //    icc++;
                //}
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCustomizeColumnsIN f = new frmCustomizeColumnsIN();
            f.mode = "OUT";
            f.ShowDialog();

            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine().Trim();
                    if (dgvOUT.Columns.Contains(x.Split('^')[0]))
                    {
                        dgvOUT.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);
                        if (x.Split('^').Length >= 3)
                        {
                            dgvOUT.Columns[x.Split('^')[0]].Visible = bool.Parse(x.Split('^')[2]);
                            if (x.Split('^').Length == 4) dgvOUT.Columns[x.Split('^')[0]].HeaderText = x.Split('^')[3];
                        }
                        else
                        {
                            dgvOUT.Columns[x.Split('^')[0]].Visible = false;
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
