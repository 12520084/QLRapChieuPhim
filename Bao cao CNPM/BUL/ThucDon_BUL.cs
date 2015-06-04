using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class ThucDon_BUL
    {
        private ThucDon_DAL cls;
        public ThucDon_BUL()
        {
            cls = new ThucDon_DAL();
        }
        public void Insert(ThucDon_Pub _info)
        {
            cls.Insert(_info);
        }
    }
}
