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
    public partial class FormDonViTinh : Form
    {
        public FormDonViTinh()
        {
            InitializeComponent();
        }
        BLL_DanhMuc bd;
        DataTable dataTable;
        string err = string.Empty;

        private Database_KaraokeDataContext db;
        private string nhanvien = "admin";
        private void FormDonViTinh_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();
            bd = new BLL_DanhMuc();
            ShowData();
            #region
            dgvDVT.Columns["id"].HeaderText = "Mã ĐVT";
            dgvDVT.Columns["id"].Width = 100;
            dgvDVT.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDVT.Columns["TenDVT"].HeaderText = "Tên ĐVT";
            dgvDVT.Columns["TenDVT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion

        }

        private void ShowData()
        {
            #region
            /*
            var rs = (from d in db.DonViTinhs
                      select new
                      {
                          d.ID,
                          d.TenDVT
                      }).ToList();*/
            #endregion
            dataTable = new DataTable();
            dataTable = bd.LayDanhSachDVT(ref err);
            dgvDVT.DataSource = dataTable;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                DonViTinh dvt = new DonViTinh();
                dvt.TenDVT = txtDVT.Text;
                dvt.NguoiTao = nhanvien;
                dvt.NgayTao = DateTime.Now;
                db.DonViTinhs.InsertOnSubmit(dvt);
                db.SubmitChanges();
                MessageBox.Show("Thêm mới đơn vị tính thành công ", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                txtDVT.Text = null;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private DataGridViewRow r;
        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            r = dgvDVT.Rows[e.RowIndex];
            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x=>x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                dvt.TenDVT = txtDVT.Text;
                dvt.NgayCapNhat = DateTime.Now;
                dvt.NguoiCapNhat = nhanvien;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật đơn vị tính thành công", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                r = null;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị tính cần cập nhật", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(
                MessageBox.Show("Bạn thực sự muốn xóa đơn vị tính "+ r.Cells["TenDVT"].Value.ToString()+"?",
                 "xác nhận xóa",
                MessageBoxButtons.YesNo,            
                MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                db.DonViTinhs.DeleteOnSubmit(dvt);
                db.SubmitChanges();
                MessageBox.Show("Xóa đơn vị tính thành công", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                r = null;
            }
        }
    }
}
