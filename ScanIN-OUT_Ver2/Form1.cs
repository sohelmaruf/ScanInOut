using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SCANINOUTBL;


namespace ScanINOUTVer2
{
    public partial class Form1 : Form
    {
        private bool dragging;

        private Point pointClicked;
        public Inventory inventory;
        public DataLog datalogObj;
        public List<InventoryRecord> IL;
        public List<InventoryRecord> ILOUT;
        public bool SearchIsIn;
        public string ver;
        public frmPackingListReport packinglistreport;
        public frmReceivedReport receivedreport;

        public Form1()
        {
            if (Connection.HasConnection())
            {
                inventory = new Inventory();
                datalogObj = new DataLog();
                IL = new List<InventoryRecord>();
                ILOUT = new List<InventoryRecord>();
            }
            InitializeComponent();
        }
        public UCScanOUT scanOUT;
        public UCScanIN scanIN;
        public UCConfiguration configuration;
        public UCConiction coniction;
        public UCDataLog dataLog;
        public UCPurchaseOrders purchaseorders;
        public UCPurchaseOrdersLog purchaseorderslog;
        public UCCreatePurchaseOrders CreatePurchaseOrders;
        public UCCreatePurchaseOrdersIndividually CreatePurchaseOrdersIndividually;
        void LoadUC()
        {
            configuration = new UCConfiguration();
            pnlContent.Controls.Add(configuration);
            configuration.Left = 0;
            configuration.Top = 0;
            configuration.BringToFront();
            configuration.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            configuration.Visible = false;
            configuration.f1 = this;

            CreatePurchaseOrders = new UCCreatePurchaseOrders();
            pnlContent.Controls.Add(CreatePurchaseOrders);
            CreatePurchaseOrders.Left = 0;
            CreatePurchaseOrders.Top = 0;
            CreatePurchaseOrders.BringToFront();
            // CreatePurchaseOrders.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            CreatePurchaseOrders.Visible = false;

            CreatePurchaseOrdersIndividually = new UCCreatePurchaseOrdersIndividually();
            pnlContent.Controls.Add(CreatePurchaseOrdersIndividually);
            CreatePurchaseOrdersIndividually.Left = 0;
            CreatePurchaseOrdersIndividually.Top = 0;
            CreatePurchaseOrdersIndividually.BringToFront();
            // CreatePurchaseOrders.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            CreatePurchaseOrdersIndividually.Visible = false;
            


            coniction = new UCConiction();
            coniction.Mainfrm = this;
            pnlContent.Controls.Add(coniction);
            coniction.Left = 0;
            coniction.Top = 0;
            coniction.BringToFront();
            coniction.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            coniction.Visible = false;

            dataLog = new UCDataLog();
            dataLog.logdata = datalogObj;
            dataLog.f1 = this;
            pnlContent.Controls.Add(dataLog);
            dataLog.Left = 0;
            dataLog.Top = 0;
            dataLog.BringToFront();
            dataLog.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            dataLog.Visible = false;



            scanOUT = new UCScanOUT();
            pnlContent.Controls.Add(scanOUT);
            scanOUT.Left = 0;
            scanOUT.Top = 0;
            scanOUT.BringToFront();
            scanOUT.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            scanOUT.Visible = false;
            scanOUT.frmMain = this;



            scanIN = new UCScanIN();
            pnlContent.Controls.Add(scanIN);
            scanIN.Left = 0;
            scanIN.Top = 0;
            scanIN.BringToFront();
            scanIN.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            scanIN.Visible = false;
            scanIN.frmMain = this;


            purchaseorders = new UCPurchaseOrders();
            purchaseorders.frmMain = this;
            pnlContent.Controls.Add(purchaseorders);
            purchaseorders.Left = 0;
            purchaseorders.Top = 0;
            purchaseorders.BringToFront();
            purchaseorders.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            purchaseorders.Visible = false;

            purchaseorderslog = new UCPurchaseOrdersLog();
            purchaseorderslog.frmMain = this;
            pnlContent.Controls.Add(purchaseorderslog);
            purchaseorderslog.Left = 0;
            purchaseorderslog.Top = 0;
            purchaseorderslog.BringToFront();
            purchaseorderslog.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            purchaseorderslog.Visible = false;

        }

