using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhuyenMai_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public KhuyenMai_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(KhuyenMai_Pub _info)
        {
            _info.MaKM = GetTopIndexOfFilm("KM", GetIndex_DAL.GetIndexKhuyenMai());

            string insertCommand = @"INSERT INTO KHUYENMAI(MaKM, TenKM, NgayBatDau, NgayKetThuc, NoiDung) VALUES('" +
                _info.MaKM + "', '" +
                _info.TenKM + "', '" +
                _info.NgayBatDau.ToShortDateString() + "', " +
                _info.NgayKetThuc.ToShortDateString() + ", '" +
                _info.NoiDung + "')";

            m_sqlConnect.executeNonQuery(insertCommand);

            GetIndex_DAL.SetIndexKhuyenMai(GetIndex_DAL.GetIndexKhuyenMai() + 1);
        }

        public void Update(KhuyenMai_Pub _info_update)
        {
            string updateCommand = @"UPDATE KHUYENMAI " +
                "SET TenKM = N'" + _info_update.TenKM + "', " +
                "NgayBatDau = '" + _info_update.NgayBatDau.ToShortDateString() + "', " +
                "NgayKetThuc = '" + _info_update.NgayKetThuc.ToShortDateString() + "', " +
                "NoiDung = N'" + _info_update.NoiDung.ToString() + "' WHERE MaKM = '" + _info_update.MaKM + "'";
            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public List<KhuyenMai_Pub> GetKM()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetKM");
            List<KhuyenMai_Pub> _LKM = new List<KhuyenMai_Pub>();

            while (reader.Read())
            {
                KhuyenMai_Pub _KM = new KhuyenMai_Pub();
                _KM.MaKM = reader["MaKM"].ToString();
                _KM.TenKM = reader["TenKM"].ToString();
                _KM.NoiDung = reader["NoiDung"].ToString();
                _KM.NgayBatDau = DateTime.Parse(reader["NgayBatDau"].ToString());
                _KM.NgayKetThuc = DateTime.Parse(reader["NgayKetThuc"].ToString());
                _LKM.Add(_KM);
            }
            reader.Close();
            return _LKM;
        }

        public KhuyenMai_Pub GetKMTheoMaKM(string _MaKM)
        {
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_MaKM", _MaKM));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("[GetKMTheoMaKM]", Lparameter);
            //SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetKM");
            KhuyenMai_Pub result = new KhuyenMai_Pub();

            while (reader.Read())
            {
                result.MaKM = reader["MaKM"].ToString();
                result.TenKM = reader["TenKM"].ToString();
                result.NoiDung = reader["NoiDung"].ToString();
                result.NgayBatDau = DateTime.Parse(reader["NgayBatDau"].ToString());
                result.NgayKetThuc = DateTime.Parse(reader["NgayKetThuc"].ToString());
            }

            reader.Close();
            return result;
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
