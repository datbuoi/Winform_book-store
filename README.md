# ỨNG DỤNG QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN (BookStore_LTTQ)

> **Học phần:** Lập trình trực quan (LTTQ) - Đại học Giao thông Vận tải (UTC)  
> **Nền tảng:** C# Windows Forms (.NET Framework 4.7.2) & Microsoft SQL Server  
> **Kiến trúc:** Mô hình 3 lớp chuẩn hóa (**GUI - BLL - DAL - DTO**)  

---

## 1. TỔNG QUAN HỆ THỐNG

Phần mềm **Quản lý Cửa hàng Cho Thuê Sách Truyện** được xây dựng nhằm giải quyết bài toán quản lý quy trình cho thuê sách, trả sách, kiểm soát hàng tồn kho, tính toán tiền cọc, tiền thuê, tiền phạt vi phạm và hệ thống báo cáo thống kê doanh thu đa chiều.

---

## 2. CẤU TRÚC THƯ MỤC DỰ ÁN (3-LAYER ARCHITECTURE)

Dự án được tái cấu trúc theo mô hình phân tầng chuẩn công nghiệp (3-Layer Architecture):

```text
BookStore_LTTQ/
│
├── DTO/ (Data Transfer Object - Lớp đối tượng truyền dữ liệu)
│   ├── SachDTO.cs             # Đối tượng dữ liệu Sách truyện (Mã, tên, giá, đơn giá thuê, ảnh...)
│   ├── NhanVienDTO.cs         # Đối tượng Nhân viên (Mã, tên, ca làm, lương, giới tính...)
│   ├── KhachHangDTO.cs        # Đối tượng Khách hàng
│   ├── ThueTraDTO.cs          # DTO Phiếu thuê, Chi tiết thuê, Phiếu trả, Chi tiết trả
│   └── DanhMucDTO.cs          # DTO Loại sách, Lĩnh vực, Tác giả, NXB, Ca làm, Vi phạm...
│
├── DAL/ (Data Access Layer - Tầng truy cập dữ liệu SQL Server)
│   ├── DataProcess.cs         # Lớp tiện ích ADO.NET: Kết nối CSDL, DocBang, ThucThiLenh, ExecProcedure
│   ├── SachDAL.cs             # Truy vấn CRUD, lọc sách còn hàng, tìm kiếm sách
│   ├── NhanVienDAL.cs         # Truy vấn CRUD, tìm kiếm nhân viên theo tiêu chí
│   ├── ThueTraDAL.cs          # Quản lý giao dịch (Transaction) lập phiếu thuê & phiếu trả
│   └── BaoCaoDAL.cs           # Gọi Stored Procedure & View thống kê doanh thu, top sách
│
├── BLL/ (Business Logic Layer - Tầng xử lý nghiệp vụ)
│   ├── SachBLL.cs             # Kiểm tra ràng buộc dữ liệu sách, sinh mã tự động, kiểm tra sách đã thuê
│   ├── NhanVienBLL.cs         # Validate thông tin nhân viên, năm sinh, lương tháng
│   ├── ThueTraBLL.cs          # Tính toán tiền cọc, số ngày thuê, tiền phạt, kiểm tra tồn kho
│   └── BaoCaoBLL.cs           # Xử lý tham số kỳ báo cáo (Tháng, Quý, Năm), khoảng thời gian
│
├── GUI/ (Graphical User Interface - Tầng giao diện người dùng)
│   ├── FormMain.cs/.Designer/.resx      # Giao diện chính điều hướng chức năng hệ thống
│   ├── FormSach.cs/.Designer            # Quản lý Sách truyện, tìm kiếm & chọn ảnh bìa
│   ├── FormNhanVien.cs/.Designer        # Quản lý Nhân viên & tìm kiếm nhân viên
│   ├── FormThueSach.cs/.Designer        # Lập phiếu thuê sách (ràng buộc tồn kho > 0)
│   ├── FormTraSach.cs/.Designer         # Lập phiếu trả sách (chỉ hiện sách chưa trả, tính phạt)
│   └── FormBaoCao.cs/.Designer          # Báo cáo thống kê: Chưa trả, Doanh thu, Top 5
│
├── Properties/                # AssemblyInfo, Resources, Settings
├── App.config                 # Cấu hình chuỗi kết nối Database SQL Server
├── Program.cs                 # Điểm khởi chạy ứng dụng (Main Entry Point)
└── BookStore_LTTQ.csproj      # File project MSBuild C#
```

