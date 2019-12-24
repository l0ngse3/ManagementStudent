using BUS_Student;
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

namespace FormSinhVien
{
    public partial class Form_SinhVien : Form
    {
        BUS_Student_ bus = new BUS_Student_();

        string ma="";
        string role = "";
        bool gt;
        public Form_SinhVien()
        {
            InitializeComponent();
        }

        //Constructor lấy thông tin mã sinh viên sau khi đăng nhập thành công
        public Form_SinhVien(string ma, string role)
        {
            this.ma = ma;
            this.role = role;
            InitializeComponent();
        }

        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("MaSV: " + ma);

            if (bus.getStudent(ma)!= null)
            {
                //khởi tạo đối tượng đăng nhập và validate thông tin
                SinhVien sv = bus.getStudent(ma);
                txtMa.Text = sv.MaSV;
                txtTen.Text = sv.Ten;
                txtDiaChi.Text = sv.DiaChi;
                dateTimePickerNgaySinh.Value = DateTime.Parse(sv.NgaySinh);
                txtLop.Text = sv.Lop;
                txtSdt.Text = sv.Sdt;
                gt = sv.GioiTinh;
                
                //tắt quyền edit khi đăng nhập của các text view
                txtMa.Enabled = false;
                txtLop.Enabled = false;
                txtTen.Enabled = false;
                richTextBoxThongBao.Enabled = false;

                // hàm lọc ra tên gán vào label chào
                string[] arr = sv.Ten.Split(' ');
                int l = arr.Length;
                string nameHello = arr[l - 2] + " " + arr[l - 1];
                lblWelcome.Text = "Xin chào, " + nameHello;

                //Cập nhật thông báo từ lớp trưởng.
                string[] message = bus.getMessages().Split('-');
                if(message[message.Length-1].Trim() != "")
                {
                    int leng = message.Length;
                    string content = "Thông báo: " + message[2] + "\nĐăng lúc: " + message[1] + "\n\n\nNội dung: \n" + message[3];
                    richTextBoxThongBao.Text = content;
                }
                else
                {
                    richTextBoxThongBao.Text = "Không có thông báo nào!";
                }

                //bật các button đặc biệt của lớp trưởng
                if(role=="1")
                {
                    btnDangThongBao.Visible = true;
                }


            }
            else
            {
                MessageBox.Show("Lỗi đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm chỉnh sửa thông tin cá nhân của sinh viên sau khi đăng nhập
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMa.Text;
            sv.Ten = txtTen.Text;
            sv.DiaChi = txtDiaChi.Text;
            sv.NgaySinh = dateTimePickerNgaySinh.Value.ToString();
            sv.Lop = txtLop.Text;
            sv.Sdt = txtSdt.Text;
            sv.GioiTinh = gt;

            if(bus.updateStudent(sv))
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //hàm lấy danh sách lớp từ cơ sở dữ liệu. Lọc ra những sinh viên học cùng lớp
        private void btnLayDanhSachLop_Click(object sender, EventArgs e)
        {
            FormExportStudent formExportStudent = new FormExportStudent(txtLop.Text);
            formExportStudent.ShowDialog();
        }

        //hàm tạo thông báo - chức năng này chỉ có lớp trưởng mới có.
        private void btnDangThongBao_Click(object sender, EventArgs e)
        {
            FormUploadMessages formUpload = new FormUploadMessages();
            formUpload.ShowDialog();
            FormSinhVien_Load(sender, e);
        }
    }
}
