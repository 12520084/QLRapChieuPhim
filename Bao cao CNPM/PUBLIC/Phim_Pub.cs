using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class Phim_Pub
    {
        private string m_MaPhim;
        private string m_TenPhim;
        private string m_Poster;
        private int m_ThoiLuong;
        private string m_DaoDien;
        private string m_DienVien;
        private DateTime m_NamPhatHanh;
        private string m_NuocSanXuat;
        private string m_TheLoai;
        private string m_NoiDung;
        private int m_TuoiQuyDinh;
        private DateTime m_NgayChieu;

        public DateTime NgayChieu
        {
            get { return m_NgayChieu; }
            set { m_NgayChieu = value; }
        }

        public int TuoiQuyDinh
        {
            get { return m_TuoiQuyDinh; }
            set { m_TuoiQuyDinh = value; }
        }

        public string NoiDung
        {
            get { return m_NoiDung; }
            set { m_NoiDung = value; }
        }

        public string TheLoai
        {
            get { return m_TheLoai; }
            set { m_TheLoai = value; }
        }

        public string NuocSanXuat
        {
            get { return m_NuocSanXuat; }
            set { m_NuocSanXuat = value; }
        }

        public DateTime NamPhatHanh
        {
            get { return m_NamPhatHanh; }
            set { m_NamPhatHanh = value; }
        }

        public string DienVien
        {
            get { return m_DienVien; }
            set { m_DienVien = value; }
        }

        public string DaoDien
        {
            get { return m_DaoDien; }
            set { m_DaoDien = value; }
        }

        public int ThoiLuong
        {
            get { return m_ThoiLuong; }
            set { m_ThoiLuong = value; }
        }

        public string Poster
        {
            get { return m_Poster; }
            set { m_Poster = value; }
        }

        public string TenPhim
        {
            get { return m_TenPhim; }
            set { m_TenPhim = value; }
        }

        public string MaPhim
        {
            get { return m_MaPhim; }
            set { m_MaPhim = value; }
        }
    }
}
