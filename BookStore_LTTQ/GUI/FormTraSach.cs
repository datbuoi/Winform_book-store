using System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookStore_LTTQ.BLL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ
namespace BookStore_LTTQ.GUI
{
    public partial class FormTraSach : Form
    {
        private readonly ThueTraBLL _thueTraBLL = new ThueTraBLL();

        private DataTable dtChiTietTra;
        private DataTable dtSachChuaTra;
        private DateTime ngayThueGoc = DateTime.Now;

        public FormTraSach()
        {
            InitializeComponent();
            KhoiTaoBangChiTietTra();
        }

        private void KhoiTaoBangChiTietTra()
        {
            dtChiTietTra = new DataTable();
            dtChiTietTra.Columns.Add("MaSach", typeof(string));
            dtChiTietTra.Columns.Add("TenSach", typeof(string));
            dtChiTietTra.Columns.Add("SoLuong", typeof(int));
            dtChiTietTra.Columns.Add("SoNgayThue", typeof(int));
            dtChiTietTra.Columns.Add("TienThue", typeof(decimal));
            dtChiTietTra.Columns.Add("MaVP", typeof(string));
            dtChiTietTra.Columns.Add("TenViPham", typeof(string));
            dtChiTietTra.Columns.Add("TienPhat", typeof(decimal));
            dtChiTietTra.Columns.Add("ThanhTien", typeof(decimal));
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxNhanVien();
            LoadComboBoxViPham();
            LoadDanhSachPhieuThue();
            TaoPhieuMoi();
        }

        private void LoadComboBoxNhanVien()
        {
            cboNhanVien.DataSource = DataProcess.DocBang("SELECT MaNV, TenNV + ' (' + MaNV + ')' AS HienThi FROM tNhanVien");
            cboNhanVien.DataSource = _thueTraBLL.GetNhanVien();
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "MaNV";
        }

        private void LoadComboBoxViPham()
        {
            DataTable dtVP = DataProcess.DocBang("SELECT MaVP, TenVP, TienPhat FROM tViPham");
            DataTable dtVP = _thueTraBLL.GetViPham();
            DataTable dtVPHienThi = dtVP.Copy();

            DataRow r = dtVPHienThi.NewRow();
            r["MaVP"] = "";
            r["TenVP"] = "-- Không vi phạm (0 đ) --";
            r["TienPhat"] = 0;
            dtVPHienThi.Rows.InsertAt(r, 0);

            cboViPham.DataSource = dtVPHienThi;
            cboViPham.DisplayMember = "TenVP";
            cboViPham.ValueMember = "MaVP";
        }

        private void LoadDanhSachPhieuThue()
        {
            // Chỉ load các phiếu thuê đang có sách CHƯA TRẢ (DaTra = 0)
            string sql = @"SELECT DISTINCT t.MaThue, 
                                  t.MaThue + ' - ' + kh.TenKH AS HienThi,
                                  kh.TenKH, t.NgayThue
                           FROM tThueSach t
                           JOIN tKhachHang kh ON kh.MaKH = t.MaKH
                           JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue
                           WHERE ct.DaTra = 0
                           ORDER BY t.MaThue DESC";
            DataTable dt = DataProcess.DocBang(sql);
            DataTable dt = _thueTraBLL.GetDanhSachPhieuThueChuaTra();
            cboMaThue.DataSource = dt;
            cboMaThue.DisplayMember = "HienThi";
            cboMaThue.ValueMember = "MaThue";

            if (dt.Rows.Count > 0)
            {
                cboMaThue_SelectedIndexChanged(null, null);
            }
            else
            {
                txtKhachHang.Text = "";
                txtNgayThue.Text = "";
                cboSachTra.DataSource = null;
                btnThemSachTra.Enabled = false;
                btnLuuPhieuTra.Enabled = false;
            }
        }

        // YÊU CẦU 3: Khi khách hàng trả sách chỉ hiển thị các sách chưa trả từ mã thuê tương ứng
        private void cboMaThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaThue.SelectedValue == null) return;
            string maThue = cboMaThue.SelectedValue.ToString();

