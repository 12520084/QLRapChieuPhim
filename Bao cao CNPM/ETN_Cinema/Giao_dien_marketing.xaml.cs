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
    /// Interaction logic for Giao_dien_marketing.xaml
    /// </summary>
    public partial class Giao_dien_marketing : Window
    {
        public Giao_dien_marketing()
        {
            InitializeComponent();
        }

        private void mn_NhapKhuyenMai_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_nhap_khuyen_mai _gdnkm = new Giao_dien_nhap_khuyen_mai();
            _gdnkm.ShowDialog();
        }

        private void mn_SuaKhuyenMai_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_sua_khuyen_mai _gdskm = new Giao_dien_sua_khuyen_mai();
            _gdskm.ShowDialog();
        }
    }
}
