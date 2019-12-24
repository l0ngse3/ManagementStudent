using BUS_Info;
using DTO;
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
using Excel = Microsoft.Office.Interop.Excel;


namespace MgInfo
{
    public partial class FormInfo : Form
    {
        //Bus cho tab 1: quản lý thông tin
        BUS_Info_ bus = new BUS_Info_();
        //
        //Bus cho tab 2: quản lý tài khoản
        BUS_Mg_User bus_mg_user = new BUS_Mg_User();


        string role = "0";
        int current_row = 1; // mặc định dòng chọn dòng đầu tiên trong dgvMain
        private string ma_temp = ""; //Lấy để lưu giá trị mã sinh viên nhằm không cho việc thay đổi mã
        string lop;
        string gioiTinh = "Nam";  //Lấy giá trị mặc định cho radio button
        static int on_add_file = 0; // biến mặc định khi chưa add file excel là 0, kiểm soát việc đọc ghi file

        public FormInfo()
        {
            InitializeComponent();
        }

        public FormInfo(string role)
        {
            this.role = role;
            InitializeComponent();
        }


        /*
         * TAB 1: Quản lý thông tin sinh viên
         * 
         * Chức năng chính:
         *  - Thêm , sửa, xóa các thông tin của sinh viên
         *  - Nhập dữ liệu từ ngoài vào bằng file excel 2003 (*.xls)
         *  - Xuất dữ liệu từ data base ra file excel 2003 (*.xls)
         *  - Tìm kiếm mã sinh viên theo mã, lớp và khoa.
         * 
         * 
         *
         */
        // Hàm kiểm tra có chứa dấu nháy đơn khi nhập ký tự -  tránh lỗi SQL injection
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

