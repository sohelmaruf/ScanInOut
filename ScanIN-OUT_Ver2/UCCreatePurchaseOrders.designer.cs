namespace ScanINOUTVer2
{
    partial class UCCreatePurchaseOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.clmPONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnaddTopo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSupplier
            // 
            this.cbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(59, 6);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(308, 21);
            this.cbSupplier.TabIndex = 0;
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Controls.Add(this.btnaddTopo);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPONum,
            this.clmItemNum,
            this.clmSKU,
            this.clmSupplierSKU,
            this.clmItemName,
            this.Column1,
            this.clmCost,
            this.clmQuantityOrdered});
            this.dgvData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvData.Location = new System.Drawing.Point(10, 70);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(936, 255);
            this.dgvData.TabIndex = 9;
            // 
            // clmPONum
            // 
            this.clmPONum.DataPropertyName = "SKU";
            this.clmPONum.FillWeight = 150F;
            this.clmPONum.HeaderText = "Local SKU";
            this.clmPONum.Name = "clmPONum";
            this.clmPONum.ReadOnly = true;
            this.clmPONum.Width = 200;
            // 
            // clmItemNum
            // 
            this.clmItemNum.DataPropertyName = "ItemName";
            this.clmItemNum.FillWeight = 200F;
            this.clmItemNum.HeaderText = "Item Name";
            this.clmItemNum.Name = "clmItemNum";
            this.clmItemNum.ReadOnly = true;
            this.clmItemNum.Width = 280;
            // 
            // clmSKU
            // 
            this.clmSKU.DataPropertyName = "QOH";
            this.clmSKU.FillWeight = 20F;
            this.clmSKU.HeaderText = "QOH";
            this.clmSKU.Name = "clmSKU";
            this.clmSKU.ReadOnly = true;
            // 
            // clmSupplierSKU
            // 
            this.clmSupplierSKU.DataPropertyName = "ReorderPoint";
            this.clmSupplierSKU.FillWeight = 20F;
            this.clmSupplierSKU.HeaderText = "Reorder Point";
            this.clmSupplierSKU.Name = "clmSupplierSKU";
            this.clmSupplierSKU.ReadOnly = true;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "ReorderQuantity";
            this.clmItemName.FillWeight = 20F;
            this.clmItemName.HeaderText = "Reorder Quantity";
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "QuantityNeeded";
            this.Column1.HeaderText = "Quantity Needed";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // clmCost
            // 
            this.clmCost.DataPropertyName = "QtyToOrder";
            this.clmCost.FillWeight = 20F;
            this.clmCost.HeaderText = "Qty To Order";
            this.clmCost.Name = "clmCost";
            this.clmCost.ReadOnly = true;
            // 
            // clmQuantityOrdered
            // 
            this.clmQuantityOrdered.DataPropertyName = "SuuplierID";
            this.clmQuantityOrdered.HeaderText = "Suuplier ID";
            this.clmQuantityOrdered.Name = "clmQuantityOrdered";
            this.clmQuantityOrdered.ReadOnly = true;
            this.clmQuantityOrdered.Visible = false;
            this.clmQuantityOrdered.Width = 70;
            // 
            // btnaddTopo
            // 
            this.btnaddTopo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddTopo.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnaddTopo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddTopo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnaddTopo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddTopo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnaddTopo.ForeColor = System.Drawing.Color.White;
            this.btnaddTopo.Location = new System.Drawing.Point(806, 332);
            this.btnaddTopo.Name = "btnaddTopo";
            this.btnaddTopo.Size = new System.Drawing.Size(135, 54);
            this.btnaddTopo.TabIndex = 8;
            this.btnaddTopo.Text = "Add To PO";
            this.btnaddTopo.UseVisualStyleBackColor = false;
            this.btnaddTopo.Click += new System.EventHandler(this.btnaddTopo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbDays);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbSupplier);
            this.panel1.Location = new System.Drawing.Point(9, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 42);
            this.panel1.TabIndex = 3;            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(458, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "days ago in order needed";
            // 
            // cbDays
            // 
            this.cbDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDays.FormattingEnabled = true;
            this.cbDays.Items.AddRange(new object[] {
            "60",
            "90",
            "160",
            "366"});
            this.cbDays.Location = new System.Drawing.Point(401, 7);
            this.cbDays.Name = "cbDays";
            this.cbDays.Size = new System.Drawing.Size(51, 21);
            this.cbDays.TabIndex = 7;
            this.cbDays.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(373, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "For";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Supplier:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.LightSlateGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 54);
            this.button1.TabIndex = 10;
            this.button1.Text = "Show Log";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UCCreatePurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "UCCreatePurchaseOrders";
            this.Size = new System.Drawing.Size(962, 401);
            this.Load += new System.EventHandler(this.UCPurchaseOrders_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnaddTopo;
        private System.Windows.Forms.Timer timer1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityOrdered;
        private System.Windows.Forms.Button button1;
    }
}
