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
    public partial class FormOrder : Form
    {
        public FormOrder(int idHoaDon,string tenphong, DataGridViewRow r)
        {

            this.idHoaDon = idHoaDon;
            this.tenphong = tenphong;
            this.r = r;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private int idHoaDon;
        private DataGridViewRow r;
        private string tenphong;
        private Database_KaraokeDataContext db;

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();

            this.lblTenMatHang.Text = "Mặt hàng yêu cầu :" + r.Cells["tenhang"].Value.ToString()+"["+ r.Cells["dvt"].Value.ToString() + "]";
            this.lblPhong.Text = string.Format("Phòng phục vụ: {0}",tenphong);

            
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sl = 0;
            try
            {
                sl = int.Parse(txtSL.Text);
                if (sl == 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Select();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng không hợp lệ", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSL.Select();
                return;
            }

            

            var item = db.ChiTietHoaDons.SingleOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["mahang"].Value.ToString()));
            if (item != null)
            {
                item.SL += sl;
                db.SubmitChanges();
            }
            else
            {
                var ct = new ChiTietHoaDon();
                ct.IDHoaDon = idHoaDon;
                ct.IDMatHang = int.Parse(r.Cells["mahang"].Value.ToString());
                ct.SL = sl;

                var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["mahang"].Value.ToString()));

                ct.DonGia = mh.DonGiaBan;

                db.ChiTietHoaDons.InsertOnSubmit(ct);
                db.SubmitChanges();
            }

            MessageBox.Show("Thêm mặt hàng vào phòng " + tenphong + "thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
