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
    public partial class frmChangePWD : Form
    {
        public frmChangePWD()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {           
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
                MessageBox.Show("Please Enter your Current Password!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }
            StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//pwdSIO.txt");
            string x = sr.ReadLine();
            sr.Close();
            sr.Dispose();
            sr = null;
            if (textBox1.Text.Trim() != x.Trim())
            {
                MessageBox.Show("Invalid Current Password!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please Enter your New Password!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password Not Matched!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }


            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//pwdSIO.txt",false);
            sw.WriteLine(textBox3.Text.Trim());
            sw.Close();
            sw.Dispose();
            sw = null;
            this.Close();            

        }
    }
}
