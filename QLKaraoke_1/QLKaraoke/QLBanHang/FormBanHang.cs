using QLKaraoke.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private ListView lv;
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            var dsLoaiPhong = db.LoaiPhongs;
            foreach (var l in dsLoaiPhong)
            {
                TabPage tp = new TabPage(l.TenLoaiPhong);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }

            idLoaiPhong = db.LoaiPhongs.Min(x => x.ID);
            LoadPhong(idLoaiPhong, tabIndex);

            ShowMatHang();
            #region
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
            #endregion
        }

        private void LoadPhong(int loaiphong, int tabIndex)
        {

                tbcContent.TabPages[tabIndex].Controls.Clear();
                lv = new ListView();
                lv.Dock = DockStyle.Fill;

                lv.SelectedIndexChanged += lv_SelectedIndexChanged;

                ImageList imgl = new ImageList();
                imgl.ImageSize = new Size(256, 128);
                imgl.Images.Add(Properties.Resources._256x256bb);
                imgl.Images.Add(Properties.Resources.tải_xuống);
                lv.LargeImageList = imgl;

                var dsPhong = db.Phongs.Where(x => x.IDLoaiPhong == loaiphong);
                foreach (var p in dsPhong)
                {
                    if (p.TrangThai == 1)
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenPhong,Name = p.ID.ToString(),Tag = true });
                    }
                    else
                    {
                        lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenPhong, Name = p.ID.ToString(),Tag = false });
                    }
                }
            tbcContent.TabPages[tabIndex].Controls.Add(lv);
            
        }

        int idLoaiPhong = 0;
        int idPhong = 0;
        private string tenphong;
        private int idHoaDon=0;
        private string nhanvien = "admin";
        private int tabIndex = 0;
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {

                idPhong = int.Parse(lv.SelectedItems[0].Name);
                tenphong = lv.SelectedItems[0].Text.ToUpper();
                lblPhongDangChon.Text = tenphong;

                if ((bool)lv.SelectedItems[0].Tag)
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x => x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDPhong == idPhong).Max(z => z.IDHoaDon));
                    idHoaDon = hd.IDHoaDon;

                    
                    mtbKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");

                    ShowChiTietHoaDon();

                }
                else
                {
                    
                    dgvChiTietBanHang.DataSource = null;
                    mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    btnBatDau.Enabled = true;
                    btnKetThuc.Enabled = false;
                    
                }


            }
        }

        private void ShowChiTietHoaDon()
        {
            var rs = from ct in db.ChiTietHoaDons.Where(x => x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on ct.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         mahang = h.ID,
                         tenhang = h.TenMatHang,
                         dvt = d.TenDVT,
                         sl = ct.SL,
                         dg = ct.DonGia,
                         thanhtien = ct.SL * ct.DonGia
                     };
            dgvChiTietBanHang.DataSource = rs;
            #region
            dgvChiTietBanHang.Columns["mahang"].Visible = false;
            dgvChiTietBanHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvChiTietBanHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvChiTietBanHang.Columns["sl"].HeaderText = "Số lượng";
            dgvChiTietBanHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvChiTietBanHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvChiTietBanHang.Columns["sl"].Width = 50;
            dgvChiTietBanHang.Columns["dvt"].Width = 70;
            dgvChiTietBanHang.Columns["dg"].Width = 100;
            dgvChiTietBanHang.Columns["thanhtien"].Width = 100;
            dgvChiTietBanHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvChiTietBanHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietBanHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
            #endregion

        }

        private void ShowMatHang()
        {
            #region
            /*
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
                          };*/
            #endregion
            #region ton_kho_cha
            var details = from ct in db.ChiTietHoaDonNhaps
                          join hd in db.HoaDonNhaps.Where(x => x.DaNhap == 1)
                          on ct.IDHoaDon equals hd.ID
                          select new
                          {
                              mahang = ct.IDMatHang,
                              sl = ct.SoLuong
                          };

            var nhapCha = from ct in details.GroupBy(x => x.mahang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0) on ct.First().mahang equals h.ID
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          
                          select new
                          {
                              mahang = ct.First().mahang,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.Sum(x => x.sl)
                          };

            var xuatCha = from p in db.ChiTietHoaDons.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0)
                          on p.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = p.Sum(x => x.SL)
                          };

            var xuatQuyRaCha = from ct in db.ChiTietHoaDons.GroupBy(x => x.IDMatHang)
                               join h in db.MatHangs.Where(x => x.IdCha > 0)
                               on ct.First().IDMatHang equals h.ID
                               select new
                               {
                                   mahang = ct.First().IDMatHang,
                                   soluong = ct.Sum(x => x.SL) % h.Tile == 0 ? ct.Sum(x => x.SL) / h.Tile: ct.Sum(x => x.SL) / h.Tile+1
                               };

            var tongXuatCha = from xc in xuatCha.Union(xuatQuyRaCha).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = xc.First().mahang,
                                  soluong = xc.Sum(x => x.soluong)
                             };
            var tonKhoCha = from p in nhapCha
                            join q in tongXuatCha on p.mahang equals q.mahang
                            select new
                            {
                                mahang = p.mahang,
                                tenhang = p.tenhang,
                                dvt =p.dvt,
                                dg = p.dg,
                                tongkho = (int)(p.soluong - q.soluong)
                            };
            #endregion
            #region ton_kho_con
            var nhapCon = from ct in nhapCha
                          join h in db.MatHangs on ct.mahang equals h.IdCha
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          select new {
                              mahang = h.ID,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.soluong * h.Tile
                          };

           var xuatConQuyTuCha = from xc in xuatCha
                              join h in db.MatHangs.Where(x => x.IdCha > 0)
                              on xc.mahang equals h.IdCha
                              select new
                              {
                                  mahang = h.ID,
                                  soluong = xc.soluong * h.Tile
                              };

            var xuatCon = from ct in db.ChiTietHoaDons.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha > 0)
                          on ct.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = ct.Sum(x => x.SL)
                          };

            var tongConXuat = from ct in xuatConQuyTuCha.Union(xuatCon).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = ct.First().mahang,
                                  slXuat = ct.Sum(x => x.soluong)
                              };

            var tonKhoCon = from nc in nhapCon
                            join xc in tongConXuat on nc.mahang equals xc.mahang
                            select new
                            {
                                mahang = nc.mahang,
                                tenhang = nc.tenhang,
                                //dvt =nc.dvt,
                                //dg = nc.dg,
                                tonkho = (int)(nc.soluong - xc.slXuat)
                            };
            #endregion
            var tonkho = tonKhoCha.Concat(tonKhoCon).OrderBy(x => x.tenhang);
            
            var t = 1;
            dgvDanhSachMatHang.DataSource = tonkho;
            //dgvDanhSachMatHang.DataSource = khadung.OrderBy(x => x.tenhang);
        }

        

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhSachMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để tiếp tục ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(e.RowIndex < 0)
            {
                return;
            }

            var phong = db.Phongs.SingleOrDefault(x => x.ID == idPhong);

            if (phong.TrangThai == 1)
            {
                var r = dgvDanhSachMatHang.Rows[e.RowIndex];
                new FormOrder(idHoaDon, tenphong, r).ShowDialog();
                ShowMatHang();
                ShowChiTietHoaDon();
            }
            

        }

        private void tbcContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            idLoaiPhong = int.Parse(tbcContent.SelectedTab.Name);
            tabIndex = tbcContent.SelectedIndex;
            LoadPhong(idLoaiPhong, tabIndex);
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                var od = new HoaDonBanHang();
                od.IDPhong = idPhong;
                od.NguoiBan = nhanvien;
                od.ThoiGianBDau = DateTime.ParseExact(mtbBatDau.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;

                db.HoaDonBanHangs.InsertOnSubmit(od);
                db.SubmitChanges();

                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                p.TrangThai = 1;
                db.SubmitChanges();

                LoadPhong(idLoaiPhong, tabIndex);
                btnBatDau.Enabled = false;
                btnKetThuc.Enabled = true;
                MessageBox.Show("Gọi phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Gọi phòng thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);
                hd.ThoiGianKetThuc = DateTime.ParseExact(mtbKetThuc.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                db.SubmitChanges();

                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                p.TrangThai = 0;
                db.SubmitChanges();


                LoadPhong(idLoaiPhong, tabIndex);
                mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                MessageBox.Show("Thanh toán phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message,"Thanh toán phòng thất bại ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
