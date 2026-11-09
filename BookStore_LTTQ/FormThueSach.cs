﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookStore_LTTQ
{
    public partial class FormThueSach : Form
    {
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
            cboKhachHang.DataSource = DataProcess.DocBang("SELECT MaKH, TenKH + ' (' + MaKH + ')' AS HienThi FROM tKhachHang");
            cboKhachHang.DisplayMember = "HienThi";
            cboKhachHang.ValueMember = "MaKH";

            // Nhân viên
            cboNhanVien.DataSource = DataProcess.DocBang("SELECT MaNV, TenNV + ' (' + MaNV + ')' AS HienThi FROM tNhanVien");
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "MaNV";

            // Ca làm
            cboCaLam.DataSource = DataProcess.DocBang("SELECT MaCa, TenCa FROM tCaLam");
            cboCaLam.DisplayMember = "TenCa";
            cboCaLam.ValueMember = "MaCa";

            // YÊU CẦU 1: Trong bảng Chi tiết thuê sách chỉ hiển thị các sách có số lượng > 0
            LoadSachConHang();
        }

        private void LoadSachConHang()
        {
            // Chỉ lấy các sách có SoLuong > 0 theo Yêu cầu 1
            dtSachConHang = DataProcess.DocBang("SELECT MaSach, TenSach, SoLuong, DonGiaThue FROM tSachTruyen WHERE SoLuong > 0 ORDER BY TenSach");
            
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
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(10); EXEC SP_GenerateNewMaThue @Ma OUTPUT; SELECT @Ma;");
            txtMaThue.Text = newMa != null ? newMa.ToString().Trim() : "TH" + DateTime.Now.ToString("yyMM") + "0001";
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
                dgvChiTietThue.Columns["ThanhTienTamTinh"].HeaderText = "Tiền thuê (1 ngày)";
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
            if (cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = cboSach.SelectedValue.ToString();
            int slThue = (int)numSoLuongThue.Value;

            DataRow[] found = dtSachConHang.Select("MaSach = '" + maSach + "'");
            if (found.Length == 0) return;

            string tenSach = found[0]["TenSach"].ToString();
            int tonKho = Convert.ToInt32(found[0]["SoLuong"]);
            decimal donGia = Convert.ToDecimal(found[0]["DonGiaThue"]);

            // Kiểm tra xem đã thêm sách này vào bảng chưa
            DataRow[] existed = dtChiTiet.Select("MaSach = '" + maSach + "'");
            if (existed.Length > 0)
            {
                int currentSl = Convert.ToInt32(existed[0]["SoLuong"]);
                if (currentSl + slThue > tonKho)
                {
                    MessageBox.Show("Tổng số lượng thuê (" + (currentSl + slThue) + ") vượt quá số lượng tồn kho (" + tonKho + ")!", "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                existed[0]["SoLuong"] = currentSl + slThue;
                existed[0]["ThanhTienTamTinh"] = (currentSl + slThue) * donGia;
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
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu thuê chưa có sách nào! Vui lòng chọn sách cần thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedValue == null || cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng và nhân viên lập phiếu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DataProcess.GetConnection())
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm phiếu thuê
                        string sqlThue = @"INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
                                           VALUES (@MaThue, @MaKH, @MaNV, @MaCa, @NgayThue, @TienDatCoc)";
                        using (SqlCommand cmdThue = new SqlCommand(sqlThue, conn, trans))
                        {
                            cmdThue.Parameters.AddWithValue("@MaThue", txtMaThue.Text.Trim());
                            cmdThue.Parameters.AddWithValue("@MaKH", cboKhachHang.SelectedValue.ToString());
                            cmdThue.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue.ToString());
                            cmdThue.Parameters.AddWithValue("@MaCa", cboCaLam.SelectedValue?.ToString() ?? (object)DBNull.Value);
                            cmdThue.Parameters.AddWithValue("@NgayThue", dtpNgayThue.Value.Date);
                            cmdThue.Parameters.AddWithValue("@TienDatCoc", numTienDatCoc.Value);
                            cmdThue.ExecuteNonQuery();
                        }

                        // 2. Thêm từng dòng chi tiết thuê (Trigger trg_ChiTietThue_Insert sẽ tự động trừ kho)
                        string sqlCT = @"INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra)
                                         VALUES (@MaThue, @MaSach, @SoLuong, 0)";
                        foreach (DataRow r in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaThue", txtMaThue.Text.Trim());
                                cmdCT.Parameters.AddWithValue("@MaSach", r["MaSach"].ToString());
                                cmdCT.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(r["SoLuong"]));
                                cmdCT.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show("Lập phiếu thuê sách thành công!\nSố lượng tồn kho của các sách đã được tự động cập nhật.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TaoPhieuMoi();
                        LoadSachConHang();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi khi lưu phiếu thuê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
