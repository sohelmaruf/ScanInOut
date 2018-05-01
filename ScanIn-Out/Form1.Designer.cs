namespace ScanIn_Out
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlDBConnection = new System.Windows.Forms.Panel();
            this.lblConnection = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlScanOut = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlScanIn = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbScanningIN = new System.Windows.Forms.GroupBox();
            this.pnlINStatus = new System.Windows.Forms.Panel();
            this.txtINTotalUSKU = new System.Windows.Forms.Label();
            this.txtINTotalSKU = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnINAdd = new System.Windows.Forms.Button();
            this.txtINSKU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtINBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnINUpdate = new System.Windows.Forms.Button();
            this.btnINCIL = new System.Windows.Forms.Button();
            this.btnINCLSI = new System.Windows.Forms.Button();
            this.dgvIN = new System.Windows.Forms.DataGridView();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINTotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmINCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmINOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.gbScanningOUT = new System.Windows.Forms.GroupBox();
            this.pnlOUTStatus = new System.Windows.Forms.Panel();
            this.txtOUTTotalUSKU = new System.Windows.Forms.Label();
            this.txtOUTTotalSKU = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnOUTAdd = new System.Windows.Forms.Button();
            this.txtOUTSKU = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOUTBarcode = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOUTUpdate = new System.Windows.Forms.Button();
            this.btnOUTCEL = new System.Windows.Forms.Button();
            this.btnOUTCLSI = new System.Windows.Forms.Button();
            this.dgvOUT = new System.Windows.Forms.DataGridView();
            this.seqOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOutBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOUTSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOUTItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOUTTotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOUTPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOUTPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmOUTCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.tmrINFocus = new System.Windows.Forms.Timer();
            this.tmrOUTFocus = new System.Windows.Forms.Timer();
            this.tmrBarcodeIN = new System.Windows.Forms.Timer();
            this.tmrBarcodeOut = new System.Windows.Forms.Timer();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.pnlDBConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlScanOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlScanIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbScanningIN.SuspendLayout();
            this.pnlINStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIN)).BeginInit();
            this.gbScanningOUT.SuspendLayout();
            this.pnlOUTStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOUT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pnlDBConnection);
            this.panel1.Controls.Add(this.pnlScanOut);
            this.panel1.Controls.Add(this.pnlScanIn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 60);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.ForeColor = System.Drawing.Color.SlateGray;
            this.label9.Location = new System.Drawing.Point(655, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "Default Printer For Reports:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(658, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 24);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(869, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Data Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // pnlDBConnection
            // 
            this.pnlDBConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDBConnection.Controls.Add(this.lblConnection);
            this.pnlDBConnection.Controls.Add(this.label8);
            this.pnlDBConnection.Controls.Add(this.pictureBox3);
            this.pnlDBConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDBConnection.Location = new System.Drawing.Point(277, 5);
            this.pnlDBConnection.Name = "pnlDBConnection";
            this.pnlDBConnection.Size = new System.Drawing.Size(248, 48);
            this.pnlDBConnection.TabIndex = 7;
            this.pnlDBConnection.Click += new System.EventHandler(this.pnlDBConnection_Click);
            this.pnlDBConnection.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.pnlDBConnection.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblConnection.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblConnection.Location = new System.Drawing.Point(49, 22);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(87, 14);
            this.lblConnection.TabIndex = 2;
            this.lblConnection.Text = "Connected to:";
            this.lblConnection.Click += new System.EventHandler(this.pnlDBConnection_Click);
            this.lblConnection.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.lblConnection.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Location = new System.Drawing.Point(49, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Database Connection";
            this.label8.Click += new System.EventHandler(this.pnlDBConnection_Click);
            this.label8.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pnlDBConnection_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // pnlScanOut
            // 
            this.pnlScanOut.Controls.Add(this.label7);
            this.pnlScanOut.Controls.Add(this.pictureBox2);
            this.pnlScanOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlScanOut.Location = new System.Drawing.Point(138, 5);
            this.pnlScanOut.Name = "pnlScanOut";
            this.pnlScanOut.Size = new System.Drawing.Size(133, 48);
            this.pnlScanOut.TabIndex = 6;
            this.pnlScanOut.Click += new System.EventHandler(this.panel3_Click);
            this.pnlScanOut.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.pnlScanOut.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(49, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Scanning Out";
            this.label7.Click += new System.EventHandler(this.panel3_Click);
            this.label7.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.label7.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.panel3_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // pnlScanIn
            // 
            this.pnlScanIn.Controls.Add(this.label6);
            this.pnlScanIn.Controls.Add(this.pictureBox1);
            this.pnlScanIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlScanIn.Location = new System.Drawing.Point(11, 5);
            this.pnlScanIn.Name = "pnlScanIn";
            this.pnlScanIn.Size = new System.Drawing.Size(126, 48);
            this.pnlScanIn.TabIndex = 5;
            this.pnlScanIn.Click += new System.EventHandler(this.panel4_Click);
            this.pnlScanIn.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.pnlScanIn.MouseLeave += new System.EventHandler(this.panel4_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(49, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "Scanning In";
            this.label6.Click += new System.EventHandler(this.panel4_Click);
            this.label6.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.panel4_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.panel4_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.panel4_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.panel4_MouseLeave);
            // 
            // gbScanningIN
            // 
            this.gbScanningIN.Controls.Add(this.pnlINStatus);
            this.gbScanningIN.Controls.Add(this.btnINAdd);
            this.gbScanningIN.Controls.Add(this.txtINSKU);
            this.gbScanningIN.Controls.Add(this.label2);
            this.gbScanningIN.Controls.Add(this.txtINBarcode);
            this.gbScanningIN.Controls.Add(this.label1);
            this.gbScanningIN.Controls.Add(this.btnINUpdate);
            this.gbScanningIN.Controls.Add(this.btnINCIL);
            this.gbScanningIN.Controls.Add(this.btnINCLSI);
            this.gbScanningIN.Controls.Add(this.dgvIN);
            this.gbScanningIN.Controls.Add(this.shapeContainer1);
            this.gbScanningIN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gbScanningIN.ForeColor = System.Drawing.Color.White;
            this.gbScanningIN.Location = new System.Drawing.Point(12, 66);
            this.gbScanningIN.Name = "gbScanningIN";
            this.gbScanningIN.Size = new System.Drawing.Size(950, 374);
            this.gbScanningIN.TabIndex = 1;
            this.gbScanningIN.TabStop = false;
            this.gbScanningIN.Text = "Scanning IN:";
            this.gbScanningIN.Visible = false;
            this.gbScanningIN.Enter += new System.EventHandler(this.gbScanningIN_Enter);
            // 
            // pnlINStatus
            // 
            this.pnlINStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlINStatus.BackColor = System.Drawing.Color.LightCyan;
            this.pnlINStatus.Controls.Add(this.txtINTotalUSKU);
            this.pnlINStatus.Controls.Add(this.txtINTotalSKU);
            this.pnlINStatus.Controls.Add(this.label5);
            this.pnlINStatus.Controls.Add(this.label4);
            this.pnlINStatus.Controls.Add(this.label3);
            this.pnlINStatus.Location = new System.Drawing.Point(677, 29);
            this.pnlINStatus.Name = "pnlINStatus";
            this.pnlINStatus.Size = new System.Drawing.Size(249, 114);
            this.pnlINStatus.TabIndex = 13;
            // 
            // txtINTotalUSKU
            // 
            this.txtINTotalUSKU.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtINTotalUSKU.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtINTotalUSKU.Location = new System.Drawing.Point(182, 49);
            this.txtINTotalUSKU.Name = "txtINTotalUSKU";
            this.txtINTotalUSKU.Size = new System.Drawing.Size(64, 17);
            this.txtINTotalUSKU.TabIndex = 5;
            this.txtINTotalUSKU.Text = "0";
            // 
            // txtINTotalSKU
            // 
            this.txtINTotalSKU.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtINTotalSKU.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtINTotalSKU.Location = new System.Drawing.Point(182, 28);
            this.txtINTotalSKU.Name = "txtINTotalSKU";
            this.txtINTotalSKU.Size = new System.Drawing.Size(64, 17);
            this.txtINTotalSKU.TabIndex = 4;
            this.txtINTotalSKU.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(4, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Number of Unique SKU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(32, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total SKU Scanned:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Info of scanned Items:";
            // 
            // btnINAdd
            // 
            this.btnINAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnINAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnINAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINAdd.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnINAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnINAdd.Location = new System.Drawing.Point(561, 107);
            this.btnINAdd.Name = "btnINAdd";
            this.btnINAdd.Size = new System.Drawing.Size(92, 36);
            this.btnINAdd.TabIndex = 12;
            this.btnINAdd.Text = "Add";
            this.btnINAdd.UseVisualStyleBackColor = false;
            this.btnINAdd.Click += new System.EventHandler(this.btnINAdd_Click);
            this.btnINAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseDown);
            this.btnINAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseUp);
            // 
            // txtINSKU
            // 
            this.txtINSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtINSKU.BackColor = System.Drawing.Color.AliceBlue;
            this.txtINSKU.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtINSKU.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtINSKU.Location = new System.Drawing.Point(485, 68);
            this.txtINSKU.Name = "txtINSKU";
            this.txtINSKU.Size = new System.Drawing.Size(168, 33);
            this.txtINSKU.TabIndex = 11;
            this.txtINSKU.TextChanged += new System.EventHandler(this.txtINBarcode_TextChanged);
            this.txtINSKU.Enter += new System.EventHandler(this.txtINSKU_Enter);
            this.txtINSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtINBarcode_KeyPress);
            this.txtINSKU.Leave += new System.EventHandler(this.txtINSKU_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label2.Location = new System.Drawing.Point(420, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "SKU:";
            // 
            // txtINBarcode
            // 
            this.txtINBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtINBarcode.BackColor = System.Drawing.Color.DodgerBlue;
            this.txtINBarcode.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtINBarcode.ForeColor = System.Drawing.Color.White;
            this.txtINBarcode.Location = new System.Drawing.Point(485, 29);
            this.txtINBarcode.Name = "txtINBarcode";
            this.txtINBarcode.Size = new System.Drawing.Size(168, 33);
            this.txtINBarcode.TabIndex = 9;
            this.txtINBarcode.TextChanged += new System.EventHandler(this.txtINBarcode_TextChanged);
            this.txtINBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtINBarcode_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(380, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Barcode:";
            // 
            // btnINUpdate
            // 
            this.btnINUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnINUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINUpdate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnINUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnINUpdate.Location = new System.Drawing.Point(19, 79);
            this.btnINUpdate.Name = "btnINUpdate";
            this.btnINUpdate.Size = new System.Drawing.Size(208, 50);
            this.btnINUpdate.TabIndex = 7;
            this.btnINUpdate.Text = "Update";
            this.btnINUpdate.UseVisualStyleBackColor = false;
            this.btnINUpdate.Click += new System.EventHandler(this.btnINUpdate_Click);
            this.btnINUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseDown);
            this.btnINUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseUp);
            // 
            // btnINCIL
            // 
            this.btnINCIL.BackColor = System.Drawing.Color.Transparent;
            this.btnINCIL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINCIL.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnINCIL.Location = new System.Drawing.Point(126, 23);
            this.btnINCIL.Name = "btnINCIL";
            this.btnINCIL.Size = new System.Drawing.Size(101, 50);
            this.btnINCIL.TabIndex = 6;
            this.btnINCIL.Text = "Cancel Entire List";
            this.btnINCIL.UseVisualStyleBackColor = false;
            this.btnINCIL.Click += new System.EventHandler(this.btnINCIL_Click);
            this.btnINCIL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseDown);
            this.btnINCIL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseUp);
            // 
            // btnINCLSI
            // 
            this.btnINCLSI.BackColor = System.Drawing.Color.Transparent;
            this.btnINCLSI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINCLSI.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnINCLSI.Location = new System.Drawing.Point(19, 23);
            this.btnINCLSI.Name = "btnINCLSI";
            this.btnINCLSI.Size = new System.Drawing.Size(101, 50);
            this.btnINCLSI.TabIndex = 5;
            this.btnINCLSI.Text = "Cancel Last Scanned Item";
            this.btnINCLSI.UseVisualStyleBackColor = false;
            this.btnINCLSI.Click += new System.EventHandler(this.btnINCLSI_Click);
            this.btnINCLSI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseDown);
            this.btnINCLSI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnINAdd_MouseUp);
            // 
            // dgvIN
            // 
            this.dgvIN.AllowUserToAddRows = false;
            this.dgvIN.AllowUserToDeleteRows = false;
            this.dgvIN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIN.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.clmINBarCode,
            this.clmINSKU,
            this.clmINItemName,
            this.clmINPrice,
            this.clmINTotalQuantity,
            this.clmINPrint,
            this.clmINCancel,
            this.clmINOrderNumber});
            this.dgvIN.Location = new System.Drawing.Point(6, 172);
            this.dgvIN.Name = "dgvIN";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIN.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIN.RowHeadersVisible = false;
            this.dgvIN.RowHeadersWidth = 21;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            this.dgvIN.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIN.Size = new System.Drawing.Size(938, 196);
            this.dgvIN.TabIndex = 3;
            this.dgvIN.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvIN_CellBeginEdit);
            this.dgvIN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIN_CellClick);
            this.dgvIN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIN_CellContentClick);
            this.dgvIN.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIN_CellEndEdit);
            this.dgvIN.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIN_CellValueChanged);
            this.dgvIN.SizeChanged += new System.EventHandler(this.dgvIN_SizeChanged);
            // 
            // seq
            // 
            this.seq.HeaderText = "";
            this.seq.Name = "seq";
            this.seq.Width = 30;
            // 
            // clmINBarCode
            // 
            this.clmINBarCode.FillWeight = 175.1402F;
            this.clmINBarCode.HeaderText = "Barcode";
            this.clmINBarCode.Name = "clmINBarCode";
            this.clmINBarCode.ReadOnly = true;
            this.clmINBarCode.Width = 120;
            // 
            // clmINSKU
            // 
            this.clmINSKU.FillWeight = 355.33F;
            this.clmINSKU.HeaderText = "SKU";
            this.clmINSKU.Name = "clmINSKU";
            this.clmINSKU.ReadOnly = true;
            this.clmINSKU.Width = 120;
            // 
            // clmINItemName
            // 
            this.clmINItemName.FillWeight = 144.1645F;
            this.clmINItemName.HeaderText = "Item Name";
            this.clmINItemName.Name = "clmINItemName";
            this.clmINItemName.ReadOnly = true;
            this.clmINItemName.Width = 170;
            // 
            // clmINPrice
            // 
            this.clmINPrice.HeaderText = "Price";
            this.clmINPrice.Name = "clmINPrice";
            this.clmINPrice.ReadOnly = true;
            this.clmINPrice.Width = 80;
            // 
            // clmINTotalQuantity
            // 
            this.clmINTotalQuantity.FillWeight = 13.22049F;
            this.clmINTotalQuantity.HeaderText = "Total Quantity";
            this.clmINTotalQuantity.Name = "clmINTotalQuantity";
            this.clmINTotalQuantity.Width = 120;
            // 
            // clmINPrint
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Print";
            this.clmINPrint.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmINPrint.FillWeight = 1.966186F;
            this.clmINPrint.HeaderText = "";
            this.clmINPrint.Name = "clmINPrint";
            this.clmINPrint.Text = "Print";
            this.clmINPrint.ToolTipText = "Print";
            this.clmINPrint.Width = 80;
            // 
            // clmINCancel
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Cancel";
            this.clmINCancel.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmINCancel.FillWeight = 3.302768F;
            this.clmINCancel.HeaderText = "";
            this.clmINCancel.Name = "clmINCancel";
            this.clmINCancel.Text = "Cancel";
            this.clmINCancel.ToolTipText = "Cancel";
            this.clmINCancel.Width = 80;
            // 
            // clmINOrderNumber
            // 
            this.clmINOrderNumber.FillWeight = 6.875844F;
            this.clmINOrderNumber.HeaderText = "Order Number";
            this.clmINOrderNumber.Name = "clmINOrderNumber";
            this.clmINOrderNumber.Width = 120;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 20);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(944, 351);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 980;
            this.lineShape1.Y1 = 148;
            this.lineShape1.Y2 = 148;
            // 
            // gbScanningOUT
            // 
            this.gbScanningOUT.Controls.Add(this.pnlOUTStatus);
            this.gbScanningOUT.Controls.Add(this.btnOUTAdd);
            this.gbScanningOUT.Controls.Add(this.txtOUTSKU);
            this.gbScanningOUT.Controls.Add(this.label12);
            this.gbScanningOUT.Controls.Add(this.txtOUTBarcode);
            this.gbScanningOUT.Controls.Add(this.label13);
            this.gbScanningOUT.Controls.Add(this.btnOUTUpdate);
            this.gbScanningOUT.Controls.Add(this.btnOUTCEL);
            this.gbScanningOUT.Controls.Add(this.btnOUTCLSI);
            this.gbScanningOUT.Controls.Add(this.dgvOUT);
            this.gbScanningOUT.Controls.Add(this.shapeContainer2);
            this.gbScanningOUT.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gbScanningOUT.ForeColor = System.Drawing.Color.White;
            this.gbScanningOUT.Location = new System.Drawing.Point(12, 447);
            this.gbScanningOUT.Name = "gbScanningOUT";
            this.gbScanningOUT.Size = new System.Drawing.Size(950, 374);
            this.gbScanningOUT.TabIndex = 2;
            this.gbScanningOUT.TabStop = false;
            this.gbScanningOUT.Text = "Scanning OUT:";
            this.gbScanningOUT.Visible = false;
            this.gbScanningOUT.Enter += new System.EventHandler(this.gbScanningOUT_Enter);
            // 
            // pnlOUTStatus
            // 
            this.pnlOUTStatus.BackColor = System.Drawing.Color.LightCyan;
            this.pnlOUTStatus.Controls.Add(this.txtOUTTotalUSKU);
            this.pnlOUTStatus.Controls.Add(this.txtOUTTotalSKU);
            this.pnlOUTStatus.Controls.Add(this.label14);
            this.pnlOUTStatus.Controls.Add(this.label15);
            this.pnlOUTStatus.Controls.Add(this.label11);
            this.pnlOUTStatus.Location = new System.Drawing.Point(19, 79);
            this.pnlOUTStatus.Name = "pnlOUTStatus";
            this.pnlOUTStatus.Size = new System.Drawing.Size(249, 72);
            this.pnlOUTStatus.TabIndex = 13;
            // 
            // txtOUTTotalUSKU
            // 
            this.txtOUTTotalUSKU.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtOUTTotalUSKU.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtOUTTotalUSKU.Location = new System.Drawing.Point(181, 46);
            this.txtOUTTotalUSKU.Name = "txtOUTTotalUSKU";
            this.txtOUTTotalUSKU.Size = new System.Drawing.Size(64, 17);
            this.txtOUTTotalUSKU.TabIndex = 9;
            this.txtOUTTotalUSKU.Text = "0";
            // 
            // txtOUTTotalSKU
            // 
            this.txtOUTTotalSKU.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtOUTTotalSKU.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtOUTTotalSKU.Location = new System.Drawing.Point(181, 25);
            this.txtOUTTotalSKU.Name = "txtOUTTotalSKU";
            this.txtOUTTotalSKU.Size = new System.Drawing.Size(64, 17);
            this.txtOUTTotalSKU.TabIndex = 8;
            this.txtOUTTotalSKU.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label14.Location = new System.Drawing.Point(3, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Number of Unique SKU:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label15.Location = new System.Drawing.Point(31, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Total SKU Scanned:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Info of scanned Items:";
            // 
            // btnOUTAdd
            // 
            this.btnOUTAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOUTAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnOUTAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOUTAdd.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnOUTAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnOUTAdd.Location = new System.Drawing.Point(561, 107);
            this.btnOUTAdd.Name = "btnOUTAdd";
            this.btnOUTAdd.Size = new System.Drawing.Size(92, 36);
            this.btnOUTAdd.TabIndex = 12;
            this.btnOUTAdd.Text = "Add";
            this.btnOUTAdd.UseVisualStyleBackColor = false;
            this.btnOUTAdd.Click += new System.EventHandler(this.btnOUTAdd_Click);
            this.btnOUTAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseDown);
            this.btnOUTAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseUp);
            // 
            // txtOUTSKU
            // 
            this.txtOUTSKU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOUTSKU.BackColor = System.Drawing.Color.AliceBlue;
            this.txtOUTSKU.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtOUTSKU.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.txtOUTSKU.Location = new System.Drawing.Point(485, 68);
            this.txtOUTSKU.Name = "txtOUTSKU";
            this.txtOUTSKU.Size = new System.Drawing.Size(168, 33);
            this.txtOUTSKU.TabIndex = 11;
            this.txtOUTSKU.TextChanged += new System.EventHandler(this.txtOUTBarcode_TextChanged);
            this.txtOUTSKU.Enter += new System.EventHandler(this.txtOUTSKU_Enter);
            this.txtOUTSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOUTBarcode_KeyPress);
            this.txtOUTSKU.Leave += new System.EventHandler(this.txtOUTSKU_Leave);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label12.Location = new System.Drawing.Point(420, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 27);
            this.label12.TabIndex = 10;
            this.label12.Text = "SKU:";
            // 
            // txtOUTBarcode
            // 
            this.txtOUTBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOUTBarcode.BackColor = System.Drawing.Color.DodgerBlue;
            this.txtOUTBarcode.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtOUTBarcode.ForeColor = System.Drawing.Color.White;
            this.txtOUTBarcode.Location = new System.Drawing.Point(485, 29);
            this.txtOUTBarcode.Name = "txtOUTBarcode";
            this.txtOUTBarcode.Size = new System.Drawing.Size(168, 33);
            this.txtOUTBarcode.TabIndex = 9;
            this.txtOUTBarcode.TextChanged += new System.EventHandler(this.txtOUTBarcode_TextChanged);
            this.txtOUTBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOUTBarcode_KeyPress);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label13.Location = new System.Drawing.Point(380, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 27);
            this.label13.TabIndex = 8;
            this.label13.Text = "Barcode:";
            // 
            // btnOUTUpdate
            // 
            this.btnOUTUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOUTUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnOUTUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOUTUpdate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnOUTUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnOUTUpdate.Location = new System.Drawing.Point(718, 23);
            this.btnOUTUpdate.Name = "btnOUTUpdate";
            this.btnOUTUpdate.Size = new System.Drawing.Size(208, 50);
            this.btnOUTUpdate.TabIndex = 7;
            this.btnOUTUpdate.Text = "Update";
            this.btnOUTUpdate.UseVisualStyleBackColor = false;
            this.btnOUTUpdate.Click += new System.EventHandler(this.btnOUTUpdate_Click);
            this.btnOUTUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseDown);
            this.btnOUTUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseUp);
            // 
            // btnOUTCEL
            // 
            this.btnOUTCEL.BackColor = System.Drawing.Color.Transparent;
            this.btnOUTCEL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOUTCEL.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOUTCEL.Location = new System.Drawing.Point(126, 23);
            this.btnOUTCEL.Name = "btnOUTCEL";
            this.btnOUTCEL.Size = new System.Drawing.Size(101, 50);
            this.btnOUTCEL.TabIndex = 6;
            this.btnOUTCEL.Text = "Cancel Entire List";
            this.btnOUTCEL.UseVisualStyleBackColor = false;
            this.btnOUTCEL.Click += new System.EventHandler(this.btnOUTCEL_Click);
            this.btnOUTCEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseDown);
            this.btnOUTCEL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseUp);
            // 
            // btnOUTCLSI
            // 
            this.btnOUTCLSI.BackColor = System.Drawing.Color.Transparent;
            this.btnOUTCLSI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOUTCLSI.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOUTCLSI.Location = new System.Drawing.Point(19, 23);
            this.btnOUTCLSI.Name = "btnOUTCLSI";
            this.btnOUTCLSI.Size = new System.Drawing.Size(101, 50);
            this.btnOUTCLSI.TabIndex = 5;
            this.btnOUTCLSI.Text = "Cancel Last Scanned Item";
            this.btnOUTCLSI.UseVisualStyleBackColor = false;
            this.btnOUTCLSI.Click += new System.EventHandler(this.btnOUTCLSI_Click);
            this.btnOUTCLSI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseDown);
            this.btnOUTCLSI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOUTAdd_MouseUp);
            // 
            // dgvOUT
            // 
            this.dgvOUT.AllowUserToAddRows = false;
            this.dgvOUT.AllowUserToDeleteRows = false;
            this.dgvOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOUT.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvOUT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOUT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seqOut,
            this.clmOutBarcode,
            this.clmOUTSKU,
            this.clmOUTItemName,
            this.clmOUTTotalQuantity,
            this.clmOUTPrice,
            this.clmOUTPrint,
            this.clmOUTCancel});
            this.dgvOUT.Location = new System.Drawing.Point(6, 172);
            this.dgvOUT.Name = "dgvOUT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOUT.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOUT.RowHeadersWidth = 21;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.SteelBlue;
            this.dgvOUT.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOUT.Size = new System.Drawing.Size(938, 196);
            this.dgvOUT.TabIndex = 3;
            this.dgvOUT.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOUT_CellBeginEdit);
            this.dgvOUT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOUT_CellClick);
            this.dgvOUT.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOUT_CellEndEdit);
            this.dgvOUT.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOUT_CellValueChanged);
            this.dgvOUT.SizeChanged += new System.EventHandler(this.dgvOUT_SizeChanged);
            // 
            // seqOut
            // 
            this.seqOut.HeaderText = "";
            this.seqOut.Name = "seqOut";
            this.seqOut.Width = 50;
            // 
            // clmOutBarcode
            // 
            this.clmOutBarcode.HeaderText = "Barcode";
            this.clmOutBarcode.Name = "clmOutBarcode";
            this.clmOutBarcode.Width = 130;
            // 
            // clmOUTSKU
            // 
            this.clmOUTSKU.HeaderText = "SKU";
            this.clmOUTSKU.Name = "clmOUTSKU";
            this.clmOUTSKU.Width = 130;
            // 
            // clmOUTItemName
            // 
            this.clmOUTItemName.HeaderText = "Item Name";
            this.clmOUTItemName.Name = "clmOUTItemName";
            this.clmOUTItemName.Width = 200;
            // 
            // clmOUTTotalQuantity
            // 
            this.clmOUTTotalQuantity.HeaderText = "Total Quantity";
            this.clmOUTTotalQuantity.Name = "clmOUTTotalQuantity";
            this.clmOUTTotalQuantity.Width = 130;
            // 
            // clmOUTPrice
            // 
            this.clmOUTPrice.HeaderText = "Price";
            this.clmOUTPrice.Name = "clmOUTPrice";
            this.clmOUTPrice.ReadOnly = true;
            this.clmOUTPrice.Width = 80;
            // 
            // clmOUTPrint
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Print";
            this.clmOUTPrint.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmOUTPrint.HeaderText = "";
            this.clmOUTPrint.Name = "clmOUTPrint";
            this.clmOUTPrint.Text = "Print";
            this.clmOUTPrint.ToolTipText = "Print";
            // 
            // clmOUTCancel
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "Cancel";
            this.clmOUTCancel.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmOUTCancel.HeaderText = "";
            this.clmOUTCancel.Name = "clmOUTCancel";
            this.clmOUTCancel.Text = "Cancel";
            this.clmOUTCancel.ToolTipText = "Cancel";
            this.clmOUTCancel.Width = 80;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 20);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(944, 351);
            this.shapeContainer2.TabIndex = 4;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.White;
            this.lineShape2.Name = "lineShape1";
            this.lineShape2.X1 = 0;
            this.lineShape2.X2 = 980;
            this.lineShape2.Y1 = 148;
            this.lineShape2.Y2 = 148;
            // 
            // tmrINFocus
            // 
            this.tmrINFocus.Interval = 200;
            this.tmrINFocus.Tick += new System.EventHandler(this.tmrINFocus_Tick);
            // 
            // tmrOUTFocus
            // 
            this.tmrOUTFocus.Interval = 200;
            this.tmrOUTFocus.Tick += new System.EventHandler(this.tmrOUTFocus_Tick);
            // 
            // tmrBarcodeIN
            // 
            this.tmrBarcodeIN.Interval = 1000;
            this.tmrBarcodeIN.Tick += new System.EventHandler(this.tmrBarcodeIN_Tick);
            // 
            // tmrBarcodeOut
            // 
            this.tmrBarcodeOut.Interval = 300;
            this.tmrBarcodeOut.Tick += new System.EventHandler(this.tmrBarcodeOut_Tick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(974, 730);
            this.Controls.Add(this.gbScanningOUT);
            this.Controls.Add(this.gbScanningIN);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanIN-OUT Ver1.1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDBConnection.ResumeLayout(false);
            this.pnlDBConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlScanOut.ResumeLayout(false);
            this.pnlScanOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlScanIn.ResumeLayout(false);
            this.pnlScanIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbScanningIN.ResumeLayout(false);
            this.gbScanningIN.PerformLayout();
            this.pnlINStatus.ResumeLayout(false);
            this.pnlINStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIN)).EndInit();
            this.gbScanningOUT.ResumeLayout(false);
            this.gbScanningOUT.PerformLayout();
            this.pnlOUTStatus.ResumeLayout(false);
            this.pnlOUTStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOUT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDBConnection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnlScanOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlScanIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbScanningIN;
        private System.Windows.Forms.DataGridView dgvIN;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnINCLSI;
        private System.Windows.Forms.Button btnINCIL;
        private System.Windows.Forms.Button btnINUpdate;
        private System.Windows.Forms.TextBox txtINBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlINStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnINAdd;
        public System.Windows.Forms.TextBox txtINSKU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbScanningOUT;
        private System.Windows.Forms.Panel pnlOUTStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOUTAdd;
        public System.Windows.Forms.TextBox txtOUTSKU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOUTBarcode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOUTUpdate;
        private System.Windows.Forms.Button btnOUTCEL;
        private System.Windows.Forms.Button btnOUTCLSI;
        private System.Windows.Forms.DataGridView dgvOUT;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label txtINTotalUSKU;
        private System.Windows.Forms.Label txtINTotalSKU;
        private System.Windows.Forms.Label txtOUTTotalUSKU;
        private System.Windows.Forms.Label txtOUTTotalSKU;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer tmrINFocus;
        private System.Windows.Forms.Timer tmrOUTFocus;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrBarcodeIN;
        private System.Windows.Forms.Timer tmrBarcodeOut;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINTotalQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn clmINPrint;
        private System.Windows.Forms.DataGridViewButtonColumn clmINCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn seqOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOutBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOUTSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOUTItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOUTTotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOUTPrice;
        private System.Windows.Forms.DataGridViewButtonColumn clmOUTPrint;
        private System.Windows.Forms.DataGridViewButtonColumn clmOUTCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

