using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class SuatChieu_Pub
    {
        private string m_MaSC;
        private DateTime m_GioChieu;
        private DateTime m_NgayChieu;
        private string m_PhongChieu;
        private string m_LoaiSuatChieu;
        private string m_TenPhim;
        private float m_Gia;

        public float Gia
        {
            get { return m_Gia; }
            set { m_Gia = value; }
        }

        public string TenPhim
        {
            get { return m_TenPhim; }
            set { m_TenPhim = value; }
        }

        public string LoaiSuatChieu
        {
            get { return m_LoaiSuatChieu; }
            set { m_LoaiSuatChieu = value; }
        }

        public string PhongChieu
        {
            get { return m_PhongChieu; }
            set { m_PhongChieu = value; }
        }

        public DateTime NgayChieu
        {
            get { return m_NgayChieu; }
            set { m_NgayChieu = value; }
        }

        public DateTime GioChieu
        {
            get { return m_GioChieu; }
            set { m_GioChieu = value; }
        }

        public string MaSC
        {
            get { return m_MaSC; }
            set { m_MaSC = value; }
        }
    }
}
