
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class NhanVien_Pub
    {
        private string m_MaNV;
        private string m_MaPB;
        private string m_MaCV;
        private string m_HoTen;
        private DateTime m_NamSinh;
        private bool m_GioiTinh;
        private string m_DienThoai;
        private string m_Email;
        private string m_QueQuan;
        private string m_CMND;
        private string m_DiaChi;
        private DateTime m_NgayVaoLam;
        private string m_HinhAnh;
        private string m_MatKhau;

        public string MatKhau
        {
            get { return m_MatKhau; }
            set { m_MatKhau = value; }
        }

        public string HinhAnh
        {
            get { return m_HinhAnh; }
            set { m_HinhAnh = value; }
        }

        public DateTime NgayVaoLam
        {
            get { return m_NgayVaoLam; }
            set { m_NgayVaoLam = value; }
        }


        public string CMND
        {
            get { return m_CMND; }
            set { m_CMND = value; }
        }

        public string QueQuan
        {
            get { return m_QueQuan; }
            set { m_QueQuan = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public string DienThoai
        {
            get { return m_DienThoai; }
            set { m_DienThoai = value; }
        }

        public bool GioiTinh
        {
            get { return m_GioiTinh; }
            set { m_GioiTinh = value; }
        }

        public DateTime NamSinh
        {
            get { return m_NamSinh; }
            set { m_NamSinh = value; }
        }

        public string HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }

        public string MaNV
        {
            get { return m_MaNV; }
            set { m_MaNV = value; }
        }

        public string MaPB
        {
            get { return m_MaPB; }
            set { m_MaPB = value; }
        }

        public string DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
        public string MaCV
        {
            get { return m_MaCV; }
            set { m_MaCV = value; }
        }

        public NhanVien_Pub()
        {
            m_GioiTinh = false;
        }
    }
}
