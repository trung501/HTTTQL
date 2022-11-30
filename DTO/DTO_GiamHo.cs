using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_GiamHo
    {
        private string maGH;
        private string hoTen;
        private string diaChi;
        private string sdt;
        private string email;


        public string MaGH { get => maGH; set => maGH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }


        public DTO_GiamHo(string maGH, string hoTen, string diaChi, string sdt, string email)
        {
            this.maGH = maGH;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
        }
    }
}
