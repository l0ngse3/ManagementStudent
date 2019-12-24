namespace FormSinhVien
{
    partial class Form_SinhVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.dateTimePickerNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.richTextBoxThongBao = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDangThongBao = new System.Windows.Forms.Button();
            this.btnLayDanhSachLop = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thông tin cá nhân";
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(69, 206);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(119, 20);
            this.txtSdt.TabIndex = 81;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(69, 169);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(119, 20);
            this.txtDiaChi.TabIndex = 79;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(68, 132);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(119, 20);
            this.txtTen.TabIndex = 78;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(266, 134);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(119, 20);
            this.txtMa.TabIndex = 77;
            // 
            // dateTimePickerNgaySinh
            // 
            this.dateTimePickerNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNgaySinh.Location = new System.Drawing.Point(267, 169);
            this.dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            this.dateTimePickerNgaySinh.Size = new System.Drawing.Size(119, 20);
            this.dateTimePickerNgaySinh.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "SĐT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Ngày Sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Họ và tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Mã SV";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 88;
            this.label11.Text = "Lớp";
            // 
            // txtLop
            // 
            this.txtLop.Location = new System.Drawing.Point(268, 209);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(119, 20);
            this.txtLop.TabIndex = 89;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Location = new System.Drawing.Point(68, 266);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(318, 23);
            this.btnChinhSua.TabIndex = 90;
            this.btnChinhSua.Text = "Chỉnh sửa thông tin cá nhân";
            this.btnChinhSua.UseVisualStyleBackColor = true;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // richTextBoxThongBao
            // 
            this.richTextBoxThongBao.Location = new System.Drawing.Point(454, 128);
            this.richTextBoxThongBao.Name = "richTextBoxThongBao";
            this.richTextBoxThongBao.Size = new System.Drawing.Size(325, 168);
            this.richTextBoxThongBao.TabIndex = 91;
            this.richTextBoxThongBao.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(543, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 31);
            this.label7.TabIndex = 92;
            this.label7.Text = "Thông báo";
            // 
            // btnDangThongBao
            // 
            this.btnDangThongBao.Location = new System.Drawing.Point(571, 23);
            this.btnDangThongBao.Name = "btnDangThongBao";
            this.btnDangThongBao.Size = new System.Drawing.Size(105, 23);
            this.btnDangThongBao.TabIndex = 94;
            this.btnDangThongBao.Text = "Đăng thông báo";
            this.btnDangThongBao.UseVisualStyleBackColor = true;
            this.btnDangThongBao.Visible = false;
            this.btnDangThongBao.Click += new System.EventHandler(this.btnDangThongBao_Click);
            // 
            // btnLayDanhSachLop
            // 
            this.btnLayDanhSachLop.Location = new System.Drawing.Point(682, 23);
            this.btnLayDanhSachLop.Name = "btnLayDanhSachLop";
            this.btnLayDanhSachLop.Size = new System.Drawing.Size(105, 23);
            this.btnLayDanhSachLop.TabIndex = 95;
            this.btnLayDanhSachLop.Text = "Lấy danh sách lớp";
            this.btnLayDanhSachLop.UseVisualStyleBackColor = true;
            this.btnLayDanhSachLop.Click += new System.EventHandler(this.btnLayDanhSachLop_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(22, 23);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(77, 17);
            this.lblWelcome.TabIndex = 96;
            this.lblWelcome.Text = "Hello world";
            // 
            // Form_SinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 309);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLayDanhSachLop);
            this.Controls.Add(this.btnDangThongBao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBoxThongBao);
            this.Controls.Add(this.btnChinhSua);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.dateTimePickerNgaySinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Form_SinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.FormSinhVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMa;
        public System.Windows.Forms.DateTimePicker dateTimePickerNgaySinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.RichTextBox richTextBoxThongBao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDangThongBao;
        private System.Windows.Forms.Button btnLayDanhSachLop;
        private System.Windows.Forms.Label lblWelcome;
    }
}

