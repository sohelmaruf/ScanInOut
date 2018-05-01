using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
using System.IO;

namespace ScanINOUTVer2
{
    public partial class frmSearchcs : Form
    {
       public Form1 frmMain;
        public frmSearchcs()
        {
            InitializeComponent();
            
        }

        private void btnINAdd_Click(object sender, EventArgs e)
        {
            string f="";
            if (!string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                f += " i.LocalSKU like '%" + txtSKU.Text.Replace("'", "''") + "%' AND ";
            }
            else
            {
                f += "1 = 1 AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                f += "i.ItemName like '%" + txtItemName.Text.Replace("'", "''") + "%' AND ";
            }
            else
            {
                f += "1 = 1 AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                f += "i.Barcode like '%" + txtBarcode.Text.Replace("'", "''") + "%'  AND ";
            }
            else
            {
                f += "1 = 1 AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtSupplierSKU.Text))
            {
                f += "s.SupplierSKU like '%" + txtSupplierSKU.Text.Replace("'", "''") + "%'  ";
            }
            else
            {
                f += "1 = 1";
            }
             
            dgvSearch.DataSource = Inventory.SearchData(f);
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//SHW.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream)
                {
                    string x = sr.ReadLine().Trim();
                    if (dgvSearch.Columns.Contains(x.Split('^')[0]))
                    {
                        dgvSearch.Columns[x.Split('^')[0]].Width = int.Parse(x.Split('^')[1]);

                    }

                }
                sr.Close();
                sr.Dispose();
                sr = null;

            }
            dgvSearch.Focus();
        }

        private void dgvSearch_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (frmMain.SearchIsIn)
                {
                    frmMain.btnScanIN_Click(sender, e);
                    frmMain.scanIN.txtINSKU.Text = "~~~" + dgvSearch.Rows[e.RowIndex].Cells[0].Value + @"/"; ;
                }
                else
                {
                    frmMain.btnScanOut_Click(sender, e);
                    frmMain.scanOUT.txtOUTSKU.Text = "~~~" + dgvSearch.Rows[e.RowIndex].Cells[0].Value + @"/";
                }
            }
        }

        private void dgvSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnINAdd_Click(btnINAdd, new EventArgs());
            }
        }

        private void frmSearchcs_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSupplierSKU.Text = "";
            txtSKU.Text = "";
            txtItemName.Text = "";
            txtBarcode.Text = "";
            dgvSearch.Rows.Clear();
            txtSKU.Focus();
        }

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (dgvSearch.SelectedCells.Count == 1)
                {
                    if (frmMain.SearchIsIn)
                    {
                        frmMain.btnScanIN_Click(sender, e);
                        frmMain.scanIN.txtINSKU.Text = "~~~" + dgvSearch.Rows[dgvSearch.SelectedCells[0].RowIndex].Cells[0].Value + @"/"; ;
                    }
                    else
                    {
                        frmMain.btnScanOut_Click(sender, e);
                        frmMain.scanOUT.txtOUTSKU.Text = "~~~" + dgvSearch.Rows[dgvSearch.SelectedCells[0].RowIndex].Cells[0].Value + @"/";
                    }
                }
            }
        }

        private void frmSearchcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//SHW.txt", false);

            foreach (DataGridViewColumn item in dgvSearch.Columns)
            {
                sw.WriteLine(item.Name + "^" + item.Width.ToString());
            }
            sw.Close();
            sw.Dispose();
            sw = null;
        }
    }
}
 