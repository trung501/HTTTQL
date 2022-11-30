
namespace GUI
{
    partial class ListLVC
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbNewLVC = new System.Windows.Forms.Label();
            this.tbTenLVC = new DevExpress.XtraEditors.TextEdit();
            this.tbMaLVC = new DevExpress.XtraEditors.TextEdit();
            this.lbTenLVC = new DevExpress.XtraEditors.LabelControl();
            this.lbMaLVC = new DevExpress.XtraEditors.LabelControl();
            this.btnXoaLVC = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemLVC = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridListVC = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenLVC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaLVC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListVC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.lbNewLVC);
            this.panelControl1.Controls.Add(this.tbTenLVC);
            this.panelControl1.Controls.Add(this.tbMaLVC);
            this.panelControl1.Controls.Add(this.lbTenLVC);
            this.panelControl1.Controls.Add(this.lbMaLVC);
            this.panelControl1.Controls.Add(this.btnXoaLVC);
            this.panelControl1.Controls.Add(this.btnThemLVC);
            this.panelControl1.Location = new System.Drawing.Point(2, 13);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(586, 111);
            this.panelControl1.TabIndex = 0;
            // 
            // lbNewLVC
            // 
            this.lbNewLVC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbNewLVC.AutoSize = true;
            this.lbNewLVC.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lbNewLVC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbNewLVC.Location = new System.Drawing.Point(130, 47);
            this.lbNewLVC.Name = "lbNewLVC";
            this.lbNewLVC.Size = new System.Drawing.Size(192, 14);
            this.lbNewLVC.TabIndex = 34;
            this.lbNewLVC.Text = "* Để trống nếu là loại vaccine mới";
            this.lbNewLVC.Visible = false;
            // 
            // tbTenLVC
            // 
            this.tbTenLVC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTenLVC.Location = new System.Drawing.Point(133, 68);
            this.tbTenLVC.Name = "tbTenLVC";
            this.tbTenLVC.Size = new System.Drawing.Size(208, 24);
            this.tbTenLVC.TabIndex = 25;
            // 
            // tbMaLVC
            // 
            this.tbMaLVC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMaLVC.Location = new System.Drawing.Point(133, 22);
            this.tbMaLVC.Name = "tbMaLVC";
            this.tbMaLVC.Size = new System.Drawing.Size(208, 24);
            this.tbMaLVC.TabIndex = 25;
            this.tbMaLVC.Click += new System.EventHandler(this.tbMaLVC_Click);
            this.tbMaLVC.Leave += new System.EventHandler(this.tbMaLVC_Leave);
            // 
            // lbTenLVC
            // 
            this.lbTenLVC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTenLVC.Location = new System.Drawing.Point(22, 71);
            this.lbTenLVC.Name = "lbTenLVC";
            this.lbTenLVC.Size = new System.Drawing.Size(104, 18);
            this.lbTenLVC.TabIndex = 26;
            this.lbTenLVC.Text = "Tên loại vaccine";
            // 
            // lbMaLVC
            // 
            this.lbMaLVC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbMaLVC.Location = new System.Drawing.Point(22, 25);
            this.lbMaLVC.Name = "lbMaLVC";
            this.lbMaLVC.Size = new System.Drawing.Size(98, 18);
            this.lbMaLVC.TabIndex = 26;
            this.lbMaLVC.Text = "Mã loại vaccine";
            // 
            // btnXoaLVC
            // 
            this.btnXoaLVC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaLVC.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btnXoaLVC.Appearance.Options.UseBackColor = true;
            this.btnXoaLVC.Location = new System.Drawing.Point(362, 59);
            this.btnXoaLVC.Name = "btnXoaLVC";
            this.btnXoaLVC.Size = new System.Drawing.Size(177, 41);
            this.btnXoaLVC.TabIndex = 0;
            this.btnXoaLVC.Text = "Xóa loại Vaccine";
            this.btnXoaLVC.Click += new System.EventHandler(this.btnXoaLVC_Click);
            // 
            // btnThemLVC
            // 
            this.btnThemLVC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemLVC.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnThemLVC.Appearance.Options.UseBackColor = true;
            this.btnThemLVC.Location = new System.Drawing.Point(362, 10);
            this.btnThemLVC.Name = "btnThemLVC";
            this.btnThemLVC.Size = new System.Drawing.Size(177, 41);
            this.btnThemLVC.TabIndex = 0;
            this.btnThemLVC.Text = "Thêm loại Vaccine";
            this.btnThemLVC.Click += new System.EventHandler(this.btnThemLVC_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.gridListVC);
            this.panelControl2.Location = new System.Drawing.Point(7, 130);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(586, 571);
            this.panelControl2.TabIndex = 1;
            // 
            // gridListVC
            // 
            this.gridListVC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListVC.Location = new System.Drawing.Point(0, 0);
            this.gridListVC.MainView = this.gridView1;
            this.gridListVC.Name = "gridListVC";
            this.gridListVC.Size = new System.Drawing.Size(586, 571);
            this.gridListVC.TabIndex = 0;
            this.gridListVC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridListVC;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // ListLVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 713);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Location = new System.Drawing.Point(800, 400);
            this.Name = "ListLVC";
            this.Text = "Cập nhật loại vaccine";
            this.Leave += new System.EventHandler(this.ListLVC_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTenLVC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaLVC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListVC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridListVC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnXoaLVC;
        private DevExpress.XtraEditors.SimpleButton btnThemLVC;
        private DevExpress.XtraEditors.TextEdit tbTenLVC;
        private DevExpress.XtraEditors.TextEdit tbMaLVC;
        private DevExpress.XtraEditors.LabelControl lbTenLVC;
        private DevExpress.XtraEditors.LabelControl lbMaLVC;
        private System.Windows.Forms.Label lbNewLVC;
    }
}