---

## 3. CƠ SỞ DỮ LIỆU (QLChoThueSach)

Hệ thống sử dụng cơ sở dữ liệu Microsoft SQL Server với 15 bảng theo chuẩn thiết kế:

1. **`tSachTruyen`**: Thông tin sách truyện, số lượng tồn kho, đơn giá thuê, giá bán, ảnh bìa.
2. **`tLoaiSach`**: Danh mục thể loại sách.
3. **`tLinhVuc`**: Danh mục lĩnh vực (Khoa học, Văn học, CNTT...).
4. **`tTacGia`**: Danh sách tác giả.
5. **`tNXB`**: Nhà xuất bản.
6. **`tNgonNgu`**: Ngôn ngữ sách.
7. **`tTinhTrang`**: Tình trạng vật lý sách (Mới 100%, 90%, Cũ...).
8. **`tKhachHang`**: Khách hàng thuê sách.
9. **`tNhanVien`**: Nhân viên cửa hàng.
10. **`tCaLam`**: Ca làm việc của nhân viên.
11. **`tViPham`**: Các lỗi vi phạm (Trả muộn, Rách trang, Mất sách...) và mức tiền phạt.
12. **`tThueSach`**: Thông tin phiếu thuê, ngày thuê, tiền đặt cọc.
13. **`tChiTietThueSach`**: Chi tiết các cuốn sách trong phiếu thuê, cờ `DaTra`.
14. **`tTraSach`**: Thông tin phiếu trả, ngày trả, tổng tiền thanh toán.
15. **`tChiTietTraSach`**: Chi tiết trả từng cuốn sách, vi phạm và thành tiền.

### Các Trigger & Stored Procedure cốt lõi:
- **`trg_ChiTietThue_Insert`**: Tự động trừ số lượng tồn kho trong `tSachTruyen` khi lập phiếu thuê.
- **`trg_ChiTietTra_Insert`**: Tự động cộng lại số lượng tồn kho và cập nhật `DaTra = 1` trong chi tiết thuê.
- **`SP_GenerateNewMaSach`**, **`SP_GenerateNewMaNV`**, **`SP_GenerateNewMaThue`**, **`SP_GenerateNewMaTra`**: Tự động sinh mã khóa chính liên tục.
- **`SP_TimSach`**: Tìm kiếm sách động theo Tên, Lĩnh vực, Tác giả, NXB.
- **`SP_TimNhanVien`**: Tìm kiếm nhân viên theo Tên, Ca làm, Giới tính.
- **`SP_GetSachChuaTraTheoPhieu`**: Lọc chính xác các cuốn sách chưa trả của phiếu thuê.
- **`SP_DoanhThu`**: Báo cáo tổng tiền cho thuê theo Tháng / Quý / Năm.
- **`SP_Top5SachDoanhThu`**: Báo cáo top 5 sách truyện mang lại doanh thu cao nhất.
- **`vw_SachDangThueChuaTra`**: View tổng hợp theo dõi sách đang mượn quá hạn hoặc chưa trả.

---

## 4. ĐÁP ỨNG ĐẦY ĐỦ 9 YÊU CẦU NGHIỆP VỤ ĐỀ BÀI

