using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThemTK
    {
        private string maTaiKhoan;
        private string hassPass;
        private string ChucVu;
        private string HoTen;
        private string NgaySinh;
        private string sdt;
        private string DiaChi;
        private string ChuyenKhoa;
        private string BangCap;

        public DTO_ThemTK(string maTaiKhoan,string hassPass, string ChucVu, string HoTen, string NgaySinh, string sdt, string DiaChi, string ChuyenKhoa, string BangCap)
        {
            this.maTaiKhoan = maTaiKhoan;
            this.hassPass = hassPass;
            this.ChucVu = ChucVu;
            this.HoTen = HoTen;
            this.NgaySinh = NgaySinh;
            this.sdt = sdt;
            this.DiaChi = DiaChi;
            this.ChuyenKhoa = ChuyenKhoa;
            this.BangCap = BangCap;

        }
       
        public string MATAIKHOAN { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string CHUCVU { get => ChucVu; set => ChucVu = value; }
        public string HOTEN { get => HoTen; set => HoTen = value; }
        public string NGAYSINH { get => NgaySinh; set => NgaySinh = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string DIACHI { get => DiaChi; set => DiaChi = value; }
        public string CHUYENKHOA { get => ChuyenKhoa; set => ChuyenKhoa = value; }
        public string BANGCAP { get => BangCap; set => BangCap = value; }
        public string HASHPASS { get => hassPass; set => hassPass = value; }
    }
}
