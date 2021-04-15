using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKaraoke.QLHeThong
{
    public class BLLHeThong
    {
        Database data;
        public BLLHeThong()
        {
            data = new Database();
        }

        public DataTable KiemTraDangNhap(ref string err, string tenDangNhap, string matKhau)
        {
            return data.GetDataTable(ref err, "PSP_NhanVien_KiemTraDangNhap", CommandType.StoredProcedure,
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau));
        }

    }
}
