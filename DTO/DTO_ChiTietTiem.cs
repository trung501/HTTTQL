using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ChiTietTiem
    {
        private string maPT;
        private string maVC;
        private int giaBan;
        private int muiThu;
        private string ngayNhacLai;
        private double lieuLuong;
        private bool tiemNhacLai;

        public string MAPHIEUTIEM { get => maPT; set => maPT = value; }
        public string MAVACCINE { get => maVC; set => maVC = value; }
        public int GIABAN { get => giaBan; set => giaBan = value; }
        public int MUITHU { get => muiThu; set => muiThu = value; }
        public string NGAYNHACLAI { get => ngayNhacLai; set => ngayNhacLai = value; }
        public double LIEULUONG { get => lieuLuong; set => lieuLuong = value; }
        public bool TIEMNHACLAI { get => tiemNhacLai; set => tiemNhacLai = value; }


        public DTO_ChiTietTiem(string maPT, string maVC, int giaBan, int muiThu, string ngayNhacLai, double lieuLuong,bool tiemNhacLai)
        {
            this.maPT = maPT;
            this.maVC = maVC;
            this.giaBan = giaBan;
            this.muiThu = muiThu;
            this.ngayNhacLai = ngayNhacLai;
            this.lieuLuong = lieuLuong;
            this.tiemNhacLai = tiemNhacLai;
        }
    }
}
