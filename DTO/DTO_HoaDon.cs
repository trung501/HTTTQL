using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        private string maHD;
        private double chietKhau;
        private string ngayThu;
        private int tongTien;
        private string maTN;
        private string maGH;
        private string maPT;

        public string MaHD { get => maHD; set => maHD = value; }
        public double ChietKhau { get => chietKhau; set => chietKhau = value; }
        public string NgayThu { get => ngayThu; set => ngayThu = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public string MaTN { get => maTN; set => maTN = value; }
        public string MaGH { get => maGH; set => maGH = value; }
        public string MaPT { get => maPT; set => maPT = value; }

        public DTO_HoaDon(string maHD, double chietKhau, string ngayThu, int tongTien, string maTN, string maGH, string maPT)
        {
            this.maHD = maHD;
            this.chietKhau = chietKhau;
            this.ngayThu = ngayThu;
            this.tongTien = tongTien;
            this.maTN = maTN;
            this.maGH = maGH;
            this.maPT = maPT;
        }
    }
}
