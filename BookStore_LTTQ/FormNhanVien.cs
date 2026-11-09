﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookStore_LTTQ
{
    public partial class FormNhanVien : Form
    {
        private bool isThemMoi = false;

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadDataNhanVien();
            SetButtonState(true);
            LockInputs(true);
        }

        private void LoadComboBoxes()
        {
            cboGioiTinh.SelectedIndex = 0;

            DataTable dtCa = DataProcess.DocBang("SELECT MaCa, TenCa FROM tCaLam");
            DataTable dtCaTim = dtCa.Copy();
            DataRow r = dtCaTim.NewRow();
            r["MaCa"] = "";
            r["TenCa"] = "-- Tất cả ca làm --";
            dtCaTim.Rows.InsertAt(r, 0);

            cboTimCaLam.DataSource = dtCaTim;
            cboTimCaLam.DisplayMember = "TenCa";
            cboTimCaLam.ValueMember = "MaCa";

            cboTimGioiTinh.SelectedIndex = 0;
        }

        private void LoadDataNhanVien(string query = null, SqlParameter[] sqlParams = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                query = @"SELECT MaNV, TenNV, NamSinh, 
                                 CASE WHEN GioiTinh = 'M' THEN N'Nam' ELSE N'Nữ' END AS GioiTinhHienThi,
                                 GioiTinh, DiaChi, DienThoai, LuongThang
                          FROM tNhanVien";
            }

            DataTable dt = DataProcess.DocBang(query, sqlParams);
            dgvNhanVien.DataSource = dt;

            if (dgvNhanVien.Columns.Contains("MaNV")) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns.Contains("TenNV")) dgvNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            if (dgvNhanVien.Columns.Contains("NamSinh")) dgvNhanVien.Columns["NamSinh"].HeaderText = "Năm sinh";
            if (dgvNhanVien.Columns.Contains("GioiTinhHienThi")) dgvNhanVien.Columns["GioiTinhHienThi"].HeaderText = "Giới tính";
            if (dgvNhanVien.Columns.Contains("DiaChi")) dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            if (dgvNhanVien.Columns.Contains("DienThoai")) dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            if (dgvNhanVien.Columns.Contains("LuongThang"))
            {
                dgvNhanVien.Columns["LuongThang"].HeaderText = "Lương tháng (VNĐ)";
                dgvNhanVien.Columns["LuongThang"].DefaultCellStyle.Format = "N0";
            }
            if (dgvNhanVien.Columns.Contains("GioiTinh")) dgvNhanVien.Columns["GioiTinh"].Visible = false;
        }

        private void SetButtonState(bool normal)
        {
            btnThem.Enabled = normal;
            btnSua.Enabled = normal && dgvNhanVien.Rows.Count > 0;
            btnXoa.Enabled = normal && dgvNhanVien.Rows.Count > 0;
            btnLuu.Enabled = !normal;
            btnBoQua.Enabled = !normal;
        }

        private void LockInputs(bool locked)
        {
            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = locked;
            numNamSinh.Enabled = !locked;
            cboGioiTinh.Enabled = !locked;
            txtDiaChi.ReadOnly = locked;
            txtDienThoai.ReadOnly = locked;
            numLuongThang.Enabled = !locked;
        }

        private void ClearInputs()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            numNamSinh.Value = 2000;
            cboGioiTinh.SelectedIndex = 0;
            numLuongThang.Value = 5000000;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvNhanVien.Rows.Count) return;

            DataGridViewRow r = dgvNhanVien.Rows[e.RowIndex];
            txtMaNV.Text = r.Cells["MaNV"].Value?.ToString().Trim();
            txtTenNV.Text = r.Cells["TenNV"].Value?.ToString();
            numNamSinh.Value = Convert.ToDecimal(r.Cells["NamSinh"].Value ?? 2000);

            string gt = r.Cells["GioiTinh"].Value?.ToString().Trim();
            cboGioiTinh.SelectedIndex = (gt == "F") ? 1 : 0;

            txtDiaChi.Text = r.Cells["DiaChi"].Value?.ToString();
            txtDienThoai.Text = r.Cells["DienThoai"].Value?.ToString();
            numLuongThang.Value = Convert.ToDecimal(r.Cells["LuongThang"].Value ?? 0);

            SetButtonState(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThemMoi = true;
            ClearInputs();
            LockInputs(false);
            SetButtonState(false);

            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(6); EXEC SP_GenerateNewMaNV @Ma OUTPUT; SELECT @Ma;");
            txtMaNV.Text = newMa != null ? newMa.ToString().Trim() : "NV0004";
            txtTenNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isThemMoi = false;
            LockInputs(false);
            SetButtonState(false);
            txtTenNV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object cnt = DataProcess.LayGiaTri("SELECT COUNT(*) FROM tThueSach WHERE MaNV = @MaNV",
                new SqlParameter[] { new SqlParameter("@MaNV", txtMaNV.Text.Trim()) });
            if (cnt != null && Convert.ToInt32(cnt) > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu thuê sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên '" + txtTenNV.Text + "' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sql = "DELETE FROM tNhanVien WHERE MaNV = @MaNV";
                int r = DataProcess.ThucThiLenh(sql, new SqlParameter[] { new SqlParameter("@MaNV", txtMaNV.Text.Trim()) });
                if (r > 0)
                {
                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhanVien();
                    ClearInputs();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }

            string gioiTinh = (cboGioiTinh.SelectedIndex == 1) ? "F" : "M";

            if (isThemMoi)
            {
                string sql = @"INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang)
                               VALUES (@MaNV, @TenNV, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @LuongThang)";
                SqlParameter[] p = {
                    new SqlParameter("@MaNV", txtMaNV.Text.Trim()),
                    new SqlParameter("@TenNV", txtTenNV.Text.Trim()),
                    new SqlParameter("@NamSinh", (int)numNamSinh.Value),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                    new SqlParameter("@DienThoai", txtDienThoai.Text.Trim()),
                    new SqlParameter("@LuongThang", numLuongThang.Value)
                };

                int r = DataProcess.ThucThiLenh(sql, p);
                if (r > 0)
                {
                    MessageBox.Show("Thêm mới nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhanVien();
                    LockInputs(true);
                    SetButtonState(true);
                }
            }
            else
            {
                string sql = @"UPDATE tNhanVien 
                               SET TenNV = @TenNV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, 
                                   DiaChi = @DiaChi, DienThoai = @DienThoai, LuongThang = @LuongThang
                               WHERE MaNV = @MaNV";
                SqlParameter[] p = {
                    new SqlParameter("@MaNV", txtMaNV.Text.Trim()),
                    new SqlParameter("@TenNV", txtTenNV.Text.Trim()),
                    new SqlParameter("@NamSinh", (int)numNamSinh.Value),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@DiaChi", txtDiaChi.Text.Trim()),
                    new SqlParameter("@DienThoai", txtDienThoai.Text.Trim()),
                    new SqlParameter("@LuongThang", numLuongThang.Value)
                };

                int r = DataProcess.ThucThiLenh(sql, p);
                if (r > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataNhanVien();
                    LockInputs(true);
                    SetButtonState(true);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            LockInputs(true);
            SetButtonState(true);
            if (dgvNhanVien.CurrentRow != null)
            {
                dgvNhanVien_CellClick(dgvNhanVien, new DataGridViewCellEventArgs(0, dgvNhanVien.CurrentRow.Index));
            }
            else
            {
                ClearInputs();
            }
        }

        // YÊU CẦU 6: Tìm kiếm Nhân viên theo tiêu chí: Tên nhân viên, Ca làm, Giới tính
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTimTenNV.Text.Trim();
            string ca = cboTimCaLam.SelectedValue?.ToString().Trim();
            string gt = null;
            if (cboTimGioiTinh.SelectedIndex == 1) gt = "M";
            else if (cboTimGioiTinh.SelectedIndex == 2) gt = "F";

            SqlParameter[] p = {
                new SqlParameter("@TenNV", string.IsNullOrEmpty(ten) ? (object)DBNull.Value : ten),
                new SqlParameter("@MaCa", string.IsNullOrEmpty(ca) ? (object)DBNull.Value : ca),
                new SqlParameter("@GioiTinh", string.IsNullOrEmpty(gt) ? (object)DBNull.Value : gt)
            };

            DataTable dt = DataProcess.ExecProcedure("SP_TimNhanVien", p);
            dgvNhanVien.DataSource = dt;

            if (dgvNhanVien.Columns.Contains("MaNV")) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns.Contains("TenNV")) dgvNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            if (dgvNhanVien.Columns.Contains("NamSinh")) dgvNhanVien.Columns["NamSinh"].HeaderText = "Năm sinh";
            if (dgvNhanVien.Columns.Contains("GioiTinh")) dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            if (dgvNhanVien.Columns.Contains("DiaChi")) dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            if (dgvNhanVien.Columns.Contains("DienThoai")) dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            if (dgvNhanVien.Columns.Contains("LuongThang"))
            {
                dgvNhanVien.Columns["LuongThang"].HeaderText = "Lương tháng (VNĐ)";
                dgvNhanVien.Columns["LuongThang"].DefaultCellStyle.Format = "N0";
            }

            MessageBox.Show("Tìm thấy " + dt.Rows.Count + " nhân viên thỏa mãn tiêu chí!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoiTim_Click(object sender, EventArgs e)
        {
            txtTimTenNV.Clear();
            cboTimCaLam.SelectedIndex = 0;
            cboTimGioiTinh.SelectedIndex = 0;
            LoadDataNhanVien();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
