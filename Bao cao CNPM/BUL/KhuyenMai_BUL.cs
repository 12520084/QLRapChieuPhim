using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class KhuyenMai_BUL
    {
        private KhuyenMai_DAL cls;
        public KhuyenMai_BUL()
        { cls = new KhuyenMai_DAL(); }
        public void Insert(KhuyenMai_Pub _info)
        {
            cls.Insert(_info);
        }
        public List<KhuyenMai_Pub> GetKM()
        {
            return cls.GetKM();
        }

        public KhuyenMai_Pub GetKMTheoMaKM(string _MaKM)
        {
            return cls.GetKMTheoMaKM(_MaKM);
        }

        public void Update(KhuyenMai_Pub _info_update)
        {
            cls.Update(_info_update);
        }
    }
}
