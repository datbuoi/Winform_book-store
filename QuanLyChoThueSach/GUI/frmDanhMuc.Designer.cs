#nullable disable
namespace QuanLyChoThueSach.GUI
{
    partial class frmDanhMuc
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlPhai = new System.Windows.Forms.Panel();
            this.tlpFields = new System.Windows.Forms.TableLayoutPanel();
            this.flowNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlPhai.SuspendLayout();
            this.flowNut.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(540, 520);
            this.dgv.TabIndex = 0;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // pnlPhai
            // 
            this.pnlPhai.Controls.Add(this.tlpFields);
            this.pnlPhai.Controls.Add(this.flowNut);
            this.pnlPhai.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPhai.Location = new System.Drawing.Point(540, 0);
            this.pnlPhai.Name = "pnlPhai";
            this.pnlPhai.Padding = new System.Windows.Forms.Padding(12);
            this.pnlPhai.Size = new System.Drawing.Size(360, 520);
            this.pnlPhai.TabIndex = 1;
            // 
            // tlpFields
            // 
            this.tlpFields.AutoSize = true;
            this.tlpFields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpFields.ColumnCount = 2;
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpFields.Location = new System.Drawing.Point(12, 12);
            this.tlpFields.Name = "tlpFields";
            this.tlpFields.RowCount = 1;
            this.tlpFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFields.Size = new System.Drawing.Size(336, 0);
            this.tlpFields.TabIndex = 0;
            // 
            // flowNut
            // 
            this.flowNut.Controls.Add(this.btnThem);
            this.flowNut.Controls.Add(this.btnSua);
            this.flowNut.Controls.Add(this.btnXoa);
            this.flowNut.Controls.Add(this.btnNhapMoi);
            this.flowNut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowNut.Location = new System.Drawing.Point(12, 464);
            this.flowNut.Name = "flowNut";
            this.flowNut.Size = new System.Drawing.Size(336, 44);
            this.flowNut.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(84, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(165, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.Location = new System.Drawing.Point(246, 3);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(75, 32);
            this.btnNhapMoi.TabIndex = 3;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.UseVisualStyleBackColor = true;
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // frmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnlPhai);
            this.MinimumSize = new System.Drawing.Size(700, 360);
            this.Name = "frmDanhMuc";
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.frmDanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlPhai.ResumeLayout(false);
            this.pnlPhai.PerformLayout();
            this.flowNut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnlPhai;
        private System.Windows.Forms.TableLayoutPanel tlpFields;
        private System.Windows.Forms.FlowLayoutPanel flowNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNhapMoi;
    }
}
