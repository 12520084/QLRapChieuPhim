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
    /// Interaction logic for Giao_dien_xem_ho_so.xaml
    /// </summary>
    public partial class Giao_dien_xem_ho_so : Window
    {
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

        public Giao_dien_xem_ho_so()
        {
            InitializeComponent();


            ChucVu_BUL _pchucvuBUL = new ChucVu_BUL();
            ChucVu_Pub _chucvuPub = new ChucVu_Pub();

            NhanVien_BUL _pnhanvienBUL = new NhanVien_BUL();
            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();

            lbc_MaNV.Content = VarGlobal.g_NhanVienPub.MaNV;
            lbc_HoTen.Content = VarGlobal.g_NhanVienPub.HoTen;
            lbc_NamSinh.Content = VarGlobal.g_NhanVienPub.NamSinh.ToShortDateString();
            lbc_GioiTinh.Content = StaticMethod.SetGender(VarGlobal.g_NhanVienPub.GioiTinh);
            lbc_DienThoai.Content = VarGlobal.g_NhanVienPub.DienThoai;
            lbc_Email.Content = VarGlobal.g_NhanVienPub.Email;
            lbc_QueQuan.Content = VarGlobal.g_NhanVienPub.QueQuan;
            lbc_DiaChi.Content = VarGlobal.g_NhanVienPub.DiaChi;
            lbc_CMND.Content = VarGlobal.g_NhanVienPub.CMND;
            
            _chucvuPub = _pchucvuBUL.GetCVTheoMaCV(VarGlobal.g_NhanVienPub.MaCV.ToString());
            lbc_ChucVu.Content = _chucvuPub.TenCV;

            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();
            lbc_PhongBan.Content = _phongbanBUL.GetPBTheoMaPB(VarGlobal.g_NhanVienPub.MaPB).TenPB;

            lbc_NgayVaoLam.Content = VarGlobal.g_NhanVienPub.NgayVaoLam.ToShortDateString();

#region. Set image
            image_HinhAnh.Source = GetHinhAnhTuPoster(VarGlobal.g_NhanVienPub.HinhAnh);
#endregion

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
