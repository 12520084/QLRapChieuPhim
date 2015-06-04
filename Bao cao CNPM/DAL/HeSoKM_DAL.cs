using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using System.Data.SqlClient;

namespace DAL
{
    public class HeSoKM_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public HeSoKM_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(HeSoKM_Pub _info)
        {
            _info.MaHSMK = GetTopIndexOfFilm("HSKM", GetIndex_DAL.GetIndexHSKhuyenMai());

            string insertCommand = @"INSERT INTO HESOKM(MaHeSoKM, MaKM, TenLoaiKH, HeSoKM) VALUES('" +
                _info.MaHSMK + "', '" +
                _info.MaKM + "', N'" +
                _info.TenLoaiKH +"'," +
                _info.HeSoKM + ")";
            m_sqlConnect.executeNonQuery(insertCommand);

            GetIndex_DAL.SetIndexHSKhuyenMai(GetIndex_DAL.GetIndexHSKhuyenMai() + 1);
        }

        public HeSoKM_Pub GetHSKMTheoMaKMvaLoaiKM(string _MaKM, string _TenLoaiKH)
        {
            HeSoKM_Pub result = new HeSoKM_Pub();
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_MaKM", _MaKM));
            Lparameter.Add(new SqlParameter("@_TenLoaiKH", _TenLoaiKH));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("[GetHSKMTheoMaKMvaLoaiKM]", Lparameter);

            while (reader.Read())
            {
                result.MaKM = reader["MaKM"].ToString();
                result.MaHSMK = reader["MaHeSoKM"].ToString();
                result.TenLoaiKH = reader["TenLoaiKH"].ToString();
                result.HeSoKM = float.Parse(reader["HeSoKM"].ToString());
            }

            reader.Close();
            return result;
        }

        public void UpdateHSKM(HeSoKM_Pub _info_Update)
        {
            string updateCommand = @"UPDATE HESOKM SET " +
            "HeSoKM = '" + _info_Update.HeSoKM + "'" +
            " WHERE MaKM = '" + _info_Update.MaKM.ToString() + "' " +
            "AND TenLoaiKH = N'" + _info_Update.TenLoaiKH + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public string GetTopIndexOfFilm(string _startString, int m_Index)
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
