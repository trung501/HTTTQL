using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BUS_RPHoaDon
    {
        DAO_RPHoaDon dao = new DAO_RPHoaDon();


        /// <summary>
        /// Hàm này get thông tin: ChietKhau, NgayThu, TongTien, MaPhieuTiem, MaThuNgan
        /// </summary>
        /// <param name="MaHD"></param>
        /// <returns></returns>
        public DataTable RP_GetInforHoaDon(string MaHD)
        {
            return dao.RP_getInforHoaDon(MaHD);
        }

        /// <summary>
        /// Hàm này get thông tin người giám hộ: HoTen, DiaChi, SDT
        /// </summary>
        /// <param name="MaHD"></param>
        /// <returns></returns>
        public DataTable RP_GetInforNGH(string MaHD)
        {
            return dao.RP_getInforNGH(MaHD);
        }

        /// <summary>
        /// Hàm này get ra string: NgayTiem
        /// </summary>
        /// <param name="MaPhieuTiem"></param>
        /// <returns></returns>
        public string RP_GetNgayTiem(string MaPhieuTiem)
        {
            DataTable dt = dao.RP_getNgayTiem(MaPhieuTiem);
            string NgayTiem = "";

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                NgayTiem = row["NgayTiem"].ToString();
            }

            return NgayTiem;
        }

        /// <summary>
        /// Hàm này get ra string: HoTenBS
        /// </summary>
        /// <param name="MaPhieuTiem"></param>
        /// <returns></returns>
        public string RP_GetHoTenBS(string MaPhieuTiem)
        {
            DataTable dt = dao.RP_getHoTenBS(MaPhieuTiem);
            string HoTenBS = "";

            if(dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                HoTenBS = row["HoTenBS"].ToString().Trim();
            }
            return HoTenBS;
        }

        /// <summary>
        /// Hàm này trả về DataTable: MaVC có trong hóa đơn
        /// </summary>
        /// <param name="MaPhieuTiem"></param>
        /// <returns></returns>
        public DataTable RP_GetMaVC(string MaPhieuTiem)
        {
            return dao.RP_getMaVC(MaPhieuTiem);
        }

        /// <summary>
        /// Hàm này trả về DataTable: TenVC, DonGiaVC của maVC truyền vào
        /// </summary>
        /// <param name="MaVC"></param>
        /// <returns></returns>
        public DataTable RP_GetTen_GiaVC(string MaVC)
        {
            return dao.RP_getTen_GiaVC(MaVC);
        }

        /// <summary>
        /// Hàm này trả về string: HoTenTN
        /// </summary>
        /// <param name="MaTN"></param>
        /// <returns></returns>
        public string RP_GetTenThuNgan(string MaTN)
        {
            DataTable dt = dao.RP_getTenThuNgan(MaTN);
            string TenTN = "";

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                TenTN = row["HoTenTN"].ToString().Trim();
            }

            return TenTN;
        }

        /// <summary>
        /// Hàm này trả về 1 string tên của người đc tiêm là : Khách hàng(bệnh nhân)
        /// </summary>
        /// <param name="MaPhieuTiem"></param>
        /// <returns></returns>
        public string RP_GetTenBenhNhan(string MaPhieuTiem)
        {
            DataTable dt = dao.RP_getTenBenhNhan(MaPhieuTiem);

            string TenBN = "";

            if(dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                TenBN = row["TenBN"].ToString().Trim();
            }

            return TenBN;
        }
    }
}
