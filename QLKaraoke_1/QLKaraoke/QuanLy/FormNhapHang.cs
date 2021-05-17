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

namespace QLKaraoke.QuanLy
{
    public partial class FormNhapHang : Form
    {
        public FormNhapHang()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            ShowData();
            #region
            mtbNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbbNhanVienNhap.DataSource = db.NhanViens;
            cbbNhanVienNhap.DisplayMember = "hovaten";
            cbbNhanVienNhap.ValueMember = "username";
            cbbNhanVienNhap.SelectedIndex = -1;

            cbbNhaCungCap.DataSource = db.NhaCungCaps;
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "ID";
            cbbNhaCungCap.SelectedIndex = -1;

            dgvHoaDonNhap.Columns["danhap"].Visible = false;
            dgvHoaDonNhap.Columns["ID"].HeaderText = "Mã Phiếu Nhập";
            dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
            dgvHoaDonNhap.Columns["trangthai"].HeaderText = "Trạng Thái";
            dgvHoaDonNhap.Columns["tongtien"].HeaderText = "Tổng Tiền";
            dgvHoaDonNhap.Columns["dathanhtoan"].HeaderText = "Đã Thanh Toán";

            dgvHoaDonNhap.Columns["id"].Width = 100;
            dgvHoaDonNhap.Columns["NgayNhap"].Width = 100;
            dgvHoaDonNhap.Columns["dathanhtoan"].Width = 100;
            dgvHoaDonNhap.Columns["trangthai"].Width = 100;
            dgvHoaDonNhap.Columns["tongtien"].Width = 100;
            dgvHoaDonNhap.Columns["TenNCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHoaDonNhap.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["trangthai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Format = "N0";
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime ngaynhap;
            try
            {
                ngaynhap = DateTime.ParseExact(mtbNgayNhap.Text,"dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày nhập không hợp lệ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            try
            {
                var od = new HoaDonNhap();
                od.NhanVienNhap = cbbNhanVienNhap.SelectedValue.ToString();
                od.IDNhaCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                od.NgayNhap = ngaynhap;

                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;

                db.HoaDonNhaps.InsertOnSubmit(od);
                db.SubmitChanges();

               // MessageBox.Show("Tạo mới hóa đơn nhập thành công "+idHDNhap, "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var idHDNhap = db.HoaDonNhaps.Max(x => x.ID);
                new DanhMuc.FormChiTietHoaDonNhap(idHDNhap,0).ShowDialog();
                ShowData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,"Tạo hóa đon nhập hàng thất bại",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ShowData()
        {
           var rs = from o in db.HoaDonNhaps
                    join n in db.NhaCungCaps on o.IDNhaCC equals n.ID
                    join c in db.NhanViens on o.NhanVienNhap equals c.Username
                    select new 
                    {
                        id = o.ID,
                        NgayNhap = o.NgayNhap,
                        TenNCC = n.TenNCC,
                        danhap = o.DaNhap,
                        trangthai = o.DaNhap== 1?"Đã nhập":"Yêu Cầu",
                        //tongtien = db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == o.ID).Sum(y => y.SoLuong*y.DonGiaNhap),
                        dathanhtoan = o.TienThanhToan
                    };
            dgvHoaDonNhap.DataSource = rs;
        }

        private DataGridViewRow r;
        private void dgvHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvHoaDonNhap.Rows[e.RowIndex];
                byte danhapkho = r.Cells["danhap"].Value == null ? (byte)0 : byte.Parse(r.Cells["danhap"].Value.ToString());
                new DanhMuc.FormChiTietHoaDonNhap(int.Parse(r.Cells["id"].Value.ToString()),danhapkho).ShowDialog();
                ShowData();
            }
        }
    }
}
