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
using SCANINOUTBL;

namespace ScanINOUTVer2
{
    public partial class UCCreatePurchaseOrders : UserControl
    {
        public UCCreatePurchaseOrders()
        {
            InitializeComponent();
        }

        string listoflocalSKU;
        private void UCPurchaseOrders_Load(object sender, EventArgs e)
        {
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";
            cbSupplier.DataSource = SCANINOUTBL.Supplier.GetSupplierNameAndID();
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierID";

            cbSupplier.SelectedIndex = -1;
            cbDays.SelectedIndex = 1;
            dgvData.AutoGenerateColumns = false;
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedIndex != -1)
            {
                Inventory inventory = new SCANINOUTBL.Inventory();
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = inventory.GetReorderQty(cbSupplier.SelectedValue.ToString(), cbDays.Text == "" ? "0" : cbDays.Text, out listoflocalSKU);
            }
        }

        

        private void btnaddTopo_Click(object sender, EventArgs e)
        {

            if (dgvData.RowCount == 0)
            {
                MessageBox.Show("No data to ordered");
                return;
            }
            frmAddToPO frm = new frmAddToPO();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.IsAuto = true;
            frm.inventoryrecords = dgvData.DataSource as List<InventoryRecord>;
            frm.ListOfLocalSKU = listoflocalSKU;
            frm.ShowDialog();
            cbSupplier_SelectedIndexChanged(cbSupplier, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmPOLog frm = new frmPOLog();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }

}
