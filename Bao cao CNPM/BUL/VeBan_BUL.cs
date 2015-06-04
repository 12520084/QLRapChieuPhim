using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class VeBan_BUL
    {
        private VeBan_DAL cls;
        public VeBan_BUL()
        {
            cls = new VeBan_DAL();
        }

        public void Insert(VeBan_Pub _info)
        {
            cls.Insert(_info);
        }

        public List<VeBan_Pub> GetVeTuLoaiSCvaTenPhim(string _LoaiSC, string _TenPhim)
        {
            return cls.GetVeTuLoaiSCvaTenPhim(_LoaiSC, _TenPhim);
        }
    }
}
