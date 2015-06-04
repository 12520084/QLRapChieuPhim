using DAL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ChucVu_BUL
    {
        private ChucVu_DAL cls;

        public ChucVu_BUL()
        {
            cls = new ChucVu_DAL();
        }

        public List<ChucVu_Pub> GetCV()
        {
            return cls.GetCV();
        }

        public ChucVu_Pub GetCVTheoMaCV(string _MaCV)
        {
            return cls.GetCVTheoMaCV(_MaCV);
        }
    }
}
