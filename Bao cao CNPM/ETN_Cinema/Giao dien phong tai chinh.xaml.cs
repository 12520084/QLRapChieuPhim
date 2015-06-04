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
    /// Interaction logic for Giao_dien_phong_tai_chinh.xaml
    /// </summary>
    public partial class Giao_dien_phong_tai_chinh : Window
    {
        public Giao_dien_phong_tai_chinh()
        {
            InitializeComponent();
            lb_LoiChao.Content = "Xin Chào " + VarGlobal.g_NhanVienPub.HoTen + " đến với Phòng Tài Chính";
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

        private void mn_SuaKhuyenMai_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mn_NhapKhuyenMai_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mn_HoSo_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_xem_ho_so _gdxhs = new Giao_dien_xem_ho_so();
            _gdxhs.ShowDialog();
        }

        private void mn_SuaNV_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_tinh_luong_nhan_vien _gdtlnv = new Giao_dien_tinh_luong_nhan_vien();
            _gdtlnv.ShowDialog();
        }

        private void mn_DoiMK_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thay_doi_mat_khau _gddmk = new Giao_dien_thay_doi_mat_khau();
            _gddmk.ShowDialog();
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
    }
}
