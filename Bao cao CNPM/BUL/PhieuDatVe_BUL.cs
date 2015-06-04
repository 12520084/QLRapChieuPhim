using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class PhieuDatVe_BUL
    {
        private PhieuDatVe_DAL cls;
        public PhieuDatVe_BUL()
        {
            cls = new PhieuDatVe_DAL();
        }
        public void Insert(PhieuDatVe_Pub _info)
        {
            cls.Insert(_info);
        }
        public List<PhieuDatVe_Pub> GetPDVTuMaKH(string _MaKH)
        {
            return cls.GetPDVTuMaKH(_MaKH);
        }
        public PhieuDatVe_Pub GetPDVTuMaPDV(string _MaPDV)
        {
            return cls.GetPDVTuMaPDV(_MaPDV);
        }
        public void XoaPDVTuMaPDV(PhieuDatVe_Pub _info)
        {
            cls.XoaPDVTuMaPDV(_info);
        }
        public void Update(PhieuDatVe_Pub _info_update)
        {
            cls.Update(_info_update);
        }
    }
}
