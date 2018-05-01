namespace ScanINOUTVer2
{
    partial class frmChangeColumnHeader
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeHeader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(89, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Header Text:";
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
            this.btnChangeHeader.Location = new System.Drawing.Point(179, 38);
            this.btnChangeHeader.Name = "btnChangeHeader";
            this.btnChangeHeader.Size = new System.Drawing.Size(60, 31);
            this.btnChangeHeader.TabIndex = 10;
            this.btnChangeHeader.Text = "Save";
            this.btnChangeHeader.UseVisualStyleBackColor = false;
            this.btnChangeHeader.Click += new System.EventHandler(this.btnChangeHeader_Click);
            // 
            // frmChangeColumnHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(251, 84);
            this.Controls.Add(this.btnChangeHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangeColumnHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Column Header";
            this.Load += new System.EventHandler(this.frmChangeColumnHeader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeHeader;
    }
}