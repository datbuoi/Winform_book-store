namespace BookStore_LTTQ
{
    partial class FormBaoCao
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.tabBaoCao = new System.Windows.Forms.TabControl();
            this.tabChuaTra = new System.Windows.Forms.TabPage();
            this.dgvChuaTra = new System.Windows.Forms.DataGridView();
            this.panelTab1Bottom = new System.Windows.Forms.Panel();
            this.lblTongChuaTra = new System.Windows.Forms.Label();
            this.panelTab1Top = new System.Windows.Forms.Panel();
            this.btnLamMoiTab1 = new System.Windows.Forms.Button();
            this.lblTab1TieuDe = new System.Windows.Forms.Label();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.panelTab2Bottom = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.grpBoLocDoanhThu = new System.Windows.Forms.GroupBox();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.numNamDoanhThu = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.radNam = new System.Windows.Forms.RadioButton();
            this.radQuy = new System.Windows.Forms.RadioButton();
            this.radThang = new System.Windows.Forms.RadioButton();
            this.tabTop5 = new System.Windows.Forms.TabPage();
            this.dgvTop5 = new System.Windows.Forms.DataGridView();
            this.panelTab3Bottom = new System.Windows.Forms.Panel();
            this.lblGhiChuTop5 = new System.Windows.Forms.Label();
            this.grpBoLocTop5 = new System.Windows.Forms.GroupBox();
            this.btnXemTatCaTop5 = new System.Windows.Forms.Button();
            this.btnXemTop5 = new System.Windows.Forms.Button();
            this.dtpTop5DenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTop5TuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.tabBaoCao.SuspendLayout();
            this.tabChuaTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaTra)).BeginInit();
            this.panelTab1Bottom.SuspendLayout();
            this.panelTab1Top.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.panelTab2Bottom.SuspendLayout();
            this.grpBoLocDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDoanhThu)).BeginInit();
            this.tabTop5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).BeginInit();
            this.panelTab3Bottom.SuspendLayout();
            this.grpBoLocTop5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1034, 55);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(385, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(264, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO VÀ THỐNG KÊ";
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Controls.Add(this.tabChuaTra);
            this.tabBaoCao.Controls.Add(this.tabDoanhThu);
            this.tabBaoCao.Controls.Add(this.tabTop5);
            this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBaoCao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabBaoCao.Location = new System.Drawing.Point(0, 55);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.SelectedIndex = 0;
            this.tabBaoCao.Size = new System.Drawing.Size(1034, 556);
            this.tabBaoCao.TabIndex = 1;
            // 
            // tabChuaTra
            // 
            this.tabChuaTra.Controls.Add(this.dgvChuaTra);
            this.tabChuaTra.Controls.Add(this.panelTab1Bottom);
            this.tabChuaTra.Controls.Add(this.panelTab1Top);
            this.tabChuaTra.Location = new System.Drawing.Point(4, 26);
            this.tabChuaTra.Name = "tabChuaTra";
            this.tabChuaTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuaTra.Size = new System.Drawing.Size(1026, 526);
            this.tabChuaTra.TabIndex = 0;
            this.tabChuaTra.Text = "Sách đang thuê chưa trả (Yêu cầu 7)";
            this.tabChuaTra.UseVisualStyleBackColor = true;
            // 
            // dgvChuaTra
            // 
            this.dgvChuaTra.AllowUserToAddRows = false;
            this.dgvChuaTra.AllowUserToDeleteRows = false;
            this.dgvChuaTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChuaTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvChuaTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuaTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChuaTra.Location = new System.Drawing.Point(3, 53);
            this.dgvChuaTra.MultiSelect = false;
            this.dgvChuaTra.Name = "dgvChuaTra";
            this.dgvChuaTra.ReadOnly = true;
            this.dgvChuaTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChuaTra.Size = new System.Drawing.Size(1020, 425);
            this.dgvChuaTra.TabIndex = 1;
            // 
            // panelTab1Bottom
            // 
            this.panelTab1Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelTab1Bottom.Controls.Add(this.lblTongChuaTra);
            this.panelTab1Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTab1Bottom.Location = new System.Drawing.Point(3, 478);
            this.panelTab1Bottom.Name = "panelTab1Bottom";
            this.panelTab1Bottom.Size = new System.Drawing.Size(1020, 45);
            this.panelTab1Bottom.TabIndex = 2;
            // 
            // lblTongChuaTra
            // 
            this.lblTongChuaTra.AutoSize = true;
            this.lblTongChuaTra.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTongChuaTra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblTongChuaTra.Location = new System.Drawing.Point(15, 12);
            this.lblTongChuaTra.Name = "lblTongChuaTra";
            this.lblTongChuaTra.Size = new System.Drawing.Size(325, 19);
            this.lblTongChuaTra.TabIndex = 0;
            this.lblTongChuaTra.Text = "Tổng số sách đang mượn chưa trả: 0 cuốn";
            // 
            // panelTab1Top
            // 
            this.panelTab1Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelTab1Top.Controls.Add(this.btnLamMoiTab1);
            this.panelTab1Top.Controls.Add(this.lblTab1TieuDe);
            this.panelTab1Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTab1Top.Location = new System.Drawing.Point(3, 3);
            this.panelTab1Top.Name = "panelTab1Top";
            this.panelTab1Top.Size = new System.Drawing.Size(1020, 50);
            this.panelTab1Top.TabIndex = 0;
            // 
            // btnLamMoiTab1
            // 
            this.btnLamMoiTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLamMoiTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiTab1.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiTab1.Location = new System.Drawing.Point(860, 8);
            this.btnLamMoiTab1.Name = "btnLamMoiTab1";
            this.btnLamMoiTab1.Size = new System.Drawing.Size(140, 32);
            this.btnLamMoiTab1.TabIndex = 1;
            this.btnLamMoiTab1.Text = "Làm mới";
            this.btnLamMoiTab1.UseVisualStyleBackColor = false;
            this.btnLamMoiTab1.Click += new System.EventHandler(this.btnLamMoiTab1_Click);
            // 
            // lblTab1TieuDe
            // 
            this.lblTab1TieuDe.AutoSize = true;
            this.lblTab1TieuDe.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTab1TieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTab1TieuDe.Location = new System.Drawing.Point(12, 14);
            this.lblTab1TieuDe.Name = "lblTab1TieuDe";
            this.lblTab1TieuDe.Size = new System.Drawing.Size(438, 20);
            this.lblTab1TieuDe.TabIndex = 0;
            this.lblTab1TieuDe.Text = "DANH SÁCH CÁC SÁCH TRUYỆN ĐANG ĐƯỢC THUÊ CHƯA TRẢ";
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Controls.Add(this.panelTab2Bottom);
            this.tabDoanhThu.Controls.Add(this.grpBoLocDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 26);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(1026, 526);
            this.tabDoanhThu.TabIndex = 1;
            this.tabDoanhThu.Text = "Doanh thu theo Tháng/Quý/Năm (Yêu cầu 8)";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThu.Location = new System.Drawing.Point(3, 73);
            this.dgvDoanhThu.MultiSelect = false;
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1020, 405);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // panelTab2Bottom
            // 
            this.panelTab2Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelTab2Bottom.Controls.Add(this.lblTongDoanhThu);
            this.panelTab2Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTab2Bottom.Location = new System.Drawing.Point(3, 478);
            this.panelTab2Bottom.Name = "panelTab2Bottom";
            this.panelTab2Bottom.Size = new System.Drawing.Size(1020, 45);
            this.panelTab2Bottom.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(15, 12);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(173, 20);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            // 
            // grpBoLocDoanhThu
            // 
            this.grpBoLocDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.grpBoLocDoanhThu.Controls.Add(this.btnXemDoanhThu);
            this.grpBoLocDoanhThu.Controls.Add(this.numNamDoanhThu);
            this.grpBoLocDoanhThu.Controls.Add(this.lblNam);
            this.grpBoLocDoanhThu.Controls.Add(this.radNam);
            this.grpBoLocDoanhThu.Controls.Add(this.radQuy);
            this.grpBoLocDoanhThu.Controls.Add(this.radThang);
            this.grpBoLocDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLocDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.grpBoLocDoanhThu.Name = "grpBoLocDoanhThu";
            this.grpBoLocDoanhThu.Size = new System.Drawing.Size(1020, 70);
            this.grpBoLocDoanhThu.TabIndex = 0;
            this.grpBoLocDoanhThu.TabStop = false;
            this.grpBoLocDoanhThu.Text = "Tùy chọn thống kê doanh thu";
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXemDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThu.Location = new System.Drawing.Point(620, 24);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(140, 32);
            this.btnXemDoanhThu.TabIndex = 5;
            this.btnXemDoanhThu.Text = "Xem thống kê";
            this.btnXemDoanhThu.UseVisualStyleBackColor = false;
            this.btnXemDoanhThu.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // numNamDoanhThu
            // 
            this.numNamDoanhThu.Location = new System.Drawing.Point(485, 28);
            this.numNamDoanhThu.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numNamDoanhThu.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numNamDoanhThu.Name = "numNamDoanhThu";
            this.numNamDoanhThu.Size = new System.Drawing.Size(100, 25);
            this.numNamDoanhThu.TabIndex = 4;
            this.numNamDoanhThu.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(435, 30);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(42, 19);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm:";
            // 
            // radNam
            // 
            this.radNam.AutoSize = true;
            this.radNam.Location = new System.Drawing.Point(280, 28);
            this.radNam.Name = "radNam";
            this.radNam.Size = new System.Drawing.Size(117, 23);
            this.radNam.TabIndex = 2;
            this.radNam.Text = "Theo các Năm";
            this.radNam.UseVisualStyleBackColor = true;
            this.radNam.CheckedChanged += new System.EventHandler(this.radDoanhThu_CheckedChanged);
            // 
            // radQuy
            // 
            this.radQuy.AutoSize = true;
            this.radQuy.Location = new System.Drawing.Point(155, 28);
            this.radQuy.Name = "radQuy";
            this.radQuy.Size = new System.Drawing.Size(87, 23);
            this.radQuy.TabIndex = 1;
            this.radQuy.Text = "Theo Quý";
            this.radQuy.UseVisualStyleBackColor = true;
            this.radQuy.CheckedChanged += new System.EventHandler(this.radDoanhThu_CheckedChanged);
            // 
            // radThang
            // 
            this.radThang.AutoSize = true;
            this.radThang.Checked = true;
            this.radThang.Location = new System.Drawing.Point(25, 28);
            this.radThang.Name = "radThang";
            this.radThang.Size = new System.Drawing.Size(100, 23);
            this.radThang.TabIndex = 0;
            this.radThang.TabStop = true;
            this.radThang.Text = "Theo Tháng";
            this.radThang.UseVisualStyleBackColor = true;
            this.radThang.CheckedChanged += new System.EventHandler(this.radDoanhThu_CheckedChanged);
            // 
            // tabTop5
            // 
            this.tabTop5.Controls.Add(this.dgvTop5);
            this.tabTop5.Controls.Add(this.panelTab3Bottom);
            this.tabTop5.Controls.Add(this.grpBoLocTop5);
            this.tabTop5.Location = new System.Drawing.Point(4, 26);
            this.tabTop5.Name = "tabTop5";
            this.tabTop5.Padding = new System.Windows.Forms.Padding(3);
            this.tabTop5.Size = new System.Drawing.Size(1026, 526);
            this.tabTop5.TabIndex = 2;
            this.tabTop5.Text = "Top 5 Sách doanh thu cao nhất (Yêu cầu 9)";
            this.tabTop5.UseVisualStyleBackColor = true;
            // 
            // dgvTop5
            // 
            this.dgvTop5.AllowUserToAddRows = false;
            this.dgvTop5.AllowUserToDeleteRows = false;
            this.dgvTop5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop5.BackgroundColor = System.Drawing.Color.White;
            this.dgvTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop5.Location = new System.Drawing.Point(3, 73);
            this.dgvTop5.MultiSelect = false;
            this.dgvTop5.Name = "dgvTop5";
            this.dgvTop5.ReadOnly = true;
            this.dgvTop5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop5.Size = new System.Drawing.Size(1020, 405);
            this.dgvTop5.TabIndex = 1;
            // 
            // panelTab3Bottom
            // 
            this.panelTab3Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelTab3Bottom.Controls.Add(this.lblGhiChuTop5);
            this.panelTab3Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTab3Bottom.Location = new System.Drawing.Point(3, 478);
            this.panelTab3Bottom.Name = "panelTab3Bottom";
            this.panelTab3Bottom.Size = new System.Drawing.Size(1020, 45);
            this.panelTab3Bottom.TabIndex = 2;
            // 
            // lblGhiChuTop5
            // 
            this.lblGhiChuTop5.AutoSize = true;
            this.lblGhiChuTop5.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuTop5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGhiChuTop5.Location = new System.Drawing.Point(15, 12);
            this.lblGhiChuTop5.Name = "lblGhiChuTop5";
            this.lblGhiChuTop5.Size = new System.Drawing.Size(534, 19);
            this.lblGhiChuTop5.TabIndex = 0;
            this.lblGhiChuTop5.Text = "* Danh sách 5 tác phẩm sách truyện đạt tổng doanh thu cho thuê cao nhất của cửa hàng";
            // 
            // grpBoLocTop5
            // 
            this.grpBoLocTop5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.grpBoLocTop5.Controls.Add(this.btnXemTatCaTop5);
            this.grpBoLocTop5.Controls.Add(this.btnXemTop5);
            this.grpBoLocTop5.Controls.Add(this.dtpTop5DenNgay);
            this.grpBoLocTop5.Controls.Add(this.lblDenNgay);
            this.grpBoLocTop5.Controls.Add(this.dtpTop5TuNgay);
            this.grpBoLocTop5.Controls.Add(this.lblTuNgay);
            this.grpBoLocTop5.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLocTop5.Location = new System.Drawing.Point(3, 3);
            this.grpBoLocTop5.Name = "grpBoLocTop5";
            this.grpBoLocTop5.Size = new System.Drawing.Size(1020, 70);
            this.grpBoLocTop5.TabIndex = 0;
            this.grpBoLocTop5.TabStop = false;
            this.grpBoLocTop5.Text = "Khoảng thời gian thống kê";
            // 
            // btnXemTatCaTop5
            // 
            this.btnXemTatCaTop5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnXemTatCaTop5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTatCaTop5.ForeColor = System.Drawing.Color.White;
            this.btnXemTatCaTop5.Location = new System.Drawing.Point(740, 25);
            this.btnXemTatCaTop5.Name = "btnXemTatCaTop5";
            this.btnXemTatCaTop5.Size = new System.Drawing.Size(160, 32);
            this.btnXemTatCaTop5.TabIndex = 5;
            this.btnXemTatCaTop5.Text = "Toàn bộ thời gian";
            this.btnXemTatCaTop5.UseVisualStyleBackColor = false;
            this.btnXemTatCaTop5.Click += new System.EventHandler(this.btnXemTatCaTop5_Click);
            // 
            // btnXemTop5
            // 
            this.btnXemTop5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnXemTop5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTop5.ForeColor = System.Drawing.Color.White;
            this.btnXemTop5.Location = new System.Drawing.Point(580, 25);
            this.btnXemTop5.Name = "btnXemTop5";
            this.btnXemTop5.Size = new System.Drawing.Size(140, 32);
            this.btnXemTop5.TabIndex = 4;
            this.btnXemTop5.Text = "Thống kê Top 5";
            this.btnXemTop5.UseVisualStyleBackColor = false;
            this.btnXemTop5.Click += new System.EventHandler(this.btnXemTop5_Click);
            // 
            // dtpTop5DenNgay
            // 
            this.dtpTop5DenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTop5DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTop5DenNgay.Location = new System.Drawing.Point(375, 28);
            this.dtpTop5DenNgay.Name = "dtpTop5DenNgay";
            this.dtpTop5DenNgay.Size = new System.Drawing.Size(160, 25);
            this.dtpTop5DenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(295, 31);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(73, 19);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTop5TuNgay
            // 
            this.dtpTop5TuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTop5TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTop5TuNgay.Location = new System.Drawing.Point(95, 28);
            this.dtpTop5TuNgay.Name = "dtpTop5TuNgay";
            this.dtpTop5TuNgay.Size = new System.Drawing.Size(160, 25);
            this.dtpTop5TuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 31);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(63, 19);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 611);
            this.Controls.Add(this.tabBaoCao);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(950, 580);
            this.Name = "FormBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo và Thống kê";
            this.Load += new System.EventHandler(this.FormBaoCao_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabBaoCao.ResumeLayout(false);
            this.tabChuaTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaTra)).EndInit();
            this.panelTab1Bottom.ResumeLayout(false);
            this.panelTab1Bottom.PerformLayout();
            this.panelTab1Top.ResumeLayout(false);
            this.panelTab1Top.PerformLayout();
            this.tabDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.panelTab2Bottom.ResumeLayout(false);
            this.panelTab2Bottom.PerformLayout();
            this.grpBoLocDoanhThu.ResumeLayout(false);
            this.grpBoLocDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDoanhThu)).EndInit();
            this.tabTop5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).EndInit();
            this.panelTab3Bottom.ResumeLayout(false);
            this.panelTab3Bottom.PerformLayout();
            this.grpBoLocTop5.ResumeLayout(false);
            this.grpBoLocTop5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TabControl tabBaoCao;
        private System.Windows.Forms.TabPage tabChuaTra;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabTop5;
        private System.Windows.Forms.Panel panelTab1Top;
        private System.Windows.Forms.Label lblTab1TieuDe;
        private System.Windows.Forms.Button btnLamMoiTab1;
        private System.Windows.Forms.DataGridView dgvChuaTra;
        private System.Windows.Forms.Panel panelTab1Bottom;
        private System.Windows.Forms.Label lblTongChuaTra;
        private System.Windows.Forms.GroupBox grpBoLocDoanhThu;
        private System.Windows.Forms.RadioButton radNam;
        private System.Windows.Forms.RadioButton radQuy;
        private System.Windows.Forms.RadioButton radThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNamDoanhThu;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Panel panelTab2Bottom;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.GroupBox grpBoLocTop5;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTop5TuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTop5DenNgay;
        private System.Windows.Forms.Button btnXemTop5;
        private System.Windows.Forms.Button btnXemTatCaTop5;
        private System.Windows.Forms.DataGridView dgvTop5;
        private System.Windows.Forms.Panel panelTab3Bottom;
        private System.Windows.Forms.Label lblGhiChuTop5;
    }
}
