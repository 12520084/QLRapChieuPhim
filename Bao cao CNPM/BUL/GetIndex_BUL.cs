using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public static class GetIndex_BUL
    {
        public static int GetIndex()
        {
            return GetIndex_DAL.GetIndexNV();
        }

        public static void SetIndex(int _index)
        {
            GetIndex_DAL.SetIndexNV(_index);
        }

        public static int GetIndexPhim()
        {
            return GetIndex_DAL.GetIndexPhim();
        }

        public static void SetIndexPhim(int _index)
        {
            GetIndex_DAL.SetIndexPhim(_index);
        }

        public static int GetIndexKhuyenMai()
        {
            return GetIndex_DAL.GetIndexKhuyenMai();
        }

        public static void SetIndexKhuyenMai(int _index)
        {
            GetIndex_DAL.SetIndexKhuyenMai(_index);
        }

        public static int GetIndexHSKhuyenMai()
        {
            return GetIndex_DAL.GetIndexHSKhuyenMai();
        }

        public static void SetIndexHSKhuyenMai(int _index)
        {
            GetIndex_DAL.SetIndexHSKhuyenMai(_index);
        }

        public static int GetIndexGiaVe()
        {
            return GetIndex_DAL.GetIndexGiaVe();
        }

        public static void SetIndexGiaVe(int _index)
        {
            GetIndex_DAL.SetIndexGiaVe(_index);
        }

        public static int GetIndexSuatChieu()
        {
            return GetIndex_DAL.GetIndexSuatChieu();
        }

        public static void SetIndexSuatChieu(int _index)
        {
            GetIndex_DAL.SetIndexSuatChieu(_index);
        }

        public static int GetIndexKhachHang()
        {
            return GetIndex_DAL.GetIndexKhachHang();
        }

        public static void SetIndexKhachHang(int _index)
        {
            GetIndex_DAL.SetIndexKhachHang(_index);
        }

        public static int GetIndexVeBan()
        {
            return GetIndex_DAL.GetIndexVeBan();
        }

        public static void SetIndexVeBan(int _index)
        {
            GetIndex_DAL.SetIndexVeBan(_index);
        }
        public static int GetIndexPDV()
        {
            return GetIndex_DAL.GetIndexPDV();
        }
        public static void SetIndexPDV(int _index)
        {
            GetIndex_DAL.SetIndexPDV(_index);
        }
    }
}
