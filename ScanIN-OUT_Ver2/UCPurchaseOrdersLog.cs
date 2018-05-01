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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;



namespace ScanINOUTVer2
{
    public partial class UCPurchaseOrdersLog : UserControl
    {
        public Form1 frmMain;        
        Inventory Inv;
        List<PurchaseOrderDetailsObj> purchaseorderdetailslist;
        BindingSource bs;
        BindingSource rbs;
        BindingSource nbs;
        List<POHistoryobj> ReceivingList;
        List<POLogObj> NotReceivingList;
        public UCPurchaseOrdersLog()
        {
            InitializeComponent();
        }

        private void UCPurchaseOrdersLog_Load(object sender, EventArgs e)
        {
            Inv = new Inventory();

            ReceivingList = new List<POHistoryobj>();
            rbs = new BindingSource();

            rbs.DataSource = ReceivingList;

            dgvReceived.DataSource = rbs;

            NotReceivingList = new List<POLogObj>();
            nbs = new BindingSource();

            nbs.DataSource = NotReceivingList;
            dgvNotReceived.AutoGenerateColumns = false;
            dgvNotReceived.DataSource = nbs;
            

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
        }
        public void ResetAll(Control c = null)
        {            
            clbOrderNumbers.Items.Clear();
            if (bs != null) bs.Clear();
            if (rbs != null) rbs.Clear();
            dgvEcpected.Refresh();
            dgvNotReceived.Refresh();
            dgvReceived.Refresh();
            if (c != null)
            {
                c.Focus();
                c.Select();
            }
        }
        private void cbSupplier_DropDown(object sender, EventArgs e)
        {
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.DataSource = Supplier.GetAllWithOpenPO();
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

        public void clbOrderNumbers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PurchaseOrdersObj purchaseorder = PurchaseOrders.GetByID((int)clbOrderNumbers.Items[e.Index]);

            if (e.NewValue == CheckState.Checked)
            {
                foreach (PurchaseOrderDetailsObj item in PurchaseOrderDetails.GetByPONumber(purchaseorder.PONumber).FindAll(m => m.QuantityRemaining != 0))
                {
                    bs.Add(item);
                }
                foreach (POHistoryobj  item in POHistory.GetReceivedItems(purchaseorder.PONumber))
                {
                    rbs.Add(item);
                }
                foreach (POLogObj item in POLog.GetAll(Convert.ToInt32(cbSupplier.SelectedValue),purchaseorder.PONumber).FindAll(m=>m.IsUpdated == false))
                {
                    nbs.Add(item);
                }
            }
            else
            {
                foreach (PurchaseOrderDetailsObj item in purchaseorderdetailslist.FindAll(m => m.PONumber == purchaseorder.PONumber))
                {
                    bs.Remove(item);
                }
                foreach (POHistoryobj item in ReceivingList.FindAll(m => m.PONumber == purchaseorder.PONumber))
                {
                    rbs.Remove(item);
                }
                foreach (POLogObj  item in NotReceivingList.FindAll(m => m.PONumber == purchaseorder.PONumber))
                {
                   nbs.Remove(item); 
                }
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (NotReceivingList.Count == 0)
            {
                return;
            }

            frmMain.btnPurchaseOrders_Click(frmMain.btnPurchaseOrders, new EventArgs());
            frmMain.purchaseorders.RestoreMode = true;
            ComboBox cb =  (ComboBox)frmMain.purchaseorders.Controls.Find(cbSupplier.Name, true)[0];
            frmMain.purchaseorders.cbSupplier_DropDown(cb, new EventArgs());
            cb.SelectedValue = NotReceivingList[0].SupplierID;
            CheckedListBox clb = (CheckedListBox)frmMain.purchaseorders.Controls.Find(clbOrderNumbers.Name, true)[0];
            for (int i = 0; i < clbOrderNumbers.Items.Count; i++)
            {
                if (clbOrderNumbers.GetItemChecked(i))
                {
                    frmMain.purchaseorders.clbOrderNumbers_ItemCheck(clb,new ItemCheckEventArgs(i,CheckState.Checked,CheckState.Unchecked));
                }
            }
            clb.Refresh();

            foreach (POLogObj item in NotReceivingList)
            {
                frmMain.purchaseorders.Receive(item.SKU, item.QtyReceived, item.PONumber);
            }
            frmMain.purchaseorders.RestoreMode = false;
            frmMain.purchaseorders.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int cols;
            //open file 
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel files (*.csv)|*.csv";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            StreamWriter wr = new StreamWriter(s.FileName);

            //determine the number of columns and write columns to file 
            cols = dgvEcpected.Columns.Count;
            for (int i = 0; i < cols - 1; i++)
            {
                wr.Write(dgvEcpected.Columns[i].HeaderText.ToString().ToUpper() + ",");
            }
            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dgvEcpected.Rows.Count - 1); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dgvEcpected.Rows[i].Cells[j].Value != null)
                    {
                        wr.Write(dgvEcpected.Rows[i].Cells[j].Value + ",");
                    }
                    else
                    {
                        wr.Write(",");
                    }
                }

