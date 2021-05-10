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
    public partial class FormNhaCC : Form
    {
        public FormNhaCC()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";
        private void FormNhaCC_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            ShowData();

            dgvNhaCC.Columns["id"].Visible = false;
            dgvNhaCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNhaCC.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvNhaCC.Columns["Email"].HeaderText = "Email";
            dgvNhaCC.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dgvNhaCC.Columns["diachi"].Width = 200;
            dgvNhaCC.Columns["dienthoai"].Width = 100;
            dgvNhaCC.Columns["email"].Width = 200;
            dgvNhaCC.Columns["tenncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void ShowData()
        {
            var rs = (from n in db.NhaCungCaps
                      select new
                      {
                          n.ID,
                          n.TenNCC,
                          n.DienThoai,
                          n.Email,
                          n.DiaChi
                      });
            dgvNhaCC.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNhaCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhaCC.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Select();
                return;
            }

            NhaCungCap ncc = new NhaCungCap();
            ncc.TenNCC = txtNhaCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
            ncc.DienThoai = txtDienThoai.Text;
            ncc.NgayTao = DateTime.Now;
            ncc.NguoiTao = nhanvien;

            db.NhaCungCaps.InsertOnSubmit(ncc);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhà cung cấp thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtNhaCC.Text = txtDiaChi.Text = txtEmail.Text = null;
            txtDienThoai.Text = "0";
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp  muốn cập nhật", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ncc = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            ncc.TenNCC = txtNhaCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
            ncc.DienThoai = txtDienThoai.Text;

            ncc.NgayCapNhat = DateTime.Now;
            ncc.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật nhà cung cấp thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtNhaCC.Text = txtDiaChi.Text = txtEmail.Text = null;
            txtDienThoai.Text = "0";
            r = null;
        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhaCC.Rows[e.RowIndex];
                txtNhaCC.Text = r.Cells["tenncc"].Value.ToString();
                txtDiaChi.Text = r.Cells["diachi"].Value.ToString();
                txtDienThoai.Text = r.Cells["dienthoai"].Value.ToString();
                txtEmail.Text = r.Cells["email"].Value.ToString();

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng nhập nhà cung cấp muốn xóa", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
                MessageBox.Show("Bạn muốn xóa nhà cung cấp : " + r.Cells["tenncc"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    )
            {
                try
                {
                    var l = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.NhaCungCaps.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhà cung cấp thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();

                    txtNhaCC.Text = txtDiaChi.Text = txtEmail.Text = null;
                    txtDienThoai.Text = "0";
                    r = null;
                    
                }
                catch
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
