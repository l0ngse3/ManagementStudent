using BUS_Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormSinhVien
{
    public partial class FormExportStudent : Form
    {
        public string lop = "";
        BUS_Student_ bus = new BUS_Student_();

        public FormExportStudent()
        {
            InitializeComponent();
        }

        public FormExportStudent(string lop)
        {
            this.lop = lop;
            InitializeComponent();
        }

        private void FormExportStudent_Load(object sender, EventArgs e)
        {
            dgvDsLop.DataSource = bus.getStudentInClass(lop);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
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
                    runProgressBar("Loading");
                    //Đọc data từ grid view để export
                    sheet = wb.ActiveSheet;
                    sheet.Name = "Sheet1";
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, dgvDsLop.ColumnCount]].Merge();
                    sheet.Cells[1, 1].Value = "Danh sách sinh viên lớp " + lop;
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[1, 1].Borders.Weight = Excel.XlBorderWeight.xlThin;

                    string[] arr = { "Mã SV", "Họ và tên", "Địa chỉ", "Ngày Sinh", "Lớp", "SĐT", "Nam" };
                    //sinh tiêu đề
                    for (int i = 1; i <= dgvDsLop.ColumnCount; i++)
                    {
                        sheet.Cells[2, i] = arr[i - 1];
                        sheet.Cells[2, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        sheet.Cells[2, i].Font.Bold = true;
                        sheet.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                    }
                    //ghi dữ liệu
                    for (int i = 1; i <= dgvDsLop.RowCount; i++)
                    {
                        for (int j = 1; j <= dgvDsLop.ColumnCount; j++)
                        {
                            sheet.Cells[i + 2, j].Value = dgvDsLop.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }

                    wb.SaveAs(fsave.FileName);
                    hideProgressBar();
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

        //
        //
    }
}
