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
    /// Interaction logic for Giao_dien_chon_ghe_dat_ve.xaml
    /// </summary>
    public partial class Giao_dien_chon_ghe_dat_ve : Window
    {
        List<Ghe_Pub> LghePub;
        List<Ghe_Pub> Lselection;
        string _SC;
        public Giao_dien_chon_ghe_dat_ve()
        {
            InitializeComponent();
            if (Giao_dien_phieu_dat_ve.g_SuatChieu != null)
            {
                _SC = Giao_dien_phieu_dat_ve.g_SuatChieu; 
            }
            if (Giao_dien_ban_ve.g_SuatChieu != null)
            {
                _SC = Giao_dien_ban_ve.g_SuatChieu;
            }
            Ghe_BUL ghe_bul = new Ghe_BUL();
            Lselection = new List<Ghe_Pub>();
            LghePub = ghe_bul.GetGheTheoSuatChieu(_SC);
        }

        private void btn_Chair_Click(object sender, RoutedEventArgs e)
        {
            string _MaGhe = (sender as Button).Content.ToString();
            Ghe_Pub ghe_pub = new Ghe_Pub();
            ghe_pub.MaSC = _SC;
            ghe_pub.MaGhe = _MaGhe;
            ghe_pub.Trong = false;
            bool isExist = false;
            int index = 0;
            for (int i = 0; i < Lselection.Count; i++)
            {
                if (Lselection[i].MaGhe == _MaGhe)
                {
                    isExist = true;
                    index = i;
                }
            }
            if (isExist)
            {
                Lselection.Remove(Lselection[index]);
                //Giao_dien_phieu_dat_ve.g_Lmaghe.Remove(Lselection[index].MaGhe);
                (sender as Button).Background = Brushes.LightGray;
                Ghe_BUL ghe_bul = new Ghe_BUL();
                ghe_pub.Trong = true;
                ghe_bul.Update(ghe_pub);
            }
            else
            {
                Lselection.Add(ghe_pub);
                (sender as Button).Background = Brushes.Red;
            }
            //if (Lselection.BinarySearch(ghe_pub) < 0)
            //{
                
            //    Lselection.Add(ghe_pub);
            //    (sender as Button).Background = Brushes.Red; 
            //}
            //else
            //{
                
            //    Lselection.Remove(ghe_pub);
            //    (sender as Button).Background = Brushes.Gray; 
            //}
            //(sender as Button).IsEnabled = false;
            
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
            foreach (Button btn in FindVisualChildren<Button>(this))
            {
                if (Giao_dien_phieu_dat_ve.g_Lmaghe != null)
                {
                    for (int i = 0; i < Giao_dien_phieu_dat_ve.g_Lmaghe.Count; i++)
                    {
                        if (btn.Content.ToString() == Giao_dien_phieu_dat_ve.g_Lmaghe[i])
                        {
                            btn.IsEnabled = true;
                            btn.Background = Brushes.Red;
                            Ghe_Pub ghe_pub = new Ghe_Pub();
                            ghe_pub.MaSC = Giao_dien_phieu_dat_ve.g_SuatChieu;
                            ghe_pub.Trong = false;
                            ghe_pub.MaGhe = btn.Content.ToString();
                            Lselection.Add(ghe_pub);
                        }
                    } 
                }
                if (Giao_dien_ban_ve.g_Lmaghe != null)
                {
                    for (int i = 0; i < Giao_dien_ban_ve.g_Lmaghe.Count; i++)
                    {
                        if (btn.Content.ToString() == Giao_dien_ban_ve.g_Lmaghe[i])
                        {
                            btn.IsEnabled = true;
                            btn.Background = Brushes.Red;
                            Ghe_Pub ghe_pub = new Ghe_Pub();
                            ghe_pub.MaSC = Giao_dien_ban_ve.g_SuatChieu;
                            ghe_pub.Trong = false;
                            ghe_pub.MaGhe = btn.Content.ToString();
                            Lselection.Add(ghe_pub);
                        }
                    }
                }
            }

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Giao_dien_phieu_dat_ve.g_SuatChieu != null)
            {
                Giao_dien_phieu_dat_ve.g_Lmaghe = new List<string>();
                Ghe_BUL ghe_bul = new Ghe_BUL();
                for (int i = 0; i < Lselection.Count; i++)
                {
                    ghe_bul.Update(Lselection[i]);
                }

                for (int i = 0; i < Lselection.Count; i++)
                {
                    Giao_dien_phieu_dat_ve.g_Lmaghe.Add(Lselection[i].MaGhe);
                }
                this.Close();
            }
            if (Giao_dien_ban_ve.g_SuatChieu != null)
            {
                Giao_dien_ban_ve.g_Lmaghe = new List<string>();
                Ghe_BUL ghe_bul = new Ghe_BUL();
                for (int i = 0; i < Lselection.Count; i++)
                {
                    ghe_bul.Update(Lselection[i]);
                }

                for (int i = 0; i < Lselection.Count; i++)
                {
                    Giao_dien_ban_ve.g_Lmaghe.Add(Lselection[i].MaGhe);
                }
                VarGlobal.g_LVeBanPub = new List<VeBan_Pub>();
                
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
}
