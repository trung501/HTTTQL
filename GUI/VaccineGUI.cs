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
using System.Diagnostics;
using System.Reflection;
using DTO;

namespace GUI
{
    public partial class VaccineGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public static VaccineGUI _instance;
        public static VaccineGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VaccineGUI();
                }
                return _instance;
            }
        }

        BUS_Vaccine busVC = new BUS_Vaccine();

        public VaccineGUI()
        {
            InitializeComponent();


            gridView1.OptionsBehavior.Editable = false;
            //gridView1.RowClick += GridView1_RowClick;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
        }

        public void RefreshGrid()
        {
            gridVaccine.DataSource = busVC.getAllVaccine();
            gridView1.BestFitColumns();
            gridView1.Columns["MAVACCINE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            tbSearch.Focus();
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //tbGia.Text = gridView1.GetRowCellValue(e.FocusedRowHandle, "DONGIA").ToString();
            //currMAVACCINE = gridView1.GetRowCellValue(e.FocusedRowHandle, "MAVACCINE").ToString();
            //Debug.WriteLine(currMAVACCINE);
        }

        private void GridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void VaccineGUI_Load(object sender, EventArgs e)
        {
            //gridVaccine.DataSource = busVC.getAllVaccine();
            //gridView1.BestFitColumns();
            //tbSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                switch (radioGroup1.SelectedIndex)
                {
                    case 1:
                        gridVaccine.DataSource = busVC.SearchByMaVC(tbSearch.Text);
                        break;
                    case 2:
                        gridVaccine.DataSource = busVC.SearchByTenVC(tbSearch.Text);
                        break;
                    case 3:
                        gridVaccine.DataSource = busVC.SearchByLoaiVC(tbSearch.Text);
                        break;
                    case 4:
                        gridVaccine.DataSource = busVC.SearchByNhaSX(tbSearch.Text);
                        break;
                    case 0:
                        gridVaccine.DataSource = busVC.SearchAll(tbSearch.Text);
                        break;
                }
            }
            else gridVaccine.DataSource = busVC.getAllVaccine();
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
    }
}
