namespace MgInfo
{
    partial class FormDeleteKhoa
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.comboBoxLop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteKhoa = new System.Windows.Forms.Button();
            this.btnDeleteLop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(102, 157);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Khoa";
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.FormattingEnabled = true;
            this.comboBoxKhoa.Location = new System.Drawing.Point(97, 25);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(119, 21);
            this.comboBoxKhoa.TabIndex = 79;
            this.comboBoxKhoa.SelectionChangeCommitted += new System.EventHandler(this.comboBoxKhoa_SelectionChangeCommitted);
            // 
            // comboBoxLop
            // 
            this.comboBoxLop.FormattingEnabled = true;
            this.comboBoxLop.Location = new System.Drawing.Point(96, 61);
            this.comboBoxLop.Name = "comboBoxLop";
            this.comboBoxLop.Size = new System.Drawing.Size(120, 21);
            this.comboBoxLop.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Lớp";
            // 
            // btnDeleteKhoa
            // 
            this.btnDeleteKhoa.Location = new System.Drawing.Point(102, 97);
            this.btnDeleteKhoa.Name = "btnDeleteKhoa";
            this.btnDeleteKhoa.Size = new System.Drawing.Size(81, 23);
            this.btnDeleteKhoa.TabIndex = 1;
            this.btnDeleteKhoa.Text = "Xóa Khoa";
            this.btnDeleteKhoa.UseVisualStyleBackColor = true;
            this.btnDeleteKhoa.Click += new System.EventHandler(this.btnDeleteKhoa_Click);
            // 
            // btnDeleteLop
            // 
            this.btnDeleteLop.Location = new System.Drawing.Point(102, 126);
            this.btnDeleteLop.Name = "btnDeleteLop";
            this.btnDeleteLop.Size = new System.Drawing.Size(81, 23);
            this.btnDeleteLop.TabIndex = 2;
            this.btnDeleteLop.Text = "Xóa Lớp";
            this.btnDeleteLop.UseVisualStyleBackColor = true;
            this.btnDeleteLop.Click += new System.EventHandler(this.btnDeleteLop_Click);
            // 
            // FormDeleteKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 199);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteLop);
            this.Controls.Add(this.btnDeleteKhoa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxKhoa);
            this.Controls.Add(this.comboBoxLop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Name = "FormDeleteKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa khoa hoặc lớp";
            this.Load += new System.EventHandler(this.FormDeleteKhoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
        private System.Windows.Forms.ComboBox comboBoxLop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteKhoa;
        private System.Windows.Forms.Button btnDeleteLop;
    }
}