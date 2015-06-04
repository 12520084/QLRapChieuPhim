using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class SuatChieu_BUL
    {
        private SuatChieu_DAL cls;
        public SuatChieu_BUL()
        {
            cls = new SuatChieu_DAL();
        }
        public void Insert(SuatChieu_Pub _info)
        {
            cls.Insert(_info);
        }

        public List<SuatChieu_Pub> GetSuatChieuTheoTenPhim(string _TenPhim)
        {
            return cls.GetSuatChieuTheoTenPhim(_TenPhim);
        }

        public List<SuatChieu_Pub> GetSuatChieu()
        {
            return cls.GetSuatChieu();
        }

        public SuatChieu_Pub GetSuatChieuTheoMaSC(string _MaSC)
        {
            return cls.GetSuatChieuTheoMaSC(_MaSC);
        }

        public void Update(SuatChieu_Pub _info_update)
        {
            cls.Update(_info_update);
        }

        public List<string> GetLoaiSC()
        {
            return cls.GetLoaiSC();
        }
    }
}
