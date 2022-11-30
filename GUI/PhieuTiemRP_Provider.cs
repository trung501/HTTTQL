using BUS;
using DevExpress.XtraReports.UI;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class PhieuTiemRP_Provider
    {
        public PhieuTiemRP_Dataset ds;
        public PhieuTiemRP rp;
        public string MaPT;
        public BUS_PhieuTiem busPT;

        public PhieuTiemRP_Provider(string maPT)
        {
            this.MaPT = maPT;
            this.ds = new PhieuTiemRP_Dataset();
            this.rp = new PhieuTiemRP(maPT);
            this.busPT = new BUS_PhieuTiem();
        }

        public bool PopulateDataset()
        {
            #region PhieuTiemInfo

            string ngayTiem, thangTiem, namTiem, maKH, tenKH, ngaySinh, gioiTinh, tieuSu, tenBS;

            DataTable dt = busPT.GetReportInfo(MaPT);

            if (dt.Rows.Count > 0)
            {
                string stringNgayTiem = dt.Rows[0]["NGAYTIEM"].ToString().Trim();
                string[] arrayNgayTiem = stringNgayTiem.Split(new[] { '/' });
                ngayTiem = arrayNgayTiem[1].ToString();
                thangTiem = arrayNgayTiem[0].ToString();
                namTiem = arrayNgayTiem[2].ToString().Substring(0, 4);
                maKH = dt.Rows[0]["MAKH"].ToString();
                tenKH = dt.Rows[0]["TENKH"].ToString();
                ngaySinh = dt.Rows[0]["NGAYSINH"].ToString().Substring(0, 10);
                gioiTinh = dt.Rows[0]["GIOITINH"].ToString();
                tieuSu = dt.Rows[0]["TIEUSU"].ToString();
                tenBS = dt.Rows[0]["TENBS"].ToString();
            }
            else //Có bug trên DB
            {
                return false;
            }

            ds.PhieuTiem.Rows.Add(new Object[] { MaPT, ngayTiem, maKH, tenKH, ngaySinh, gioiTinh, tieuSu, tenBS, thangTiem, namTiem });

            #endregion

            #region VaccineList

            string MaVC, TenVC, LieuLuong, DonGia;

            DataTable dtVC = busPT.GetVCFromPHIEUTIEM(MaPT);

            if (dtVC.Rows.Count > 0)
            {
                for (int i = 0; i < dtVC.Rows.Count; i++)
                {
                    MaVC = dtVC.Rows[i]["MAVACCINE"].ToString();
                    TenVC = dtVC.Rows[i]["TENVACCINE"].ToString();
                    LieuLuong = dtVC.Rows[i]["LIEULUONG"].ToString();
                    DonGia = dtVC.Rows[i]["DONGIA"].ToString();

                    ds.Vaccine.Rows.Add(new Object[] { MaVC, TenVC, LieuLuong, DonGia });
                }
            }
            else //Có bug trên DB
            {
                return false;
            }

            #endregion

            return true;

        }

        public void ShowReport()
        {
            rp.DataSource = ds;
            rp.DataMember = ds.Vaccine.TableName;
            PopulateDataset();

            ReportPrintTool ViewRP = new ReportPrintTool(rp);

            ViewRP.ShowPreview();
        }
    }
}
