using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScanINOUTVer2
{
    public partial class frmPackingListReport : Form
    {
        public int TQty;
        public frmPackingListReport()
        {
            InitializeComponent();
        }

        private void frmPackingListReport_Load(object sender, EventArgs e)
        {            
            
            
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            
        }

        //private void frmPackingListReport_Activated(object sender, EventArgs e)
        //{
        //    this.reportViewer1.RefreshReport();
        //}

        private void frmPackingListReport_Shown(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
