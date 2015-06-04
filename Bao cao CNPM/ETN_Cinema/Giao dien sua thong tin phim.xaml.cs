using BUL;
using Microsoft.Win32;
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
    public partial class Giao_dien_sua_thong_tin_phim : Window
    {
        List<Phim_Pub> LphimPUB;
        List<TheLoaiPhim_Pub> LtlPUB;
        Uri filmPosterURI;
        string m_Poster = "";
        public Giao_dien_sua_thong_tin_phim()
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
            cb_XuatTheLoai.ItemsSource = LtlPUB;
            cb_XuatTheLoai.DisplayMemberPath = "TenLP";
            cb_XuatTheLoai.SelectedValuePath = "TenLP";
            cb_TheLoai.SelectedItem = LtlPUB[LtlPUB.Count - 1];
            ManageInput(false);
            //btn_ChonAnh.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cb_MaPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _MaPhim = "";
            if (cb_MaPhim.SelectedValue != null)
            {
                _MaPhim = cb_MaPhim.SelectedValue.ToString();
            }
            Phim_BUL phim_bul = new Phim_BUL();
            ManageLabelXuat(true);
            ManageInput(true);
            if (_MaPhim != "")
            {
                
                Phim_Pub _tempPhim = phim_bul.GetPhimTheoMaPhim(_MaPhim);
                lb_XuatTenPhim.Text = _tempPhim.TenPhim;
                //lb_XuatTheLoai.Content = _tempPhim.TheLoai;
                lb_XuatNoiDung.Text = _tempPhim.NoiDung;
                lb_XuatNuocSanXuat.Text = _tempPhim.NuocSanXuat;
                lb_XuatThoiLuong.Text = _tempPhim.ThoiLuong.ToString();
                lb_XuatDoTuoiQuyDinh.Text = _tempPhim.TuoiQuyDinh.ToString();
                lb_XuatDaoDien.Text = _tempPhim.DaoDien;
                lb_XuatDienVien.Text = _tempPhim.DienVien;
                //lb_XuatNamPhatHanh.Content = _tempPhim.NamPhatHanh.Year;
                cb_XuatTheLoai.SelectedItem = XuatTheLoaiChoComboBox(_tempPhim.TheLoai);
                datepicker_NgayKhoiChieu.SelectedDate = _tempPhim.NgayChieu;
                datepicker_NamPhatHanh.SelectedDate = _tempPhim.NamPhatHanh;
                //lb_XuatNgayKhoiChieu.Content = _tempPhim.NgayChieu.ToShortDateString();
                img_Poster.Source = GetHinhAnhTuPoster(_tempPhim.Poster);
                m_Poster = _tempPhim.Poster;
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

        private TheLoaiPhim_Pub XuatTheLoaiChoComboBox(string _TheLoai)
        {
            for (int i = 0; i < LtlPUB.Count; i++)
            {
                if (LtlPUB[i].TenLP == _TheLoai)
                {
                    return LtlPUB[i];
                }
            }
            return null;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            Phim_Pub phim_pub = new Phim_Pub();
            Phim_BUL phim_bul = new Phim_BUL();

            phim_pub.MaPhim = cb_MaPhim.SelectedValue.ToString();
            phim_pub.TenPhim = lb_XuatTenPhim.Text;
            phim_pub.NgayChieu = datepicker_NgayKhoiChieu.SelectedDate.Value;
            phim_pub.NamPhatHanh = datepicker_NamPhatHanh.SelectedDate.Value;
            phim_pub.NoiDung = lb_XuatNoiDung.Text;
            phim_pub.NuocSanXuat = lb_XuatNuocSanXuat.Text;
            phim_pub.DaoDien = lb_XuatDaoDien.Text;
            phim_pub.DienVien = lb_XuatDienVien.Text;
            phim_pub.ThoiLuong = int.Parse(lb_XuatThoiLuong.Text);
            phim_pub.TuoiQuyDinh = int.Parse(lb_XuatDoTuoiQuyDinh.Text);
            phim_pub.TheLoai = cb_XuatTheLoai.SelectedValue.ToString();
            phim_pub.Poster = m_Poster;
            if (filmPosterURI != null)
            {
                UpdatePoster(filmPosterURI, m_Poster); 
            }
            phim_bul.Update(phim_pub);
            MessageBox.Show("Thay đổi thành công");
        }

        private void UpdatePoster(Uri _uri, string _Index)
        {
            FileStream stream = new FileStream("../Debug/Image/Film Poster/" + _Index, FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(_uri));
            encoder.Save(stream);
            stream.Flush();
            stream.Close();
        }

        private void cb_TheLoai_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Phim_Pub> m_ListFilm;
            string TheLoai = cb_TheLoai.SelectedValue.ToString();
            cb_MaPhim.ItemsSource = null;
            ManageLabelXuat(true);
            ManageInput(false);
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

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            string fileLink;
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";

            Nullable<bool> result = dlg.ShowDialog();
            if (result != null)
            {
                fileLink = dlg.FileName;
                if (fileLink != "")
                {
                    filmPosterURI = new Uri(fileLink);
                    img_Poster.Source = new BitmapImage(filmPosterURI);
                } 
            }

        }

        private void ManageLabelXuat(bool _Input)
        {
            if (_Input)
            {
                lb_XuatDaoDien.Text = "";
                lb_XuatDienVien.Text = "";
                lb_XuatDoTuoiQuyDinh.Text = "";
                //lb_XuatNamPhatHanh.Content = "";
                //lb_XuatNgayKhoiChieu.Content = "";
                lb_XuatNoiDung.Text = "";
                lb_XuatNuocSanXuat.Text = "";
                lb_XuatTenPhim.Text = "";
                lb_XuatThoiLuong.Text = "";
                cb_XuatTheLoai.SelectedItem = null;
                img_Poster.Source = null;
                datepicker_NgayKhoiChieu.SelectedDate = null;
                datepicker_NamPhatHanh.SelectedDate = null;
                //lb_XuatTheLoai.Content = "";
            }
        }

        private void ManageInput(bool _Enable)
        {
            if (_Enable)
            {
                cb_XuatTheLoai.Visibility = System.Windows.Visibility.Visible;
                btn_ChonAnh.Visibility = System.Windows.Visibility.Visible;
                lb_xuatTheLoai.Visibility = System.Windows.Visibility.Visible;
                lb_XuatThoiLuong.Visibility = System.Windows.Visibility.Visible;
                datepicker_NamPhatHanh.Visibility = System.Windows.Visibility.Visible;
                datepicker_NgayKhoiChieu.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDaoDien.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDienVien.Visibility = System.Windows.Visibility.Visible;
                lb_XuatDoTuoiQuyDinh.Visibility = System.Windows.Visibility.Visible;
                lb_XuatNoiDung.Visibility = System.Windows.Visibility.Visible;
                lb_XuatNuocSanXuat.Visibility = System.Windows.Visibility.Visible;
                lb_XuatTenPhim.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                cb_XuatTheLoai.Visibility = System.Windows.Visibility.Hidden;
                btn_ChonAnh.Visibility = System.Windows.Visibility.Hidden;
                lb_xuatTheLoai.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatThoiLuong.Visibility = System.Windows.Visibility.Hidden;
                datepicker_NamPhatHanh.Visibility = System.Windows.Visibility.Hidden;
                datepicker_NgayKhoiChieu.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDaoDien.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDienVien.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatDoTuoiQuyDinh.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatNoiDung.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatNuocSanXuat.Visibility = System.Windows.Visibility.Hidden;
                lb_XuatTenPhim.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
