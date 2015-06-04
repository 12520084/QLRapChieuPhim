using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class HoaDonTD_BUL
    {
        private HoaDonTD_DAL cls;
        public HoaDonTD_BUL()
        {
            cls = new HoaDonTD_DAL();
        }

        public void Insert(HoaDonTD_Pub _info)
        {
            cls.Insert(_info);
        }
    }
}
