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
    public class ThongKeCreator
    {
        public ThongKe_DataSet ds;
        public ThongKeRP RP;
        public string ThoiGianDau, ThoiGianCuoi, TongDoanhThu, editDau, editCuoi;
        public BUS_ThongKe busRP;


        public ThongKeCreator(string NgayDau, string NgayCuoi, string TongDoanhThu, string editDau, string editCuoi)
        {
            this.ThoiGianCuoi = NgayCuoi;
            this.ThoiGianDau = NgayDau;
            this.RP = new ThongKeRP();
            this.busRP = new BUS_ThongKe();
            this.ds = new ThongKe_DataSet();
            this.TongDoanhThu = TongDoanhThu;
            this.editCuoi = editCuoi;
            this.editDau = editDau;
        }

        public void NhapDuLieuVaoDataSet()
        {
            //Lay Hoa Don intime:
            DataTable dtHD = new DataTable();
            dtHD = busRP.GetDoanhThuInTime(ThoiGianDau, ThoiGianCuoi);

            //Lay so luong loaiVC:
            DataTable dtLoaiVC = busRP.GetCountLoaiVC();

            //Get Most Used Vaccine:
            DataTable dtMostVC = busRP.GetMostUsedVaccineIn(ThoiGianDau, ThoiGianCuoi);

            //Nhap dtHD:
            foreach(DataRow row in dtHD.Rows)
            {
                string Ngay = row["Ngay"].ToString();
                Ngay = Ngay.Split(' ')[0];
                string DoanhThu = row["Tien"].ToString();

                ds.DoanhThu.Rows.Add(new Object[]
                {
                    Ngay,
                    DoanhThu
                });

            }

            //Nhap dtLoaiVC:
            foreach (DataRow row in dtLoaiVC.Rows)
            {
                string MaLoaiVC = row["Loaivaccine"].ToString();
                string SoLuong = row["SoLuong"].ToString();
                string TenLoaiVC = busRP.GetTenLoaiVCTheoMaLoaiVC(MaLoaiVC);

                ds.LoaiVC.Rows.Add(new Object[]
                {
                    MaLoaiVC,
                    SoLuong,
                    TenLoaiVC
                });
                
            }


            //Nhap 15 LoaiVC dung nhieu nhat:

            foreach (DataRow row in dtMostVC.Rows)
            {
                string MaVC = row["MaVC"].ToString();
                string SoLanSuDung = row["SoLuong"].ToString();
                string TenVC = busRP.GetTenVCTheoMaVC(MaVC);

                ds.TopVaccine.Rows.Add(new Object[]
                {
                    MaVC,
                    TenVC,
                    SoLanSuDung
                });
            }

        }

        public void ShowThongKeRP()
        {
            RP.DataSource = ds;
            RP.DataMember = ds.DoanhThu.TableName;
            NhapDuLieuVaoDataSet();

            RP.xrTableCell_TongDoanhThu.Text = TongDoanhThu;
            RP.xrLabel_ThoiGian.Text = "Thời gian từ: " + editDau + " đến " + editCuoi;

            ReportPrintTool ViewRP = new ReportPrintTool(RP);
            ViewRP.ShowPreview();
        }
    }
}
