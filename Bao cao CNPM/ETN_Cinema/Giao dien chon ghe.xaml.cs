using PUBLIC;
using BUL;
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
    /// Interaction logic for Giao_dien_chon_ghe.xaml
    /// </summary>
    public partial class Giao_dien_chon_ghe : Window
    {
        List<Ghe_Pub> LghePub;
        List<Ghe_Pub> Lselection;
        string _SC;
        public Giao_dien_chon_ghe()
        {
            InitializeComponent();
            _SC = VarGlobal.g_VeBanPub.MaSC;
            Ghe_BUL ghe_bul = new Ghe_BUL();
            Lselection = new List<Ghe_Pub>();
            LghePub = ghe_bul.GetGheTheoSuatChieu(_SC);
        }

        private void btn_Chair_Click(object sender, RoutedEventArgs e)
        {
            string a = (sender as Button).Content.ToString();
            Ghe_Pub ghe_pub = new Ghe_Pub();
            ghe_pub.MaSC = _SC;
            ghe_pub.MaGhe = a;
            ghe_pub.Trong = false;
            Lselection.Add(ghe_pub);
            (sender as Button).IsEnabled = false;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void MyInit(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in FindVisualChildren<Button>(this))
            {
                for (int i = 0; i < LghePub.Count; i++)
                {
                    if (btn.Content.ToString() == LghePub[i].MaGhe)
                    {
                        if (!LghePub[i].Trong)
                        {
                            btn.IsEnabled = false;
                        }
                    }
                }
            }

        }

        private void btn_Undo_Click(object sender, RoutedEventArgs e)
        {
            if (Lselection.Count != 0)
            {
                foreach (Button btn in FindVisualChildren<Button>(this))
                {
                    if (btn.Content.ToString() == Lselection[Lselection.Count - 1].MaGhe)
                    {
                          btn.IsEnabled = true;
                    }
                }
                Lselection.RemoveAt(Lselection.Count - 1);
            }
        }

        private void btn_RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            while(Lselection.Count != 0)
            {
                foreach (Button btn in FindVisualChildren<Button>(this))
                {
                    if (btn.Content.ToString() == Lselection[Lselection.Count - 1].MaGhe)
                    {
                        btn.IsEnabled = true;
                    }
                }
                Lselection.RemoveAt(Lselection.Count - 1);
            }
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            VarGlobal.g_LVeBanPub = new List<VeBan_Pub>();
            Ghe_BUL ghe_bul = new Ghe_BUL();
            for (int i = 0; i < Lselection.Count; i++)
            {
                ghe_bul.Update(Lselection[i]);
            }
            btn_RemoveAll.IsEnabled = false;
            btn_Undo.IsEnabled = false;
            for (int i = 0; i < Lselection.Count; i++)
            {
                VeBan_Pub _temp = new VeBan_Pub();
                _temp.GiaVe = VarGlobal.g_VeBanPub.GiaVe;
                _temp.GioChieu = VarGlobal.g_VeBanPub.GioChieu;
                _temp.LoaiSC = VarGlobal.g_VeBanPub.LoaiSC;
                _temp.MaSC = VarGlobal.g_VeBanPub.MaSC;
                _temp.NgayChieu = VarGlobal.g_VeBanPub.NgayChieu;
                _temp.PhongChieu = VarGlobal.g_VeBanPub.PhongChieu;
                _temp.TenPhim = VarGlobal.g_VeBanPub.TenPhim;
                _temp.MaGhe = Lselection[i].MaGhe;
                _temp.MaNV = VarGlobal.g_VeBanPub.MaNV;
                VarGlobal.g_LVeBanPub.Add(_temp);
            }
            Giao_dien_tinh_gia_ve _gdtgv = new Giao_dien_tinh_gia_ve();
            this.Close();
            _gdtgv.ShowDialog();
        }
    }
}
