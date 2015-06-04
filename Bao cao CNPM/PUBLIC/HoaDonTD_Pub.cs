using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class HoaDonTD_Pub
    {
        private string m_MaHDTD;
        private DateTime m_NgayLap;
        private string m_TenTD;
        private int m_SoLuong;
        private float m_DonGia;
        private float m_TongTriGia;
        private string m_MaKH;
        private string m_MaNV;

        public string MaHDTD
        {
            get { return m_MaHDTD; }
            set { m_MaHDTD = value; }
        }

        public DateTime NgayLap
        {
            get { return m_NgayLap; }
            set { m_NgayLap = value; }
        }


        public string TenTD
        {
            get { return m_TenTD; }
            set { m_TenTD = value; }
        }


        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }


        public float DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }


        public float TongTriGia
        {
            get { return m_TongTriGia; }
            set { m_TongTriGia = value; }
        }


        public string MaKH
        {
            get { return m_MaKH; }
            set { m_MaKH = value; }
        }


        public string MaNV
        {
            get { return m_MaNV; }
            set { m_MaNV = value; }
        }


    }
}
