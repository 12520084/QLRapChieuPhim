using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonTD_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public HoaDonTD_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(HoaDonTD_Pub _info)
        {
            string insertCommand = @"INSERT INTO HOADONTD(MaHDTD, NgayLap, TenTD, SoLuong, DonGia, TongTriGia, MaKH, MaNV) VALUES('" +
                _info.MaHDTD + "', '" +
                _info.NgayLap.ToShortDateString() + "', '" +
                _info.TenTD + "', " +
                _info.SoLuong + ", '" +
                _info.SoLuong + "', " +
                _info.DonGia + ", " +
                _info.TongTriGia + ", " +
                _info.MaKH + ", " +
                _info.TongTriGia + ", " +
                _info.MaKH + ", " +
                _info.MaNV + ")";

            m_sqlConnect.executeNonQuery(insertCommand);
        }
    }
}
