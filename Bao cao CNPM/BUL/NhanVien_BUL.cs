using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PUBLIC;
using DAL;
namespace BUL
{
    public class NhanVien_BUL
    {
        private NhanVien_DAL cls;

        public NhanVien_DAL Cls
        {
            get { return cls; }
            set { cls = value; }
        }
        public NhanVien_BUL()
        { cls = new NhanVien_DAL(); }

        public void Insert(NhanVien_Pub _info)
        {
             cls.Insert(_info);
        }
        
        public NhanVien_Pub GetNV(string _MaNV)
        {
            return cls.GetNV(_MaNV);
        }

        public List<NhanVien_Pub> GetNVTheoPB(string _MaPB)
        {
            return cls.GetNVTheoPB(_MaPB);
        }

        public List<NhanVien_Pub> GetQuanLy(string _MaPB)
        {
            return cls.GetQuanLy(_MaPB);
        }

        public void Update(NhanVien_Pub _nhanvienPub)
        {
            cls.Update(_nhanvienPub);
        }


        public void ResetChucVu(string _MaPB)
        {
            cls.ResetChucVu(_MaPB);
        }

        public void UpdatePassword(string _password, string _MaNV)
        {
            cls.UpdatePassword(_password, _MaNV);
        }

        public void Delete(string _MaNV)
        {
            cls.Delete(_MaNV);
        }
    }
}
