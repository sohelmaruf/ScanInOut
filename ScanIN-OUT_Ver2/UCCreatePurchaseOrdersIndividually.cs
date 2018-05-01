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
    public partial class UCCreatePurchaseOrdersIndividually : UserControl
    {
        public List<InventoryRecord> PublicInventoryRecord = new List<InventoryRecord>();
        public List<InventoryRecord> PublicISuppliernventoryRecord = new List<InventoryRecord>();
        BindingSource bs = new BindingSource();
        public UCCreatePurchaseOrdersIndividually()
        {
            InitializeComponent();
        }


        private void UCPurchaseOrders_Load(object sender, EventArgs e)
        {
            string str="";
            dgvData.AutoGenerateColumns = false;
            PublicInventoryRecord = Inventory.GetAllNotOrderedRecord(out str);
            dgvData.DataSource = PublicInventoryRecord;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItem.Text))
            {
                MessageBox.Show("You Must insert the Item SKU");
                return;
            }
            if (dgvData.DataSource != null)
            {
                if ((dgvData.DataSource as List<InventoryRecord>).Any(x => x.SKU == txtItem.Text))
                {

                    MessageBox.Show("Can't add this item becouse it is in the list you can only update it in the list");
                    return;
                }
            }
            if (txtQty.Value == 0)
            {
                MessageBox.Show("You Must Insert the Qty to Order");
                return;
            }
            Inventory ir = new Inventory();
            List<InventoryRecord> Items = ir.GetBySKU("i", txtItem.Text);
            if (Items.Count > 0)
            {

                Items[0].QtyToOrder = Convert.ToInt32(txtQty.Value);
                Items[0].ISDeleted = false;
                Items[0].ISordered = false;
                Items[0].Cost = Items[0].HideCost * Items[0].QtyToOrder;
                Items[0].ExtendedCost = Items[0].HideCost * Items[0].QtyToOrder;
                Items[0].IsAuto = false;
                PublicInventoryRecord.Add(Items[0]);
                Inventory.AddToLogAccDB(Items[0]);
                dgvData.DataSource = new List<InventoryRecord>();
                dgvData.DataSource = PublicInventoryRecord;
                dgvData.Refresh();
            }
            else
            {
                MessageBox.Show("Invalid SKU");
                return;

            }
        }

        private void dgvData_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            dgvData.EndEdit();

        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            PublicInventoryRecord = dgvData.DataSource as List<InventoryRecord>;

            PublicInventoryRecord[e.RowIndex].Cost = PublicInventoryRecord[e.RowIndex].HideCost * PublicInventoryRecord[e.RowIndex].QtyToOrder;
            PublicInventoryRecord[e.RowIndex].ExtendedCost = PublicInventoryRecord[e.RowIndex].HideCost * PublicInventoryRecord[e.RowIndex].QtyToOrder;
            Inventory.AddToLogAccDB(PublicInventoryRecord[e.RowIndex]);

        }


        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvData.CurrentCell.ColumnIndex > -1)
            {
                TextBox tb = (TextBox)e.Control;
                tb.TextChanged += new EventHandler(tb_TextChanged);
                tb.Leave += new EventHandler(tb_Leave);
            }
        }

        void tb_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = 0.ToString();
            }
        }
        void tb_TextChanged(object sender, EventArgs e)
        {
            int xx = 0;

            if (string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = xx.ToString();
            }
            else
            {

                if (!int.TryParse((sender as TextBox).Text, out xx))
                {
                    MessageBox.Show("Enter only numbers");
                    (sender as TextBox).Text = xx.ToString();
                }
                else 
                {

                    if (Convert.ToInt32((sender as TextBox).Text) <0)
                    {
                        
                    MessageBox.Show("Enter only Positive numbers");
                    (sender as TextBox).Text = 0.ToString();
                    }
                   
                }
            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplier.Text))
            {
                MessageBox.Show("You Must insert the Supplier SKU");
                return;
            }
            Inventory ir = new Inventory();
            List<InventoryRecord> Items = ir.GetBySKU("s", txtSupplier.Text);
            if (Items.Count > 0)
            {
                frmSupplierItems frms = new frmSupplierItems();
                frms.sir.Clear();
                frms.sir.AddRange(Items);
                frms.sirNew = PublicInventoryRecord;
                frms.StartPosition = FormStartPosition.CenterParent;
                frms.ShowDialog();
                dgvData.DataSource = new List<InventoryRecord>();
                dgvData.DataSource = PublicInventoryRecord;
                dgvData.Refresh();
            }
            else
            {
                MessageBox.Show("Invalid SKU");
                return;

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Are You sure You want to Delete??","Confirmation",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    return;
                }
                PublicInventoryRecord[e.RowIndex].ISDeleted = true;
                Inventory.AddToLogAccDB(PublicInventoryRecord[e.RowIndex]);
                PublicInventoryRecord.RemoveAt(e.RowIndex);
                dgvData.DataSource = new List<InventoryRecord>();
                dgvData.DataSource = PublicInventoryRecord;
                dgvData.Refresh();
            }
        }

        private void btnaddTopo_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount==0)
            {
                MessageBox.Show("No data to ordered");
                return;
            }
            frmAddToPO frm = new frmAddToPO();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.IsAuto = false;
            frm.ShowDialog();
            string str="";
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = new List<InventoryRecord>();
            PublicInventoryRecord =Inventory.GetAllNotOrderedRecord(out str);
            dgvData.DataSource = PublicInventoryRecord;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmPOLog frm = new frmPOLog();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void txtQty_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}