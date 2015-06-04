using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class VeBan_Pub
    {
        private string m_MaVe;
        private string m_MaGhe;
        private float m_GiaVe;
        private string m_LoaiSC;
        private DateTime m_NgayChieu;
        private DateTime m_GioChieu;
        private string m_TenPhim;
        private string m_PhongChieu;
        private string m_MaPDV;
        private string m_MaKH;
        private string m_MaNV;
        private string m_MaSC;

        public string MaSC
        {
            get { return m_MaSC; }
            set { m_MaSC = value; }
        }

        public string MaNV
        {
            get { return m_MaNV; }
            set { m_MaNV = value; }
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

        public string PhongChieu
        {
            get { return m_PhongChieu; }
            set { m_PhongChieu = value; }
        }
        public string TenPhim
        {
            get { return m_TenPhim; }
            set { m_TenPhim = value; }
        }

        public DateTime GioChieu
        {
            get { return m_GioChieu; }
            set { m_GioChieu = value; }
        }

        public DateTime NgayChieu
        {
            get { return m_NgayChieu; }
            set { m_NgayChieu = value; }
        }

        public string LoaiSC
        {
            get { return m_LoaiSC; }
            set { m_LoaiSC = value; }
        }

        public float GiaVe
        {
            get { return m_GiaVe; }
            set { m_GiaVe = value; }
        }

        public string MaGhe
        {
            get { return m_MaGhe; }
            set { m_MaGhe = value; }
        }

        public string MaVe
        {
            get { return m_MaVe; }
            set { m_MaVe = value; }
        }
    }
}
