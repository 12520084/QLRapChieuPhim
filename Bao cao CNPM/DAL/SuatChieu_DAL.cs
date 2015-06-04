using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SuatChieu_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public SuatChieu_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(SuatChieu_Pub _info)
        {
            _info.MaSC = GetMa("SC", GetIndex_DAL.GetIndexSuatChieu());
            string insertCommand = @"INSERT INTO SUATCHIEU(MaSC, GioChieu, NgayChieu, PhongChieu, LoaiSuatChieu, TenPhim, Gia) VALUES('" +
                _info.MaSC + "', '" +
                _info.GioChieu.ToShortTimeString() + "', '" + 
                _info.NgayChieu.ToShortDateString() + "', '" +
                _info.PhongChieu + "', '" +
                _info.LoaiSuatChieu + "', N'" +
                _info.TenPhim + "', " +
                _info.Gia + ")";

            m_sqlConnect.executeNonQuery(insertCommand);

            GetIndex_DAL.SetIndexSuatChieu(GetIndex_DAL.GetIndexSuatChieu() + 1);
            for (int i = 65; i < 75; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string insertChairCommand = @"INSERT INTO GHE(Id, MaGhe, MaSC, Trong) VALUES(" +
                        GetIndex_DAL.GetIndexGhe() + ",'" + (char)i + j.ToString() + "','" + _info.MaSC + "','" + 1 + "')";
                    m_sqlConnect.executeNonQuery(insertChairCommand);
                    GetIndex_DAL.SetIndexGhe(GetIndex_DAL.GetIndexGhe() + 1);
                }
            }
        }

        public List<SuatChieu_Pub> GetSuatChieuTheoTenPhim(string _TenPhim)
        {
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_TenPhim", _TenPhim));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetSuatChieuTheoTenPhim", Lparameter);
            List<SuatChieu_Pub> _LSuatChieu = new List<SuatChieu_Pub>();

            while (reader.Read())
            {
                SuatChieu_Pub _SC = new SuatChieu_Pub();
                _SC.Gia = float.Parse(reader["Gia"].ToString());
                _SC.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                _SC.MaSC = reader["MaSC"].ToString();
                _SC.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                _SC.PhongChieu = reader["PhongChieu"].ToString();
                _SC.TenPhim = reader["TenPhim"].ToString();
                _SC.LoaiSuatChieu = reader["LoaiSuatChieu"].ToString();
                _LSuatChieu.Add(_SC);
            }
            reader.Close();
            return _LSuatChieu;
        }

        public List<SuatChieu_Pub> GetSuatChieu()
        {
            List<SuatChieu_Pub> _LSuatChieu = new List<SuatChieu_Pub>();
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetSuatChieu");

            while (reader.Read())
            {
                SuatChieu_Pub _SC = new SuatChieu_Pub();
                _SC.Gia = float.Parse(reader["Gia"].ToString());
                _SC.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                _SC.MaSC = reader["MaSC"].ToString();
                _SC.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                _SC.PhongChieu = reader["PhongChieu"].ToString();
                _SC.TenPhim = reader["TenPhim"].ToString();
                _SC.LoaiSuatChieu = reader["LoaiSuatChieu"].ToString();
                _LSuatChieu.Add(_SC);
            }
            return _LSuatChieu;
        }

        public List<string> GetLoaiSC()
        {
            List<string> _LLoaiSC = new List<string>();
            _LLoaiSC.Add("3D");
            _LLoaiSC.Add("2D");
            return _LLoaiSC;
        }

        public void Update(SuatChieu_Pub _info_update)
        {
            string updateCommand = @"UPDATE SUATCHIEU SET " + 
                "GioChieu = '" + _info_update.GioChieu.ToShortTimeString() + "', " + 
                "NgayChieu = '" + _info_update.NgayChieu.ToShortDateString() + "', " +
                "Phongchieu = '" + _info_update.PhongChieu.ToString() + "', " + 
                "LoaisuatChieu = '" + _info_update.LoaiSuatChieu.ToString()  + "', " + 
                "TenPhim = N'" + _info_update.TenPhim.ToString() + "', " + 
                "Gia = '" + _info_update.Gia.ToString() + "' WHERE MaSC = '" + _info_update.MaSC.ToString() + "'";
            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public SuatChieu_Pub GetSuatChieuTheoMaSC(string _MaSC)
        {
            SuatChieu_Pub result = new SuatChieu_Pub();
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_MaSC", _MaSC));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetSuatChieuTheoMaSC", Lparameter);

            while (reader.Read())
            {
                result.Gia = float.Parse(reader["Gia"].ToString());
                result.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                result.MaSC = reader["MaSC"].ToString();
                result.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                result.PhongChieu = reader["PhongChieu"].ToString();
                result.TenPhim = reader["TenPhim"].ToString();
                result.LoaiSuatChieu = reader["LoaiSuatChieu"].ToString();
            }

            return result;
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
    }
}
