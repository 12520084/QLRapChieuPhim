using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using DAL;

namespace BUL
{
    public class KhachHang_BUL
    {
        private KhachHang_DAL cls;

        public KhachHang_BUL()
        {
            cls = new KhachHang_DAL();
        }

        public void Insert(KhachHang_Pub _info)
        {
            cls.Insert(_info);
        }

        public KhachHang_Pub GetKHTuMaKH(string _MaKH)
        {
            return cls.GetKHTuMaKH(_MaKH);
        }

        public float GetHeSoUuDaiTuTenLoaiKH(string _TenLoaiKH)
        {
            return cls.GetHeSoUuDaiTuTenLoaiKH(_TenLoaiKH);
        }

        public float GetHeSoKMTuMaKMVaLoaiKH(string _MaKM, string _TenLoaiKH)
        {
            return cls.GetHeSoKMTuMaKMVaLoaiKH(_MaKM, _TenLoaiKH);
        }

        public void Update(KhachHang_Pub _info_update)
        {
            cls.Update(_info_update);
        }

        public void UpdatePassword(string _Password, string _MaKH)
        {
            cls.UpdatePassword(_Password, _MaKH);
        }
    }
}
