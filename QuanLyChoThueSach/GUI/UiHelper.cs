using System.Data;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

/// <summary>Các hàm giao diện dùng chung: thông báo, nạp ComboBox, định dạng lưới.</summary>
internal static class UiHelper
{
    public const string TieuDe = "Quản lý cho thuê sách truyện";
    public const string DinhDangTien = "N0";
    public const string DinhDangNgay = "dd/MM/yyyy";

    // ---- Thông báo ----

    public static void ThongBao(string noiDung) =>
        MessageBox.Show(noiDung, TieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void CanhBao(string noiDung) =>
        MessageBox.Show(noiDung, TieuDe, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static bool XacNhan(string noiDung) =>
        MessageBox.Show(noiDung, TieuDe, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    /// <summary>Lỗi nghiệp vụ hiện dạng cảnh báo; lỗi khác (mất kết nối, lỗi code...) hiện dạng lỗi.</summary>
    public static void BaoLoi(Exception ex)
    {
        if (ex is NghiepVuException)
            CanhBao(ex.Message);
        else
            MessageBox.Show("Đã xảy ra lỗi:\n" + ex.Message, TieuDe, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // ---- ComboBox ----

    /// <summary>
    /// Nạp dữ liệu cho ComboBox. Nếu <paramref name="tatCa"/> khác null, thêm dòng đầu tiên với giá trị 0
    /// (dùng cho ô tìm kiếm); đọc giá trị bằng <see cref="GiaTriInt"/>.
    /// </summary>
    public static void GanCombo(ComboBox cbo, DataTable dt, string hienThi, string giaTri, string? tatCa = null)
    {
        if (tatCa is not null)
        {
            dt = dt.Copy();
            var dong = dt.NewRow();
            dong[giaTri] = 0;
            dong[hienThi] = tatCa;
            dt.Rows.InsertAt(dong, 0);
        }

        cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        cbo.DisplayMember = hienThi;
        cbo.ValueMember = giaTri;
        cbo.DataSource = dt;
        cbo.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
    }

    /// <summary>Giá trị số của ComboBox; null nếu chưa chọn hoặc chọn dòng "Tất cả" (0).</summary>
    public static int? GiaTriInt(ComboBox cbo) =>
        cbo.SelectedValue is int v && v != 0 ? v : null;

    // ---- DataGridView ----

    public static void CauHinhLuoi(DataGridView g, bool chiDoc = true)
    {
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.AllowUserToResizeRows = false;
        g.ReadOnly = chiDoc;
        g.MultiSelect = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        g.RowHeadersVisible = false;
        g.BackgroundColor = SystemColors.Window;
        g.BorderStyle = BorderStyle.FixedSingle;
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
        g.ColumnHeadersDefaultCellStyle.Font = new Font(g.Font, FontStyle.Bold);
        g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;   // không ngắt dòng tiêu đề cột
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    }

    /// <summary>Cho cột hiển thị cuối cùng giãn hết phần chiều ngang còn lại. Gọi sau khi đã cấu hình cột.</summary>
    public static void HoanTatLuoi(DataGridView g)
    {
        var cuoi = g.Columns.Cast<DataGridViewColumn>().LastOrDefault(c => c.Visible);
        // Cột tiền căn phải: giãn ra sẽ đẩy số sát mép phải, nên chỉ giãn cột chữ.
        if (cuoi is null || cuoi.DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight) return;
        cuoi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        cuoi.MinimumWidth = 80;
    }

    /// <summary>Đặt tiêu đề/định dạng/ẩn cho một cột (bỏ qua nếu cột không tồn tại).</summary>
    public static void Cot(DataGridView g, string ten, string tieuDe, string? dinhDang = null, bool hien = true)
    {
        if (!g.Columns.Contains(ten)) return;
        var c = g.Columns[ten];
        c.HeaderText = tieuDe;
        c.Visible = hien;
        if (dinhDang is not null)
        {
            c.DefaultCellStyle.Format = dinhDang;
            if (dinhDang == DinhDangTien)
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }

    public static void AnCot(DataGridView g, params string[] ten)
    {
        foreach (var t in ten)
            if (g.Columns.Contains(t)) g.Columns[t].Visible = false;
    }
}
