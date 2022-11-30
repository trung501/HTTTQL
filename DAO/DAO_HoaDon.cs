using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HoaDon : DBProvider
    {
        public DataTable GetAllHD()
        {
            string query = "SELECT * FROM HOADON";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool InsertHD(DTO_HoaDon hd)
        {
            try
            {
               
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertHD", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAHOADON", hd.MaHD);
                cmd.Parameters.AddWithValue("@CHIETKHAU", hd.ChietKhau);
                cmd.Parameters.AddWithValue("@NGAYTHU", hd.NgayThu);
                cmd.Parameters.AddWithValue("@TONGTIEN", hd.TongTien);
                cmd.Parameters.AddWithValue("@MAGH", hd.MaGH);
                cmd.Parameters.AddWithValue("@MATHUNGAN", hd.MaTN);
                cmd.Parameters.AddWithValue("@MAPHIEUTIEM", hd.MaPT);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public string GetLastestMaHD()
        {
            string query = "SELECT TOP(1) MAHOADON FROM HOADON ORDER BY MAHOADON DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return "HD000";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public DataTable GetALlHoaDonInfo()
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllHoaDonInfo", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();

            return dt;
        }

        public string GetMaPhieuTiemFromHD(string maHD)
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetMaPhieuTiemFromHD", _conn);
            cmd.Parameters.AddWithValue("@MAHOADON", maHD);
            cmd.CommandType = CommandType.StoredProcedure;
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();

            return dt.Rows[0][0].ToString();
        }

        public bool DeleteHoaDon(string maHD)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_DeleteHoaDon", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAHOADON", maHD);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public bool UpdateHoaDonInfo(DTO_HoaDonInfo hdif)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_UpdateHoaDonInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAHOADON", hdif.MaHD);
                cmd.Parameters.AddWithValue("@NGAYTHU", hdif.NgayThu);
                cmd.Parameters.AddWithValue("@NGUOIGH", hdif.NguoiGH);
                cmd.Parameters.AddWithValue("@DIACHI", hdif.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", hdif.Sdt);
                cmd.Parameters.AddWithValue("@EMAIL", hdif.Email);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }
    }
}
