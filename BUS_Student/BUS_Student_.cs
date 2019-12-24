using DAO_Student;
using DTO_Info;
using DTO_Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Student
{
    public class BUS_Student_
    {
        DAO_Student_ dao = new DAO_Student_();
        
        public SinhVien getStudent(string s)
        {
            string sql = "select * from SinhVien where MaSV = "+s+"";
            return dao.getStudent(sql);
        }

        public DataTable getStudentInClass(string s)
        {
            string sql = "select * from SinhVien where Lop = '" + s + "'";
            return dao.getStudentInClass(sql);
        }

        public bool updateStudent(SinhVien sv)
        {
            string sql = "update SinhVien set Ten = '" + sv.Ten + "', DiaChi = '" + sv.DiaChi + "', NgaySinh = '" + sv.NgaySinh + "', Lop = '" + sv.Lop + "', Sdt = '" + sv.Sdt + "', GioiTinh = " + sv.GioiTinh + " where MaSV = " + sv.MaSV + "";
            return dao.ExecuteNonQuery(sql);
        }

        public string getMessages()
        {
            string sql = "select * from Messages";
            return dao.getMessages(sql);
        }

        public bool deleteAllMessages()
        {
            string sql = "delete from Messages";
            return dao.ExecuteNonQuery(sql);
        }

        public bool insertMessages(Messages mess)
        {
            string sql = string.Format("insert into Messages values ({0}, {1}, '{2}', '{3}')", mess.Id, mess.Date, mess.Title, mess.Description);
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteMessages(Messages mess)
        {
            string sql = string.Format("delete from Messages where ID = {0} ", mess.Id);
            return dao.ExecuteNonQuery(sql);
        }
        //
        //

    }
}
