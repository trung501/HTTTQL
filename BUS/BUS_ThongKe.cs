using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ThongKe
    {
        DAO_ThongKe dao = new DAO_ThongKe();

        public DataTable GetHoaDonInTime(string NgayDau, string NgayCuoi)
        {
            return dao.GetAllHoaDonINTIME(NgayDau, NgayCuoi);
        }

        public DataTable GetDoanhThuInTime(string NgayDau, string NgayCuoi)
        {
            return dao.GetDoanhThuINTIME(NgayDau, NgayCuoi);
        }

        public DataTable GetCountLoaiVC()
        {
            return dao.GetCountLoaiVC();
        }

        public DataTable GetMostUsedVaccineIn(string NgayDau, string NgayCuoi)
        {
            return dao.GetMostUsedVC(NgayDau, NgayCuoi);
        }
        public DataTable GetKhachHangDenHanINTIME(string NgayDau, string NgayCuoi)
        {
            return dao.GetKhachHangDenHanINTIME(NgayDau, NgayCuoi);
        }

        public DataTable GetVaccineSHH(int SoNgay)
        {
            return dao.GetVaccineSHH(SoNgay);
        }

        public string GetTenLoaiVCTheoMaLoaiVC(string MaLoaiVC)
        {
            string TenLoaiVC = "";

            DataTable dt = dao.getTenLoaiVC(MaLoaiVC);

            if(dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                TenLoaiVC = row["TenLoaiVC"].ToString();
            }

            return TenLoaiVC;
        }



        public string GetTenVCTheoMaVC(string MaVC)
        {
            string TenVC = "";

            DataTable dt = dao.getTenVC(MaVC);

            if (dt.Rows.Count >= 1)
            {
                DataRow row = dt.Rows[0];
                TenVC = row["TenVC"].ToString();
            }

            return TenVC;
        }
    }
}
