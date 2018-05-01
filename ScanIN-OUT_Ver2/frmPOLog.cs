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
    public partial class frmPOLog : Form
    {

        public frmPOLog()
        {
            InitializeComponent();
        }

        private void AddToPO_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            dtpFrom.MinDate = dtpTo.MinDate = new DateTime(2015, 1, 1);
            dtpTo.MaxDate = dtpFrom.MaxDate = dtpTo.Value;
            dgvItems.AutoGenerateColumns = false;
            dgvItems.DataSource = Inventory.GetAllPerPerioud(dtpFrom.Value, dtpTo.Value);
        }

        
        private void btnCreatePO_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value>dtpTo.Value)
            {
                MessageBox.Show("Date from must be smaller tham Date to");
                return;
            }
            dgvItems.AutoGenerateColumns = false;
            dgvItems.DataSource = Inventory.GetAllPerPerioud(dtpFrom.Value, dtpTo.Value);
        }

       
    }
}
