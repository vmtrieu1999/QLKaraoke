using QLKaraoke.QLHeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKaraoke
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        BLLHeThong bd;
        DataTable dataTable;
        string err = string.Empty;

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            bd = new BLLHeThong();
        }

        private bool DangNhap(string tenDangNhap, string matKhau)
        {
            dataTable = new DataTable();
            dataTable = bd.KiemTraDangNhap(ref err, tenDangNhap, matKhau);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["code"].ToString().Equals("1"))
                {
                    
                    return true;
                }
            }
            return false;
        }


        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (DangNhap(txtUser.Text, txtPasswork.Text))
            {                             
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai \n " + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Text = null;
                txtPasswork.Text = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
