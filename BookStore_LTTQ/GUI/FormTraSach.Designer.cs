namespace BookStore_LTTQ.GUI
{
    partial class FormTraSach
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
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.txtNgayThue = new System.Windows.Forms.TextBox();
            this.lblNgayThue = new System.Windows.Forms.Label();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboMaThue = new System.Windows.Forms.ComboBox();
            this.lblMaThue = new System.Windows.Forms.Label();
            this.txtMaTra = new System.Windows.Forms.TextBox();
            this.lblMaTra = new System.Windows.Forms.Label();
            this.grpChiTietTra = new System.Windows.Forms.GroupBox();
            this.btnThemSachTra = new System.Windows.Forms.Button();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.txtTienPhat = new System.Windows.Forms.TextBox();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.cboViPham = new System.Windows.Forms.ComboBox();
            this.lblViPham = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtSoNgayThue = new System.Windows.Forms.TextBox();
            this.lblSoNgayThue = new System.Windows.Forms.Label();
            this.cboSachTra = new System.Windows.Forms.ComboBox();
            this.lblSachTra = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTietTra = new System.Windows.Forms.DataGridView();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoaDongTra = new System.Windows.Forms.Button();
            this.btnLuuPhieuTra = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpThongTinPhieu.SuspendLayout();
            this.grpChiTietTra.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTra)).BeginInit();
            this.panelChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1034, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(400, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(235, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LẬP PHIẾU TRẢ SÁCH";
            // 
            // grpThongTinPhieu
            // 
            this.grpThongTinPhieu.Controls.Add(this.txtTongTien);
            this.grpThongTinPhieu.Controls.Add(this.lblTongTien);
            this.grpThongTinPhieu.Controls.Add(this.cboNhanVien);
            this.grpThongTinPhieu.Controls.Add(this.lblNhanVien);
            this.grpThongTinPhieu.Controls.Add(this.dtpNgayTra);
            this.grpThongTinPhieu.Controls.Add(this.lblNgayTra);
            this.grpThongTinPhieu.Controls.Add(this.txtNgayThue);
            this.grpThongTinPhieu.Controls.Add(this.lblNgayThue);
            this.grpThongTinPhieu.Controls.Add(this.txtKhachHang);
            this.grpThongTinPhieu.Controls.Add(this.lblKhachHang);
            this.grpThongTinPhieu.Controls.Add(this.cboMaThue);
            this.grpThongTinPhieu.Controls.Add(this.lblMaThue);
            this.grpThongTinPhieu.Controls.Add(this.txtMaTra);
            this.grpThongTinPhieu.Controls.Add(this.lblMaTra);
            this.grpThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinPhieu.Location = new System.Drawing.Point(0, 55);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.Size = new System.Drawing.Size(1034, 115);
            this.grpThongTinPhieu.TabIndex = 1;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "Thông tin phiếu trả";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.txtTongTien.Location = new System.Drawing.Point(860, 68);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(155, 27);
            this.txtTongTien.TabIndex = 13;
            this.txtTongTien.Text = "0 đ";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(785, 73);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(72, 17);
            this.lblTongTien.TabIndex = 12;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(585, 68);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 25);
            this.cboNhanVien.TabIndex = 11;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(510, 71);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(69, 17);
            this.lblNhanVien.TabIndex = 10;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTra.Location = new System.Drawing.Point(860, 28);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(155, 25);
            this.dtpNgayTra.TabIndex = 9;
            this.dtpNgayTra.ValueChanged += new System.EventHandler(this.dtpNgayTra_ValueChanged);
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(785, 31);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(61, 17);
            this.lblNgayTra.TabIndex = 8;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // txtNgayThue
            // 
            this.txtNgayThue.Location = new System.Drawing.Point(585, 28);
            this.txtNgayThue.Name = "txtNgayThue";
            this.txtNgayThue.ReadOnly = true;
            this.txtNgayThue.Size = new System.Drawing.Size(180, 25);
            this.txtNgayThue.TabIndex = 7;
            // 
            // lblNgayThue
            // 
            this.lblNgayThue.AutoSize = true;
            this.lblNgayThue.Location = new System.Drawing.Point(510, 31);
            this.lblNgayThue.Name = "lblNgayThue";
            this.lblNgayThue.Size = new System.Drawing.Size(72, 17);
            this.lblNgayThue.TabIndex = 6;
            this.lblNgayThue.Text = "Ngày thuê:";
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Location = new System.Drawing.Point(320, 68);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.ReadOnly = true;
            this.txtKhachHang.Size = new System.Drawing.Size(170, 25);
            this.txtKhachHang.TabIndex = 5;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(240, 71);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(79, 17);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cboMaThue
            // 
            this.cboMaThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaThue.FormattingEnabled = true;
            this.cboMaThue.Location = new System.Drawing.Point(320, 28);
            this.cboMaThue.Name = "cboMaThue";
            this.cboMaThue.Size = new System.Drawing.Size(170, 25);
            this.cboMaThue.TabIndex = 3;
            this.cboMaThue.SelectedIndexChanged += new System.EventHandler(this.cboMaThue_SelectedIndexChanged);
            // 
            // lblMaThue
            // 
            this.lblMaThue.AutoSize = true;
            this.lblMaThue.Location = new System.Drawing.Point(240, 31);
            this.lblMaThue.Name = "lblMaThue";
            this.lblMaThue.Size = new System.Drawing.Size(61, 17);
            this.lblMaThue.TabIndex = 2;
            this.lblMaThue.Text = "Mã thuê:";
            // 
            // txtMaTra
            // 
            this.txtMaTra.Location = new System.Drawing.Point(75, 28);
            this.txtMaTra.Name = "txtMaTra";
            this.txtMaTra.ReadOnly = true;
            this.txtMaTra.Size = new System.Drawing.Size(145, 25);
            this.txtMaTra.TabIndex = 1;
            // 
            // lblMaTra
            // 
            this.lblMaTra.AutoSize = true;
            this.lblMaTra.Location = new System.Drawing.Point(15, 31);
            this.lblMaTra.Name = "lblMaTra";
            this.lblMaTra.Size = new System.Drawing.Size(50, 17);
            this.lblMaTra.TabIndex = 0;
            this.lblMaTra.Text = "Mã trả:";
            // 
            // grpChiTietTra
            // 
            this.grpChiTietTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.grpChiTietTra.Controls.Add(this.btnThemSachTra);
            this.grpChiTietTra.Controls.Add(this.txtThanhTien);
            this.grpChiTietTra.Controls.Add(this.lblThanhTien);
            this.grpChiTietTra.Controls.Add(this.txtTienPhat);
            this.grpChiTietTra.Controls.Add(this.lblTienPhat);
            this.grpChiTietTra.Controls.Add(this.cboViPham);
            this.grpChiTietTra.Controls.Add(this.lblViPham);
            this.grpChiTietTra.Controls.Add(this.txtDonGia);
            this.grpChiTietTra.Controls.Add(this.lblDonGia);
            this.grpChiTietTra.Controls.Add(this.txtSoNgayThue);
            this.grpChiTietTra.Controls.Add(this.lblSoNgayThue);
            this.grpChiTietTra.Controls.Add(this.cboSachTra);
            this.grpChiTietTra.Controls.Add(this.lblSachTra);
            this.grpChiTietTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChiTietTra.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.grpChiTietTra.Location = new System.Drawing.Point(0, 170);
            this.grpChiTietTra.Name = "grpChiTietTra";
            this.grpChiTietTra.Size = new System.Drawing.Size(1034, 115);
            this.grpChiTietTra.TabIndex = 2;
            this.grpChiTietTra.TabStop = false;
            this.grpChiTietTra.Text = "Chọn sách trả & Tính tiền (Yêu cầu 3: Sách chưa trả | Yêu cầu 4: Đơn giá * Ngày + Phạt)";
            // 
            // btnThemSachTra
            // 
            this.btnThemSachTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnThemSachTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSachTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSachTra.ForeColor = System.Drawing.Color.White;
            this.btnThemSachTra.Location = new System.Drawing.Point(860, 68);
            this.btnThemSachTra.Name = "btnThemSachTra";
            this.btnThemSachTra.Size = new System.Drawing.Size(155, 35);
            this.btnThemSachTra.TabIndex = 12;
            this.btnThemSachTra.Text = "Trả sách này";
            this.btnThemSachTra.UseVisualStyleBackColor = false;
            this.btnThemSachTra.Click += new System.EventHandler(this.btnThemSachTra_Click);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.BackColor = System.Drawing.Color.White;
            this.txtThanhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.txtThanhTien.Location = new System.Drawing.Point(660, 73);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(180, 25);
            this.txtThanhTien.TabIndex = 11;
            this.txtThanhTien.Text = "0 đ";
            this.txtThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(580, 76);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(76, 17);
            this.lblThanhTien.TabIndex = 10;
            this.lblThanhTien.Text = "Thành tiền:";
            // 
            // txtTienPhat
            // 
            this.txtTienPhat.Location = new System.Drawing.Point(445, 73);
            this.txtTienPhat.Name = "txtTienPhat";
            this.txtTienPhat.ReadOnly = true;
            this.txtTienPhat.Size = new System.Drawing.Size(115, 25);
            this.txtTienPhat.TabIndex = 9;
            this.txtTienPhat.Text = "0";
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(375, 76);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(66, 17);
            this.lblTienPhat.TabIndex = 8;
            this.lblTienPhat.Text = "Tiền phạt:";
            // 
            // cboViPham
            // 
            this.cboViPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViPham.FormattingEnabled = true;
            this.cboViPham.Location = new System.Drawing.Point(95, 73);
            this.cboViPham.Name = "cboViPham";
            this.cboViPham.Size = new System.Drawing.Size(260, 25);
            this.cboViPham.TabIndex = 7;
            this.cboViPham.SelectedIndexChanged += new System.EventHandler(this.cboViPham_SelectedIndexChanged);
            // 
            // lblViPham
            // 
            this.lblViPham.AutoSize = true;
            this.lblViPham.Location = new System.Drawing.Point(15, 76);
            this.lblViPham.Name = "lblViPham";
            this.lblViPham.Size = new System.Drawing.Size(60, 17);
            this.lblViPham.TabIndex = 6;
            this.lblViPham.Text = "Vi phạm:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(660, 30);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(180, 25);
            this.txtDonGia.TabIndex = 5;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(580, 33);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(59, 17);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtSoNgayThue
            // 
            this.txtSoNgayThue.Location = new System.Drawing.Point(445, 30);
            this.txtSoNgayThue.Name = "txtSoNgayThue";
            this.txtSoNgayThue.ReadOnly = true;
            this.txtSoNgayThue.Size = new System.Drawing.Size(115, 25);
            this.txtSoNgayThue.TabIndex = 3;
            // 
            // lblSoNgayThue
            // 
            this.lblSoNgayThue.AutoSize = true;
            this.lblSoNgayThue.Location = new System.Drawing.Point(375, 33);
            this.lblSoNgayThue.Name = "lblSoNgayThue";
            this.lblSoNgayThue.Size = new System.Drawing.Size(67, 17);
            this.lblSoNgayThue.TabIndex = 2;
            this.lblSoNgayThue.Text = "Số ngày T:";
            // 
            // cboSachTra
            // 
            this.cboSachTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSachTra.FormattingEnabled = true;
            this.cboSachTra.Location = new System.Drawing.Point(95, 30);
            this.cboSachTra.Name = "cboSachTra";
            this.cboSachTra.Size = new System.Drawing.Size(260, 25);
            this.cboSachTra.TabIndex = 1;
            this.cboSachTra.SelectedIndexChanged += new System.EventHandler(this.cboSachTra_SelectedIndexChanged);
            // 
            // lblSachTra
            // 
            this.lblSachTra.AutoSize = true;
            this.lblSachTra.Location = new System.Drawing.Point(15, 33);
            this.lblSachTra.Name = "lblSachTra";
            this.lblSachTra.Size = new System.Drawing.Size(61, 17);
            this.lblSachTra.TabIndex = 0;
            this.lblSachTra.Text = "Sách trả:";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.grpDanhSach);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 285);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1034, 271);
            this.panelCenter.TabIndex = 3;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvChiTietTra);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Location = new System.Drawing.Point(0, 0);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1034, 271);
            this.grpDanhSach.TabIndex = 0;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách chi tiết trả sách trong phiếu này";
            // 
            // dgvChiTietTra
            // 
            this.dgvChiTietTra.AllowUserToAddRows = false;
            this.dgvChiTietTra.AllowUserToDeleteRows = false;
            this.dgvChiTietTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietTra.Location = new System.Drawing.Point(3, 21);
            this.dgvChiTietTra.MultiSelect = false;
            this.dgvChiTietTra.Name = "dgvChiTietTra";
            this.dgvChiTietTra.ReadOnly = true;
            this.dgvChiTietTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietTra.Size = new System.Drawing.Size(1028, 247);
            this.dgvChiTietTra.TabIndex = 0;
            // 
            // panelChucNang
            // 
            this.panelChucNang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelChucNang.Controls.Add(this.btnDong);
            this.panelChucNang.Controls.Add(this.btnXoaDongTra);
            this.panelChucNang.Controls.Add(this.btnLuuPhieuTra);
            this.panelChucNang.Controls.Add(this.btnTaoMoi);
            this.panelChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelChucNang.Location = new System.Drawing.Point(0, 556);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(1034, 55);
            this.panelChucNang.TabIndex = 4;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(790, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 35);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoaDongTra
            // 
            this.btnXoaDongTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.btnXoaDongTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDongTra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaDongTra.ForeColor = System.Drawing.Color.White;
            this.btnXoaDongTra.Location = new System.Drawing.Point(560, 10);
            this.btnXoaDongTra.Name = "btnXoaDongTra";
            this.btnXoaDongTra.Size = new System.Drawing.Size(170, 35);
            this.btnXoaDongTra.TabIndex = 2;
            this.btnXoaDongTra.Text = "Hủy dòng trả";
            this.btnXoaDongTra.UseVisualStyleBackColor = false;
            this.btnXoaDongTra.Click += new System.EventHandler(this.btnXoaDongTra_Click);
            // 
            // btnLuuPhieuTra
            // 
            this.btnLuuPhieuTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnLuuPhieuTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhieuTra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieuTra.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieuTra.Location = new System.Drawing.Point(330, 10);
            this.btnLuuPhieuTra.Name = "btnLuuPhieuTra";
            this.btnLuuPhieuTra.Size = new System.Drawing.Size(170, 35);
            this.btnLuuPhieuTra.TabIndex = 1;
            this.btnLuuPhieuTra.Text = "Lưu phiếu trả sách";
            this.btnLuuPhieuTra.UseVisualStyleBackColor = false;
            this.btnLuuPhieuTra.Click += new System.EventHandler(this.btnLuuPhieuTra_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTaoMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoMoi.Location = new System.Drawing.Point(100, 10);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(170, 35);
            this.btnTaoMoi.TabIndex = 0;
            this.btnTaoMoi.Text = "Lập phiếu mới";
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // FormTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 611);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelChucNang);
            this.Controls.Add(this.grpChiTietTra);
            this.Controls.Add(this.grpThongTinPhieu);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "FormTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Trả Sách";
            this.Load += new System.EventHandler(this.FormTraSach_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpThongTinPhieu.ResumeLayout(false);
            this.grpThongTinPhieu.PerformLayout();
            this.grpChiTietTra.ResumeLayout(false);
            this.grpChiTietTra.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietTra)).EndInit();
            this.panelChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.Label lblMaTra;
        private System.Windows.Forms.TextBox txtMaTra;
        private System.Windows.Forms.Label lblMaThue;
        private System.Windows.Forms.ComboBox cboMaThue;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.Label lblNgayThue;
        private System.Windows.Forms.TextBox txtNgayThue;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.GroupBox grpChiTietTra;
        private System.Windows.Forms.Label lblSachTra;
        private System.Windows.Forms.ComboBox cboSachTra;
        private System.Windows.Forms.Label lblSoNgayThue;
        private System.Windows.Forms.TextBox txtSoNgayThue;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblViPham;
        private System.Windows.Forms.ComboBox cboViPham;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.TextBox txtTienPhat;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnThemSachTra;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvChiTietTra;
        private System.Windows.Forms.Panel panelChucNang;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnLuuPhieuTra;
        private System.Windows.Forms.Button btnXoaDongTra;
        private System.Windows.Forms.Button btnDong;
    }
}
