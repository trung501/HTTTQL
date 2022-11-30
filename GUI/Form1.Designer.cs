namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.container = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem = new DevExpress.XtraBars.BarStaticItem();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceHome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceVaccine1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceVaccine2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLichSu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acePhieuTiem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceThanhToan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceThongKe = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTaoTaiKhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Controls.Add(this.progressPanel);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(270, 37);
            this.container.Margin = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1035, 831);
            this.container.TabIndex = 0;
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.Caption = "Vui lòng đợi";
            this.progressPanel.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressPanel.Description = "Đang tải...";
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.Margin = new System.Windows.Forms.Padding(4);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(1035, 831);
            this.progressPanel.TabIndex = 0;
            this.progressPanel.Text = "progressPanel1";
            this.progressPanel.Visible = false;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDangXuat,
            this.barStaticItem1,
            this.barStaticItem});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1305, 37);
            this.fluentDesignFormControl1.TabIndex = 4;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnDangXuat);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 0;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem
            // 
            this.barStaticItem.Caption = "Xin chào Hưng";
            this.barStaticItem.Id = 3;
            this.barStaticItem.Name = "barStaticItem";
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.AccordionControl.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Disabled.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Hovered.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accordionControl1.Appearance.Item.Hovered.Options.UseFont = true;
            this.accordionControl1.Appearance.Item.Normal.Options.UseFont = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceHome,
            this.aceVaccine1,
            this.aceVaccine2,
            this.aceLichSu,
            this.acePhieuTiem,
            this.aceThanhToan,
            this.aceThongKe,
            this.aceTaoTaiKhoan});
            this.accordionControl1.Location = new System.Drawing.Point(0, 37);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.accordionControl1.MaximumSize = new System.Drawing.Size(270, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Auto;
            this.accordionControl1.Size = new System.Drawing.Size(270, 831);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl1.ElementClick += new DevExpress.XtraBars.Navigation.ElementClickEventHandler(this.accordionControl1_ElementClick);
            // 
            // aceHome
            // 
            this.aceHome.Height = 10;
            this.aceHome.ImageOptions.Image = global::GUI.Properties.Resources.home;
            this.aceHome.Name = "aceHome";
            this.aceHome.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceHome.Text = " Trang chủ";
            this.aceHome.Click += new System.EventHandler(this.aceHome_Click);
            // 
            // aceVaccine1
            // 
            this.aceVaccine1.ImageOptions.Image = global::GUI.Properties.Resources.vaccine;
            this.aceVaccine1.Name = "aceVaccine1";
            this.aceVaccine1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceVaccine1.Text = " Quản lý vaccine";
            this.aceVaccine1.Click += new System.EventHandler(this.aceVaccine_Click);
            // 
            // aceVaccine2
            // 
            this.aceVaccine2.Height = 10;
            this.aceVaccine2.ImageOptions.Image = global::GUI.Properties.Resources.vaccine;
            this.aceVaccine2.Name = "aceVaccine2";
            this.aceVaccine2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceVaccine2.Text = " Quản lý vaccine";
            this.aceVaccine2.Click += new System.EventHandler(this.aceVaccine2_Click);
            // 
            // aceLichSu
            // 
            this.aceLichSu.Height = 10;
            this.aceLichSu.ImageOptions.Image = global::GUI.Properties.Resources.clock;
            this.aceLichSu.Name = "aceLichSu";
            this.aceLichSu.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceLichSu.Text = " Lịch sử tiêm";
            this.aceLichSu.Click += new System.EventHandler(this.aceLichSu_Click);
            // 
            // acePhieuTiem
            // 
            this.acePhieuTiem.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acePhieuTiem.Appearance.Normal.Options.UseFont = true;
            this.acePhieuTiem.ImageOptions.Image = global::GUI.Properties.Resources.add;
            this.acePhieuTiem.Name = "acePhieuTiem";
            this.acePhieuTiem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.acePhieuTiem.Text = " Tạo phiếu tiêm";
            this.acePhieuTiem.Click += new System.EventHandler(this.acePhieuTiem_Click);
            // 
            // aceThanhToan
            // 
            this.aceThanhToan.Height = 10;
            this.aceThanhToan.ImageOptions.Image = global::GUI.Properties.Resources.pay;
            this.aceThanhToan.Name = "aceThanhToan";
            this.aceThanhToan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThanhToan.Text = " Thanh toán";
            this.aceThanhToan.Click += new System.EventHandler(this.aceThanhToan_Click);
            // 
            // aceThongKe
            // 
            this.aceThongKe.ImageOptions.Image = global::GUI.Properties.Resources.statistics;
            this.aceThongKe.Name = "aceThongKe";
            this.aceThongKe.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThongKe.Text = " Thống kê";
            this.aceThongKe.Click += new System.EventHandler(this.aceThongKe_Click);
            // 
            // aceTaoTaiKhoan
            // 
            this.aceTaoTaiKhoan.ImageOptions.Image = global::GUI.Properties.Resources.add;
            this.aceTaoTaiKhoan.Name = "aceTaoTaiKhoan";
            this.aceTaoTaiKhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTaoTaiKhoan.Text = " Tạo tài khoản";
            this.aceTaoTaiKhoan.Click += new System.EventHandler(this.aceTaoTaiKhoan_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(202, 125);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(185, 56);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(201, 180);
            this.toggleSwitch1.Margin = new System.Windows.Forms.Padding(6);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(186, 25);
            this.toggleSwitch1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 868);
            this.ControlContainer = this.container;
            this.Controls.Add(this.container);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Form1.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(1236, 820);
            this.Name = "Form1";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer container;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceThanhToan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLichSu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceVaccine1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePhieuTiem;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
          private DevExpress.XtraBars.Navigation.AccordionControlElement aceThongKe;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHome;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceVaccine2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTaoTaiKhoan;
    }
}

