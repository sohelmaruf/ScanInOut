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

namespace ScanINOUTVer2
{
    public partial class UCDataLog : UserControl
    {

        public Form1 f1;
        public DataLog logdata;
        DataTable dt;
        DataTable dto;
        public UCDataLog()
        {
            InitializeComponent();
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lbOrderID.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Item to restore!", "Scan IN&OUT");
                return;
            }

            if (dgvOrders.Rows[0].Cells[10].Value.ToString() == "true")
            {
                MessageBox.Show("You have aleready Restored this transaction!", "Scan IN&OUT");
                return;
            }
                        if (dgvOrders.Rows[0].Cells[11].Value.ToString() == "IN")
            {
                logdata.LogKeyIN = lbOrderID.Text;
                f1.btnScanIN_Click(sender, e);
                f1.scanIN.IsRestore = true;
            }
            else
            {
                logdata.LogKeyOUT = lbOrderID.Text;
                f1.btnScanOut_Click(sender,e);
                f1.scanOUT.IsRestore = true;
            }
            foreach (DataGridViewRow item in dgvOrders.Rows)
            {
                for (int i = 1; i <= (int)item.Cells[5].Value; i++)
                {
                    if (item.Cells[11].Value.ToString() == "IN")
                    {
                        f1.scanIN.txtINSKU.Text = "~~~" + item.Cells[0].Value.ToString() + @"/"; ;
                    }
                    else
                    {
                        f1.scanOUT.txtOUTSKU.Text = "~~~" +item.Cells[0].Value.ToString()+ @"/";
                    }
                }
            }
            f1.scanOUT.IsRestore = false;
            f1.scanIN.IsRestore = false;
            this.Cursor = Cursors.Default;            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbOrderID.SelectedIndex<-1)
            {
                MessageBox.Show("You must select An Order");
                return;
            }
            if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                logdata.RemoveFromLog(lbOrderID.Text);
                dto.Rows.Remove(dto.Select("OrderID = '" + lbOrderID.Text + "'")[0]);
                lbOrderID.SelectedIndex = 0;
            }
        }

        public void UCDataLog_Load(object sender, EventArgs e)
        {
            if (Connection.HasConnection())
            {
             
            dt = logdata.GetLogs();
            dto = logdata.GetLogsOrderID();
            lbOrderID.DataSource = dto;
            lbOrderID.ValueMember = "OrderID";
            lbOrderID.DisplayMember = "OrderID";
            dgvOrders.DataSource = dt;
            updategrid();
            lbOrderID.SelectedIndex = -1;
            label1.Text = "";   
            }
        }

        void updategrid()
        {
            if (dgvOrders.Columns.Count == 12)
            {
                dgvOrders.Columns[0].Width = 100;
                dgvOrders.Columns[1].Width = 100;
                dgvOrders.Columns[2].Width = 150;
                dgvOrders.Columns[3].Visible = false;
                dgvOrders.Columns[4].Visible = false;
                dgvOrders.Columns[5].Width = 60;
                dgvOrders.Columns[6].Width = 60;
                dgvOrders.Columns[7].Width = 60;
                dgvOrders.Columns[8].Width = 80;
                dgvOrders.Columns[9].Width = 105;
                dgvOrders.Columns[10].Width = 60;
                dgvOrders.Columns[11].Width = 60;

            }
        }

        private void lbOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lbOrderID.SelectedIndex >= 0)
            {
                dgvOrders.DataSource = logdata.GetLogsbyOrderID(lbOrderID.Text);
                updategrid();
                try
                {
                    label1.Text = "Transaction Date: " + new DateTime(int.Parse(lbOrderID.Text.Substring(0, 4)), int.Parse(lbOrderID.Text.Substring(4, 2)), int.Parse(lbOrderID.Text.Substring(6, 2)), int.Parse(lbOrderID.Text.Substring(8, 2)), int.Parse(lbOrderID.Text.Substring(10, 2)), int.Parse(lbOrderID.Text.Substring(12, 2))).ToString(@"dddd, MMMM dd, yyyy    Tran\sac\tion Ti\me: hh:mm:ss tt");
                }
                catch (Exception ex)
                {
                    label1.Text = "";
                }

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (lbOrderID.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Item to Export!", "Scan IN&OUT");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|XML Files (*.xml)|*.xml";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName).ToLower().Contains("xml"))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add((DataTable)dgvOrders.DataSource);
                    ds.WriteXml(sfd.FileName);
                }
                else
                {
                    DataTable dt = (DataTable)dgvOrders.DataSource;
                    StreamWriter sw = new StreamWriter(sfd.FileName, false);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i != dt.Columns.Count - 1)
                        {
                            sw.Write(@"""" + dt.Columns[i].ColumnName + @""",");
                        }
                        else
                        {
                            sw.WriteLine(@"""" + dt.Columns[i].ColumnName + @"""");
                        }
                    }
                    foreach (DataRow item in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i != dt.Columns.Count - 1)
                            {
                                sw.Write(@"""" + item[i].ToString() + @""",");
                            }
                            else
                            {
                                sw.WriteLine(@"""" + item[i].ToString() + @"""");
                            }
                        }
                    }
                    sw.Close();
                    MessageBox.Show(" Order Number " + lbOrderID.Text + " Has Been Exported!");
                }
            }
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv|XML Files (*.xml)|*.xml";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                if (Path.GetExtension(sfd.FileName).ToLower().Contains("xml"))
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    ds.WriteXml(sfd.FileName);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName, false);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i != dt.Columns.Count - 1)
                        {
                            sw.Write(@"""" + dt.Columns[i].ColumnName + @""",");
                        }
                        else
                        {
                            sw.WriteLine(@"""" + dt.Columns[i].ColumnName + @"""");
                        }
                    }
                    foreach (DataRow item in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (i != dt.Columns.Count - 1)
                            {
                                sw.Write(@"""" + item[i].ToString() + @""",");
                            }
                            else
                            {
                                sw.WriteLine(@"""" + item[i].ToString() + @"""");
                            }
                        }
                    }
                    sw.Close();
                    MessageBox.Show("All Orders Has Been Exported!");
                }


            }
        }
    }
}
