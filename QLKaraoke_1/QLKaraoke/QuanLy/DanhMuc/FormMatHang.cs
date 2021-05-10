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
    public partial class FormMatHang : Form
    {
        public FormMatHang()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";
        private DataGridViewRow r;
        private void FormMatHang_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();

            cbbMatHangGoc.DataSource = db.MatHangs.Where(x => x.IdCha == null || x.IdCha == -1);
            cbbMatHangGoc.DisplayMember = "TenMatHang";
            cbbMatHangGoc.ValueMember = "ID";
            cbbMatHangGoc.SelectedIndex = -1;

            ShowData();

            dgvMatHang.Columns["idcha"].Visible = false;
            dgvMatHang.Columns["tile"].Visible = false;


            cbbDVT.DataSource = db.DonViTinhs;
            cbbDVT.DisplayMember = "TenDVT";
            cbbDVT.ValueMember = "ID";
            cbbDVT.SelectedIndex = -1;

            dgvMatHang.Columns["id"].Width = 100;
            dgvMatHang.Columns["tendvt"].Width = 100;
            dgvMatHang.Columns["dongiaban"].Width = 100;
            dgvMatHang.Columns["tenmathang"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;

            dgvMatHang.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["tendv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Format = "N0";

            dgvMatHang.Columns["id"].HeaderText = "Mã hàng";
            dgvMatHang.Columns["tendvt"].HeaderText = "ĐVT";
            dgvMatHang.Columns["dongiaban"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["tenmathang"].HeaderText = "Tên mặt hàng";

        }

        private void ShowData()
        {
            var rs = (from h in db.MatHangs
                      join d in db.DonViTinhs on h.IDDVT equals d.ID
                      select new
                      {
                          h.ID,
                          h.IdCha,
                          h.Tile,
                          h.TenMatHang,
                          d.TenDVT,
                          h.DonGiaBan
                      });
            dgvMatHang.DataSource = rs;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatHang.Select();
                return; 
            }

            if(cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                return;
            }

            int idCha = -1;
            int tile = 0;

            if (cbbMatHangGoc.SelectedIndex >= 0)
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                try
                {
                    tile = int.Parse(txtTiLeQuyDoi.Text);
                    if(tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0 ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLeQuyDoi.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLeQuyDoi.Select();
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtMatHang.Text))
            {
                MatHang mh = new MatHang();
                mh.TenMatHang = txtMatHang.Text;
                mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString());
                mh.DonGiaBan = int.Parse(txtDonGia.Text);
                mh.IdCha = idCha;
                mh.Tile = tile;
                mh.NgayTao = DateTime.Now;
                mh.NguoiTao = nhanvien;

                db.MatHangs.InsertOnSubmit(mh);
                db.SubmitChanges();

                ShowData();
                MessageBox.Show("Thêm mới mặt hàng thành công ", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatHang.Text = null;
                txtDonGia.Text = "0";
                cbbDVT.SelectedIndex = -1;
            }
           
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) &&  !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));

            int idCha = -1;
            int tile = 0;

            if (cbbMatHangGoc.SelectedIndex >= 0)
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                try
                {
                    tile = int.Parse(txtTiLeQuyDoi.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0 ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLeQuyDoi.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLeQuyDoi.Select();
                    return;
                }
            }

            mh.TenMatHang = txtMatHang.Text;
            mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString());
            mh.DonGiaBan = int.Parse(txtDonGia.Text);
            mh.IdCha = idCha;
            mh.Tile = tile;
            mh.NgayCapNhat = DateTime.Now;
            mh.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật mặt hàng thành công ", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtMatHang.Text = null;
            txtDonGia.Text = "0";
            cbbDVT.SelectedIndex = -1;
        }

        private void dgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];

                txtMatHang.Text = r.Cells["tenmathang"].Value.ToString();
                txtDonGia.Text = r.Cells["dongiaban"].Value.ToString();
                cbbDVT.Text = r.Cells["tendvt"].Value.ToString();
                txtTiLeQuyDoi.Text = r.Cells["tile"].Value == null ? "0" : r.Cells["tile"].Value.ToString();
                if (r.Cells["idcha"].Value == null || r.Cells["idcha"].Value.ToString() == "-1")
                {
                    cbbMatHangGoc.SelectedIndex = -1;
                }
                else
                {
                    var item = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["idcha"].Value.ToString()));
                    cbbMatHangGoc.Text = item.TenMatHang;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa","chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (
                MessageBox.Show("Bạn thực sự muốn xóa mặt hàng " + r.Cells["tenmathang"].Value.ToString() + "?",
                 "xác nhận xóa mặt hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.MatHangs.DeleteOnSubmit(mh);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ShowData();
                }
                catch
                {
                    MessageBox.Show("Xóa mặt hàng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMatHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbbDVT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTiLeQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
