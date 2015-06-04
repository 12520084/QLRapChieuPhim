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
    /// Interaction logic for Giao_dien_quan_ly_phim.xaml
    /// </summary>
    public partial class Giao_dien_quan_ly_phim : Window
    {
        public Giao_dien_quan_ly_phim()
        {
            InitializeComponent();
        }

        private void mn_NhapPhim_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _gdnp = new MainWindow();
            _gdnp.ShowDialog();
        }

        private void mn_SuaPhim_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_sua_thong_tin_phim _gdsttp = new Giao_dien_sua_thong_tin_phim();
            _gdsttp.ShowDialog();
        }

        private void mn_NhapSuatChieu_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_mo_suat_chieu _gdnsc = new Giao_dien_mo_suat_chieu();
            _gdnsc.ShowDialog();
        }

        private void mn_SuaSuatChieu_Click(object sender, RoutedEventArgs e)
        {
            Giao_dien_sua_suat_chieu _gdssc = new Giao_dien_sua_suat_chieu();
            _gdssc.ShowDialog();
        }
    }
}
