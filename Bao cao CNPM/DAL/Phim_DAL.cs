using PUBLIC;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAL
{
    public class Phim_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public Phim_DAL()
        {
            m_sqlConnect.connect();
        }

        public string GetTopIndexOfFilm(string _startString, int m_Index)
        {
            //SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetIndexPhim");
            
            if (m_Index < 10)
            {
                return _startString + "000" + m_Index;
            }
            else
            {
                if(m_Index < 100)
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
            //reader.Close();
        }

        public void Insert(Phim_Pub _info)
        {
            _info.MaPhim = GetTopIndexOfFilm("PH", GetIndex_DAL.GetIndexPhim());
            
            string insertCommand = @"INSERT INTO PHIM(MaPhim, TenPhim, Poster, ThoiLuong, DaoDien, DienVien, NamPhatHanh, NuocSanXuat, TheLoai, NoiDung, TuoiQuyDinh, NgayChieu) VALUES('" +
                _info.MaPhim + "', N'" +
                _info.TenPhim + "', N'" +
                _info.Poster + "', '" +
                _info.ThoiLuong + "', N'" +
                _info.DaoDien + "', N'" +
                _info.DienVien + "', '" +
                _info.NamPhatHanh.ToShortDateString() + "', N'" +
                _info.NuocSanXuat + "', N'" +
                _info.TheLoai + "', N'" +
                _info.NoiDung + "', '" +
                _info.TuoiQuyDinh + "', '" +
                _info.NgayChieu.ToShortDateString() + "')";
                m_sqlConnect.executeNonQuery(insertCommand);

                GetIndex_DAL.SetIndexPhim(GetIndex_DAL.GetIndexPhim() + 1);
        }

        public void Update(Phim_Pub _info_update)
        {
            string updateCommand = "UPDATE PHIM " +
                        "SET MaPhim = N'" + _info_update.MaPhim.ToString() + "', " +
                        " TenPhim = N'" + _info_update.TenPhim.ToString() + "', " +
                        //" Poster = '" + _info_update.Poster.ToString() + "', " +
                        " ThoiLuong = '" + _info_update.ThoiLuong.ToString() + "', " +
                        " DaoDien = '" + _info_update.DaoDien.ToString() + "', " +
                        " DienVien = N'" + _info_update.DienVien.ToString() + "', " +
                        " NamPhatHanh = N'" + _info_update.NamPhatHanh.ToShortDateString() + "', " +
                        " NgayChieu = '" + _info_update.NgayChieu.ToShortDateString() +"', " +
                        " NuocSanXuat = '" + _info_update.NuocSanXuat.ToString() + "', " +
                        " TheLoai = N'" + _info_update.TheLoai.ToString() + "', " +
                        " NoiDung = '" + _info_update.NoiDung.ToString() + "', " +
                        " TuoiQuyDinh = '" + _info_update.TuoiQuyDinh.ToString() + "' " +
                        " WHERE MaPhim = '" + _info_update.MaPhim.ToString() + "'";

            m_sqlConnect.executeNonQuery(updateCommand);
        }

        public List<Phim_Pub> GetMaPhim()
        {
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQuery("GetMaPhim");
            List<Phim_Pub> _LPhim = new List<Phim_Pub>();

            while (reader.Read())
            {
                Phim_Pub _Phim = new Phim_Pub();
                _Phim.MaPhim = reader["MaPhim"].ToString();
                _Phim.TenPhim = reader["TenPhim"].ToString();
                _LPhim.Add(_Phim);
            }
            reader.Close();
            return _LPhim;
        }

        public List<Phim_Pub> GetPhimTheoTheLoai(string _TheLoai)
        {
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@TheLoai", _TheLoai));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetMaPhimTheoTheLoai", Lparameter);
            List<Phim_Pub> _LPhim = new List<Phim_Pub>();

            while (reader.Read())
            {
                Phim_Pub _Phim = new Phim_Pub();
                _Phim.MaPhim = reader["MaPhim"].ToString();
                _LPhim.Add(_Phim);
            }
            reader.Close();
            return _LPhim;
        }

        public Phim_Pub GetPhimTheoMaPhim(string _MaPhim)
        {
            List<SqlParameter> Lparameter = new List<SqlParameter>();
            Lparameter.Add(new SqlParameter("@_MaPhim", _MaPhim));
            SqlDataReader reader = (SqlDataReader)m_sqlConnect.executeQueryParameter("GetPhimTheoMaPhim", Lparameter);
            Phim_Pub result = new Phim_Pub();

            while (reader.Read())
            {
                result.TenPhim = reader["TenPhim"].ToString();
                result.Poster = reader["Poster"].ToString();
                result.TheLoai = reader["TheLoai"].ToString();
                result.NoiDung = reader["NoiDung"].ToString();
                result.NuocSanXuat = reader["NuocSanXuat"].ToString();
                result.ThoiLuong = int.Parse(reader["ThoiLuong"].ToString());
                result.TuoiQuyDinh = int.Parse(reader["TuoiQuyDinh"].ToString());
                result.DienVien = reader["DienVien"].ToString();
                result.DaoDien = reader["DaoDien"].ToString();
                result.NamPhatHanh = DateTime.Parse(reader["NamPhatHanh"].ToString());
                result.NgayChieu = DateTime.Parse(reader["NgayChieu"].ToString());
            }
            reader.Close();
            return result;
        }
    }
}
