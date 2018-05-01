using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
using System.IO;
using GenCode128;
using System.Reflection;

namespace ScanINOUTVer2
{
    public partial class UCPurchaseOrders : UserControl
    {
        public bool RestoreMode;
        public Form1 frmMain;
        List<PurchaseOrderDetailsObj> purchaseorderdetailslist;
        BindingSource bs;
        BindingSource rbs;
        List<ReceiveObj> ReceivingList;
        Inventory Inv;
        List<POLogObj> pologlist;
        string LastItem;


        public void Receive(string SKU, int Quantity, int PONumber = 0)
        {
            PurchaseOrderDetailsObj pod;
            if (PONumber == 0)
            {
                pod = purchaseorderdetailslist.FirstOrDefault(m => m.LocalSKU.ToLower() == SKU.ToLower());
            }
            else
            {
                pod = purchaseorderdetailslist.FirstOrDefault(m => m.LocalSKU.ToLower() == SKU.ToLower() && m.PONumber == PONumber);
            }

            if (pod != null)
            {
                ReceiveObj rcv = ReceivingList.FirstOrDefault(m => m.PONumber == pod.PONumber && m.LocalSKU.ToLower() == pod.LocalSKU.ToLower());
                if (rcv == null)
                {
                    string res = "";
                    InventoryRecord InvR = Inv.GetData(SKU, SKU, ref res);
                    ReceiveObj Newrcv = new ReceiveObj();
                    Newrcv.ItemName = pod.ItemName;
                    Newrcv.ItemNumber = pod.ItemNumber;
                    Newrcv.Cost = Math.Round(pod.ExpectedCost, 4);
                    Newrcv.LocalSKU = pod.LocalSKU;
                    Newrcv.Location = InvR.Location;
                    Newrcv.OrderNumber = InvR.OrderNumber;
                    Newrcv.PONumber = pod.PONumber;
                    Newrcv.Price = InvR.Price;
                    Newrcv.Price2 = InvR.Price2;
                    Newrcv.Price3 = InvR.Price3;
                    if (Quantity > pod.QuantityRemaining)
                    {
                        Console.Beep(3800, 500);
                        if (MessageBox.Show("The Selected Quantity is bigger than that expected. Do you want to receive more?","Scan In&Out",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No )
                        {
                            return;
                        }
                        Newrcv.QtyReceived = Quantity;
                    }
                    else
                    {
                        Newrcv.QtyReceived = Quantity;
                    }                    
                    Newrcv.SupplierSKU = pod.SuppliersSKU;

                    rbs.Add(Newrcv);
                    #region LOG
                    POLogObj l = new POLogObj();
                    l.Cost = Newrcv.Cost;
                    l.IsUpdated = false;
                    l.ItemName = Newrcv.ItemName;
                    l.ItemNumber = Newrcv.ItemNumber;
                    l.Location = Newrcv.Location;
                    l.OrderNumber = Newrcv.OrderNumber;
                    l.PONumber = Newrcv.PONumber;
                    l.Price = Newrcv.Price;
                    l.Price2 = Newrcv.Price2;
                    l.Price3 = Newrcv.Price3;
                    l.QtyOrdered = pod.Ordered;
                    l.QtyReceived = Newrcv.QtyReceived;
                    l.QtyRemaining = pod.QuantityRemaining;
                    l.SKU = Newrcv.LocalSKU;
                    l.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                    l.SupplierName = cbSupplier.Text;
                    l.SupplierSKU = Newrcv.SupplierSKU;
                    if(!RestoreMode) POLog.Insert(l);
                    pologlist.Add(l);
                    #endregion
                    dgvReceiving.Refresh();
                    LastItem = Newrcv.PONumber.ToString() + "," + Newrcv.LocalSKU + "," + Quantity.ToString();

                    FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + InvR.Barcode + ".jpg");
                    if (!fi.Exists)
                    {
                        Image i = Code128Rendering.MakeBarcodeImage(InvR.Barcode, 1, true);
                        i.Save(fi.FullName);
                    }

                }
                else
                {
                    rcv.QtyReceived += Quantity;
                    LastItem = rcv.PONumber.ToString() + "," + rcv.LocalSKU + "," + Quantity.ToString();
                    #region LOG
                    POLogObj l = new POLogObj();
                    l.Cost = rcv.Cost;
                    l.IsUpdated = false;
                    l.ItemName = rcv.ItemName;
                    l.ItemNumber = rcv.ItemNumber;
                    l.Location = rcv.Location;
                    l.OrderNumber = rcv.OrderNumber;
                    l.PONumber = rcv.PONumber;
                    l.Price = rcv.Price;
                    l.Price2 = rcv.Price2;
                    l.Price3 = rcv.Price3;
                    l.QtyOrdered = pod.Ordered;
                    l.QtyReceived = rcv.QtyReceived;
                    l.QtyRemaining = pod.QuantityRemaining;
                    l.SKU = rcv.LocalSKU;
                    l.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                    l.SupplierName = cbSupplier.Text;
                    l.SupplierSKU = rcv.SupplierSKU;
                    if (!RestoreMode) POLog.Insert(l);
                    pologlist.Add(l);
                    #endregion
                }
                Console.Beep();
                dgvReceiving.Refresh();
                if (pod.QuantityRemaining < Quantity)
                {
                    pod.QuantityRemaining = 0 ;
                }
                else
                {
                    pod.QuantityRemaining -= Quantity;
                }
                
            }
            else
            {
                Console.Beep(3800, 500);
                ReceiveObj rcv = ReceivingList.FirstOrDefault(m => m.LocalSKU.ToLower() == SKU.ToLower() && m.PONumber != 0);
                if (rcv != null)
                {
                    if (MessageBox.Show(@"You have received the full quantity ordered for this item." + Environment.NewLine + "Do you want to receive more?", "Scan IN&OUT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        rcv.QtyReceived += Quantity;
                        LastItem = rcv.PONumber.ToString() + "," + rcv.LocalSKU + "," + Quantity.ToString();

                        #region LOG
                        POLogObj l = new POLogObj();
                        l.Cost = rcv.Cost;
                        l.IsUpdated = false;
                        l.ItemName = rcv.ItemName;
                        l.ItemNumber = rcv.ItemNumber;
                        l.Location = rcv.Location;
                        l.OrderNumber = rcv.OrderNumber;
                        l.PONumber = rcv.PONumber;
                        l.Price = rcv.Price;
                        l.Price2 = rcv.Price2;
                        l.Price3 = rcv.Price3;
                        l.QtyOrdered = rcv.QtyReceived;
                        l.QtyReceived = rcv.QtyReceived;
                        l.QtyRemaining = 0;
                        l.SKU = rcv.LocalSKU;
                        l.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                        l.SupplierName = cbSupplier.Text;
                        l.SupplierSKU = rcv.SupplierSKU;
                        if (!RestoreMode) POLog.Insert(l);
                        pologlist.Add(l);
                        #endregion
                    }
                }
                else
                {
                    string res = "";
                    InventoryRecord InvR = Inv.GetData(SKU, SKU, ref res);
                    if (InvR == null || string.IsNullOrWhiteSpace(InvR.SKU))
                    {
                        MessageBox.Show("Item Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    rcv = ReceivingList.FirstOrDefault(m => m.LocalSKU.ToLower() == SKU.ToLower() && m.PONumber == 0);
                    if (MessageBox.Show(@"This item is not listed on the selected PO(s)." + Environment.NewLine + "Do you want to receive it?", "Scan IN&OUT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        if (rcv == null)
                        {
                            rcv = new ReceiveObj();

                            rcv.Cost = 0;
                            rcv.ItemName = InvR.ProductName;
                            rcv.ItemNumber = ReceivingList.FindAll(m => m.PONumber == 0).Count + 1;
                            rcv.LocalSKU = InvR.SKU;
                            rcv.Location = InvR.Location;
                            rcv.OrderNumber = 0;
                            rcv.PONumber = 0;
                            rcv.Price = InvR.Price;
                            rcv.Price2 = InvR.Price2;
                            rcv.Price3 = InvR.Price3;
                            rcv.QtyReceived = Quantity;
                            rcv.SupplierSKU = InvR.SupplierSKU;
                            rbs.Add(rcv);
                            LastItem = rcv.PONumber.ToString() + "," + rcv.LocalSKU + "," + Quantity.ToString();
                            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + InvR.Barcode + ".jpg");
                            if (!fi.Exists)
                            {
                                Image i = Code128Rendering.MakeBarcodeImage(InvR.Barcode, 1, true);
                                i.Save(fi.FullName);
                            }
                        }
                        else
                        {
                            rcv.QtyReceived += Quantity;
                            LastItem = rcv.PONumber.ToString() + "," + rcv.LocalSKU + "," + Quantity.ToString();
                        }

                        #region LOG
                        POLogObj l = new POLogObj();
                        l.Cost = rcv.Cost;
                        l.IsUpdated = false;
                        l.ItemName = rcv.ItemName;
                        l.ItemNumber = rcv.ItemNumber;
                        l.Location = rcv.Location;
                        l.OrderNumber = rcv.OrderNumber;
                        l.PONumber = rcv.PONumber;
                        l.Price = rcv.Price;
                        l.Price2 = rcv.Price2;
                        l.Price3 = rcv.Price3;
                        l.QtyOrdered = 0;
                        l.QtyReceived = rcv.QtyReceived;
                        l.QtyRemaining = 0;
                        l.SKU = rcv.LocalSKU;
                        l.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                        l.SupplierName = cbSupplier.Text;
                        l.SupplierSKU = rcv.SupplierSKU;
                        if (!RestoreMode) POLog.Insert(l);
                        pologlist.Add(l);
                        #endregion

                    }
                }

                dgvReceiving.Refresh();
            }

            purchaseorderdetailslist.RemoveAll(m => m.QuantityRemaining == 0);
            bs.ResetBindings(false);
            dgvEcpected.Refresh();
        }
        public void ResetInput(Control c = null)
        {
            txtBarcode.Text = "";
            txtSKU.Text = "";
            txtSupplierSKU.Text = "";
            nudQty.Value = 1;
            if (c != null)
            {
                c.Focus();
            }
        }
        public void ResetAll(Control c = null)
        {
            
            pologlist.Clear();
            txtBarcode.Text = "";
            txtSKU.Text = "";
            txtSupplierSKU.Text = "";
            nudQty.Value = 1;
            clbOrderNumbers.Items.Clear();
            if (bs != null) bs.Clear();
            if (rbs != null) rbs.Clear();
            dgvEcpected.Refresh();
            dgvReceiving.Refresh();
            if (c != null)
            {
                c.Focus();
                c.Select();
            }
        }
        public UCPurchaseOrders()
        {
            InitializeComponent();
        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            dgvEcpected.Height = panel3.Height * 75 / 175;
            dgvReceiving.Height = panel3.Height * 75 / 175;
        }



        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAll();
            if (cbSupplier.SelectedIndex >= 0)
            {
                List<PurchaseOrdersObj> purchaseorders = PurchaseOrders.GetAll((int)cbSupplier.SelectedValue).FindAll(m => m.DateClosed == DateTime.MinValue);
                foreach (PurchaseOrdersObj item in purchaseorders)
                {
                    clbOrderNumbers.Items.Add(item.PONumber);
                }

            }
            else
            {
                clbOrderNumbers.Items.Clear();
            }
        }


        private void UCPurchaseOrders_Load(object sender, EventArgs e)
        {
            RestoreMode = false;
            Inv = new Inventory();
            pologlist = new List<POLogObj>();

            ReceivingList = new List<ReceiveObj>();
            rbs = new BindingSource();

            rbs.DataSource = ReceivingList;

            dgvReceiving.DataSource = rbs;

            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.DataSource = Supplier.GetAllWithOpenPO();

            cbSupplier.SelectedIndex = -1;


            dgvEcpected.AutoGenerateColumns = false;


            purchaseorderdetailslist = new List<PurchaseOrderDetailsObj>();
            bs = new BindingSource();
            bs.DataSource = purchaseorderdetailslist;
            
            
            dgvEcpected.DataSource = bs;

            ResetAll((Control)cbSupplier);

            dgvReceiving.Columns["clm2Price"].Visible = false;
            dgvReceiving.Columns["clm2Price2"].Visible = false;
            dgvReceiving.Columns["clm2Price3"].Visible = false;
            dgvReceiving.Columns["clm2Cost"].Visible = false;
        }

        public void clbOrderNumbers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PurchaseOrdersObj purchaseorder = PurchaseOrders.GetByID((int)clbOrderNumbers.Items[e.Index]);

            if (e.NewValue == CheckState.Checked)
            {
                foreach (PurchaseOrderDetailsObj item in PurchaseOrderDetails.GetByPONumber(purchaseorder.PONumber).FindAll(m => m.QuantityRemaining != 0))
                {
                    bs.Add(item);
                }
            }
            else
            {
                foreach (PurchaseOrderDetailsObj item in purchaseorderdetailslist.FindAll(m => m.PONumber == purchaseorder.PONumber))
                {
                    bs.Remove(item);
                }
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                string barcode = txtBarcode.Text;
                string res = "";
                InventoryRecord Invr = Inv.GetData(barcode, barcode, ref res);
                Receive(Invr.SKU== null?"":Invr.SKU, 1);
                ResetInput((Control)txtBarcode);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                Receive(txtSKU.Text, Convert.ToInt32(nudQty.Value));
                ResetInput((Control)txtSKU);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtSupplierSKU.Text))
            {
                List<string> SKUs = Inv.GetSKUs(txtSupplierSKU.Text);
                if (SKUs.Count == 1)
                {
                    Receive(SKUs[0], Convert.ToInt32(nudQty.Value));
                    ResetInput((Control)txtSupplierSKU);
                    return;
                }
                else if (SKUs.Count > 1)
                {
                    frmSKUList f = new frmSKUList();
                    f.SKUList = SKUs;
                    f.ShowDialog();
                    if (!string.IsNullOrWhiteSpace(f.SelectedSKU))
                    {
                        Receive(f.SelectedSKU, f.Quantity);
                        ResetInput((Control)txtSupplierSKU);
                    }
                    return;
                }


            }
            MessageBox.Show("You have to insert Input data first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void UCPurchaseOrders_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 126)
            {
                e.Handled = true;
                txtBarcode.Focus();

            }
            try
            {
                if (e.KeyChar == 22 && dgvReceiving.SelectedCells.Count == 1 && dgvReceiving.Columns[dgvReceiving.SelectedCells[0].ColumnIndex].ReadOnly == false && dgvReceiving.Columns[dgvReceiving.SelectedCells[0].ColumnIndex].Name != clmPrintFormat.Name)
                {
                    dgvReceiving.SelectedCells[0].Value = Clipboard.GetText();
                }
            }
            catch (Exception)
            {
                
                
            }
            
           
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Contains('~') && txtBarcode.Text.Contains('/'))
            {
                int EndIndex = 0;
                int StartIndex = 0;
                while (txtBarcode.Text.IndexOf('~', StartIndex) != -1)
                {
                    StartIndex = txtBarcode.Text.IndexOf('~', StartIndex) + 1;
                }
                EndIndex = txtBarcode.Text.IndexOf('/', StartIndex);

                string barcode = txtBarcode.Text.Substring(StartIndex, EndIndex - StartIndex);
                string res = "";
                InventoryRecord Invr = Inv.GetData(barcode, barcode, ref res);
                Receive(Invr.SKU, 1);
                ResetInput((Control)sender);
            }
        }

