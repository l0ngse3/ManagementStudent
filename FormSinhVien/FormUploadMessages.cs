using BUS_Student;
using DTO_Student;
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
    public partial class FormUploadMessages : Form
    {
        BUS_Student_ bus = new BUS_Student_();

        public FormUploadMessages()
        {
            InitializeComponent();
        }

        //hàm post thông báo - đưa thông báo vào csdl cho các sinh viên cùng lớp
        private void btnPost_Click(object sender, EventArgs e)
        {
            if(txtTitle.Text != "" && richTextBoxContent.Text != "")
            {
                Messages messages = new Messages();

                bus.deleteAllMessages();

                messages.Id = "1";
                messages.Date = DateTime.Now.ToShortDateString().ToString();
                messages.Title = txtTitle.Text;
                messages.Description = richTextBoxContent.Text;


                if (bus.insertMessages(messages))
                {
                    MessageBox.Show("Đã đăng tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tin chưa được đăng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(txtTitle.Text == "")
            {
                MessageBox.Show("Không được để trống tiêu đề!");
            }
            else if(richTextBoxContent.Text == "")
            {
                MessageBox.Show("Không được để trống nội dung!");
            }


        }

        //
        //

    }
}
