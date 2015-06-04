using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuDatVe_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public PhieuDatVe_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(PhieuDatVe_Pub _info)
        {
            _info.MaPDV = GetMa("PD", GetIndex_DAL.GetIndexPDV());
            string insertCommand = @"INSERT INTO  PHIEUDATVE(MaPDV, MaKH, GioChieu, PhongChieu, MaGhe, TenPhim, NgayChieu, TriGia, NgayDatVe, MaSC) VALUES('" +
                _info.MaPDV + "', '" +
                _info.MaKH + "', '" +
                _info.GioChieu.ToShortTimeString() + "', '" +
                _info.PhongChieu + "', '" +
                _info.MaGhe + "', N'" +
                _info.TenPhim + "', '" +
                _info.NgayChieu.ToShortDateString() + "', '" +
                _info.TriGia + "', '" +
                _info.NgayDatVe.ToShortDateString() + "', '" +
                _info.MaSC + "')";

            m_sqlConnect.executeNonQuery(insertCommand);
            GetIndex_DAL.SetIndexPDV(GetIndex_DAL.GetIndexPDV() + 1);
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

        public List<PhieuDatVe_Pub> GetPDVTuMaKH(string _MaKH)
        {
            PhieuDatVe_Pub result;
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@_MaKH", _MaKH));

            List<PhieuDatVe_Pub> _LpdvPub = new List<PhieuDatVe_Pub>();

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetPDVTuMaKH", paramters);
            while (reader.Read())
            {
                result = new PhieuDatVe_Pub();
                result.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                result.MaGhe = reader["MaGhe"].ToString();
                result.MaKH = reader["MaKH"].ToString();
                result.MaPDV = reader["MaPDV"].ToString();
                result.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                result.NgayDatVe = DateTime.Parse(reader["NgayDatVe"].ToString());
                result.PhongChieu = reader["PhongChieu"].ToString();
                result.TenPhim = reader["TenPhim"].ToString();
                result.TriGia = float.Parse(reader["TriGia"].ToString());
                result.MaSC = reader["MaSC"].ToString();
                _LpdvPub.Add(result);
            }
            reader.Close();
            return _LpdvPub;
        }

        public PhieuDatVe_Pub GetPDVTuMaPDV(string _MaPDV)
        {
            PhieuDatVe_Pub result = new PhieuDatVe_Pub();
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@_MaPDV", _MaPDV));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetPDVTuMaPDV", paramters);
            
            while (reader.Read())
            {
                result.GioChieu = DateTime.Parse(reader["GioChieu"].ToString());
                result.MaGhe = reader["MaGhe"].ToString();
                result.MaKH = reader["MaKH"].ToString();
                result.MaPDV = reader["MaPDV"].ToString();
                result.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
                result.NgayDatVe = DateTime.Parse(reader["NgayDatVe"].ToString());
                result.PhongChieu = reader["PhongChieu"].ToString();
                result.TenPhim = reader["TenPhim"].ToString();
                result.TriGia = float.Parse(reader["TriGia"].ToString());
                result.MaSC = reader["MaSC"].ToString();
            }
            reader.Close();
            return result;
        }

        public void XoaPDVTuMaPDV(PhieuDatVe_Pub _info)
        {
            string command = "DELETE FROM PHIEUDATVE WHERE MaPDV = '" + _info.MaPDV +"'";
            m_sqlConnect.executeNonQuery(command);
            string updateChair = "UPDATE GHE SET Trong = 1 WHERE MaGhe = '" + _info.MaGhe + "' AND MaSC ='" + _info.MaSC + "'";
            m_sqlConnect.executeNonQuery(updateChair);
        }

        public void Update(PhieuDatVe_Pub _info_update)
        {
            string command = "UPDATE PHIEUDATVE SET MaKH = '" + _info_update.MaKH.ToString() + "', " +
                "GioChieu = '" + _info_update.GioChieu.ToShortTimeString() +"', " +
                "PhongChieu = '" + _info_update.PhongChieu.ToString() + "', " +
                "MaGhe = '" + _info_update.MaGhe.ToString() + "', " +
                "TenPhim = N'" + _info_update.TenPhim.ToString() + "', " +
                "NgayChieu = '" + _info_update.NgayChieu.ToShortDateString() + "', " +
                "TriGia = '" + _info_update.TriGia.ToString() + "', " +
                "NgayDatVe = '" + _info_update.NgayDatVe.ToShortDateString() + "', " +
                "MaSC = '" + _info_update.MaSC.ToString() + "' WHERE MaPDV = '" + _info_update.MaPDV.ToString() + "'";
            m_sqlConnect.executeNonQuery(command);
        }
    }
}
