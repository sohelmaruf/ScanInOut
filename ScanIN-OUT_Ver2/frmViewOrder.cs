using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCANINOUTBL;

namespace ScanINOUTVer2
{
    public partial class frmViewOrder : Form
    {
        public int OrderNumber;
        public int PONumber;
        public DateTime PODate;
        public bool IsCreatePO;
        
        public frmViewOrder()
        {
            InitializeComponent();
        }

        private void frmViewOrder_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsCreatePO)
                {
                    dgvDetails.Columns[7].Visible = false;
                    dgvDetails.Columns[8].Visible = false;
                }

                OrderObj ord = Order.GetByOrderNumber(OrderNumber);
                List<OrderDetailObj> odo = OrderDetail.GetByOrderNumber(OrderNumber, PONumber, PODate);
                lblBalanceDue.Text = ord.BalanceDue.ToString("$0.00");
                lblCartName.Text = ord.CartName;
                lblComment.Text = ord.Comment;
                lblCustomerAddress.Text = ord.CustomerAddress;
                lblCustomerAddress2.Text = ord.CustomerAddress2;
                lblCustomerCity.Text = ord.CustomerCity;
                lblCustomerCompany.Text = ord.CustomerCompany;
                lblCustomerCountry.Text = ord.CustomerCountry;
                lblCustomerEmail.Text = ord.CustomerEmail;
                lblCustomerName.Text = ord.CustomerName;
                lblCustomerPhone.Text = ord.CustomerPhone;
                lblCustomerState.Text = ord.CustomerState;
                lblCustomerZip.Text = ord.CustomerZip;
                lblOrderDate.Text = ord.OrderDate == DateTime.MinValue?"": ord.OrderDate.ToShortDateString();
                lblOrderNumber.Text = ord.OrderNumber.ToString();
                lblShipAddress.Text = ord.ShipAddress;
                lblShipAddress2.Text = ord.ShipAddress2;
                lblShipCity.Text = ord.ShipCity;
                lblShipCompany.Text = ord.ShipCompany;
                lblShipCountry.Text = ord.ShipCountry;
                lblShipName.Text = ord.ShipName;
                lblShipPhone.Text = ord.ShipPhone;
                lblShipState.Text = ord.ShipState;
                lblShipZip.Text = ord.ShipZip;
                lblSOrderNumber.Text = ord.SourceOrderNumber.ToString();
                dgvDetails.AutoGenerateColumns = false;
                dgvDetails.DataSource = odo;
                dgvDetails.Refresh();
            }
            catch (Exception)
            {
                                
            }
            
        }
    }
}
