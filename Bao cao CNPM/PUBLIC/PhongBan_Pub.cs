using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class PhongBan_Pub
    {
        private string m_MaPB;

        private int m_HeSL;

        public int HeSL
        {
            get { return m_HeSL; }
            set { m_HeSL = value; }
        }

        public string MaPB
        {
            get { return m_MaPB; }
            set { m_MaPB = value; }
        }

        private string m_TenPB;

        public string TenPB
        {
            get { return m_TenPB; }
            set { m_TenPB = value; }
        }


    }
}
