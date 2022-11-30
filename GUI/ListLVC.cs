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
using DTO;
using BUS;
namespace GUI
{
    public partial class ListLVC : DevExpress.XtraEditors.XtraForm
    {
        public ListLVC()
        {
            InitializeComponent();

        }
        BUS_LoaiVaccine busLVC = new BUS_LoaiVaccine();
        public void RefreshGrid()
        {
            DataTable dtLVC = busLVC.getAllLoaiVC();
            dtLVC.Columns.Remove("InfoLVC");
            gridListVC.DataSource = dtLVC;
           
        }
        private void ListLVC_Leave(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            tbMaLVC.Text = gridView1.GetRowCellValue(e.RowHandle, "MALOAIVC").ToString().Trim();
            tbTenLVC.Text = gridView1.GetRowCellValue(e.RowHandle, "LOAIVACCINE").ToString().Trim();
        }

        private void btnThemLVC_Click(object sender, EventArgs e)
        {
            if (tbMaLVC.Text != "")
            {
                MessageBoxEx.Show("Để thêm mới loại vaccine, vui lòng để trống mã loại vaccine.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (busLVC.IsLoaiVCExists(tbTenLVC.Text.Trim()))
            {
                MessageBoxEx.Show("Loại vaccine đã tồn tại, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string maLVC = busLVC.NextMAVACCINE();
            if (busLVC.InsertLoaiVC(new DTO_LoaiVaccine(maLVC, tbTenLVC.Text.Trim())))
                {
                MessageBoxEx.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            else
            {
                MessageBoxEx.Show("Có lỗi xảy ra, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnXoaLVC_Click(object sender, EventArgs e)
        {           
            if (!busLVC.XoaLoaiVC(tbMaLVC.Text.Trim()))
                {
                 MessageBoxEx.Show("Xóa không thành công. Vui lòng thử lại sau. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
             }
        RefreshGrid();            
        MessageBoxEx.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void tbMaLVC_Click(object sender, EventArgs e)
        {
            lbNewLVC.Show();
        }

        private void tbMaLVC_Leave(object sender, EventArgs e)
        {
            lbNewLVC.Hide();
            tbMaLVC.Text = tbMaLVC.Text.ToUpper();  
        }
    }
}