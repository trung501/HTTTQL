using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LichSu
    {
        private string ngayTiem;
        private string tenVC;
        private float lieuLuong;
        private string chiDinh;
        private int donGia;

        public string NGAYTIEM { get => ngayTiem; set => ngayTiem = value; }
        public string TENVACCINE { get => tenVC; set => tenVC = value; }
        public float LIEULUONG { get => lieuLuong; set => lieuLuong = value; }
        public string CHIDINH { get => chiDinh; set => chiDinh = value; }
        public int DONGIA { get => donGia; set => donGia = value; }

        public DTO_LichSu() { }

        public DTO_LichSu(string ngayTiem, string tenVC, float lieuLuong, string chiDinh, int donGia)
        {
            this.ngayTiem = ngayTiem;
            this.tenVC = tenVC;
            this.lieuLuong = lieuLuong;
            this.chiDinh = chiDinh;
            this.donGia = donGia;
        }
    }
}
