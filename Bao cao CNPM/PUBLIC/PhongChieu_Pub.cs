using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public class PhongChieu_Pub
    {
        private string m_MaPC;
        private string m_TenPC;
        private string m_SoDo;

        public string SoDo
        {
            get { return m_SoDo; }
            set { m_SoDo = value; }
        }

        public string TenPC
        {
            get { return m_TenPC; }
            set { m_TenPC = value; }
        }

        public string MaPC
        {
            get { return m_MaPC; }
            set { m_MaPC = value; }
        }
    }
}
