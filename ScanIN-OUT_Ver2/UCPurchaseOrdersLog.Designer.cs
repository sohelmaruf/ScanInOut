namespace ScanINOUTVer2
{
    partial class UCPurchaseOrdersLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.clbOrderNumbers = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpExpected = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvEcpected = new System.Windows.Forms.DataGridView();
            this.clmPONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpReceived = new System.Windows.Forms.TabPage();
            this.dgvReceived = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tpNotReceived = new System.Windows.Forms.TabPage();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dgvNotReceived = new System.Windows.Forms.DataGridView();
            this.clmRPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRSupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRQtyReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnteredBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbContent.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpExpected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcpected)).BeginInit();
            this.tpReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceived)).BeginInit();
            this.tpNotReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(957, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purrchase Orders Log";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbContent
            // 
            this.gbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContent.Controls.Add(this.clbOrderNumbers);
            this.gbContent.Controls.Add(this.label3);
            this.gbContent.Controls.Add(this.cbSupplier);
            this.gbContent.Controls.Add(this.label2);
            this.gbContent.Controls.Add(this.tabControl1);
            this.gbContent.Location = new System.Drawing.Point(1, 22);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(959, 376);
            this.gbContent.TabIndex = 1;
            this.gbContent.TabStop = false;
            // 
            // clbOrderNumbers
            // 
            this.clbOrderNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbOrderNumbers.CheckOnClick = true;
            this.clbOrderNumbers.ColumnWidth = 80;
            this.clbOrderNumbers.FormattingEnabled = true;
            this.clbOrderNumbers.IntegralHeight = false;
            this.clbOrderNumbers.Location = new System.Drawing.Point(428, 13);
            this.clbOrderNumbers.MultiColumn = true;
            this.clbOrderNumbers.Name = "clbOrderNumbers";
            this.clbOrderNumbers.Size = new System.Drawing.Size(525, 52);
            this.clbOrderNumbers.TabIndex = 3;
            this.clbOrderNumbers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbOrderNumbers_ItemCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order Number:";
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(61, 13);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(276, 21);
            this.cbSupplier.TabIndex = 2;
            this.cbSupplier.DropDown += new System.EventHandler(this.cbSupplier_DropDown);
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpExpected);
            this.tabControl1.Controls.Add(this.tpReceived);
            this.tabControl1.Controls.Add(this.tpNotReceived);
            this.tabControl1.Location = new System.Drawing.Point(9, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 319);
            this.tabControl1.TabIndex = 6;
            // 
            // tpExpected
            // 
            this.tpExpected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.tpExpected.Controls.Add(this.button1);
            this.tpExpected.Controls.Add(this.btnUpdate);
            this.tpExpected.Controls.Add(this.dgvEcpected);
            this.tpExpected.Location = new System.Drawing.Point(4, 22);
            this.tpExpected.Name = "tpExpected";
            this.tpExpected.Padding = new System.Windows.Forms.Padding(3);
            this.tpExpected.Size = new System.Drawing.Size(936, 293);
            this.tpExpected.TabIndex = 0;
            this.tpExpected.Text = "Expected To Receive";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(694, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 26);
            this.button1.TabIndex = 11;
            this.button1.Text = "Export to pdf";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.btnUpdate.Location = new System.Drawing.Point(815, 261);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 26);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Export to excel";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvEcpected
            // 
            this.dgvEcpected.AllowUserToAddRows = false;
            this.dgvEcpected.AllowUserToDeleteRows = false;
            this.dgvEcpected.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEcpected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEcpected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.dgvEcpected.Location = new System.Drawing.Point(0, 0);
            this.dgvEcpected.Name = "dgvEcpected";
            this.dgvEcpected.ReadOnly = true;
            this.dgvEcpected.RowHeadersVisible = false;
            this.dgvEcpected.Size = new System.Drawing.Size(936, 255);
            this.dgvEcpected.TabIndex = 2;
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
            // tpReceived
            // 
            this.tpReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.tpReceived.Controls.Add(this.dgvReceived);
            this.tpReceived.Controls.Add(this.button2);
            this.tpReceived.Controls.Add(this.button3);
            this.tpReceived.Location = new System.Drawing.Point(4, 22);
            this.tpReceived.Name = "tpReceived";
            this.tpReceived.Padding = new System.Windows.Forms.Padding(3);
            this.tpReceived.Size = new System.Drawing.Size(936, 293);
            this.tpReceived.TabIndex = 1;
            this.tpReceived.Text = "Received";
            // 
            // dgvReceived
            // 
            this.dgvReceived.AllowUserToAddRows = false;
            this.dgvReceived.AllowUserToDeleteRows = false;
            this.dgvReceived.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReceived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceived.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReceived.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRPONumber,
            this.clmRItemNumber,
            this.clmRItemName,
            this.clmRSKU,
            this.clmRSupplierSKU,
            this.clmRCost,
            this.clmRQtyReceived,
            this.EnteredBy});
            this.dgvReceived.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvReceived.Location = new System.Drawing.Point(0, 0);
            this.dgvReceived.Name = "dgvReceived";
            this.dgvReceived.ReadOnly = true;
            this.dgvReceived.RowHeadersVisible = false;
            this.dgvReceived.Size = new System.Drawing.Size(936, 255);
            this.dgvReceived.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(694, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "Export to pdf";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(815, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "Export to excel";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tpNotReceived
            // 
            this.tpNotReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.tpNotReceived.Controls.Add(this.btnPrintPreview);
            this.tpNotReceived.Controls.Add(this.button4);
            this.tpNotReceived.Controls.Add(this.button5);
            this.tpNotReceived.Controls.Add(this.dgvNotReceived);
            this.tpNotReceived.Location = new System.Drawing.Point(4, 22);
            this.tpNotReceived.Name = "tpNotReceived";
            this.tpNotReceived.Size = new System.Drawing.Size(936, 293);
            this.tpNotReceived.TabIndex = 2;
            this.tpNotReceived.Text = "Not Received (Purchase Orders Log)";
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
            this.btnPrintPreview.Location = new System.Drawing.Point(579, 261);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(109, 26);
            this.btnPrintPreview.TabIndex = 17;
            this.btnPrintPreview.Text = "Restore";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(694, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 26);
            this.button4.TabIndex = 16;
            this.button4.Text = "Export to pdf";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(815, 261);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 26);
            this.button5.TabIndex = 15;
            this.button5.Text = "Export to excel";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dgvNotReceived
            // 
            this.dgvNotReceived.AllowUserToAddRows = false;
            this.dgvNotReceived.AllowUserToDeleteRows = false;
            this.dgvNotReceived.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNotReceived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNotReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNotReceived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotReceived.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNotReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotReceived.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PONumber,
            this.ItemNumber,
            this.SKU,
            this.SupplierSKU,
            this.ItemName,
            this.clmLocation,
            this.OrderNumber,
            this.QtyReceived,
            this.Cost,
            this.CreationDate,
            this.CreationTime});
            this.dgvNotReceived.Location = new System.Drawing.Point(0, 0);
            this.dgvNotReceived.Name = "dgvNotReceived";
            this.dgvNotReceived.RowHeadersVisible = false;
            this.dgvNotReceived.Size = new System.Drawing.Size(936, 255);
            this.dgvNotReceived.TabIndex = 14;
            // 
            // clmRPONumber
            // 
            this.clmRPONumber.DataPropertyName = "PONumber";
            this.clmRPONumber.HeaderText = "PO#";
            this.clmRPONumber.Name = "clmRPONumber";
            this.clmRPONumber.ReadOnly = true;
            // 
            // clmRItemNumber
            // 
            this.clmRItemNumber.DataPropertyName = "ItemNumber";
            this.clmRItemNumber.HeaderText = "Item#";
            this.clmRItemNumber.Name = "clmRItemNumber";
            this.clmRItemNumber.ReadOnly = true;
            // 
            // clmRItemName
            // 
            this.clmRItemName.DataPropertyName = "ItemName";
            this.clmRItemName.HeaderText = "ItemName";
            this.clmRItemName.Name = "clmRItemName";
            this.clmRItemName.ReadOnly = true;
            // 
            // clmRSKU
            // 
            this.clmRSKU.DataPropertyName = "LocalSKU";
            this.clmRSKU.HeaderText = "SKU";
            this.clmRSKU.Name = "clmRSKU";
            this.clmRSKU.ReadOnly = true;
            // 
            // clmRSupplierSKU
            // 
            this.clmRSupplierSKU.DataPropertyName = "SuppliersSKU";
            this.clmRSupplierSKU.HeaderText = "SupplierSKU";
            this.clmRSupplierSKU.Name = "clmRSupplierSKU";
            this.clmRSupplierSKU.ReadOnly = true;
            // 
            // clmRCost
            // 
            this.clmRCost.DataPropertyName = "Cost";
            this.clmRCost.HeaderText = "Cost";
            this.clmRCost.Name = "clmRCost";
            this.clmRCost.ReadOnly = true;
            // 
            // clmRQtyReceived
            // 
            this.clmRQtyReceived.DataPropertyName = "Quantity";
            this.clmRQtyReceived.HeaderText = "Quantity";
            this.clmRQtyReceived.Name = "clmRQtyReceived";
            this.clmRQtyReceived.ReadOnly = true;
            // 
            // EnteredBy
            // 
            this.EnteredBy.DataPropertyName = "EnteredBy";
            this.EnteredBy.HeaderText = "EnteredBy";
            this.EnteredBy.Name = "EnteredBy";
            this.EnteredBy.ReadOnly = true;
            // 
            // PONumber
            // 
            this.PONumber.DataPropertyName = "PONumber";
            this.PONumber.HeaderText = "PONumber";
            this.PONumber.Name = "PONumber";
            // 
            // ItemNumber
            // 
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "ItemNumber";
            this.ItemNumber.Name = "ItemNumber";
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "SKU";
            this.SKU.HeaderText = "SKU";
            this.SKU.Name = "SKU";
            // 
            // SupplierSKU
            // 
            this.SupplierSKU.DataPropertyName = "SupplierSKU";
            this.SupplierSKU.HeaderText = "SupplierSKU";
            this.SupplierSKU.Name = "SupplierSKU";
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // clmLocation
            // 
            this.clmLocation.DataPropertyName = "Location";
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            // 
            // OrderNumber
            // 
            this.OrderNumber.DataPropertyName = "OrderNumber";
            this.OrderNumber.HeaderText = "OrderNumber";
            this.OrderNumber.Name = "OrderNumber";
            // 
            // QtyReceived
            // 
            this.QtyReceived.DataPropertyName = "QtyReceived";
            this.QtyReceived.HeaderText = "QtyReceived";
            this.QtyReceived.Name = "QtyReceived";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // CreationDate
            // 
            this.CreationDate.DataPropertyName = "CreationDate";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.CreationDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.CreationDate.HeaderText = "CreationDate";
            this.CreationDate.Name = "CreationDate";
            // 
            // CreationTime
            // 
            this.CreationTime.DataPropertyName = "CreationDate";
            dataGridViewCellStyle6.Format = "T";
            dataGridViewCellStyle6.NullValue = null;
            this.CreationTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.CreationTime.HeaderText = "CreationTime";
            this.CreationTime.Name = "CreationTime";
            // 
            // UCPurchaseOrdersLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbContent);
            this.Name = "UCPurchaseOrdersLog";
            this.Size = new System.Drawing.Size(962, 401);
            this.Load += new System.EventHandler(this.UCPurchaseOrdersLog_Load);
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpExpected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcpected)).EndInit();
            this.tpReceived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceived)).EndInit();
            this.tpNotReceived.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReceived)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbOrderNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpExpected;
        private System.Windows.Forms.TabPage tpReceived;
        private System.Windows.Forms.TabPage tpNotReceived;
        private System.Windows.Forms.DataGridView dgvEcpected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityRemaining;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgvNotReceived;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.DataGridView dgvReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRSupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRQtyReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnteredBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
    }
}
