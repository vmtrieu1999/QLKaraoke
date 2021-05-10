namespace QLKaraoke.QuanLy.DanhMuc
{
    partial class FormChiTietHoaDonNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMatHang = new System.Windows.Forms.DataGridView();
            this.cbbMatHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienThanhToan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbtYeuCau = new System.Windows.Forms.RadioButton();
            this.rbtNhapKho = new System.Windows.Forms.RadioButton();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatHang
            // 
            this.dgvMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatHang.GridColor = System.Drawing.Color.DarkGray;
            this.dgvMatHang.Location = new System.Drawing.Point(12, 127);
            this.dgvMatHang.MultiSelect = false;
            this.dgvMatHang.Name = "dgvMatHang";
            this.dgvMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatHang.Size = new System.Drawing.Size(886, 215);
            this.dgvMatHang.TabIndex = 27;
            this.dgvMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatHang_CellClick);
            // 
            // cbbMatHang
            // 
            this.cbbMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMatHang.FormattingEnabled = true;
            this.cbbMatHang.Location = new System.Drawing.Point(150, 41);
            this.cbbMatHang.Name = "cbbMatHang";
            this.cbbMatHang.Size = new System.Drawing.Size(217, 21);
            this.cbbMatHang.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Mặt hàng";
            // 
            // txtTienThanhToan
            // 
            this.txtTienThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienThanhToan.Location = new System.Drawing.Point(527, 458);
            this.txtTienThanhToan.Multiline = true;
            this.txtTienThanhToan.Name = "txtTienThanhToan";
            this.txtTienThanhToan.Size = new System.Drawing.Size(144, 22);
            this.txtTienThanhToan.TabIndex = 31;
            this.txtTienThanhToan.Text = "0";
            this.txtTienThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(432, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Thanh Toán";
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSL.Location = new System.Drawing.Point(675, 40);
            this.txtSL.Multiline = true;
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(38, 22);
            this.txtSL.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(592, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Số Lượng";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(803, 83);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(77, 31);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(720, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 31);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Thêm";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbtYeuCau
            // 
            this.rbtYeuCau.AutoSize = true;
            this.rbtYeuCau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtYeuCau.ForeColor = System.Drawing.Color.Black;
            this.rbtYeuCau.Location = new System.Drawing.Point(173, 459);
            this.rbtYeuCau.Name = "rbtYeuCau";
            this.rbtYeuCau.Size = new System.Drawing.Size(85, 21);
            this.rbtYeuCau.TabIndex = 36;
            this.rbtYeuCau.TabStop = true;
            this.rbtYeuCau.Text = "Yêu cầu";
            this.rbtYeuCau.UseVisualStyleBackColor = true;
            this.rbtYeuCau.Click += new System.EventHandler(this.rbtNhapKho_Click);
            // 
            // rbtNhapKho
            // 
            this.rbtNhapKho.AutoSize = true;
            this.rbtNhapKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNhapKho.ForeColor = System.Drawing.Color.Black;
            this.rbtNhapKho.Location = new System.Drawing.Point(320, 459);
            this.rbtNhapKho.Name = "rbtNhapKho";
            this.rbtNhapKho.Size = new System.Drawing.Size(97, 21);
            this.rbtNhapKho.TabIndex = 37;
            this.rbtNhapKho.TabStop = true;
            this.rbtNhapKho.Text = "Nhập Kho";
            this.rbtNhapKho.UseVisualStyleBackColor = true;
            this.rbtNhapKho.Click += new System.EventHandler(this.rbtNhapKho_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(12, 354);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(96, 17);
            this.lblTongTien.TabIndex = 39;
            this.lblTongTien.Text = "Thanh Toán";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhan.Location = new System.Drawing.Point(678, 452);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(113, 31);
            this.btnXacNhan.TabIndex = 38;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // FormChiTietHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(885, 485);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.rbtNhapKho);
            this.Controls.Add(this.rbtYeuCau);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTienThanhToan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbMatHang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvMatHang);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FormChiTietHoaDonNhap";
            this.Text = "Chi Tiết Hóa Đơn Nhập Hàng";
            this.Load += new System.EventHandler(this.FormChiTietHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatHang;
        private System.Windows.Forms.ComboBox cbbMatHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienThanhToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbtYeuCau;
        private System.Windows.Forms.RadioButton rbtNhapKho;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnXacNhan;
    }
}