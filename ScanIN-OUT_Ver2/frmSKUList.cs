using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScanINOUTVer2
{
    public partial class frmSKUList : Form
    {
        public List<string> SKUList;
        public string SelectedSKU;
        public int Quantity;
        public frmSKUList()
        {
            InitializeComponent();
        }

        private void frmSKUList_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = SKUList;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SelectedSKU = listBox1.SelectedItem.ToString();
            Quantity = Convert.ToInt32(numericUpDown1.Value);
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnUpdate_Click(btnUpdate, new EventArgs());
        }
    }
}
