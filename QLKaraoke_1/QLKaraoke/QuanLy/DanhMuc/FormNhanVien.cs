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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";

        BLL_DanhMuc bd;
        DataTable dataTable;
        string err = string.Empty;
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            bd = new BLL_DanhMuc();
            ShowData();
            #region
            dgvNhanVien.Columns["password"].Visible = false;
            dgvNhanVien.Columns["Username"].HeaderText = "Tài Khoản";
            dgvNhanVien.Columns["hovaten"].HeaderText = "Họ và Tên";
            dgvNhanVien.Columns["dienthoai"].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns["diachi"].HeaderText = "Địa Chỉ";


            dgvNhanVien.Columns["Username"].Width = 100;
            dgvNhanVien.Columns["dienthoai"].Width = 100;
            dgvNhanVien.Columns["hovaten"].Width = 100;
            dgvNhanVien.Columns["diachi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion
        }

        private void ShowData()
        {
            #region
            /*
            var rs = (from nv in db.NhanViens
                      select new
                      {
                          nv.Username,
                          nv.Password,
                          nv.HoVaTen,
                          nv.DienThoai,
                          nv.DiaChi
                      });*/
            #endregion
            dataTable = new DataTable();
            dataTable = bd.LayDanhSachNhanVien(ref err);
            dgvNhanVien.DataSource = dataTable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản nhân viên", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu nhân viên", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtHovaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHovaTen.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhân viên", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhân viên", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Select();
                return;
            }

            //kiểm tra tồn tại tài khoản 
            var c = db.NhanViens.Where(x => x.Username.Trim().ToLower() == txtTaiKhoan.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài khoản này đã tồn tại", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }

            NhanVien nv = new NhanVien();
            nv.Username = txtTaiKhoan.Text;
            nv.Password = txtMatKhau.Text;
            nv.HoVaTen = txtHovaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;
           
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhân viên thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtTaiKhoan.Text = txtMatKhau.Text = txtHovaTen.Text = txtDienThoai.Text = txtDiaChi.Text = null;
            
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
                MessageBox.Show("Vui lòng nhập nhân viên muốn cập nhật", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["username"].Value.ToString());
            nv.Username = txtTaiKhoan.Text;
            nv.Password = txtMatKhau.Text;
            nv.HoVaTen = txtHovaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;

           

            db.SubmitChanges();
            MessageBox.Show("Cập nhật loại phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtTaiKhoan.Text = txtMatKhau.Text = txtHovaTen.Text = txtDienThoai.Text = txtDiaChi.Text = null;
            r = null;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhanVien.Rows[e.RowIndex];
                txtTaiKhoan.Text = r.Cells["username"].Value.ToString();
                txtMatKhau.Text = r.Cells["password"].Value.ToString();
                txtHovaTen.Text = r.Cells["hovaten"].Value.ToString();
                txtDienThoai.Text = r.Cells["dienthoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["diachi"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng nhập nhân viên muốn xóa", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
                MessageBox.Show("Bạn muốn xóa nhân viên : " + r.Cells["username"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    )
            {
                try
                {
                    var l = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["username"].Value.ToString());
                    db.NhanViens.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhân viên thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();

                    txtTaiKhoan.Text = txtMatKhau.Text = txtHovaTen.Text = txtDienThoai.Text = txtDiaChi.Text = null;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa loại phòng thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
