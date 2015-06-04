using DAL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUL
{
    public class LoaiKhachHang_BUL
    {
        private LoaiKhachHang_DAL cls;

        public LoaiKhachHang_BUL()
        {
            cls = new LoaiKhachHang_DAL();
        }

        public List<LoaiKhachHang_Pub> GetCV()
        {
            return cls.GetLoaiKH();
        }

        public LoaiKhachHang_Pub GetLoaiKHTheoMaLoaiKH(string _MaLoaiKH)
        {
            return cls.GetLoaiKHTheoMaLoaiKH(_MaLoaiKH);
        }
    }
}
