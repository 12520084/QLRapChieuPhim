using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class TheLoaiPhim_Pub
    {
        private string m_MaLP;
        private string m_TenLP;

        public string TenLP
        {
            get { return m_TenLP; }
            set { m_TenLP = value; }
        }

        public string MaLP
        {
            get { return m_MaLP; }
            set { m_MaLP = value; }
        }
    }
}
