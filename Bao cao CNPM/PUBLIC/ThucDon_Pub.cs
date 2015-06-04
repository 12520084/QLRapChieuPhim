using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class ThucDon_Pub
    {
        private string m_MaTD;
        private string m_TenTD;
        private float m_Gia;
        private string m_HinhAnh;

        public string HinhAnh
        {
            get { return m_HinhAnh; }
            set { m_HinhAnh = value; }
        }

        public float Gia
        {
            get { return m_Gia; }
            set { m_Gia = value; }
        }

        public string TenTD
        {
            get { return m_TenTD; }
            set { m_TenTD = value; }
        }

        public string MaTD
        {
            get { return m_MaTD; }
            set { m_MaTD = value; }
        }
    }
}
