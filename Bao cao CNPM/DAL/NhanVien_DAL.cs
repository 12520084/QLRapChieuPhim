using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVien_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public sqlConnect SqlConnect
        {
            get { return m_sqlConnect; }
            set { m_sqlConnect = value; }
        }

        public NhanVien_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(NhanVien_Pub _info)
        {
            string insertCommand = @"INSERT INTO  NHANVIEN(MaNV, MaPB, MaCV, HoTen, NamSinh, GioiTinh, DienThoai, Email, QueQuan, DiaChi, CMND, NgayVaoLam, HinhAnh, MatKhau) VALUES('" +
                _info.MaNV + "', N'" +
                _info.MaPB + "', N'" +
                _info.MaCV + "', N'" +
                _info.HoTen + "', '" + 
                _info.NamSinh.ToShortDateString() + "', '" +
                _info.GioiTinh + "', '" +
                _info.DienThoai + "', '" +
                _info.Email + "', N'" +
                _info.QueQuan + "', N'" +
                _info.DiaChi + "', N'" +
                _info.CMND + "', '" +
                _info.NgayVaoLam.ToShortDateString() + "', '" +
                _info.HinhAnh + "', '" +
                _info.MatKhau+ "')";

            m_sqlConnect.executeNonQuery(insertCommand);
        }

        public NhanVien_Pub GetNV(string _MaNV)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaNV", _MaNV));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetDSHSTuMaNV", paramters);
            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();

            while (reader.Read())
            {
                _nhanvienPub.MaNV = reader["MaNV"].ToString();
                _nhanvienPub.HoTen = reader["HoTen"].ToString();
                _nhanvienPub.NamSinh = DateTime.Parse(reader["NamSinh"].ToString());
                _nhanvienPub.GioiTinh = bool.Parse(reader["GioiTinh"].ToString());
                _nhanvienPub.DienThoai = reader["DienThoai"].ToString();
                _nhanvienPub.Email = reader["Email"].ToString();
                _nhanvienPub.QueQuan = reader["QueQuan"].ToString();
                _nhanvienPub.DiaChi = reader["DiaChi"].ToString();
                _nhanvienPub.CMND = reader["CMND"].ToString();
                _nhanvienPub.MaCV = reader["MaCV"].ToString();
                _nhanvienPub.MaPB = reader["MaPB"].ToString();
                _nhanvienPub.NgayVaoLam = DateTime.Parse(reader["NgayVaoLam"].ToString());
                _nhanvienPub.HinhAnh = reader["HinhAnh"].ToString();
                _nhanvienPub.MatKhau = reader["MatKhau"].ToString();
            }

            m_sqlConnect.disconnect();
            return _nhanvienPub;
        }

        public List<NhanVien_Pub> GetNVTheoPB(string _MaPB)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaPB", _MaPB));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetNVTheoPB", paramters);

            List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
            NhanVien_Pub _nhanvienPub;

            while (reader.Read())
            {
                _nhanvienPub = new NhanVien_Pub();
                _nhanvienPub.MaNV = reader["MaNV"].ToString();
                _nhanvienPub.HoTen = reader["HoTen"].ToString();
                _nhanvienPub.NamSinh = DateTime.Parse(reader["NamSinh"].ToString());
                _nhanvienPub.GioiTinh = bool.Parse(reader["GioiTinh"].ToString());
                _nhanvienPub.DienThoai = reader["DienThoai"].ToString();
                _nhanvienPub.Email = reader["Email"].ToString();
                _nhanvienPub.QueQuan = reader["QueQuan"].ToString();
                _nhanvienPub.DiaChi = reader["DiaChi"].ToString();
                _nhanvienPub.CMND = reader["CMND"].ToString();
                _nhanvienPub.MaCV = reader["MaCV"].ToString();
                _nhanvienPub.MaPB = reader["MaPB"].ToString();
                _nhanvienPub.NgayVaoLam = DateTime.Parse(reader["NgayVaoLam"].ToString());
                _nhanvienPub.HinhAnh = reader["HinhAnh"].ToString();
                _nhanvienPub.MatKhau = reader["MatKhau"].ToString();

                _LnhanvienPub.Add(_nhanvienPub);
            }

            return _LnhanvienPub;
        }

        public List<NhanVien_Pub> GetQuanLy(string _MaPB)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaPB", _MaPB));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetQuanLy", paramters);

            List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
            NhanVien_Pub _nhanvienPub;

            while (reader.Read())
            {
                _nhanvienPub = new NhanVien_Pub();
                _nhanvienPub.MaNV = reader["MaNV"].ToString();
                _nhanvienPub.HoTen = reader["HoTen"].ToString();
                _nhanvienPub.NamSinh = DateTime.Parse(reader["NamSinh"].ToString());
                _nhanvienPub.GioiTinh = bool.Parse(reader["GioiTinh"].ToString());
                _nhanvienPub.DienThoai = reader["DienThoai"].ToString();
                _nhanvienPub.Email = reader["Email"].ToString();
                _nhanvienPub.QueQuan = reader["QueQuan"].ToString();
                _nhanvienPub.DiaChi = reader["DiaChi"].ToString();
                _nhanvienPub.CMND = reader["CMND"].ToString();
                _nhanvienPub.MaCV = reader["MaCV"].ToString();
                _nhanvienPub.MaPB = reader["MaPB"].ToString();
                _nhanvienPub.NgayVaoLam = DateTime.Parse(reader["NgayVaoLam"].ToString());
                _nhanvienPub.HinhAnh = reader["HinhAnh"].ToString();
                _nhanvienPub.MatKhau = reader["MatKhau"].ToString();

                _LnhanvienPub.Add(_nhanvienPub);
            }

            return _LnhanvienPub;
        }

        public void Update(NhanVien_Pub _nhanvienPub)
        {
            m_sqlConnect.connect();
            string updateCommand = "UPDATE NHANVIEN " +
                        "SET HOTEN = N'" + _nhanvienPub.HoTen.ToString() + "', " +
                        " NAMSINH = N'" + _nhanvienPub.NamSinh.ToShortDateString() + "', " +
                        " GIOITINH = '" + _nhanvienPub.GioiTinh.ToString()+ "', " +
                        " DIENTHOAI = '" + _nhanvienPub.DienThoai.ToString() + "', " +
                        " EMAIL = '" + _nhanvienPub.Email.ToString() + "', " +
                        " QUEQUAN = N'" + _nhanvienPub.QueQuan.ToString() + "', " +
                        " DIACHI = N'" + _nhanvienPub.DiaChi.ToString() + "', " +
                        " CMND = '" + _nhanvienPub.CMND.ToString() + "', " +
                        " MACV = '" + _nhanvienPub.MaCV.ToString() + "', " +
                        " MAPB = '" + _nhanvienPub.MaPB.ToString() + "', " +
                        " NGAYVAOLAM = '" + _nhanvienPub.NgayVaoLam.ToShortDateString() + "', " +
                        " HINHANH = '" + _nhanvienPub.HinhAnh.ToString() + "'" +
                        " WHERE MANV = '" + _nhanvienPub.MaNV.ToString() + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }


        public void ResetChucVu(string _MaPB)
        {
            string _cv = "CV0002";

            m_sqlConnect.connect();
            string updateCommand = "UPDATE NHANVIEN " +
                        "SET MACV = '" + _cv + "'" +
                        " WHERE MAPB = '" + _MaPB + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public void UpdatePassword(string _password, string _MaNV)
        {
            string updateCommand = "UPDATE NHANVIEN " +
            "SET MatKhau = '" + _password.ToString() + "' " +
            "WHERE MaNV = '" + _MaNV.ToString() + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public void Delete(string _MaNV)
        {
            string deleteCommad = "delete from NhanVien where MaNV = '" + _MaNV + "'";

            m_sqlConnect.executeNonQuery(deleteCommad);
        }
    }
}