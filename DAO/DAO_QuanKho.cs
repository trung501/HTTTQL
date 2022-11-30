using DTO;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_QuanKho: DBProvider
    {
        public DataRow GetQuanKhoInfo(string MAQUANKHO)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetQuanKhoInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUANKHO", MAQUANKHO);
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
        public string GetLastestMAQUANKHO()
        {
            string query = "SELECT TOP(1) MAQUANKHO FROM QUANKHO ORDER BY MAQUANKHO DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, _conn);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else if (dt.Rows.Count == 0)
                {
                    return "QK000";
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

