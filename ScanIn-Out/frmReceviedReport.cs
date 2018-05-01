using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
namespace ScanIn_Out
{

    public partial class frmReceviedReport : Form
    {
      public List<InventoryRecord> IRlist;
      public string pn;
        public frmReceviedReport()
        {
            InitializeComponent();
        }

        private void frmReceviedReport_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.LocalReport.DataSources.RemoveAt(0);
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("pmtTQ",IRlist.Sum(x=>x.Quantity).ToString()));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", IRlist));
            if (!string.IsNullOrWhiteSpace(pn))
            {
                reportViewer1.PrinterSettings.PrinterName = pn;    
            }
            
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
        }
    }
}
