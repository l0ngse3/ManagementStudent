using BUS_Info;
using DTO_Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MgInfo
{
    public partial class FormAddKhoa : Form
    {
        public FormAddKhoa()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsApostrophe(Char c)
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

        private void txtLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            BUS_Info_ bus = new BUS_Info_();

            Lop lop = new Lop();
            lop.TenLop = txtLop.Text;
            lop.Khoa = txtKhoa.Text;
            lop.MaKhoa = txtMaKhoa.Text;

            if (bus.addClass(lop))
            {
                MessageBox.Show("Thêm khoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Khoa đã tồn tại hoặc bạn điền sai thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormAddKhoa_Load(object sender, EventArgs e)
        {

        }
    }
}
