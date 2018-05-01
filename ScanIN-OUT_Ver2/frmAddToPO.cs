using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;

namespace ScanINOUTVer2
{
    public partial class frmAddToPO : Form
    {
        public bool IsAuto;
        public List<InventoryRecord> inventoryrecords;
        public string ListOfLocalSKU;

        public frmAddToPO()
        {
            InitializeComponent();
        }

        private void AddToPO_Load(object sender, EventArgs e)
        {
            dtpDue.Value = DateTime.Now;
            dtpExpected.Value = DateTime.Now;
            string str = "";
            dgvItems.AutoGenerateColumns = false;
            dgvSupplier.AutoGenerateColumns = false;
            Supplier supplier = new Supplier();
            if (IsAuto)
            {
                dgvItems.DataSource = inventoryrecords;
                str = ListOfLocalSKU;
            }
            else
            {
                List<InventoryRecord> sos = Inventory.GetAllNotOrderedRecord(out str);
                foreach (InventoryRecord so in sos)
                {
                    so.ISordered = true;
                }
                dgvItems.DataSource = sos;
            }
            dgvSupplier.DataSource = supplier.GetSupplierByListLocalSKU(str);

        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 10)
            {
                SupplierObj so = (dgvSupplier.DataSource as List<SupplierObj>)[e.RowIndex];
                frmSupplierDetails fsd = new frmSupplierDetails();
                fsd.Text = so.SupplierName + " - Details";
                fsd.psos = (dgvSupplier.DataSource as List<SupplierObj>);
                fsd.pssku = so.SupplierSKU;
                fsd.StartPosition = FormStartPosition.CenterParent;
                fsd.ShowDialog();
                dgvSupplier.DataSource = fsd.psos;
            }
        }

        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            List<SupplierObj> Suppliers = (dgvSupplier.DataSource as List<SupplierObj>).FindAll(x => x.Isordered == true);
            if (Suppliers.Count == 0)
            {
                MessageBox.Show("there is no Purchases order to created");
                return;
            }
            List<InventoryRecord> InventoryRecords = (dgvItems.DataSource as List<InventoryRecord>).FindAll(x => x.ISordered == true);
            foreach (SupplierObj Supplier in Suppliers)
            {
                List<InventoryRecord> InventoryRecordsToinsert = InventoryRecords.FindAll(x => x.SupplierID == Supplier.SupplierID.ToString());
                int i = 1;
                PurchaseOrders.Insert(Supplier, "WithoutSend Mail", dtpDue.Value, InventoryRecordsToinsert.Sum(x => x.Cost));
                foreach (InventoryRecord inventoryrecord in InventoryRecordsToinsert)
                {

                    inventoryrecord.Cost = inventoryrecord.HideCost * inventoryrecord.QtyToOrder;
                    inventoryrecord.ExtendedCost = inventoryrecord.HideCost * inventoryrecord.QtyToOrder;
                    inventoryrecord.IsAuto = IsAuto;
                    PurchaseOrderDetails.Insert(inventoryrecord, i, dtpExpected.Value);
                    POHistory.Insert(inventoryrecord, i, txtCancel.Text);
                    Inventory.AddToLogAccDB(inventoryrecord);
                    i++;
                }
            }
            MessageBox.Show("purchase order created successfully");
            this.Close();
        }

        private void dgvSupplier_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvSupplier.EndEdit();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 19)
            {
                InventoryRecord ir = (dgvItems.DataSource as List<InventoryRecord>)[e.RowIndex];
                frmViewOrder frm = new frmViewOrder();
                frm.IsCreatePO = true;
                frm.OrderNumber = ir.OrderNumber;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.PONumber = 0;
                frm.PODate = DateTime.MinValue;
                frm.ShowDialog();
                frm.IsCreatePO = false;


            }
        }


        private void dgvSupplier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvSupplier.DataSource != null && dgvItems.DataSource != null && e.RowIndex ==0)
            {
                SupplierObj so = (dgvSupplier.DataSource as List<SupplierObj>)[e.RowIndex];
                List<InventoryRecord> irs = (dgvItems.DataSource as List<InventoryRecord>);
                List<InventoryRecord> newirs = new List<InventoryRecord>();
                foreach (InventoryRecord ir in irs)
                {
                    if (ir.SupplierID == so.SupplierID.ToString())
                    {
                        ir.ISordered = so.Isordered;

                    }
                    newirs.Add(ir);
                }
                dgvItems.DataSource = new List<InventoryRecord>();
                dgvItems.DataSource = newirs;

            }
        }

        private void dgvSupplier_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSupplier.EndEdit();
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvSupplier.DataSource != null && dgvItems.DataSource != null && e.RowIndex == 0)
            {
                List<InventoryRecord> irs = dgvItems.DataSource as List<InventoryRecord>;
                InventoryRecord ir = irs[e.RowIndex];
                bool Bool = irs.FindAll(x => x.SupplierID == ir.SupplierID).FindAll(x => x.ISordered == true).Count > 0;
                List<SupplierObj> sos = (dgvSupplier.DataSource as List<SupplierObj>);
                List<SupplierObj> newsos = new List<SupplierObj>();
                foreach (SupplierObj so in sos)
                {
                    if (so.SupplierID.ToString() == ir.SupplierID)
                    {
                        so.Isordered = Bool;

                    }
                    newsos.Add(so);
                }
                dgvSupplier.DataSource = new List<SupplierObj>();
                dgvSupplier.DataSource = newsos;

            }
        }

        private void dgvItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvItems.EndEdit();
        }
    }
}
