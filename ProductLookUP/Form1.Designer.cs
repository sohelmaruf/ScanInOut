namespace ProductLookUP
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRenameHeaders = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnINAdd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LocalSKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QOH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integer3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integer4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integer5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReorderPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReorderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSave = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmUndo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(81, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label53.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label53.ForeColor = System.Drawing.Color.Lavender;
            this.label53.Location = new System.Drawing.Point(3, 9);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 29);
            this.label53.TabIndex = 50;
            this.label53.Text = "Barcode:";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.btnRenameHeaders);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnINAdd);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label53);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnRenameHeaders
            // 
            this.btnRenameHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameHeaders.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRenameHeaders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenameHeaders.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRenameHeaders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameHeaders.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnRenameHeaders.ForeColor = System.Drawing.Color.Black;
            this.btnRenameHeaders.Location = new System.Drawing.Point(698, 8);
            this.btnRenameHeaders.Name = "btnRenameHeaders";
            this.btnRenameHeaders.Size = new System.Drawing.Size(127, 30);
            this.btnRenameHeaders.TabIndex = 5;
            this.btnRenameHeaders.Text = "Rename Headers";
            this.btnRenameHeaders.UseVisualStyleBackColor = false;
            this.btnRenameHeaders.Click += new System.EventHandler(this.btnRenameHeaders_Click);
            this.btnRenameHeaders.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(553, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Edit Master";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // btnINAdd
            // 
            this.btnINAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnINAdd.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnINAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnINAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnINAdd.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnINAdd.ForeColor = System.Drawing.Color.Black;
            this.btnINAdd.Location = new System.Drawing.Point(830, 7);
            this.btnINAdd.Name = "btnINAdd";
            this.btnINAdd.Size = new System.Drawing.Size(127, 30);
            this.btnINAdd.TabIndex = 6;
            this.btnINAdd.Text = "Change Password";
            this.btnINAdd.UseVisualStyleBackColor = false;
            this.btnINAdd.Click += new System.EventHandler(this.btnINAdd_Click);
            this.btnINAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSlateGray;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(421, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 26);
            this.button3.TabIndex = 2;
            this.button3.Text = "Search...";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 29);
            this.label1.TabIndex = 53;
            this.label1.Text = "SKU:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(275, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocalSKU,
            this.ItemName,
            this.Price,
            this.Price2,
            this.Price3,
            this.QOH,
            this.Integer1,
            this.Integer2,
            this.Integer3,
            this.Integer4,
            this.Integer5,
            this.Barcode,
            this.ReorderPoint,
            this.ReorderQuantity,
            this.clmSave,
            this.clmUndo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(960, 335);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // LocalSKU
            // 
            this.LocalSKU.DataPropertyName = "LocalSKU";
            this.LocalSKU.HeaderText = "LocalSKU";
            this.LocalSKU.Name = "LocalSKU";
            this.LocalSKU.ReadOnly = true;
            this.LocalSKU.Width = 150;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // Price2
            // 
            this.Price2.DataPropertyName = "Price2";
            this.Price2.HeaderText = "Price2";
            this.Price2.Name = "Price2";
            this.Price2.ReadOnly = true;
            this.Price2.Width = 70;
            // 
            // Price3
            // 
            this.Price3.DataPropertyName = "Price3";
            this.Price3.HeaderText = "Price3";
            this.Price3.Name = "Price3";
            this.Price3.ReadOnly = true;
            this.Price3.Width = 70;
            // 
            // QOH
            // 
            this.QOH.DataPropertyName = "QOH";
            this.QOH.HeaderText = "QOH";
            this.QOH.Name = "QOH";
            this.QOH.ReadOnly = true;
            this.QOH.Width = 50;
            // 
            // Integer1
            // 
            this.Integer1.DataPropertyName = "Integer1";
            this.Integer1.HeaderText = "Integer1";
            this.Integer1.Name = "Integer1";
            this.Integer1.ReadOnly = true;
            this.Integer1.Width = 60;
            // 
            // Integer2
            // 
            this.Integer2.DataPropertyName = "Integer2";
            this.Integer2.HeaderText = "Integer2";
            this.Integer2.Name = "Integer2";
            this.Integer2.ReadOnly = true;
            this.Integer2.Width = 60;
            // 
            // Integer3
            // 
            this.Integer3.DataPropertyName = "Integer3";
            this.Integer3.HeaderText = "Integer3";
            this.Integer3.Name = "Integer3";
            this.Integer3.ReadOnly = true;
            this.Integer3.Width = 60;
            // 
            // Integer4
            // 
            this.Integer4.DataPropertyName = "Integer4";
            this.Integer4.HeaderText = "Integer4";
            this.Integer4.Name = "Integer4";
            this.Integer4.ReadOnly = true;
            this.Integer4.Width = 60;
            // 
            // Integer5
            // 
            this.Integer5.DataPropertyName = "Integer5";
            this.Integer5.HeaderText = "Integer5";
            this.Integer5.Name = "Integer5";
            this.Integer5.ReadOnly = true;
            this.Integer5.Width = 60;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // ReorderPoint
            // 
            this.ReorderPoint.DataPropertyName = "ReorderPoint";
            this.ReorderPoint.HeaderText = "ReorderPoint";
            this.ReorderPoint.Name = "ReorderPoint";
            this.ReorderPoint.ReadOnly = true;
            // 
            // ReorderQuantity
            // 
            this.ReorderQuantity.DataPropertyName = "ReorderQuantity";
            this.ReorderQuantity.HeaderText = "ReorderQuantity";
            this.ReorderQuantity.Name = "ReorderQuantity";
            this.ReorderQuantity.ReadOnly = true;
            // 
            // clmSave
            // 
            this.clmSave.HeaderText = "Save";
            this.clmSave.Name = "clmSave";
            this.clmSave.ReadOnly = true;
            this.clmSave.Text = "Save";
            this.clmSave.UseColumnTextForButtonValue = true;
            this.clmSave.Width = 50;
            // 
            // clmUndo
            // 
            this.clmUndo.HeaderText = "Undo";
            this.clmUndo.Name = "clmUndo";
            this.clmUndo.ReadOnly = true;
            this.clmUndo.Text = "Undo";
            this.clmUndo.UseColumnTextForButtonValue = true;
            this.clmUndo.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(984, 411);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product LookUP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnINAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRenameHeaders;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalSKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price3;
        private System.Windows.Forms.DataGridViewTextBoxColumn QOH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integer3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integer4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integer5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReorderPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReorderQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn clmSave;
        private System.Windows.Forms.DataGridViewButtonColumn clmUndo;
    }
}

