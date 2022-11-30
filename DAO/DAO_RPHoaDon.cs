using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Class để run SqlCommand, get dữ liệu cho Report Hóa đơn
    /// </summary>
    public class DAO_RPHoaDon : DBProvider
    {
        /// <summary>
        /// Hàm này get thông tin: ChietKhau, NgayThu, TongTien, MaPhieuTiem, MaThuNgan
        /// </summary>
        /// <param name="maHD"></param>
        /// <returns></returns>
        public DataTable RP_getInforHoaDon (string maHD)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("spRP_getInforHoaDon", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maHD", maHD);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Hàm này get thông tin người giám hộ: HoTen, DiaChi, SDT
        /// </summary>
        /// <param name="maHD"></param>
        /// <returns></returns>
        public DataTable RP_getInforNGH(string maHD)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("spRP_GetInforNGH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maHD", maHD);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Hàm này get duy nhất: NgayTiem
        /// </summary>
        /// <param name="maPhieuTiem"></param>
        /// <returns></returns>
        public DataTable RP_getNgayTiem(string maPhieuTiem)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("spRP_GetNgayTiem", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maPhieuTiem", maPhieuTiem);

                rd = cmd.ExecuteReader();

                dt.Load(rd);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }

        /// <summary>
        /// Hàm này chỉ để lấy: HoTenBS
        /// </summary>
        /// <param name="maPhieuTiem"></param>
        /// <returns></returns>
        public DataTable RP_getHoTenBS(string maPhieuTiem)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("spRP_GetTenBS", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maPhieuTiem", maPhieuTiem);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Hàm này chỉ get list tất cả các: MaVC có trong Hóa đơn đó
        /// </summary>
        /// <param name="maPhieuTiem"></param>
        /// <returns></returns>
        public DataTable RP_getMaVC(string maPhieuTiem)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("spRP_GetMaVC", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maPhieuTiem", maPhieuTiem);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }


        /// <summary>
        /// Hàm này get ra: TenVC, DonGiaVC
        /// </summary>
        /// <param name="maVC"></param>
        /// <returns></returns>
        public DataTable RP_getTen_GiaVC(string maVC)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("spRP_GetTen_GiaVC", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maVC", maVC);

                rd = cmd.ExecuteReader();

                dt.Load(rd);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }


        /// <summary>
        /// Hàm này chỉ get: HoTenTN
        /// </summary>
        /// <param name="maTN"></param>
        /// <returns></returns>
        public DataTable RP_getTenThuNgan(string maTN)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("spRP_GetTenThuNgan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maTN", maTN);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }

        /// <summary>
        /// Hàm này trả về DataTable có tên của Khách Hàng (bệnh nhân): TenBN
        /// </summary>
        /// <param name="maPhieuTiem"></param>
        /// <returns></returns>
        public DataTable RP_getTenBenhNhan(string maPhieuTiem)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("spRP_GetTenBenhNhan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maPhieuTiem", maPhieuTiem);

                rd = cmd.ExecuteReader();

                dt.Load(rd);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }
    }
}
