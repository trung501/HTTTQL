using BUS;
using DevExpress.XtraBars;
using DTO;
using GUI.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        Login login = new Login();
        BUS_ThuNgan busTN = new BUS_ThuNgan();
        public DTO_ThuNgan thungan;
        public DTO_ThemTK taikhoan;
        BUS_ThemTK busTK = new BUS_ThemTK();

        ThanhToanGUI ttGUI;
        VaccineGUI vcGUI;
        NhapKhoGUI nkGUI;
        PhieuTiemGUI ptGUI;
        TaiKhoanGUI tkGUI;
        private string maTK;
        public Form1(string maTK, string pass) //uyen
        {
            InitializeComponent();
            this.maTK = maTK;//hehe
            DataRow infoTaiKhoan = busTK.GetFullInfoTaiKhoan(maTK);
            if (this.maTK == "G00" || infoTaiKhoan == null)
            {
                taikhoan = new DTO_ThemTK("G00", null, null, "Khách hàng", null, null, null, null, null);
            }
            else
            {
                taikhoan = new DTO_ThemTK(this.maTK, pass, infoTaiKhoan["CHUCVU"].ToString(), infoTaiKhoan["HOTEN"].ToString(), infoTaiKhoan["NGAYSINH"].ToString().Split(' ')[0], infoTaiKhoan["SDT"].ToString(), infoTaiKhoan["DIACHI"].ToString(), null, null);
            }
         
            barStaticItem.Caption = "Xin chào " + taikhoan.HOTEN;

            ttGUI = new ThanhToanGUI(taikhoan);
            container.Controls.Add(ttGUI);
            ttGUI.Dock = DockStyle.Fill;

            vcGUI = new VaccineGUI();
            container.Controls.Add(vcGUI);
            vcGUI.Dock = DockStyle.Fill;

            nkGUI = new NhapKhoGUI(maTK);
            container.Controls.Add(nkGUI);
            nkGUI.Dock = DockStyle.Fill;

            ptGUI = new PhieuTiemGUI();
            container.Controls.Add(ptGUI);
            ptGUI.Dock = DockStyle.Fill;

            tkGUI = new TaiKhoanGUI(maTK, pass);
            container.Controls.Add(tkGUI);
            tkGUI.Dock = DockStyle.Fill;

            container.Controls.Add(LichSuGUI.Instance);
            LichSuGUI.Instance.Dock = DockStyle.Fill;

            container.Controls.Add(ThongKeGUI.Instance);
            ThongKeGUI.Instance.Dock = DockStyle.Fill;

            container.Controls.Add(ThongKeKHDenHan.Instance);
            ThongKeKHDenHan.Instance.Dock = DockStyle.Fill;

            container.Controls.Add(HomeGUI.Instance);
            HomeGUI.Instance.Dock = DockStyle.Fill;


            if (this.maTK.StartsWith("QT"))
            {
                AdminDisplay();
            }
            else if (this.maTK.StartsWith("TN"))
            {
                ThuNganDisplay();
            }
            else if (this.maTK.StartsWith("QK"))
            {
                NhapKhoDisplay();
            }
            else if (this.maTK.StartsWith("BS"))
            {
                BacSiDisplay();
            }
            else
            {
                KhachHangDisplay();
            }
            //AdminDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //acePhieuTiem_Click(sender, e);
            accordionControl1.Elements[0].Image = Resources.home_clicked;
            accordionControl1.Elements[0].Appearance.Normal.ForeColor = Color.FromArgb(31, 187, 166);
            accordionControl1.Elements[0].Appearance.Hovered.ForeColor = Color.FromArgb(31, 187, 166);
            HomeGUI.Instance.BringToFront();
        }
        
        private void BacSiDisplay()
        {
            aceHome.Visible = true;
            aceVaccine1.Visible = true;
            aceVaccine2.Visible = false;
            aceLichSu.Visible = true;
            acePhieuTiem.Visible = true;
            aceThanhToan.Visible = false;
            aceThongKe.Visible = true;
            aceTaoTaiKhoan.Visible = false;
        }
        private void KhachHangDisplay()
        {
            aceHome.Visible = true;
            aceVaccine1.Visible = false;
            aceVaccine2.Visible = false;
            aceLichSu.Visible = true;
            acePhieuTiem.Visible = false;
            aceThanhToan.Visible = false;
            aceThongKe.Visible = false;
            aceTaoTaiKhoan.Visible = false;
        }

        private void AdminDisplay()
        {
            aceHome.Visible = true;
            aceVaccine1.Visible = false;
            aceVaccine2.Visible = true;
            aceLichSu.Visible = true;
            acePhieuTiem.Visible = true;
            aceThanhToan.Visible = true;
            aceThongKe.Visible = true;
            aceTaoTaiKhoan.Visible = true;
        }
        private void ThuNganDisplay()
        {
            aceHome.Visible = true;
            aceVaccine1.Visible = true;
            aceVaccine2.Visible = false;
            aceLichSu.Visible = true;
            acePhieuTiem.Visible = true;
            aceThanhToan.Visible = true;
            aceThongKe.Visible = false;
            aceTaoTaiKhoan.Visible = false;
        }
        private void NhapKhoDisplay()
        {
            aceHome.Visible = true;
            aceVaccine1.Visible = false;
            aceVaccine2.Visible = true;
            aceLichSu.Visible = true;
            acePhieuTiem.Visible = false;
            aceThanhToan.Visible = false;
            aceThongKe.Visible = false;
            aceTaoTaiKhoan.Visible = false;
        }
        private void aceThanhToan_Click(object sender, EventArgs e)
        {
            ttGUI.BringToFront();
        }

        private void aceLichSu_Click(object sender, EventArgs e)
        {
            LichSuGUI.Instance.BringToFront();
        }

        private void aceVaccine_Click(object sender, EventArgs e)
        {
            vcGUI.RefreshGrid();
            vcGUI.BringToFront();

        }

        private void acePhieuTiem_Click(object sender, EventArgs e)
        {
            ptGUI.RefreshGrid();
            ptGUI.BringToFront();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void aceThongKe_Click(object sender, EventArgs e)
        {
            if (this.maTK.StartsWith("BS"))
            {
                ThongKeKHDenHan.Instance.BringToFront();
            }
            else
            {
                ThongKeGUI.Instance.BringToFront();
            }
        }

        private void aceHome_Click(object sender, EventArgs e)
        {
            HomeGUI.Instance.BringToFront();
        }
        private void aceVaccine2_Click(object sender, EventArgs e)
        {
            nkGUI.RefreshGrid();
            nkGUI.BringToFront();
        }
        private void aceTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            tkGUI.RefreshGrid();
            tkGUI.BringToFront();
        }
        private void accordionControl1_ElementClick(object sender, DevExpress.XtraBars.Navigation.ElementClickEventArgs e)
        {
            accordionControl1.Elements[0].Image = Resources.home;
            accordionControl1.Elements[0].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[0].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[1].Image = Resources.vaccine;
            accordionControl1.Elements[1].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[1].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[2].Image = Resources.vaccine;
            accordionControl1.Elements[2].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[2].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[3].Image = Resources.clock;
            accordionControl1.Elements[3].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[3].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[4].Image = Resources.add;
            accordionControl1.Elements[4].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[4].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[5].Image = Resources.pay;
            accordionControl1.Elements[5].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[5].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[6].Image = Resources.statistics;
            accordionControl1.Elements[6].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[6].Appearance.Hovered.ForeColor = Color.White;

            accordionControl1.Elements[7].Image = Resources.add;
            accordionControl1.Elements[7].Appearance.Normal.ForeColor = Color.White;
            accordionControl1.Elements[7].Appearance.Hovered.ForeColor = Color.White;

            switch (e.Element.Text)
            {
                case " Trang chủ":
                    e.Element.Image = Resources.home_clicked;
                    break;
                case " Quản lý vaccine":
                    e.Element.Image = Resources.vaccine_clicked;
                    break;
                case " Lịch sử tiêm":
                    e.Element.Image = Resources.clock_clicked;
                    break;
                case " Tạo phiếu tiêm":
                    e.Element.Image = Resources.add_clicked;
                    break;
                case " Thanh toán":
                    e.Element.Image = Resources.pay_clicked;
                    break;
                case " Thống kê":
                    e.Element.Image = Resources.statistics_clicked;
                    break;
                case " Tạo tài khoản":
                    e.Element.Image = Resources.add_clicked;
                    break;
            }
            e.Element.Appearance.Normal.ForeColor = Color.FromArgb(31, 187, 166);
            e.Element.Appearance.Hovered.ForeColor = Color.FromArgb(31, 187, 166);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
