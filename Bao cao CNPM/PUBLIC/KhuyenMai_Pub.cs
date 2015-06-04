using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class KhuyenMai_Pub
    {
        private string m_MaKM;
        private string m_TenKM;
        private DateTime m_NgayBatDau;
        private DateTime m_NgayKetThuc;
        private string m_NoiDung;

        public string NoiDung
        {
            get { return m_NoiDung; }
            set { m_NoiDung = value; }
        }

        public DateTime NgayKetThuc
        {
            get { return m_NgayKetThuc; }
            set { m_NgayKetThuc = value; }
        }

        public DateTime NgayBatDau
        {
            get { return m_NgayBatDau; }
            set { m_NgayBatDau = value; }
        }

        public string TenKM
        {
            get { return m_TenKM; }
            set { m_TenKM = value; }
        }

        public string MaKM
        {
            get { return m_MaKM; }
            set { m_MaKM = value; }
        }
    }
}
