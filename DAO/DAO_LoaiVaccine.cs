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
    public class DAO_LoaiVaccine :  DBProvider
    {
        public DataTable getAllLoaiVC()
        {
            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllLoaiVC", _conn);
            cmd.CommandType = CommandType.StoredProcedure;

            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();

            return dt;
        }
        public bool IsLoaiVCExists(string LOAIVACCINE)
        {
            string query = "SELECT LOAIVACCINE FROM LOAIVC WHERE LOAIVACCINE=@LOAIVACCINE";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);

            da.SelectCommand.Parameters.AddWithValue("@LOAIVACCINE", LOAIVACCINE);

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
        public string GetLastestMaLoaiVC()
        {
            string query = "SELECT TOP(1) MALOAIVC FROM LOAIVC ORDER BY MALOAIVC DESC";
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
                    return "LVC000";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public bool InsertLoaiVC(DTO_LoaiVaccine lvc)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertLoaiVC", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MALOAIVC", lvc.MALOAIVC);
                cmd.Parameters.AddWithValue("@LOAIVACCINE", lvc.TENLOAIVC);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
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
        public bool XoaLoaiVC(string MALOAIVC)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_XoaLoaiVC", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MALOAIVC", MALOAIVC);
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