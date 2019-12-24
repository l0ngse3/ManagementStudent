using BUS_Info;
using DTO_Info;
using System;
using System.Collections;
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
    public partial class FormDeleteKhoa : Form
    {
        BUS_Info_ bus = new BUS_Info_();
        public FormDeleteKhoa()
        {
            InitializeComponent();
        }


        private void FormDeleteKhoa_Load(object sender, EventArgs e)
        {
            DataTable table_khoa = bus.GetKhoa();
            //comboBoxSearchKhoa.Items.Clear();
            comboBoxKhoa.DataSource = table_khoa;
            comboBoxKhoa.DisplayMember = "Khoa";
            comboBoxKhoa.ValueMember = "Khoa";
        }

        //ánh xạ dữ liệu theo dữ liệu đã chọn của combo box khoa
        private void comboBoxKhoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ArrayList arr = bus.GetLop(comboBoxKhoa.SelectedValue.ToString());
            comboBoxLop.Items.Clear();
            comboBoxLop.Text = "";
            foreach (string item in arr)
            {
                comboBoxLop.Items.Add(item);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // hàm xóa toàn bộ khoa và các lớp
        private void btnDeleteKhoa_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            string s;
            lop.Khoa = comboBoxKhoa.Text;
            s = lop.Khoa;
            if(bus.deleteKhoa(lop))
            {
                
                MessageBox.Show("Đã xóa khoa: "+s, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormDeleteKhoa_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại khoa: " + s, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hàm xóa một lớp trong một khoa
        private void btnDeleteLop_Click(object sender, EventArgs e)
        {
            string[] array;
            Lop lop = new Lop();
            string tenLop, tenKhoa;
            lop.Khoa = comboBoxKhoa.Text;
            array = comboBoxLop.Text.Split('-');
            lop.TenLop = array[0];

            tenLop = lop.TenLop;
            tenKhoa = lop.Khoa;
            if (bus.deleteClass(lop))
            { 
                MessageBox.Show("Đã xóa lớp: " + tenLop + " - Khoa: " + tenKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormDeleteKhoa_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại khoa: " +tenLop + " - Khoa: " + tenKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //
    }
}
