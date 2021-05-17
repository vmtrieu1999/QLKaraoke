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

namespace QLKaraoke.QuanLy.DanhMuc
{
    public partial class FormChiTietHoaDonNhap : Form
    {
        public FormChiTietHoaDonNhap(int idHoaDon, byte danhapkho)
        {
            this.idHoaDon = idHoaDon;
            this.danhapkho = danhapkho;
            InitializeComponent();
        }
        private int idHoaDon;
        private byte danhapkho;
        private Database_KaraokeDataContext db;

        private void FormChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();

            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            if (hd.DaNhap == 1)
            {
                btnSave.Enabled = btnXoa.Enabled = false;
            }

            var rs = from h in db.MatHangs
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         tenmathang = h.TenMatHang + " - " + d.TenDVT,
                         mahang = h.ID
                     };

            cbbMatHang.DataSource = rs;
            cbbMatHang.DisplayMember = "TenMatHang";
            cbbMatHang.ValueMember = "mahang";
            cbbMatHang.SelectedIndex = -1;

            ShowData();

            dgvMatHang.Columns["idmathang"].Visible = false;
            dgvMatHang.Columns["mathang"].HeaderText = "Tên Mặt Hàng";
            dgvMatHang.Columns["dvt"].HeaderText = "Đơn vị Tính";
            dgvMatHang.Columns["sl"].HeaderText = "Số Lượng";
            dgvMatHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["thanhtien"].HeaderText = "Thành Tiền";

            dgvMatHang.Columns["dvt"].Width = 100;
            dgvMatHang.Columns["sl"].Width = 100;
            dgvMatHang.Columns["thanhtien"].Width = 100;
            dgvMatHang.Columns["dg"].Width = 100;
            dgvMatHang.Columns["mathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";

            dgvMatHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void ShowData()
        {
            var rs = from c in db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on c.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         idmathang = h.ID,
                         mathang = h.TenMatHang,
                         dvt = d.TenDVT,
                         sl = c.SoLuong,
                         dg = c.DonGiaNhap,
                         thanhtien = c.SoLuong * c.DonGiaNhap
                     };
            dgvMatHang.DataSource = rs;
            lblTongTien.Text = string.Format("Tổng tiền : {0:N0} VNĐ", rs.Sum(x => x.thanhtien));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbMatHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần nhập", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ct = new ChiTietHoaDonNhap();
            ct.IDHoaDon = idHoaDon;

            var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(cbbMatHang.SelectedValue.ToString()));

            if (item == null)
            {
                ct.IDMatHang = int.Parse(cbbMatHang.SelectedValue.ToString());
                ct.DonGiaNhap = int.Parse(txtTienThanhToan.Text);
                ct.SoLuong = int.Parse(txtSL.Text);
                db.ChiTietHoaDonNhaps.InsertOnSubmit(ct);
                db.SubmitChanges();
            }
            else
            {
                item.SoLuong += int.Parse(txtSL.Text);
                db.SubmitChanges();
            }          
            ShowData();
        }

        private DataGridViewRow r;

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa khỏi phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xóa mặt hàng" + r.Cells["mathang"].Value.ToString(), "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["idmathang"].Value.ToString()));
                db.ChiTietHoaDonNhaps.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show("Xóa mặt hàng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }
        }

        private void rbtNhapKho_Click(object sender, EventArgs e)
        {
            if (rbtYeuCau.Checked)
            {
                txtTienThanhToan.Enabled = false;
                txtTienThanhToan.Text = "0";
            }
            else
            {
                txtTienThanhToan.Enabled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(dgvMatHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mặt hàng vào hóa đơn nhập trước khi tiếp tục", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            hd.TienThanhToan = int.Parse(txtTienThanhToan.Text);
            hd.DaNhap = rbtYeuCau.Checked ? (byte)0 : (byte)1;
            db.SubmitChanges();
            this.Dispose();
        }
    }
}
