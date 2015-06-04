using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongBan_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public PhongBan_DAL()
        {
            m_sqlConnect.connect();
        }

        public List<PhongBan_Pub> GetPB()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetPB");
            List<PhongBan_Pub> _LphongbanPub = new List<PhongBan_Pub>();



            while (reader.Read())
            {
                PhongBan_Pub _phongbanPub = new PhongBan_Pub();
                _phongbanPub.MaPB = reader["MaPB"].ToString();
                _phongbanPub.TenPB = reader["TenPB"].ToString();

                _LphongbanPub.Add(_phongbanPub);
            }

            return _LphongbanPub;
        }

        public PhongBan_Pub GetPBTheoMaPB(string _MaPB)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaPB", _MaPB));

            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetPBTheoMaPB", paramters);

            PhongBan_Pub _phongbanPub = new PhongBan_Pub();

            while (reader.Read())
            {
                _phongbanPub.MaPB = reader["MaPB"].ToString();
                _phongbanPub.TenPB = reader["TenPB"].ToString();
                _phongbanPub.HeSL = int.Parse(reader["HeSL"].ToString());
            }

            return _phongbanPub;
        }
    }
}
