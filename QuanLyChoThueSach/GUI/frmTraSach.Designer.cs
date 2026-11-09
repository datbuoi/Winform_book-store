#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmTraSach
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
            this.lblPhieu = new System.Windows.Forms.Label();
            this.cboPhieu = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlDuoi = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlDuoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.lblPhieu);
            this.grpPhieu.Controls.Add(this.cboPhieu);
            this.grpPhieu.Controls.Add(this.lblNV);
            this.grpPhieu.Controls.Add(this.cboNV);
            this.grpPhieu.Controls.Add(this.lblNgay);
            this.grpPhieu.Controls.Add(this.dtpNgayTra);
            this.grpPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPhieu.Location = new System.Drawing.Point(0, 0);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(900, 105);
            this.grpPhieu.TabIndex = 0;
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Thông tin phiếu trả (chỉ hiện các sách chưa trả của phiếu thuê được chọn)";
            // 
            // lblPhieu
            // 
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Location = new System.Drawing.Point(12, 31);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(61, 15);
            this.lblPhieu.TabIndex = 0;
            this.lblPhieu.Text = "Phiếu thuê";
            // 
            // cboPhieu
            // 
            this.cboPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieu.Location = new System.Drawing.Point(95, 28);
            this.cboPhieu.Name = "cboPhieu";
            this.cboPhieu.Size = new System.Drawing.Size(500, 23);
            this.cboPhieu.TabIndex = 1;
            this.cboPhieu.SelectedIndexChanged += new System.EventHandler(this.cboPhieu_SelectedIndexChanged);
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(12, 68);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(58, 15);
            this.lblNV.TabIndex = 2;
            this.lblNV.Text = "Nhân viên";
            // 
            // cboNV
            // 
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.Location = new System.Drawing.Point(95, 65);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(230, 23);
            this.cboNV.TabIndex = 3;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(345, 68);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(51, 15);
            this.lblNgay.TabIndex = 4;
            this.lblNgay.Text = "Ngày trả";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(410, 65);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(140, 23);
            this.dtpNgayTra.TabIndex = 5;
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 105);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(900, 480);
            this.dgv.TabIndex = 1;
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgv.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_CurrentCellDirtyStateChanged);
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
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
            this.pnlDuoi.TabIndex = 2;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTong.Location = new System.Drawing.Point(12, 19);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(200, 17);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tổng tiền: 0";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(610, 10);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 34);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu phiếu trả";
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
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlDuoi);
            this.Controls.Add(this.grpPhieu);
            this.MinimumSize = new System.Drawing.Size(916, 500);
            this.Name = "frmTraSach";
            this.Text = "Trả sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlDuoi.ResumeLayout(false);
            this.pnlDuoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.ComboBox cboPhieu;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnlDuoi;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
