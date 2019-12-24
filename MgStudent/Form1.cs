using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MgInfo;
using FormSinhVien;

namespace MgStudent
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        BUS_USER bus = new BUS_USER();

        // hàm làm ẩn chữ "user name" trong phần đăng nhập
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "user name")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        //hàm làm ẩn chữ "password" trong phần đăng nhập
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.Black;
            }
        }

        // Hàm kiểm tra có chứa dấu nháy đơn khi nhập ký tự -  tránh lỗi SQL injection
        public static bool IsApostrophe(Char c)
        {
            if (c == 39)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //hàm kiểm tra việc nhập có chứa kí tự ảnh hưởng đến truy vấn dữ liệu hay không
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //hàm kiểm tra việc nhập có chứa kí tự ảnh hưởng đến truy vấn dữ liệu hay không
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //hàm xử lý đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            String user = txtUser.Text;
            String password = txtPassword.Text;

            USER uSER = new USER();
            uSER.Username = user;
            uSER.Password = password;
            string role = bus.checkRole(uSER);
            if (role=="2")
            {
                FormInfo formInfo = new FormInfo(role);

                formInfo.ShowDialog();
                //this.Hide();
            }
            else if(role=="0" || role=="1")
            {
                Form_SinhVien formSinhVien = new Form_SinhVien(user, role);
                formSinhVien.ShowDialog();
            }
            else if(role=="")
            {
                MessageBox.Show("Lỗi: Sai tên đăng nhập hoặc mật khẩu.");
            }
        }

    }
}
