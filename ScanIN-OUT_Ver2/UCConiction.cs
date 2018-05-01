using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace ScanINOUTVer2
{
    public partial class UCConiction : UserControl
    {
        public Form1 Mainfrm;
        public UCConiction()
        {
            InitializeComponent();
        }

        private void UCConiction_SizeChanged(object sender, EventArgs e)
        {
            //int x = this.Width - 960;
            //int y = this.Height - 399;
            //x = x / 2;
            //y = y / 2;

            //if (x != 0) panel1.Left += x; else panel1.Left = 7;
            //if (y != 0) panel1.Top += y; else panel1.Top = 28;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pnlUserAccess.Enabled = false;
                txtUserName.Text = "";
                txtPwd.Text = "";
            }
            else
            {
                pnlUserAccess.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)
            {
                pnlUserAccess.Enabled = false;
            }
            else
            {
                pnlUserAccess.Enabled = true;

            }
        }

        private void UCConiction_Load(object sender, EventArgs e)
        {

            radioButton1.Checked = true;
            if (Connection.HasConnection())            
            {
                SqlConnection cn = Connection.GetConnection();
                txtCurrentlyCN.Text = string.Format("Server Name= {0}               Database= {1}", cn.DataSource, cn.Database);
                cn.Close();
            }
            filllist();
        }

        private void cmServerName_DropDown(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                System.Data.DataTable table = instance.GetDataSources();

                cmServerName.DataSource = table;
                cmServerName.DisplayMember = "ServerName";
                cmServerName.ValueMember = "InstanceName";
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("An error has occured while trying to connect to SQL Server. Please contact the administrator!","Scan IN&OUT",MessageBoxButtons.OK,MessageBoxIcon.Warning);                
            }
            
        }

        private void cmDatabase_DropDown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmServerName.Text))
            {
                this.Cursor = Cursors.WaitCursor;
                string conntxt = "";
                if (radioButton1.Checked)
                {
                    conntxt = string.Format("Data Source={0};Integrated Security=True", cmServerName.Text, cmDatabase.Text);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtPwd.Text) || string.IsNullOrWhiteSpace(txtUserName.Text))
                    {
                        MessageBox.Show("Please insert User Name/PassWord");
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    conntxt = string.Format("Data Source={0};User ID={2};Password={3};", cmServerName.Text, cmDatabase.Text, txtUserName.Text.Trim(), txtPwd.Text.Trim());
                }

                using (var con = new SqlConnection(conntxt))
                {
                    try
                    {
                        
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    cmDatabase.DataSource = databases;
                    cmDatabase.DisplayMember = "database_name";
                    cmDatabase.ValueMember = "dbid";
                    con.Close();
                    this.Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("error: 40"))
                        {
                            MessageBox.Show("An error has occured while trying to connect to SQL Server. Please contact the administrator!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select the server name!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            string conntxt = "";
            if (radioButton1.Checked)
            {
                conntxt = string.Format("Data Source={0};Initial catalog={1};Integrated Security=True", cmServerName.Text, cmDatabase.Text);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtPwd.Text) || string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Please insert User Name/PassWord");
                    this.Cursor = Cursors.Default;
                    return;
                }
                conntxt = string.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3};", cmServerName.Text, cmDatabase.Text, txtUserName.Text.Trim(), txtPwd.Text.Trim());
            }
            if (TestCon(conntxt)) MessageBox.Show("Test Connection Succeeded!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
        }
        bool  TestCon(string Cn)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(Cn);
            try
            {
                con.Open(); 
                result = true;
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("error: 40"))
                {
                    MessageBox.Show("An error has occured while trying to connect to SQL Server. Please contact the administrator!", "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Scan IN&OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            finally
            {
                con.Close();                
            }
            return result;
        
        
        
        }
        void filllist()
        {
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            if (!fi.Exists)
            {
                fi = null;
                dataGridView1.Rows.Clear();
                return;
            }
            fi = null;
            dataGridView1.Rows.Clear();
            StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = dataGridView1.Rows.Count;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = s.Split(';')[0].Split('=')[1].Trim();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = s.Split(';')[1].Split('=')[1].Trim();
                if (s.Split(';')[2].Contains("ID"))
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = s.Split(';')[2].Split('=')[1].Trim();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = "*****";
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value = s.Split(';')[3].Split('=')[1].Trim();
                }

            }
            sr.Close();
            sr.Dispose();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            string conntxt = "";
            if (radioButton1.Checked)
            {
                conntxt = string.Format("Data Source={0};Initial catalog={1};Integrated Security=True", cmServerName.Text, cmDatabase.Text);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtPwd.Text) || string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("Please insert User Name/PassWord");
                    this.Cursor = Cursors.Default;
                    return;
                }
                conntxt = string.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3};", cmServerName.Text, cmDatabase.Text, txtUserName.Text.Trim(), txtPwd.Text.Trim());
            }
            if(!TestCon(conntxt))return;
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt", true);
            sw.WriteLine(conntxt);
            sw.Close();
            sw.Dispose();
            sw = null;
            filllist();
            this.Cursor = Cursors.Default;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string conntxt = "";
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value == null)
            {
                conntxt = string.Format("Data Source={0};Initial catalog={1};Integrated Security=True", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
            }
            else
            {                
                conntxt = string.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3};", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString().Trim(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].Value.ToString().Trim());
            }
            if (TestCon(conntxt)) MessageBox.Show("Test Connection Succeeded!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt");
            List<string> c = new List<string>();
            while (!sr.EndOfStream)
            {
                c.Add(sr.ReadLine());
            }
            sr.Close();
            sr.Dispose();
            sr = null;

            c.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);

            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//dbconns.txt",false);
            for (int i = 0; i < c.Count; i++)
            {                
                sw.WriteLine(c[i]);
            }
            sw.Close();
            sw.Dispose();
            sw = null;
            filllist();
        }

        private void btnDefaultCn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string conntxt = "";
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value == null)
            {
                conntxt = string.Format("Data Source={0};Initial catalog={1};Integrated Security=True", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
            }
            else
            {
                conntxt = string.Format("Data Source={0};Initial catalog={1};User ID={2};Password={3};", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].Value.ToString().Trim(), dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].Value.ToString().Trim());
            }
            if (TestCon(conntxt))
            {
                Connection.SetConnection(conntxt);
                if (Connection.HasConnection())
                {
                    try
                    {
                        Mainfrm.inventory = new Inventory();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    
                    Inventory.conn = Connection.GetConnection();
                    SqlConnection cn = Connection.GetConnection();
                    txtCurrentlyCN.Text = string.Format("Server Name= {0}               Database= {1}", cn.DataSource, cn.Database);
                    Mainfrm.lblConnection.Text = "...Connected to: " + cn.Database;
                    MessageBox.Show("You are connected to: " + cn.Database, "Scan IN&OUT. Application is going to restart to apply the new connection.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                    return;
                    //cn.Close();
                    
                }
            }
            this.Cursor = Cursors.Default;
        }
    }
}
