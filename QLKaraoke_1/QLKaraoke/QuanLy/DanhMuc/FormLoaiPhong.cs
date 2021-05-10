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
    public partial class FormLoaiPhong : Form
    {
        public FormLoaiPhong()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";
        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            ShowData();

            dgvLoaiPhong.Columns["id"].HeaderText = "Mã loại";
            dgvLoaiPhong.Columns["tenloaiphong"].HeaderText = "Tên loại phòng";
            dgvLoaiPhong.Columns["dongia"].HeaderText = "Đơn giá";

            dgvLoaiPhong.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiPhong.Columns["dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLoaiPhong.Columns["id"].Width = 100;
            dgvLoaiPhong.Columns["dongia"].Width = 150;
            dgvLoaiPhong.Columns["tenloaiphong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLoaiPhong.Columns["dongia"].DefaultCellStyle.Format = "N0";


        }

        private void ShowData()
        {
            var rs = (from l in db.LoaiPhongs
                      select new
                      {
                          l.ID,
                          l.TenLoaiPhong,
                          l.DonGia
                      });
            dgvLoaiPhong.DataSource = rs;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiPhong.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                return;
            }

            LoaiPhong l = new LoaiPhong();
            l.TenLoaiPhong = txtTenLoaiPhong.Text;
            l.DonGia = int.Parse(txtDonGia.Text);
            l.NgayTao = DateTime.Now;
            l.NguoiTao = nhanvien;

            db.LoaiPhongs.InsertOnSubmit(l);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới loại phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtDonGia.Text = "0";
            txtTenLoaiPhong.Text = null;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng nhập loại phòng muốn cập nhật", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                return;
            }

            var l = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            l.TenLoaiPhong = txtTenLoaiPhong.Text;
            l.DonGia = int.Parse(txtDonGia.Text);

            l.NgayCapNhat = DateTime.Now;
            l.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật loại phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            txtDonGia.Text = "0";
            txtTenLoaiPhong.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng nhập loại phòng muốn xóa", "chú ý ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(
                MessageBox.Show("Bạn muốn xóa loại phòng : "+r.Cells["tenloaiphong"].Value.ToString()+ "?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes
                    )
            {
                try
                {
                    var l = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.LoaiPhongs.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa loại phòng thành công ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();

                    txtDonGia.Text = "0";
                    txtTenLoaiPhong.Text = null;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa loại phòng thất bại ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvLoaiPhong.Rows[e.RowIndex];
                txtTenLoaiPhong.Text = r.Cells["tenloaiphong"].Value.ToString();
                txtDonGia.Text = r.Cells["dongia"].Value.ToString();
            }
        }
    }
}
