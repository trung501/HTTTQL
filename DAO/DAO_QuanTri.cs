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
    public class DAO_QuanTri: DBProvider
    {
        public DataRow GetQuanTriInfo(string MAQUANTRI)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetQuanTriInfo", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAQUANTRI", MAQUANTRI);
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
        public string GetLastestMAQUANTRI()
        {
            string query = "SELECT TOP(1) MAQUANTRI FROM QUANTRI ORDER BY MAQUANTRI DESC";
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
                    return "QT000";
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
