using BUS;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThanhToanLIST : DevExpress.XtraEditors.XtraForm
    {
        List<string> deletedMaHD = new List<string>();
        List<DTO_HoaDonInfo> editedHD = new List<DTO_HoaDonInfo>();

        BUS_HoaDon busHD = new BUS_HoaDon();
        BUS_PhieuTiem busPT = new BUS_PhieuTiem();

        string MaHD;

        public ThanhToanLIST()
        {
            InitializeComponent();
            DisableResetAndSaveButton();
            btnXuat.Enabled = false;
            btnXuat.Appearance.BackColor = Color.White;
        }

        private void DisableResetAndSaveButton()
        {
            btnReset.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Text = "Đã lưu";
            btnSave.Appearance.BackColor = Color.White;
            btnReset.Appearance.BackColor = Color.White;
            deletedMaHD.Clear();
            editedHD.Clear();
        }

        private void EnableResetAndSaveButton()
        {
            btnReset.Enabled = true;
            btnSave.Enabled = true;
            btnSave.Text = "Lưu";
            btnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            btnReset.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
        }

        private void ThanhToanLIST_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (deletedMaHD.Count > 0 || editedHD.Count > 0)
            {
                DialogResult result = MessageBoxEx.Show("Bạn có muốn lưu các thay đổi không?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    FormClosing -= ThanhToanLIST_FormClosing;
                    Close();
                }
                else if (result == DialogResult.No)
                {
                    FormClosing -= ThanhToanLIST_FormClosing;
                    Close();
                }
                else e.Cancel = true;
            }
        }

        private void ThanhToanLIST_Load(object sender, EventArgs e)
        {
            gridHD.DataSource = busHD.GetALlHoaDonInfo();
            gridView1.Columns["MAHOADON"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("- Nhấn đúp vào một ô để sửa thông tin (Chỉ cho phép sửa Ngày thu, Tên NGH, Địa chỉ NGH, SĐT NGH) \n- Nhấn phím Delete để xoá 1 bản ghi", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Các thay đổi chưa lưu sẽ bị mất. Bạn có chắc chắn muốn đặt lại?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridHD.DataSource = busHD.GetALlHoaDonInfo();
                DisableResetAndSaveButton();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < deletedMaHD.Count; i++)
            {
                busHD.DeleteHoaDon(deletedMaHD[i]);
            }
            for (int i = 0; i < editedHD.Count; i++)
            {
                busHD.UpdateHoaDonInfo(editedHD[i]);
            }
            DisableResetAndSaveButton();
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);

            if (hitInfo.InRowCell)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                view.FocusedColumn = hitInfo.Column;
                DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                if (e.Clicks == 2 && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (view.FocusedColumn == gridView1.Columns["MAHOADON"] || view.FocusedColumn == gridView1.Columns["TONGTIEN"] || view.FocusedColumn == gridView1.Columns["CHIETKHAU"] || view.FocusedColumn == gridView1.Columns["KHACHHANG"] || view.FocusedColumn == gridView1.Columns["THUNGAN"])
                    {

                    }
                    else view.ShowEditor();
                }
                if (e.Clicks == 1)
                {
                    btnXuat.Enabled = true;
                    btnXuat.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                    int[] selectedRowHandles = view.GetSelectedRows();
                    MaHD = view.GetRowCellValue(selectedRowHandles[0], "MAHOADON").ToString();
                    string maPT = busHD.GetMaPhieuTiemFromHD(MaHD);
                    gridVC.DataSource = busPT.GetVCFromPHIEUTIEM(maPT);
                }
            }
        }

        private void gridHD_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            int[] selectedRowHandles = view.GetSelectedRows();
            if (e.KeyData == Keys.Delete)
            {
                string s = view.GetRowCellValue(selectedRowHandles[0], "MAHOADON").ToString();
                deletedMaHD.Add(s);
                EnableResetAndSaveButton();
                view.DeleteSelectedRows();
                gridVC.DataSource = null;
                e.Handled = true;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            int[] selectedRowHandles = view.GetSelectedRows();

            string maHD = view.GetRowCellValue(selectedRowHandles[0], "MAHOADON").ToString();

            for (int i = 0; i < editedHD.Count; i++)
            {
                if (editedHD[i].MaHD == maHD)
                {
                    editedHD[i].NgayThu = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYTHU").ToString()).ToString("yyyy-MM-dd");
                    editedHD[i].NguoiGH = view.GetRowCellValue(selectedRowHandles[0], "NGUOIGH").ToString();
                    editedHD[i].DiaChi = view.GetRowCellValue(selectedRowHandles[0], "DIACHI").ToString();
                    editedHD[i].Sdt = view.GetRowCellValue(selectedRowHandles[0], "SDT").ToString();
                    editedHD[i].Email = view.GetRowCellValue(selectedRowHandles[0], "EMAIL").ToString();
                    return;
                }
            }

            string ngayThu = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYTHU").ToString()).ToString("yyyy-MM-dd");
            string nguoiGH = view.GetRowCellValue(selectedRowHandles[0], "NGUOIGH").ToString();
            string diaCHi = view.GetRowCellValue(selectedRowHandles[0], "DIACHI").ToString();
            string sdt = view.GetRowCellValue(selectedRowHandles[0], "SDT").ToString();
            string email = view.GetRowCellValue(selectedRowHandles[0], "EMAIL").ToString();
            DTO_HoaDonInfo hdif = new DTO_HoaDonInfo(maHD, ngayThu, nguoiGH, diaCHi, sdt,email);

            editedHD.Add(hdif);

            EnableResetAndSaveButton();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            HoaDonCreator HoaDonCreator = new HoaDonCreator(MaHD);
            HoaDonCreator.ShowReportHoaDon();
        }
    }
}
