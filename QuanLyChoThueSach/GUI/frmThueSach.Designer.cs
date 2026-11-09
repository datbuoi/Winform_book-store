#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmThueSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.lblKhach = new System.Windows.Forms.Label();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblCa = new System.Windows.Forms.Label();
            this.cboCa = new System.Windows.Forms.ComboBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.lblCoc = new System.Windows.Forms.Label();
            this.nudCoc = new System.Windows.Forms.NumericUpDown();
            this.grpSach = new System.Windows.Forms.GroupBox();
            this.lblSach = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.lblCon = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlDuoi = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoc)).BeginInit();
            this.grpSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlDuoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.lblKhach);
            this.grpPhieu.Controls.Add(this.cboKhach);
            this.grpPhieu.Controls.Add(this.lblNV);
            this.grpPhieu.Controls.Add(this.cboNV);
            this.grpPhieu.Controls.Add(this.lblCa);
            this.grpPhieu.Controls.Add(this.cboCa);
            this.grpPhieu.Controls.Add(this.lblNgay);
            this.grpPhieu.Controls.Add(this.dtpNgayThue);
            this.grpPhieu.Controls.Add(this.lblCoc);
            this.grpPhieu.Controls.Add(this.nudCoc);
            this.grpPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPhieu.Location = new System.Drawing.Point(0, 0);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(900, 105);
            this.grpPhieu.TabIndex = 0;
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Thông tin phiếu thuê";
            // 
            // lblKhach
            // 
            this.lblKhach.AutoSize = true;
            this.lblKhach.Location = new System.Drawing.Point(12, 31);
            this.lblKhach.Name = "lblKhach";
            this.lblKhach.Size = new System.Drawing.Size(66, 15);
            this.lblKhach.TabIndex = 0;
            this.lblKhach.Text = "Khách hàng";
            // 
            // cboKhach
            // 
            this.cboKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhach.Location = new System.Drawing.Point(95, 28);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(230, 23);
            this.cboKhach.TabIndex = 1;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(345, 31);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(58, 15);
            this.lblNV.TabIndex = 2;
            this.lblNV.Text = "Nhân viên";
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.Location = new System.Drawing.Point(420, 28);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(200, 23);
            this.cboNV.TabIndex = 3;
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Location = new System.Drawing.Point(640, 31);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(40, 15);
            this.lblCa.TabIndex = 4;
            this.lblCa.Text = "Ca làm";
            // 
            // cboCa
            // 
            this.cboCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCa.Location = new System.Drawing.Point(690, 28);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(190, 23);
            this.cboCa.TabIndex = 5;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(12, 68);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(60, 15);
            this.lblNgay.TabIndex = 6;
            this.lblNgay.Text = "Ngày thuê";
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThue.Location = new System.Drawing.Point(95, 65);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(140, 23);
            this.dtpNgayThue.TabIndex = 7;
            // 
            // lblCoc
            // 
            this.lblCoc.AutoSize = true;
            this.lblCoc.Location = new System.Drawing.Point(345, 68);
            this.lblCoc.Name = "lblCoc";
            this.lblCoc.Size = new System.Drawing.Size(75, 15);
            this.lblCoc.TabIndex = 8;
            this.lblCoc.Text = "Tiền đặt cọc";
            // 
            // nudCoc
            // 
            this.nudCoc.Location = new System.Drawing.Point(450, 65);
            this.nudCoc.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.nudCoc.Name = "nudCoc";
            this.nudCoc.Size = new System.Drawing.Size(170, 23);
            this.nudCoc.TabIndex = 9;
            this.nudCoc.ThousandsSeparator = true;
            // 
            // grpSach
            // 
            this.grpSach.Controls.Add(this.lblSach);
            this.grpSach.Controls.Add(this.cboSach);
            this.grpSach.Controls.Add(this.lblCon);
            this.grpSach.Controls.Add(this.lblSoLuong);
            this.grpSach.Controls.Add(this.nudSoLuong);
            this.grpSach.Controls.Add(this.btnThemSach);
            this.grpSach.Controls.Add(this.btnBoSach);
            this.grpSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSach.Location = new System.Drawing.Point(0, 105);
            this.grpSach.Name = "grpSach";
            this.grpSach.Size = new System.Drawing.Size(900, 70);
            this.grpSach.TabIndex = 1;
            this.grpSach.TabStop = false;
            this.grpSach.Text = "Chi tiết thuê sách (chỉ hiện sách còn trong kho)";
            // 
            // lblSach
            // 
            this.lblSach.AutoSize = true;
            this.lblSach.Location = new System.Drawing.Point(12, 31);
            this.lblSach.Name = "lblSach";
            this.lblSach.Size = new System.Drawing.Size(31, 15);
            this.lblSach.TabIndex = 0;
            this.lblSach.Text = "Sách";
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.Location = new System.Drawing.Point(60, 28);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(300, 23);
            this.cboSach.TabIndex = 1;
            this.cboSach.SelectedIndexChanged += new System.EventHandler(this.cboSach_SelectedIndexChanged);
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.Location = new System.Drawing.Point(372, 31);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(40, 15);
            this.lblCon.TabIndex = 2;
            this.lblCon.Text = "Còn: 0";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(450, 31);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(54, 15);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(510, 28);
            this.nudSoLuong.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(65, 23);
            this.nudSoLuong.TabIndex = 4;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(595, 26);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(130, 27);
            this.btnThemSach.TabIndex = 5;
            this.btnThemSach.Text = "Thêm vào phiếu";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnBoSach
            // 
            this.btnBoSach.Location = new System.Drawing.Point(735, 26);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(145, 27);
            this.btnBoSach.TabIndex = 6;
            this.btnBoSach.Text = "Bỏ sách đang chọn";
            this.btnBoSach.UseVisualStyleBackColor = true;
            this.btnBoSach.Click += new System.EventHandler(this.btnBoSach_Click);
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 175);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(900, 410);
            this.dgv.TabIndex = 2;
            // 
            // pnlDuoi
            // 
            this.pnlDuoi.Controls.Add(this.lblTong);
            this.pnlDuoi.Controls.Add(this.btnLuu);
            this.pnlDuoi.Controls.Add(this.btnLamMoi);
            this.pnlDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDuoi.Location = new System.Drawing.Point(0, 585);
            this.pnlDuoi.Name = "pnlDuoi";
            this.pnlDuoi.Size = new System.Drawing.Size(900, 55);
            this.pnlDuoi.TabIndex = 3;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTong.Location = new System.Drawing.Point(12, 19);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(200, 17);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tổng số lượng: 0";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(610, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu phiếu thuê";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(770, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmThueSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlDuoi);
            this.Controls.Add(this.grpSach);
            this.Controls.Add(this.grpPhieu);
            this.MinimumSize = new System.Drawing.Size(916, 500);
            this.Name = "frmThueSach";
            this.Text = "Thuê sách";
            this.Load += new System.EventHandler(this.frmThueSach_Load);
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCoc)).EndInit();
            this.grpSach.ResumeLayout(false);
            this.grpSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlDuoi.ResumeLayout(false);
            this.pnlDuoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.Label lblKhach;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.ComboBox cboCa;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.NumericUpDown nudCoc;
        private System.Windows.Forms.GroupBox grpSach;
        private System.Windows.Forms.Label lblSach;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label lblCon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnlDuoi;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
