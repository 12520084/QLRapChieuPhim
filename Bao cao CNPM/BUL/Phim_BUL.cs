using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class Phim_BUL
    {
        private Phim_DAL cls;
        public Phim_BUL()
        {
            cls = new Phim_DAL();
        }
        public void Insert(Phim_Pub _info)
        {
            cls.Insert(_info);
        }

        public List<Phim_Pub> GetMaPhim()
        {
            return cls.GetMaPhim();
        }

        public List<Phim_Pub> GetMaPhimTheoTheLoai(string _TheLoai)
        {
            return cls.GetPhimTheoTheLoai(_TheLoai);
        }

        public void Update(Phim_Pub _info_update)
        {
            cls.Update(_info_update);
        }

        public Phim_Pub GetPhimTheoMaPhim(string _MaPhim)
        {
            return cls.GetPhimTheoMaPhim(_MaPhim);
        }
    }
}