            // Hiển thị thông tin khách hàng và ngày thuê
            DataRowView drv = cboMaThue.SelectedItem as DataRowView;
            if (drv != null)
            {
                txtKhachHang.Text = drv["TenKH"].ToString();
                if (drv["NgayThue"] != DBNull.Value)
                {
                    ngayThueGoc = Convert.ToDateTime(drv["NgayThue"]);
                    txtNgayThue.Text = ngayThueGoc.ToString("dd/MM/yyyy");
                }
            }

            // Gọi thủ tục hoặc truy vấn chỉ lấy sách CHƯA TRẢ (DaTra = 0) từ mã thuê này
            SqlParameter[] p = { new SqlParameter("@MaThue", maThue) };
            dtSachChuaTra = DataProcess.ExecProcedure("SP_GetSachChuaTraTheoPhieu", p);
            dtSachChuaTra = _thueTraBLL.GetChiTietSachChuaTra(maThue);

            DataTable dtHienThi = dtSachChuaTra.Copy();
            dtHienThi.Columns.Add("HienThi", typeof(string));
            foreach (DataRow r in dtHienThi.Rows)
            {
                r["HienThi"] = r["TenSach"].ToString() + " (SL: " + r["SoLuong"].ToString() + ")";
            }

            cboSachTra.DataSource = dtHienThi;
            cboSachTra.DisplayMember = "HienThi";
            cboSachTra.ValueMember = "MaSach";

            if (dtHienThi.Rows.Count > 0)
            {
                btnThemSachTra.Enabled = true;
                cboSachTra_SelectedIndexChanged(null, null);
            }
            else
            {
                btnThemSachTra.Enabled = false;
                txtDonGia.Clear();
                txtSoNgayThue.Clear();
                txtThanhTien.Text = "0 đ";
            }