        private void mgInfo_Load(object sender, EventArgs e)
        {
            dgvMain.Columns.Clear();
            dgvMain.DataSource = null;
            

                if (bus.getSinhVien() != null)
                {
                    //khởi tạo dữ liệu cho data grid view khi khởi động
                    DataTable table_sv = bus.getSinhVien();
                    dgvMain.DataSource = table_sv;
                }
                else
                {
                    MessageBox.Show("Chưa có dữ liệu", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //truyền dữ liệu khởi tạo combo box khoa trên thanh tìm kiếm
                DataTable table_khoa = bus.GetKhoa();
                //comboBoxSearchKhoa.Items.Clear();
                comboBoxSearchKhoa.DataSource = table_khoa;
                comboBoxSearchKhoa.DisplayMember = "Khoa";
                comboBoxSearchKhoa.ValueMember = "Khoa";

                //comboBoxKhoa.Items.Clear();
                comboBoxKhoa.DataSource = table_khoa;
                comboBoxKhoa.DisplayMember = "Khoa";
                comboBoxKhoa.ValueMember = "Khoa";


            //
            //Gán dữ liệu vào bảng quản lý tài khoản đăng nhập của sinh viên
            dgvUser.DataSource = bus_mg_user.getUserStudent();

            //
            //
            //Gán dữ liệu vào bảng quản lý tải khoản đăng nhập của quản trị viên
            dgvAdminUser.DataSource = bus_mg_user.getUserAdmin();

            //
            //
            
        }

        //Thêm lớp vào bảng lớp
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            FormAddClass addClass = new FormAddClass();
            addClass.ShowDialog();
            mgInfo_Load(sender, e);
        }

        //Hàm kiểm tra kí tự trong ô mã sinh viên - chỉ cho nhập số
        private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Hàm kiểm tra kí tự trong ô tên sinh viên - chỉ cho nhập chữ
        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Hàm kiểm tra kí tự trong ô số điện thoại - chỉ cho nhập số
        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Hàm kiểm tra kí tự trong ô lớp và không cho nhập kí tự nháy đơn tránh lỗi khi query
        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Hàm bật chức năng mở file khi import
        private void txtPath_DoubleClick(object sender, EventArgs e)
        {
            btnImport_Click(sender, e);
        }

        //Hàm thêm dữ liệu bằng excel
        private void btnImport_Click(object sender, EventArgs e)
        {
            dgvMain.Columns.Clear();

            try
            {
                MessageBox.Show("Chỉ có thể Import file theo Template, nếu không chỉ có thể đọc được file mà không lưu lại được dữ liệu. Bấm OK để tiếp tục.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult quest = MessageBox.Show("Bạn muốn thêm mới toàn bộ dữ liệu hay CHỈ XEM và thêm riêng lẻ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "(Các tệp excel 2003)|*.xls";
                open.ShowDialog();

                on_add_file = 1;

                string fileName = open.FileName;
                string[] filePart = fileName.Split('.');
                txtPath.Text = open.FileName;

                if (fileName != "" && filePart[1] == "xls")
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook wb = app.Workbooks.Open(open.FileName);


                    try
                    {
                        Excel._Worksheet sheet = wb.Sheets[1];
                        Excel.Range range = sheet.UsedRange;
                        dgvMain.DataSource = null;
                        int rows = range.Rows.Count;
                        int cols = range.Columns.Count;
                        runProgressBar("Opening");
                        //Sinh tiêu đề trong Data grid view
                        for (int c = 1; c <= cols; c++)
                        {
                            string colName = range.Cells[2, c].Value.ToString();
                            dgvMain.Columns.Add(colName, colName);
                        }



                        //Đọc dữ liệu từ file excel vào và format dữ liệu
                        for (int r = 3; r <= rows; r++)
                        {
                            string[] cell1 = new string[7];
                            for (int c = 1; c <= cols; c++)
                            {
                                string data;
                                if (c == 4)
                                {
                                    data = range.Cells[r, c].Value.ToString("MM/dd/yyyy");
                                }
                                else
                                {
                                    data = range.Cells[r, c].Value.ToString();
                                }
                                cell1[c - 1] = data;
                            }
                            dgvMain.Rows.Add(cell1);
                        }


                        //Xử lý ghi dữ liệu từ file vào database khi người dùng đồng ý ghi đè dữ liệu cũ
                        if (quest == DialogResult.Yes)
                        {
                            SinhVien sv = new SinhVien();
                            bus.deleteAllSinhVien();

                            for (int i = dgvMain.RowCount - 1; i >= 0; i--)
                            {
                                sv.MaSV = dgvMain.Rows[i].Cells[0].Value.ToString();
                                sv.Ten = dgvMain.Rows[i].Cells[1].Value.ToString();
                                sv.DiaChi = dgvMain.Rows[i].Cells[2].Value.ToString();
                                sv.NgaySinh = dgvMain.Rows[i].Cells[3].Value.ToString();
                                sv.Lop = dgvMain.Rows[i].Cells[4].Value.ToString();
                                sv.Sdt = dgvMain.Rows[i].Cells[5].Value.ToString();
                                if (dgvMain.Rows[i].Cells[6].Value.ToString() == "True")
                                {
                                    sv.GioiTinh = true;
                                }
                                else
                                {
                                    sv.GioiTinh = false;
                                }

                                bus.addSinhVien(sv);

                            }

                            MessageBox.Show("Đã cập nhật toàn bộ danh sách lớp trên Database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //MainBoard_Load(sender, e);
                            app.Quit();
                            wb = null;

                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Bạn không chọn file nào hoặc không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mgInfo_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                hideProgressBar();
            }
        }

        //Hàm xuất dữ liệu bằng excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            runProgressBar("Loading");
            SaveFileDialog fsave = new SaveFileDialog();
            fsave.Filter = "(Các tệp excel 2003)|*.xls";
            fsave.ShowDialog();
            txtPath.Text = fsave.FileName;
            //xử lý
            if (fsave.FileName != "")
            {

                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);

                Excel.Worksheet sheet = null;

                try
                {
                    //Đọc data từ grid view để export
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Sheet1";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgvMain.ColumnCount]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách sinh viên";
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;

                    string[] arr = { "Mã SV", "Họ và tên", "Địa chỉ", "Ngày Sinh", "Lớp", "SĐT", "Nam" };
                    //sinh tiêu đề
                    for (int i = 1; i <= dgvMain.ColumnCount; i++)
                    {
                        sheet.Cells[2, i] = arr[i - 1];
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //ghi dữ liệu
                    for (int i = 1; i <= dgvMain.RowCount; i++)
                    {
                        for (int j = 1; j <= dgvMain.ColumnCount; j++)
                        {
                            sheet.Cells[i + 2, j].Value = dgvMain.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }

                    wb.SaveAs(fsave.FileName);
                    MessageBox.Show("Ghi lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    app.Quit();
                    wb = null;
                }
            }
            hideProgressBar();
        }

        //hiệu ứng hiển thị progress bar
        private void runProgressBar(string s)
        {
            txtProgress.Visible = true;
            progressBar.Visible = true;

            txtProgress.Text = s;
            progressBar.PerformLayout();
        }

        //hiệu ứng ẩn progress bar
        private void hideProgressBar()
        {
            progressBar.Value = 100;
            txtProgress.Visible = false;
            progressBar.Visible = false;
        }

        //Hàm thêm sinh viên
        private void btnAdd_Click(object sender, EventArgs e)
        {
            runProgressBar("Adding");
            try
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMa.Text;
                sv.Ten = txtTen.Text;
                sv.NgaySinh = dateTimePickerNgaySinh.Value.ToString("dd/MM/yyyy");
                sv.Lop = comboBoxLop.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.Sdt = txtSdt.Text;
                if (rdnNu.Checked)
                {
                    sv.GioiTinh = false;
                    gioiTinh = "Nữ";
                }
                else
                {
                    sv.GioiTinh = true;
                    gioiTinh = "Nam";
                }

                if (txtMa.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống mã", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMa.Focus();
                }
                else if (txtTen.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTen.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Focus();
                }
                else if (comboBoxLop.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxLop.Focus();
                }
                else if (txtSdt.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSdt.Focus();
                }
                else if (bus.addSinhVien(sv))
                {
                    MessageBox.Show("\nMã: " + sv.MaSV + "\nHọ tên: " + sv.Ten + "\nNgày sinh: " + sv.NgaySinh + "\nGiới tính: " + gioiTinh, "Đã thêm sinh viên");
                    mgInfo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, có thể do mã trùng hoặc định dạng không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMa.Focus();
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                hideProgressBar();
            }
        }

        //hàm sửa thông tin của sinh viên - không cho phép sửa mã
        private void btnEdit_Click(object sender, EventArgs e)
        {
            runProgressBar("Editing");
            try
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = ma_temp;
                sv.Ten = txtTen.Text;
                sv.NgaySinh = dateTimePickerNgaySinh.Value.ToString("dd/MM/yyyy");
                sv.Lop = comboBoxLop.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.Sdt = txtSdt.Text;
                if (rdnNu.Checked)
                {
                    sv.GioiTinh = false;
                    gioiTinh = "Nữ";
                }
                else
                {
                    sv.GioiTinh = true;
                    gioiTinh = "Nam";
                }

                if (bus.EditSinhVien(sv))
                {
                    MessageBox.Show("\nMã: " + sv.MaSV + "\nHọ tên: " + sv.Ten + "\nNgay sinh: " + sv.NgaySinh + "\nGiới Tính: " + gioiTinh, "Đã thêm sinh viên");
                    mgInfo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Focus();
                    txtMa.Text = ma_temp;
                }

            }
            catch (Exception )
            {

            }
            finally
            {
                hideProgressBar();
            }
        }

        //Hàm xóa thông tin của sinh viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            runProgressBar("Deleting");
            try
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = ma_temp;

                if (bus.deleteSinhVien(sv))
                {
                    MessageBox.Show("Xóa thành công", "Đã xóa");
                    mgInfo_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMa.Focus();
                }

            }
            catch (Exception err)
            {

            }
            finally
            {
                hideProgressBar();
            }
        }

        //Xử lý việc đẩy ngược dữ liệu lên view khi bấm vào một dòng trong data grid view
        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                current_row = r;


                txtMa.Text = dgvMain.Rows[r].Cells[0].Value.ToString();
                ma_temp = txtMa.Text;
                txtTen.Text = dgvMain.Rows[r].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvMain.Rows[r].Cells[2].Value.ToString();
                dateTimePickerNgaySinh.Value = DateTime.Parse(dgvMain.Rows[r].Cells[3].Value.ToString());
                comboBoxLop.Text = dgvMain.Rows[r].Cells[4].Value.ToString();
                lop = comboBoxLop.Text;
                txtSdt.Text = dgvMain.Rows[r].Cells[5].Value.ToString();
                if (dgvMain.Rows[r].Cells[6].Value.Equals(true) || dgvMain.Rows[r].Cells[6].Value.ToString() == "True")
                {
                    rdnNam.Checked = true;
                }
                else
                {
                    rdnNu.Checked = true;
                }
            }
            catch (Exception)
            {

            }
        }

        // hàm xóa khoa hoặc lớp nào đó
        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            FormDeleteKhoa formDelete = new FormDeleteKhoa();
            formDelete.ShowDialog();
            mgInfo_Load(sender, e);
        }

