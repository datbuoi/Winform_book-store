using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmMain : Form
{
    /// <summary>true nếu người dùng chọn "Đăng xuất" (quay lại màn hình đăng nhập) thay vì thoát.</summary>
    public bool DangXuat { get; private set; }

    public frmMain()
    {
        InitializeComponent();
        lblNguoiDung.Text = "Người dùng: " + (AppSession.NguoiDung?.TenHienThi ?? "");
    }

    // ---- Hệ thống ----

    private void mnuDangXuat_Click(object? sender, EventArgs e)
    {
        if (!UiHelper.XacNhan("Bạn có chắc muốn đăng xuất?")) return;
        DangXuat = true;
        AppSession.NguoiDung = null;
        Close();
    }

    private void mnuThoat_Click(object? sender, EventArgs e) => Close();

    // ---- Danh mục ----

    private void mnuSachTruyen_Click(object? sender, EventArgs e) => MoForm<frmSachTruyen>();
    private void mnuNhanVien_Click(object? sender, EventArgs e) => MoForm<frmNhanVien>();

    private void mnuKhachHang_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.KhachHang);
    private void mnuTacGia_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.TacGia);
    private void mnuNXB_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.NXB);
    private void mnuLinhVuc_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.LinhVuc);
    private void mnuLoaiSach_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.LoaiSach);
    private void mnuNgonNgu_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.NgonNgu);
    private void mnuTinhTrang_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.TinhTrang);
    private void mnuCaLam_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.CaLam);
    private void mnuViPham_Click(object? sender, EventArgs e) => MoDanhMuc(DanhMucs.ViPham);

    // ---- Nghiệp vụ và báo cáo ----

    private void mnuThueSach_Click(object? sender, EventArgs e) => MoForm<frmThueSach>();
    private void mnuTraSach_Click(object? sender, EventArgs e) => MoForm<frmTraSach>();
    private void mnuBaoCao_Click(object? sender, EventArgs e) => MoForm<frmBaoCao>();

    // ---- Mở form con (mỗi loại một cửa sổ) ----

    private void MoForm<T>() where T : Form, new()
    {
        var f = MdiChildren.OfType<T>().FirstOrDefault();
        if (f is null)
        {
            f = new T { MdiParent = this };
            f.Show();
        }
        else
        {
            if (f.WindowState == FormWindowState.Minimized) f.WindowState = FormWindowState.Normal;
            f.Activate();
        }
    }

    private void MoDanhMuc(DanhMucInfo info)
    {
        var f = MdiChildren.OfType<frmDanhMuc>().FirstOrDefault(x => x.Info == info);
        if (f is null)
        {
            f = new frmDanhMuc(info) { MdiParent = this };
            f.Show();
        }
        else
        {
            if (f.WindowState == FormWindowState.Minimized) f.WindowState = FormWindowState.Normal;
            f.Activate();
        }
    }
}
