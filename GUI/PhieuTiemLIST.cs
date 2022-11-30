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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PhieuTiemLIST : DevExpress.XtraEditors.XtraForm
    {
        List<string> deletedMaPT = new List<string>();
        List<DTO_PhieuTiemInfo> editedPT = new List<DTO_PhieuTiemInfo>();

        BUS_PhieuTiem busPT = new BUS_PhieuTiem();

        string MaPT;

        public PhieuTiemLIST()
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
            deletedMaPT.Clear();
            editedPT.Clear();
        }

        private void EnableResetAndSaveButton()
        {
            btnReset.Enabled = true;
            btnSave.Enabled = true;
            btnSave.Text = "Lưu";
            btnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            btnReset.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
        }

        private void PhieuTiemLIST_Load(object sender, EventArgs e)
        {
            gridPT.DataSource = busPT.GetAllPhieuTiemInfo();
            gridView1.BestFitColumns();
            gridView1.Columns["MAPHIEUTIEM"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void gridPT_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            int[] selectedRowHandles = view.GetSelectedRows();
            if (e.KeyData == Keys.Delete)
            {
                string s = view.GetRowCellValue(selectedRowHandles[0], "MAPHIEUTIEM").ToString();
                deletedMaPT.Add(s);
                EnableResetAndSaveButton();
                view.DeleteSelectedRows();
                gridVC.DataSource = null;
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Các thay đổi chưa lưu sẽ bị mất. Bạn có chắc chắn muốn đặt lại?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridPT.DataSource = busPT.GetAllPhieuTiemInfo();
                DisableResetAndSaveButton();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < deletedMaPT.Count; i++)
            {
                busPT.DeletePhieuTiem(deletedMaPT[i]);
            }
            for (int i = 0; i < editedPT.Count; i++)
            {
                busPT.UpdatePhieuTiemInfo(editedPT[i]);
            }
            DisableResetAndSaveButton();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //var gv = sender as GridView;
            //var rowIndex = gv.FocusedRowHandle;
            //var columnIndex = gv.FocusedColumn.VisibleIndex;
            //MessageBox.Show(rowIndex + " " + columnIndex);
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
                    if (view.FocusedColumn == gridView1.Columns["MAPHIEUTIEM"] || view.FocusedColumn == gridView1.Columns["MAKH"] || view.FocusedColumn == gridView1.Columns["TENBS"])
                    {

                    }
                    else view.ShowEditor();
                }
                if (e.Clicks == 1)
                {
                    btnXuat.Enabled = true;
                    btnXuat.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
                    int[] selectedRowHandles = view.GetSelectedRows();
                    MaPT = view.GetRowCellValue(selectedRowHandles[0], "MAPHIEUTIEM").ToString();
                    gridVC.DataSource = busPT.GetVCFromPHIEUTIEM(view.GetRowCellValue(selectedRowHandles[0], "MAPHIEUTIEM").ToString());
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PhieuTiemLIST_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (deletedMaPT.Count > 0 || editedPT.Count > 0)
            {
                DialogResult result = MessageBoxEx.Show("Bạn có muốn lưu các thay đổi không?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    FormClosing -= PhieuTiemLIST_FormClosing;
                    Close();
                }
                else if (result == DialogResult.No)
                {
                    FormClosing -= PhieuTiemLIST_FormClosing;
                    Close();
                }
                else e.Cancel = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Nhấn đúp vào một ô để sửa thông tin \nNhấn phím Delete để xoá 1 bản ghi", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            int[] selectedRowHandles = view.GetSelectedRows();

            string maPT = view.GetRowCellValue(selectedRowHandles[0], "MAPHIEUTIEM").ToString();

            for (int i = 0; i < editedPT.Count; i++)
            {
                if (editedPT[i].MaPT == maPT)
                {
                    editedPT[i].NgayTiem = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYTIEM").ToString()).ToString("yyyy-MM-dd");
                    editedPT[i].TenKH = view.GetRowCellValue(selectedRowHandles[0], "TENKH").ToString();
                    editedPT[i].NgaySinh = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYSINH").ToString()).ToString("yyyy-MM-dd");
                    editedPT[i].GioiTinh = view.GetRowCellValue(selectedRowHandles[0], "GIOITINH").ToString();
                    editedPT[i].TieuSu = view.GetRowCellValue(selectedRowHandles[0], "TIEUSU").ToString();
                    return;
                }
            }

            string ngayTiem = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYTIEM").ToString()).ToString("yyyy-MM-dd");
            string tenKH = view.GetRowCellValue(selectedRowHandles[0], "TENKH").ToString();
            string ngaySinh = Convert.ToDateTime(view.GetRowCellValue(selectedRowHandles[0], "NGAYSINH").ToString()).ToString("yyyy-MM-dd");
            string gioiTinh = view.GetRowCellValue(selectedRowHandles[0], "GIOITINH").ToString();
            string tieuSu = view.GetRowCellValue(selectedRowHandles[0], "TIEUSU").ToString();
            string email= view.GetRowCellValue(selectedRowHandles[0], "EMAIL").ToString();
            string sdt = view.GetRowCellValue(selectedRowHandles[0], "SDT").ToString();

            DTO_PhieuTiemInfo ptif = new DTO_PhieuTiemInfo(maPT, ngayTiem, tenKH, ngaySinh, gioiTinh, tieuSu,email,sdt);
            editedPT.Add(ptif);
            EnableResetAndSaveButton();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            PhieuTiemRP_Provider ptRP = new PhieuTiemRP_Provider(MaPT);
            ptRP.ShowReport();
        }
    }
}
