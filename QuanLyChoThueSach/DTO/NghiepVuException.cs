namespace QuanLyChoThueSach.DTO;

/// <summary>
/// Lỗi nghiệp vụ có thông báo thân thiện để hiển thị thẳng cho người dùng
/// (ví dụ: thiếu dữ liệu, không đủ số lượng sách, vi phạm ràng buộc khóa ngoại).
/// </summary>
public class NghiepVuException : Exception
{
    public NghiepVuException(string message) : base(message) { }
    public NghiepVuException(string message, Exception inner) : base(message, inner) { }
}
