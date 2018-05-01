using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;
using Microsoft.Reporting.WinForms;
namespace ScanIn_Out
{
    public partial class frmpackinglist : Form
    {
        public List<InventoryRecord> IRList;
        public string pn;
        public frmpackinglist()
        {
            InitializeComponent();
        }

        private void frmpackinglist_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.RemoveAt(0);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", IRList));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("TQ",IRList.Sum(x=>x.Quantity).ToString()));
            if (!string.IsNullOrWhiteSpace(pn))
            {
                reportViewer1.PrinterSettings.PrinterName = pn;
            }
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
        }
    }
}
