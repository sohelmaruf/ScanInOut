namespace ScanINOUTVer2
{
    partial class frmCustomizeColumnsIN
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnChangeHeader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Items.AddRange(new object[] {
            "ProductName",
            "Barcode",
            "SKU",
            "Price",
            "QOH",
            "SupplierSKU",
            "Price2",
            "Price3",
            "Price4",
            "Price5",
            "Price6",
            "Price7",
            "Price8",
            "Price9",
            "Price10",
            "Location",
            "OrderNumber",
            "Weight",
            "ReorderPoint",
            "Backordered",
            "ActualWeight",
            "Text1",
            "Text2",
            "Text3",
            "Text4",
            "Text5",
            "Integer1",
            "Integer2",
            "Integer3",
            "Integer4",
            "Integer5"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(182, 249);
            this.checkedListBox1.TabIndex = 0;
            // 
            // btnChangeHeader
            // 
            this.btnChangeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeHeader.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnChangeHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeHeader.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnChangeHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeHeader.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangeHeader.ForeColor = System.Drawing.Color.White;
            this.btnChangeHeader.Location = new System.Drawing.Point(12, 267);
            this.btnChangeHeader.Name = "btnChangeHeader";
            this.btnChangeHeader.Size = new System.Drawing.Size(182, 31);
            this.btnChangeHeader.TabIndex = 9;
            this.btnChangeHeader.Text = "Change Header Text";
            this.btnChangeHeader.UseVisualStyleBackColor = false;
            this.btnChangeHeader.Click += new System.EventHandler(this.btnChangeHeader_Click);
            // 
            // frmCustomizeColumnsIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(206, 310);
            this.Controls.Add(this.btnChangeHeader);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCustomizeColumnsIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customize Columns";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomizeColumnsIN_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomizeColumnsIN_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnChangeHeader;
    }
}