using QLKaraoke.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKaraoke.QLBanHang
{
    public partial class FormBanHang : Form
    {
        public FormBanHang()
        {
            InitializeComponent();
        }

        private Database_KaraokeDataContext db;

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            var dsLoaiPhong = db.LoaiPhongs;
            foreach(var l in dsLoaiPhong)
            {
                TabPage tp = new TabPage(l.TenLoaiPhong);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);

                ListView lv = new ListView();
                lv.Dock = DockStyle.Fill;

                ImageList imgl = new ImageList();
                imgl.ImageSize = new Size(256, 128);
                imgl.Images.Add(Properties.Resources._256x256bb);
                lv.LargeImageList = imgl;

                var dsPhong = db.Phongs.Where(x => x.IDLoaiPhong == l.ID);
                foreach (var p in dsPhong)
                {
                    if(p.TrangThai == 1)
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenPhong });
                    }
                    else
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenPhong });
                    }
                }
                tp.Controls.Add(lv);
            }

            ShowMatHang();

            dgvDanhSachMatHang.Columns["mahang"].Visible = false;
            dgvDanhSachMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDanhSachMatHang.Columns["dvt"].HeaderText = "Đơn vị tính";
            dgvDanhSachMatHang.Columns["dg"].HeaderText = "Gía";
            dgvDanhSachMatHang.Columns["tonkho"].HeaderText = "Tồn kho";

            dgvDanhSachMatHang.Columns["dvt"].Width = 50;
            dgvDanhSachMatHang.Columns["dg"].Width = 70;
            dgvDanhSachMatHang.Columns["tonkho"].Width = 70;
            dgvDanhSachMatHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDanhSachMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Format = "N0";

        }

        private void ShowMatHang()
        {
            var nhap = from p in db.ChiTietHoaDonNhaps.GroupBy(x => x.IDMatHang)
                       select new
                       {
                           mahang = p.First().IDMatHang,
                           tongnhap = p.Sum(x => x.SoLuong)
                       };

            var xuat = from p in db.ChiTietHoaDons.GroupBy(x => x.IDMatHang)
                       select new
                       {
                           mahang = p.First().IDMatHang,
                           tongxuat = p.Sum(x => x.IDMatHang)
                       };

            var khadung = from p in nhap
                          join q in xuat on p.mahang equals q.mahang into t
                          join h in db.MatHangs on p.mahang equals h.ID
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          from s in t.DefaultIfEmpty()
                          select new
                          {
                              mahang = p.mahang,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              tonkho = s.mahang == null ? p.tongnhap : p.tongnhap - s.tongxuat
                          };
            dgvDanhSachMatHang.DataSource = khadung.OrderBy(x => x.tenhang);
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
