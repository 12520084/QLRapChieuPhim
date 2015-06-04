using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiKhachHang_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public LoaiKhachHang_DAL()
        {
            m_sqlConnect.connect();
        }

        public List<LoaiKhachHang_Pub> GetLoaiKH()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetLoaiKH");
            List<LoaiKhachHang_Pub> _LloaiKHPub = new List<LoaiKhachHang_Pub>();



            while (reader.Read())
            {
                LoaiKhachHang_Pub _loaiKHPub = new LoaiKhachHang_Pub();
                _loaiKHPub.MaLoaiKH = reader["MaLoaiKH"].ToString();
                _loaiKHPub.TenLoaiKH = reader["TenLoaiKH"].ToString();
                _loaiKHPub.DiemToiThieu = int.Parse(reader["DiemToiThieu"].ToString());
                _loaiKHPub.HeSoUuDai = float.Parse(reader["HeSoUuDai"].ToString());


                _LloaiKHPub.Add(_loaiKHPub);
            }

            return _LloaiKHPub;
        }

        public LoaiKhachHang_Pub GetLoaiKHTheoMaLoaiKH(string _MaLoaiKH)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaLoaiKH", _MaLoaiKH));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetLoaiKHTheoMaLoaiKH", paramters);
            LoaiKhachHang_Pub _loaiKHPub = new LoaiKhachHang_Pub();

            while (reader.Read())
            {
                _loaiKHPub.MaLoaiKH = reader["MaLoaiKH"].ToString();
                _loaiKHPub.TenLoaiKH = reader["TenLoaiKH"].ToString();
                _loaiKHPub.DiemToiThieu = int.Parse(reader["DiemToiThieu"].ToString());
                _loaiKHPub.HeSoUuDai = float.Parse(reader["HeSoUuDai"].ToString());
            }

            return _loaiKHPub;
        }
    }
}
