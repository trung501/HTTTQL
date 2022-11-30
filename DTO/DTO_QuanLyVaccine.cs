using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_QuanLyVaccine
    {
        private string maVC;
        private string tenVC;
        private string nhaSX;
        private string ngaySX;
        private string hanSD;
        private string soLo;
        private int soLuongSan;
        private int donGia;
        private string maloaiVC;
        private string maQuanKho;
        private string maQuanTri;

        public string MAVACCINE { get => maVC; set => maVC = value; }
        public string TENVACCINE { get => tenVC; set => tenVC = value; }
        public string NHASX { get => nhaSX; set => nhaSX = value; }
        public string NGAYSX { get => ngaySX; set => ngaySX = value; }
        public string HANSD { get => hanSD; set => hanSD = value; }
        public string SOLO { get => soLo; set => soLo = value; }
        public int SOLUONGCOSAN { get => soLuongSan; set => soLuongSan = value; }
        public int DONGIA { get => donGia; set => donGia = value; }
        public string MALVC { get => maloaiVC; set => maloaiVC = value; }
        public string MAQUANKHO { get => maQuanKho; set => maQuanKho = value; }
        public string MAQUANTRI { get => maQuanTri; set => maQuanTri = value; }
        public DTO_QuanLyVaccine()
        {

        }

        public DTO_QuanLyVaccine(string maVC, string tenVC, string nhaSX, string ngaySX, string hanSD, string soLo, int soLuongSan, int donGia, string maloaiVC, string maQuanKho, string maQuanTri)
        {
            this.maVC = maVC;
            this.tenVC = tenVC;
            this.nhaSX = nhaSX;
            this.ngaySX = ngaySX;
            this.hanSD = hanSD;
            this.soLo = soLo;
            this.soLuongSan = soLuongSan;
            this.donGia = donGia;
            this.maloaiVC = maloaiVC;
            this.maQuanKho = maQuanKho;
            this.maQuanTri = maQuanTri;
        }
    }

}