                wr.WriteLine();
            }

            //close file
            wr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PDF files (*.pdf)|*.pdf";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(s.FileName, FileMode.Create));

            doc.Open();//Open Document to write


            Paragraph paragraph = new Paragraph("");

            //Create table by setting table value

            PdfPTable t1 = new PdfPTable(dgvEcpected.Columns.Count);
            //DataTable dt = (DataTable)dgvEcpected.DataSource;


            //Create Table Header

            foreach (DataGridViewColumn item in dgvEcpected.Columns)
            {
                t1.AddCell(item.HeaderText);
            }

            foreach (DataGridViewRow rows in dgvEcpected.Rows)
            {

                foreach (DataGridViewColumn item in dgvEcpected.Columns)
                {
                    t1.AddCell(rows.Cells[item.Name].Value.ToString());
                }

            }
            doc.Add(paragraph);
            doc.Add(t1);
            doc.Close(); //Close document
            //
            MessageBox.Show("PDF Created!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PDF files (*.pdf)|*.pdf";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(s.FileName, FileMode.Create));

            doc.Open();//Open Document to write


            Paragraph paragraph = new Paragraph("");

            //Create table by setting table value

            PdfPTable t1 = new PdfPTable(dgvReceived.Columns.Count);
            //DataTable dt = (DataTable)dgvEcpected.DataSource;


            //Create Table Header

            foreach (DataGridViewColumn item in dgvReceived.Columns)
            {
                t1.AddCell(item.HeaderText);
            }

            foreach (DataGridViewRow rows in dgvReceived.Rows)
            {

                foreach (DataGridViewColumn item in dgvReceived.Columns)
                {
                    t1.AddCell(rows.Cells[item.Name].Value.ToString());
                }

            }
            doc.Add(paragraph);
            doc.Add(t1);
            doc.Close(); //Close document
            //
            MessageBox.Show("PDF Created!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PDF files (*.pdf)|*.pdf";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(s.FileName, FileMode.Create));

            doc.Open();//Open Document to write


            Paragraph paragraph = new Paragraph("");

            //Create table by setting table value

            PdfPTable t1 = new PdfPTable(dgvNotReceived.Columns.Count);
            //DataTable dt = (DataTable)dgvEcpected.DataSource;


            //Create Table Header

            foreach (DataGridViewColumn item in dgvNotReceived.Columns)
            {
                t1.AddCell(item.HeaderText);
            }

            foreach (DataGridViewRow rows in dgvNotReceived.Rows)
            {

                foreach (DataGridViewColumn item in dgvNotReceived.Columns)
                {
                    t1.AddCell(rows.Cells[item.Name].Value.ToString());
                }

            }
            doc.Add(paragraph);
            doc.Add(t1);
            doc.Close(); //Close document
            //
            MessageBox.Show("PDF Created!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cols;
            //open file 
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel files (*.csv)|*.csv";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            StreamWriter wr = new StreamWriter(s.FileName);

            //determine the number of columns and write columns to file 
            cols = dgvReceived.Columns.Count;
            for (int i = 0; i < cols - 1; i++)
            {
                wr.Write(dgvReceived.Columns[i].HeaderText.ToString().ToUpper() + ",");
            }
            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dgvReceived.Rows.Count - 1); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dgvReceived.Rows[i].Cells[j].Value != null)
                    {
                        wr.Write(dgvReceived.Rows[i].Cells[j].Value + ",");
                    }
                    else
                    {
                        wr.Write(",");
                    }
                }

                wr.WriteLine();
            }

            //close file
            wr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cols;
            //open file 
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel files (*.csv)|*.csv";
            s.ShowDialog();
            if (string.IsNullOrWhiteSpace(s.FileName))
            {
                return;
            }
            StreamWriter wr = new StreamWriter(s.FileName);

            //determine the number of columns and write columns to file 
            cols = dgvNotReceived.Columns.Count;
            for (int i = 0; i < cols - 1; i++)
            {
                wr.Write(dgvNotReceived.Columns[i].HeaderText.ToString().ToUpper() + ",");
            }
            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (dgvNotReceived.Rows.Count - 1); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (dgvNotReceived.Rows[i].Cells[j].Value != null)
                    {
                        wr.Write(dgvNotReceived.Rows[i].Cells[j].Value + ",");
                    }
                    else
                    {
                        wr.Write(",");
                    }
                }

                wr.WriteLine();
            }

            //close file
            wr.Close();
        }

       
    }
}
