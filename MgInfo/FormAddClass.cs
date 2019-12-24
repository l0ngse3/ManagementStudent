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
    public partial class FormAddClass : Form
    {
        BUS_Info_ bus = new BUS_Info_();
        public FormAddClass()
        {
            InitializeComponent();
        }

        private void FormAddClass_Load(object sender, EventArgs e)
        {
            DataTable table = bus.GetKhoa();

            //comboBoxKhoa.Items.Clear();
            comboBoxKhoa.DataSource = table;
            comboBoxKhoa.DisplayMember = "Khoa";
            comboBoxKhoa.ValueMember = "Khoa";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            lop.TenLop = txtLop.Text;
            lop.Khoa = comboBoxKhoa.Text;
            lop.MaKhoa = txtKhoa.Text;

            if(bus.addClass(lop))
            {
                MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lớp đã tồn tại hoặc bạn điền sai thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void txtKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            FormAddKhoa formAddKhoa = new FormAddKhoa();
            formAddKhoa.ShowDialog();

            FormAddClass_Load(sender, e);
        }
    }
}
