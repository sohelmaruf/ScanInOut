namespace ScanINOUTVer2
{
    partial class UCPurchaseOrders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvReceiving = new System.Windows.Forms.DataGridView();
            this.clm2PONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2ItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2SupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2QtyReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2QuickPrint = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmPrintFormat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clm2Cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clm2ViewOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clm2Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2Price3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dgvEcpected = new System.Windows.Forms.DataGridView();
            this.clmPONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblUSKU = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTSKU = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelLastItem = new System.Windows.Forms.Button();
            this.txtOperationName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShowCost = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnReceive = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupplierSKU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clbOrderNumbers = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcpected)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier:";
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(61, 16);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(379, 21);
            this.cbSupplier.TabIndex = 0;
            this.cbSupplier.DropDown += new System.EventHandler(this.cbSupplier_DropDown);
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            this.cbSupplier.Enter += new System.EventHandler(this.cbSupplier_Enter);
            this.cbSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnChangePwd);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.btnCancelLastItem);
            this.groupBox1.Controls.Add(this.txtOperationName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnPrintPreview);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnShowCost);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.clbOrderNumbers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSupplier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePwd.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnChangePwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePwd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePwd.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePwd.ForeColor = System.Drawing.Color.White;
            this.btnChangePwd.Location = new System.Drawing.Point(868, 69);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 50);
            this.btnChangePwd.TabIndex = 17;
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.UseVisualStyleBackColor = false;
            this.btnChangePwd.Visible = false;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.dgvReceiving);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.dgvEcpected);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(9, 129);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(941, 200);
            this.panel3.TabIndex = 4;
            this.panel3.SizeChanged += new System.EventHandler(this.panel3_SizeChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(751, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 24);
            this.button1.TabIndex = 28;
            this.button1.Text = "Make the same Print Format";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvReceiving
            // 
            this.dgvReceiving.AllowUserToAddRows = false;
            this.dgvReceiving.AllowUserToDeleteRows = false;
            this.dgvReceiving.AllowUserToOrderColumns = true;
            this.dgvReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceiving.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceiving.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReceiving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiving.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm2PONum,
            this.clm2ItemNum,
            this.clm2SKU,
            this.clm2ItemName,
            this.clm2SupplierSKU,
            this.clm2Location,
            this.clm2OrderNumber,
            this.clm2QtyReceived,
            this.clm2QuickPrint,
            this.clmPrintFormat,
            this.clm2Cancel,
            this.clm2ViewOrder,
            this.clm2Cost,
            this.clm2Price,
            this.clm2Price2,
            this.clm2Price3});
            this.dgvReceiving.Location = new System.Drawing.Point(0, 122);
            this.dgvReceiving.Name = "dgvReceiving";
            this.dgvReceiving.RowHeadersVisible = false;
            this.dgvReceiving.Size = new System.Drawing.Size(941, 75);
            this.dgvReceiving.TabIndex = 2;
            this.dgvReceiving.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiving_CellContentClick);
            this.dgvReceiving.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvReceiving_CellContextMenuStripNeeded);
            this.dgvReceiving.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvReceiving_RowsAdded);
            this.dgvReceiving.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // clm2PONum
            // 
            this.clm2PONum.DataPropertyName = "PONumber";
            this.clm2PONum.HeaderText = "PO#";
            this.clm2PONum.Name = "clm2PONum";
            this.clm2PONum.ReadOnly = true;
            // 
            // clm2ItemNum
            // 
            this.clm2ItemNum.DataPropertyName = "ItemNumber";
            this.clm2ItemNum.HeaderText = "Item#";
            this.clm2ItemNum.Name = "clm2ItemNum";
            this.clm2ItemNum.ReadOnly = true;
            // 
            // clm2SKU
            // 
            this.clm2SKU.DataPropertyName = "LocalSKU";
            this.clm2SKU.HeaderText = "SKU";
            this.clm2SKU.Name = "clm2SKU";
            this.clm2SKU.ReadOnly = true;
            // 
            // clm2ItemName
            // 
            this.clm2ItemName.DataPropertyName = "ItemName";
            this.clm2ItemName.FillWeight = 200F;
            this.clm2ItemName.HeaderText = "ItemName";
            this.clm2ItemName.Name = "clm2ItemName";
            this.clm2ItemName.ReadOnly = true;
            // 
            // clm2SupplierSKU
            // 
            this.clm2SupplierSKU.DataPropertyName = "SupplierSKU";
            this.clm2SupplierSKU.HeaderText = "SupplierSKU";
            this.clm2SupplierSKU.Name = "clm2SupplierSKU";
            this.clm2SupplierSKU.ReadOnly = true;
            // 
            // clm2Location
            // 
            this.clm2Location.DataPropertyName = "Location";
            this.clm2Location.HeaderText = "Location";
            this.clm2Location.Name = "clm2Location";
            this.clm2Location.ReadOnly = true;
            // 
            // clm2OrderNumber
            // 
            this.clm2OrderNumber.DataPropertyName = "OrderNumber";
            this.clm2OrderNumber.HeaderText = "OrderNumber";
            this.clm2OrderNumber.Name = "clm2OrderNumber";
            this.clm2OrderNumber.ReadOnly = true;
            // 
            // clm2QtyReceived
            // 
            this.clm2QtyReceived.DataPropertyName = "QtyReceived";
            this.clm2QtyReceived.HeaderText = "QtyReceived";
            this.clm2QtyReceived.Name = "clm2QtyReceived";
            this.clm2QtyReceived.ReadOnly = true;
            // 
            // clm2QuickPrint
            // 
            this.clm2QuickPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clm2QuickPrint.HeaderText = "";
            this.clm2QuickPrint.Name = "clm2QuickPrint";
            this.clm2QuickPrint.Text = "QuickPrint";
            this.clm2QuickPrint.UseColumnTextForButtonValue = true;
            // 
            // clmPrintFormat
            // 
            this.clmPrintFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clmPrintFormat.HeaderText = "PrintFormat";
            this.clmPrintFormat.Items.AddRange(new object[] {
            "BarcodePrice",
            "BarcodeNOPrice",
            "BarcodePrice3",
            "BarcodePrice4"});
            this.clmPrintFormat.Name = "clmPrintFormat";
            // 
            // clm2Cancel
            // 
            this.clm2Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clm2Cancel.HeaderText = "";
            this.clm2Cancel.Name = "clm2Cancel";
            this.clm2Cancel.Text = "Cancel";
            this.clm2Cancel.UseColumnTextForButtonValue = true;
            // 
            // clm2ViewOrder
            // 
            this.clm2ViewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clm2ViewOrder.HeaderText = "";
            this.clm2ViewOrder.Name = "clm2ViewOrder";
            this.clm2ViewOrder.Text = "ViewOrder";
            this.clm2ViewOrder.UseColumnTextForButtonValue = true;
            // 
            // clm2Cost
            // 
            this.clm2Cost.DataPropertyName = "Cost";
            this.clm2Cost.HeaderText = "Cost";
            this.clm2Cost.Name = "clm2Cost";
            // 
            // clm2Price
            // 
            this.clm2Price.DataPropertyName = "Price";
            this.clm2Price.HeaderText = "Price";
            this.clm2Price.Name = "clm2Price";
            // 
            // clm2Price2
            // 
            this.clm2Price2.DataPropertyName = "Price2";
            this.clm2Price2.HeaderText = "Price2";
            this.clm2Price2.Name = "clm2Price2";
            // 
            // clm2Price3
            // 
            this.clm2Price3.DataPropertyName = "Price3";
            this.clm2Price3.HeaderText = "Price3";
            this.clm2Price3.Name = "clm2Price3";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-3, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Receiving:";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkBox1.Location = new System.Drawing.Point(750, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(201, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Print All Barcodes for received items ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // dgvEcpected
            // 
            this.dgvEcpected.AllowUserToAddRows = false;
            this.dgvEcpected.AllowUserToDeleteRows = false;
            this.dgvEcpected.AllowUserToOrderColumns = true;
            this.dgvEcpected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEcpected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEcpected.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEcpected.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvEcpected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEcpected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPONum,
            this.clmItemNum,
            this.clmSKU,
            this.clmSupplierSKU,
            this.clmItemName,
            this.clmCost,
            this.clmQuantityOrdered,
            this.clmQuantityRemaining});
            this.dgvEcpected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEcpected.Location = new System.Drawing.Point(0, 20);
            this.dgvEcpected.Name = "dgvEcpected";
            this.dgvEcpected.ReadOnly = true;
            this.dgvEcpected.RowHeadersVisible = false;
            this.dgvEcpected.Size = new System.Drawing.Size(941, 75);
            this.dgvEcpected.TabIndex = 1;
            this.dgvEcpected.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEcpected_CellClick);
            this.dgvEcpected.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvEcpected_CellContextMenuStripNeeded);
            this.dgvEcpected.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEcpected_CellDoubleClick);
            this.dgvEcpected.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEcpected_ColumnHeaderMouseClick);
            this.dgvEcpected.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // clmPONum
            // 
            this.clmPONum.DataPropertyName = "PONumber";
            this.clmPONum.HeaderText = "PO#";
            this.clmPONum.Name = "clmPONum";
            this.clmPONum.ReadOnly = true;
            // 
            // clmItemNum
            // 
            this.clmItemNum.DataPropertyName = "ItemNumber";
            this.clmItemNum.HeaderText = "Item#";
            this.clmItemNum.Name = "clmItemNum";
            this.clmItemNum.ReadOnly = true;
            // 
            // clmSKU
            // 
            this.clmSKU.DataPropertyName = "LocalSKU";
            this.clmSKU.HeaderText = "SKU";
            this.clmSKU.Name = "clmSKU";
            this.clmSKU.ReadOnly = true;
            // 
            // clmSupplierSKU
            // 
            this.clmSupplierSKU.DataPropertyName = "SuppliersSKU";
            this.clmSupplierSKU.HeaderText = "SupplierSKU";
            this.clmSupplierSKU.Name = "clmSupplierSKU";
            this.clmSupplierSKU.ReadOnly = true;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "ItemName";
            this.clmItemName.HeaderText = "ItemName";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.ReadOnly = true;
            // 
            // clmCost
            // 
            this.clmCost.DataPropertyName = "ExpectedCost";
            this.clmCost.HeaderText = "Cost";
            this.clmCost.Name = "clmCost";
            this.clmCost.ReadOnly = true;
            this.clmCost.Visible = false;
            // 
            // clmQuantityOrdered
            // 
            this.clmQuantityOrdered.DataPropertyName = "Ordered";
            this.clmQuantityOrdered.HeaderText = "QuantityOrdered";
            this.clmQuantityOrdered.Name = "clmQuantityOrdered";
            this.clmQuantityOrdered.ReadOnly = true;
            // 
            // clmQuantityRemaining
            // 
            this.clmQuantityRemaining.DataPropertyName = "QuantityRemaining";
            this.clmQuantityRemaining.HeaderText = "QuantityRemaining";
            this.clmQuantityRemaining.Name = "clmQuantityRemaining";
            this.clmQuantityRemaining.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Expected To Receive:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lblUSKU);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblTSKU);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(124, 335);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 54);
            this.panel2.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTotal.Location = new System.Drawing.Point(295, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(101, 15);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "0.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(245, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Total $:";
            // 
            // lblUSKU
            // 
            this.lblUSKU.BackColor = System.Drawing.Color.Gainsboro;
            this.lblUSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUSKU.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUSKU.Location = new System.Drawing.Point(133, 29);
            this.lblUSKU.Name = "lblUSKU";
            this.lblUSKU.Size = new System.Drawing.Size(101, 15);
            this.lblUSKU.TabIndex = 9;
            this.lblUSKU.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(3, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Number of Unique SKUs:";
            // 
            // lblTSKU
            // 
            this.lblTSKU.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTSKU.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblTSKU.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTSKU.Location = new System.Drawing.Point(133, 7);
            this.lblTSKU.Name = "lblTSKU";
            this.lblTSKU.Size = new System.Drawing.Size(101, 15);
            this.lblTSKU.TabIndex = 7;
            this.lblTSKU.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Total SKU Scanned:";
            // 
            // btnCancelLastItem
            // 
            this.btnCancelLastItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelLastItem.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnCancelLastItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelLastItem.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCancelLastItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelLastItem.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelLastItem.ForeColor = System.Drawing.Color.White;
            this.btnCancelLastItem.Location = new System.Drawing.Point(9, 335);
            this.btnCancelLastItem.Name = "btnCancelLastItem";
            this.btnCancelLastItem.Size = new System.Drawing.Size(109, 54);
            this.btnCancelLastItem.TabIndex = 5;
            this.btnCancelLastItem.Text = "Cancel Last Item";
            this.btnCancelLastItem.UseVisualStyleBackColor = false;
            this.btnCancelLastItem.Click += new System.EventHandler(this.btnCancelLastItem_Click);
            this.btnCancelLastItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // txtOperationName
            // 
            this.txtOperationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOperationName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtOperationName.Location = new System.Drawing.Point(531, 369);
            this.txtOperationName.Name = "txtOperationName";
            this.txtOperationName.Size = new System.Drawing.Size(157, 20);
            this.txtOperationName.TabIndex = 7;
            this.txtOperationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(528, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "OperatorName:";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnPrintPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.ForeColor = System.Drawing.Color.White;
            this.btnPrintPreview.Location = new System.Drawing.Point(694, 335);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(135, 54);
            this.btnPrintPreview.TabIndex = 8;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            this.btnPrintPreview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(835, 335);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 54);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // btnShowCost
            // 
            this.btnShowCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCost.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnShowCost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCost.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnShowCost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCost.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowCost.ForeColor = System.Drawing.Color.Black;
            this.btnShowCost.Location = new System.Drawing.Point(861, 16);
            this.btnShowCost.Name = "btnShowCost";
            this.btnShowCost.Size = new System.Drawing.Size(89, 109);
            this.btnShowCost.TabIndex = 2;
            this.btnShowCost.Text = "Show Cost";
            this.btnShowCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowCost.UseVisualStyleBackColor = false;
            this.btnShowCost.Click += new System.EventHandler(this.btnShowCost_Click);
            this.btnShowCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.nudQty);
            this.panel1.Controls.Add(this.btnReceive);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSupplierSKU);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSKU);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(9, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 82);
            this.panel1.TabIndex = 3;
            // 
            // nudQty
            // 
            this.nudQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudQty.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nudQty.Location = new System.Drawing.Point(408, 8);
            this.nudQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(103, 20);
            this.nudQty.TabIndex = 3;
            this.nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            this.nudQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // btnReceive
            // 
            this.btnReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceive.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceive.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnReceive.ForeColor = System.Drawing.Color.White;
            this.btnReceive.Location = new System.Drawing.Point(376, 33);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(135, 46);
            this.btnReceive.TabIndex = 4;
            this.btnReceive.Text = "Receive";
            this.btnReceive.UseVisualStyleBackColor = false;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            this.btnReceive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(373, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Qty:";
            // 
            // txtSupplierSKU
            // 
            this.txtSupplierSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierSKU.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtSupplierSKU.Location = new System.Drawing.Point(80, 59);
            this.txtSupplierSKU.Name = "txtSupplierSKU";
            this.txtSupplierSKU.Size = new System.Drawing.Size(242, 20);
            this.txtSupplierSKU.TabIndex = 2;
            this.txtSupplierSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            this.txtSupplierSKU.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Supplier SKU:";
            // 
            // txtSKU
            // 
            this.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSKU.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtSKU.Location = new System.Drawing.Point(80, 33);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(242, 20);
            this.txtSKU.TabIndex = 1;
            this.txtSKU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            this.txtSKU.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SKU:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtBarcode.Location = new System.Drawing.Point(51, 7);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(271, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Barcode:";
            // 
            // clbOrderNumbers
            // 
            this.clbOrderNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbOrderNumbers.CheckOnClick = true;
            this.clbOrderNumbers.ColumnWidth = 80;
            this.clbOrderNumbers.FormattingEnabled = true;
            this.clbOrderNumbers.Location = new System.Drawing.Point(531, 16);
            this.clbOrderNumbers.MultiColumn = true;
            this.clbOrderNumbers.Name = "clbOrderNumbers";
            this.clbOrderNumbers.Size = new System.Drawing.Size(324, 109);
            this.clbOrderNumbers.TabIndex = 1;
            this.clbOrderNumbers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbOrderNumbers_ItemCheck);
            this.clbOrderNumbers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Number:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UCPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "UCPurchaseOrders";
            this.Size = new System.Drawing.Size(962, 401);
            this.Load += new System.EventHandler(this.UCPurchaseOrders_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UCPurchaseOrders_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcpected)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox clbOrderNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSupplierSKU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblUSKU;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTSKU;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancelLastItem;
        private System.Windows.Forms.TextBox txtOperationName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShowCost;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvReceiving;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dgvEcpected;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityRemaining;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2PONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2ItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2SupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2QtyReceived;
        private System.Windows.Forms.DataGridViewButtonColumn clm2QuickPrint;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmPrintFormat;
        private System.Windows.Forms.DataGridViewButtonColumn clm2Cancel;
        private System.Windows.Forms.DataGridViewButtonColumn clm2ViewOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2Price3;
    }
}
