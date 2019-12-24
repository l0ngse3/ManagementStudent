using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Info
{
    public class SinhVien
    {
        private string maSV, ten, diaChi, ngaySinh, lop, sdt;
        private bool gioiTinh;

        public SinhVien()
        {
        }

        public SinhVien(string maSV, string ten, string diaChi, string ngaySinh, string lop, string sdt, bool gioiTinh)
        {
            this.maSV = maSV;
            this.ten = ten;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
            this.lop = lop;
            this.sdt = sdt;
            this.gioiTinh = gioiTinh;
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string Ten { get => ten; set => ten = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
