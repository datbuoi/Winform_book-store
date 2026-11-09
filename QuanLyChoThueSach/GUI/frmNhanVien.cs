using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmNhanVien : Form
{
    private int _maNVDangChon;   // 0 = chưa chọn dòng nào

    public frmNhanVien()
    {
        InitializeComponent();
    }

    private void frmNhanVien_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        try
        {
            UiHelper.CauHinhLuoi(dgv);
            UiHelper.GanCombo(cboTimCa, DanhMucBLL.LayTatCa(DanhMucs.CaLam), "TenCa", "MaCa", "(Tất cả)");
            cboTimGioiTinh.SelectedIndex = 0;
            TimKiem();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    // ---- Tìm kiếm / lưới ----

    private void TimKiem(int? chonMa = null)
    {
        var gioiTinh = cboTimGioiTinh.SelectedIndex > 0 ? cboTimGioiTinh.SelectedItem as string : null;
        var dt = NhanVienBLL.Tim(txtTimTen.Text, UiHelper.GiaTriInt(cboTimCa), gioiTinh);

        dgv.DataSource = dt;
        grpTim.Text = $"Tìm kiếm ({dt.Rows.Count} kết quả)";

        UiHelper.Cot(dgv, "MaNV", "Mã NV");
        UiHelper.Cot(dgv, "TenNV", "Tên nhân viên");
        UiHelper.Cot(dgv, "NamSinh", "Năm sinh");
        UiHelper.Cot(dgv, "GioiTinh", "Giới tính");
        UiHelper.Cot(dgv, "DiaChi", "Địa chỉ");
        UiHelper.Cot(dgv, "DienThoai", "Điện thoại");
        UiHelper.Cot(dgv, "LuongThang", "Lương tháng", UiHelper.DinhDangTien);
        UiHelper.HoanTatLuoi(dgv);

        if (chonMa is { } ma)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.DataBoundItem is DataRowView v && (int)v["MaNV"] == ma)
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
        cboTimCa.SelectedIndex = 0;
        cboTimGioiTinh.SelectedIndex = 0;
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
        _maNVDangChon = (int)r["MaNV"];
        txtMa.Text = _maNVDangChon.ToString();
        txtTen.Text = (string)r["TenNV"];
        nudNamSinh.Value = r["NamSinh"] is int nam ? nam : 0;
        cboGioiTinh.SelectedItem = r["GioiTinh"] as string;
        txtDiaChi.Text = r["DiaChi"] as string ?? "";
        txtDienThoai.Text = r["DienThoai"] as string ?? "";
        nudLuong.Value = r["LuongThang"] is decimal luong ? luong : 0;
    }

    private void NhapMoi()
    {
        _maNVDangChon = 0;
        txtMa.Clear();
        txtTen.Clear();
        nudNamSinh.Value = 0;
        cboGioiTinh.SelectedIndex = -1;
        txtDiaChi.Clear();
        txtDienThoai.Clear();
        nudLuong.Value = 0;
    }

    private NhanVienDTO LayTuForm() => new()
    {
        MaNV = _maNVDangChon,
        TenNV = txtTen.Text,
        NamSinh = nudNamSinh.Value == 0 ? null : (int)nudNamSinh.Value,
        GioiTinh = cboGioiTinh.SelectedItem as string,
        DiaChi = txtDiaChi.Text,
        DienThoai = txtDienThoai.Text,
        LuongThang = nudLuong.Value
    };

    // ---- Nút chức năng ----

    private void btnThem_Click(object? sender, EventArgs e)
    {
        try
        {
            var ma = NhanVienBLL.Them(LayTuForm());
            TimKiem(ma);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (_maNVDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một nhân viên trong danh sách để sửa.");
            return;
        }
        try
        {
            NhanVienBLL.Sua(LayTuForm());
            TimKiem(_maNVDangChon);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (_maNVDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một nhân viên trong danh sách để xóa.");
            return;
        }
        if (!UiHelper.XacNhan("Bạn có chắc muốn xóa nhân viên đang chọn?")) return;
        try
        {
            NhanVienBLL.Xoa(_maNVDangChon);
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
