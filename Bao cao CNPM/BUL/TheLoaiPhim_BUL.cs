using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using DAL;

namespace BUL
{
    public class TheLoaiPhim_BUL
    {
        private TheLoaiPhim_DAL cls;
        public TheLoaiPhim_BUL()
        {
            cls = new TheLoaiPhim_DAL();
        }
        public void Insert(TheLoaiPhim_Pub _info)
        {
            cls.Insert(_info);
        }

        public List<TheLoaiPhim_Pub> GetTheLoai()
        {
            return cls.GetTheLoai();
        }
    }
}
