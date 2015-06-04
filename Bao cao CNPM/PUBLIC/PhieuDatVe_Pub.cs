using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class PhieuDatVe_Pub
    {
        private string m_MaPDV;
        private string m_MaKH;
        private DateTime m_GioChieu;
        private string m_PhongChieu;
        private string m_MaGhe;
        private string m_TenPhim;
        private DateTime m_NgayChieu;
        private float m_TriGia;
        private DateTime m_NgayDatVe;
        private string m_MaSC;

        public string MaSC
        {
            get { return m_MaSC; }
            set { m_MaSC = value; }
        }

        public DateTime NgayDatVe
        {
            get { return m_NgayDatVe; }
            set { m_NgayDatVe = value; }
        }

        public float TriGia
        {
            get { return m_TriGia; }
            set { m_TriGia = value; }
        }

        public DateTime NgayChieu
        {
            get { return m_NgayChieu; }
            set { m_NgayChieu = value; }
        }

        public string TenPhim
        {
            get { return m_TenPhim; }
            set { m_TenPhim = value; }
        }

        public string MaGhe
        {
            get { return m_MaGhe; }
            set { m_MaGhe = value; }
        }

        public string PhongChieu
        {
            get { return m_PhongChieu; }
            set { m_PhongChieu = value; }
        }

        public DateTime GioChieu
        {
            get { return m_GioChieu; }
            set { m_GioChieu = value; }
        }

        public string MaKH
        {
            get { return m_MaKH; }
            set { m_MaKH = value; }
        }

        public string MaPDV
        {
            get { return m_MaPDV; }
            set { m_MaPDV = value; }
        }
    }
}
