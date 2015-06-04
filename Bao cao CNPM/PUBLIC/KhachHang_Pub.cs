using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class KhachHang_Pub
    {
        private string m_MaKH;
        private string m_MaLoaiKH;
        private string m_HoTen;
        private DateTime m_NamSinh;
        private bool m_GioiTinh;
        private string m_DiaChi;
        private string m_SoDT;
        private string m_Email;
        private string m_CMND;
        private DateTime m_NgayDangKy;
        private string m_HinhAnh;
        private string m_MatKhau;
        private int m_Diem;


        public string MaKH
        {
            get { return m_MaKH; }
            set { m_MaKH = value; }
        }


        public string HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }


        public DateTime NamSinh
        {
            get { return m_NamSinh; }
            set { m_NamSinh = value; }
        }


        public bool GioiTinh
        {
            get { return m_GioiTinh; }
            set { m_GioiTinh = value; }
        }


        public string DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }


        public string SoDT
        {
            get { return m_SoDT; }
            set { m_SoDT = value; }
        }

        public int Diem
        {
            get { return m_Diem; }
            set { m_Diem = value; }
        }

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

        public DateTime NgayDangKy
        {
            get { return m_NgayDangKy; }
            set { m_NgayDangKy = value; }
        }

        public string CMND
        {
            get { return m_CMND; }
            set { m_CMND = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public string MaLoaiKH
        {
            get { return m_MaLoaiKH; }
            set { m_MaLoaiKH = value; }
        }

    }
}
