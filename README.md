# Quản lý cửa hàng cho thuê sách truyện

Ứng dụng WinForms (C#, .NET 8) chia 3 tầng DAL, BLL, GUI, dùng SQL Server.

## Yêu cầu cài đặt

- Windows 10/11
- Visual Studio 2022 (bản 17.8 trở lên) có workload **".NET desktop development"**
- Một SQL Server bất kỳ: LocalDB, SQL Server Express hoặc bản đầy đủ
- SQL Server Management Studio (SSMS) để chạy file SQL
- Có mạng trong lần build đầu tiên (để tải gói NuGet `Microsoft.Data.SqlClient` và `QuestPDF`)

## Cách chạy

### Bước 1: Tạo CSDL

1. Mở SSMS và kết nối vào SQL Server của bạn.
2. Mở file `QuanLyChoThueSach/CuaHangChoThueSach.sql` (**File → Open → File**).
3. Bấm **Execute** (F5).
4. Bấm chuột phải mục **Databases** rồi chọn **Refresh**. Bạn sẽ thấy CSDL `QuanLyChoThueSach`.

Lưu ý: script xóa các bảng cùng tên nếu đã có, nên chỉ chạy khi muốn đặt lại dữ liệu mẫu.

### Bước 2: Sửa chuỗi kết nối

Mở `QuanLyChoThueSach/GUI/appsettings.json` và sửa phần `Server=` cho đúng với máy bạn.
Tên server chính là ô **Server name** trong cửa sổ đăng nhập SSMS.

| Bạn dùng | Ghi trong file |
|---|---|
| LocalDB (mặc định) | `Server=(localdb)\\MSSQLLocalDB` |
| SQL Server Express | `Server=.\\SQLEXPRESS` |
| SQL Server khác | `Server=TEN_MAY\\TEN_INSTANCE` |

Trong file JSON phải viết **hai dấu `\\`**. Ví dụ đầy đủ:

```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=QuanLyChoThueSach;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

Nếu đăng nhập SQL Server bằng tài khoản `sa` (SQL Authentication), thay `Integrated Security=True`
bằng `User Id=sa;Password=MAT_KHAU_CUA_BAN`.

### Bước 3: Chạy chương trình

1. Mở `QuanLyChoThueSach/QuanLyChoThueSach.sln` bằng Visual Studio.
2. Trong Solution Explorer, bấm chuột phải project **QuanLyChoThueSach.GUI** rồi chọn **Set as Startup Project**.
3. Nhấn **Ctrl+Shift+B** để build, rồi nhấn **F5** để chạy.

Hoặc chạy bằng dòng lệnh:

```powershell
cd QuanLyChoThueSach
dotnet run --project GUI
```

### Bước 4: Đăng nhập

| Tên đăng nhập | Mật khẩu |
|---|---|
| `nv_an` | `admin123` |
| `nv_hoa` | `nhanvien123` |

Mật khẩu trong CSDL được lưu dưới dạng mã băm (SHA-256 kèm salt), không lưu chữ gốc.

## Lỗi thường gặp

| Thông báo | Cách xử lý |
|---|---|
| `The specified LocalDB instance does not exist` hoặc không tìm thấy server | Sai tên server trong `appsettings.json`. Với LocalDB phải bắt đầu bằng `(localdb)`, không đổi thành `localhost`. Nếu máy chưa có LocalDB, cài SQL Server Express rồi dùng `.\\SQLEXPRESS`. |
| `Cannot open database "QuanLyChoThueSach"` | Chưa chạy file SQL ở Bước 1. |
| Sửa `appsettings.json` nhưng chương trình vẫn dùng cấu hình cũ | Cần build lại (Ctrl+Shift+B). Chương trình đọc bản sao trong `GUI/bin/Debug/net8.0-windows/`. |
| Lỗi `NU1101`/không tải được gói NuGet | Kiểm tra kết nối mạng rồi build lại; trong Visual Studio chọn **Tools → NuGet Package Manager → Restore**. |
| Không mở được project do thiếu .NET 8 | Cài **.NET 8 SDK** (đi kèm workload ".NET desktop development"). |

Kiểm tra LocalDB trong PowerShell: `sqllocaldb info` (phải thấy `MSSQLLocalDB`), nếu chưa có thì chạy
`sqllocaldb create MSSQLLocalDB` rồi `sqllocaldb start MSSQLLocalDB`.

## Cấu trúc dự án

```
QuanLyChoThueSach/
├── CuaHangChoThueSach.sql    Script tạo CSDL, bảng và dữ liệu mẫu
├── QuanLyChoThueSach.sln
├── DTO/   Các lớp dữ liệu dùng chung giữa các tầng
├── DAL/   Truy cập SQL Server (câu lệnh SQL, giao dịch)
├── BLL/   Nghiệp vụ: kiểm tra dữ liệu, tính thành tiền, đăng nhập, xuất PDF
└── GUI/   Giao diện WinForms (mỗi form gồm .cs và .Designer.cs)
```

## Chức năng chính

- Đăng nhập, danh mục (sách truyện, nhân viên, khách hàng, tác giả, NXB, lĩnh vực, loại sách, ngôn ngữ, tình trạng, ca làm, vi phạm)
- Thuê sách: chỉ hiện sách còn trong kho, tự trừ số lượng
- Trả sách: chỉ hiện sách chưa trả của phiếu thuê, tính thành tiền = đơn giá thuê × số lượng + tiền phạt, tự cộng lại kho
- Tìm kiếm sách (tên, lĩnh vực, tác giả, NXB) và nhân viên (tên, ca làm, giới tính)
- Báo cáo (có nút **Xuất PDF**): sách đang thuê chưa trả, tiền thuê theo tháng/quý/năm, top 5 sách doanh thu cao nhất
