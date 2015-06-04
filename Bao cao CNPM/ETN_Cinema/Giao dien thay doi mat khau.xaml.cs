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
    /// Interaction logic for Giao_dien_thay_doi_mat_khau.xaml
    /// </summary>
    public partial class Giao_dien_thay_doi_mat_khau : Window
    {
        public Giao_dien_thay_doi_mat_khau()
        {
            InitializeComponent();
        }

        private void bt_ThayDoi1_Click(object sender, RoutedEventArgs e)
        {
            string _matkhaumoi;
            string _matkhaulaplai;

            NhanVien_BUL _nhanvien_BUL = new NhanVien_BUL();

            _matkhaumoi = pw_MatKhauMoi.Password.ToString();
            _matkhaulaplai = pw_MatKhauLapLai.Password.ToString();

            // Kiểm tra mật khẩu có trùng với mật khẩu lúc đăng nhập hay không ?
            //if (StaticMethod.md5(pw_MatKhauCu.Password.ToString()) == VarGlobal.g_NhanVienPub.MatKhau)
            if (pw_MatKhauCu.Password.ToString() == VarGlobal.g_NhanVienPub.MatKhau)
            {


                if (_matkhaumoi != "" && _matkhaulaplai != "")
                {
                    if (_matkhaumoi == _matkhaulaplai)
                    {
                        //_nhanvien_BUL.UpdatePassword(StaticMethod.md5(_matkhaumoi), VarGlobal.g_NhanVienPub.MaNV);
                        _nhanvien_BUL.UpdatePassword(_matkhaumoi, VarGlobal.g_NhanVienPub.MaNV);
                        MessageBox.Show("Thay Đổi Mật Khẩu Thành Công");
                        this.Close();
                    }
                }
                else if(_matkhaumoi != _matkhaulaplai)
                {
                    MessageBox.Show("Mật Khẩu Không Trùng Nhau");
                    pw_MatKhauCu.Password = "";
                    pw_MatKhauMoi.Password = "";
                    pw_MatKhauLapLai.Password = "";
                }
            }
            else
            {
                MessageBox.Show("Không Đúng Mật Khẩu");
                pw_MatKhauCu.Password = "";
                pw_MatKhauMoi.Password = "";
                pw_MatKhauLapLai.Password = "";
            }

        }
    }
}
