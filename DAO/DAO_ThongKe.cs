using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    //Class to make connect sqlcmd for thongke
    public class DAO_ThongKe : DBProvider
    {
        #region DoanhThu

       
        /// <summary>
        /// Get NgayThu + TongTien cua cac hoa don trong 1 khoang tgian.
        /// </summary>
        /// <param name="NgayDau">string ngay</param>
        /// <param name="NgayCuoi">string ngay</param>
        /// <returns></returns>
        public DataTable GetAllHoaDonINTIME(string NgayDau, string NgayCuoi)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetHoaDonINTIME_TK", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NgayDau", NgayDau);
                cmd.Parameters.AddWithValue("@NgayCuoi", NgayCuoi);
                rd = cmd.ExecuteReader();
                dt.Load(rd);

            }
            catch (Exception)
            {

                
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }

        #endregion


        #region LoaiVC

        public DataTable GetCountLoaiVC()
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_CountVCTheoLoaiVC",_conn);
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {

                
            }
            finally
            {
                _conn.Close();
            }
            return dt;
        }
        #endregion

        #region ThongKeUsedVC

        public DataTable GetMostUsedVC(string NgayDau, string NgayCuoi)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetMostUsedVaccineINTIME", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayDau", NgayDau);
                cmd.Parameters.AddWithValue("@NgayCuoi", NgayCuoi);
                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {

                
            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }

        #endregion

        #region Report Thong Ke

        public DataTable GetInforReportTK (string NgayDau, string NgayCuoi)
        {
            DataTable dt = new DataTable();

            SqlDataReader rd;
            try
            {
                _conn.Open();


            }
            catch (Exception)
            {

                
            }
            finally
            {
                _conn.Close();
            }



            return dt;
        }


        #endregion

        // Get Vaccine và loại vaccine sắp hết hạn
        public DataTable GetVaccineSHH(int SoNgay)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetLoaiVaccineSHH", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SoNgay", SoNgay);
                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }
        //Get TenLoaiVC theo MaLoaiVC:
        public DataTable getTenLoaiVC(string MaLoaiVC)
        {
            DataTable dt = new DataTable();

            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetTenLoaiVCTheoMaLoai", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaLoaiVC", MaLoaiVC);

                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }


            return dt;
        }


        //Get TenVC theo MaVC:
        public DataTable getTenVC(string MaVC)
        {
            DataTable dt = new DataTable();

            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetTenVCTuMaVC", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaVC", MaVC);

                rd = cmd.ExecuteReader();
                dt.Load(rd);
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }


            return dt;
        }


        //Fix bug:
        public DataTable GetDoanhThuINTIME(string NgayDau, string NgayCuoi)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetDoanhThuTheoNgayINTIME", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NgayDau", NgayDau);
                cmd.Parameters.AddWithValue("@NgayCuoi", NgayCuoi);
                rd = cmd.ExecuteReader();
                dt.Load(rd);

            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }
        public DataTable GetKhachHangDenHanINTIME(string NgayDau, string NgayCuoi)
        {
            DataTable dt = new DataTable();
            SqlDataReader rd;
            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetKhachHangDenHanINTIME", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NgayDau", NgayDau);
                cmd.Parameters.AddWithValue("@NgayCuoi", NgayCuoi);
                rd = cmd.ExecuteReader();
                dt.Load(rd);

            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }

            return dt;
        }
    }
}
