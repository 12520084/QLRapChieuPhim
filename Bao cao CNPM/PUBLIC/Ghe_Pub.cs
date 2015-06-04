using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class Ghe_Pub
    {
        private string m_MaGhe;
        private int m_Id;
        private string m_MaSC;
        bool m_Trong;

        public bool Trong
        {
            get { return m_Trong; }
            set { m_Trong = value; }
        }

        public string MaSC
        {
            get { return m_MaSC; }
            set { m_MaSC = value; }
        }

        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public string MaGhe
        {
            get { return m_MaGhe; }
            set { m_MaGhe = value; }
        }
    }
}
