using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ThuNgan : DBProvider
    {
        public string getTenThuNgan(string maTN)
        {
            //string query = "SELECT HOTEN FROM THUNGAN WHERE MATHUNGAN = @MATHUNGAN";
            //SqlDataAdapter da = new SqlDataAdapter(query, _conn);
            //da.SelectCommand.Parameters.AddWithValue("@MATHUNGAN", maTN);

            //DataTable dt = new DataTable();

            //try
            //{
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        return dt.Rows[0][0].ToString();
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetTenThuNgan", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MATHUNGAN", maTN);
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }
        public DataRow GetThuNganInfo(string MATHUNGAN)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetThuNganInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MATHUNGAN", MATHUNGAN);
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
        public string GetLastestMATHUNGAN()
        {
            string query = "SELECT TOP(1) MATHUNGAN FROM THUNGAN ORDER BY MATHUNGAN DESC";
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
                    return  "TN000";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
