#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmSachTruyen
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
            this.grpTim = new System.Windows.Forms.GroupBox();
            this.lblTimTen = new System.Windows.Forms.Label();
            this.txtTimTen = new System.Windows.Forms.TextBox();
            this.lblTimLV = new System.Windows.Forms.Label();
            this.cboTimLinhVuc = new System.Windows.Forms.ComboBox();
            this.lblTimTG = new System.Windows.Forms.Label();
            this.cboTimTacGia = new System.Windows.Forms.ComboBox();
            this.lblTimNXB = new System.Windows.Forms.Label();
            this.cboTimNXB = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHuyLoc = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblLinhVuc = new System.Windows.Forms.Label();
            this.cboLinhVuc = new System.Windows.Forms.ComboBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.cboTacGia = new System.Windows.Forms.ComboBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.lblNgonNgu = new System.Windows.Forms.Label();
            this.cboNgonNgu = new System.Windows.Forms.ComboBox();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblSoTrang = new System.Windows.Forms.Label();
            this.nudSoTrang = new System.Windows.Forms.NumericUpDown();
            this.lblGiaSach = new System.Windows.Forms.Label();
            this.nudGiaSach = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaThue = new System.Windows.Forms.Label();
            this.nudDonGiaThue = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblAnh = new System.Windows.Forms.Label();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            this.grpTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaThue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTim
            // 
            this.grpTim.Controls.Add(this.lblTimTen);
            this.grpTim.Controls.Add(this.txtTimTen);
            this.grpTim.Controls.Add(this.lblTimLV);
            this.grpTim.Controls.Add(this.cboTimLinhVuc);
            this.grpTim.Controls.Add(this.lblTimTG);
            this.grpTim.Controls.Add(this.cboTimTacGia);
            this.grpTim.Controls.Add(this.lblTimNXB);
            this.grpTim.Controls.Add(this.cboTimNXB);
            this.grpTim.Controls.Add(this.btnTim);
            this.grpTim.Controls.Add(this.btnHuyLoc);
            this.grpTim.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTim.Location = new System.Drawing.Point(0, 0);
            this.grpTim.Name = "grpTim";
            this.grpTim.Size = new System.Drawing.Size(1000, 70);
            this.grpTim.TabIndex = 0;
            this.grpTim.TabStop = false;
            this.grpTim.Text = "Tìm kiếm";
            // 
            // lblTimTen
            // 
            this.lblTimTen.AutoSize = true;
            this.lblTimTen.Location = new System.Drawing.Point(12, 31);
            this.lblTimTen.Name = "lblTimTen";
            this.lblTimTen.Size = new System.Drawing.Size(55, 15);
            this.lblTimTen.TabIndex = 0;
            this.lblTimTen.Text = "Tên sách";
            // 
            // txtTimTen
            // 
            this.txtTimTen.Location = new System.Drawing.Point(75, 28);
            this.txtTimTen.Name = "txtTimTen";
            this.txtTimTen.Size = new System.Drawing.Size(150, 23);
            this.txtTimTen.TabIndex = 1;
            this.txtTimTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimTen_KeyDown);
            // 
            // lblTimLV
            // 
            this.lblTimLV.AutoSize = true;
            this.lblTimLV.Location = new System.Drawing.Point(240, 31);
            this.lblTimLV.Name = "lblTimLV";
            this.lblTimLV.Size = new System.Drawing.Size(51, 15);
            this.lblTimLV.TabIndex = 2;
            this.lblTimLV.Text = "Lĩnh vực";
            // 
            // cboTimLinhVuc
            // 
            this.cboTimLinhVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimLinhVuc.Location = new System.Drawing.Point(300, 28);
            this.cboTimLinhVuc.Name = "cboTimLinhVuc";
            this.cboTimLinhVuc.Size = new System.Drawing.Size(130, 23);
            this.cboTimLinhVuc.TabIndex = 3;
            // 
            // lblTimTG
            // 
            this.lblTimTG.AutoSize = true;
            this.lblTimTG.Location = new System.Drawing.Point(445, 31);
            this.lblTimTG.Name = "lblTimTG";
            this.lblTimTG.Size = new System.Drawing.Size(42, 15);
            this.lblTimTG.TabIndex = 4;
            this.lblTimTG.Text = "Tác giả";
            // 
            // cboTimTacGia
            // 
            this.cboTimTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTacGia.Location = new System.Drawing.Point(495, 28);
            this.cboTimTacGia.Name = "cboTimTacGia";
            this.cboTimTacGia.Size = new System.Drawing.Size(130, 23);
            this.cboTimTacGia.TabIndex = 5;
            // 
            // lblTimNXB
            // 
            this.lblTimNXB.AutoSize = true;
            this.lblTimNXB.Location = new System.Drawing.Point(640, 31);
            this.lblTimNXB.Name = "lblTimNXB";
            this.lblTimNXB.Size = new System.Drawing.Size(30, 15);
            this.lblTimNXB.TabIndex = 6;
            this.lblTimNXB.Text = "NXB";
            // 
            // cboTimNXB
            // 
            this.cboTimNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimNXB.Location = new System.Drawing.Point(675, 28);
            this.cboTimNXB.Name = "cboTimNXB";
            this.cboTimNXB.Size = new System.Drawing.Size(130, 23);
            this.cboTimNXB.TabIndex = 7;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(820, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(70, 27);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnHuyLoc
            // 
            this.btnHuyLoc.Location = new System.Drawing.Point(895, 26);
            this.btnHuyLoc.Name = "btnHuyLoc";
            this.btnHuyLoc.Size = new System.Drawing.Size(85, 27);
            this.btnHuyLoc.TabIndex = 9;
            this.btnHuyLoc.Text = "Hủy lọc";
            this.btnHuyLoc.UseVisualStyleBackColor = true;
            this.btnHuyLoc.Click += new System.EventHandler(this.btnHuyLoc_Click);
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 70);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1000, 340);
            this.dgv.TabIndex = 1;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.lblMa);
            this.grpChiTiet.Controls.Add(this.txtMa);
            this.grpChiTiet.Controls.Add(this.lblTen);
            this.grpChiTiet.Controls.Add(this.txtTen);
            this.grpChiTiet.Controls.Add(this.lblLoai);
            this.grpChiTiet.Controls.Add(this.cboLoai);
            this.grpChiTiet.Controls.Add(this.lblLinhVuc);
            this.grpChiTiet.Controls.Add(this.cboLinhVuc);
            this.grpChiTiet.Controls.Add(this.lblTacGia);
            this.grpChiTiet.Controls.Add(this.cboTacGia);
            this.grpChiTiet.Controls.Add(this.lblNXB);
            this.grpChiTiet.Controls.Add(this.cboNXB);
            this.grpChiTiet.Controls.Add(this.lblNgonNgu);
            this.grpChiTiet.Controls.Add(this.cboNgonNgu);
            this.grpChiTiet.Controls.Add(this.lblTinhTrang);
            this.grpChiTiet.Controls.Add(this.cboTinhTrang);
            this.grpChiTiet.Controls.Add(this.lblSoTrang);
            this.grpChiTiet.Controls.Add(this.nudSoTrang);
            this.grpChiTiet.Controls.Add(this.lblGiaSach);
            this.grpChiTiet.Controls.Add(this.nudGiaSach);
            this.grpChiTiet.Controls.Add(this.lblDonGiaThue);
            this.grpChiTiet.Controls.Add(this.nudDonGiaThue);
            this.grpChiTiet.Controls.Add(this.lblSoLuong);
            this.grpChiTiet.Controls.Add(this.nudSoLuong);
            this.grpChiTiet.Controls.Add(this.lblAnh);
            this.grpChiTiet.Controls.Add(this.txtAnh);
            this.grpChiTiet.Controls.Add(this.btnChonAnh);
            this.grpChiTiet.Controls.Add(this.lblGhiChu);
            this.grpChiTiet.Controls.Add(this.txtGhiChu);
            this.grpChiTiet.Controls.Add(this.picAnh);
            this.grpChiTiet.Controls.Add(this.btnThem);
            this.grpChiTiet.Controls.Add(this.btnSua);
            this.grpChiTiet.Controls.Add(this.btnXoa);
            this.grpChiTiet.Controls.Add(this.btnNhapMoi);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpChiTiet.Location = new System.Drawing.Point(0, 410);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(1000, 270);
            this.grpChiTiet.TabIndex = 2;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Thông tin sách truyện";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(12, 28);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(51, 15);
            this.lblMa.TabIndex = 0;
            this.lblMa.Text = "Mã sách";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(105, 25);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(165, 23);
            this.txtMa.TabIndex = 1;
            this.txtMa.TabStop = false;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(290, 28);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(55, 15);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên sách";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(380, 25);
            this.txtTen.MaxLength = 200;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(440, 23);
            this.txtTen.TabIndex = 3;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(12, 61);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(53, 15);
            this.lblLoai.TabIndex = 4;
            this.lblLoai.Text = "Loại sách";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Location = new System.Drawing.Point(105, 58);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(165, 23);
            this.cboLoai.TabIndex = 5;
            // 
            // lblLinhVuc
            // 
            this.lblLinhVuc.AutoSize = true;
            this.lblLinhVuc.Location = new System.Drawing.Point(290, 61);
            this.lblLinhVuc.Name = "lblLinhVuc";
            this.lblLinhVuc.Size = new System.Drawing.Size(51, 15);
            this.lblLinhVuc.TabIndex = 6;
            this.lblLinhVuc.Text = "Lĩnh vực";
            // 
            // cboLinhVuc
            // 
            this.cboLinhVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinhVuc.Location = new System.Drawing.Point(380, 58);
            this.cboLinhVuc.Name = "cboLinhVuc";
            this.cboLinhVuc.Size = new System.Drawing.Size(165, 23);
            this.cboLinhVuc.TabIndex = 7;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(565, 61);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(42, 15);
            this.lblTacGia.TabIndex = 8;
            this.lblTacGia.Text = "Tác giả";
            // 
            // cboTacGia
            // 
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.Location = new System.Drawing.Point(655, 58);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(165, 23);
            this.cboTacGia.TabIndex = 9;
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(12, 94);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(30, 15);
            this.lblNXB.TabIndex = 10;
            this.lblNXB.Text = "NXB";
            // 
            // cboNXB
            // 
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.Location = new System.Drawing.Point(105, 91);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(165, 23);
            this.cboNXB.TabIndex = 11;
            // 
            // lblNgonNgu
            // 
            this.lblNgonNgu.AutoSize = true;
            this.lblNgonNgu.Location = new System.Drawing.Point(290, 94);
            this.lblNgonNgu.Name = "lblNgonNgu";
            this.lblNgonNgu.Size = new System.Drawing.Size(55, 15);
            this.lblNgonNgu.TabIndex = 12;
            this.lblNgonNgu.Text = "Ngôn ngữ";
            // 
            // cboNgonNgu
            // 
            this.cboNgonNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNgonNgu.Location = new System.Drawing.Point(380, 91);
            this.cboNgonNgu.Name = "cboNgonNgu";
            this.cboNgonNgu.Size = new System.Drawing.Size(165, 23);
            this.cboNgonNgu.TabIndex = 13;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new System.Drawing.Point(565, 94);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(57, 15);
            this.lblTinhTrang.TabIndex = 14;
            this.lblTinhTrang.Text = "Tình trạng";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.Location = new System.Drawing.Point(655, 91);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(165, 23);
            this.cboTinhTrang.TabIndex = 15;
            // 
            // lblSoTrang
            // 
            this.lblSoTrang.AutoSize = true;
            this.lblSoTrang.Location = new System.Drawing.Point(12, 127);
            this.lblSoTrang.Name = "lblSoTrang";
            this.lblSoTrang.Size = new System.Drawing.Size(51, 15);
            this.lblSoTrang.TabIndex = 16;
            this.lblSoTrang.Text = "Số trang";
            // 
            // nudSoTrang
            // 
            this.nudSoTrang.Location = new System.Drawing.Point(105, 124);
            this.nudSoTrang.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudSoTrang.Name = "nudSoTrang";
            this.nudSoTrang.Size = new System.Drawing.Size(165, 23);
            this.nudSoTrang.TabIndex = 17;
            // 
            // lblGiaSach
            // 
            this.lblGiaSach.AutoSize = true;
            this.lblGiaSach.Location = new System.Drawing.Point(290, 127);
            this.lblGiaSach.Name = "lblGiaSach";
            this.lblGiaSach.Size = new System.Drawing.Size(51, 15);
            this.lblGiaSach.TabIndex = 18;
            this.lblGiaSach.Text = "Giá sách";
            // 
            // nudGiaSach
            // 
            this.nudGiaSach.Location = new System.Drawing.Point(380, 124);
            this.nudGiaSach.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudGiaSach.Name = "nudGiaSach";
            this.nudGiaSach.Size = new System.Drawing.Size(165, 23);
            this.nudGiaSach.TabIndex = 19;
            this.nudGiaSach.ThousandsSeparator = true;
            // 
            // lblDonGiaThue
            // 
            this.lblDonGiaThue.AutoSize = true;
            this.lblDonGiaThue.Location = new System.Drawing.Point(565, 127);
            this.lblDonGiaThue.Name = "lblDonGiaThue";
            this.lblDonGiaThue.Size = new System.Drawing.Size(73, 15);
            this.lblDonGiaThue.TabIndex = 20;
            this.lblDonGiaThue.Text = "Đơn giá thuê";
            // 
            // nudDonGiaThue
            // 
            this.nudDonGiaThue.Location = new System.Drawing.Point(655, 124);
            this.nudDonGiaThue.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudDonGiaThue.Name = "nudDonGiaThue";
            this.nudDonGiaThue.Size = new System.Drawing.Size(165, 23);
            this.nudDonGiaThue.TabIndex = 21;
            this.nudDonGiaThue.ThousandsSeparator = true;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(12, 160);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(54, 15);
            this.lblSoLuong.TabIndex = 22;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(105, 157);
            this.nudSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(165, 23);
            this.nudSoLuong.TabIndex = 23;
            // 
            // lblAnh
            // 
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(290, 160);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(26, 15);
            this.lblAnh.TabIndex = 24;
            this.lblAnh.Text = "Ảnh";
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(380, 157);
            this.txtAnh.MaxLength = 255;
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.ReadOnly = true;
            this.txtAnh.Size = new System.Drawing.Size(385, 23);
            this.txtAnh.TabIndex = 25;
            this.txtAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(770, 156);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(50, 25);
            this.btnChonAnh.TabIndex = 26;
            this.btnChonAnh.Text = "...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(12, 193);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(45, 15);
            this.lblGhiChu.TabIndex = 27;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(105, 190);
            this.txtGhiChu.MaxLength = 500;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(715, 23);
            this.txtGhiChu.TabIndex = 28;
            // 
            // picAnh
            // 
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(845, 25);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(130, 175);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabIndex = 29;
            this.picAnh.TabStop = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(105, 227);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(205, 227);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(305, 227);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(405, 227);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(90, 32);
            this.btnNhapMoi.TabIndex = 33;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // frmSachTruyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.grpTim);
            this.MinimumSize = new System.Drawing.Size(1016, 600);
            this.Name = "frmSachTruyen";
            this.Text = "Quản lý sách truyện";
            this.Load += new System.EventHandler(this.frmSachTruyen_Load);
            this.grpTim.ResumeLayout(false);
            this.grpTim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaThue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTim;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.TextBox txtTimTen;
        private System.Windows.Forms.Label lblTimLV;
        private System.Windows.Forms.ComboBox cboTimLinhVuc;
        private System.Windows.Forms.Label lblTimTG;
        private System.Windows.Forms.ComboBox cboTimTacGia;
        private System.Windows.Forms.Label lblTimNXB;
        private System.Windows.Forms.ComboBox cboTimNXB;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnHuyLoc;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblLinhVuc;
        private System.Windows.Forms.ComboBox cboLinhVuc;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.ComboBox cboTacGia;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label lblNgonNgu;
        private System.Windows.Forms.ComboBox cboNgonNgu;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Label lblSoTrang;
        private System.Windows.Forms.NumericUpDown nudSoTrang;
        private System.Windows.Forms.Label lblGiaSach;
        private System.Windows.Forms.NumericUpDown nudGiaSach;
        private System.Windows.Forms.Label lblDonGiaThue;
        private System.Windows.Forms.NumericUpDown nudDonGiaThue;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNhapMoi;
    }
}
