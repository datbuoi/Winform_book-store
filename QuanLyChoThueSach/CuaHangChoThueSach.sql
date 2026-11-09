/* =====================================================================
   CSDL: Quản lý cửa hàng cho thuê sách truyện (SQL Server)
   Chạy toàn bộ script trong SSMS / Azure Data Studio.
   Cảnh báo: script xóa các bảng cùng tên nếu đã tồn tại.
   ===================================================================== */

IF DB_ID(N'QuanLyChoThueSach') IS NULL
    CREATE DATABASE QuanLyChoThueSach;
GO
USE QuanLyChoThueSach;
GO
SET QUOTED_IDENTIFIER ON;   -- cần cho filtered index (sqlcmd mặc định là OFF)
GO

/* ---------- Xóa bảng cũ (con trước, cha sau) ---------- */
DROP TABLE IF EXISTS ChiTietTraSach;
DROP TABLE IF EXISTS TraSach;
DROP TABLE IF EXISTS ChiTietThueSach;
DROP TABLE IF EXISTS ThueSach;
DROP TABLE IF EXISTS TaiKhoan;
DROP TABLE IF EXISTS SachTruyen;
DROP TABLE IF EXISTS ViPham;
DROP TABLE IF EXISTS NhanVien;
DROP TABLE IF EXISTS CaLam;
DROP TABLE IF EXISTS KhachHang;
DROP TABLE IF EXISTS TacGia;
DROP TABLE IF EXISTS NXB;
DROP TABLE IF EXISTS NgonNgu;
DROP TABLE IF EXISTS LoaiSach;
DROP TABLE IF EXISTS TinhTrang;
DROP TABLE IF EXISTS LinhVuc;
GO

/* =====================================================================
   BẢNG DANH MỤC
   ===================================================================== */
CREATE TABLE LinhVuc (
    MaLinhVuc   INT IDENTITY(1,1) CONSTRAINT PK_LinhVuc PRIMARY KEY,
    TenLinhVuc  NVARCHAR(100) NOT NULL
);

CREATE TABLE LoaiSach (
    MaLoaiSach  INT IDENTITY(1,1) CONSTRAINT PK_LoaiSach PRIMARY KEY,
    TenLoai     NVARCHAR(100) NOT NULL          -- Mới, cũ, ...
);

CREATE TABLE TinhTrang (
    MaTinhTrang  INT IDENTITY(1,1) CONSTRAINT PK_TinhTrang PRIMARY KEY,
    TenTinhTrang NVARCHAR(100) NOT NULL
);

CREATE TABLE NgonNgu (
    MaNgonNgu   INT IDENTITY(1,1) CONSTRAINT PK_NgonNgu PRIMARY KEY,
    TenNgonNgu  NVARCHAR(100) NOT NULL
);

CREATE TABLE NXB (
    MaNXB       INT IDENTITY(1,1) CONSTRAINT PK_NXB PRIMARY KEY,
    TenNXB      NVARCHAR(150) NOT NULL,
    DiaChi      NVARCHAR(255) NULL,
    DienThoai   VARCHAR(15)   NULL
);

CREATE TABLE TacGia (
    MaTG        INT IDENTITY(1,1) CONSTRAINT PK_TacGia PRIMARY KEY,
    TenTG       NVARCHAR(100) NOT NULL,
    NgaySinh    DATE NULL,
    GioiTinh    NVARCHAR(5) NULL CONSTRAINT CK_TacGia_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi      NVARCHAR(255) NULL
);

CREATE TABLE ViPham (
    MaViPham    INT IDENTITY(1,1) CONSTRAINT PK_ViPham PRIMARY KEY,
    TenViPham   NVARCHAR(150) NOT NULL,
    TienPhat    DECIMAL(12,0) NOT NULL CONSTRAINT CK_ViPham_TienPhat CHECK (TienPhat >= 0)
);

CREATE TABLE CaLam (
    MaCa        INT IDENTITY(1,1) CONSTRAINT PK_CaLam PRIMARY KEY,
    TenCa       NVARCHAR(50) NOT NULL
);

/* =====================================================================
   NHÂN VIÊN, KHÁCH HÀNG
   ===================================================================== */
