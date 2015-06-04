using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using DAL;

namespace BUL
{
    public class LoaiSuatChieu_BUL
    {
        private LoaiSuatChieu_DAL cls;
        public LoaiSuatChieu_BUL()
        {
            cls = new LoaiSuatChieu_DAL();
        }

        public List<LoaiSuatChieu_Pub> GetLoaiSuatChieu()
        {
            return cls.GetLoaiSuatChieu();
        }
    }
}
