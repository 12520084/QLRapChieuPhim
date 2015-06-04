using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChucVu_DAL
    {
        
        private sqlConnect m_sqlConnect = new sqlConnect();

        public ChucVu_DAL()
        {
            m_sqlConnect.connect();
        }

        public List<ChucVu_Pub> GetCV()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetCV");
            List<ChucVu_Pub> _LchucvuPub = new List<ChucVu_Pub>();



            while (reader.Read())
            {
               ChucVu_Pub _chucvuPub = new ChucVu_Pub();
                _chucvuPub.MaCV = reader["MaCV"].ToString();
                _chucvuPub.TenCV = reader["TenCV"].ToString();

                _LchucvuPub.Add(_chucvuPub);
            }

            return _LchucvuPub;
        }

        public ChucVu_Pub GetCVTheoMaCV(string _MaCV)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaCV", _MaCV));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetCVTheoMaCV", paramters);
            ChucVu_Pub _chucvuPub = new ChucVu_Pub();

            while (reader.Read())
            {
                _chucvuPub.MaCV = reader["MaCV"].ToString();
                _chucvuPub.TenCV = reader["TenCV"].ToString();
            }

            return _chucvuPub;
        }
    }
}
