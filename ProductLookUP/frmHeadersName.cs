using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProductLookUP
{
    public partial class frmHeadersName : Form
    {
        public frmHeadersName()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNLU.txt", false);
            sw.WriteLine(textlocalSKU.Text);
            sw.WriteLine(txtItemName.Text);
            sw.WriteLine(txtPrice.Text);
            sw.WriteLine(txtPrice2.Text);
            sw.WriteLine(txtPrice3.Text);
            sw.WriteLine(txtQOH.Text);
            sw.WriteLine(txtInteger1.Text);
            sw.WriteLine(txtInteger2.Text);
            sw.WriteLine(txtInteger3.Text);
            sw.WriteLine(txtInteger4.Text);
            sw.WriteLine(txtInteger5.Text);
            sw.WriteLine(txtBarcode.Text);
            sw.WriteLine(txtReorderPoint.Text);
            sw.WriteLine(txtRecordQuantity.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
            this.Close();


        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void frmHeadersName_Load(object sender, EventArgs e)
        {
            FileInfo fhnin = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNLU.txt");
            if (fhnin.Exists)
            {
                StreamReader sr = new StreamReader(fhnin.FullName);
                textlocalSKU.Text = sr.ReadLine();
                txtItemName.Text = sr.ReadLine();
                txtPrice.Text = sr.ReadLine();
                txtPrice2.Text = sr.ReadLine();
                txtPrice3.Text = sr.ReadLine();
                txtQOH.Text = sr.ReadLine();
                txtInteger1.Text = sr.ReadLine();
                txtInteger2.Text = sr.ReadLine();
                txtInteger3.Text = sr.ReadLine();
                txtInteger4.Text = sr.ReadLine();
                txtInteger5.Text = sr.ReadLine();
                txtBarcode.Text = sr.ReadLine();
                txtReorderPoint.Text = sr.ReadLine();
                txtRecordQuantity.Text = sr.ReadLine();
                sr.Close();

            }
        }

        private void txtPrice2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
