using DAL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class PhongBan_BUL
    {
        private PhongBan_DAL cls;

        public PhongBan_BUL()
        {
            cls = new PhongBan_DAL();
        }

        public List<PhongBan_Pub> GetPB()
        {
            return cls.GetPB();
        }

        public PhongBan_Pub GetPBTheoMaPB(string _MaPB)
        {
            return cls.GetPBTheoMaPB(_MaPB);
        }
    }
}
