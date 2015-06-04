using BUL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_tinh_luong_nhan_vien.xaml
    /// </summary>
    public partial class Giao_dien_tinh_luong_nhan_vien : Window
    {

        private List<PhongBan_Pub> _LphongbanPub;

        public Giao_dien_tinh_luong_nhan_vien()
        {
            InitializeComponent();

            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();

            _LphongbanPub = _phongbanBUL.GetPB();
            cbb_MaPB.ItemsSource = _LphongbanPub;
            cbb_MaPB.DisplayMemberPath = "TenPB";
            cbb_MaPB.SelectedValuePath = "MaPB";

            cbb_MaPB.SelectedIndex = 0;

            List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

            _LnhanvienPub = _nhanvienBUL.GetNVTheoPB("TEST");
            cbb_MaNV.ItemsSource = _LnhanvienPub;
            cbb_MaNV.DisplayMemberPath = "HoTen";
            cbb_MaNV.SelectedValuePath = "MaNV";

            cbb_MaNV.SelectedIndex = 0;

            
            //img_HinhAnh.Source = new BitmapImage(new Uri(@"C:\Users\Tran Danh\Desktop\ETN_Cinema\ETN_Cinema\bin\Debug\image\" + "default.png"));
        }

        string Danhdaucham(string _Input)
        {
            string result1 = "";
            string result2 = "";
            int count = 0;
            for (int i = _Input.Length - 1; i >= 0; --i)
            {
                if ((count + 1) % 4 == 0)
                {
                    result1 += ".";
                    result1 += _Input[i];
                    count += 2;
                }
                else
                {
                    result1 += _Input[i];
                    ++count;
                }
            }
            for (int i = result1.Length - 1; i >= 0; --i)
            {
                result2 += result1[i];
            }
            return result2;
        }

        private void cbb_MaPB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _maPB = cbb_MaPB.SelectedValue.ToString();

            List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

            //_LnhanvienPub = _nhanvienBUL.GetNVTheoPB(_maPB);
            //cbb_MaNV.ItemsSource = _LnhanvienPub;

            if (cbb_MaPB.SelectedIndex != 0)
            {
                _LnhanvienPub = _nhanvienBUL.GetNVTheoPB(_maPB);
                cbb_MaNV.ItemsSource = _LnhanvienPub;
            }
            else
            {
                _LnhanvienPub = _nhanvienBUL.GetNVTheoPB("TEST");
                cbb_MaNV.ItemsSource = _LnhanvienPub;
                
            }

            cbb_MaNV.DisplayMemberPath = "HoTen";
            cbb_MaNV.SelectedValuePath = "MaNV";

            lbFullName.Content = "";
            lbBirthDay.Content = "";
            lbNgayVL.Content = "";
            lbNgayLuongGanNhat.Content = "";

            lbLuong.Content = "";
            //img_HinhAnh.Source = new BitmapImage(new Uri(@"C:\Users\Tran Danh\Desktop\ETN_Cinema\ETN_Cinema\bin\Debug\image\" + "default.png"));
            cbb_MaNV.SelectedIndex = 0;
        }

        private void cbb_MaNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

            PhongBan_Pub _phongbanPub = new PhongBan_Pub();
            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();

            if (cbb_MaNV.SelectedValue != null && cbb_MaNV.SelectedIndex != 0)
            { 
            _phongbanPub = _phongbanBUL.GetPBTheoMaPB(cbb_MaPB.SelectedValue.ToString());

            _nhanvienPub = _nhanvienBUL.GetNV(cbb_MaNV.SelectedValue.ToString());

            lbFullName.Content = _nhanvienPub.HoTen.ToString();
            lbBirthDay.Content = _nhanvienPub.NamSinh.ToShortDateString();
            lbNgayVL.Content = _nhanvienPub.NgayVaoLam.ToShortDateString();
            //lbNgayLuongGanNhat.Content = _nhanvienPub.MocLuong.ToShortDateString();

            //int mCoutDay = (DateTime.Parse(DateTime.Now.ToShortDateString()) -  DateTime.Parse(_nhanvienPub.MocLuong.ToShortDateString())).Days;
            //lbLuong.Content = Danhdaucham((mCoutDay * VarGlobal.mLCB * _phongbanPub.HeSL).ToString());

            //img_HinhAnh.Source = new BitmapImage(new Uri(@"C:\Users\Tran Danh\Desktop\ETN_Cinema\ETN_Cinema\bin\Debug\image\" + _nhanvienPub.HinhAnh));
            }
        }
        
    }
}
