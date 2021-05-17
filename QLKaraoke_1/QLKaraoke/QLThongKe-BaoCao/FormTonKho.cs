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

namespace QLKaraoke.QLThongKe_BaoCao
{
    public partial class FormTonKho : Form
    {
        public FormTonKho()
        {
            InitializeComponent();
        }
        private Database_KaraokeDataContext db;
        private void FormTonKho_Load(object sender, EventArgs e)
        {
            db = new Database_KaraokeDataContext();

        }

        private int LoaiThongKe = -1;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rbtDaHet.Checked)
            {
                return;
            }
            if (rbtGanHet.Checked)
            {
                return;
            }
            if(rbtTatCa.Checked)
            {
                return;
            }
        }  

       
        
    }
}
