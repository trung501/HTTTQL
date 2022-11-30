using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public class HoaDonCreator
    {
        public HoaDon_DataSet ds;
        public HoaDonRP RP;
        public string MaHoaDon;
        public BUS_RPHoaDon busRP;


        public HoaDonCreator(string MaHoaDon)
        {
            this.MaHoaDon = MaHoaDon;
            this.ds = new HoaDon_DataSet();
            this.RP = new HoaDonRP();
            this.busRP = new BUS_RPHoaDon();
        }

        public bool NhapDuLieuHoaDonVaoDataSet()
        {
            string TenKH, DiaChi, SDT, TenBS, TenTN, MaTN, NgayThu, NgayTiem, TenBenhNhan;
            double ChietKhau, TongTien, _ThanhTien;

            //Biến ẩn trên report:
            string MaPhieuTiem = "";

            

            //***************************************************************
            #region ChietKhau, NgayThu, TongTien, MaPhieuTiem, MaThuNgan

            DataTable dt = new DataTable();
            dt =  busRP.RP_GetInforHoaDon(MaHoaDon).Copy();
            if(dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                ChietKhau = Double.Parse(row["ChietKhau"].ToString());
                TongTien = Double.Parse(row["TongTien"].ToString());
                _ThanhTien = Math.Round(TongTien * (1.0 - ChietKhau));


                MaPhieuTiem = row["MaPhieuTiem"].ToString().Trim();
                MaTN = row["MaThuNgan"].ToString();
                NgayThu = row["NgayThu"].ToString().Substring(0, 10);
            }
            else //Có bug trên DB
            {
                return false;
            }

            #endregion
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            //****************************************************************
            #region  HoTen, DiaChi, SDT

            DataTable dt1 = new DataTable();
             dt1   = busRP.RP_GetInforNGH(MaHoaDon).Copy();
            if(dt1.Rows.Count == 1)
            {
                DataRow row1 = dt1.Rows[0];
                TenKH = row1["HoTen"].ToString().Trim();
                DiaChi = row1["DiaChi"].ToString().Trim();
                SDT = row1["SDT"].ToString().Trim();
            }
            else
            {
                return false;
            }

            #endregion
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            //*******************************************************************
            //NgayTiem, HoTenBS:
            NgayTiem = busRP.RP_GetNgayTiem(MaPhieuTiem);
            TenBS = busRP.RP_GetHoTenBS(MaPhieuTiem);
            TenTN = busRP.RP_GetTenThuNgan(MaTN);
            //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            //************************************************************
            #region Get List MaVaccine
            DataTable dtVC = new DataTable();
            dtVC =    busRP.RP_GetMaVC(MaPhieuTiem).Copy();
            int SoLuongVC = dtVC.Rows.Count;

            List<string> ListMaVC = new List<string>();
            if (SoLuongVC >= 1)
            {
                
                foreach (DataRow rowVC in dtVC.Rows)
                {
                    ListMaVC.Add(rowVC["MaVC"].ToString().Trim());
                }
            }
            #endregion

            #region Lấy Tên Bệnh Nhân bằng mã phiếu tiêm

            TenBenhNhan = busRP.RP_GetTenBenhNhan(MaPhieuTiem);


            #endregion


            #region Add record to HoaDon Table in Dataset:

            ds.HoaDon.Rows.Add(
                new Object[]
                {
                    MaHoaDon,
                    TenKH,
                    DiaChi,
                    SDT,
                    TenBS,
                    NgayThu,
                    ChietKhau,
                    TenTN,
                    MaTN,
                    NgayTiem,
                    TongTien,
                    _ThanhTien,
                    TenBenhNhan
                });


            #endregion

            #region Add record to Vaccine Table:  MaVC, TenVC, DonGia

            string TenVC = "";
            double DonGia = 0;

            foreach (string item in ListMaVC)
            {
                DataTable dt3 = new DataTable();
                 dt3 =    busRP.RP_GetTen_GiaVC(item).Copy();
                
                if(dt3.Rows.Count == 1)
                {
                    DataRow row3 = dt3.Rows[0];
                    TenVC = row3["TenVC"].ToString();
                    DonGia = Double.Parse(row3["DonGiaVC"].ToString().Trim());
                }



                ds.Vaccine.Rows.Add(
                    new Object[]
                    {
                        TenVC,
                        DonGia,
                        item,
                        MaHoaDon
                    });
            }
            #endregion


            return true;
        }


        public void ShowReportHoaDon()
        {
            RP.DataSource = ds;
            RP.DataMember = ds.Vaccine.TableName;
            NhapDuLieuHoaDonVaoDataSet();

            
            

            ReportPrintTool ViewRP = new ReportPrintTool(RP);

            ViewRP.ShowPreview();
        }

    }
}
