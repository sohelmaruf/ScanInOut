namespace ScanINOUTVer2
{
    partial class frmSupplierItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.clmPONum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplierSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnaddTopo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.clmCost,
            this.clmQuantityOrdered});
            this.dgvData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvData.Location = new System.Drawing.Point(12, 12);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(890, 305);
            this.dgvData.TabIndex = 112;
            this.dgvData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvData_CellBeginEdit);
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
            this.dgvData.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellLeave);
            this.dgvData.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvData_EditingControlShowing);
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
            // clmCost
            // 
            this.clmCost.DataPropertyName = "QtyToOrder";
            this.clmCost.FillWeight = 20F;
            this.clmCost.HeaderText = "Qty To Order";
            this.clmCost.Name = "clmCost";
            // 
            // clmQuantityOrdered
            // 
            this.clmQuantityOrdered.DataPropertyName = "SuuplierID";
            this.clmQuantityOrdered.HeaderText = "Suuplier ID";
            this.clmQuantityOrdered.Name = "clmQuantityOrdered";
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
            this.btnaddTopo.Location = new System.Drawing.Point(767, 323);
            this.btnaddTopo.Name = "btnaddTopo";
            this.btnaddTopo.Size = new System.Drawing.Size(135, 54);
            this.btnaddTopo.TabIndex = 113;
            this.btnaddTopo.Text = "Add To List";
            this.btnaddTopo.UseVisualStyleBackColor = false;
            this.btnaddTopo.Click += new System.EventHandler(this.btnaddTopo_Click);
            // 
            // frmSupplierItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(914, 378);
            this.Controls.Add(this.btnaddTopo);
            this.Controls.Add(this.dgvData);
            this.Name = "frmSupplierItems";
            this.Text = "frmSupplierItems";
            this.Load += new System.EventHandler(this.frmSupplierItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPONum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplierSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantityOrdered;
        private System.Windows.Forms.Button btnaddTopo;
    }
}