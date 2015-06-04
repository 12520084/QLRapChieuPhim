using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhongChieu_DAL
    {
         private sqlConnect m_sqlConnect = new sqlConnect();

        public PhongChieu_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(PhongChieu_Pub _info)
        {
            string insertCommand = @"INSERT INTO  PHONGCHIEU(MaPC, TenPC, SoDo) VALUES('" +
                _info.MaPC + "', '" +
                _info.TenPC + "', '" + 
                _info.SoDo+ ")";

            m_sqlConnect.executeNonQuery(insertCommand);
        }

        public List<PhongChieu_Pub> GetPhongChieu()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetPhongChieu");
            List<PhongChieu_Pub> _LPhongChieu = new List<PhongChieu_Pub>();

            while (reader.Read())
            {
                PhongChieu_Pub _PC = new PhongChieu_Pub();
                _PC.TenPC = reader["TenPC"].ToString();
                _LPhongChieu.Add(_PC);
            }
            reader.Close();
            return _LPhongChieu;
        }
    }
}
