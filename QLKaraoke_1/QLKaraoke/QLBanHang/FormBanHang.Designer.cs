namespace QLKaraoke.QLBanHang
{
    partial class FormBanHang
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
            this.tbcContent = new System.Windows.Forms.TabControl();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lblPhongDangChon = new System.Windows.Forms.Label();
            this.dgvDanhSachMatHang = new System.Windows.Forms.DataGridView();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.pnlThoiGian = new System.Windows.Forms.Panel();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.dgvChiTietBanHang = new System.Windows.Forms.DataGridView();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.mtbKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).BeginInit();
            this.panelOrder.SuspendLayout();
            this.pnlThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcContent
            // 
            this.tbcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcContent.Location = new System.Drawing.Point(0, 0);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.SelectedIndex = 0;
            this.tbcContent.Size = new System.Drawing.Size(1257, 587);
            this.tbcContent.TabIndex = 0;
            this.tbcContent.SelectedIndexChanged += new System.EventHandler(this.tbcContent_SelectedIndexChanged);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.lblPhongDangChon);
            this.pnlControl.Controls.Add(this.dgvDanhSachMatHang);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(881, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(376, 587);
            this.pnlControl.TabIndex = 1;
            this.pnlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControl_Paint);
            // 
            // lblPhongDangChon
            // 
            this.lblPhongDangChon.AutoSize = true;
            this.lblPhongDangChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhongDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhongDangChon.Location = new System.Drawing.Point(0, 0);
            this.lblPhongDangChon.Name = "lblPhongDangChon";
            this.lblPhongDangChon.Size = new System.Drawing.Size(76, 17);
            this.lblPhongDangChon.TabIndex = 5;
            this.lblPhongDangChon.Text = "Bắt Đầu :";
            // 
            // dgvDanhSachMatHang
            // 
            this.dgvDanhSachMatHang.AllowUserToAddRows = false;
            this.dgvDanhSachMatHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMatHang.Location = new System.Drawing.Point(0, 20);
            this.dgvDanhSachMatHang.MultiSelect = false;
            this.dgvDanhSachMatHang.Name = "dgvDanhSachMatHang";
            this.dgvDanhSachMatHang.ReadOnly = true;
            this.dgvDanhSachMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachMatHang.Size = new System.Drawing.Size(376, 567);
            this.dgvDanhSachMatHang.TabIndex = 4;
            this.dgvDanhSachMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachMatHang_CellDoubleClick);
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.pnlThoiGian);
            this.panelOrder.Controls.Add(this.label2);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrder.Location = new System.Drawing.Point(0, 435);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(881, 152);
            this.panelOrder.TabIndex = 2;
            // 
            // pnlThoiGian
            // 
            this.pnlThoiGian.Controls.Add(this.btnBatDau);
            this.pnlThoiGian.Controls.Add(this.dgvChiTietBanHang);
            this.pnlThoiGian.Controls.Add(this.btnKetThuc);
            this.pnlThoiGian.Controls.Add(this.mtbKetThuc);
            this.pnlThoiGian.Controls.Add(this.label4);
            this.pnlThoiGian.Controls.Add(this.mtbBatDau);
            this.pnlThoiGian.Controls.Add(this.label3);
            this.pnlThoiGian.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThoiGian.Location = new System.Drawing.Point(0, 31);
            this.pnlThoiGian.Name = "pnlThoiGian";
            this.pnlThoiGian.Size = new System.Drawing.Size(881, 121);
            this.pnlThoiGian.TabIndex = 4;
            // 
            // btnBatDau
            // 
            this.btnBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatDau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.Color.Black;
            this.btnBatDau.Location = new System.Drawing.Point(0, 83);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(98, 31);
            this.btnBatDau.TabIndex = 26;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // dgvChiTietBanHang
            // 
            this.dgvChiTietBanHang.AllowUserToAddRows = false;
            this.dgvChiTietBanHang.AllowUserToDeleteRows = false;
            this.dgvChiTietBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietBanHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBanHang.Location = new System.Drawing.Point(208, 0);
            this.dgvChiTietBanHang.MultiSelect = false;
            this.dgvChiTietBanHang.Name = "dgvChiTietBanHang";
            this.dgvChiTietBanHang.ReadOnly = true;
            this.dgvChiTietBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietBanHang.Size = new System.Drawing.Size(673, 121);
            this.dgvChiTietBanHang.TabIndex = 25;
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKetThuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetThuc.ForeColor = System.Drawing.Color.Black;
            this.btnKetThuc.Location = new System.Drawing.Point(104, 83);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(98, 31);
            this.btnKetThuc.TabIndex = 24;
            this.btnKetThuc.Text = "Kết Thúc";
            this.btnKetThuc.UseVisualStyleBackColor = false;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // mtbKetThuc
            // 
            this.mtbKetThuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbKetThuc.Location = new System.Drawing.Point(91, 40);
            this.mtbKetThuc.Mask = "00/00/0000 90:00";
            this.mtbKetThuc.Name = "mtbKetThuc";
            this.mtbKetThuc.Size = new System.Drawing.Size(111, 20);
            this.mtbKetThuc.TabIndex = 3;
            this.mtbKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kết Thúc :";
            // 
            // mtbBatDau
            // 
            this.mtbBatDau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbBatDau.Location = new System.Drawing.Point(91, 11);
            this.mtbBatDau.Mask = "00/00/0000 90:00";
            this.mtbBatDau.Name = "mtbBatDau";
            this.mtbBatDau.Size = new System.Drawing.Size(111, 20);
            this.mtbBatDau.TabIndex = 1;
            this.mtbBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bắt Đầu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Danh Sách Phòng Đã Sử Dụng";
            // 
            // FormBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(1257, 587);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.tbcContent);
            this.Name = "FormBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBanHang";
            this.Load += new System.EventHandler(this.FormBanHang_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).EndInit();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.pnlThoiGian.ResumeLayout(false);
            this.pnlThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tbcContent;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.DataGridView dgvDanhSachMatHang;
        private System.Windows.Forms.Panel pnlThoiGian;
        private System.Windows.Forms.MaskedTextBox mtbBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Label lblPhongDangChon;
        private System.Windows.Forms.DataGridView dgvChiTietBanHang;
        private System.Windows.Forms.Button btnBatDau;
    }
}