| STT | Yêu cầu nghiệp vụ | Triển khai trong code |
|:---:|:---|:---|
| **YC1** | Trong bảng Chi tiết thuê sách chỉ hiển thị các sách có số lượng > 0 | `SachDAL.GetSachConHang()` lọc `WHERE SoLuong > 0`, combobox chọn sách tự động ẩn sách hết hàng. |
| **YC2** | Khi khách thuê sách cập nhật lại Số lượng trong bảng Sách; khi trả cập nhật lại kho và đánh dấu đã trả | `SqlTransaction` kết hợp Trigger `trg_ChiTietThue_Insert` & `trg_ChiTietTra_Insert` đảm bảo toàn vẹn dữ liệu. |
| **YC3** | Khi khách hàng trả sách chỉ hiển thị các sách chưa trả từ mã thuê tương ứng | `ThueTraDAL.GetChiTietSachChuaTra(maThue)` gọi `SP_GetSachChuaTraTheoPhieu` lọc `DaTra = 0`. |
| **YC4** | Thành tiền = Tiền thuê + Tiền phạt (nếu có); Tiền thuê = Số ngày * Đơn giá thuê * Số lượng | Hàm `TinhToanThanhTien()` trong `FormTraSach.cs` tự động tính số ngày thuê và mức phạt vi phạm. |
| **YC5** | Tìm kiếm Sách truyện theo các tiêu chí: Tên sách, Lĩnh vực, Tác giả, NXB | Form `FormSach.cs` tích hợp khu vực tìm kiếm đa tiêu chí qua `SP_TimSach`. |
| **YC6** | Tìm kiếm Nhân viên theo các tiêu chí: Tên nhân viên, Ca làm, Giới tính | Form `FormNhanVien.cs` tìm kiếm qua `SP_TimNhanVien`. |
| **YC7** | Báo cáo danh sách các sách truyện đang được thuê chưa trả | Tab 1 trong `FormBaoCao.cs` truy vấn từ `vw_SachDangThueChuaTra`, tính tổng số lượng và tiền thuê tạm tính. |
| **YC8** | Báo cáo tổng tiền cho thuê thu được theo Tháng, Quý, Năm | Tab 2 trong `FormBaoCao.cs` linh hoạt chọn loại kỳ qua radio button và Stored Procedure `SP_DoanhThu`. |
| **YC9** | Báo cáo danh sách 5 sách truyện đạt doanh thu nhiều nhất theo khoảng thời gian | Tab 3 trong `FormBaoCao.cs` lọc theo `Từ ngày - Đến ngày` qua `SP_Top5SachDoanhThu`. |

---

## 5. HƯỚNG DẪN CÀI ĐẶT & CHẠY ỨNG DỤNG

### Bước 1: Khởi tạo Cơ sở dữ liệu SQL Server
1. Mở **SQL Server Management Studio (SSMS)**.
2. Kết nối tới server (mặc định: `.\SQLEXPRESS` hoặc `localhost`).
3. Mở file [QLChoThueSach.sql](file:///d:/lmd/nam3/lttq/Winform_book-store/QLChoThueSach.sql) và nhấn **Execute (F5)** để tạo CSDL và nạp dữ liệu mẫu hoàn chỉnh.

### Bước 2: Cấu hình kết nối (App.config)
Kiểm tra file `BookStore_LTTQ/App.config`:
```xml
<connectionStrings>
    <add name="QLChoThueSachConnectionString" 
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=QLChoThueSach;Integrated Security=True;TrustServerCertificate=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```
*(Nếu sử dụng tài khoản SQL Server Authentication, thay bằng `User ID=...;Password=...`)*.

### Bước 3: Mở và Chạy dự án
- Mở file solution `BookStore_LTTQ.slnx` bằng **Visual Studio 2022**.
- Nhấn tổ hợp phím **Ctrl + Shift + B** để Build dự án (**0 Error, 0 Warning**).
- Nhấn **F5** để khởi chạy ứng dụng.

---

## 6. THÔNG TIN BẢN QUYỀN
- Đề tài Bài tập lớn môn **Lập trình trực quan (LTTQ)**.
- Trường Đại học Giao thông Vận tải (UTC).

