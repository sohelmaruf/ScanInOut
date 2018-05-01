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
    public partial class frmChangeColumnHeader : Form
    {
        public clm c;
        public frmChangeColumnHeader()
        {
            InitializeComponent();
        }

        private void frmChangeColumnHeader_Load(object sender, EventArgs e)
        {
            
        }

        private void btnChangeHeader_Click(object sender, EventArgs e)
        {
            try
            {
                if (c != null)
                {
                    c.clmtext = textBox1.Text.Trim();
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
