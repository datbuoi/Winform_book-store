-- =========================================================================
-- HỆ THỐNG CƠ SỞ DỮ LIỆU: QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN
-- MÔN HỌC: LẬP TRÌNH TRỰC QUAN (WINFORMS .NET C# + SQL SERVER)
-- TÊN CSDL: QLChoThueSach
-- =========================================================================

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'QLChoThueSach')
BEGIN
    CREATE DATABASE QLChoThueSach;
END
GO

USE QLChoThueSach;
GO

-- =========================================================================
-- 1. TẠO CẤU TRÚC BẢNG (15 BẢNG THEO ĐÚNG ĐỀ BÀI)
-- =========================================================================

-- 1.1. Bảng Lĩnh vực
IF OBJECT_ID('tLinhVuc', 'U') IS NULL
CREATE TABLE tLinhVuc (
    MaLV        CHAR(4)         NOT NULL PRIMARY KEY,
    TenLV       NVARCHAR(100)   NOT NULL
);
GO

-- 1.2. Bảng Loại sách (Mới, cũ...)
IF OBJECT_ID('tLoaiSach', 'U') IS NULL
CREATE TABLE tLoaiSach (
    MaLoai      CHAR(4)         NOT NULL PRIMARY KEY,
    TenLoai     NVARCHAR(100)   NOT NULL
);
GO

-- 1.3. Bảng Tình trạng sách (Mới 100%, Còn tốt, Rách gáy, Cũ...)
IF OBJECT_ID('tTinhTrang', 'U') IS NULL
CREATE TABLE tTinhTrang (
    MaTT        CHAR(4)         NOT NULL PRIMARY KEY,
    TenTT       NVARCHAR(100)   NOT NULL
);
GO

-- 1.4. Bảng Ngôn ngữ
IF OBJECT_ID('tNgonNgu', 'U') IS NULL
CREATE TABLE tNgonNgu (
    MaNN        CHAR(4)         NOT NULL PRIMARY KEY,
    TenNN       NVARCHAR(100)   NOT NULL
);
GO

-- 1.5. Bảng Tác giả
IF OBJECT_ID('tTacGia', 'U') IS NULL
CREATE TABLE tTacGia (
    MaTG        CHAR(6)         NOT NULL PRIMARY KEY,
    TenTG       NVARCHAR(100)   NOT NULL,
    NgaySinh    DATE            NULL,
    GioiTinh    CHAR(1)         NULL CHECK (GioiTinh IN ('M', 'F')), -- M: Nam, F: Nữ
    DiaChi      NVARCHAR(200)   NULL
);
GO

-- 1.6. Bảng Nhà xuất bản (NXB)
IF OBJECT_ID('tNXB', 'U') IS NULL
CREATE TABLE tNXB (
    MaNXB       CHAR(6)         NOT NULL PRIMARY KEY,
    TenNXB      NVARCHAR(150)   NOT NULL,
    DiaChi      NVARCHAR(200)   NULL,
    DienThoai   NVARCHAR(20)    NULL
);
GO

-- 1.7. Bảng Ca làm việc
IF OBJECT_ID('tCaLam', 'U') IS NULL
CREATE TABLE tCaLam (
    MaCa        CHAR(3)         NOT NULL PRIMARY KEY,
    TenCa       NVARCHAR(50)    NOT NULL
);
GO

-- 1.8. Bảng Vi phạm & Tiền phạt
IF OBJECT_ID('tViPham', 'U') IS NULL
CREATE TABLE tViPham (
    MaVP        CHAR(5)         NOT NULL PRIMARY KEY,
    TenVP       NVARCHAR(100)   NOT NULL,
    TienPhat    DECIMAL(12,0)   NOT NULL DEFAULT 0
);
GO

-- 1.9. Bảng Khách hàng
IF OBJECT_ID('tKhachHang', 'U') IS NULL
CREATE TABLE tKhachHang (
    MaKH        CHAR(8)         NOT NULL PRIMARY KEY,
    TenKH       NVARCHAR(100)   NOT NULL,
    NgaySinh    DATE            NULL,
    GioiTinh    CHAR(1)         NULL CHECK (GioiTinh IN ('M', 'F')),
    DiaChi      NVARCHAR(200)   NULL
);
GO

-- 1.10. Bảng Nhân viên
IF OBJECT_ID('tNhanVien', 'U') IS NULL
CREATE TABLE tNhanVien (
    MaNV        CHAR(6)         NOT NULL PRIMARY KEY,
    TenNV       NVARCHAR(100)   NOT NULL,
    NamSinh     INT             NULL,
    GioiTinh    CHAR(1)         NULL CHECK (GioiTinh IN ('M', 'F')),
    DiaChi      NVARCHAR(200)   NULL,
    DienThoai   NVARCHAR(20)    NULL,
    LuongThang  DECIMAL(12,0)   NULL DEFAULT 0
);
GO

-- 1.11. Bảng Sách truyện
IF OBJECT_ID('tSachTruyen', 'U') IS NULL
CREATE TABLE tSachTruyen (
    MaSach      CHAR(8)         NOT NULL PRIMARY KEY,
    TenSach     NVARCHAR(200)   NOT NULL,
    MaLoai      CHAR(4)         NOT NULL FOREIGN KEY REFERENCES tLoaiSach(MaLoai),
    MaLV        CHAR(4)         NOT NULL FOREIGN KEY REFERENCES tLinhVuc(MaLV),
    MaTG        CHAR(6)         NOT NULL FOREIGN KEY REFERENCES tTacGia(MaTG),
    MaNXB       CHAR(6)         NOT NULL FOREIGN KEY REFERENCES tNXB(MaNXB),
    MaNN        CHAR(4)         NOT NULL FOREIGN KEY REFERENCES tNgonNgu(MaNN),
    SoTrang     INT             NULL,
    GiaSach     DECIMAL(12,0)   NOT NULL DEFAULT 0,
    DonGiaThue  DECIMAL(12,0)   NOT NULL DEFAULT 0,
    MaTT        CHAR(4)         NOT NULL FOREIGN KEY REFERENCES tTinhTrang(MaTT),
    SoLuong     INT             NOT NULL DEFAULT 0 CHECK (SoLuong >= 0),
    Anh         NVARCHAR(200)   NULL,
    GhiChu      NVARCHAR(500)   NULL
);
GO

