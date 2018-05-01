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
    public partial class frmSupplierDetails : Form
    {
        public frmSupplierDetails()
        {
            InitializeComponent();
        }

        public List<SupplierObj> psos;
        public string pssku;
        private void frmSupplierDetails_Load(object sender, EventArgs e)
        {
            SupplierObj so = psos.Find(x => x.SupplierSKU == pssku);
            txtInstructions.Text = so.Instructions;
            txtComment.Text = so.Comments;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SupplierObj so = psos.Find(x => x.SupplierSKU == pssku);
            so.Instructions = txtInstructions.Text;
            so.Comments = txtComment.Text;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You Want To Close Without Save Changes ? If you choose yes you will lose Your Changes","Cnfirmation",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                return;
            }
            this.Close();
        }
    }
}