CREATE TABLE NhanVien (
    MaNV        INT IDENTITY(1,1) CONSTRAINT PK_NhanVien PRIMARY KEY,
    TenNV       NVARCHAR(100) NOT NULL,
    NamSinh     INT NULL CONSTRAINT CK_NhanVien_NamSinh CHECK (NamSinh BETWEEN 1900 AND 2100),
    GioiTinh    NVARCHAR(5) NULL CONSTRAINT CK_NhanVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi      NVARCHAR(255) NULL,
    DienThoai   VARCHAR(15) NULL,
    LuongThang  DECIMAL(12,0) NULL CONSTRAINT CK_NhanVien_Luong CHECK (LuongThang >= 0)
);

CREATE TABLE KhachHang (
    MaKhach     INT IDENTITY(1,1) CONSTRAINT PK_KhachHang PRIMARY KEY,
    TenKhach    NVARCHAR(100) NOT NULL,
    NgaySinh    DATE NULL,
    GioiTinh    NVARCHAR(5) NULL CONSTRAINT CK_KhachHang_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi      NVARCHAR(255) NULL
);

/* =====================================================================
   TÀI KHOẢN ĐĂNG NHẬP (bảng bổ sung, không có trong tài liệu)
   - MatKhauHash: mã băm của (Salt + mật khẩu), không lưu mật khẩu gốc.
   - Salt: chuỗi ngẫu nhiên riêng cho từng tài khoản.
   - MaNV: nhân viên sở hữu tài khoản (để biết ai đang đăng nhập khi lập phiếu).
   ===================================================================== */
CREATE TABLE TaiKhoan (
    MaTK         INT IDENTITY(1,1) CONSTRAINT PK_TaiKhoan PRIMARY KEY,
    TenDangNhap  VARCHAR(50)  NOT NULL CONSTRAINT UQ_TaiKhoan_TenDangNhap UNIQUE,
    MatKhauHash  VARCHAR(255) NOT NULL,
    Salt         VARCHAR(64)  NULL,
    MaNV         INT NULL,
    TrangThai    BIT NOT NULL CONSTRAINT DF_TaiKhoan_TrangThai DEFAULT (1),   -- 1: hoạt động, 0: khóa
    NgayTao      DATETIME2(0) NOT NULL CONSTRAINT DF_TaiKhoan_NgayTao DEFAULT (SYSDATETIME()),
    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
-- Mỗi nhân viên có tối đa 1 tài khoản
CREATE UNIQUE INDEX UX_TaiKhoan_MaNV ON TaiKhoan(MaNV) WHERE MaNV IS NOT NULL;

/* =====================================================================
   SÁCH TRUYỆN
   ===================================================================== */
CREATE TABLE SachTruyen (
    MaSach       INT IDENTITY(1,1) CONSTRAINT PK_SachTruyen PRIMARY KEY,
    TenSach      NVARCHAR(200) NOT NULL,
    MaLoaiSach   INT NOT NULL,
    MaLinhVuc    INT NOT NULL,
    MaTG         INT NOT NULL,
    MaNXB        INT NOT NULL,
    MaNgonNgu    INT NOT NULL,
    SoTrang      INT NULL CONSTRAINT CK_SachTruyen_SoTrang CHECK (SoTrang > 0),
    GiaSach      DECIMAL(12,0) NOT NULL CONSTRAINT CK_SachTruyen_GiaSach CHECK (GiaSach >= 0),
    DonGiaThue   DECIMAL(12,0) NOT NULL CONSTRAINT CK_SachTruyen_DonGiaThue CHECK (DonGiaThue >= 0),
    MaTinhTrang  INT NOT NULL,
    SoLuong      INT NOT NULL CONSTRAINT DF_SachTruyen_SoLuong DEFAULT (0) CONSTRAINT CK_SachTruyen_SoLuong CHECK (SoLuong >= 0),
    Anh          NVARCHAR(255) NULL,            -- đường dẫn / tên file ảnh
    GhiChu       NVARCHAR(500) NULL,
    CONSTRAINT FK_SachTruyen_LoaiSach  FOREIGN KEY (MaLoaiSach)  REFERENCES LoaiSach(MaLoaiSach),
    CONSTRAINT FK_SachTruyen_LinhVuc   FOREIGN KEY (MaLinhVuc)   REFERENCES LinhVuc(MaLinhVuc),
    CONSTRAINT FK_SachTruyen_TacGia    FOREIGN KEY (MaTG)        REFERENCES TacGia(MaTG),
    CONSTRAINT FK_SachTruyen_NXB       FOREIGN KEY (MaNXB)       REFERENCES NXB(MaNXB),
    CONSTRAINT FK_SachTruyen_NgonNgu   FOREIGN KEY (MaNgonNgu)   REFERENCES NgonNgu(MaNgonNgu),
    CONSTRAINT FK_SachTruyen_TinhTrang FOREIGN KEY (MaTinhTrang) REFERENCES TinhTrang(MaTinhTrang)
);

/* =====================================================================
   THUÊ SÁCH
   ===================================================================== */
CREATE TABLE ThueSach (
    MaThue      INT IDENTITY(1,1) CONSTRAINT PK_ThueSach PRIMARY KEY,
    MaKhach     INT NOT NULL,
    MaNV        INT NOT NULL,
    MaCa        INT NOT NULL,
    NgayThue    DATE NOT NULL CONSTRAINT DF_ThueSach_NgayThue DEFAULT (CAST(GETDATE() AS DATE)),
    TienDatCoc  DECIMAL(12,0) NOT NULL CONSTRAINT DF_ThueSach_TienDatCoc DEFAULT (0)
                CONSTRAINT CK_ThueSach_TienDatCoc CHECK (TienDatCoc >= 0),
    CONSTRAINT FK_ThueSach_KhachHang FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach),
    CONSTRAINT FK_ThueSach_NhanVien  FOREIGN KEY (MaNV)    REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_ThueSach_CaLam     FOREIGN KEY (MaCa)    REFERENCES CaLam(MaCa)
);

