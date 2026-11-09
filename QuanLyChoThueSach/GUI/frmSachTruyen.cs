using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmSachTruyen : Form
{
    private int _maSachDangChon;   // 0 = chưa chọn dòng nào

    public frmSachTruyen()
    {
        InitializeComponent();
    }

    private void frmSachTruyen_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        try
        {
            UiHelper.CauHinhLuoi(dgv);
            NapDanhMuc();
            TimKiem();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void NapDanhMuc()
    {
        var loai = DanhMucBLL.LayTatCa(DanhMucs.LoaiSach);
        var linhVuc = DanhMucBLL.LayTatCa(DanhMucs.LinhVuc);
        var tacGia = DanhMucBLL.LayTatCa(DanhMucs.TacGia);
        var nxb = DanhMucBLL.LayTatCa(DanhMucs.NXB);
        var ngonNgu = DanhMucBLL.LayTatCa(DanhMucs.NgonNgu);
        var tinhTrang = DanhMucBLL.LayTatCa(DanhMucs.TinhTrang);

        // Ô nhập liệu
        UiHelper.GanCombo(cboLoai, loai, "TenLoai", "MaLoaiSach");
        UiHelper.GanCombo(cboLinhVuc, linhVuc, "TenLinhVuc", "MaLinhVuc");
        UiHelper.GanCombo(cboTacGia, tacGia, "TenTG", "MaTG");
        UiHelper.GanCombo(cboNXB, nxb, "TenNXB", "MaNXB");
        UiHelper.GanCombo(cboNgonNgu, ngonNgu, "TenNgonNgu", "MaNgonNgu");
        UiHelper.GanCombo(cboTinhTrang, tinhTrang, "TenTinhTrang", "MaTinhTrang");

        // Ô tìm kiếm (có dòng "Tất cả"; GanCombo tự sao chép bảng nên không bị đồng bộ lựa chọn với ô nhập liệu)
        UiHelper.GanCombo(cboTimLinhVuc, linhVuc, "TenLinhVuc", "MaLinhVuc", "(Tất cả)");
        UiHelper.GanCombo(cboTimTacGia, tacGia, "TenTG", "MaTG", "(Tất cả)");
        UiHelper.GanCombo(cboTimNXB, nxb, "TenNXB", "MaNXB", "(Tất cả)");
    }

    // ---- Tìm kiếm / lưới ----

    private void TimKiem(int? chonMa = null)
    {
        var dt = SachTruyenBLL.Tim(
            txtTimTen.Text,
            UiHelper.GiaTriInt(cboTimLinhVuc),
            UiHelper.GiaTriInt(cboTimTacGia),
            UiHelper.GiaTriInt(cboTimNXB));

        dgv.DataSource = dt;
        grpTim.Text = $"Tìm kiếm ({dt.Rows.Count} kết quả)";

        UiHelper.Cot(dgv, "MaSach", "Mã sách");
        UiHelper.Cot(dgv, "TenSach", "Tên sách");
        UiHelper.Cot(dgv, "TenLinhVuc", "Lĩnh vực");
        UiHelper.Cot(dgv, "TenTG", "Tác giả");
        UiHelper.Cot(dgv, "TenNXB", "NXB");
        UiHelper.Cot(dgv, "TenLoai", "Loại sách");
        UiHelper.Cot(dgv, "TenNgonNgu", "Ngôn ngữ");
        UiHelper.Cot(dgv, "SoTrang", "Số trang");
        UiHelper.Cot(dgv, "GiaSach", "Giá sách", UiHelper.DinhDangTien);
        UiHelper.Cot(dgv, "DonGiaThue", "Đơn giá thuê", UiHelper.DinhDangTien);
        UiHelper.Cot(dgv, "TenTinhTrang", "Tình trạng");
        UiHelper.Cot(dgv, "SoLuong", "Số lượng");
        UiHelper.Cot(dgv, "GhiChu", "Ghi chú");
        UiHelper.AnCot(dgv, "Anh", "MaLoaiSach", "MaLinhVuc", "MaTG", "MaNXB", "MaNgonNgu", "MaTinhTrang");
        UiHelper.HoanTatLuoi(dgv);

        if (chonMa is { } ma)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.DataBoundItem is DataRowView v && (int)v["MaSach"] == ma)
                {
                    r.Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = r.Index;
                    return;
                }
            }
        }
        dgv.ClearSelection();
        NhapMoi();
    }

    private void btnTim_Click(object? sender, EventArgs e)
    {
        try { TimKiem(); }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void txtTimTen_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        btnTim_Click(sender, e);
    }

    private void btnHuyLoc_Click(object? sender, EventArgs e)
    {
        txtTimTen.Clear();
        cboTimLinhVuc.SelectedIndex = 0;
        cboTimTacGia.SelectedIndex = 0;
        cboTimNXB.SelectedIndex = 0;
        btnTim_Click(sender, e);
    }

    private void dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].DataBoundItem is DataRowView v)
            DoVaoForm(v.Row);
        else
            NhapMoi();
    }

    // ---- Ô nhập liệu ----

    private void DoVaoForm(DataRow r)
    {
        _maSachDangChon = (int)r["MaSach"];
        txtMa.Text = _maSachDangChon.ToString();
        txtTen.Text = (string)r["TenSach"];
        cboLoai.SelectedValue = (int)r["MaLoaiSach"];
        cboLinhVuc.SelectedValue = (int)r["MaLinhVuc"];
        cboTacGia.SelectedValue = (int)r["MaTG"];
        cboNXB.SelectedValue = (int)r["MaNXB"];
        cboNgonNgu.SelectedValue = (int)r["MaNgonNgu"];
        cboTinhTrang.SelectedValue = (int)r["MaTinhTrang"];
        nudSoTrang.Value = r["SoTrang"] is int trang ? trang : 0;
        nudGiaSach.Value = (decimal)r["GiaSach"];
        nudDonGiaThue.Value = (decimal)r["DonGiaThue"];
        nudSoLuong.Value = (int)r["SoLuong"];
        txtAnh.Text = r["Anh"] as string ?? "";
        txtGhiChu.Text = r["GhiChu"] as string ?? "";
        HienAnh(txtAnh.Text);
    }

    private void NhapMoi()
    {
        _maSachDangChon = 0;
        txtMa.Clear();
        txtTen.Clear();
        foreach (var cbo in new[] { cboLoai, cboLinhVuc, cboTacGia, cboNXB, cboNgonNgu, cboTinhTrang })
            cbo.SelectedIndex = -1;
        nudSoTrang.Value = 0;
        nudGiaSach.Value = 0;
        nudDonGiaThue.Value = 0;
        nudSoLuong.Value = 0;
        txtAnh.Clear();
        txtGhiChu.Clear();
        HienAnh(null);
    }

    private SachTruyenDTO LayTuForm() => new()
    {
        MaSach = _maSachDangChon,
        TenSach = txtTen.Text,
        MaLoaiSach = UiHelper.GiaTriInt(cboLoai) ?? 0,
        MaLinhVuc = UiHelper.GiaTriInt(cboLinhVuc) ?? 0,
        MaTG = UiHelper.GiaTriInt(cboTacGia) ?? 0,
        MaNXB = UiHelper.GiaTriInt(cboNXB) ?? 0,
        MaNgonNgu = UiHelper.GiaTriInt(cboNgonNgu) ?? 0,
        MaTinhTrang = UiHelper.GiaTriInt(cboTinhTrang) ?? 0,
        SoTrang = nudSoTrang.Value == 0 ? null : (int)nudSoTrang.Value,
        GiaSach = nudGiaSach.Value,
        DonGiaThue = nudDonGiaThue.Value,
        SoLuong = (int)nudSoLuong.Value,
        Anh = txtAnh.Text,
        GhiChu = txtGhiChu.Text
    };

    private void HienAnh(string? duongDan)
    {
        picAnh.Image?.Dispose();
        picAnh.Image = null;
        if (string.IsNullOrWhiteSpace(duongDan) || !File.Exists(duongDan)) return;
        try
        {
            // Đọc vào bộ nhớ để không khóa file ảnh.
            using var fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var img = Image.FromStream(fs);
            picAnh.Image = new Bitmap(img);
        }
        catch (Exception)
        {
            // File không phải ảnh hợp lệ: bỏ qua, chỉ không hiển thị.
        }
    }

    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Chọn ảnh bìa",
            Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả|*.*"
        };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        txtAnh.Text = dlg.FileName;
        HienAnh(dlg.FileName);
    }

    // ---- Nút chức năng ----

    private void btnThem_Click(object? sender, EventArgs e)
    {
        try
        {
            var ma = SachTruyenBLL.Them(LayTuForm());
            TimKiem(ma);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (_maSachDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một sách trong danh sách để sửa.");
            return;
        }
        try
        {
            SachTruyenBLL.Sua(LayTuForm());
            TimKiem(_maSachDangChon);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (_maSachDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một sách trong danh sách để xóa.");
            return;
        }
        if (!UiHelper.XacNhan("Bạn có chắc muốn xóa sách đang chọn?")) return;
        try
        {
            SachTruyenBLL.Xoa(_maSachDangChon);
            TimKiem();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnNhapMoi_Click(object? sender, EventArgs e)
    {
        dgv.ClearSelection();
        NhapMoi();
    }
}
