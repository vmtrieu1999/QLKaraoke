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
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
        }
        BLL_DanhMuc bd;
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";
        DataTable dataTable;
        string err = string.Empty;

        private void FormPhong_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            
            bd = new BLL_DanhMuc();
            ShowData();
            #region
            //đổ dữ liệu cbbLoaiPhong
            cbbLoaiPhong.DataSource = db.LoaiPhongs;
            cbbLoaiPhong.DisplayMember = "tenloaiphong";
            cbbLoaiPhong.ValueMember = "id";
            cbbLoaiPhong.SelectedIndex = -1;


            dgvPhong.Columns["id"].HeaderText = "Mã Phòng";
            dgvPhong.Columns["tenloaiphong"].HeaderText = "Loại Phòng";
            dgvPhong.Columns["tenphong"].HeaderText = "Tên Phòng";
            dgvPhong.Columns["dongia"].HeaderText = "Đơn Gía";
            dgvPhong.Columns["succhua"].HeaderText = "Sức Chứa";

            dgvPhong.Columns["id"].Width = 100;
            dgvPhong.Columns["tenloaiphong"].Width = 200;
            dgvPhong.Columns["succhua"].Width = 100;
            dgvPhong.Columns["dongia"].Width = 100;
            dgvPhong.Columns["tenphong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvPhong.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.Columns["succhua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.Columns["dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPhong.Columns["dongia"].DefaultCellStyle.Format = "N0";
            #endregion

        }

        private void ShowData()
        {
            dataTable = new DataTable();
            dataTable = bd.LayDanhSachPhong(ref err);
            #region
            /*var rs = (from p in db.Phongs
                      join l in db.LoaiPhongs on p.IDLoaiPhong equals l.ID
                      select new
                      {
                          p.ID,
                          l.TenLoaiPhong,
                          p.TenPhong,
                          l.DonGia,
                          p.SucChua
                      });*/
            #endregion
            dgvPhong.DataSource = dataTable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if(cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text)<=0)
            {
                MessageBox.Show("Sức chứa của phòng phải > 0", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                return;
            }

            var p = new Phong();
            p.TenPhong = txtTenPhong.Text;
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.SucChua = int.Parse(txtSucChua.Text);

            p.NgayTao = DateTime.Now;
            p.NguoiTao = nhanvien;

            db.Phongs.InsertOnSubmit(p);
            db.SubmitChanges();

            MessageBox.Show("Thêm mới phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtSucChua.Text = txtTenPhong.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvPhong.Rows[e.RowIndex];
                txtTenPhong.Text = r.Cells["tenphong"].Value.ToString();
                txtSucChua.Text = r.Cells["succhua"].Value.ToString();
                cbbLoaiPhong.Text = r.Cells["tenloaiphong"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if (cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text) <= 0)
            {
                MessageBox.Show("Sức chứa của phòng phải > 0", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                return;
            }

            var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            p.TenPhong = txtTenPhong.Text;
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.SucChua = int.Parse(txtSucChua.Text);

            p.NgayCapNhat = DateTime.Now;
            p.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtTenPhong.Text = null;           
            txtSucChua.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng nhập loại phòng muốn xóa", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
                MessageBox.Show("Bạn muốn xóa loại phòng : " + r.Cells["tenphong"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    )
            {
                try
                {
                    var l = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.Phongs.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa loại phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();

                    txtTenPhong.Text = null;
                    txtSucChua.Text = null;
                    cbbLoaiPhong.SelectedIndex = -1;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa loại phòng thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