        //nhập mã sinh viên vào ô tìm kiếm - chỉ cho nhập số
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //hàm tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(comboBoxSearchKhoa.Text!="" && comboBoxSearchLop.Text!="")
            {
                string key_word = txtSearch.Text;
                key_word += "_" + comboBoxSearchLop.Text;
                key_word += "_" + comboBoxSearchKhoa.Text;
                dgvMain.DataSource = null;
                dgvMain.Columns.Clear();
                DataTable dataTable = bus.getSinhVienSearch(key_word);
                dgvMain.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Chọn thiếu thông tin trong hộp tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //hiển thị tên các lớp theo khoa đã chọn trên thanh tìm kiếm
        private void comboBoxSearchKhoa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //truyền dữ liệu khởi tạo combo box lớp trên thanh tìm kiếm
            ArrayList arr = bus.GetLop(comboBoxSearchKhoa.SelectedValue.ToString());
            comboBoxSearchLop.Items.Clear();
            foreach (string item in arr)
            {
                comboBoxSearchLop.Items.Add(item);
            }
        }

        //hiển thị tên các lớp theo khoa đã chọn
        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList arr = bus.GetLop(comboBoxKhoa.SelectedValue.ToString());
            comboBoxLop.Items.Clear();
            comboBoxLop.Text = "";
            foreach (string item in arr)
            {
                comboBoxLop.Items.Add(item);
            }
        }

