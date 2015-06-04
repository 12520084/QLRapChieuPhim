using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class HeSoKM_Pub
    {
        private string m_MaHSMK;
        private string m_MaKM;
        private string m_TenLoaiKH;
        private float m_HeSoKM;

        public string MaHSMK
        {
            get { return m_MaHSMK; }
            set { m_MaHSMK = value; }
        }

        public float HeSoKM
        {
            get { return m_HeSoKM; }
            set { m_HeSoKM = value; }
        }

        public string TenLoaiKH
        {
            get { return m_TenLoaiKH; }
            set { m_TenLoaiKH = value; }
        }

        public string MaKM
        {
            get { return m_MaKM; }
            set { m_MaKM = value; }
        }
    }
}
