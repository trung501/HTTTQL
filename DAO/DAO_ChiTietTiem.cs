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
    public class DAO_ChiTietTiem : DBProvider
    {
        public bool InsertCTT(DTO_ChiTietTiem ctt)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertCTT", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAPHIEUTIEM", ctt.MAPHIEUTIEM);
                cmd.Parameters.AddWithValue("@MAVACCINE", ctt.MAVACCINE);
                cmd.Parameters.AddWithValue("@GIABAN", ctt.GIABAN);
                cmd.Parameters.AddWithValue("@MUITHU", ctt.MUITHU);
                cmd.Parameters.AddWithValue("@NGAYNHACLAI", ctt.NGAYNHACLAI);
                cmd.Parameters.AddWithValue("@LIEULUONG", ctt.LIEULUONG);
                cmd.Parameters.AddWithValue("@TIEMNHACLAI", ctt.TIEMNHACLAI);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }


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
