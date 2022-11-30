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

namespace GUI
{
    public partial class LichSuGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public static LichSuGUI _instance;
        public static LichSuGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LichSuGUI();
                }
                return _instance;
            }
        }

        BUS_LichSu busLS = new BUS_LichSu();

        public LichSuGUI()
        {
            InitializeComponent();
            gridLichSu.DataSource = busLS.getAllLichSu("");
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns["NGAYTIEM"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridView1.RowClick += GridView1_RowClick;
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dtpNgayTiem.Text = gridView1.GetRowCellValue(e.RowHandle, "NGAYTIEM").ToString().Substring(0, 10);
            tbTenVC.Text = gridView1.GetRowCellValue(e.RowHandle, "TENVACCINE").ToString();
            tbLoaiVC.Text = gridView1.GetRowCellValue(e.RowHandle, "LOAIVACCINE").ToString();
            tbNhaSX.Text = gridView1.GetRowCellValue(e.RowHandle, "NHASX").ToString();
            tbMuiThu.Text = gridView1.GetRowCellValue(e.RowHandle, "MUITHU").ToString();
            tbLieuLuong.Text = gridView1.GetRowCellValue(e.RowHandle, "LIEULUONG").ToString();
            dtpNhacLai.Text = gridView1.GetRowCellValue(e.RowHandle, "NGAYTIEMNHACLAI").ToString().Substring(0, 10);
            tbDonGia.Text = gridView1.GetRowCellValue(e.RowHandle, "DONGIA").ToString();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            gridLichSu.DataSource = busLS.getAllLichSu(tbMaKH.Text);
            gridView1.BestFitColumns();
        }

        private void tbMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTraCuu.PerformClick();
            }
        }
    }
}
