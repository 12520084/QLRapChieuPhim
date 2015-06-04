using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using System.Data.SqlClient;

namespace DAL
{
    public class Ghe_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public Ghe_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Update(Ghe_Pub _info)
        {
            string updateCommand = "UPDATE GHE " +
                        "SET Trong = '" + _info.Trong + "'"+
                        " WHERE MaGhe = '" + _info.MaGhe.ToString() + "' AND MaSC = '" + _info.MaSC.ToString() + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public List<Ghe_Pub> GetGheTheoSuatChieu(string _SC)
        {
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_SC", _SC));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetGheTheoSuatChieu", Lparameter);
            List<Ghe_Pub> result = new List<Ghe_Pub>();

            while (reader.Read())
            {
                Ghe_Pub ghe_pub = new Ghe_Pub();
                ghe_pub.Id = int.Parse(reader["Id"].ToString());
                ghe_pub.Trong = bool.Parse(reader["Trong"].ToString());
                ghe_pub.MaGhe = reader["MaGhe"].ToString();
                ghe_pub.MaSC = reader["MaSC"].ToString();
                result.Add(ghe_pub);
            }
            reader.Close();
            return result;
        }
    }
}
