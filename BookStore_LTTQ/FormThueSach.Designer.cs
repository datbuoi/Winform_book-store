namespace BookStore_LTTQ
{
    partial class FormThueSach
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpThongTinPhieu = new System.Windows.Forms.GroupBox();
            this.numTienDatCoc = new System.Windows.Forms.NumericUpDown();
            this.lblTienDatCoc = new System.Windows.Forms.Label();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.lblNgayThue = new System.Windows.Forms.Label();
            this.cboCaLam = new System.Windows.Forms.ComboBox();
            this.lblCaLam = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtMaThue = new System.Windows.Forms.TextBox();
            this.lblMaThue = new System.Windows.Forms.Label();
            this.grpChonSach = new System.Windows.Forms.GroupBox();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.numSoLuongThue = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongThue = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblChonSach = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTietThue = new System.Windows.Forms.DataGridView();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpThongTinPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienDatCoc)).BeginInit();
            this.grpChonSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThue)).BeginInit();
            this.panelCenter.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietThue)).BeginInit();
            this.panelChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(365, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(255, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LẬP PHIẾU THUÊ SÁCH";
            // 
            // grpThongTinPhieu
            // 
            this.grpThongTinPhieu.Controls.Add(this.numTienDatCoc);
            this.grpThongTinPhieu.Controls.Add(this.lblTienDatCoc);
            this.grpThongTinPhieu.Controls.Add(this.dtpNgayThue);
            this.grpThongTinPhieu.Controls.Add(this.lblNgayThue);
            this.grpThongTinPhieu.Controls.Add(this.cboCaLam);
            this.grpThongTinPhieu.Controls.Add(this.lblCaLam);
            this.grpThongTinPhieu.Controls.Add(this.cboNhanVien);
            this.grpThongTinPhieu.Controls.Add(this.lblNhanVien);
            this.grpThongTinPhieu.Controls.Add(this.cboKhachHang);
            this.grpThongTinPhieu.Controls.Add(this.lblKhachHang);
            this.grpThongTinPhieu.Controls.Add(this.txtMaThue);
            this.grpThongTinPhieu.Controls.Add(this.lblMaThue);
            this.grpThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinPhieu.Location = new System.Drawing.Point(0, 55);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.Size = new System.Drawing.Size(984, 115);
            this.grpThongTinPhieu.TabIndex = 1;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "Thông tin phiếu thuê";
            // 
            // numTienDatCoc
            // 
            this.numTienDatCoc.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTienDatCoc.Location = new System.Drawing.Point(750, 70);
            this.numTienDatCoc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTienDatCoc.Name = "numTienDatCoc";
            this.numTienDatCoc.Size = new System.Drawing.Size(200, 25);
            this.numTienDatCoc.TabIndex = 11;
            this.numTienDatCoc.ThousandsSeparator = true;
            // 
            // lblTienDatCoc
            // 
            this.lblTienDatCoc.AutoSize = true;
            this.lblTienDatCoc.Location = new System.Drawing.Point(660, 73);
            this.lblTienDatCoc.Name = "lblTienDatCoc";
            this.lblTienDatCoc.Size = new System.Drawing.Size(83, 17);
            this.lblTienDatCoc.TabIndex = 10;
            this.lblTienDatCoc.Text = "Tiền đặt cọc:";
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThue.Location = new System.Drawing.Point(750, 28);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(200, 25);
            this.dtpNgayThue.TabIndex = 9;
            // 
            // lblNgayThue
            // 
            this.lblNgayThue.AutoSize = true;
            this.lblNgayThue.Location = new System.Drawing.Point(660, 31);
            this.lblNgayThue.Name = "lblNgayThue";
            this.lblNgayThue.Size = new System.Drawing.Size(72, 17);
            this.lblNgayThue.TabIndex = 8;
            this.lblNgayThue.Text = "Ngày thuê:";
            // 
            // cboCaLam
            // 
            this.cboCaLam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaLam.FormattingEnabled = true;
            this.cboCaLam.Location = new System.Drawing.Point(420, 70);
            this.cboCaLam.Name = "cboCaLam";
            this.cboCaLam.Size = new System.Drawing.Size(210, 25);
            this.cboCaLam.TabIndex = 7;
            // 
            // lblCaLam
            // 
            this.lblCaLam.AutoSize = true;
            this.lblCaLam.Location = new System.Drawing.Point(340, 73);
            this.lblCaLam.Name = "lblCaLam";
            this.lblCaLam.Size = new System.Drawing.Size(52, 17);
            this.lblCaLam.TabIndex = 6;
            this.lblCaLam.Text = "Ca làm:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(420, 28);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(210, 25);
            this.cboNhanVien.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(340, 31);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(69, 17);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(100, 70);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(210, 25);
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(20, 73);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(79, 17);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // txtMaThue
            // 
            this.txtMaThue.Location = new System.Drawing.Point(100, 28);
            this.txtMaThue.Name = "txtMaThue";
            this.txtMaThue.ReadOnly = true;
            this.txtMaThue.Size = new System.Drawing.Size(210, 25);
            this.txtMaThue.TabIndex = 1;
            // 
            // lblMaThue
            // 
            this.lblMaThue.AutoSize = true;
            this.lblMaThue.Location = new System.Drawing.Point(20, 31);
            this.lblMaThue.Name = "lblMaThue";
            this.lblMaThue.Size = new System.Drawing.Size(61, 17);
            this.lblMaThue.TabIndex = 0;
            this.lblMaThue.Text = "Mã thuê:";
            // 
            // grpChonSach
            // 
            this.grpChonSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.grpChonSach.Controls.Add(this.btnThemSach);
            this.grpChonSach.Controls.Add(this.numSoLuongThue);
            this.grpChonSach.Controls.Add(this.lblSoLuongThue);
            this.grpChonSach.Controls.Add(this.lblDonGia);
            this.grpChonSach.Controls.Add(this.lblTonKho);
            this.grpChonSach.Controls.Add(this.cboSach);
            this.grpChonSach.Controls.Add(this.lblChonSach);
            this.grpChonSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChonSach.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpChonSach.Location = new System.Drawing.Point(0, 170);
            this.grpChonSach.Name = "grpChonSach";
            this.grpChonSach.Size = new System.Drawing.Size(984, 85);
            this.grpChonSach.TabIndex = 2;
            this.grpChonSach.TabStop = false;
            this.grpChonSach.Text = "Chọn sách thuê (Yêu cầu 1: Chỉ hiển thị sách có số lượng tồn kho > 0)";
            // 
            // btnThemSach
            // 
            this.btnThemSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnThemSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSach.ForeColor = System.Drawing.Color.White;
            this.btnThemSach.Location = new System.Drawing.Point(830, 28);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(130, 35);
            this.btnThemSach.TabIndex = 6;
            this.btnThemSach.Text = "Thêm vào phiếu";
            this.btnThemSach.UseVisualStyleBackColor = false;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // numSoLuongThue
            // 
            this.numSoLuongThue.Location = new System.Drawing.Point(735, 34);
            this.numSoLuongThue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuongThue.Name = "numSoLuongThue";
            this.numSoLuongThue.Size = new System.Drawing.Size(80, 25);
            this.numSoLuongThue.TabIndex = 5;
            this.numSoLuongThue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSoLuongThue
            // 
            this.lblSoLuongThue.AutoSize = true;
            this.lblSoLuongThue.Location = new System.Drawing.Point(670, 37);
            this.lblSoLuongThue.Name = "lblSoLuongThue";
            this.lblSoLuongThue.Size = new System.Drawing.Size(59, 17);
            this.lblSoLuongThue.TabIndex = 4;
            this.lblSoLuongThue.Text = "SL thuê:";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblDonGia.Location = new System.Drawing.Point(505, 37);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(127, 17);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "Đơn giá: 0 đ/ngày";
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblTonKho.Location = new System.Drawing.Point(395, 37);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(79, 17);
            this.lblTonKho.TabIndex = 2;
            this.lblTonKho.Text = "Tồn kho: 0";
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(95, 34);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(280, 25);
            this.cboSach.TabIndex = 1;
            this.cboSach.SelectedIndexChanged += new System.EventHandler(this.cboSach_SelectedIndexChanged);
            // 
            // lblChonSach
            // 
            this.lblChonSach.AutoSize = true;
            this.lblChonSach.Location = new System.Drawing.Point(20, 37);
            this.lblChonSach.Name = "lblChonSach";
            this.lblChonSach.Size = new System.Drawing.Size(75, 17);
            this.lblChonSach.TabIndex = 0;
            this.lblChonSach.Text = "Chọn sách:";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.grpChiTiet);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 255);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(984, 301);
            this.panelCenter.TabIndex = 3;
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.dgvChiTietThue);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Location = new System.Drawing.Point(0, 0);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(984, 301);
            this.grpChiTiet.TabIndex = 0;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Danh sách chi tiết sách trong phiếu thuê";
            // 
            // dgvChiTietThue
            // 
            this.dgvChiTietThue.AllowUserToAddRows = false;
            this.dgvChiTietThue.AllowUserToDeleteRows = false;
            this.dgvChiTietThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietThue.Location = new System.Drawing.Point(3, 21);
            this.dgvChiTietThue.MultiSelect = false;
            this.dgvChiTietThue.Name = "dgvChiTietThue";
            this.dgvChiTietThue.ReadOnly = true;
            this.dgvChiTietThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietThue.Size = new System.Drawing.Size(978, 277);
            this.dgvChiTietThue.TabIndex = 0;
            // 
            // panelChucNang
            // 
            this.panelChucNang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelChucNang.Controls.Add(this.btnDong);
            this.panelChucNang.Controls.Add(this.btnXoaDong);
            this.panelChucNang.Controls.Add(this.btnLuuPhieu);
            this.panelChucNang.Controls.Add(this.btnTaoMoi);
            this.panelChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelChucNang.Location = new System.Drawing.Point(0, 556);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(984, 55);
            this.panelChucNang.TabIndex = 4;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(750, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 35);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(530, 10);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(160, 35);
            this.btnXoaDong.TabIndex = 2;
            this.btnXoaDong.Text = "Xóa sách chọn";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnLuuPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(310, 10);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(160, 35);
            this.btnLuuPhieu.TabIndex = 1;
            this.btnLuuPhieu.Text = "Lưu phiếu thuê";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Location = new System.Drawing.Point(90, 10);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(160, 35);
            this.btnTaoMoi.TabIndex = 0;
            this.btnTaoMoi.Text = "Lập phiếu mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // FormThueSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelChucNang);
            this.Controls.Add(this.grpChonSach);
            this.Controls.Add(this.grpThongTinPhieu);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "FormThueSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Thuê Sách";
            this.Load += new System.EventHandler(this.FormThueSach_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpThongTinPhieu.ResumeLayout(false);
            this.grpThongTinPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienDatCoc)).EndInit();
            this.grpChonSach.ResumeLayout(false);
            this.grpChonSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThue)).EndInit();
            this.panelCenter.ResumeLayout(false);
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietThue)).EndInit();
            this.panelChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.Label lblMaThue;
        private System.Windows.Forms.TextBox txtMaThue;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblCaLam;
        private System.Windows.Forms.ComboBox cboCaLam;
        private System.Windows.Forms.Label lblNgayThue;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label lblTienDatCoc;
        private System.Windows.Forms.NumericUpDown numTienDatCoc;
        private System.Windows.Forms.GroupBox grpChonSach;
        private System.Windows.Forms.Label lblChonSach;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblSoLuongThue;
        private System.Windows.Forms.NumericUpDown numSoLuongThue;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietThue;
        private System.Windows.Forms.Panel panelChucNang;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnDong;
    }
}
