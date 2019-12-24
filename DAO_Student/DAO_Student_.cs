using DAO;
using DTO_Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_Student
{
    public class DAO_Student_ : DAO_USER
    {
        public bool ExecuteNonQuery(String sql)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                OleDbCommand cmd = new OleDbCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        //Lấy danh sách sinh viên trong cùng một lớp
        public DataTable getStudentInClass(string cmd)
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            OleDbDataAdapter dbCommand = new OleDbDataAdapter(cmd, _conn);
            DataTable table = new DataTable();
            dbCommand.Fill(table);

            _conn.Close();
            return table;
        }

        // Lấy thông tin của 1 sinh viên theo mã sinh viên
        public SinhVien getStudent(string cmd)
        {
            SinhVien sv = new SinhVien();

            OleDbCommand dbCommand = new OleDbCommand(cmd, _conn);
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }



            OleDbDataReader reader = dbCommand.ExecuteReader();
            
            while (reader.Read())
            {
                sv.MaSV = reader.GetValue(0).ToString();
                sv.Ten = reader.GetValue(1).ToString();
                sv.DiaChi = reader.GetValue(2).ToString();
                sv.NgaySinh = reader.GetValue(3).ToString();
                sv.Lop = reader.GetValue(4).ToString();
                sv.Sdt = reader.GetValue(5).ToString();
                sv.GioiTinh = reader.GetBoolean(6);

                break;
            }

            reader.Close();
            _conn.Close();
            return sv;
        }

        //truy vấn lấy thông tin của thông báo và update lên thông báo trong phần thông tin cá nhân
        public string getMessages(string cmd)
        {
            OleDbCommand dbCommand = new OleDbCommand(cmd, _conn);
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }

            string id = "", date = "", title = "", meta = "";

            OleDbDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                id = reader.GetValue(0).ToString();
                date = reader.GetValue(1).ToString();
                title = reader.GetValue(2).ToString();
                meta = reader.GetValue(3).ToString();

                break;
            }

            string s = id + "-" + date + "-" + title + "-" + meta;

            reader.Close();
            _conn.Close();
            return s;
        }

        //
    }
}
