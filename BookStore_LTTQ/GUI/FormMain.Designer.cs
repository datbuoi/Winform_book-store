namespace BookStore_LTTQ.GUI
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusLabelTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelCSDL = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxNav = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.btnThueSach = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnSach = new System.Windows.Forms.Button();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.groupBoxNav.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 85);
            this.panelHeader.TabIndex = 1;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.lblSubTitle.Location = new System.Drawing.Point(320, 50);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(340, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "HỌC PHẦN: BÀI TẬP LỚN LẬP TRÌNH TRỰC QUAN";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(145, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(764, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelTrangThai,
            this.statusLabelCSDL});
            this.statusStripMain.Location = new System.Drawing.Point(0, 589);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(984, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // statusLabelTrangThai
            // 
            this.statusLabelTrangThai.Name = "statusLabelTrangThai";
            this.statusLabelTrangThai.Size = new System.Drawing.Size(110, 17);
            this.statusLabelTrangThai.Text = "Hệ thống: Sẵn sàng";
            // 
            // statusLabelCSDL
            // 
            this.statusLabelCSDL.Name = "statusLabelCSDL";
            this.statusLabelCSDL.Size = new System.Drawing.Size(185, 17);
            this.statusLabelCSDL.Text = " | CSDL: QLChoThueSach (Online)";
            // 
            // groupBoxNav
            // 
            this.groupBoxNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.groupBoxNav.Controls.Add(this.btnThoat);
            this.groupBoxNav.Controls.Add(this.btnBaoCao);
            this.groupBoxNav.Controls.Add(this.btnTraSach);
            this.groupBoxNav.Controls.Add(this.btnThueSach);
            this.groupBoxNav.Controls.Add(this.btnNhanVien);
            this.groupBoxNav.Controls.Add(this.btnSach);
            this.groupBoxNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxNav.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxNav.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.groupBoxNav.Location = new System.Drawing.Point(0, 85);
            this.groupBoxNav.Name = "groupBoxNav";
            this.groupBoxNav.Size = new System.Drawing.Size(250, 504);
            this.groupBoxNav.TabIndex = 3;
            this.groupBoxNav.TabStop = false;
            this.groupBoxNav.Text = "Chức năng hệ thống";
            this.groupBoxNav.Enter += new System.EventHandler(this.groupBoxNav_Enter);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(15, 395);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(220, 48);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát ứng dụng";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(15, 320);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(220, 52);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "Báo cáo & Thống kê\r\n(Yêu cầu 7, 8, 9)";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnTraSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(15, 245);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(220, 52);
            this.btnTraSach.TabIndex = 3;
            this.btnTraSach.Text = "Quản lý Trả Sách\r\n(Yêu cầu 2, 3, 4)";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnThueSach
            // 
            this.btnThueSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnThueSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThueSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThueSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThueSach.ForeColor = System.Drawing.Color.White;
            this.btnThueSach.Location = new System.Drawing.Point(15, 170);
            this.btnThueSach.Name = "btnThueSach";
            this.btnThueSach.Size = new System.Drawing.Size(220, 52);
            this.btnThueSach.TabIndex = 2;
            this.btnThueSach.Text = "Quản lý Thuê Sách\r\n(Yêu cầu 1, 2)";
            this.btnThueSach.UseVisualStyleBackColor = false;
            this.btnThueSach.Click += new System.EventHandler(this.btnThueSach_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Location = new System.Drawing.Point(15, 100);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(220, 50);
            this.btnNhanVien.TabIndex = 1;
            this.btnNhanVien.Text = "Quản lý Nhân Viên\r\n(Yêu cầu 6)";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnSach
            // 
            this.btnSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSach.ForeColor = System.Drawing.Color.White;
            this.btnSach.Location = new System.Drawing.Point(15, 30);
            this.btnSach.Name = "btnSach";
            this.btnSach.Size = new System.Drawing.Size(220, 50);
            this.btnSach.TabIndex = 0;
            this.btnSach.Text = "Quản lý Sách Truyện\r\n(Yêu cầu 5)";
            this.btnSach.UseVisualStyleBackColor = false;
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelCenter.Controls.Add(this.lblMoTa);
            this.panelCenter.Controls.Add(this.lblChaoMung);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(250, 85);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(734, 504);
            this.panelCenter.TabIndex = 4;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMoTa.Location = new System.Drawing.Point(40, 90);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(650, 320);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = resources.GetString("lblMoTa.Text");
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.AutoSize = true;
            this.lblChaoMung.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChaoMung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChaoMung.Location = new System.Drawing.Point(38, 35);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(427, 30);
            this.lblChaoMung.TabIndex = 0;
            this.lblChaoMung.Text = "Chào mừng bạn đến với Cửa hàng Sách!";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.groupBoxNav);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Cửa hàng Cho Thuê Sách Truyện";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.groupBoxNav.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelCSDL;
        private System.Windows.Forms.GroupBox groupBoxNav;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnThueSach;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblChaoMung;
    }
}
