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
    public class DAO_BacSi: DBProvider
    {
        public DataTable getAllBacSi()
        {

            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllBacSi", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();

            return dt;
        }
        public DataRow GetBacSyInfo(string MABS)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetBacSyInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MABS", MABS);
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
        public string GetLastestMABS()
        {
            string query = "SELECT TOP(1) MABS FROM BACSY ORDER BY MABS DESC";
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
                    return "BS000";
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
