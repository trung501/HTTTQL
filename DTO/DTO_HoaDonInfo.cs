using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonInfo
    {
        private string maHD;
        private string ngayThu;
        private string nguoiGH;
        private string diaChi;
        private string sdt;
        private string email;

        public string MaHD { get => maHD; set => maHD = value; }
        public string NgayThu { get => ngayThu; set => ngayThu = value; }
        public string NguoiGH { get => nguoiGH; set => nguoiGH = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }


        public DTO_HoaDonInfo() { }

        public DTO_HoaDonInfo(string maHD, string ngayThu, string nguoiGH, string diaChi, string sdt,string email)
        {
            this.maHD = maHD;
            this.ngayThu = ngayThu;
            this.nguoiGH = nguoiGH;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
        }
    }
}
