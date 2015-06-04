using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class DoanhSoBanVe_Pub
    {
        private string m_TenPhim;
        private string m_LoaiSC;
        private int m_SoLuong;
        private float m_DoanhSo;
        private int m_SoTT;

        public int SoTT
        {
            get { return m_SoTT; }
            set { m_SoTT = value; }
        }

        public string TenPhim
        {
            get { return m_TenPhim; }
            set { m_TenPhim = value; }
        }

        public string LoaiSC
        {
            get { return m_LoaiSC; }
            set { m_LoaiSC = value; }
        }

        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }

        public float DoanhSo
        {
            get { return m_DoanhSo; }
            set { m_DoanhSo = value; }
        }
    }
}
