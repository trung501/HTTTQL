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
    public class DAO_GiamHo : DBProvider
    {
        public DataTable GetAllNGH()
        {
            string query = "SELECT * FROM NGUOIGIAMHO";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string GetLastestMaGH()
        {
            string query = "SELECT TOP(1) MAGH FROM NGUOIGIAMHO ORDER BY MAGH DESC";
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
                    return "GH000";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool InsertNGH(DTO_GiamHo gh)
        {
            try
            {
                //_conn.Open();

                //string SQL = @"INSERT INTO NGUOIGIAMHO
                //            ( MAGH, HOTEN, DIACHI, SDT )
                //            VALUES
                //            ( @MAGH, @HOTEN, @DIACHI, @SDT )";

                //SqlCommand cmd = new SqlCommand(SQL, _conn);

                //cmd.Parameters.AddWithValue("@MAGH", gh.MaGH);
                //cmd.Parameters.AddWithValue("@HOTEN", gh.HoTen);
                //cmd.Parameters.AddWithValue("@DIACHI", gh.DiaChi);
                //cmd.Parameters.AddWithValue("@SDT", gh.Sdt);

                //if (cmd.ExecuteNonQuery() > 0)
                //    return true;

                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertNGH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAGH", gh.MaGH);
                cmd.Parameters.AddWithValue("@HOTEN", gh.HoTen);
                cmd.Parameters.AddWithValue("@DIACHI", gh.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", gh.Sdt);
                cmd.Parameters.AddWithValue("@EMAIL", gh.Email);

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

        public bool IsMaGHExists(string maGH)
        {
            string query = "SELECT MAGH FROM NGUOIGIAMHO WHERE MAGH = @MAGH";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);

            da.SelectCommand.Parameters.AddWithValue("@MAGH", maGH);

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

        public bool AddMaGHtoKH(string maGH)
        {
            try
            {
             

                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_AddMaGHtoKH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAGH", maGH);

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
