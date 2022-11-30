using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_TaiKhoan : DBProvider
    {
        public DataTable getAllTaiKhoan( string maQT, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_getAllTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maTK", maQT);
                cmd.Parameters.AddWithValue("@pass", pass);
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
       
        public bool InsertTaiKhoan(DTO_ThemTK tk,string maQT,string passQT)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maQT", maQT);
                cmd.Parameters.AddWithValue("@passQT", passQT);
                cmd.Parameters.AddWithValue("@MATK", tk.MATAIKHOAN);
                cmd.Parameters.AddWithValue("@CHUCVU", tk.CHUCVU);
                cmd.Parameters.AddWithValue("@HOTEN", tk.HOTEN);
                cmd.Parameters.AddWithValue("@NGAYSINH", tk.NGAYSINH);
                cmd.Parameters.AddWithValue("@SDT", tk.SDT);
                cmd.Parameters.AddWithValue("@DIACHI", tk.DIACHI);
                cmd.Parameters.AddWithValue("@CHUYENKHOA", tk.CHUYENKHOA);
                cmd.Parameters.AddWithValue("@BANGCAP", tk.BANGCAP);
                cmd.Parameters.AddWithValue("@PASSWORD", tk.HASHPASS);
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
        
        public string GetHoTenFromTaiKhoan(string maTK)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetHoTenFromTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MATK", maTK);
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }


    
        public bool DeleteTaikhoan(string MaTK)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_DeleteTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MATK", MaTK);
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

        public DataRow GetGeneralInfoTaiKhoan(string maTK)
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetGeneralInfoTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MATK", maTK);
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }
        public DataTable GetAllGeneralInfoTaiKhoan(string maTK,string pass)
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetAllGeneralInfoTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maTK", maTK);
                cmd.Parameters.AddWithValue("@pass", pass);
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
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataRow GetFullInfoTaiKhoan(string maTK)
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetFullInfoTaiKhoan", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MATK", maTK);
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }
        public string GetHashpassFromTaiKhoan(string maQT,string passQT,string maTK)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetHashpassFromMa", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maQT", maQT);
                cmd.Parameters.AddWithValue("@passQT", passQT);
                cmd.Parameters.AddWithValue("@maUser", maTK);
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
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        public bool UpdateTaiKhoanInfo(DTO_ThemTK tktp, string maQT, string passQT)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_UpdateTaiKhoanInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maQT", maQT);
                cmd.Parameters.AddWithValue("@passQT", passQT);
                cmd.Parameters.AddWithValue("@MATK", tktp.MATAIKHOAN);
                cmd.Parameters.AddWithValue("@CHUCVU", tktp.CHUCVU);
                cmd.Parameters.AddWithValue("@HOTEN", tktp.HOTEN);
                cmd.Parameters.AddWithValue("@NGAYSINH", tktp.NGAYSINH);
                cmd.Parameters.AddWithValue("@SDT", tktp.SDT);
                cmd.Parameters.AddWithValue("@DIACHI", tktp.DIACHI);
                cmd.Parameters.AddWithValue("@CHUYENKHOA", tktp.CHUYENKHOA);
                cmd.Parameters.AddWithValue("@BANGCAP", tktp.BANGCAP);
                cmd.Parameters.AddWithValue("@PASSWORD", tktp.HASHPASS);
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

        

      

        public bool CheckExistance(string maTK)
        {
            string query = "SELECT * FROM TAIKHOAN WHERE MATAIKHOAN = @MATAIKHOAN";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            da.SelectCommand.Parameters.AddWithValue("@MATAIKHOAN", maTK);

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
    }
}
