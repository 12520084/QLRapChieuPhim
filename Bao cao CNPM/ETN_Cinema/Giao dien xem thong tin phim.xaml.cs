using BUL;
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
    /// Interaction logic for Giao_dien_xem_thong_tin_phim.xaml
    /// </summary>
    public partial class Giao_dien_xem_thong_tin_phim : Window
    {
        List<Phim_Pub> LphimPUB;
        List<TheLoaiPhim_Pub> LtlPUB;
        public Giao_dien_xem_thong_tin_phim()
        {
            InitializeComponent();
            Phim_BUL phim_bul = new Phim_BUL();
            LphimPUB = phim_bul.GetMaPhim();
            cb_MaPhim.ItemsSource = LphimPUB;
            cb_MaPhim.DisplayMemberPath = "MaPhim";
            cb_MaPhim.SelectedValuePath = "MaPhim";
            TheLoaiPhim_BUL tl_bul = new TheLoaiPhim_BUL();
            LtlPUB = tl_bul.GetTheLoai();
            TheLoaiPhim_Pub phim_Tatca = new TheLoaiPhim_Pub();
            phim_Tatca.TenLP = "Tất cả";
            phim_Tatca.MaLP = "";
            LtlPUB.Add(phim_Tatca);
            cb_TheLoai.ItemsSource = LtlPUB;
            cb_TheLoai.DisplayMemberPath = "TenLP";
            cb_TheLoai.SelectedValuePath = "TenLP";
        }

        private void cb_MaPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _MaPhim = "";
            if (cb_MaPhim.SelectedValue != null)
            {
                _MaPhim = cb_MaPhim.SelectedValue.ToString(); 
            }
            Phim_BUL phim_bul = new Phim_BUL();

            if (_MaPhim != "")
            {
                Phim_Pub _tempPhim = phim_bul.GetPhimTheoMaPhim(_MaPhim);
                lb_XuatTenPhim.Content = _tempPhim.TenPhim;
                lb_XuatTheLoai.Content = _tempPhim.TheLoai;
                lb_XuatNoiDung.Content = _tempPhim.NoiDung;
                lb_XuatNuocSanXuat.Content = _tempPhim.NuocSanXuat;
                lb_XuatThoiLuong.Content = _tempPhim.ThoiLuong;
                lb_XuatDoTuoiQuyDinh.Content = _tempPhim.TuoiQuyDinh;
                lb_XuatDaoDien.Content = _tempPhim.DaoDien;
                lb_XuatDienVien.Content = _tempPhim.DienVien;
                lb_XuatNamPhatHanh.Content = _tempPhim.NamPhatHanh.Year;
                lb_XuatNgayKhoiChieu.Content = _tempPhim.NgayChieu.ToShortDateString();
                img_Poster.Source = GetHinhAnhTuPoster(_tempPhim.Poster);
            }
        }

        private BitmapImage GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();
            Stream bm_Stream = new FileStream("../Debug/Image/Film Poster/" + _Poster, FileMode.Open);
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

        private void cb_TheLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Phim_Pub> m_ListFilm;
            string TheLoai = cb_TheLoai.SelectedValue.ToString();
            cb_MaPhim.ItemsSource = null;
            ManageLabelXuat(false);
            if (TheLoai != "Tất cả")
            {
                Phim_BUL phim_bul = new Phim_BUL();
                m_ListFilm = phim_bul.GetMaPhimTheoTheLoai(TheLoai);
                cb_MaPhim.ItemsSource = m_ListFilm;
                cb_MaPhim.DisplayMemberPath = "MaPhim";
                cb_MaPhim.SelectedValuePath = "MaPhim"; 
            }
            else
            {
                Phim_BUL phim_bul = new Phim_BUL();
                LphimPUB = phim_bul.GetMaPhim();
                cb_MaPhim.ItemsSource = LphimPUB;
                cb_MaPhim.DisplayMemberPath = "MaPhim";
                cb_MaPhim.SelectedValuePath = "MaPhim";
            }
        }

        private void ManageLabelXuat(bool _Input)
        {
            if (!_Input)
            {
                lb_XuatDaoDien.Content = "";
                lb_XuatDienVien.Content = "";
                lb_XuatDoTuoiQuyDinh.Content = "";
                lb_XuatNamPhatHanh.Content = "";
                lb_XuatNgayKhoiChieu.Content = "";
                lb_XuatNoiDung.Content = "";
                lb_XuatNuocSanXuat.Content = "";
                lb_XuatTenPhim.Content = "";
                lb_XuatThoiLuong.Content = "";
                lb_XuatTheLoai.Content = "";
            }
        }
    }
}
