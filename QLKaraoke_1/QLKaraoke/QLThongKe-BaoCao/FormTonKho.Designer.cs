namespace QLKaraoke.QLThongKe_BaoCao
{
    partial class FormTonKho
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
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtTatCa = new System.Windows.Forms.RadioButton();
            this.rbtGanHet = new System.Windows.Forms.RadioButton();
            this.rbtDaHet = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.GridColor = System.Drawing.Color.DarkGray;
            this.dgvTonKho.Location = new System.Drawing.Point(-2, 129);
            this.dgvTonKho.MultiSelect = false;
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(768, 366);
            this.dgvTonKho.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "THỐNG KÊ TỒN KHO";
            // 
            // rbtTatCa
            // 
            this.rbtTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtTatCa.AutoSize = true;
            this.rbtTatCa.Checked = true;
            this.rbtTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTatCa.Location = new System.Drawing.Point(137, 97);
            this.rbtTatCa.Name = "rbtTatCa";
            this.rbtTatCa.Size = new System.Drawing.Size(148, 21);
            this.rbtTatCa.TabIndex = 22;
            this.rbtTatCa.TabStop = true;
            this.rbtTatCa.Text = "Tất Cả Mặt Hàng";
            this.rbtTatCa.UseVisualStyleBackColor = true;
            // 
            // rbtGanHet
            // 
            this.rbtGanHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtGanHet.AutoSize = true;
            this.rbtGanHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtGanHet.Location = new System.Drawing.Point(291, 97);
            this.rbtGanHet.Name = "rbtGanHet";
            this.rbtGanHet.Size = new System.Drawing.Size(86, 21);
            this.rbtGanHet.TabIndex = 23;
            this.rbtGanHet.Text = "Gần Hết";
            this.rbtGanHet.UseVisualStyleBackColor = true;
            // 
            // rbtDaHet
            // 
            this.rbtDaHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtDaHet.AutoSize = true;
            this.rbtDaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDaHet.Location = new System.Drawing.Point(383, 97);
            this.rbtDaHet.Name = "rbtDaHet";
            this.rbtDaHet.Size = new System.Drawing.Size(76, 21);
            this.rbtDaHet.TabIndex = 24;
            this.rbtDaHet.Text = "Đã Hết";
            this.rbtDaHet.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Location = new System.Drawing.Point(465, 92);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(167, 31);
            this.btnThongKe.TabIndex = 25;
            this.btnThongKe.Text = "Thống Kê Mặt Hàng";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // FormTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(766, 495);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.rbtDaHet);
            this.Controls.Add(this.rbtGanHet);
            this.Controls.Add(this.rbtTatCa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTonKho);
            this.Name = "FormTonKho";
            this.Text = "FormTonKho";
            this.Load += new System.EventHandler(this.FormTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtTatCa;
        private System.Windows.Forms.RadioButton rbtGanHet;
        private System.Windows.Forms.RadioButton rbtDaHet;
        private System.Windows.Forms.Button btnThongKe;
    }
}