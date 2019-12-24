using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Info
{
    public class Lop
    {
        private string tenLop, khoa, maKhoa;

        public Lop()
        {
        }

        public Lop(string tenLop, string khoa, string maKhoa)
        {
            this.tenLop = tenLop;
            this.khoa = khoa;
            this.maKhoa = maKhoa;
        }

        public string TenLop { get => tenLop; set => tenLop = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
    }
}
