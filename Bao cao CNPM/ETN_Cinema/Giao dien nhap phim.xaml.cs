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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyException m_Exception;
        List<TheLoaiPhim_Pub> LtlPUB;
        Uri filmPosterURI;
        //string filename;
        public MainWindow()
        {
            InitializeComponent();
            TheLoaiPhim_BUL tl_bul = new TheLoaiPhim_BUL();
            LtlPUB = tl_bul.GetTheLoai();
            cb_TheLoai.ItemsSource = LtlPUB;
            cb_TheLoai.DisplayMemberPath = "TenLP";
            cb_TheLoai.SelectedValuePath = "TenLP";
            m_Exception = new MyException();
            m_Exception.AddImage(img_Poster, lb_Poster);
            m_Exception.AddDateTimePicker(datepicker_NgayKhoiChieu, lb_NgayKhoiChieu);
            m_Exception.AddDateTimePicker(datepicker_NgayNhapPhieu, lb_NgayNhapPhieu);
            m_Exception.AddTextBox(tb_TenNhanVien, lb_TenNhanVien);
            m_Exception.AddTextBox(tb_SoPhieuNhap, lb_SoPhieuNhap);
            m_Exception.AddTextBox(tb_TenPhim, lb_TenPhim);
            m_Exception.AddTextBox(tb_NoiDung, lb_NoiDung);
            m_Exception.AddTextBox(tb_ThoiLuong, lb_ThoiLuong);
            m_Exception.AddTextBox(tb_DienVien, lb_DienVien);
            m_Exception.AddTextBox(tb_DaoDien, lb_DaoDien);
            m_Exception.AddTextBox(tb_NamPhatHanh, lb_NamPhatHanh);
            m_Exception.AddTextBox(tb_NuocSanXuat, lb_NuocSanXuat);
            //m_Exception.AddTextBox(tb_TheLoai, lb_TheLoai);
            m_Exception.AddTextBox(tb_DoTuoiQuyDinh, lb_DoTuoiQuyDinh);
        }

        //private string IncreaseIndexBy1(string _StringInput, string _StartIndex)
        //{
        //    string result = "";
        //    if (_StringInput == "")
        //    {
        //        result = _StartIndex + "1";
        //    }
        //    else
        //    {
        //        result = _StartIndex + _StringInput;
        //    }
        //    return result;
        //}

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            Phim_Pub phim = new Phim_Pub();
            Phim_BUL phim_bul = new Phim_BUL();
            //Phim_BUL phim_reader = new Phim_BUL();
            //m_Exception.ShowMessageBox();
            int temp;
            try
            {
                m_Exception.ThrowExceptionForMessageBox();
                if (!int.TryParse(tb_ThoiLuong.Text, out temp))
                {
                    throw new FormatException("Thời lượng phải là số!");
                }
                if (!m_Exception.IsError)
                {
                    phim.DaoDien = tb_DaoDien.Text;
                    phim.DienVien = tb_DienVien.Text;
                    phim.TenPhim = tb_TenPhim.Text;
                    phim.TheLoai = cb_TheLoai.SelectedValue.ToString();
                    phim.NgayChieu = datepicker_NgayKhoiChieu.SelectedDate.Value;
                    phim.NamPhatHanh = datepicker_NgayNhapPhieu.SelectedDate.Value;
                    //phim.Poster = filename;
                    phim.Poster = GetIndex_BUL.GetIndexPhim().ToString() + ".png";
                    phim.ThoiLuong = int.Parse(tb_ThoiLuong.Text);
                    phim.NoiDung = tb_NoiDung.Text;
                    phim.NuocSanXuat = tb_NuocSanXuat.Text;
                    phim.TuoiQuyDinh = int.Parse(tb_DoTuoiQuyDinh.Text);
                    if (filmPosterURI != null)
                    {
                        CreatePoster(filmPosterURI); 
                    }
                    else
                    {
                        throw new Exception("Chưa nhập Poster Phim");
                    }
                    phim_bul.Insert(phim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreatePoster(Uri _uri)
        {
            FileStream stream = new FileStream("../Debug/Image/Film Poster/" + GetIndex_BUL.GetIndexPhim().ToString() + ".png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(_uri));
            encoder.Save(stream);
            stream.Flush();
            stream.Close();
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            string fileLink;
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            //Image tempImage = new Image();
            // Get the selected file name and display in a TextBox 

            if (result != null)
            {
                fileLink = dlg.FileName;
                filmPosterURI = new Uri(fileLink);
                img_Poster.Source = new BitmapImage(filmPosterURI); 
            }
            ////tempImage.Source = new BitmapImage(uri);
            ////if (tempImage.Source.Height > 800)
            ////{
            ////    throw new Exception("Thằng Lép nhiều chuyện vl");
            ////}
            ////save hình
            //FileStream stream = new FileStream("../Debug/Image/" + GetIndex_BUL.GetIndexPhim().ToString() + ".png", FileMode.Create);
            //PngBitmapEncoder encoder = new PngBitmapEncoder();
            ////TextBlock myTextBlock = new TextBlock();
            ////myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            //encoder.Interlace = PngInterlaceOption.On;
            //encoder.Frames.Add(BitmapFrame.Create(uri));
            //encoder.Save(stream);
            //stream.Flush();
            //stream.Close();
            //img_Poster.Source = new BitmapImage(new Uri(stream.Name));
            //filename = stream.Name;
            //tb_LinkAnh.Text = filename;
        }
    }
}
