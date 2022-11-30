using System;
using BUS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class ThongKeGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public static ThongKeGUI _instance;

        public static ThongKeGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThongKeGUI();
                }
                return _instance;
            }
        }

        #region Define Variable
        BUS_ThongKe busThongKe = new BUS_ThongKe();
        BUS_Vaccine busVaccine = new BUS_Vaccine();
        public int SoLuongVaccineChartMostVC = 7;
        int NgayTinhHan = 30;//Thông báo vắc xin sắp hết hạn khi số ngày còn lại < NgayTinhHan
        #endregion
        public ThongKeGUI()
        {
            InitializeComponent();
            LoadDataToChartLoaiVC();

            //default date for Chart Doanh Thu:
            //dateEditDau.EditValue = new DateTime(2018, 1, 1);
            //dateEditCuoi.EditValue = new DateTime(2018, 2, 1);            
            dateEditCuoi.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dateEditDau.EditValue = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
            LoadDataToChartDoanhThu();

            //Default date for Chart MostVC:
            dateEditVCCuoi.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dateEditVCDau.EditValue = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
            cbBoxEditSoMostVC.SelectedIndex = 3;
            LoadDataToChartMostVC();

            panelControlVcHH.Visible = false;
            textEdit1.EditValue = 30;
            LoadDataToChartVCSHH();
            RefreshGrid();

            gridView1.OptionsBehavior.Editable = false;


        }
        
        public void RefreshGrid()
        {
            gridVCSHH.DataSource = busVaccine.getAllVaccineSHH(NgayTinhHan);
            //gridView1.BestFitColumns();
            gridView1.Columns["MAVACCINE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            tbSearch.Focus();
        }

        #region Chart Doanh Thu

        public void LoadDataToChartDoanhThu()
        {
            //Clear chart:
            chartControlDoanhThu.Series["BDDoanhThu"].Points.Clear();

            string NgayDau = dateEditDau.DateTime.ToString("yyyy-MM-dd");
            string NgayCuoi = dateEditCuoi.DateTime.ToString("yyyy-MM-dd");

            DataTable dt = new DataTable();
            dt = busThongKe.GetDoanhThuInTime(NgayDau, NgayCuoi);
            int TongDoanhThu = 0;
            foreach (DataRow row in dt.Rows)
            {
                string ThoiGian = row["Ngay"].ToString();
                int Tien = int.Parse(row["Tien"].ToString());
                TongDoanhThu += Tien;
                chartControlDoanhThu.Series["BDDoanhThu"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(ThoiGian, Tien));
            }
            chartControlDoanhThu.Refresh();
            tedTongDoanhThu.Text = TongDoanhThu.ToString();
        }

        #endregion

        #region Chart LoaiVC

        public void LoadDataToChartLoaiVC()
        {
            DataTable dt = busThongKe.GetCountLoaiVC();

            chartControlLoaiVC.Series["BDLoaiVC"].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string TenVC = row["LOAIVACCINE"].ToString();
                TenVC = TenVC.Trim();
                int SoLuong = int.Parse(row["SoLuong"].ToString());
                chartControlLoaiVC.Series["BDLoaiVC"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(TenVC, SoLuong));
            }
            chartControlLoaiVC.Refresh();
            //chartControlLoaiVC.Series["BDLoaiVC"].LegendText = "#AXISLABEL";
        }

        #endregion

        #region Chart Most VC

        public void LoadDataToChartMostVC()
        {
            //Re check số lượng sẽ hiện ra:
            if (cbBoxEditSoMostVC.SelectedItem != null)
            {
                SoLuongVaccineChartMostVC = int.Parse(cbBoxEditSoMostVC.SelectedItem.ToString());
            }
            
            chartControlMostVC.Series["BDCmostVC"].Points.Clear();

            string NgayDau = dateEditVCDau.DateTime.ToString("yyyy-MM-dd");
            string NgayCuoi = dateEditVCCuoi.DateTime.ToString("yyyy-MM-dd");

            DataTable dt = busThongKe.GetMostUsedVaccineIn(NgayDau, NgayCuoi);

            //Check số row data có đủ để hiện không
            if (SoLuongVaccineChartMostVC > dt.Rows.Count)
            {
                SoLuongVaccineChartMostVC = dt.Rows.Count;
            }
            for (int i = 0; i < SoLuongVaccineChartMostVC; i++)
            {
                DataRow row = dt.Rows[i];
                string MaVC = row["MaVC"].ToString().Trim();
                int SoLuong = int.Parse(row["SoLuong"].ToString());
                chartControlMostVC.Series["BDCmostVC"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(MaVC, SoLuong));

                chartControlMostVC.Refresh();
            }


        }

        #endregion

        #region Chart VCSHH

        public void LoadDataToChartVCSHH()
        {
            chartControlVCSHH.Series["BDVCSHH"].Points.Clear();
            DataTable dt = busThongKe.GetVaccineSHH(NgayTinhHan);
            //DataTable dtVC = busVaccine.getAllVaccine();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string LoaiVC = row["LOAIVACCINE"].ToString().Trim();
                int SoLuong = int.Parse(row["SOLUONGCOSAN"].ToString());
                chartControlVCSHH.Series["BDVCSHH"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(LoaiVC, SoLuong));
                chartControlVCSHH.Refresh();
                /*
                string stringHanSD = row["HANSD"].ToString().Trim();
                DateTime HanSD = DateTime.Parse(stringHanSD);
                TimeSpan Time = HanSD.Subtract(DateTime.Now);
                int SoNgayConLai = Time.Days;//Bằng hạn sử dụng trừ ngày hiện tại
                if ((SoNgayConLai-NgayTinhHan) < 0)
                {
                    string LoaiVC = row["LOAIVACCINE"].ToString().Trim();
                    int SoLuong = int.Parse(row["SOLUONGCOSAN"].ToString());
                    chartControlVCSHH.Series["BDVCSHH"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(LoaiVC, SoLuong));
                    chartControlVCSHH.Refresh();
                }*/
            }

            chartControlVCSHH.Refresh();
        }

        #endregion

        //Generate Code for Event Handle:
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataToChartDoanhThu();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataToChartDoanhThu();
        }

        private void tedTongDoanhThu_DoubleClick(object sender, EventArgs e)
        {
            if (tedTongDoanhThu.Text != "")
            {
                Clipboard.SetText(tedTongDoanhThu.Text);
            }
        }

        private void simpleButtonGiam_Click(object sender, EventArgs e)
        {
            if (dateEditCuoi.DateTime.ToString("yyyy-MM-dd") != "0001-01-01"
                && dateEditDau.DateTime.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                dateEditDau.DateTime = dateEditDau.DateTime.AddDays(-1);
                dateEditCuoi.DateTime = dateEditCuoi.DateTime.AddDays(-1);
                LoadDataToChartDoanhThu();
            }
        }

        private void simpleButtonTang_Click(object sender, EventArgs e)
        {
            if (dateEditCuoi.DateTime.ToString("yyyy-MM-dd") != "0001-01-01"
                && dateEditDau.DateTime.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                dateEditDau.DateTime = dateEditDau.DateTime.AddDays(1);
                dateEditCuoi.DateTime = dateEditCuoi.DateTime.AddDays(1);
                LoadDataToChartDoanhThu();
            }
        }

        private void dateEditVCDau_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataToChartMostVC();
        }

        private void dateEditVCCuoi_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataToChartMostVC();
        }

        private void cbBoxEditSoMostVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToChartMostVC();
        }


        #region LongClick

        DateTime sw;
        bool buttonUp = false;
        const int holdButtonDuration = 500;

        private void simpleButtonGiam_MouseDown(object sender, MouseEventArgs e)
        {
            buttonUp = false;
            sw = DateTime.Now;
            while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && (DateTime.Now - sw).TotalMilliseconds < holdButtonDuration))
                Application.DoEvents();
            if ((DateTime.Now - sw).TotalMilliseconds < holdButtonDuration)
                simpleButtonGiam.PerformClick();
            else
                timerGiam.Start();
        }

        private void simpleButtonGiam_MouseUp(object sender, MouseEventArgs e)
        {
            buttonUp = true;
        }

        private void simpleButtonTang_MouseDown(object sender, MouseEventArgs e)
        {
            buttonUp = false;
            sw = DateTime.Now;
            while (e.Button == MouseButtons.Left && e.Clicks == 1 && (buttonUp == false && (DateTime.Now - sw).TotalMilliseconds < holdButtonDuration))
                Application.DoEvents();
            if ((DateTime.Now - sw).TotalMilliseconds < holdButtonDuration)
                simpleButtonTang.PerformClick();
            else
                timerTang.Start();
        }

        private void simpleButtonTang_MouseUp(object sender, MouseEventArgs e)
        {
            buttonUp = true;
        }

        private void timerGiam_Tick(object sender, EventArgs e)
        {
            if (buttonUp != true)
            {
                simpleButtonGiam.PerformClick();
            }
            else timerGiam.Stop();
        }

        private void timerTang_Tick(object sender, EventArgs e)
        {
            if (buttonUp != true)
            {
                simpleButtonTang.PerformClick();
            }
            else timerTang.Stop();
        }

        #endregion

        //Xuat Bao Cao Thong Ke
        private void ButtonReportTK_Click(object sender, EventArgs e)
        {
            string NgayDau = dateEditDau.DateTime.ToString("yyyy-MM-dd");
            string NgayCuoi = dateEditCuoi.DateTime.ToString("yyyy-MM-dd");
            string TongDoanhThu = tedTongDoanhThu.Text;

            ThongKeCreator TKCreator = new ThongKeCreator(NgayDau, NgayCuoi, TongDoanhThu,dateEditDau.DateTime.ToString("dd/MM/yyyy"), dateEditCuoi.DateTime.ToString("dd/MM/yyyy"));

            TKCreator.ShowThongKeRP();

        }

        private void btnChuyenTrang_Click(object sender, EventArgs e)
        {
            panelControlVcHH.Visible = true;
        }

        private void chartControlLoaiVC_Click(object sender, EventArgs e)
        {

        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                switch (radioGroup1.SelectedIndex)
                {
                    case 1:
                        gridVCSHH.DataSource = busVaccine.SearchByMaVCSHH(tbSearch.Text,NgayTinhHan);
                        break;
                    case 2:
                        gridVCSHH.DataSource = busVaccine.SearchByTenVCSHH(tbSearch.Text,NgayTinhHan);
                        break;
                    case 3:
                        gridVCSHH.DataSource = busVaccine.SearchByLoaiVCSHH(tbSearch.Text,NgayTinhHan);
                        break;
                    case 4:
                        gridVCSHH.DataSource = busVaccine.SearchByNhaSXSHH(tbSearch.Text,NgayTinhHan);
                        break;
                    case 0:
                        gridVCSHH.DataSource = busVaccine.SearchAllSHH(tbSearch.Text,NgayTinhHan);
                        break;
                }
            }
            else gridVCSHH.DataSource = busVaccine.getAllVaccineSHH(NgayTinhHan);
        }

        private void textEdit1_Properties_Leave(object sender, EventArgs e)
        {
            NgayTinhHan = int.Parse(textEdit1.Text);
            LoadDataToChartVCSHH();
            RefreshGrid();
        }

        private void btnChuyenTrang1_Click(object sender, EventArgs e)
        {
            panelControlVcHH.Visible = false;
        }

        private void tbSearch_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }
    }
}
