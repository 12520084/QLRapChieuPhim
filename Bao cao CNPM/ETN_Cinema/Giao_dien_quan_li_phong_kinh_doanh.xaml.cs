using PUBLIC;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Giao_dien_quan_li_phong_kinh_doanh.xaml
    /// </summary>
    public partial class Giao_dien_quan_li_phong_kinh_doanh : Window
    {
        public Giao_dien_quan_li_phong_kinh_doanh()
        {
            InitializeComponent();
            lb_LoiChao.Content = "Xin Chào " + VarGlobal.g_NhanVienPub.HoTen + " đến với Phòng Kinh Doanh";
            avatar.Source = GetHinhAnhTuPoster(VarGlobal.g_NhanVienPub.HinhAnh);
            name.Content = VarGlobal.g_NhanVienPub.HoTen;
            birthday.Content = VarGlobal.g_NhanVienPub.NamSinh.ToShortDateString();
            province.Content = VarGlobal.g_NhanVienPub.QueQuan;
            company.Content = "ETN Cinema";
        }

        private BitmapImage GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();
            Stream bm_Stream = new FileStream("../Debug/Image/" + _Poster, FileMode.Open);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(bm_Stream));
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Save(memoryStream);
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
            bImg.EndInit();
            memoryStream.Close();
            bm_Stream.Close();
            return bImg;
        }

        private void mn_HoSo_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_xem_ho_so _gdxhs = new Giao_dien_xem_ho_so();
            _gdxhs.ShowDialog();
        }

        private void mn_DoiMK_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thay_doi_mat_khau _gdtdmk = new Giao_dien_thay_doi_mat_khau();
            _gdtdmk.ShowDialog();
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

        private void mn_QuanLy_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_quan_ly_phim _gdqlp = new Giao_dien_quan_ly_phim();
            _gdqlp.ShowDialog();
        }

        private void mn_Marketing_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_marketing _gdmkt = new Giao_dien_marketing();
            _gdmkt.ShowDialog();
        }

        private void mn_ChamSocKhachHang_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_dang_ky_khach_hang _gddkkh = new Giao_dien_dang_ky_khach_hang();
            _gddkkh.ShowDialog();
        }

        private void mn_KhachHang_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_ban_ve _gdbv = new Giao_dien_ban_ve();
            _gdbv.ShowDialog();
        }

        private void mn_Report_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thong_ke_doanh_so_ve _gdtkdsv = new Giao_dien_thong_ke_doanh_so_ve();
            _gdtkdsv.ShowDialog();
        }
    }
}