CREATE TABLE ChiTietThueSach (
    MaThue      INT NOT NULL,
    MaSach      INT NOT NULL,
    SoLuong     INT NOT NULL CONSTRAINT CK_CTThue_SoLuong CHECK (SoLuong > 0),
    DaTra       BIT NOT NULL CONSTRAINT DF_CTThue_DaTra DEFAULT (0),   -- 0: chưa trả, 1: đã trả
    CONSTRAINT PK_ChiTietThueSach PRIMARY KEY (MaThue, MaSach),
    CONSTRAINT FK_CTThue_ThueSach FOREIGN KEY (MaThue) REFERENCES ThueSach(MaThue) ON DELETE CASCADE,
    CONSTRAINT FK_CTThue_Sach     FOREIGN KEY (MaSach) REFERENCES SachTruyen(MaSach)
);

/* =====================================================================
   TRẢ SÁCH
   ===================================================================== */
CREATE TABLE TraSach (
    MaTra       INT IDENTITY(1,1) CONSTRAINT PK_TraSach PRIMARY KEY,
    MaThue      INT NOT NULL,
    MaNV        INT NOT NULL,
    NgayTra     DATE NOT NULL CONSTRAINT DF_TraSach_NgayTra DEFAULT (CAST(GETDATE() AS DATE)),
    TongTien    DECIMAL(12,0) NOT NULL CONSTRAINT DF_TraSach_TongTien DEFAULT (0)
                CONSTRAINT CK_TraSach_TongTien CHECK (TongTien >= 0),
    CONSTRAINT FK_TraSach_ThueSach FOREIGN KEY (MaThue) REFERENCES ThueSach(MaThue),
    CONSTRAINT FK_TraSach_NhanVien FOREIGN KEY (MaNV)   REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietTraSach (
    MaTra       INT NOT NULL,
    MaSach      INT NOT NULL,
    MaViPham    INT NULL,                       -- NULL: không vi phạm
    ThanhTien   DECIMAL(12,0) NOT NULL CONSTRAINT DF_CTTra_ThanhTien DEFAULT (0)
                CONSTRAINT CK_CTTra_ThanhTien CHECK (ThanhTien >= 0),
    CONSTRAINT PK_ChiTietTraSach PRIMARY KEY (MaTra, MaSach),
    CONSTRAINT FK_CTTra_TraSach FOREIGN KEY (MaTra)     REFERENCES TraSach(MaTra) ON DELETE CASCADE,
    CONSTRAINT FK_CTTra_Sach    FOREIGN KEY (MaSach)    REFERENCES SachTruyen(MaSach),
    CONSTRAINT FK_CTTra_ViPham  FOREIGN KEY (MaViPham)  REFERENCES ViPham(MaViPham)
);
GO

/* ---------- Chỉ mục hỗ trợ tìm kiếm / báo cáo ---------- */
CREATE INDEX IX_SachTruyen_TenSach  ON SachTruyen(TenSach);
CREATE INDEX IX_NhanVien_TenNV      ON NhanVien(TenNV);
CREATE INDEX IX_ThueSach_NgayThue   ON ThueSach(NgayThue);
CREATE INDEX IX_TraSach_NgayTra     ON TraSach(NgayTra);
CREATE INDEX IX_TraSach_MaThue      ON TraSach(MaThue);
GO

/* =====================================================================
   DỮ LIỆU MẪU
   ===================================================================== */
INSERT INTO LinhVuc (TenLinhVuc)   VALUES (N'Văn học'), (N'Khoa học'), (N'Thiếu nhi'), (N'Kỹ năng sống');
INSERT INTO LoaiSach (TenLoai)     VALUES (N'Mới'), (N'Cũ');
INSERT INTO TinhTrang (TenTinhTrang) VALUES (N'Còn tốt'), (N'Rách nhẹ'), (N'Hỏng');
INSERT INTO NgonNgu (TenNgonNgu)   VALUES (N'Tiếng Việt'), (N'Tiếng Anh');
INSERT INTO NXB (TenNXB, DiaChi, DienThoai) VALUES
    (N'NXB Trẻ', N'TP. Hồ Chí Minh', '0283930000'),
    (N'NXB Tổng hợp TP.HCM', N'TP. Hồ Chí Minh', '0283822000');
INSERT INTO TacGia (TenTG, NgaySinh, GioiTinh, DiaChi) VALUES
    (N'Nguyễn Nhật Ánh', '1955-05-07', N'Nam', N'Quảng Nam'),
    (N'Dale Carnegie',   '1888-11-24', N'Nam', N'Missouri, Mỹ');
INSERT INTO ViPham (TenViPham, TienPhat) VALUES
    (N'Trả trễ hạn', 5000),
    (N'Rách sách',   20000),
    (N'Mất sách',    100000);
INSERT INTO CaLam (TenCa) VALUES (N'Ca sáng'), (N'Ca chiều'), (N'Ca tối');
INSERT INTO NhanVien (TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang) VALUES
    (N'Nguyễn Văn An', 1998, N'Nam', N'Hà Nội', '0900000001', 7000000),
    (N'Lê Thị Hoa',    2000, N'Nữ',  N'Hà Nội', '0900000003', 6500000);
INSERT INTO KhachHang (TenKhach, NgaySinh, GioiTinh, DiaChi) VALUES
    (N'Trần Thị Bình', '2001-03-15', N'Nữ',  N'Hà Nội'),
    (N'Phạm Minh Cường', '1999-09-02', N'Nam', N'Hà Nội');
INSERT INTO SachTruyen (TenSach, MaLoaiSach, MaLinhVuc, MaTG, MaNXB, MaNgonNgu, SoTrang, GiaSach, DonGiaThue, MaTinhTrang, SoLuong, Anh, GhiChu) VALUES
    (N'Cho tôi xin một vé đi tuổi thơ', 1, 3, 1, 1, 1, 208, 80000, 3000, 1, 5, NULL, NULL),
    (N'Đắc nhân tâm',                   2, 4, 2, 2, 1, 320, 90000, 4000, 1, 3, NULL, NULL);

/* ---------- Tài khoản mẫu ----------
   Mật khẩu: admin123 (nv_an), nhanvien123 (nv_hoa)
   Hash = SHA2_256(Salt + MatKhau), viết hoa hex. Salt ngẫu nhiên cho từng tài khoản. */
DECLARE @salt1 VARCHAR(32) = CONVERT(VARCHAR(32), CRYPT_GEN_RANDOM(16), 2);
DECLARE @salt2 VARCHAR(32) = CONVERT(VARCHAR(32), CRYPT_GEN_RANDOM(16), 2);

INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, Salt, MaNV) VALUES
    ('nv_an',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @salt1 + 'admin123'),    2), @salt1, 1),
    ('nv_hoa', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @salt2 + 'nhanvien123'), 2), @salt2, 2);
GO

/* ---------- Kiểm tra đăng nhập mẫu (trả về 1 dòng nếu đúng) ----------
DECLARE @user VARCHAR(50) = 'nv_an', @pass VARCHAR(100) = 'admin123';
SELECT MaTK, MaNV
FROM TaiKhoan
WHERE TenDangNhap = @user
  AND TrangThai = 1
  AND MatKhauHash = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', Salt + @pass), 2);
*/
