using BUL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    /// Interaction logic for Giao_dien_dang_nha.xaml
    /// </summary>
    public partial class Giao_dien_dang_nhap : Window
    {

        public Giao_dien_dang_nhap()
        {
            InitializeComponent();
            tb_MaNV.Text = "NV0001";
            pass_MK.Password = "123456";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

            _nhanvienPub = _nhanvienBUL.GetNV(tb_MaNV.Text.ToString());

            KhachHang_Pub _khachhangPub = new KhachHang_Pub();
            KhachHang_BUL _khachhangBUL = new KhachHang_BUL();

            _khachhangPub = _khachhangBUL.GetKHTuMaKH(tb_MaNV.Text.ToString());


            //if (StaticMethod.md5(pass_MK.Password.ToString()) == _nhanvienPub.MatKhau)
            if (pass_MK.Password.ToString() == _nhanvienPub.MatKhau)
            {
                VarGlobal.g_NhanVienPub = _nhanvienPub;
                SetPermission(_nhanvienPub.MaPB);
                this.Close();
            }
            else
            {
                //if (StaticMethod.md5(pass_MK.Password.ToString()) == _khachhangPub.MatKhau)
                if (pass_MK.Password.ToString() == _khachhangPub.MatKhau)
                {
                    VarGlobal.g_KhachHangPub = _khachhangPub;
                    Giao_dien_nguoi_su_dung _gdnsd = new Giao_dien_nguoi_su_dung();
                    this.Close();
                    _gdnsd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu đã bị sai - Nhấn OK để nhập lại");
                }
            }
        }

        private void SetPermission(string _MaPB)
        {
            switch (_MaPB)
            {
                case "PB0001":
                    Giao_dien_quan_li_nhan_su _gdql = new Giao_dien_quan_li_nhan_su();
                    _gdql.Show();
                    break;
                case "PB0002":
                    Giao_dien_quan_li_phong_kinh_doanh _gdqlkd = new Giao_dien_quan_li_phong_kinh_doanh();
                    _gdqlkd.Show();
                    break;
                case "PB0003":
                     Giao_dien_phong_tai_chinh _gdtc= new Giao_dien_phong_tai_chinh();
                    _gdtc.Show();
                    break;
                default:
                    break;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void image_login_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            tb_MaNV.Text = "";
            pass_MK.Password = "";
        }

    }
}