-- 1.12. Bảng Thuê sách
IF OBJECT_ID('tThueSach', 'U') IS NULL
CREATE TABLE tThueSach (
    MaThue      CHAR(10)        NOT NULL PRIMARY KEY,
    MaKH        CHAR(8)         NOT NULL FOREIGN KEY REFERENCES tKhachHang(MaKH),
    MaNV        CHAR(6)         NOT NULL FOREIGN KEY REFERENCES tNhanVien(MaNV),
    MaCa        CHAR(3)         NULL FOREIGN KEY REFERENCES tCaLam(MaCa),
    NgayThue    DATE            NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TienDatCoc  DECIMAL(12,0)   NOT NULL DEFAULT 0
);
GO

-- 1.13. Bảng Chi tiết thuê sách
IF OBJECT_ID('tChiTietThueSach', 'U') IS NULL
CREATE TABLE tChiTietThueSach (
    MaThue      CHAR(10)        NOT NULL FOREIGN KEY REFERENCES tThueSach(MaThue),
    MaSach      CHAR(8)         NOT NULL FOREIGN KEY REFERENCES tSachTruyen(MaSach),
    SoLuong     INT             NOT NULL DEFAULT 1 CHECK (SoLuong > 0),
    DaTra       BIT             NOT NULL DEFAULT 0, -- 0: Chưa trả, 1: Đã trả
    PRIMARY KEY (MaThue, MaSach)
);
GO

-- 1.14. Bảng Trả sách
IF OBJECT_ID('tTraSach', 'U') IS NULL
CREATE TABLE tTraSach (
    MaTra       CHAR(10)        NOT NULL PRIMARY KEY,
    MaThue      CHAR(10)        NOT NULL FOREIGN KEY REFERENCES tThueSach(MaThue),
    MaNV        CHAR(6)         NOT NULL FOREIGN KEY REFERENCES tNhanVien(MaNV),
    NgayTra     DATE            NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TongTien    DECIMAL(12,0)   NOT NULL DEFAULT 0
);
GO

-- 1.15. Bảng Chi tiết trả sách
IF OBJECT_ID('tChiTietTraSach', 'U') IS NULL
CREATE TABLE tChiTietTraSach (
    MaTra       CHAR(10)        NOT NULL FOREIGN KEY REFERENCES tTraSach(MaTra),
    MaSach      CHAR(8)         NOT NULL FOREIGN KEY REFERENCES tSachTruyen(MaSach),
    MaVP        CHAR(5)         NULL FOREIGN KEY REFERENCES tViPham(MaVP),
    ThanhTien   DECIMAL(12,0)   NOT NULL DEFAULT 0,
    PRIMARY KEY (MaTra, MaSach)
);
GO

-- =========================================================================
-- 2. HÀM TÍNH TOÁN & CÁC TRIGGER RÀNG BUỘC KHO (YÊU CẦU 2 & 4)
-- =========================================================================

-- 2.1. Hàm tính thành tiền chi tiết trả sách (Yêu cầu 4)
-- Thành tiền = Đơn giá thuê * Số ngày thuê * Số lượng + Tiền phạt (nếu có)
IF OBJECT_ID('fn_TinhThanhTien', 'FN') IS NOT NULL
    DROP FUNCTION fn_TinhThanhTien;
GO

CREATE FUNCTION fn_TinhThanhTien (
    @MaThue CHAR(10), 
    @MaSach CHAR(8), 
    @NgayTra DATE, 
    @MaVP CHAR(5)
)
RETURNS DECIMAL(12,0)
AS
BEGIN
    DECLARE @NgayThue DATE, @DonGia DECIMAL(12,0), @SL INT;
    DECLARE @SoNgay INT, @TienPhat DECIMAL(12,0) = 0;

    SELECT @NgayThue = t.NgayThue, @SL = ct.SoLuong, @DonGia = s.DonGiaThue
    FROM tThueSach t
    JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue
    JOIN tSachTruyen s ON s.MaSach = ct.MaSach
    WHERE t.MaThue = @MaThue AND ct.MaSach = @MaSach;

    -- Tính số ngày thuê: Nếu thuê và trả trong cùng ngày tính tối thiểu 1 ngày
    SET @SoNgay = DATEDIFF(DAY, @NgayThue, @NgayTra);
    IF @SoNgay < 1 SET @SoNgay = 1;

    -- Tiền phạt (nếu có vi phạm)
    IF @MaVP IS NOT NULL AND @MaVP <> ''
        SELECT @TienPhat = TienPhat FROM tViPham WHERE MaVP = @MaVP;

    RETURN (@DonGia * @SoNgay * @SL) + ISNULL(@TienPhat, 0);
END;
GO

-- 2.2. Triggers tự động cập nhật số lượng sách trong kho (Yêu cầu 2)

