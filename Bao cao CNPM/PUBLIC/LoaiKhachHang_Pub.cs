using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class LoaiKhachHang_Pub
    {
        private string m_MaLoaiKH;

        public string MaLoaiKH
        {
            get { return m_MaLoaiKH; }
            set { m_MaLoaiKH = value; }
        }
        private string m_TenLoaiKH;

        public string TenLoaiKH
        {
            get { return m_TenLoaiKH; }
            set { m_TenLoaiKH = value; }
        }

        private int m_DiemToiThieu;

        public int DiemToiThieu
        {
            get { return m_DiemToiThieu; }
            set { m_DiemToiThieu = value; }
        }
        private float m_HeSoUuDai;

        public float HeSoUuDai
        {
            get { return m_HeSoUuDai; }
            set { m_HeSoUuDai = value; }
        }
    }
}