        //Hàm đóng form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* TAB 2: Quản lý tài khoản sinh viên
         * 
         * Chức năng chính:
         *  - Thêm tài khoản
         *  - Sửa đổi mật khẩu các tài khoản
         *  - Sửa quyền truy cập của các tài khoản
         *  - Xóa tài khoản
         *  - Đồng bộ tài khoản chưa có dựa vào dữ liệu đã import hoặc đã nhập từ Tab quản lý thông tin
         * 
         *
         */


        //Hàm tìm kiếm tài khoản sinh viên theo mã sinh viên
        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string ma = txtSearchUser.Text;
            dgvUser.DataSource = bus_mg_user.searchUserStudent(ma);
        }

        //hàm đồng bộ tài khoản sinh viên từ data base của tab thông tin sang thành các user có thể đăng nhập được.
        private void btnSync_Click(object sender, EventArgs e)
        {
            int rows = dgvMain.RowCount;
            for(int i=0; i<rows; i++)
            {
                USER user = new USER();
                user.Username = dgvMain.Rows[i].Cells[0].Value.ToString();
                user.Password = "123456";
                user.Role = 0;
                bus_mg_user.addUser(user);
            }

            DataTable table_user = bus_mg_user.getUserStudent();
            dgvUser.DataSource = table_user;
            MessageBox.Show("Đã đồng bộ tài khoản xong!");
        }

        //Hàm đẩy ngược dữ liệu từ data grid view lên các view để chỉnh sửa
        private void dgvUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            txtUsername.Text = dgvUser.Rows[r].Cells[0].Value.ToString();
            ma_temp = txtUsername.Text;
            txtPassword.Text = dgvUser.Rows[r].Cells[1].Value.ToString();

            if(dgvUser.Rows[r].Cells[2].Value.ToString() == "1")
            {
                checkBoxCanBoLop.Checked = true;
            }
            else
            {
                checkBoxCanBoLop.Checked = false;
            }
        }

        //Hàm thêm từng user một
        private void btnThem_Click(object sender, EventArgs e)
        {
            USER user = new USER();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            if(checkBoxCanBoLop.Checked)
            {
                user.Role = 1;
            }
            else
            {
                user.Role = 0;
            }

            if(bus_mg_user.addUser(user))
            {
                MessageBox.Show("Đã thêm!" + "\nUser name: " + user.Username + "\nPassword: " + user.Password + "\nRole: " + user.Role, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable table_user = bus_mg_user.getUserStudent();
                dgvUser.DataSource = table_user;
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại hoặc bạn đã nhập không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hàm sửa mật khẩu và quyền truy cập của các tài khoản
        private void btnSua_Click(object sender, EventArgs e)
        {
            USER user = new USER();
            user.Username = ma_temp;
            user.Password = txtPassword.Text;
            if (checkBoxCanBoLop.Checked)
            {
                user.Role = 1;
            }
            else
            {
                user.Role = 0;
            }

            bus_mg_user.deleteUser(user);

            if (bus_mg_user.addUser(user))
            {
                MessageBox.Show("Cập nhật thành công!" + "\nUser name: " + user.Username + "\nPassword: " + user.Password + "\nRole: " + user.Role, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable table_user = bus_mg_user.getUserStudent();
                dgvUser.DataSource = table_user;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hàm xóa thông tin đăng nhập của một user. Hàm này không ảnh hưởng đến việc hàm lưu trữ các sinh viên trong bảng SinhVien
        private void btnXoa_Click(object sender, EventArgs e)
        {
            USER user = new USER();
            user.Username = ma_temp;
            user.Password = txtPassword.Text;
            if (checkBoxCanBoLop.Checked)
            {
                user.Role = 1;
            }
            else
            {
                user.Role = 0;
            }

            if (bus_mg_user.deleteUser(user))
            {
                MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable table_user = bus_mg_user.getUserStudent();
                dgvUser.DataSource = table_user;
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TAB 3: Quản lý tài khoản quản trị viên
         * 
         * Chức năng chính:
         *  - Thêm tài khoản
         *  - Sửa đổi mật khẩu các tài khoản
         *  - Xóa tài khoản
         */
         
        // kiểm soát cú pháp nhập tìm kiếm
        private void txtSearchAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Hàm tìm kiếm tài khoản quản trị viên
        private void btnSearchAdmin_Click(object sender, EventArgs e)
        {
            string s = txtSearchAdmin.Text;
            dgvAdminUser.DataSource = bus_mg_user.searchUserAdmin(s);
        }

        // kiểm soát cú pháp nhập của tài khoản admin
        private void txtAdminUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // kiểm soát cú pháp nhập của mật khẩu admin
        private void txtPassAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsApostrophe(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // hàm đẩy ngược dữ liệu của thông tin tài khoản admin từ data grid view của  lên trên view
        private void dgvAdminUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            txtAdminUser.Text = dgvAdminUser.Rows[r].Cells[0].Value.ToString();
            ma_temp = txtAdminUser.Text;
            txtPassAdmin.Text = dgvAdminUser.Rows[r].Cells[1].Value.ToString();
        }

        //hàm xóa tài khoản của quản trị viên
        private void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
            USER user = new USER();

            user.Username = txtAdminUser.Text;
            user.Password = txtPassAdmin.Text;
            user.Role = 2;

            if (bus_mg_user.deleteUser(user))
            {
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAdminUser.DataSource = bus_mg_user.getUserAdmin();
            }
            else
            {
                MessageBox.Show("Không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // hàm thêm tài khoản của user admin
        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            USER user = new USER();

            user.Username = txtAdminUser.Text;
            user.Password = txtPassAdmin.Text;
            user.Role = 2;

            if (bus_mg_user.addUser(user))
            {
                MessageBox.Show("Đã thêm!" + "\nUser name: " + user.Username + "\nPassword: " + user.Password + "\nRole: " + user.Role, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAdminUser.DataSource = bus_mg_user.getUserAdmin();
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại hoặc bạn đã nhập không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //hàm sửa mật khẩu của quản trị viên
        private void btnEditAdmin_Click(object sender, EventArgs e)
        {
            USER user = new USER();

            user.Username = ma_temp;
            user.Password = txtPassAdmin.Text;
            user.Role = 2;

            bus_mg_user.deleteUser(user);

            if (bus_mg_user.addUser(user))
            {
                MessageBox.Show("Cập nhật thành công!" + "\nUser name: " + user.Username + "\nPassword: " + user.Password + "\nRole: " + user.Role, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAdminUser.DataSource = bus_mg_user.getUserAdmin();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //
    }
}
