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
using PUBLIC;
using BUL;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_thong_tin_khach_hang.xaml
    /// </summary>
    public partial class Giao_dien_thong_tin_khach_hang : Window
    {
        public Giao_dien_thong_tin_khach_hang()
        {
            InitializeComponent();

            LoaiKhachHang_BUL _ploaiKHBUL = new LoaiKhachHang_BUL();
            LoaiKhachHang_Pub _loaiKHPub = new LoaiKhachHang_Pub();

            lb_XuatCMND.Content = VarGlobal.g_KhachHangPub.CMND;
            lb_XuatDiaChi.Content = VarGlobal.g_KhachHangPub.DiaChi;
            lb_XuatDTL.Content = VarGlobal.g_KhachHangPub.Diem;
            lb_XuatEmail.Content = VarGlobal.g_KhachHangPub.Email;
            lb_XuatHoTen.Content = VarGlobal.g_KhachHangPub.HoTen;
            lb_XuatMaKH.Content = VarGlobal.g_KhachHangPub.MaKH;
            lb_XuatNgayDK.Content = VarGlobal.g_KhachHangPub.NgayDangKy.ToShortDateString();
            lb_XuatSDT.Content = VarGlobal.g_KhachHangPub.SoDT;
            lb_XuatGioiTinh.Content = StaticMethod.SetGender(VarGlobal.g_KhachHangPub.GioiTinh);
            lb_XuatNgaySinh.Content = VarGlobal.g_KhachHangPub.NamSinh.ToShortDateString();

            _loaiKHPub = _ploaiKHBUL.GetLoaiKHTheoMaLoaiKH(VarGlobal.g_KhachHangPub.MaLoaiKH.ToString());
            lb_XuatLoaiKH.Content = _loaiKHPub.TenLoaiKH;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
