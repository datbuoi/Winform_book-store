#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmBaoCao
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChuaTra = new System.Windows.Forms.TabPage();
            this.dgvChuaTra = new System.Windows.Forms.DataGridView();
            this.pnlChuaTra = new System.Windows.Forms.Panel();
            this.lblSoChuaTra = new System.Windows.Forms.Label();
            this.btnXemChuaTra = new System.Windows.Forms.Button();
            this.btnPdfChuaTra = new System.Windows.Forms.Button();
            this.btnPdfDoanhThu = new System.Windows.Forms.Button();
            this.btnPdfTop5 = new System.Windows.Forms.Button();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblKieu = new System.Windows.Forms.Label();
            this.cboKieu = new System.Windows.Forms.ComboBox();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.tabTop5 = new System.Windows.Forms.TabPage();
            this.dgvTop5 = new System.Windows.Forms.DataGridView();
            this.pnlTop5 = new System.Windows.Forms.Panel();
            this.btnXemTop5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabChuaTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaTra)).BeginInit();
            this.pnlChuaTra.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.pnlDoanhThu.SuspendLayout();
            this.tabTop5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).BeginInit();
            this.pnlTop5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChuaTra);
            this.tabControl1.Controls.Add(this.tabDoanhThu);
            this.tabControl1.Controls.Add(this.tabTop5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 600);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabChuaTra
            // 
            this.tabChuaTra.Controls.Add(this.dgvChuaTra);
            this.tabChuaTra.Controls.Add(this.pnlChuaTra);
            this.tabChuaTra.Location = new System.Drawing.Point(4, 24);
            this.tabChuaTra.Name = "tabChuaTra";
            this.tabChuaTra.Size = new System.Drawing.Size(992, 572);
            this.tabChuaTra.TabIndex = 0;
            this.tabChuaTra.Text = "Sách đang thuê chưa trả";
            this.tabChuaTra.UseVisualStyleBackColor = true;
            // 
            // dgvChuaTra
            // 
            this.dgvChuaTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChuaTra.Location = new System.Drawing.Point(0, 45);
            this.dgvChuaTra.Name = "dgvChuaTra";
            this.dgvChuaTra.Size = new System.Drawing.Size(992, 527);
            this.dgvChuaTra.TabIndex = 1;
            // 
            // pnlChuaTra
            // 
            this.pnlChuaTra.Controls.Add(this.lblSoChuaTra);
            this.pnlChuaTra.Controls.Add(this.btnXemChuaTra);
            this.pnlChuaTra.Controls.Add(this.btnPdfChuaTra);
            this.pnlChuaTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChuaTra.Location = new System.Drawing.Point(0, 0);
            this.pnlChuaTra.Name = "pnlChuaTra";
            this.pnlChuaTra.Size = new System.Drawing.Size(992, 45);
            this.pnlChuaTra.TabIndex = 0;
            // 
            // lblSoChuaTra
            // 
            this.lblSoChuaTra.AutoSize = true;
            this.lblSoChuaTra.Location = new System.Drawing.Point(250, 15);
            this.lblSoChuaTra.Name = "lblSoChuaTra";
            this.lblSoChuaTra.Size = new System.Drawing.Size(10, 15);
            this.lblSoChuaTra.TabIndex = 1;
            this.lblSoChuaTra.Text = " ";
            // 
            // btnXemChuaTra
            // 
            this.btnXemChuaTra.Location = new System.Drawing.Point(12, 9);
            this.btnXemChuaTra.Name = "btnXemChuaTra";
            this.btnXemChuaTra.Size = new System.Drawing.Size(105, 28);
            this.btnXemChuaTra.TabIndex = 0;
            this.btnXemChuaTra.Text = "Xem báo cáo";
            this.btnXemChuaTra.UseVisualStyleBackColor = true;
            this.btnXemChuaTra.Click += new System.EventHandler(this.btnXemChuaTra_Click);
            // 
            // btnPdfChuaTra
            // 
            this.btnPdfChuaTra.Location = new System.Drawing.Point(127, 9);
            this.btnPdfChuaTra.Name = "btnPdfChuaTra";
            this.btnPdfChuaTra.Size = new System.Drawing.Size(105, 28);
            this.btnPdfChuaTra.TabIndex = 2;
            this.btnPdfChuaTra.Text = "Xuất PDF";
            this.btnPdfChuaTra.UseVisualStyleBackColor = true;
            this.btnPdfChuaTra.Click += new System.EventHandler(this.btnPdfChuaTra_Click);
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Controls.Add(this.pnlDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 24);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Size = new System.Drawing.Size(992, 572);
            this.tabDoanhThu.TabIndex = 1;
            this.tabDoanhThu.Text = "Tiền thuê theo tháng / quý / năm";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(0, 45);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.Size = new System.Drawing.Size(992, 527);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.Controls.Add(this.lblKieu);
            this.pnlDoanhThu.Controls.Add(this.cboKieu);
            this.pnlDoanhThu.Controls.Add(this.btnXemDoanhThu);
            this.pnlDoanhThu.Controls.Add(this.btnPdfDoanhThu);
            this.pnlDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.pnlDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(992, 45);
            this.pnlDoanhThu.TabIndex = 0;
            // 
            // lblKieu
            // 
            this.lblKieu.AutoSize = true;
            this.lblKieu.Location = new System.Drawing.Point(12, 15);
            this.lblKieu.Name = "lblKieu";
            this.lblKieu.Size = new System.Drawing.Size(73, 15);
            this.lblKieu.TabIndex = 0;
            this.lblKieu.Text = "Thống kê theo";
            // 
            // cboKieu
            // 
            this.cboKieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieu.Items.AddRange(new object[] {
            "Tháng",
            "Quý",
            "Năm"});
            this.cboKieu.Location = new System.Drawing.Point(110, 12);
            this.cboKieu.Name = "cboKieu";
            this.cboKieu.Size = new System.Drawing.Size(110, 23);
            this.cboKieu.TabIndex = 1;
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.Location = new System.Drawing.Point(235, 9);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(105, 28);
            this.btnXemDoanhThu.TabIndex = 2;
            this.btnXemDoanhThu.Text = "Xem báo cáo";
            this.btnXemDoanhThu.UseVisualStyleBackColor = true;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // btnPdfDoanhThu
            // 
            this.btnPdfDoanhThu.Location = new System.Drawing.Point(350, 9);
            this.btnPdfDoanhThu.Name = "btnPdfDoanhThu";
            this.btnPdfDoanhThu.Size = new System.Drawing.Size(105, 28);
            this.btnPdfDoanhThu.TabIndex = 4;
            this.btnPdfDoanhThu.Text = "Xuất PDF";
            this.btnPdfDoanhThu.UseVisualStyleBackColor = true;
            this.btnPdfDoanhThu.Click += new System.EventHandler(this.btnPdfDoanhThu_Click);
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(480, 14);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(10, 17);
            this.lblTongDoanhThu.TabIndex = 3;
            this.lblTongDoanhThu.Text = " ";
            // 
            // tabTop5
            // 
            this.tabTop5.Controls.Add(this.dgvTop5);
            this.tabTop5.Controls.Add(this.pnlTop5);
            this.tabTop5.Location = new System.Drawing.Point(4, 24);
            this.tabTop5.Name = "tabTop5";
            this.tabTop5.Size = new System.Drawing.Size(992, 572);
            this.tabTop5.TabIndex = 2;
            this.tabTop5.Text = "Top 5 sách doanh thu cao nhất";
            this.tabTop5.UseVisualStyleBackColor = true;
            // 
            // dgvTop5
            // 
            this.dgvTop5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop5.Location = new System.Drawing.Point(0, 45);
            this.dgvTop5.Name = "dgvTop5";
            this.dgvTop5.Size = new System.Drawing.Size(992, 527);
            this.dgvTop5.TabIndex = 1;
            // 
            // pnlTop5
            // 
            this.pnlTop5.Controls.Add(this.btnXemTop5);
            this.pnlTop5.Controls.Add(this.btnPdfTop5);
            this.pnlTop5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop5.Location = new System.Drawing.Point(0, 0);
            this.pnlTop5.Name = "pnlTop5";
            this.pnlTop5.Size = new System.Drawing.Size(992, 45);
            this.pnlTop5.TabIndex = 0;
            // 
            // btnXemTop5
            // 
            this.btnXemTop5.Location = new System.Drawing.Point(12, 9);
            this.btnXemTop5.Name = "btnXemTop5";
            this.btnXemTop5.Size = new System.Drawing.Size(105, 28);
            this.btnXemTop5.TabIndex = 0;
            this.btnXemTop5.Text = "Xem báo cáo";
            this.btnXemTop5.UseVisualStyleBackColor = true;
            this.btnXemTop5.Click += new System.EventHandler(this.btnXemTop5_Click);
            // 
            // btnPdfTop5
            // 
            this.btnPdfTop5.Location = new System.Drawing.Point(127, 9);
            this.btnPdfTop5.Name = "btnPdfTop5";
            this.btnPdfTop5.Size = new System.Drawing.Size(105, 28);
            this.btnPdfTop5.TabIndex = 1;
            this.btnPdfTop5.Text = "Xuất PDF";
            this.btnPdfTop5.UseVisualStyleBackColor = true;
            this.btnPdfTop5.Click += new System.EventHandler(this.btnPdfTop5_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabChuaTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaTra)).EndInit();
            this.pnlChuaTra.ResumeLayout(false);
            this.pnlChuaTra.PerformLayout();
            this.tabDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlDoanhThu.PerformLayout();
            this.tabTop5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).EndInit();
            this.pnlTop5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChuaTra;
        private System.Windows.Forms.DataGridView dgvChuaTra;
        private System.Windows.Forms.Panel pnlChuaTra;
        private System.Windows.Forms.Label lblSoChuaTra;
        private System.Windows.Forms.Button btnXemChuaTra;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblKieu;
        private System.Windows.Forms.ComboBox cboKieu;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TabPage tabTop5;
        private System.Windows.Forms.DataGridView dgvTop5;
        private System.Windows.Forms.Panel pnlTop5;
        private System.Windows.Forms.Button btnXemTop5;
        private System.Windows.Forms.Button btnPdfChuaTra;
        private System.Windows.Forms.Button btnPdfDoanhThu;
        private System.Windows.Forms.Button btnPdfTop5;
    }
}
