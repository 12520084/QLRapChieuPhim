using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSuatChieu_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public LoaiSuatChieu_DAL()
        {
            m_sqlConnect.connect();
        }

        public List<LoaiSuatChieu_Pub> GetLoaiSuatChieu()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetLoaiSuatChieu");
            List<LoaiSuatChieu_Pub> _LloaiSuaChieuPub = new List<LoaiSuatChieu_Pub>();



            while (reader.Read())
            {
                LoaiSuatChieu_Pub _loaiSuatChieuPub = new LoaiSuatChieu_Pub();
                _loaiSuatChieuPub.ID = reader["ID"].ToString();


                _LloaiSuaChieuPub.Add(_loaiSuatChieuPub);
            }

            return _LloaiSuaChieuPub;
        }
    }
}
