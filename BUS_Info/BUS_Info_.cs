using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_Info;
using DTO_Info;

namespace BUS_Info
{
    public class BUS_Info_
    {

        DAO_Info_ dao = new DAO_Info_();


        public ArrayList GetLop(string khoa)
        {
            string sql = "select distinct TenLop, MaKhoa from Lop where Khoa='"+khoa+"'";
            return dao.GetLop(sql);
        }

        public DataTable GetKhoa()
        {
            string sql = "select distinct Khoa from Lop";
            return dao.GetKhoa(sql);
        }

        public DataTable getSinhVien()
        {
            String sql = "select * from SinhVien";
            return dao.getSinhVien(sql);
        }

        public DataTable getSinhVienSearch(string value)
        {
            string[] arr = value.Split('_');

            string sql = "SELECT DISTINCT SinhVien.MaSV, SinhVien.Ten, SinhVien.DiaChi, SinhVien.NgaySinh, SinhVien.Lop, SinhVien.Sdt, SinhVien.GioiTinh FROM SinhVien, Lop WHERE(SinhVien.MaSV LIKE '%" + arr[0] + "%') AND(SinhVien.Lop LIKE '%" + arr[1] + "%') AND(Lop.Khoa LIKE '%" + arr[2]+"%')";

            return dao.getSinhVien(sql);
        }

        public bool EditSinhVien(SinhVien sv)
        {
            string sql = "update SinhVien set Ten = '" + sv.Ten + "', DiaChi = '" + sv.DiaChi + "', NgaySinh = '" + sv.NgaySinh + "', Lop = '" + sv.Lop + "', Sdt = '" + sv.Sdt + "', GioiTinh = " + sv.GioiTinh + " where MaSV = " + sv.MaSV + "";
            return dao.ExecuteNonQuery(sql);
        }

        public bool addSinhVien(SinhVien sv)
        {
            String sql = string.Format("insert into SinhVien values ({0},'{1}','{2}','{3}','{4}',{5},{6})", sv.MaSV, sv.Ten, sv.DiaChi, sv.NgaySinh, sv.Lop, sv.Sdt, sv.GioiTinh);
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteSinhVien(SinhVien sv)
        {
            string sql = "delete from SinhVien where MaSV=" + sv.MaSV;
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteAllSinhVien()
        {
            string sql = "DELETE FROM SinhVien";
            return dao.ExecuteNonQuery(sql);
        }

        public bool addClass(Lop lop)
        {
            string sql = string.Format("insert into Lop values ('{0}', '{1}', '{2}')", lop.TenLop, lop.Khoa, lop.MaKhoa);
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteClass(Lop lop)
        {
            string sql = string.Format("delete from Lop where TenLop = '{0}' and Khoa = '{1}'", lop.TenLop, lop.Khoa);
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteKhoa(Lop lop)
        {
            string sql = string.Format("delete from Lop where Khoa = '{0}'", lop.Khoa);
            return dao.ExecuteNonQuery(sql);
        }


    }

}
