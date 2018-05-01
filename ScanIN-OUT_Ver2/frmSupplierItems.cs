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
    public partial class frmSupplierItems : Form
    {
        public List<InventoryRecord> sir = new List<InventoryRecord>();
        public List<InventoryRecord> sirNew;
        public frmSupplierItems()
        {
            InitializeComponent();
        }

        private void btnaddTopo_Click(object sender, EventArgs e)
        {
            UCCreatePurchaseOrdersIndividually cpoi = new UCCreatePurchaseOrdersIndividually();
            foreach (InventoryRecord ir in sir)
            {
                if (ir.QtyToOrder!=0)
                {
                    
                    ir.ISDeleted = false;
                    ir.ISordered = false;
                    ir.Cost = ir.HideCost * ir.QtyToOrder;
                    ir.ExtendedCost = ir.HideCost * ir.QtyToOrder;
                    sirNew.Add(ir);
                    Inventory.AddToLogAccDB(ir);
                }
            }
            this.Close();

        }

        private void frmSupplierItems_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.DataSource = sir;
        }

        private void dgvData_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.EndEdit();

        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sir = dgvData.DataSource as List<InventoryRecord>;

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

                    if (Convert.ToInt32((sender as TextBox).Text) < 0)
                    {

                        MessageBox.Show("Enter only Positive numbers");
                        (sender as TextBox).Text = 0.ToString();
                    }

                }
            }
 
        }
        
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (sirNew.Find(m=>m.SKU==sir[e.RowIndex].SKU)!=null)
            {
                e.Cancel = true;   
            }
        }

    }
}