        void Highlight(string BtnName)
        {
            foreach (Control item in pnlMenu.Controls)
            {
                if (!item.Name.Contains("btn"))
                {
                    continue;
                }
                Button b = (Button)item;
                if (b.Name == BtnName)
                {
                    b.BackColor = Color.FromArgb(200, 214, 240);
                    
                    lblTitle.Text = ver + " - " + b.Text;
                }
                else
                {
                    b.BackColor = Color.CornflowerBlue;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ver = "Scan IN&&Out (Ver3.0.0)";
            lblTitle.Text = ver;
            try
            {
                LoadUC();
            }
            catch (Exception)
            {
                                
            }
            
            packinglistreport = new frmPackingListReport();
            receivedreport = new frmReceivedReport();
            packinglistreport.Show();
            packinglistreport.Hide();
            receivedreport.Show();
            receivedreport.Hide();

            if (!Connection.HasConnection())
            {
                Form f = new Form();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                UCConiction u = new UCConiction();
                u.Mainfrm = this;
                f.Height = u.Height + 20;
                f.Width = u.Width + 20;

                f.Controls.Add(u);
                u.Dock = DockStyle.Fill;

                f.ShowDialog();
                //Application.Restart();
                return;

                //btnDataConnection_Click(btnDataConnection, e);
                //btnScanIN.Enabled = false;
                //btnScanOut.Enabled = false;
                //btnDataLog.Enabled = false;
                //btnPurchaseOrders.Enabled = false;
                //lblConnection.Text = "...No Connection! ";

                

            }
            else
            {   
                System.Data.SqlClient.SqlConnection cn = Connection.GetConnection();
                lblConnection.Text = "...Connected to: "+cn.Database;
                //cn.Close();
            }                        
        }

        public void btnScanIN_Click(object sender, EventArgs e)
        {
            Highlight(btnScanIN.Name);
            pnlContent.Refresh();
            scanIN.Visible = true;
            TextBox t = (TextBox)scanIN.Controls["Panel1"].Controls["txtINBarcode"];
            
            scanIN.BringToFront();
            t.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You Want To Close The application", "Close Applacation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (llFullScreen.Text == "Full Screen Mode")
            {
                this.WindowState = FormWindowState.Maximized;
                llFullScreen.Text = "Window Mode";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                llFullScreen.Text = "Full Screen Mode";
            }
        }       

        public void btnScanOut_Click(object sender, EventArgs e)
        {
            Highlight(btnScanOut.Name);
            scanOUT.Visible = true;
            scanOUT.BringToFront();
            TextBox t = (TextBox)scanOUT.Controls["Panel1"].Controls["txtOUTBarcode"];
            t.Focus();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {

            Highlight(btnConfiguration.Name);
            configuration.Visible = true;
            configuration.BringToFront();


        }

        private void btnDataConnection_Click(object sender, EventArgs e)
        {
            Highlight(btnDataConnection.Name);
            coniction.Visible = true;
            coniction.BringToFront();
        }

        private void btnDataLog_Click(object sender, EventArgs e)
        {
            Highlight(btnDataLog.Name);
            dataLog.Visible = true;
            dataLog.BringToFront();
            dataLog.UCDataLog_Load(dataLog, e);
            
        }

        

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        

       

        private void Form1_Shown(object sender, EventArgs e)
        {


            frmLogin f = new frmLogin();
            f.ShowDialog();
            if (f.Tag == "close") Application.Exit();

            linkLabel1_LinkClicked(llFullScreen, null);
            

        }

        private void btProductLookUP_Click(object sender, EventArgs e)
        {
            frmChangePWD fcp = new frmChangePWD();
            fcp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath.ToLower().Replace("scanin-out_ver2.exe", "ProductLookUP.exe"), "1");
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));

                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);

                this.Location = pointMoveTo;
            }  
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scanIN == null)
            {
                return;
            }

            StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//INHW.txt",false);

            foreach (DataGridViewColumn  item in scanIN.dgvIN.Columns)
            {
                if (item.Visible)
                {
                    sw.WriteLine(item.Name + "^" + item.Width.ToString() + "^" + "True");
                }
                else
                {
                    sw.WriteLine(item.Name + "^" + item.Width.ToString() + "^" + "False");
                }
                
            }
            sw.Close();
            sw.Dispose();
            sw = null;

            StreamWriter sw2 = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//OUTHW.txt", false);

            foreach (DataGridViewColumn item in scanOUT.dgvOUT.Columns)
            {
                if (item.Visible)
                {
                    sw2.WriteLine(item.Name + "^" + item.Width.ToString() + "^" + "True");
                }
                else
                {
                    sw2.WriteLine(item.Name + "^" + item.Width.ToString() + "^" + "False");
                }
            }
            sw2.Close();
            sw2.Dispose();
            sw2 = null;
        }

        public void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            Highlight(btnPurchaseOrders.Name);
            purchaseorders.Visible = true;
            purchaseorders.BringToFront();
            Control[] c = purchaseorders.Controls.Find("cbSupplier", true);
            if (c != null)
            {
                c[0].Focus();
            }
        }

        private void btnPurchaseOrdersLog_Click(object sender, EventArgs e)
        {
            Highlight(btnPurchaseOrdersLog.Name);
            purchaseorderslog.Visible = true;
            purchaseorderslog.BringToFront();
            Control[] c = purchaseorders.Controls.Find("cbSupplier", true);
            if (c != null)
            {
                c[0].Focus();
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {

            Highlight(btnCreateOrder.Name);
            CreatePurchaseOrders.Visible = true;
            CreatePurchaseOrders.BringToFront();
            CreatePurchaseOrders.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            CreatePurchaseOrders.Dock = DockStyle.Fill;
            //Control[] c = CreatePurchaseOrders.Controls.Find("cbSupplier", true);
            //if (c != null)
            //{
            //    c[0].Focus();
            //}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Highlight(button2.Name);
            CreatePurchaseOrdersIndividually.Visible = true;
            CreatePurchaseOrdersIndividually.BringToFront();
            CreatePurchaseOrdersIndividually.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            CreatePurchaseOrdersIndividually.Dock = DockStyle.Fill;
        }


       
    }
}
