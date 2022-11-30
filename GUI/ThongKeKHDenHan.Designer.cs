
namespace GUI
{
    partial class ThongKeKHDenHan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEmailSelect = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnXuat = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditCuoi = new DevExpress.XtraEditors.DateEdit();
            this.dateEditDau = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridKH = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCuoi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCuoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEmailSelect);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnXuat);
            this.panelControl1.Controls.Add(this.dateEditCuoi);
            this.panelControl1.Controls.Add(this.dateEditDau);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 715);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1062, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // btnEmailSelect
            // 
            this.btnEmailSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEmailSelect.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnEmailSelect.Appearance.Options.UseBackColor = true;
            this.btnEmailSelect.Location = new System.Drawing.Point(769, 6);
            this.btnEmailSelect.Name = "btnEmailSelect";
            this.btnEmailSelect.Size = new System.Drawing.Size(117, 28);
            this.btnEmailSelect.TabIndex = 1;
            this.btnEmailSelect.Text = "Gửi Email";
            this.btnEmailSelect.Click += new System.EventHandler(this.btnEmailSelect_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(30, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 18);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Hạn tiêm từ";
            // 
            // btnXuat
            // 
            this.btnXuat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuat.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnXuat.Appearance.Options.UseBackColor = true;
            this.btnXuat.Location = new System.Drawing.Point(899, 6);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(125, 28);
            this.btnXuat.TabIndex = 1;
            this.btnXuat.Text = "Xuất danh sách";
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // dateEditCuoi
            // 
            this.dateEditCuoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEditCuoi.EditValue = null;
            this.dateEditCuoi.Location = new System.Drawing.Point(323, 10);
            this.dateEditCuoi.Name = "dateEditCuoi";
            this.dateEditCuoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditCuoi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditCuoi.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateEditCuoi.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditCuoi.Size = new System.Drawing.Size(172, 24);
            this.dateEditCuoi.TabIndex = 8;
            this.dateEditCuoi.EditValueChanged += new System.EventHandler(this.dateEditCuoi_EditValueChanged);
            // 
            // dateEditDau
            // 
            this.dateEditDau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateEditDau.EditValue = null;
            this.dateEditDau.Location = new System.Drawing.Point(114, 10);
            this.dateEditDau.Name = "dateEditDau";
            this.dateEditDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDau.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateEditDau.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditDau.Size = new System.Drawing.Size(172, 24);
            this.dateEditDau.TabIndex = 7;
            this.dateEditDau.EditValueChanged += new System.EventHandler(this.dateEditDau_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Location = new System.Drawing.Point(292, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 18);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "đến";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridKH);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1062, 715);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Thống kê khách hàng đến thời gian tiêm";
            // 
            // gridKH
            // 
            this.gridKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKH.Location = new System.Drawing.Point(5, 36);
            this.gridKH.MainView = this.gridView1;
            this.gridKH.Name = "gridKH";
            this.gridKH.Size = new System.Drawing.Size(1052, 673);
            this.gridKH.TabIndex = 11;
            this.gridKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridKH;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 100;
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập để tìm kiếm...";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ThongKeKHDenHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ThongKeKHDenHan";
            this.Size = new System.Drawing.Size(1062, 762);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCuoi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCuoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnXuat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.DateEdit dateEditCuoi;
        public DevExpress.XtraEditors.DateEdit dateEditDau;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnEmailSelect;
        private DevExpress.XtraGrid.GridControl gridKH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
