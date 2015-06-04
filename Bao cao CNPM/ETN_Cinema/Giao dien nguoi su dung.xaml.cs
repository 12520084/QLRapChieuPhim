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
    /// Interaction logic for Giao_dien_nguoi_su_dung.xaml
    /// </summary>
    public partial class Giao_dien_nguoi_su_dung : Window
    {
        KhachHang_BUL _khachhangBUL = new KhachHang_BUL();

        public Giao_dien_nguoi_su_dung()
        {
            InitializeComponent();
            mn_SuaThongTinDatVe.IsEnabled = false;
            //mn_SuaThongTinDatVe.Background = Brushes.Gray;
        }

        private void mn_XemThongTin_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thong_tin_khach_hang _gdtt = new Giao_dien_thong_tin_khach_hang();
            _gdtt.ShowDialog();
        }

        private void mn_SuaThongTin_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_sua_thong_tin_khach_hang _gdstt = new Giao_dien_sua_thong_tin_khach_hang();
            _gdstt.ShowDialog();
        }

        private void mn_DatVe_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_phieu_dat_ve _gdpdv = new Giao_dien_phieu_dat_ve();
            _gdpdv.ShowDialog();
        }

        private void mn_XemThongTinDatVe_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_xem_phieu_dat_ve _gdxpdv = new Giao_dien_xem_phieu_dat_ve();
            _gdxpdv.ShowDialog();
        }

        private void mn_SuaThongTinDatVe_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void mn_DangXuat_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Bạn Có Muốn Đăng Xuất", "Đăng Xuất", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                Giao_dien_dang_nhap _gddn = new Giao_dien_dang_nhap();
                this.IsEnabled = false;
                this.Close();
                _gddn.ShowDialog();
            }
        }

        private void mn_DoiMK_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thay_doi_mat_khau_khach_hang _gddmkkh = new Giao_dien_thay_doi_mat_khau_khach_hang();
            _gddmkkh.ShowDialog();
        }
    }
}
