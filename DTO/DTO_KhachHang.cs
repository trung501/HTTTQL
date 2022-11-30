using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhachHang
    {
        private string maKH;
        private string tenKH;
        private string ngaySinh;
        private string gioiTinh;
        private string tieuSu;
        private string email;
        private string sdt;
        private string maGH;

        public string MAKH { get => maKH; set => maKH = value; }
        public string TENKH { get => tenKH; set => tenKH = value; }
        public string NGAYSINH { get => ngaySinh; set => ngaySinh = value; }
        public string GIOITINH { get => gioiTinh; set => gioiTinh = value; }
        public string TIEUSU { get => tieuSu; set => tieuSu = value; }
        public string EMAIL { get => email; set => email = value; }
        public string SDT { get => sdt; set => sdt = value; }
        public string MAGH { get => maGH; set => maGH = value; }

        public DTO_KhachHang(string maKH, string tenKH, string ngaySinh, string gioiTinh, string tieuSu,string email,string sdt, string maGH)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.tieuSu = tieuSu;
            this.email = email;
            this.sdt = sdt;
            this.maGH = maGH;
        }
    }
}
