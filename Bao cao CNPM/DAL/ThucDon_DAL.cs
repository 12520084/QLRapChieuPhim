using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThucDon_DAL
    {
        private sqlConnect m_sqlConnect = new sqlConnect();

        public ThucDon_DAL()
        {
            m_sqlConnect.connect();
        }

        public void Insert(ThucDon_Pub _info)
        {
            string insertCommand = @"INSERT INTO  THUCDON(MaTD, TenTD, Gia, HinhAnh) VALUES('" +
                _info.MaTD + "', '" +
                _info.TenTD + "', '" +
                _info.Gia + "', '" +
                _info.HinhAnh + "')";

            m_sqlConnect.executeNonQuery(insertCommand);
        }
    }
}
