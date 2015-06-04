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
    /// Interaction logic for Giao_dien_quan_li.xaml
    /// </summary>
    public partial class Giao_dien_quan_li_nhan_su : Window
    {
        public Giao_dien_quan_li_nhan_su()
        {
            InitializeComponent();
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

        private void mn_NhapNV_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_nhap_nhan_vien _gdnnv = new Giao_dien_nhap_nhan_vien();
            _gdnnv.ShowDialog();
        }

        private void mn_SuaNV_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_chinh_sua_nhan_vien _gdcsnv = new Giao_dien_chinh_sua_nhan_vien();
            _gdcsnv.ShowDialog();
        }

        private void mn_DoiMK_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thay_doi_mat_khau _gdtdmk = new Giao_dien_thay_doi_mat_khau();
            _gdtdmk.ShowDialog();
        }

        private void mn_DangXuat_Click(object sender, RoutedEventArgs e)
        {

            if( MessageBox.Show("Bạn Có Muốn Đăng Xuất", "Đăng Xuất", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                
                Giao_dien_dang_nhap _gddn = new Giao_dien_dang_nhap();
                this.IsEnabled = false;
                this.Close();
                _gddn.ShowDialog();
            }
            

        }

    }
}
