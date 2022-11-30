using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;

namespace GUI
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        BUS_Login bus = new BUS_Login();
        bool isUserCorrect = true;
        bool isPassCorrect = true;

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = tbUser.Text.Trim();
            string pass = tbPassword.Text.Trim();
            if (bus.Login(user, pass))
            {
                new Form1(user,bus.getHashPass(user,pass)).Show();
                this.Hide();
            }
            else
            {
                if (tbUser.Text == "" && tbPassword.Text == "")
                {
                    isUserCorrect = false;
                    isPassCorrect = false;
                    tbUser.Refresh();
                    tbPassword.Refresh();
                }
                else if (tbUser.Text == "")
                {
                    isUserCorrect = false;
                    tbUser.Refresh();
                }
                else if (tbPassword.Text == "")
                {
                    isPassCorrect = false;
                    tbPassword.Refresh();
                }
                else
                {
                    MessageBoxEx.Show(this, "Tên đăng nhập hoặc mật khẩu sai");
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPass.Checked)
            {
                tbPassword.Properties.PasswordChar = '\0';
            }
            else
                tbPassword.Properties.PasswordChar = '*';
        }

        private void tbUser_Paint(object sender, PaintEventArgs e)
        {
            if (!isUserCorrect)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red,
                    rec.Left,
                    rec.Top,
                    rec.Width,
                    rec.Height);
            }
        }

        private void tbPassword_Paint(object sender, PaintEventArgs e)
        {
            if (!isPassCorrect)
            {
                RectangleF rec = e.Graphics.ClipBounds;
                rec.Inflate(-1, -1);
                e.Graphics.DrawRectangle(Pens.Red,
                    rec.Left,
                    rec.Top,
                    rec.Width,
                    rec.Height);
            }
        }

        private void tbUser_EditValueChanged(object sender, EventArgs e)
        {
            isUserCorrect = true;
            tbUser.Refresh();
        }

        private void tbPassword_EditValueChanged(object sender, EventArgs e)
        {
            isPassCorrect = true;
            tbPassword.Refresh();
        }

        private void tbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void tbUser_Leave(object sender, EventArgs e)
        {
            tbUser.Text = tbUser.Text.ToUpper();
        }

        private void checkKhachHang_Click(object sender, EventArgs e)
        {
            new Form1("G00", "").Show();
            this.Hide();
        }
    }
}