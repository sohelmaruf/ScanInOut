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
    public partial class frmPOLogin : Form
    {
        public string pwd;
        public frmPOLogin()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == pwd)
            {
                this.Tag = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Password!");
            }
        }

        private void frmPOLogin_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//POPWD.txt");
            if (fi.Exists)
            {
                StreamReader sr = new StreamReader(fi.FullName);
                pwd = sr.ReadToEnd().Trim();
                sr.Close();
                sr.Dispose();
                sr = null;
            }
            else
            {
                StreamWriter sw = new StreamWriter(fi.FullName, false);
                sw.Write("admin");
                sw.Close();
                sw.Dispose();
                sw = null;

                StreamReader sr = new StreamReader(fi.FullName);
                pwd = sr.ReadToEnd().Trim();
                sr.Close();
                sr.Dispose();
                sr = null;
            }
        }
    }
}
