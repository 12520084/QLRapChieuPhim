using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class PhongChieu_BUL
    {
        private PhongChieu_DAL cls;
        public PhongChieu_BUL()
        {
            cls = new PhongChieu_DAL();
        }
        public void Insert(PhongChieu_Pub _info)
        {
            cls.Insert(_info);
        }

        public List<PhongChieu_Pub> GetPhongChieu()
        {
            return cls.GetPhongChieu();
        }
    }
}