            // Đặt lại danh sách trả tạm
            dtChiTietTra.Clear();
            dgvChiTietTra.DataSource = dtChiTietTra;
            CapNhatTongTien();
        }

        // YÊU CẦU 4: Tính Thành tiền = Đơn giá thuê * Số ngày thuê + Tiền phạt (nếu có)
        private void TinhToanThanhTien()
        {
            if (cboSachTra.SelectedValue == null || dtSachChuaTra == null) return;
            string maSach = cboSachTra.SelectedValue.ToString();

            DataRow[] rows = dtSachChuaTra.Select("MaSach = '" + maSach + "'");
            if (rows.Length == 0) return;

            decimal donGia = Convert.ToDecimal(rows[0]["DonGiaThue"]);
            int soLuong = Convert.ToInt32(rows[0]["SoLuong"]);

            int soNgay = (dtpNgayTra.Value.Date - ngayThueGoc.Date).Days;
            if (soNgay < 1) soNgay = 1; // Thuê và trả trong ngày tính tối thiểu 1 ngày

            decimal tienPhat = 0;
            if (cboViPham.SelectedValue != null && !string.IsNullOrEmpty(cboViPham.SelectedValue.ToString()))
            {
                DataRowView drv = cboViPham.SelectedItem as DataRowView;
                if (drv != null && drv["TienPhat"] != DBNull.Value)
                {
                    tienPhat = Convert.ToDecimal(drv["TienPhat"]);
                }
            }

            decimal tienThue = donGia * soNgay * soLuong;
            decimal thanhTien = tienThue + tienPhat;

            txtSoNgayThue.Text = soNgay.ToString();
            txtDonGia.Text = donGia.ToString("N0") + " đ";
            txtTienPhat.Text = tienPhat.ToString("N0");
            txtThanhTien.Text = thanhTien.ToString("N0") + " đ";
        }

        private void cboSachTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhToanThanhTien();
        }

        private void cboViPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhToanThanhTien();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            TinhToanThanhTien();
        }

        private void btnThemSachTra_Click(object sender, EventArgs e)
        {
            if (cboSachTra.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = cboSachTra.SelectedValue.ToString();

            // Kiểm tra xem đã thêm sách này vào bảng trả chưa
            DataRow[] existed = dtChiTietTra.Select("MaSach = '" + maSach + "'");
            if (existed.Length > 0)
            {
                MessageBox.Show("Sách này đã được thêm vào danh sách trả của phiếu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow[] rows = dtSachChuaTra.Select("MaSach = '" + maSach + "'");
            if (rows.Length == 0) return;

            string tenSach = rows[0]["TenSach"].ToString();
            int soLuong = Convert.ToInt32(rows[0]["SoLuong"]);
            decimal donGia = Convert.ToDecimal(rows[0]["DonGiaThue"]);

            int soNgay = int.Parse(txtSoNgayThue.Text);
            string maVP = cboViPham.SelectedValue?.ToString();
            string tenVP = (cboViPham.SelectedItem as DataRowView)?["TenVP"].ToString();
            decimal tienPhat = decimal.Parse(txtTienPhat.Text.Replace(",", ""));
            decimal tienPhat = decimal.Parse(txtTienPhat.Text);
            decimal tienThue = donGia * soNgay * soLuong;
            decimal thanhTien = tienThue + tienPhat;

            DataRow r = dtChiTietTra.NewRow();
            r["MaSach"] = maSach;
            r["TenSach"] = tenSach;
            r["SoLuong"] = soLuong;
            r["SoNgayThue"] = soNgay;
            r["TienThue"] = tienThue;
            r["MaVP"] = maVP;
            r["TenViPham"] = string.IsNullOrEmpty(maVP) ? "Không" : tenVP;
            r["TienPhat"] = tienPhat;
            r["ThanhTien"] = thanhTien;
            dtChiTietTra.Rows.Add(r);

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in dtChiTietTra.Rows)
            {
                tong += Convert.ToDecimal(r["ThanhTien"]);
            }
            txtTongTien.Text = tong.ToString("N0") + " đ";
            btnLuuPhieuTra.Enabled = (dtChiTietTra.Rows.Count > 0);
        }

        private void btnXoaDongTra_Click(object sender, EventArgs e)
        {
            if (dgvChiTietTra.CurrentRow != null)
            {
                int idx = dgvChiTietTra.CurrentRow.Index;
                dtChiTietTra.Rows.RemoveAt(idx);
                CapNhatTongTien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TaoPhieuMoi()
        {
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(10); EXEC SP_GenerateNewMaTra @Ma OUTPUT; SELECT @Ma;");
            txtMaTra.Text = newMa != null ? newMa.ToString().Trim() : "TR" + DateTime.Now.ToString("yyMM") + "0001";
            txtMaTra.Text = _thueTraBLL.SinhMaTraMoi();
            dtpNgayTra.Value = DateTime.Now;

            dtChiTietTra.Clear();
            dgvChiTietTra.DataSource = dtChiTietTra;

            if (dgvChiTietTra.Columns.Contains("MaSach")) dgvChiTietTra.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvChiTietTra.Columns.Contains("TenSach")) dgvChiTietTra.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvChiTietTra.Columns.Contains("SoLuong")) dgvChiTietTra.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChiTietTra.Columns.Contains("SoNgayThue")) dgvChiTietTra.Columns["SoNgayThue"].HeaderText = "Số ngày thuê";
            if (dgvChiTietTra.Columns.Contains("TienThue"))
            {
                dgvChiTietTra.Columns["TienThue"].HeaderText = "Tiền thuê";
                dgvChiTietTra.Columns["TienThue"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietTra.Columns.Contains("TenViPham")) dgvChiTietTra.Columns["TenViPham"].HeaderText = "Vi phạm";
            if (dgvChiTietTra.Columns.Contains("TienPhat"))
            {
                dgvChiTietTra.Columns["TienPhat"].HeaderText = "Tiền phạt";
                dgvChiTietTra.Columns["TienPhat"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietTra.Columns.Contains("ThanhTien"))
            {
                dgvChiTietTra.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTietTra.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTietTra.Columns.Contains("MaVP")) dgvChiTietTra.Columns["MaVP"].Visible = false;

            CapNhatTongTien();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TaoPhieuMoi();
            LoadDanhSachPhieuThue();
        }

        // YÊU CẦU 2: Cập nhật lại số lượng sách trong kho & đánh dấu Đã trả
        private void btnLuuPhieuTra_Click(object sender, EventArgs e)
        {
            if (dtChiTietTra.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào được chọn để trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMaThue.SelectedValue == null || cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu thuê và nhân viên nhận trả!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = 0;
            foreach (DataRow r in dtChiTietTra.Rows)
            {
                tongTien += Convert.ToDecimal(r["ThanhTien"]);
            }

            try
            PhieuTraDTO phieu = new PhieuTraDTO
            {
                using (SqlConnection conn = DataProcess.GetConnection())
                using (SqlTransaction trans = conn.BeginTransaction())
                MaTra = txtMaTra.Text.Trim(),
                MaThue = cboMaThue.SelectedValue?.ToString(),
                MaNV = cboNhanVien.SelectedValue?.ToString(),
                NgayTra = dtpNgayTra.Value.Date,
                TongThanhToan = tongTien
            };

            foreach (DataRow r in dtChiTietTra.Rows)
            {
                phieu.DanhSachChiTiet.Add(new ChiTietTraDTO
                {
                    try
                    {
                        // 1. Thêm phiếu trả
                        string sqlTra = @"INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
                                          VALUES (@MaTra, @MaThue, @MaNV, @NgayTra, @TongTien)";
                        using (SqlCommand cmdTra = new SqlCommand(sqlTra, conn, trans))
                        {
                            cmdTra.Parameters.AddWithValue("@MaTra", txtMaTra.Text.Trim());
                            cmdTra.Parameters.AddWithValue("@MaThue", cboMaThue.SelectedValue.ToString());
                            cmdTra.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue.ToString());
                            cmdTra.Parameters.AddWithValue("@NgayTra", dtpNgayTra.Value.Date);
                            cmdTra.Parameters.AddWithValue("@TongTien", tongTien);
                            cmdTra.ExecuteNonQuery();
                        }
                    MaTra = phieu.MaTra,
                    MaSach = r["MaSach"].ToString(),
                    MaVP = r["MaVP"]?.ToString(),
                    ThanhTien = Convert.ToDecimal(r["ThanhTien"])
                });
            }

                        // 2. Thêm từng dòng chi tiết trả (Trigger trg_ChiTietTra_Insert sẽ tự động cộng tồn kho và set DaTra = 1)
                        string sqlCT = @"INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
                                         VALUES (@MaTra, @MaSach, @MaVP, @ThanhTien)";
                        foreach (DataRow r in dtChiTietTra.Rows)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaTra", txtMaTra.Text.Trim());
                                cmdCT.Parameters.AddWithValue("@MaSach", r["MaSach"].ToString());
                                string mvp = r["MaVP"]?.ToString();
                                cmdCT.Parameters.AddWithValue("@MaVP", string.IsNullOrEmpty(mvp) ? (object)DBNull.Value : mvp);
                                cmdCT.Parameters.AddWithValue("@ThanhTien", Convert.ToDecimal(r["ThanhTien"]));
                                cmdCT.ExecuteNonQuery();
                            }
                        }
            if (_thueTraBLL.LapPhieuTra(phieu, out string error))
            {
                MessageBox.Show("Lập phiếu trả sách thành công!\nTổng tiền: " + tongTien.ToString("N0") + " đ\nSố lượng tồn kho sách đã được tự động cộng lại.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        trans.Commit();
                        MessageBox.Show("Lập phiếu trả sách thành công!\nTổng tiền: " + tongTien.ToString("N0") + " đ\nSố lượng tồn kho sách đã được tự động cộng lại.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TaoPhieuMoi();
                        LoadDanhSachPhieuThue();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu phiếu trả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                TaoPhieuMoi();
                LoadDanhSachPhieuThue();
            }
            catch (Exception ex)
            else
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(error, "Lỗi khi lưu phiếu trả", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
