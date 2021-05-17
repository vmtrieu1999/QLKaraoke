using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKaraoke.QuanLy.DanhMuc
{
    public class BLL_DanhMuc
    {
        Database data;
        public BLL_DanhMuc()
        {
            data = new Database();

        }

        public DataTable LayDanhSachPhong(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachPhong", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachLoaiPhong(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachLoaiPhong", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachMatHang(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachMatHang", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachDVT(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachDVT", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachNhaCC(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachNhaCC", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachNhanVien(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_DanhSach_LayDanhSachNhanVien", CommandType.StoredProcedure, null);
        }
    }
}
