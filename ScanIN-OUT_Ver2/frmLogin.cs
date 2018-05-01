using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScanINOUTVer2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//pwdSIO.txt");
            if (!f.Exists)
            {
                StreamWriter sw = new StreamWriter(f.FullName);
                sw.WriteLine("admin");
                sw.Close();
                sw.Dispose();
                sw = null;
            }

            textBox1.Focus();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Tag != "OK")
            {
                this.Tag = "close";    
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please Enter your Password!");
                return;
            }



            StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//pwdSIO.txt");
            string x = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;

            if (textBox1.Text.Trim() == x.Trim())
            {
                this.Tag = "OK";
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}
