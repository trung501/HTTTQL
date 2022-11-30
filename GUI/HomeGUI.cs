using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class HomeGUI : UserControl
    {
        public static HomeGUI _instance;
        public static HomeGUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HomeGUI();
                }
                return _instance;
            }
        }

        public HomeGUI()
        {
            InitializeComponent();
        }
    }
}