-- Trigger A: Khi THUÊ SÁCH (Insert vào tChiTietThueSach) -> Giảm số lượng trong tSachTruyen
IF OBJECT_ID('trg_ChiTietThue_Insert', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietThue_Insert;
GO

CREATE TRIGGER trg_ChiTietThue_Insert 
ON tChiTietThueSach
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu tồn kho không đủ
    IF EXISTS (
        SELECT 1
        FROM tSachTruyen s
        JOIN (
            SELECT MaSach, SUM(SoLuong) AS TongThue
            FROM inserted 
            GROUP BY MaSach
        ) x ON x.MaSach = s.MaSach
        WHERE s.SoLuong < x.TongThue
    )
    BEGIN
        RAISERROR(N'Lỗi: Số lượng sách trong kho không đủ để cho thuê!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Cập nhật giảm tồn kho
    UPDATE s
    SET s.SoLuong = s.SoLuong - x.TongThue
    FROM tSachTruyen s
    JOIN (
        SELECT MaSach, SUM(SoLuong) AS TongThue
        FROM inserted 
        GROUP BY MaSach
    ) x ON x.MaSach = s.MaSach;
END;
GO

-- Trigger B: Khi CẬP NHẬT số lượng thuê
IF OBJECT_ID('trg_ChiTietThue_Update', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietThue_Update;
GO

CREATE TRIGGER trg_ChiTietThue_Update
ON tChiTietThueSach
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(SoLuong)
    BEGIN
        IF EXISTS (
            SELECT 1
            FROM tSachTruyen s
            JOIN (
                SELECT i.MaSach, SUM(i.SoLuong - d.SoLuong) AS ChenhLech
                FROM inserted i
                JOIN deleted d ON i.MaThue = d.MaThue AND i.MaSach = d.MaSach
                GROUP BY i.MaSach
            ) x ON x.MaSach = s.MaSach
            WHERE s.SoLuong < x.ChenhLech
        )
        BEGIN
            RAISERROR(N'Lỗi: Tồn kho sách không đủ để điều chỉnh tăng số lượng thuê!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        UPDATE s
        SET s.SoLuong = s.SoLuong - x.ChenhLech
        FROM tSachTruyen s
        JOIN (
            SELECT i.MaSach, SUM(i.SoLuong - d.SoLuong) AS ChenhLech
            FROM inserted i
            JOIN deleted d ON i.MaThue = d.MaThue AND i.MaSach = d.MaSach
            GROUP BY i.MaSach
        ) x ON x.MaSach = s.MaSach;
    END
END;
GO

-- Trigger C: Khi XÓA dòng chi tiết thuê (chưa trả) -> Hoàn lại tồn kho
IF OBJECT_ID('trg_ChiTietThue_Delete', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietThue_Delete;
GO

CREATE TRIGGER trg_ChiTietThue_Delete 
ON tChiTietThueSach
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE s
    SET s.SoLuong = s.SoLuong + x.TongThue
    FROM tSachTruyen s
    JOIN (
        SELECT MaSach, SUM(SoLuong) AS TongThue
        FROM deleted 
        WHERE DaTra = 0 
        GROUP BY MaSach
    ) x ON x.MaSach = s.MaSach;
END;
GO

-- Trigger D: Khi TRẢ SÁCH (Insert vào tChiTietTraSach) -> Tăng lại số lượng trong kho & đánh dấu DaTra = 1
IF OBJECT_ID('trg_ChiTietTra_Insert', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietTra_Insert;
GO

CREATE TRIGGER trg_ChiTietTra_Insert 
ON tChiTietTraSach
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Cộng tồn kho sách (chỉ cộng nếu sách KHÔNG bị mất - mã VP003 là Mất sách)
    UPDATE s
    SET s.SoLuong = s.SoLuong + x.TongTra
    FROM tSachTruyen s
    JOIN (
        SELECT i.MaSach, SUM(ct.SoLuong) AS TongTra
        FROM inserted i
        JOIN tTraSach t ON t.MaTra = i.MaTra
        JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue AND ct.MaSach = i.MaSach
        WHERE i.MaVP IS NULL OR i.MaVP <> 'VP003'
        GROUP BY i.MaSach
    ) x ON x.MaSach = s.MaSach;

    -- 2. Cập nhật trạng thái DaTra = 1 trong phiếu thuê tương ứng
    UPDATE ct
    SET ct.DaTra = 1
    FROM tChiTietThueSach ct
    JOIN tTraSach t ON t.MaThue = ct.MaThue
    JOIN inserted i ON i.MaTra = t.MaTra AND i.MaSach = ct.MaSach;
END;
GO

-- Trigger E: Khi XÓA chi tiết trả sách -> Khôi phục lại trạng thái
IF OBJECT_ID('trg_ChiTietTra_Delete', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietTra_Delete;
GO

CREATE TRIGGER trg_ChiTietTra_Delete
ON tChiTietTraSach
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Trừ lại kho
    UPDATE s
    SET s.SoLuong = s.SoLuong - x.TongTra
    FROM tSachTruyen s
    JOIN (
        SELECT d.MaSach, SUM(ct.SoLuong) AS TongTra
        FROM deleted d
        JOIN tTraSach t ON t.MaTra = d.MaTra
        JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue AND ct.MaSach = d.MaSach
        WHERE d.MaVP IS NULL OR d.MaVP <> 'VP003'
        GROUP BY d.MaSach
    ) x ON x.MaSach = s.MaSach;

    -- Khôi phục cờ DaTra = 0
    UPDATE ct
    SET ct.DaTra = 0
    FROM tChiTietThueSach ct
    JOIN tTraSach t ON t.MaThue = ct.MaThue
    JOIN deleted d ON d.MaTra = t.MaTra AND d.MaSach = ct.MaSach;
END;
GO

-- =========================================================================
-- 3. CÁC VIEW VÀ THỦ TỤC ĐÁP ỨNG ĐẦY ĐỦ CÁC YÊU CẦU ĐỀ BÀI
-- =========================================================================

-- Yêu cầu 1: Bảng/View hiển thị chỉ các sách có số lượng > 0
IF OBJECT_ID('vw_SachConHang', 'V') IS NOT NULL
    DROP VIEW vw_SachConHang;
GO

CREATE VIEW vw_SachConHang
AS
SELECT s.MaSach, s.TenSach, s.DonGiaThue, s.SoLuong,
       lv.TenLV, tg.TenTG, nxb.TenNXB, tt.TenTT, s.Anh
FROM tSachTruyen s
LEFT JOIN tLinhVuc lv ON lv.MaLV = s.MaLV
LEFT JOIN tTacGia tg ON tg.MaTG = s.MaTG
LEFT JOIN tNXB nxb ON nxb.MaNXB = s.MaNXB
LEFT JOIN tTinhTrang tt ON tt.MaTT = s.MaTT
WHERE s.SoLuong > 0;
GO

IF OBJECT_ID('SP_GetSachConHang', 'P') IS NOT NULL
    DROP PROCEDURE SP_GetSachConHang;
GO

CREATE PROCEDURE SP_GetSachConHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM vw_SachConHang ORDER BY TenSach;
END;
GO

-- Yêu cầu 3: Khi khách trả sách chỉ hiển thị các sách CHƯA TRẢ từ mã thuê tương ứng
IF OBJECT_ID('SP_GetSachChuaTraTheoPhieu', 'P') IS NOT NULL
    DROP PROCEDURE SP_GetSachChuaTraTheoPhieu;
GO

CREATE PROCEDURE SP_GetSachChuaTraTheoPhieu
    @MaThue CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ct.MaSach, s.TenSach, ct.SoLuong, s.DonGiaThue,
           t.NgayThue,
           CASE WHEN DATEDIFF(DAY, t.NgayThue, GETDATE()) < 1 THEN 1 
                ELSE DATEDIFF(DAY, t.NgayThue, GETDATE()) END AS SoNgayThueTamTinh
    FROM tChiTietThueSach ct
    JOIN tSachTruyen s ON s.MaSach = ct.MaSach
    JOIN tThueSach t ON t.MaThue = ct.MaThue
    WHERE ct.MaThue = @MaThue AND ct.DaTra = 0;
END;
GO

-- Yêu cầu 4: Thủ tục thêm chi tiết trả sách, tự tính Thành tiền và cập nhật Tổng tiền
IF OBJECT_ID('SP_ThemChiTietTra', 'P') IS NOT NULL
    DROP PROCEDURE SP_ThemChiTietTra;
GO

CREATE PROCEDURE SP_ThemChiTietTra
    @MaTra CHAR(10), 
    @MaSach CHAR(8), 
    @MaVP CHAR(5) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    DECLARE @MaThue CHAR(10), @NgayTra DATE;
    SELECT @MaThue = MaThue, @NgayTra = NgayTra FROM tTraSach WHERE MaTra = @MaTra;

    IF @MaThue IS NULL
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Lỗi: Phiếu trả không tồn tại!', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (
        SELECT 1 FROM tChiTietThueSach 
        WHERE MaThue = @MaThue AND MaSach = @MaSach AND DaTra = 0
    )
    BEGIN
        ROLLBACK TRANSACTION;
        RAISERROR(N'Lỗi: Sách này không có trong phiếu thuê hoặc đã được trả trước đó.', 16, 1);
        RETURN;
    END

    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES (
        @MaTra, 
        @MaSach, 
        CASE WHEN @MaVP = '' THEN NULL ELSE @MaVP END, 
        dbo.fn_TinhThanhTien(@MaThue, @MaSach, @NgayTra, @MaVP)
    );

    UPDATE tTraSach
    SET TongTien = (SELECT ISNULL(SUM(ThanhTien), 0) FROM tChiTietTraSach WHERE MaTra = @MaTra)
    WHERE MaTra = @MaTra;

    COMMIT TRANSACTION;
END;
GO

-- Yêu cầu 5: Tìm kiếm Sách truyện theo tiêu chí: Tên sách, lĩnh vực, tác giả, NXB
IF OBJECT_ID('SP_TimSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_TimSach;
GO

CREATE PROCEDURE SP_TimSach
    @TenSach NVARCHAR(200) = NULL,
    @MaLV CHAR(4) = NULL,
    @MaTG CHAR(6) = NULL,
    @MaNXB CHAR(6) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT s.MaSach, s.TenSach, lv.TenLV, tg.TenTG, nxb.TenNXB, 
           s.DonGiaThue, s.SoLuong, tt.TenTT, s.Anh, s.GiaSach, s.SoTrang
    FROM tSachTruyen s
    LEFT JOIN tLinhVuc lv ON lv.MaLV = s.MaLV
    LEFT JOIN tTacGia tg ON tg.MaTG = s.MaTG
    LEFT JOIN tNXB nxb ON nxb.MaNXB = s.MaNXB
    LEFT JOIN tTinhTrang tt ON tt.MaTT = s.MaTT
    WHERE (@TenSach IS NULL OR @TenSach = '' OR s.TenSach LIKE N'%' + @TenSach + N'%')
      AND (@MaLV IS NULL OR @MaLV = '' OR s.MaLV = @MaLV)
      AND (@MaTG IS NULL OR @MaTG = '' OR s.MaTG = @MaTG)
      AND (@MaNXB IS NULL OR @MaNXB = '' OR s.MaNXB = @MaNXB)
    ORDER BY s.TenSach;
END;
GO

-- Yêu cầu 6: Tìm kiếm Nhân viên theo tiêu chí: Tên nhân viên, ca làm, giới tính
IF OBJECT_ID('SP_TimNhanVien', 'P') IS NOT NULL
    DROP PROCEDURE SP_TimNhanVien;
GO

CREATE PROCEDURE SP_TimNhanVien
    @TenNV NVARCHAR(100) = NULL,
    @MaCa CHAR(3) = NULL,
    @GioiTinh CHAR(1) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT nv.MaNV, nv.TenNV, nv.NamSinh, nv.GioiTinh, 
           nv.DiaChi, nv.DienThoai, nv.LuongThang
    FROM tNhanVien nv
    WHERE (@TenNV IS NULL OR @TenNV = '' OR nv.TenNV LIKE N'%' + @TenNV + N'%')
      AND (@GioiTinh IS NULL OR @GioiTinh = '' OR nv.GioiTinh = @GioiTinh)
      AND (@MaCa IS NULL OR @MaCa = '' OR EXISTS (
          SELECT 1 FROM tThueSach t WHERE t.MaNV = nv.MaNV AND t.MaCa = @MaCa
      ))
    ORDER BY nv.TenNV;
END;
GO

-- Yêu cầu 7: Báo cáo danh sách các sách truyện đang được thuê chưa trả
IF OBJECT_ID('vw_SachDangThueChuaTra', 'V') IS NOT NULL
    DROP VIEW vw_SachDangThueChuaTra;
GO

CREATE VIEW vw_SachDangThueChuaTra
AS
SELECT t.MaThue, kh.TenKH, s.MaSach, s.TenSach, ct.SoLuong,
       t.NgayThue,
       CASE WHEN DATEDIFF(DAY, t.NgayThue, GETDATE()) < 1 THEN 1 
            ELSE DATEDIFF(DAY, t.NgayThue, GETDATE()) END AS SoNgayDaThue,
       s.DonGiaThue * (CASE WHEN DATEDIFF(DAY, t.NgayThue, GETDATE()) < 1 THEN 1 
                            ELSE DATEDIFF(DAY, t.NgayThue, GETDATE()) END) * ct.SoLuong AS TienThueTamTinh,
       t.TienDatCoc, nv.TenNV AS NhanVienLap
FROM tChiTietThueSach ct
JOIN tThueSach t ON t.MaThue = ct.MaThue
JOIN tKhachHang kh ON kh.MaKH = t.MaKH
JOIN tSachTruyen s ON s.MaSach = ct.MaSach
JOIN tNhanVien nv ON nv.MaNV = t.MaNV
WHERE ct.DaTra = 0;
GO

-- Yêu cầu 8: Báo cáo tổng tiền cho thuê thu được theo Tháng, Quý, Năm
IF OBJECT_ID('SP_DoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE SP_DoanhThu;
GO

CREATE PROCEDURE SP_DoanhThu
    @Kieu VARCHAR(5),          -- 'THANG', 'QUY' hoặc 'NAM'
    @Nam INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @Nam IS NULL SET @Nam = YEAR(GETDATE());

    IF @Kieu = 'THANG'
        SELECT MONTH(NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach 
        WHERE YEAR(NgayTra) = @Nam
        GROUP BY MONTH(NgayTra) 
        ORDER BY Ky;
    ELSE IF @Kieu = 'QUY'
        SELECT DATEPART(QUARTER, NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach 
        WHERE YEAR(NgayTra) = @Nam
        GROUP BY DATEPART(QUARTER, NgayTra) 
        ORDER BY Ky;
    ELSE -- 'NAM'
        SELECT YEAR(NgayTra) AS Ky, COUNT(*) AS SoPhieuTra, SUM(TongTien) AS DoanhThu
        FROM tTraSach
        GROUP BY YEAR(NgayTra) 
        ORDER BY Ky;
END;
GO

-- Yêu cầu 9: Báo cáo danh sách 5 sách truyện đạt doanh thu nhiều nhất
IF OBJECT_ID('SP_Top5SachDoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE SP_Top5SachDoanhThu;
GO

CREATE PROCEDURE SP_Top5SachDoanhThu
    @TuNgay DATE = NULL,
    @DenNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 5 
           ROW_NUMBER() OVER (ORDER BY SUM(c.ThanhTien) DESC) AS Hang,
           s.MaSach, 
           s.TenSach, 
           tg.TenTG,
           lv.TenLV,
           COUNT(*) AS SoLanThue,
           SUM(c.ThanhTien) AS DoanhThu
    FROM tChiTietTraSach c
    JOIN tTraSach tr ON tr.MaTra = c.MaTra
    JOIN tSachTruyen s ON s.MaSach = c.MaSach
    LEFT JOIN tTacGia tg ON tg.MaTG = s.MaTG
    LEFT JOIN tLinhVuc lv ON lv.MaLV = s.MaLV
    WHERE (@TuNgay IS NULL OR tr.NgayTra >= @TuNgay)
      AND (@DenNgay IS NULL OR tr.NgayTra <= @DenNgay)
    GROUP BY s.MaSach, s.TenSach, tg.TenTG, lv.TenLV
    ORDER BY DoanhThu DESC;
END;
GO

-- =========================================================================
-- 4. THỦ TỤC SINH MÃ TỰ ĐỘNG (HỖ TRỢ LẬP TRÌNH WINFORMS NHANH CHÓNG)
-- =========================================================================

IF OBJECT_ID('SP_GenerateNewMaSach', 'P') IS NOT NULL DROP PROCEDURE SP_GenerateNewMaSach;
GO
CREATE PROCEDURE SP_GenerateNewMaSach @NewMa CHAR(8) OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Max INT = ISNULL((SELECT MAX(CAST(SUBSTRING(MaSach, 3, 6) AS INT)) FROM tSachTruyen), 0) + 1;
    SET @NewMa = 'S_' + RIGHT('000000' + CAST(@Max AS VARCHAR(6)), 6);
END;
GO

IF OBJECT_ID('SP_GenerateNewMaThue', 'P') IS NOT NULL DROP PROCEDURE SP_GenerateNewMaThue;
GO
CREATE PROCEDURE SP_GenerateNewMaThue @NewMa CHAR(10) OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Prefix CHAR(4) = 'TH' + RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR(4)), 2) + RIGHT('0' + CAST(MONTH(GETDATE()) AS VARCHAR(2)), 2);
    DECLARE @Max INT = ISNULL((SELECT MAX(CAST(SUBSTRING(MaThue, 7, 4) AS INT)) FROM tThueSach WHERE MaThue LIKE @Prefix + '%'), 0) + 1;
    SET @NewMa = @Prefix + RIGHT('0000' + CAST(@Max AS VARCHAR(4)), 4);
END;
GO

IF OBJECT_ID('SP_GenerateNewMaTra', 'P') IS NOT NULL DROP PROCEDURE SP_GenerateNewMaTra;
GO
CREATE PROCEDURE SP_GenerateNewMaTra @NewMa CHAR(10) OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Prefix CHAR(4) = 'TR' + RIGHT(CAST(YEAR(GETDATE()) AS VARCHAR(4)), 2) + RIGHT('0' + CAST(MONTH(GETDATE()) AS VARCHAR(2)), 2);
    DECLARE @Max INT = ISNULL((SELECT MAX(CAST(SUBSTRING(MaTra, 7, 4) AS INT)) FROM tTraSach WHERE MaTra LIKE @Prefix + '%'), 0) + 1;
    SET @NewMa = @Prefix + RIGHT('0000' + CAST(@Max AS VARCHAR(4)), 4);
END;
GO

IF OBJECT_ID('SP_GenerateNewMaKH', 'P') IS NOT NULL DROP PROCEDURE SP_GenerateNewMaKH;
GO
CREATE PROCEDURE SP_GenerateNewMaKH @NewMa CHAR(8) OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Max INT = ISNULL((SELECT MAX(CAST(SUBSTRING(MaKH, 3, 6) AS INT)) FROM tKhachHang), 0) + 1;
    SET @NewMa = 'KH' + RIGHT('000000' + CAST(@Max AS VARCHAR(6)), 6);
END;
GO

IF OBJECT_ID('SP_GenerateNewMaNV', 'P') IS NOT NULL DROP PROCEDURE SP_GenerateNewMaNV;
GO
CREATE PROCEDURE SP_GenerateNewMaNV @NewMa CHAR(6) OUTPUT AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Max INT = ISNULL((SELECT MAX(CAST(SUBSTRING(MaNV, 3, 4) AS INT)) FROM tNhanVien), 0) + 1;
    SET @NewMa = 'NV' + RIGHT('0000' + CAST(@Max AS VARCHAR(4)), 4);
END;
GO

-- =========================================================================
-- 5. DỮ LIỆU MẪU (DÙNG ĐỂ CHẠY THỬ VÀ KIỂM TRA ĐẦY ĐỦ CÁC CHỨC NĂNG)
-- =========================================================================

-- 5.1. Lĩnh vực
IF NOT EXISTS (SELECT 1 FROM tLinhVuc WHERE MaLV = 'LV01')
INSERT INTO tLinhVuc (MaLV, TenLV) VALUES
('LV01', N'Truyện tranh Manga - Comic'),
('LV02', N'Tiểu thuyết Trinh thám - Ly kỳ'),
('LV03', N'Văn học Thiếu nhi - Tuổi mới lớn'),
('LV04', N'Võ hiệp - Kiếm hiệp Cổ trang'),
('LV05', N'Kỹ năng sống - Phát triển bản thân'),
('LV06', N'Khoa học viễn tưởng - Phiêu lưu');
GO

-- 5.2. Loại sách
IF NOT EXISTS (SELECT 1 FROM tLoaiSach WHERE MaLoai = 'L001')
INSERT INTO tLoaiSach (MaLoai, TenLoai) VALUES
('L001', N'Sách mới xuất bản (Hot)'),
('L002', N'Sách tiêu chuẩn'),
('L003', N'Sách cũ sưu tầm / Hiếm'),
('L004', N'Sách kinh điển bán chạy');
GO

-- 5.3. Tình trạng sách
IF NOT EXISTS (SELECT 1 FROM tTinhTrang WHERE MaTT = 'TT01')
INSERT INTO tTinhTrang (MaTT, TenTT) VALUES
('TT01', N'Mới 99% - Tốt'),
('TT02', N'Bình thường - Ổn định'),
('TT03', N'Hơi cũ - Gáy yếu'),
('TT04', N'Đã bọc màng co bảo vệ');
GO

-- 5.4. Ngôn ngữ
IF NOT EXISTS (SELECT 1 FROM tNgonNgu WHERE MaNN = 'VN')
INSERT INTO tNgonNgu (MaNN, TenNN) VALUES
('VN', N'Tiếng Việt'),
('EN', N'Tiếng Anh'),
('JP', N'Tiếng Nhật'),
('FR', N'Tiếng Pháp');
GO

-- 5.5. Tác giả
IF NOT EXISTS (SELECT 1 FROM tTacGia WHERE MaTG = 'TG0001')
INSERT INTO tTacGia (MaTG, TenTG, NgaySinh, GioiTinh, DiaChi) VALUES
('TG0001', N'Fujiko F. Fujio', '1933-12-01', 'M', N'Toyama, Nhật Bản'),
('TG0002', N'Higashino Keigo', '1958-02-04', 'M', N'Osaka, Nhật Bản'),
('TG0003', N'Nguyễn Nhật Ánh', '1955-05-07', 'M', N'Quảng Nam, Việt Nam'),
('TG0004', N'Kim Dung', '1924-03-10', 'M', N'Hồng Kông'),
('TG0005', N'Dale Carnegie', '1888-11-24', 'M', N'Missouri, Hoa Kỳ'),
('TG0006', N'J.K. Rowling', '1965-07-31', 'F', N'Yate, Vương quốc Anh'),
('TG0007', N'Antoine de Saint-Exupéry', '1900-06-29', 'M', N'Lyon, Pháp');
GO

-- 5.6. Nhà xuất bản
IF NOT EXISTS (SELECT 1 FROM tNXB WHERE MaNXB = 'NXB001')
INSERT INTO tNXB (MaNXB, TenNXB, DiaChi, DienThoai) VALUES
('NXB001', N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '02439434730'),
('NXB002', N'NXB Trẻ', N'161B Lý Chính Thắng, TP.HCM', '02839316289'),
('NXB003', N'NXB Hội Nhà Văn', N'65 Nguyễn Du, Hà Nội', '02438222135'),
('NXB004', N'NXB Văn Học', N'18 Nguyễn Trường Tộ, Hà Nội', '02437161518'),
('NXB005', N'NXB Tổng Hợp TP.HCM', N'62 Nguyễn Thị Minh Khai, TP.HCM', '02838225340');
GO

-- 5.7. Ca làm việc
IF NOT EXISTS (SELECT 1 FROM tCaLam WHERE MaCa = 'CA1')
INSERT INTO tCaLam (MaCa, TenCa) VALUES
('CA1', N'Ca Sáng (07:30 - 12:00)'),
('CA2', N'Ca Chiều (12:00 - 17:30)'),
('CA3', N'Ca Tối (17:30 - 22:00)');
GO

-- 5.8. Vi phạm & Mức phạt
IF NOT EXISTS (SELECT 1 FROM tViPham WHERE MaVP = 'VP001')
INSERT INTO tViPham (MaVP, TenVP, TienPhat) VALUES
('VP001', N'Rách bìa / bong gáy nhẹ', 10000),
('VP002', N'Mất trang / bẩn nhiều trang', 25000),
('VP003', N'Mất sách (Đền nguyên giá bìa)', 80000),
('VP004', N'Trả muộn quá hạn quy định', 15000),
('VP005', N'Vẽ bậy / gập mép sách', 5000);
GO

-- 5.9. Khách hàng
IF NOT EXISTS (SELECT 1 FROM tKhachHang WHERE MaKH = 'KH000001')
INSERT INTO tKhachHang (MaKH, TenKH, NgaySinh, GioiTinh, DiaChi) VALUES
('KH000001', N'Trần Văn An', '2002-05-14', 'M', N'12 Chùa Láng, Đống Đa, Hà Nội'),
('KH000002', N'Nguyễn Thị Mai', '2003-11-20', 'F', N'88 Cầu Giấy, Cầu Giấy, Hà Nội'),
('KH000003', N'Lê Minh Hoàng', '2001-08-09', 'M', N'45 Nguyễn Chí Thanh, Hà Nội'),
('KH000004', N'Đỗ Phương Thảo', '2004-03-25', 'F', N'102 Thái Hà, Đống Đa, Hà Nội'),
('KH000005', N'Phạm Tuấn Anh', '2000-12-18', 'M', N'66 Xuân Thủy, Cầu Giấy, Hà Nội');
GO

-- 5.10. Nhân viên
IF NOT EXISTS (SELECT 1 FROM tNhanVien WHERE MaNV = 'NV0001')
INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang) VALUES
('NV0001', N'Vũ Thị Bích Ngọc', 1999, 'F', N'22 Tây Sơn, Đống Đa, Hà Nội', '0912345678', 7500000),
('NV0002', N'Hoàng Quốc Việt', 1998, 'M', N'79 Đội Cấn, Ba Đình, Hà Nội', '0987654321', 8000000),
('NV0003', N'Đinh Thu Trang', 2001, 'F', N'15 Hoàng Quốc Việt, Cầu Giấy, Hà Nội', '0905123987', 6500000);
GO

-- 5.11. Sách truyện
IF NOT EXISTS (SELECT 1 FROM tSachTruyen WHERE MaSach = 'S_000001')
INSERT INTO tSachTruyen (MaSach, TenSach, MaLoai, MaLV, MaTG, MaNXB, MaNN, SoTrang, GiaSach, DonGiaThue, MaTT, SoLuong, Anh, GhiChu) VALUES
('S_000001', N'Doraemon Tuyển tập Tranh truyện - Tập 1', 'L004', 'LV01', 'TG0001', 'NXB001', 'VN', 192, 45000, 3000, 'TT01', 5, N'doraemon_vol1.jpg', N'Bản in màu chất lượng cao'),
('S_000002', N'Phía Sau Nghi Can X', 'L001', 'LV02', 'TG0002', 'NXB003', 'VN', 400, 115000, 5000, 'TT01', 4, N'nghican_x.jpg', N'Tiểu thuyết trinh thám bán chạy nhất'),
('S_000003', N'Mắt Biếc', 'L004', 'LV03', 'TG0003', 'NXB002', 'VN', 300, 85000, 4000, 'TT02', 3, N'matbiec.jpg', N'Tác phẩm kinh điển tuổi thanh xuân'),
('S_000004', N'Tiếu Ngạo Giang Hồ - Trọn bộ Tập 1', 'L003', 'LV04', 'TG0004', 'NXB004', 'VN', 550, 160000, 6000, 'TT02', 2, N'tieungao1.jpg', N'Kiếm hiệp kinh điển Kim Dung'),
('S_000005', N'Đắc Nhân Tâm', 'L004', 'LV05', 'TG0005', 'NXB005', 'VN', 320, 98000, 5000, 'TT01', 6, N'dacnhantam.jpg', N'Sách phát triển bản thân hàng đầu thế giới'),
('S_000006', N'Harry Potter và Hòn đá Phù thủy', 'L001', 'LV06', 'TG0006', 'NXB002', 'VN', 360, 135000, 6500, 'TT01', 5, N'harrypotter1.jpg', N'Bản dịch mới có tranh minh họa'),
('S_000007', N'Hoàng Tử Bé', 'L004', 'LV03', 'TG0007', 'NXB001', 'VN', 120, 60000, 3000, 'TT01', 3, N'hoangtube.jpg', N'Ấn bản kỉ niệm đặc biệt'),
('S_000008', N'Bạch Dạ Hành', 'L001', 'LV02', 'TG0002', 'NXB003', 'VN', 600, 175000, 7000, 'TT01', 4, N'bachdahanh.jpg', N'Kiệt tác trinh thám đỉnh cao Keigo'),
('S_000009', N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 'L002', 'LV03', 'TG0003', 'NXB002', 'VN', 380, 92000, 4500, 'TT02', 2, N'hoavang.jpg', N'Bản bìa mềm tái bản'),
('S_000010', N'Anh Hùng Xạ Điêu - Tập 1', 'L002', 'LV04', 'TG0004', 'NXB004', 'VN', 480, 140000, 5500, 'TT02', 1, N'xadieu1.jpg', N'Tác phẩm võ hiệp hào hùng');
GO

-- 5.12. Phiếu thuê sách
IF NOT EXISTS (SELECT 1 FROM tThueSach WHERE MaThue = 'TH25100001')
BEGIN
    -- Phiếu 1: Đã hoàn tất trả
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH25100001', 'KH000001', 'NV0001', 'CA1', '2025-10-01', 100000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH25100001', 'S_000001', 1, 1),
    ('TH25100001', 'S_000003', 1, 0);

    -- Phiếu 2: Đã hoàn tất trả
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH25110001', 'KH000002', 'NV0002', 'CA2', '2025-11-10', 150000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH25110001', 'S_000006', 1, 1);

    -- Phiếu 3: Đã trả (có phát sinh vi phạm)
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH25120001', 'KH000003', 'NV0001', 'CA1', '2025-12-01', 200000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH25120001', 'S_000002', 1, 1),
    ('TH25120001', 'S_000005', 1, 1);

    -- Phiếu 4: Đã trả
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH26010001', 'KH000004', 'NV0003', 'CA3', '2026-01-05', 100000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH26010001', 'S_000001', 1, 1);

    -- Phiếu 5: Đã trả
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH26030001', 'KH000005', 'NV0002', 'CA2', '2026-03-10', 180000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH26030001', 'S_000004', 1, 1);

    -- Phiếu 6: Đang thuê CHƯA TRẢ (Dùng cho Yêu cầu 7)
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH26040001', 'KH000003', 'NV0001', 'CA1', '2026-11-02', 200000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH26040001', 'S_000007', 1, 0),
    ('TH26040001', 'S_000009', 1, 0);

    -- Phiếu 7: Đang thuê CHƯA TRẢ (Dùng cho Yêu cầu 7)
    INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
    VALUES ('TH26040002', 'KH000005', 'NV0002', 'CA2', '2026-11-05', 150000);
    
    INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES 
    ('TH26040002', 'S_000010', 1, 0);
END;
GO

-- 5.13. Phiếu trả sách và chi tiết trả sách
IF NOT EXISTS (SELECT 1 FROM tTraSach WHERE MaTra = 'TR25100001')
BEGIN
    -- Phiếu trả 1 (3 ngày x 3000 = 9000)
    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
    VALUES ('TR25100001', 'TH25100001', 'NV0001', '2025-10-04', 9000);
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES ('TR25100001', 'S_000001', NULL, 9000);

    -- Phiếu trả 2 (5 ngày x 6500 + phạt 15000 quá hạn + rách bìa = 65000)
    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
    VALUES ('TR25110001', 'TH25110001', 'NV0002', '2025-11-15', 65000);
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES ('TR25110001', 'S_000006', 'VP002', 65000);

    -- Phiếu trả 3 (S_000002: 5 ngày x 5000 + 30000 = 55000; S_000005: 5 ngày x 5000 + 5000 = 30000. Tổng = 85000)
    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
    VALUES ('TR25120001', 'TH25120001', 'NV0001', '2025-12-06', 85000);
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien) VALUES 
    ('TR25120001', 'S_000002', 'VP002', 55000),
    ('TR25120001', 'S_000005', 'VP005', 30000);

    -- Phiếu trả 4 (3 ngày x 3000 = 9000 + phạt 9000 = 18000)
    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
    VALUES ('TR26010001', 'TH26010001', 'NV0003', '2026-01-08', 18000);
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES ('TR26010001', 'S_000001', 'VP001', 18000);

    -- Phiếu trả 5 (8 ngày x 6000 = 48000)
    INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
    VALUES ('TR26030001', 'TH26030001', 'NV0002', '2026-03-18', 48000);
    INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
    VALUES ('TR26030001', 'S_000004', NULL, 48000);
END;
GO
