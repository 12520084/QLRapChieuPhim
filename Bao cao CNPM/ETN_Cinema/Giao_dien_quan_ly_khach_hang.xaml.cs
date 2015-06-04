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
    /// Interaction logic for Giao_dien_quan_ly_khach_hang.xaml
    /// </summary>
    public partial class Giao_dien_quan_ly_khach_hang : Window
    {
        public Giao_dien_quan_ly_khach_hang()
        {
            InitializeComponent();
        }

        private void mn_NhapKhachHang_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_thong_tin_khach_hang _gdttkh = new Giao_dien_thong_tin_khach_hang();
            _gdttkh.ShowDialog();
        }

        private void mn_SuaKhachHang_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_sua_thong_tin_khach_hang _gdsttkh = new Giao_dien_sua_thong_tin_khach_hang();
            _gdsttkh.ShowDialog();
        }
    }
}
