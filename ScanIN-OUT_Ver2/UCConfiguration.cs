using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScanINOUTVer2
{
    public partial class UCConfiguration : UserControl
    {
        public Form1 f1;
        public UCConfiguration()
        {
            InitializeComponent();
        }

        private void UCConfiguration_SizeChanged(object sender, EventArgs e)
        {
            //int x = this.Width - 960;
            //int y = this.Height - 399;
            //x = x / 2;
            //y = y / 2;

            //if (x != 0) panel1.Left += x; else panel1.Left = 7 ;
            //if (y != 0) panel1.Top += y; else panel1.Top = 28;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNIN.txt", false);
            sw.WriteLine(txtNumIn1.Text);
            sw.WriteLine(txtBarcodeIn1.Text);
            sw.WriteLine(txtSKUIn1.Text);
            sw.WriteLine(txtSupplierSUKIn1.Text);
            sw.WriteLine(txtItemNameIN1.Text);
            sw.WriteLine(txtPriceIn1.Text);
            sw.WriteLine(txtTotalQtyIn1.Text);
            sw.WriteLine(txtPrintIn1.Text);
            sw.WriteLine(txtOuickPrintIn1.Text);
            sw.WriteLine(txtPrintFormateIn1.Text);
            sw.WriteLine(txtCancelIn1.Text);
            sw.WriteLine(txtOrderNumIn1.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
            f1.scanIN.HeardersName();
            MessageBox.Show("Scanning In Column Headers Has Been Updated");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNOUT.txt", false);
            sw.WriteLine(txtNumOut1.Text);
            sw.WriteLine(txtBarcodeOut1.Text);
            sw.WriteLine(txtSKUOut1.Text);
            sw.WriteLine(txtSupplierSUKOut1.Text);
            sw.WriteLine(txtItemNameOut1.Text);
            sw.WriteLine(txtPriceOut1.Text);
            sw.WriteLine(txtTotalQtyOut1.Text);
            sw.WriteLine(txtPrintOut1.Text);
            sw.WriteLine(txtOuickPrintOut1.Text);
            sw.WriteLine(txtPrintFormateOut1.Text);
            sw.WriteLine(txtCancelOut1.Text);
            sw.WriteLine(txtOrderNumOut1.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
            f1.scanOUT.HeadersName();
            MessageBox.Show("Scanning Out Column Headers Has Been Updated");
        }

        private void UCConfiguration_Load(object sender, EventArgs e)
        {

            foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbReport1.Items.Add(item);
                cbBarcode1.Items.Add(item);
            }

            FileInfo dpf = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPF.txt");
            if (dpf.Exists)
            {
                StreamReader sr = new StreamReader(dpf.FullName);
                string xx = sr.ReadToEnd().Trim();
                sr.Close();
                cbDPF.Text = xx;

            }

            FileInfo fr = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPR.txt");
            if (fr.Exists)
            {
                StreamReader sr = new StreamReader(fr.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                cbReport1.Text = xx;

            }
            FileInfo frt = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRT.txt");
            if (frt.Exists)
            {
                StreamReader sr = new StreamReader(frt.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                cbReportType.Text = xx;

            }
            FileInfo frw = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRW.txt");
            if (frw.Exists)
            {
                StreamReader sr = new StreamReader(frw.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                txtReportWidth.Text = xx;

            }
            FileInfo frh = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRH.txt");
            if (frh.Exists)
            {
                StreamReader sr = new StreamReader(frh.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                txtReportHeight.Text = xx;

            }
            FileInfo fb = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPB.txt");
            if (fb.Exists)
            {
                StreamReader sr = new StreamReader(fb.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                cbBarcode1.Text = xx;

            }
            FileInfo fbt = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBT.txt");
            if (fbt.Exists)
            {
                StreamReader sr = new StreamReader(fbt.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                cbBarcodeType.Text = xx;

            }
            FileInfo fbw = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBW.txt");
            if (fbw.Exists)
            {
                StreamReader sr = new StreamReader(fbw.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                txtBarcodeWidth.Text = xx;

            }
            FileInfo fbh = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBH.txt");
            if (fbh.Exists)
            {
                StreamReader sr = new StreamReader(fbh.FullName);
                string xx = sr.ReadToEnd();
                sr.Close();
                txtBarcodeHeight.Text = xx;

            }
            FileInfo fhnin = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNIN.txt");
            if (fhnin.Exists)
            {
                StreamReader sr = new StreamReader(fhnin.FullName);
                txtNumIn1.Text = sr.ReadLine();
                txtBarcodeIn1.Text = sr.ReadLine();
                txtSKUIn1.Text = sr.ReadLine();
                txtSupplierSUKIn1.Text = sr.ReadLine();
                txtItemNameIN1.Text = sr.ReadLine();
                txtPriceIn1.Text = sr.ReadLine();
                txtTotalQtyIn1.Text = sr.ReadLine();
                txtPrintIn1.Text = sr.ReadLine();
                txtOuickPrintIn1.Text = sr.ReadLine();
                txtPrintFormateIn1.Text = sr.ReadLine();
                txtCancelIn1.Text = sr.ReadLine();
                txtOrderNumIn1.Text = sr.ReadLine();
                sr.Close();

            }

            FileInfo fhnout = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//HNOUT.txt");
            if (fhnout.Exists)
            {
                StreamReader sr = new StreamReader(fhnout.FullName);
                txtNumOut1.Text = sr.ReadLine();
                txtBarcodeOut1.Text = sr.ReadLine();
                txtSKUOut1.Text = sr.ReadLine();
                txtSupplierSUKOut1.Text = sr.ReadLine();
                txtItemNameOut1.Text = sr.ReadLine();
                txtPriceOut1.Text = sr.ReadLine();
                txtTotalQtyOut1.Text = sr.ReadLine();
                txtPrintOut1.Text = sr.ReadLine();
                txtOuickPrintOut1.Text = sr.ReadLine();
                txtPrintFormateOut1.Text = sr.ReadLine();
                txtCancelOut1.Text = sr.ReadLine();
                txtOrderNumOut1.Text = sr.ReadLine();
                sr.Close();
            }
        }

        private void cbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPR.txt", false);
            sw.WriteLine(cbReport1.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
           // MessageBox.Show(@"Default Printer To Reports Has Benn Selected as """ + cbReport.Text + @"""");
        }

        private void cbBarCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPB.txt", false);
            sw.WriteLine(cbBarcode1.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
           // MessageBox.Show(@"Default Printer To Reports Has Benn Selected as """ + cbBarCode.Text + @"""");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRT.txt", false);
            sw.WriteLine(cbReportType.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        private void cbReportWidth_Leave(object sender, EventArgs e)
        {
                DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
                if (!f.Exists)
                {
                    f.Create();
                }
                f = null;
                StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRW.txt", false);
                sw.WriteLine(Math.Round(txtReportWidth.Value,2));
                sw.Close();
                sw.Dispose();
                sw = null;
            
         
        }

        private void cbReportHeight_Leave(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPRH.txt", false);
            sw.WriteLine(Math.Round(txtReportHeight.Value,2));
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        private void cbBarcodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBT.txt", false);
            sw.WriteLine(cbBarcodeType.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        private void cbBarcodeWidth_Leave(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBW.txt", false);
            sw.WriteLine(Math.Round(txtBarcodeWidth.Value,2));
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        private void txtBarcodeHeight_Leave(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPBH.txt", false);
            sw.WriteLine(Math.Round(txtBarcodeHeight.Value,2));
            sw.Close();
            sw.Dispose();
            sw = null;
        }

        private void txtReportWidth_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbDPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo f = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!f.Exists)
            {
                f.Create();
            }
            f = null;
            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//DPF.txt", false);
            sw.WriteLine(cbDPF.Text);
            sw.Close();
            sw.Dispose();
            sw = null;
        }
    }
}
