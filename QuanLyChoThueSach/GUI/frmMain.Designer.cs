#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSachTruyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNXB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLinhVuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoaiSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNgonNgu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTinhTrang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaLam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThueSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuNghiepVu,
            this.mnuBaoCao});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(130, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(130, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSachTruyen,
            this.mnuNhanVien,
            this.mnuKhachHang,
            this.toolStripSeparator1,
            this.mnuTacGia,
            this.mnuNXB,
            this.mnuLinhVuc,
            this.mnuLoaiSach,
            this.mnuNgonNgu,
            this.mnuTinhTrang,
            this.mnuCaLam,
            this.mnuViPham});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(70, 20);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuSachTruyen
            // 
            this.mnuSachTruyen.Name = "mnuSachTruyen";
            this.mnuSachTruyen.Size = new System.Drawing.Size(180, 22);
            this.mnuSachTruyen.Text = "Sách truyện";
            this.mnuSachTruyen.Click += new System.EventHandler(this.mnuSachTruyen_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(180, 22);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(180, 22);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuTacGia
            // 
            this.mnuTacGia.Name = "mnuTacGia";
            this.mnuTacGia.Size = new System.Drawing.Size(180, 22);
            this.mnuTacGia.Text = "Tác giả";
            this.mnuTacGia.Click += new System.EventHandler(this.mnuTacGia_Click);
            // 
            // mnuNXB
            // 
            this.mnuNXB.Name = "mnuNXB";
            this.mnuNXB.Size = new System.Drawing.Size(180, 22);
            this.mnuNXB.Text = "Nhà xuất bản";
            this.mnuNXB.Click += new System.EventHandler(this.mnuNXB_Click);
            // 
            // mnuLinhVuc
            // 
            this.mnuLinhVuc.Name = "mnuLinhVuc";
            this.mnuLinhVuc.Size = new System.Drawing.Size(180, 22);
            this.mnuLinhVuc.Text = "Lĩnh vực";
            this.mnuLinhVuc.Click += new System.EventHandler(this.mnuLinhVuc_Click);
            // 
            // mnuLoaiSach
            // 
            this.mnuLoaiSach.Name = "mnuLoaiSach";
            this.mnuLoaiSach.Size = new System.Drawing.Size(180, 22);
            this.mnuLoaiSach.Text = "Loại sách";
            this.mnuLoaiSach.Click += new System.EventHandler(this.mnuLoaiSach_Click);
            // 
            // mnuNgonNgu
            // 
            this.mnuNgonNgu.Name = "mnuNgonNgu";
            this.mnuNgonNgu.Size = new System.Drawing.Size(180, 22);
            this.mnuNgonNgu.Text = "Ngôn ngữ";
            this.mnuNgonNgu.Click += new System.EventHandler(this.mnuNgonNgu_Click);
            // 
            // mnuTinhTrang
            // 
            this.mnuTinhTrang.Name = "mnuTinhTrang";
            this.mnuTinhTrang.Size = new System.Drawing.Size(180, 22);
            this.mnuTinhTrang.Text = "Tình trạng";
            this.mnuTinhTrang.Click += new System.EventHandler(this.mnuTinhTrang_Click);
            // 
            // mnuCaLam
            // 
            this.mnuCaLam.Name = "mnuCaLam";
            this.mnuCaLam.Size = new System.Drawing.Size(180, 22);
            this.mnuCaLam.Text = "Ca làm";
            this.mnuCaLam.Click += new System.EventHandler(this.mnuCaLam_Click);
            // 
            // mnuViPham
            // 
            this.mnuViPham.Name = "mnuViPham";
            this.mnuViPham.Size = new System.Drawing.Size(180, 22);
            this.mnuViPham.Text = "Vi phạm";
            this.mnuViPham.Click += new System.EventHandler(this.mnuViPham_Click);
            // 
            // mnuNghiepVu
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThueSach,
            this.mnuTraSach});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new System.Drawing.Size(67, 20);
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuThueSach
            // 
            this.mnuThueSach.Name = "mnuThueSach";
            this.mnuThueSach.Size = new System.Drawing.Size(130, 22);
            this.mnuThueSach.Text = "Thuê sách";
            this.mnuThueSach.Click += new System.EventHandler(this.mnuThueSach_Click);
            // 
            // mnuTraSach
            // 
            this.mnuTraSach.Name = "mnuTraSach";
            this.mnuTraSach.Size = new System.Drawing.Size(130, 22);
            this.mnuTraSach.Text = "Trả sách";
            this.mnuTraSach.Click += new System.EventHandler(this.mnuTraSach_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(61, 20);
            this.mnuBaoCao.Text = "Báo cáo";
            this.mnuBaoCao.Click += new System.EventHandler(this.mnuBaoCao_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(80, 17);
            this.lblNguoiDung.Text = "Người dùng: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng cho thuê sách truyện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuSachTruyen;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTacGia;
        private System.Windows.Forms.ToolStripMenuItem mnuNXB;
        private System.Windows.Forms.ToolStripMenuItem mnuLinhVuc;
        private System.Windows.Forms.ToolStripMenuItem mnuLoaiSach;
        private System.Windows.Forms.ToolStripMenuItem mnuNgonNgu;
        private System.Windows.Forms.ToolStripMenuItem mnuTinhTrang;
        private System.Windows.Forms.ToolStripMenuItem mnuCaLam;
        private System.Windows.Forms.ToolStripMenuItem mnuViPham;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuThueSach;
        private System.Windows.Forms.ToolStripMenuItem mnuTraSach;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
    }
}
