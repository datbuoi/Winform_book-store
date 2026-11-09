#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmNhanVien
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
            this.components = new System.ComponentModel.Container();
            this.grpTim = new System.Windows.Forms.GroupBox();
            this.lblTimTen = new System.Windows.Forms.Label();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.lblTimCa = new System.Windows.Forms.Label();
            this.cboTimCa = new System.Windows.Forms.ComboBox();
            this.lblTimGT = new System.Windows.Forms.Label();
            this.cboTimGioiTinh = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHuyLoc = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.nudNamSinh = new System.Windows.Forms.NumericUpDown();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.nudLuong = new System.Windows.Forms.NumericUpDown();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNamSinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTim
            // 
            this.grpTim.Controls.Add(this.lblTimTen);
            this.grpTim.Controls.Add(this.txtTimTen);
            this.grpTim.Controls.Add(this.lblTimCa);
            this.grpTim.Controls.Add(this.cboTimCa);
            this.grpTim.Controls.Add(this.lblTimGT);
            this.grpTim.Controls.Add(this.cboTimGioiTinh);
            this.grpTim.Controls.Add(this.btnTim);
            this.grpTim.Controls.Add(this.btnHuyLoc);
            this.grpTim.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTim.Location = new System.Drawing.Point(0, 0);
            this.grpTim.Name = "grpTim";
            this.grpTim.Size = new System.Drawing.Size(900, 70);
            this.grpTim.TabIndex = 0;
            this.grpTim.TabStop = false;
            this.grpTim.Text = "Tìm kiếm";
            // 
            // lblTimTen
            // 
            this.lblTimTen.AutoSize = true;
            this.lblTimTen.Location = new System.Drawing.Point(12, 31);
            this.lblTimTen.Name = "lblTimTen";
            this.lblTimTen.Size = new System.Drawing.Size(85, 15);
            this.lblTimTen.TabIndex = 0;
            this.lblTimTen.Text = "Tên nhân viên";
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(105, 28);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(170, 23);
            this.txtTimTen.TabIndex = 1;
            this.txtTimTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimTen_KeyDown);
            // 
            // lblTimCa
            // 
            this.lblTimCa.AutoSize = true;
            this.lblTimCa.Location = new System.Drawing.Point(295, 31);
            this.lblTimCa.Name = "lblTimCa";
            this.lblTimCa.Size = new System.Drawing.Size(40, 15);
            this.lblTimCa.TabIndex = 2;
            this.lblTimCa.Text = "Ca làm";
            this.toolTip1.SetToolTip(this.lblTimCa, "Tìm nhân viên đã lập phiếu thuê trong ca được chọn");
            // 
            // cboTimCa
            // 
            this.cboTimCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimCa.Location = new System.Drawing.Point(345, 28);
            this.cboTimCa.Name = "cboTimCa";
            this.cboTimCa.Size = new System.Drawing.Size(130, 23);
            this.cboTimCa.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cboTimCa, "Tìm nhân viên đã lập phiếu thuê trong ca được chọn");
            // 
            // lblTimGT
            // 
            this.lblTimGT.AutoSize = true;
            this.lblTimGT.Location = new System.Drawing.Point(490, 31);
            this.lblTimGT.Name = "lblTimGT";
            this.lblTimGT.Size = new System.Drawing.Size(52, 15);
            this.lblTimGT.TabIndex = 4;
            this.lblTimGT.Text = "Giới tính";
            // 
            // cboTimGioiTinh
            // 
            this.cboTimGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimGioiTinh.Items.AddRange(new object[] {
            "(Tất cả)",
            "Nam",
            "Nữ",
            "Khác"});
            this.cboTimGioiTinh.Location = new System.Drawing.Point(550, 28);
            this.cboTimGioiTinh.Name = "cboTimGioiTinh";
            this.cboTimGioiTinh.Size = new System.Drawing.Size(100, 23);
            this.cboTimGioiTinh.TabIndex = 5;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(670, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(70, 27);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnHuyLoc
            // 
            this.btnHuyLoc.Location = new System.Drawing.Point(745, 26);
            this.btnHuyLoc.Name = "btnHuyLoc";
            this.btnHuyLoc.Size = new System.Drawing.Size(85, 27);
            this.btnHuyLoc.TabIndex = 7;
            this.btnHuyLoc.Text = "Hủy lọc";
            this.btnHuyLoc.UseVisualStyleBackColor = true;
            this.btnHuyLoc.Click += new System.EventHandler(this.btnHuyLoc_Click);
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 70);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(900, 355);
            this.dgv.TabIndex = 1;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.lblMa);
            this.grpChiTiet.Controls.Add(this.txtMa);
            this.grpChiTiet.Controls.Add(this.lblTen);
            this.grpChiTiet.Controls.Add(this.txtTen);
            this.grpChiTiet.Controls.Add(this.lblGioiTinh);
            this.grpChiTiet.Controls.Add(this.cboGioiTinh);
            this.grpChiTiet.Controls.Add(this.lblNamSinh);
            this.grpChiTiet.Controls.Add(this.nudNamSinh);
            this.grpChiTiet.Controls.Add(this.lblDienThoai);
            this.grpChiTiet.Controls.Add(this.txtDienThoai);
            this.grpChiTiet.Controls.Add(this.lblLuong);
            this.grpChiTiet.Controls.Add(this.nudLuong);
            this.grpChiTiet.Controls.Add(this.lblDiaChi);
            this.grpChiTiet.Controls.Add(this.txtDiaChi);
            this.grpChiTiet.Controls.Add(this.btnThem);
            this.grpChiTiet.Controls.Add(this.btnSua);
            this.grpChiTiet.Controls.Add(this.btnXoa);
            this.grpChiTiet.Controls.Add(this.btnNhapMoi);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpChiTiet.Location = new System.Drawing.Point(0, 425);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(900, 175);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Thông tin nhân viên";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(12, 28);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(42, 15);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã NV";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(100, 25);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(160, 23);
            this.txtMa.TabIndex = 1;
            this.txtMa.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(285, 28);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(85, 15);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên nhân viên";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(375, 25);
            this.txtTen.MaxLength = 100;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(160, 23);
            this.txtTen.TabIndex = 3;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(560, 28);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(52, 15);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinh.Location = new System.Drawing.Point(640, 25);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(160, 23);
            this.cboGioiTinh.TabIndex = 5;
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.Location = new System.Drawing.Point(12, 61);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(55, 15);
            this.lblNamSinh.TabIndex = 6;
            this.lblNamSinh.Text = "Năm sinh";
            // 
            // nudNamSinh
            // 
            this.nudNamSinh.Location = new System.Drawing.Point(100, 58);
            this.nudNamSinh.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.nudNamSinh.Name = "nudNamSinh";
            this.nudNamSinh.Size = new System.Drawing.Size(160, 23);
            this.nudNamSinh.TabIndex = 7;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(285, 61);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(60, 15);
            this.lblDienThoai.TabIndex = 8;
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(375, 58);
            this.txtDienThoai.MaxLength = 15;
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(160, 23);
            this.txtDienThoai.TabIndex = 9;
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(560, 61);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(72, 15);
            this.lblLuong.TabIndex = 10;
            this.lblLuong.Text = "Lương tháng";
            // 
            // nudLuong
            // 
            this.nudLuong.Location = new System.Drawing.Point(650, 58);
            this.nudLuong.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudLuong.Name = "nudLuong";
            this.nudLuong.Size = new System.Drawing.Size(150, 23);
            this.nudLuong.TabIndex = 11;
            this.nudLuong.ThousandsSeparator = true;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(12, 94);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(44, 15);
            this.lblDiaChi.TabIndex = 12;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(100, 91);
            this.txtDiaChi.MaxLength = 255;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(700, 23);
            this.txtDiaChi.TabIndex = 13;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(100, 130);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(200, 130);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(300, 130);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(400, 130);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(90, 32);
            this.btnNhapMoi.TabIndex = 17;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpTim);
            this.MinimumSize = new System.Drawing.Size(916, 500);
            this.Name = "frmNhanVien";
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.grpTim.ResumeLayout(false);
            this.grpTim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNamSinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTim;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.Label lblTimCa;
        private System.Windows.Forms.ComboBox cboTimCa;
        private System.Windows.Forms.Label lblTimGT;
        private System.Windows.Forms.ComboBox cboTimGioiTinh;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnHuyLoc;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.NumericUpDown nudNamSinh;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.NumericUpDown nudLuong;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNhapMoi;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
