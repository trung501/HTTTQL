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
    public class DAO_QuanLyVaccine : DBProvider
    {
        public DataTable getAllVaccine()
        {

            SqlDataReader rd;
            DataTable dt = new DataTable();

            _conn.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllVaccine", _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            rd = cmd.ExecuteReader();
            dt.Load(rd);
            _conn.Close();

            return dt;
        }
        public bool InsertVaccine(DTO_QuanLyVaccine vc)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_InsertVaccine", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAVACCINE", vc.MAVACCINE);
                cmd.Parameters.AddWithValue("@TENVACCINE", vc.TENVACCINE);
                cmd.Parameters.AddWithValue("@NHASX", vc.NHASX);
                cmd.Parameters.AddWithValue("@NGAYSX", vc.NGAYSX);
                cmd.Parameters.AddWithValue("@HANSD", vc.HANSD);
                cmd.Parameters.AddWithValue("@SOLO", vc.SOLO);
                cmd.Parameters.AddWithValue("@SOLUONGCOSAN", vc.SOLUONGCOSAN);
                cmd.Parameters.AddWithValue("@DONGIA", vc.DONGIA);
                cmd.Parameters.AddWithValue("@MALOAIVC", vc.MALVC);
                cmd.Parameters.AddWithValue("@MAQUANKHO", vc.MAQUANKHO);
                cmd.Parameters.AddWithValue("@MAQUANTRI", vc.MAQUANTRI);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
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
        public bool ChinhSuaVaccine(DTO_QuanLyVaccine vc)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ChinhSuaVaccine", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MAVACCINE", vc.MAVACCINE);
                cmd.Parameters.AddWithValue("@TENVACCINE", vc.TENVACCINE);
                cmd.Parameters.AddWithValue("@NHASX", vc.NHASX);
                cmd.Parameters.AddWithValue("@NGAYSX", vc.NGAYSX);
                cmd.Parameters.AddWithValue("@HANSD", vc.HANSD);
                cmd.Parameters.AddWithValue("@SOLO", vc.SOLO);
                cmd.Parameters.AddWithValue("@SOLUONGCOSAN", vc.SOLUONGCOSAN);
                cmd.Parameters.AddWithValue("@DONGIA", vc.DONGIA);
                cmd.Parameters.AddWithValue("@MALOAIVC", vc.MALVC);
                cmd.Parameters.AddWithValue("@MAQUANKHO", vc.MAQUANKHO);
                cmd.Parameters.AddWithValue("@MAQUANTRI", vc.MAQUANTRI);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
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