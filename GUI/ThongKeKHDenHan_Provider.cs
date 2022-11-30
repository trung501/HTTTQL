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
    class ThongKeKHDenHan_Provider
    {
        public ThongKeKHDenHan_DataSet ds;
        public ThongKeKHDenHanRP rp;
        public string MaPT;
        public BUS_ThongKe busRP;
        public string  editDau, editCuoi;
        public ThongKeKHDenHan_Provider(string editDau, string editCuoi)
        {
            this.rp = new ThongKeKHDenHanRP();
            this.busRP = new BUS_ThongKe();
            this.ds = new ThongKeKHDenHan_DataSet();
            this.editCuoi = editCuoi;
            this.editDau = editDau;
        }
        public void NhapDuLieuVaoDataSet()
        {
            DataTable dt = new DataTable();
            dt = busRP.GetKhachHangDenHanINTIME(this.editDau, this.editCuoi);
            foreach (DataRow row in dt.Rows)
            {
                string maKH = row["MAKH"].ToString();
                string tenKH = row["TENKH"].ToString();
                string gioiTinh = row["GIOITINH"].ToString();
                string sdt = row["SDT"].ToString();
                string email = row["EMAIL"].ToString();
                string maVC = row["MAVACCINE"].ToString();
                string ngayTiemNhacLai = row["NGAYTIEMNHACLAI"].ToString();
                ngayTiemNhacLai = ngayTiemNhacLai.Split(' ')[0];

                this.ds.KHACHHANGDENHAN.Rows.Add(new Object[]
                {
                    maKH,
                    tenKH,
                    gioiTinh,
                    sdt,
                    email,
                    maVC,
                    ngayTiemNhacLai
                });
               
            }
            
        }

        public void ShowReport()
        {
            rp.DataSource = ds;
            rp.DataMember = ds.KHACHHANGDENHAN.TableName;
           NhapDuLieuVaoDataSet();
            rp.xrLabel_ThoiGian.Text = "Thời gian từ: " + editDau + " đến " + editCuoi;
            ReportPrintTool ViewRP = new ReportPrintTool(rp);

        ViewRP.ShowPreview();
        }
    }

}
