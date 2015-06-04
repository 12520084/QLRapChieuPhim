using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class HeSoKM_BUL
    {
        private HeSoKM_DAL cls;
        public HeSoKM_BUL()
        {
            cls = new HeSoKM_DAL();
        }

        public void Insert(HeSoKM_Pub _info)
        {
            cls.Insert(_info);
        }

        public HeSoKM_Pub GetHSKMTheoMaKMvaLoaiKM(string _MaKM, string _TenLoaiKH)
        {
            return cls.GetHSKMTheoMaKMvaLoaiKM(_MaKM, _TenLoaiKH);
        }

        public void UpdateHSKM(HeSoKM_Pub _info_Update)
        {
            cls.UpdateHSKM(_info_Update);
        }
    }
}
