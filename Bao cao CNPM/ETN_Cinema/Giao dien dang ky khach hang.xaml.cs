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
    /// Interaction logic for Giao_dien_dang_ky_khach_hang.xaml
    /// </summary>
    public class MyGioiTinh
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        private bool m_Sex;

        public bool Sex
        {
            get { return m_Sex; }
            set { m_Sex = value; }
        }

        public MyGioiTinh(string _Name, bool _Sex)
        {
            Name = _Name;
            Sex = _Sex;
        }
    }

    public partial class Giao_dien_dang_ky_khach_hang : Window
    {
        List<MyGioiTinh> list;
        public Giao_dien_dang_ky_khach_hang()
        {
            InitializeComponent();
            list = new List<MyGioiTinh>();
            MyGioiTinh Nam = new MyGioiTinh("Nam", true);
            MyGioiTinh Nu = new MyGioiTinh("Nữ", false);
            
            list.Add(Nam);
            list.Add(Nu);
            cb_GioiTinh.ItemsSource = list;
            cb_GioiTinh.SelectedValuePath = "Sex";
            cb_GioiTinh.DisplayMemberPath = "Name";
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KhachHang_BUL kh_bul = new KhachHang_BUL();
            KhachHang_Pub kh_pub = new KhachHang_Pub();

            kh_pub.MatKhau = "123456";
            kh_pub.HoTen = tb_HoTen.Text;
            kh_pub.Email = tb_EmailName.Text + lb_At.Content.ToString() + tb_EmailDomain.Text;
            kh_pub.DiaChi = tb_DiaChi.Text;
            kh_pub.Diem = 0;
            kh_pub.MaLoaiKH = "Khách Hàng Mới";
            kh_pub.SoDT = tb_SoDienThoai.Text;
            kh_pub.NgayDangKy = datePicker_NgayDangKy.SelectedDate.Value;
            kh_pub.NamSinh = datePicker_NgaySinh.SelectedDate.Value;
            kh_pub.CMND = tb_CMND.Text;
            kh_pub.GioiTinh = (bool)cb_GioiTinh.SelectedValue;

            kh_bul.Insert(kh_pub);
        }

        private void cb_GioiTinh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
