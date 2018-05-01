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

namespace ProductLookUP
{
    public partial class Form1 : Form
    {
        
        Inventory inventory;
        public DataTable dt;
        public DataTable dtref;
        public bool ismain = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!ismain)
            {
                frmLogin f = new frmLogin();
                f.ShowDialog();
                if (f.Tag == "close") Application.Exit();
                button1.Visible = false;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] p = Environment.GetCommandLineArgs();
                if (p.Length >= 1)
                {
                    ismain = true;
                    btnINAdd.Enabled = false;
                    button1.Visible = true;
                }
                inventory = new Inventory();
                fillheaders();
                textBox1.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Please Set the connection to the database at Scan IN&OUT Program First. Then, Re-open this program!");
                this.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (ismain)
            {
                dataGridView1.Columns[clmSave.Name].Visible = false;
                dataGridView1.Columns[clmUndo.Name].Visible = false;
            }
            dt = inventory.GetDataLookUP(textBox1.Text, textBox2.Text);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["LocalSKU"] };
            dtref = dt.Copy();
            fill();
            if (dataGridView1.Rows.Count <= 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            
        }

        void fill()
        {
            
            dataGridView1.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.Tag == "OK")
            {
                ismain = false;
                button1.Visible = false;
                btnINAdd.Enabled = true;

                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (item.Name == "LocalSKU")
                    {
                        continue;
                    }
                    item.ReadOnly = false;
                }

                //dataGridView1.Columns[clmSave.Name].Visible = true;
                //dataGridView1.Columns[clmUndo.Name].Visible = true;
            }
        }

        private void btnINAdd_Click(object sender, EventArgs e)
        {
            frmChangePWD f = new frmChangePWD();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (inventory.UpDateLookUp(dt.Rows[e.RowIndex]))
                    {
                        DataRow dtt = dt.Rows[e.RowIndex];
                        for (int i = 0; i < dtt.ItemArray.Length - 1; i++)
                        {
                            dtref.Rows[e.RowIndex][i] = dtt[i];
                        }

                    }  
                }
                if (e.ColumnIndex == 1)
                {
                    DataRow drref = dtref.Rows.Find(dt.Rows[e.RowIndex]["LocalSKU"]);
                    for (int i = 0; i < drref.ItemArray.Length; i++)
                    {
                        dt.Rows[e.RowIndex][i] = drref[i];
                    }
                }
            }
        }

        private void btnRenameHeaders_Click(object sender, EventArgs e)
        {
            frmHeadersName f = new frmHeadersName();
            f.ShowDialog();
            fillheaders();
        }
        public void fillheaders()
        {
            FileInfo f = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNLU.txt");
            if (!f.Exists)
            {
                return;
            }
            StreamReader sr = new StreamReader(f.FullName);

            if (dataGridView1.Columns[0].HeaderText == "Save")
            {
                for (int i = 2; i < 16; i++)
                {
                    dataGridView1.Columns[i].HeaderText = sr.ReadLine().Trim();
                }    
            }
            else
            {
                for (int i = 0; i < 14; i++)
                {
                    dataGridView1.Columns[i].HeaderText = sr.ReadLine().Trim();
                }
            }
            
            sr.Close();
            sr.Dispose();
            sr = null;
            dataGridView1.Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(button3, new EventArgs());
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button3_Click(button3, new EventArgs());
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }
            if (e.KeyChar == 126)
            {
                textBox1.Text = "";
                textBox1.Focus();
                e.Handled = true;
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (inventory.UpDateLookUp(dt.Rows[e.RowIndex]))
            {
                DataRow dtt = dt.Rows[e.RowIndex];
                for (int i = 0; i < dtt.ItemArray.Length - 1; i++)
                {
                    dtref.Rows[e.RowIndex][i] = dtt[i];
                }

            }  
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            System.Windows.Forms.SendKeys.Send(@"~");
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 126)
            {
                textBox1.Text = "";
                textBox1.Focus();
                e.Handled = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox t = (TextBox)e.Control;
            t.KeyPress += new KeyPressEventHandler(button3_KeyPress);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains('~') && textBox1.Text.Contains('/'))
            {
                textBox1.Text = textBox1.Text.Replace("~", "").Replace("/", "");
                button3_Click(button3, new EventArgs());
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        
        
    }
}
