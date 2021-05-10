using QLKaraoke.QLBanHang;
using QLKaraoke.QuanLy;
using QLKaraoke.QuanLy.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKaraoke
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {       
            FormDangNhap dn = new FormDangNhap();
            
            dn.StartPosition = FormStartPosition.CenterScreen;
            dn.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap exit = new FormDangNhap();
            exit.StartPosition = FormStartPosition.CenterScreen;
            exit.ShowDialog();
            
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            FormNhapHang nhaphang = new FormNhapHang();
            nhaphang.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FormDonViTinh dvt = new FormDonViTinh();
            dvt.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FormMatHang mh = new FormMatHang();
            mh.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FormLoaiPhong lp = new FormLoaiPhong();
            lp.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FormPhong p = new FormPhong();
            p.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FormNhaCC ncc = new FormNhaCC();
            ncc.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            nv.ShowDialog();
        }

        private void phânCôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormBanHang bhh = new FormBanHang();
            bhh.ShowDialog();
        }
    }
}
