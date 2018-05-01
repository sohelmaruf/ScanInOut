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
    public partial class frmChangePWD2 : Form
    {
        string pwd;
        public frmChangePWD2()
        {
            InitializeComponent();
        }

        private void frmChangePWD2_Load(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != pwd)
            {
                MessageBox.Show("Invalid old password");
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("New password Mismatched!");
                return;
            }
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//POPWD.txt", false);
            sw.Write(textBox2.Text.Trim());
            sw.Close();
            sw.Dispose();
            sw = null;
            MessageBox.Show("Saved Successfully!");
            this.Close();
        }
    }
}
