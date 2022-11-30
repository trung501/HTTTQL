using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Diagnostics;
using System.Reflection;
using DTO;
namespace GUI
{
    public partial class NhapKhoGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public static NhapKhoGUI _instance;
        public static NhapKhoGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NhapKhoGUI("");
                }
                return _instance;
            }
        }
        BUS_NhapKho busNK = new BUS_NhapKho();
        BUS_LoaiVaccine busLVC = new BUS_LoaiVaccine();
        private string maQT;
        private string maQK;

        public NhapKhoGUI(string maTK)
        {
            InitializeComponent();
            dtpNgaySanXuat.Text= DateTime.Now.ToString("MM/dd/yyyy");
            dtpHanSuDung.Text= DateTime.Now.ToString("MM/dd/yyyy");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.RowClick += gridView1_RowClick;
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            this.maQT = "";
            this.maQK = "";
            if (maTK.StartsWith("QT")){
                this.maQT = maTK;
            }
            else if (maTK.StartsWith("QK"))
            {
                this.maQK = maTK;
            }
        }

        

        public void RefreshGrid()
        {
            cbLoaiVC.Properties.Items.Clear();
            DataTable dt = busLVC.getAllLoaiVC();
            foreach (DataRow row in dt.Rows)
            {
                cbLoaiVC.Properties.Items.Add(row["InfoLVC"]);            
            }

            gridVaccine.DataSource = busNK.getAllVaccine();
            gridView1.BestFitColumns();
            gridView1.Columns["MAVACCINE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            tbSearch.Focus();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                switch (radioGroup1.SelectedIndex)
                {
                    case 1:
                        gridVaccine.DataSource = busNK.SearchByMaVC(tbSearch.Text);
                        break;
                    case 2:
                        gridVaccine.DataSource = busNK.SearchByTenVC(tbSearch.Text);
                        break;
                    case 3:
                        gridVaccine.DataSource = busNK.SearchByLoaiVC(tbSearch.Text);
                        break;
                    case 4:
                        gridVaccine.DataSource = busNK.SearchByNhaSX(tbSearch.Text);
                        break;
                    case 0:
                        gridVaccine.DataSource = busNK.SearchAll(tbSearch.Text);
                        break;
                }
            }
            else gridVaccine.DataSource = busNK.getAllVaccine();
        }

  

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            tbMaVC.Text = gridView1.GetRowCellValue(e.RowHandle, "MAVACCINE").ToString().Trim();
            tbTenVC.Text= gridView1.GetRowCellValue(e.RowHandle, "TENVACCINE").ToString().Trim();
            tbNhaSanXuat.Text= gridView1.GetRowCellValue(e.RowHandle, "NHASX").ToString().Trim();
            dtpNgaySanXuat.Text= gridView1.GetRowCellValue(e.RowHandle, "NGAYSX").ToString().Split(' ')[0];
            dtpHanSuDung.Text= gridView1.GetRowCellValue(e.RowHandle, "HANSD").ToString().Split(' ')[0];
            tbSoLo.Text= gridView1.GetRowCellValue(e.RowHandle, "SOLO").ToString().Trim();
            tbDonGia.Text= gridView1.GetRowCellValue(e.RowHandle, "DONGIA").ToString().Trim();
            cbLoaiVC.Text = busNK.getMaLVCFromMaVC(tbMaVC.Text) +" - "+  gridView1.GetRowCellValue(e.RowHandle, "LOAIVACCINE").ToString().Trim();
            tbSoLuong.Text= gridView1.GetRowCellValue(e.RowHandle, "SOLUONGCOSAN").ToString().Trim();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbLoaiVC.Properties.Items.Clear();
            DataTable dt = busLVC.getAllLoaiVC();
            foreach (DataRow row in dt.Rows)
            {
                cbLoaiVC.Properties.Items.Add(row["InfoLVC"]);
            }
            cbLoaiVC.Text = "";
            gridVaccine.DataSource = busNK.getAllVaccine();
            gridView1.Columns["MAVACCINE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            tbMaVC.Text = "";
            tbTenVC.Text = "";
            tbNhaSanXuat.Text ="";
            dtpNgaySanXuat.Text = DateTime.Now.ToString("MM/dd/yyyy");
            dtpHanSuDung.Text = DateTime.Now.ToString("MM/dd/yyyy");
            tbSoLo.Text = "";
            tbDonGia.Text = "";
            cbLoaiVC.Text = "";
            tbSoLuong.Text = "";
        }

        private void tbMaVC_Leave(object sender, EventArgs e)
        {
            lbNewVC.Visible = false;
            tbMaVC.Text = tbMaVC.Text.ToUpper();
        }

        private void tbMaVC_Click(object sender, EventArgs e)
        {
            lbNewVC.Visible = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (this.maQT != "" || this.maQK != "")
            { 
                if (busNK.IsVCInStock(tbMaVC.Text))
                {
                    string maLVC = cbLoaiVC.Text.Split(' ')[0];
                    if (busNK.ChinhSuaVaccine(new DTO_QuanLyVaccine(tbMaVC.Text, tbTenVC.Text, tbNhaSanXuat.Text, dtpNgaySanXuat.DateTime.ToString("yyyy-MM-dd"), dtpHanSuDung.DateTime.ToString("yyyy-MM-dd"), tbSoLo.Text, int.Parse(tbSoLuong.Text), int.Parse(tbDonGia.Text), maLVC, this.maQK,this.maQT)))
                    {
                        MessageBoxEx.Show("Chỉnh sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGrid();
                    }
                    else {
                        MessageBoxEx.Show("Thay đổi không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBoxEx.Show("Mã vaccine không tồn tại. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBoxEx.Show("Bạn phải có quyền quản lý vaccine mới thực hiện được thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.maQT!=""||this.maQK!= "")
            {
                if (tbMaVC.Text != "")
                {
                    MessageBoxEx.Show("Để thêm mới vaccine, vui lòng để trống mã vaccine.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string maVC = busNK.NextMAVACCINE();
                if (tbTenVC.Text != "" && tbNhaSanXuat.Text != "" && tbNhaSanXuat.Text != "" && dtpNgaySanXuat.Text != "" && dtpHanSuDung.Text != "" && tbSoLo.Text != "" && tbSoLuong.Text != "" && tbDonGia.Text != "" && cbLoaiVC.Text != "")
                {
                    string maLVC = cbLoaiVC.Text.Split(' ')[0];
                    if (busNK.InsertVaccine(new DTO_QuanLyVaccine(maVC, tbTenVC.Text, tbNhaSanXuat.Text, dtpNgaySanXuat.DateTime.ToString("yyyy-MM-dd"), dtpHanSuDung.DateTime.ToString("yyyy-MM-dd"), tbSoLo.Text, int.Parse(tbSoLuong.Text), int.Parse(tbDonGia.Text), maLVC, this.maQK,this.maQT)))
                    {
                        MessageBoxEx.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGrid();
                    }
                    else
                    {
                        MessageBoxEx.Show("Thêm không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Vui lòng nhập toàn bộ thông tin vaccine trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBoxEx.Show("Bạn phải có quyền quản lý vaccine mới thực hiện được thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbLoaiVC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLVC_Click(object sender, EventArgs e)
        {
            ListLVC listLVC = new ListLVC();
            listLVC.RefreshGrid();
            listLVC.ShowDialog();
        }
    }

}
