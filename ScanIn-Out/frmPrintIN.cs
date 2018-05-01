using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenCode128;
using System.IO;

namespace ScanIn_Out
{
    public partial class frmPrintIN : Form
    {
        public string SKU;
        public string ItemName;
        public string Barcode;
        public string Price;
        public frmPrintIN()
        {
            InitializeComponent();
        }

        private void frmPrintIN_Load(object sender, EventArgs e)
        {
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtSKU",SKU));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtItemName", ItemName));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtBarcode", Barcode));
            FileInfo f = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//tempbarcode.jpg");
            if (f.Exists)
            {
                f.Delete();
            }
            Image myimg = Code128Rendering.MakeBarcodeImage(Barcode, 2, true);
            myimg.Save(f.FullName);
            reportViewer1.LocalReport.EnableExternalImages = true;            
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtBarcodeImage", "file:///" + f.FullName));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtPrice", Price));
            reportViewer1.RefreshReport();
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
