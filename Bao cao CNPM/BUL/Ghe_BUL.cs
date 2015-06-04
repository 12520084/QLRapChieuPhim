using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using DAL;

namespace BUL
{
    public class Ghe_BUL
    {
        private Ghe_DAL cls;

        public Ghe_BUL()
        {
            cls = new Ghe_DAL();
        }

        public void Update(Ghe_Pub _info)
        {
            cls.Update(_info);
        }

        public List<Ghe_Pub> GetGheTheoSuatChieu(string _SC)
        {
            return cls.GetGheTheoSuatChieu(_SC);
        }
    }
}
