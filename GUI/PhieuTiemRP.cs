using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class PhieuTiemRP : DevExpress.XtraReports.UI.XtraReport
    {
        public PhieuTiemRP(string maPT)
        {
            InitializeComponent();
            BarCode_MaPT.Text = maPT;
        }

    }
}
