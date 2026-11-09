using System;
using System.Data;
using System.Windows.Forms;
using BookStore_LTTQ.BLL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.GUI
{
    public partial class FormThueSach : Form
    {
        private readonly ThueTraBLL _thueTraBLL = new ThueTraBLL();
        private readonly SachBLL _sachBLL = new SachBLL();

        private DataTable dtChiTiet;
        private DataTable dtSachConHang;

        public FormThueSach()
        {
            InitializeComponent();
            KhoiTaoBangChiTiet();
        }

        private void KhoiTaoBangChiTiet()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaSach", typeof(string));
            dtChiTiet.Columns.Add("TenSach", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("DonGiaThue", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTienTamTinh", typeof(decimal));
        }

        private void FormThueSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            TaoPhieuMoi();
        }

        private void LoadComboBoxes()
        {
            // Khách hàng
            cboKhachHang.DataSource = _thueTraBLL.GetKhachHang();
            cboKhachHang.DisplayMember = "HienThi";
            cboKhachHang.ValueMember = "MaKH";

            // Nhân viên
            cboNhanVien.DataSource = _thueTraBLL.GetNhanVien();
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "MaNV";

            // Ca làm
            cboCaLam.DataSource = _thueTraBLL.GetCaLam();
            cboCaLam.DisplayMember = "TenCa";
            cboCaLam.ValueMember = "MaCa";

            // YÊU CẦU 1: Trong bảng Chi tiết thuê sách chỉ hiển thị các sách có số lượng > 0
            LoadSachConHang();
        }

        private void LoadSachConHang()
        {
            dtSachConHang = _sachBLL.GetSachConHang();
            
            DataTable dtHienThi = dtSachConHang.Copy();
            dtHienThi.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in dtHienThi.Rows)
            {
                r["HienThi"] = r["TenSach"].ToString() + " (Còn: " + r["SoLuong"].ToString() + ")";
            }

            cboSach.DataSource = dtHienThi;
            cboSach.DisplayMember = "HienThi";
            cboSach.ValueMember = "MaSach";

            if (dtHienThi.Rows.Count > 0)
            {
                cboSach_SelectedIndexChanged(null, null);
            }
            else
            {
                lblTonKho.Text = "Tồn kho: HẾT HÀNG";
                lblDonGia.Text = "Đơn giá: 0 đ/ngày";
                btnThemSach.Enabled = false;
            }
        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue == null) return;
            string maSach = cboSach.SelectedValue.ToString();

            DataRow[] found = dtSachConHang.Select("MaSach = '" + maSach + "'");
            if (found.Length > 0)
            {
                int tonKho = Convert.ToInt32(found[0]["SoLuong"]);
                decimal donGia = Convert.ToDecimal(found[0]["DonGiaThue"]);

                lblTonKho.Text = "Tồn kho: " + tonKho.ToString();
                lblDonGia.Text = "Đơn giá: " + donGia.ToString("N0") + " đ/ngày";
                numSoLuongThue.Maximum = tonKho;
                numSoLuongThue.Value = 1;
                btnThemSach.Enabled = (tonKho > 0);
            }
        }

        private void TaoPhieuMoi()
        {
            txtMaThue.Text = _thueTraBLL.SinhMaThueMoi();
            dtpNgayThue.Value = DateTime.Now;
            numTienDatCoc.Value = 100000;

            dtChiTiet.Clear();
            dgvChiTietThue.DataSource = dtChiTiet;

            if (dgvChiTietThue.Columns.Contains("MaSach")) dgvChiTietThue.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvChiTietThue.Columns.Contains("TenSach")) dgvChiTietThue.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvChiTietThue.Columns.Contains("SoLuong")) dgvChiTietThue.Columns["SoLuong"].HeaderText = "Số lượng thuê";
            if (dgvChiTietThue.Columns.Contains("DonGiaThue"))
            {
                dgvChiTietThue.Columns["DonGiaThue"].HeaderText = "Đơn giá thuê (đ/ngày)";
                dgvChiTietThue.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietThue.Columns.Contains("ThanhTienTamTinh"))
            {
                dgvChiTietThue.Columns["ThanhTienTamTinh"].HeaderText = "Tiền thuê/ngày";
                dgvChiTietThue.Columns["ThanhTienTamTinh"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TaoPhieuMoi();
            LoadSachConHang();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue == null) return;
            string maSach = cboSach.SelectedValue.ToString();
            int slThue = (int)numSoLuongThue.Value;

            DataRow[] foundStock = dtSachConHang.Select("MaSach = '" + maSach + "'");
            if (foundStock.Length == 0) return;
            int tonKho = Convert.ToInt32(foundStock[0]["SoLuong"]);
            string tenSach = foundStock[0]["TenSach"].ToString();
            decimal donGia = Convert.ToDecimal(foundStock[0]["DonGiaThue"]);

            DataRow[] existing = dtChiTiet.Select("MaSach = '" + maSach + "'");
            if (existing.Length > 0)
            {
                int currentSL = Convert.ToInt32(existing[0]["SoLuong"]);
                if (currentSL + slThue > tonKho)
                {
                    MessageBox.Show("Tổng số lượng thuê vượt quá tồn kho hiện có (" + tonKho + " cuốn)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existing[0]["SoLuong"] = currentSL + slThue;
                existing[0]["ThanhTienTamTinh"] = (currentSL + slThue) * donGia;
            }
            else
            {
                DataRow r = dtChiTiet.NewRow();
                r["MaSach"] = maSach;
                r["TenSach"] = tenSach;
                r["SoLuong"] = slThue;
                r["DonGiaThue"] = donGia;
                r["ThanhTienTamTinh"] = slThue * donGia;
                dtChiTiet.Rows.Add(r);
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTietThue.CurrentRow != null)
            {
                int idx = dgvChiTietThue.CurrentRow.Index;
                dtChiTiet.Rows.RemoveAt(idx);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sách cần xóa khỏi phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // YÊU CẦU 2: Khi khách hàng thuê sách thì cập nhật lại Số lượng sách trong bảng Sách truyện
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            PhieuThueDTO phieu = new PhieuThueDTO
            {
                MaThue = txtMaThue.Text.Trim(),
                MaKH = cboKhachHang.SelectedValue?.ToString(),
                MaNV = cboNhanVien.SelectedValue?.ToString(),
                MaCa = cboCaLam.SelectedValue?.ToString(),
                NgayThue = dtpNgayThue.Value.Date,
                TienDatCoc = numTienDatCoc.Value
            };

            foreach (DataRow r in dtChiTiet.Rows)
            {
                phieu.DanhSachChiTiet.Add(new ChiTietThueDTO
                {
                    MaThue = phieu.MaThue,
                    MaSach = r["MaSach"].ToString(),
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    DonGiaThue = Convert.ToDecimal(r["DonGiaThue"])
                });
            }

            if (_thueTraBLL.LapPhieuThue(phieu, out string error))
            {
                MessageBox.Show("Lập phiếu thuê sách thành công!\nSố lượng tồn kho của các sách đã được tự động cập nhật.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaoPhieuMoi();
                LoadSachConHang();
            }
            else
            {
                MessageBox.Show(error, "Lỗi lập phiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
