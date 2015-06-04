using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHang_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public KhachHang_DAL()
        {
            m_sqlConnect.connect();
        }

        // thêm một khách hàng từ form nhập khách hàng
        public void Insert(KhachHang_Pub _info)
        {
            _info.MaKH = GetMa("KH", GetIndex_DAL.GetIndexKhachHang());
            string insertCommand = @"INSERT INTO KHACHHANG (MaKH, MaLoaiKH, HoTen, NamSinh, GioiTinh, DiaChi, SoDT, Email, CMND, NgayDangKi, MatKhau, Diem) VALUES('" +
                _info.MaKH + "', N'" +
                _info.MaLoaiKH + "','" +
                _info.HoTen + "', '" + _info.NamSinh.ToShortDateString() + "', '" +
                _info.GioiTinh + "', N'" +
                _info.DiaChi + "', '" +
                _info.SoDT + "', '" +
                _info.Email + "', " +
                _info.CMND + ", N'" +
                _info.NgayDangKy.ToShortDateString() + "', '" +
                _info.MatKhau + "', " + 
                _info.Diem + ")";

            m_sqlConnect.executeNonQuery(insertCommand);
            GetIndex_DAL.SetIndexKhachHang(GetIndex_DAL.GetIndexKhachHang() + 1);
        }

        public void Update(KhachHang_Pub _info_update)
        {
            string updateCommand = "UPDATE KHACHHANG SET "+
                "HoTen = N'" + _info_update.HoTen.ToString() + "', "+ 
                "DiaChi = N'" + _info_update.DiaChi.ToString() + "', "+
                "SoDT = '" + _info_update.SoDT.ToString() + "', " +
                "CMND = '" + _info_update.CMND.ToString() + "', " +
                "Email = '" + _info_update.Email.ToString() + "', " + 
                "NamSinh = '" + _info_update.NamSinh.ToShortDateString() +"', " +
                "GioiTinh = '" + _info_update.GioiTinh.ToString() + "'" +
                "WHERE MaKH = '" + _info_update.MaKH.ToString() +"'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public KhachHang_Pub GetKHTuMaKH(string _MaKH)
        {
            KhachHang_Pub result = new KhachHang_Pub();

            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_MaKH", _MaKH));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetKHTuMaKH", Lparameter);

            while (reader.Read())
            {

                result.MaKH = reader["MaKH"].ToString();
                result.MaLoaiKH = reader["MaLoaiKH"].ToString();
                result.HoTen = reader["HoTen"].ToString();
                result.NamSinh = DateTime.Parse(reader["NamSinh"].ToString());
                result.GioiTinh = bool.Parse(reader["GioiTinh"].ToString());
                result.DiaChi = reader["DiaChi"].ToString();
                result.SoDT = reader["SoDT"].ToString();
                result.Email = reader["Email"].ToString();
                result.CMND = reader["CMND"].ToString();
                result.NgayDangKy = DateTime.Parse(reader["NgayDangKy"].ToString());
                result.MatKhau = reader["MatKhau"].ToString();
                result.Diem = int.Parse(reader["Diem"].ToString());
                result.HinhAnh = reader["HinhAnh"].ToString();
  
            }
            reader.Close();
            return result;
        }

        public float GetHeSoUuDaiTuTenLoaiKH(string _TenLoaiKH)
        {
            float m_HeSo = 0;
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_TenLoaiKH", _TenLoaiKH));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetHeSoUuDaiTuTenLoaiKH", Lparameter);

            while (reader.Read())
            {
                m_HeSo = float.Parse(reader["HeSoUuDai"].ToString());
            }
            reader.Close();
            return m_HeSo;
        }

        public float GetHeSoKMTuMaKMVaLoaiKH(string _MaKM,string _TenLoaiKH)
        {
            float m_HeSo = 0;
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_TenLoaiKH", _TenLoaiKH));
            Lparameter.Add(new SqlParameter("@_MaKM", _MaKM));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetHeSoKMTuMaKMVaLoaiKH", Lparameter);

            while (reader.Read())
            {
                m_HeSo = float.Parse(reader["HeSoKM"].ToString());
            }
            reader.Close();
            return m_HeSo;
        }

        public string GetMa(string _startString, int m_Index)
        {
            if (m_Index < 10)
            {
                return _startString + "000" + m_Index;
            }
            else
            {
                if (m_Index < 100)
                {
                    return _startString + "00" + m_Index;
                }
                else
                {
                    if (m_Index < 1000)
                    {
                        return _startString + "0" + m_Index;
                    }
                    else
                    {
                        return _startString + m_Index;
                    }
                }
            }
        }


        public void UpdatePassword(string _password, string _MaKH)
        {
            string updateCommand = "UPDATE KHACHHANG " +
            "SET MatKhau = '" + _password.ToString() + "' " +
            "WHERE MaKH = '" + _MaKH.ToString() + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }
    }
}