        private void dgvEcpected_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PurchaseOrderDetailsObj p = (PurchaseOrderDetailsObj)bs[e.RowIndex];
                Receive(p.LocalSKU, p.QuantityRemaining, p.PONumber);
            }
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            Control c = (Control)sender;
            if (c.Name.Contains("nud"))
            {
                return;
            }
            TextBox t = (TextBox)sender;
            if (e.KeyValue == 13 && !string.IsNullOrWhiteSpace(t.Text))
            {
                btnReceive_Click(btnReceive, new EventArgs());
            }
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
            string barcode = p.DocumentName.Split(',')[1].Replace("~", "").Replace("/", "");
            float x = float.Parse((112.5 - barcode.Length * 3.3).ToString());
            g.DrawString(barcode, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x, 95);
            string price = p.DocumentName.Split(',')[3];
            float x2 = float.Parse((112.5 - price.Length * 3.3).ToString());
            g.DrawString(price, new System.Drawing.Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.Black, x2, 108);

        }
        private void dgvReceiving_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReceiving.Columns["clm2QuickPrint"].Index == e.ColumnIndex)
            {
                string res = "";
                InventoryRecord ir = Inv.GetData(dgvReceiving.Rows[e.RowIndex].Cells["clm2SKU"].Value.ToString(), dgvReceiving.Rows[e.RowIndex].Cells["clm2SKU"].Value.ToString(), ref res);
                string Barcode = ir.Barcode;
                string SKU = ir.SKU;
                string Price = "$" + Math.Round(ir.Price,2);
                string ItemName = ir.ProductName;
                switch (dgvReceiving.Rows[e.RowIndex].Cells["clmPrintFormat"].Value.ToString())
                {
                    case "BarcodeNOPrice":
                        Price = " ";
                        break;
                    case "BarcodePrice3":
                        Price = "$" + Math.Round(ir.Price3, 2).ToString();
                        break;
                    case "BarcodePrice4":
                        Price = "$" + Math.Round(ir.Price4, 2).ToString();

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
                printDocument1.DefaultPageSettings.PrinterSettings.Copies = Convert.ToInt16(dgvReceiving.Rows[e.RowIndex].Cells["clm2QtyReceived"].Value.ToString());
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", Width, hieght);
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                //printPreviewDialog.Document = printDocument1;

                //printPreviewDialog.Shown += new EventHandler(printPreviewDialog_Shown);

                //printPreviewDialog.ShowDialog();

                printDocument1.Print();
            }
            if (e.ColumnIndex == dgvReceiving.Columns["clm2Cost"].Index || e.ColumnIndex == dgvReceiving.Columns["clm2Price"].Index || e.ColumnIndex == dgvReceiving.Columns["clm2Price2"].Index || e.ColumnIndex == dgvReceiving.Columns["clm2Price3"].Index)
            {
                dgvReceiving.BeginEdit(true);
                return;
            }
            if (e.RowIndex >= 0 && dgvReceiving.Columns["clm2ViewOrder"].Index == e.ColumnIndex)
            {
                frmViewOrder f = new frmViewOrder();
                f.PONumber = Convert.ToInt32(dgvReceiving.Rows[e.RowIndex].Cells["clm2PONum"].Value);
                f.PODate = PurchaseOrders.GetByID(f.PONumber).PODate;
                f.OrderNumber = Convert.ToInt32(dgvReceiving.Rows[e.RowIndex].Cells["clm2OrderNumber"].Value);
                f.ShowDialog();
            }

            if (e.RowIndex >= 0 && dgvReceiving.Columns["clm2Cancel"].Index == e.ColumnIndex)
            {
                ReceiveObj rcv = (ReceiveObj)rbs[e.RowIndex];
                if (rcv.PONumber == 0)
                {
                    rbs.RemoveAt(e.RowIndex);
                    dgvReceiving.Refresh();

                }
                else
                {
                    PurchaseOrderDetailsObj pod = purchaseorderdetailslist.FirstOrDefault(m => m.PONumber == rcv.PONumber && m.LocalSKU == rcv.LocalSKU);
                    if (pod != null)
                    {
                        pod.QuantityRemaining += rcv.QtyReceived;
                        rbs.RemoveAt(e.RowIndex);
                        dgvReceiving.Refresh();
                        dgvEcpected.Refresh();
                    }
                    else
                    {
                        pod = PurchaseOrderDetails.GetByPONumber(rcv.PONumber).FirstOrDefault(m => m.LocalSKU == rcv.LocalSKU);
                        if (pod != null)
                        {
                            bs.Add(pod);
                            rbs.RemoveAt(e.RowIndex);
                            dgvReceiving.Refresh();
                            dgvEcpected.Refresh();
                        }
                    }
                }
                return;

            }
        }

        private void btnCancelLastItem_Click(object sender, EventArgs e)
        {
            if (ReceivingList.Count == 0)
            {
                return;
            }

            ReceiveObj rcv = ReceivingList.Last();
            if (rcv == null)
            {
                return;
            }
            if (rcv.PONumber == 0)
            {
                rbs.Remove(rcv);
                dgvReceiving.Refresh();

            }
            else
            {
                PurchaseOrderDetailsObj pod = purchaseorderdetailslist.FirstOrDefault(m => m.PONumber == rcv.PONumber && m.LocalSKU == rcv.LocalSKU);
                if (pod != null)
                {
                    pod.QuantityRemaining += rcv.QtyReceived;
                    rbs.Remove(rcv);
                    dgvReceiving.Refresh();
                    dgvEcpected.Refresh();
                }
                else
                {
                    pod = PurchaseOrderDetails.GetByPONumber(rcv.PONumber).FirstOrDefault(m => m.LocalSKU == rcv.LocalSKU);
                    if (pod != null)
                    {
                        bs.Add(pod);
                        rbs.Remove(rcv);
                        dgvReceiving.Refresh();
                        dgvEcpected.Refresh();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ReceivingList.Count > 0)
                {
                    lblTSKU.Text = ReceivingList.Sum(m => m.QtyReceived).ToString();
                    lblUSKU.Text = ReceivingList.Count.ToString();
                    lblTotal.Text = ReceivingList.Sum(m => m.Cost).ToString("$0.00");
                }
                else
                {
                    lblTSKU.Text = "0";
                    lblUSKU.Text = "0";
                    lblTotal.Text = "$0.00";
                }
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void btnShowCost_Click(object sender, EventArgs e)
        {
            if (btnShowCost.Text == "Show Cost")
            {
                frmPOLogin f = new frmPOLogin();
                f.ShowDialog();
                if (f.Tag != null && f.Tag.ToString() == "ok")
                {
                    clmCost.Visible = true;
                    dgvReceiving.Columns["clm2Cost"].Visible = true;
                    dgvReceiving.Columns["clm2Price"].Visible = true;
                    dgvReceiving.Columns["clm2Price2"].Visible = true;
                    dgvReceiving.Columns["clm2Price3"].Visible = true;
                    dgvReceiving.Refresh();
                    btnChangePwd.Visible = true;
                    btnShowCost.Text = "Hide Cost";
                }
            }
            else
            {
                clmCost.Visible = false;
                dgvReceiving.Columns["clm2Cost"].Visible = false;
                dgvReceiving.Columns["clm2Price"].Visible = false;
                dgvReceiving.Columns["clm2Price2"].Visible = false;
                dgvReceiving.Columns["clm2Price3"].Visible = false;
                dgvReceiving.Refresh();
                btnChangePwd.Visible = false;
                btnShowCost.Text = "Show Cost";
            }


        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            int x = 1;
            int q = 0;
            frmMain.receivedreport.ReportDataSet.Clear();
            foreach (ReceiveObj item in ReceivingList)
            {
                string res = "";
                InventoryRecord ir = Inv.GetData(item.LocalSKU, item.LocalSKU, ref res);
                ReportDataSet.InventoryRow r = frmMain.receivedreport.ReportDataSet.Inventory.NewInventoryRow();
                r.Barcode = ir.Barcode;
                r.BarcodeImage = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + ir.Barcode + ".jpg";
                r.ID = x;
                r.ItemName = ir.ProductName;
                r.Location = ir.Location;
                r.Price = "$" + Math.Round(ir.Price, 2).ToString();
                r.Price3 = "$" + Math.Round(ir.Price3, 2).ToString();
                r.Qty = item.QtyReceived;
                q += item.QtyReceived;
                r.SKU = ir.SKU;
                r.OrderNumber = item.OrderNumber.ToString();
                frmMain.receivedreport.ReportDataSet.Tables[0].Rows.Add(r);
            }
            //frmMain.receivedreport.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtTQty",q.ToString()));
            frmMain.receivedreport.WindowState = FormWindowState.Normal;
            frmMain.receivedreport.StartPosition = FormStartPosition.CenterScreen;
            frmMain.receivedreport.reportViewer1.RefreshReport();
            frmMain.receivedreport.ShowDialog();
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            frmChangePWD2 f = new frmChangePWD2();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvReceiving.Rows.Count; i++)
            {
                dgvReceiving.Rows[i].Cells["clmPrintFormat"].Value = dgvReceiving.Rows[0].Cells["clmPrintFormat"].Value;
            }
            dgvReceiving.Refresh();
        }

        private void dgvReceiving_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvReceiving.Rows[e.RowIndex].Cells["clmPrintFormat"].Value = "BarcodePrice";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int x = 1;
            int q = 0;
            frmMain.receivedreport.ReportDataSet.Clear();
            for (int i = 0; i < dgvReceiving.Rows.Count; i++)
            {
                POHistoryobj poh = new POHistoryobj();
                ReceiveObj rcv = ReceivingList[i];
                poh.Cost = rcv.Cost;
                poh.EnteredBy = txtOperationName.Text;
                poh.ItemNumber = rcv.ItemNumber;
                poh.LocalSKU = rcv.LocalSKU;
                poh.PONumber = rcv.PONumber;
                poh.Quantity = rcv.QtyReceived;
                poh.SuppliersSKU = rcv.SupplierSKU;
                POHistory.Insert(poh);
                Inv.UpdatePrice(rcv.LocalSKU, rcv.Price, rcv.Price2, rcv.Price3, rcv.QtyReceived);


                string res = "";
                InventoryRecord ir = Inv.GetData(rcv.LocalSKU, rcv.LocalSKU, ref res);
                ReportDataSet.InventoryRow r = frmMain.receivedreport.ReportDataSet.Inventory.NewInventoryRow();
                r.Barcode = ir.Barcode;
                r.BarcodeImage = "file:///" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//BI//" + ir.Barcode + ".jpg";
                r.ID = x;
                r.ItemName = ir.ProductName;
                r.Location = ir.Location;
                r.Price = "$" + Math.Round(ir.Price, 2).ToString();
                r.Price3 = "$" + Math.Round(ir.Price3, 2).ToString();
                r.Qty = rcv.QtyReceived;
                q += rcv.QtyReceived;
                r.SKU = ir.SKU;
                r.OrderNumber = rcv.OrderNumber.ToString();
                frmMain.receivedreport.ReportDataSet.Tables[0].Rows.Add(r);

                if (checkBox1.Checked)
                {
                    dgvReceiving_CellContentClick(dgvReceiving, new DataGridViewCellEventArgs(dgvReceiving.Columns["clm2QuickPrint"].Index, i));
                }
            }


            frmMain.receivedreport.WindowState = FormWindowState.Normal;
            frmMain.receivedreport.StartPosition = FormStartPosition.CenterScreen;
            frmMain.receivedreport.reportViewer1.RefreshReport();
            foreach (POLogObj item in pologlist)
            {
                POLog.Update(item.POLogID);
            }

            frmMain.receivedreport.ShowDialog();
            ResetAll((Control)cbSupplier);
        }

        private void cbSupplier_Enter(object sender, EventArgs e)
        {
            

            //cbSupplier.SelectedIndex = -1;
        }

       

        private void dgvEcpected_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                DataGridViewCell c = dgvEcpected.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvEcpected.CurrentCell = c;
                ContextMenuStrip cm = new ContextMenuStrip();
                cm.Items.Add("Copy", null, new EventHandler(Copy));
                e.ContextMenuStrip = cm;
            }
            catch (Exception)
            {


            }

        }
        private void Copy(object sender, EventArgs e)
        {
            
            Clipboard.SetText(dgvEcpected.SelectedCells[0].Value.ToString());
        }

        private void dgvReceiving_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                DataGridViewCell c = dgvReceiving.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvReceiving.CurrentCell = c;
                ContextMenuStrip cm = new ContextMenuStrip();
                cm.Items.Add("Copy", null, new EventHandler(Copy1));
                e.ContextMenuStrip = cm;
            }
            catch (Exception)
            {
                
                
            }
            
        }
        private void Copy1(object sender, EventArgs e)
        {

            Clipboard.SetText(dgvReceiving.SelectedCells[0].Value.ToString());
        }

        private void dgvEcpected_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewColumn c = dgvEcpected.Columns[e.ColumnIndex];
            //if (c.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            //{
            //    purchaseorderdetailslist.RemoveAll(m => m.QuantityRemaining == 0);
            //    bs.DataSource = purchaseorderdetailslist.OrderByDescending(m => m.GetType().GetProperty(c.DataPropertyName).GetValue(m, null)).ToList<PurchaseOrderDetailsObj>();
                
            //    dgvEcpected.DataSource = null;
            //    dgvEcpected.DataSource = bs;
            //    dgvEcpected.Refresh();
            //    c.HeaderCell.SortGlyphDirection = SortOrder.Descending;
            //}
            //else
            //{
            //    purchaseorderdetailslist.RemoveAll(m => m.QuantityRemaining == 0);
            //    bs.DataSource = purchaseorderdetailslist.OrderBy(m => m.GetType().GetProperty(c.DataPropertyName).GetValue(m, null)).ToList<PurchaseOrderDetailsObj>();
                
            //    dgvEcpected.DataSource = null;
            //    dgvEcpected.DataSource = bs;
            //    dgvEcpected.Refresh();
            //    c.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            //}
            
        }

        private void dgvEcpected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                txtSKU.Text = dgvEcpected.Rows[e.RowIndex].Cells[clmSKU.Name].Value.ToString();
            }
        }

        public void cbSupplier_DropDown(object sender, EventArgs e)
        {
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.DataSource = Supplier.GetAllWithOpenPO();
        }

        




    }
    public class ReceiveObj
    {
        public int PONumber { get; set; }
        public int ItemNumber { get; set; }
        public string LocalSKU { get; set; }
        public string ItemName { get; set; }
        public string SupplierSKU { get; set; }
        public string Location { get; set; }
        public int OrderNumber { get; set; }
        public int QtyReceived { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
    }
}
