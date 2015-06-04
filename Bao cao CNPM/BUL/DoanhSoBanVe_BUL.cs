using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using PUBLIC;

namespace BUL
{
    public class DoanhSoBanVe_BUL
    {
        private DoanhSoBanVe_DAL cls;

        public DoanhSoBanVe_BUL()
        {
            cls = new DoanhSoBanVe_DAL();
        }

        public void Insert(DoanhSoBanVe_Pub _info)
        {
            cls.Insert(_info);
        }

        public void DeleteTable()
        {

            cls.DeleteTable();
        }
    }
}
