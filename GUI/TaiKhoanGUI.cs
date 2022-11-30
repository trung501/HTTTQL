using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using GUI.Properties;
using DTO;
using DevExpress.XtraGrid.Localization;

namespace GUI
{
    public partial class TaiKhoanGUI : UserControl
    {
        private string maQT;
        private string pass;
        public static TaiKhoanGUI _instance;
        public static TaiKhoanGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaiKhoanGUI("", "");
                }
                return _instance;
            }
        }
        BUS_ThemTK busTaiKhoan = new BUS_ThemTK();
        BUS_BacSi busBacSi = new BUS_BacSi();
        BUS_ThuNgan busThuNgan = new BUS_ThuNgan();
        BUS_QuanKho busQuanKho = new BUS_QuanKho();
        BUS_QuanTri BusQuanTri = new BUS_QuanTri();
        public TaiKhoanGUI(string maQT, string pass)
        {
            InitializeComponent();
            cbChucVu.SelectedIndex = 0;
            deNgaySinh.Text = DateTime.Now.ToString("MM/dd/yyyy");
            GridLocalizer.Active = new MyGridLocalizer();
            this.setVerified(maQT, pass);
        }
        public void setVerified(string maQT, string pass)
        {
            if (maQT.StartsWith("QT"))
            {
                this.maQT = maQT;
                this.pass = pass;
            }
            else
            {
                this.maQT = "";
                this.pass = "";
            }
        }
        public void RefreshGrid()
        {
            gridcDanhSachTK.DataSource = busTaiKhoan.GetAllGeneralInfoTaiKhoan(maQT, pass);
        }




        private void displayFollowChucVu(string chucVu)
        {
            if (chucVu == "Bác sĩ")
            {
                lbBangCap.Visible = true;
                teBangCap.Visible = true;
                lbChuyenKhoa.Visible = true;
                teChuyenKhoa.Visible = true;
            }
            else
            {
                lbBangCap.Visible = false;
                teBangCap.Visible = false;
                lbChuyenKhoa.Visible = false;
                teChuyenKhoa.Visible = false;
            }

        }




        private void teMaThanhVien_Properties_Leave(object sender, EventArgs e)
        {
            teMaThanhVien.Text = teMaThanhVien.Text.ToUpper();
        }

  

        private void gridView2_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cbChucVu.Enabled = false;
            teMaThanhVien.Enabled = false;
            tePassWord.Enabled = true;
            DataRow rowSelected = busTaiKhoan.GetFullInfoTaiKhoan(gridView2.GetRowCellValue(e.RowHandle, "MA").ToString().Trim());
            cbChucVu.Text = rowSelected[5].ToString().Trim();
            teHoTen.Text = rowSelected[1].ToString().Trim();
            deNgaySinh.Text = rowSelected[2].ToString().Split(' ')[0];
            teDiaChi.Text = rowSelected[4].ToString().Trim();
            teSDT.Text = rowSelected[3].ToString().Trim();
            teMaThanhVien.Text = rowSelected[0].ToString().Trim();
            teBangCap.Text = rowSelected[7].ToString().Trim();
            teChuyenKhoa.Text = rowSelected[6].ToString().Trim();
            tePassWord.Text = "";
            displayFollowChucVu(cbChucVu.Text.Trim());
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (teMaThanhVien.Text.Trim() != "")
            {
                MessageBoxEx.Show("Để thêm tài khoản, vui lòng để trống mã tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maTK = "";
            if (cbChucVu.Text.Trim() == "Bác sĩ")
            {
                maTK = busBacSi.NextMABS();
            }
            else if (cbChucVu.Text.Trim() == "Thu ngân")
            {
                maTK = busThuNgan.NextMATHUNGAN();
            }
            else if (cbChucVu.Text.Trim() == "Quản lí kho")
            {
                maTK = busQuanKho.NextMAQUANKHO();
            }
            else if (cbChucVu.Text.Trim() == "Quản trị")
            {
                maTK = BusQuanTri.NextMAQUANTRI();
            }
            else
            {
                MessageBoxEx.Show("Chưa có chức vụ đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (teHoTen.Text != "" && cbChucVu.Text != "" && deNgaySinh.Text != "" && teDiaChi.Text != "" && tePassWord.Text != "" && teSDT.Text != "")
            {
                string newPassUser = busTaiKhoan.createHashPass(maQT, pass, tePassWord.Text.Trim());
                if (busTaiKhoan.InsertTaiKhoan(new DTO_ThemTK(maTK, newPassUser, cbChucVu.Text, teHoTen.Text, deNgaySinh.DateTime.ToString("yyyy-MM-dd"), teSDT.Text, teDiaChi.Text, teChuyenKhoa.Text, teBangCap.Text), maQT, pass))
                {
                    MessageBoxEx.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string showInfo = "Mã tài khoản: " + maTK + "\nMật khẩu: " + tePassWord.Text.Trim();
                    MessageBoxEx.Show(showInfo, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                    btnReset.PerformClick();
                }
                else
                {
                    MessageBoxEx.Show("Thêm không thành công. Vui lòng thử lại. Đảm bảo bạn đang đăng nhập với tài khoản quản trị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBoxEx.Show("Vui lòng nhập toàn bộ thông tin tài khoản trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            if (busTaiKhoan.CheckExistance(teMaThanhVien.Text.Trim()))
            {
                string passUser = "";

                if (tePassWord.Text.Trim() == "")
                {
                    passUser = busTaiKhoan.GetHashpassFromTaiKhoan(maQT, pass, teMaThanhVien.Text.Trim());
                }
                else
                {
                    passUser = busTaiKhoan.createHashPass(maQT, pass, tePassWord.Text.Trim());
                }
                if (busTaiKhoan.UpdateTaiKhoanInfo(new DTO_ThemTK(teMaThanhVien.Text, passUser, cbChucVu.Text, teHoTen.Text, deNgaySinh.DateTime.ToString("yyyy-MM-dd"), teSDT.Text, teDiaChi.Text, teChuyenKhoa.Text, teBangCap.Text), maQT, pass))
                {
                    MessageBoxEx.Show("Chỉnh sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }

                else
                {
                    MessageBoxEx.Show("Thay đổi không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBoxEx.Show("Mã tài khoản không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (busTaiKhoan.DeleteTaikhoan(teMaThanhVien.Text))
            {
                MessageBoxEx.Show("Xóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            else
            {
                MessageBoxEx.Show("Xóa tài khoản không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void teMaThanhVien_Leave(object sender, EventArgs e)
        {
            teMaThanhVien.Text = teMaThanhVien.Text.ToUpper();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            teHoTen.Text = null;
            teMaThanhVien.Text = null;
            tePassWord.Text = null;
            teSDT.Text = null;
            teDiaChi.Text = null;
            teBangCap.Text = null;
            teChuyenKhoa.Text = null;
            deNgaySinh.Text = DateTime.Now.ToString("MM/dd/yyyy");
            cbChucVu.Text = null;
            cbChucVu.Enabled = true;
            cbChucVu.SelectedIndex = 0;
            teMaThanhVien.Enabled = true;
            RefreshGrid();
        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayFollowChucVu(cbChucVu.Text.Trim());
        }
    }
}
