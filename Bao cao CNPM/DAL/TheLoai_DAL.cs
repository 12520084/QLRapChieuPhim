using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TheLoaiPhim_DAL
    {
         private sqlConnect m_sqlConnect = new sqlConnect();

        public TheLoaiPhim_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(TheLoaiPhim_Pub _info)
        {
            string insertCommand = @"INSERT INTO  THELOAIPHIM(MaLP, TenLP) VALUES('" +
                _info.MaLP + "', '" +
                _info.TenLP + ")";

            m_sqlConnect.executeNonQuery(insertCommand);
        }

        public List<TheLoaiPhim_Pub> GetTheLoai()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetTheLoai");
            List<TheLoaiPhim_Pub> _LTheLoai = new List<TheLoaiPhim_Pub>();

            while (reader.Read())
            {
                TheLoaiPhim_Pub _TheLoai = new TheLoaiPhim_Pub();
                _TheLoai.TenLP = reader["TenLP"].ToString();
                _LTheLoai.Add(_TheLoai);
            }

            return _LTheLoai;

        }
    }
}
