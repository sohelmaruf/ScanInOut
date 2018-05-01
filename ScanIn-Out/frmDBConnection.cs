using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using SCANINOUTBL;
using System.IO;

namespace ScanIn_Out
{
    public partial class frmDBConnection : Form
    {
        public Form1 f1;
        string defconn;
        public frmDBConnection()
        {
            InitializeComponent();
        }
        void filllist()
        {
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            if (!fi.Exists)
            {
                fi = null;
                listBox1.Items.Clear();
                return;
            }
            fi = null;
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            while (!sr.EndOfStream)
            {
                listBox1.Items.Add(sr.ReadLine());
            }
            sr.Close();
            sr.Dispose();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void frmDBConnection_Load(object sender, EventArgs e)
        {

            filllist();
            if (Connection.HasConnection())
            {
                
                textBox3.Text = Connection.GetConnection().ConnectionString;
                listBox1.SelectedItem = textBox3.Text;
                defconn = textBox3.Text;
            }                        
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "ServerName";
            comboBox1.ValueMember = "InstanceName";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                string conntxt = "";
                if (radioButton1.Checked)
                {
                    conntxt = string.Format("Data Source={0};Integrated Security=True", comboBox1.Text, comboBox2.Text);
                }
                else
                {
                    conntxt = string.Format("Data Source={0};User ID={2};Password={3};", comboBox1.Text, comboBox2.Text, textBox1.Text.Trim(), textBox2.Text);
                }

                using(var con = new SqlConnection(conntxt))
                {
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    comboBox2.DataSource = databases;
                    comboBox2.DisplayMember = "database_name";
                    comboBox2.ValueMember = "dbid";
                    con.Close();
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count <=0)
            {
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(listBox1.SelectedItem.ToString().Trim());
                cn.Open();
                cn.Close();

                Connection.SetConnection(listBox1.SelectedItem.ToString().Trim());
                MessageBox.Show("Connection Saved!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f1.inventory = new Inventory();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CollectConnectionString())
            {
                return;
            }

            try
            {
                SqlConnection cn = new SqlConnection(textBox3.Text.Trim());
                cn.Open();
                cn.Close();
                MessageBox.Show("Test Connection Succeeded!","Connection",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CollectConnectionString()
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) )
            {
                MessageBox.Show("Not Valid Connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radioButton2.Checked && string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You must Enter UserName/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radioButton1.Checked)
            {
                textBox3.Text = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True",comboBox1.Text,comboBox2.Text);
            }
            else
            {
                textBox3.Text = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",comboBox1.Text,comboBox2.Text,textBox1.Text.Trim(),textBox2.Text);
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CollectConnectionString())
	        {
                StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt",true);
                sw.WriteLine(textBox3.Text);
                sw.Close();
                sw.Dispose();
                filllist();
	        }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            if (fi.Exists)
            {
                fi.Delete();
            }

            fi = null;
            filllist();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
