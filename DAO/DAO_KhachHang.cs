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
    public class DAO_KhachHang : DBProvider
    {
        public DataTable GetAllKH()
        {
            string query = "SELECT * FROM KHACHHANG";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool IsMaKHExists(string maKH)
        {
            string query = "SELECT MAKH FROM KHACHHANG WHERE MAKH = @MAKH";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);

            da.SelectCommand.Parameters.AddWithValue("@MAKH", maKH);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public string GetLastestMaKH()
        {
            string query = "SELECT TOP(1) MAKH FROM KHACHHANG ORDER BY MAKH DESC";
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
                    return "KH000";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool InsertKHWithoutNGH(DTO_KhachHang kh)
        {
            try
            {
              
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertKH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAKH", kh.MAKH);
                cmd.Parameters.AddWithValue("@TENKH", kh.TENKH);
                cmd.Parameters.AddWithValue("@NGAYSINH", kh.NGAYSINH);
                cmd.Parameters.AddWithValue("@GIOITINH", kh.GIOITINH);
                cmd.Parameters.AddWithValue("@TIEUSU", kh.TIEUSU);
                cmd.Parameters.AddWithValue("@EMAIL", kh.EMAIL);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@MAGH", DBNull.Value);

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
    }
}