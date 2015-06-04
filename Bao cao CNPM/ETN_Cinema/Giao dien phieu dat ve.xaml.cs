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
    /// Interaction logic for Giao_dien_phieu_dat_ve.xaml
    /// </summary>
    public partial class Giao_dien_phieu_dat_ve : Window
    {
        public static string g_SuatChieu;
        public static List<string> g_Lmaghe;
        List<Phim_Pub> LphimPUB;
        List<SuatChieu_Pub> LsuatchieuPUB;
        List<string> LloaiSC;
        List<string> LGioChieu;
        List<string> LPhongChieu;
        List<string> LNgayChieu;

        public Giao_dien_phieu_dat_ve()
        {
            InitializeComponent();
            Phim_BUL phim_bul = new Phim_BUL();
            LsuatchieuPUB = new List<SuatChieu_Pub>();
            LphimPUB = phim_bul.GetMaPhim();
            
            cb_TenPhim.ItemsSource = LphimPUB;
            cb_TenPhim.DisplayMemberPath = "TenPhim";
            cb_TenPhim.SelectedValuePath = "TenPhim";
            lb_XuatNgayDatVe.Content = DateTime.Today.ToShortDateString();
        }

        private void cb_TenPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SuatChieu_BUL sc_BUL = new SuatChieu_BUL();
            LloaiSC = new List<string>();
            LGioChieu = new List<string>();
            LPhongChieu = new List<string>();
            //cb_LoaiSuatChieu.ItemsSource = LloaiSC;
            LsuatchieuPUB = sc_BUL.GetSuatChieuTheoTenPhim(cb_TenPhim.SelectedValue.ToString());
            
            for (int i = 0; i < LsuatchieuPUB.Count; i++)
            {
                if (LloaiSC.BinarySearch(LsuatchieuPUB[i].LoaiSuatChieu) < 0)
                {
                    LloaiSC.Add(LsuatchieuPUB[i].LoaiSuatChieu);
                }
            }
            cb_PhongChieu.ItemsSource = LPhongChieu;
            cb_LoaiSuatChieu.ItemsSource = LloaiSC;
            cb_GioChieu.ItemsSource = LGioChieu;
            cb_NgayChieu.ItemsSource = null;
            cb_LoaiSuatChieu.Text = "";
        }

        private void cb_LoaiSuatChieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SuatChieu_BUL sc_BUL = new SuatChieu_BUL();
            LsuatchieuPUB = sc_BUL.GetSuatChieuTheoTenPhim(cb_TenPhim.SelectedValue.ToString());
            LGioChieu = new List<string>();
            LPhongChieu = new List<string>();
            LNgayChieu = new List<string>();
            for (int i = 0; i < LsuatchieuPUB.Count; i++)
            {
                if (LsuatchieuPUB[i].TenPhim != cb_TenPhim.Text || LsuatchieuPUB[i].LoaiSuatChieu.ToString() != cb_LoaiSuatChieu.SelectedItem.ToString())
                {
                    LsuatchieuPUB.Remove(LsuatchieuPUB[i]);
                }
            }

            if (LsuatchieuPUB.Count != 0)
            {
                for (int i = 0; i < LsuatchieuPUB.Count; i++)
                {
                    if (LGioChieu.BinarySearch(LsuatchieuPUB[i].NgayChieu.ToShortDateString()) < 0)
                    {
                        LNgayChieu.Add(LsuatchieuPUB[i].NgayChieu.ToShortDateString());
                    }
                }

                for (int i = 0; i < LsuatchieuPUB.Count; i++)
                {
                    if (LGioChieu.BinarySearch(LsuatchieuPUB[i].GioChieu.ToShortTimeString()) < 0)
                    {
                        LGioChieu.Add(LsuatchieuPUB[i].GioChieu.ToShortTimeString());
                    }
                }

                for (int i = 0; i < LsuatchieuPUB.Count; i++)
                {
                    if (LPhongChieu.BinarySearch(LsuatchieuPUB[i].PhongChieu) < 0)
                    {
                        LPhongChieu.Add(LsuatchieuPUB[i].PhongChieu);
                    }
                }
            }
            cb_GioChieu.ItemsSource = LGioChieu;
            cb_PhongChieu.ItemsSource = LPhongChieu;
            cb_NgayChieu.ItemsSource = LNgayChieu;
            cb_NgayChieu.Text = "";
            cb_PhongChieu.Text = "";
            cb_GioChieu.Text = "";
        }

        
        
        private void XuatMaGhe(object sender, System.EventArgs e)
        {
            lb_XuatMaGheDat.Content = "";
            for (int i = 0; i < g_Lmaghe.Count; i++)
			{
                lb_XuatMaGheDat.Content += g_Lmaghe[i];
                if (i != g_Lmaghe.Count - 1)
                {
                    lb_XuatMaGheDat.Content += ", ";
                }
                //btn_Chair.IsEnabled = false;
			}
        }

        private void btn_Chair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                g_SuatChieu = LsuatchieuPUB[0].MaSC;
                if (g_Lmaghe == null)
                {
                    g_Lmaghe = new List<string>();
                }
                //lb_XuatNgayDatVe.Content = DateTime.Today.ToShortDateString();
                Giao_dien_chon_ghe_dat_ve _zzz = new Giao_dien_chon_ghe_dat_ve();

                _zzz.Closed += XuatMaGhe;
                _zzz.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                PhieuDatVe_BUL pdv_BUL = new PhieuDatVe_BUL();


                for (int i = 0; i < g_Lmaghe.Count; i++)
                {
                    PhieuDatVe_Pub pdv_pub = new PhieuDatVe_Pub();
                    pdv_pub.GioChieu = DateTime.Parse(cb_GioChieu.Text);
                    pdv_pub.MaKH = VarGlobal.g_KhachHangPub.MaKH;
                    pdv_pub.NgayChieu = DateTime.Parse(cb_NgayChieu.Text);
                    pdv_pub.NgayDatVe = DateTime.Parse(lb_XuatNgayDatVe.Content.ToString());
                    pdv_pub.PhongChieu = cb_PhongChieu.Text;
                    pdv_pub.TenPhim = cb_TenPhim.Text;
                    pdv_pub.TriGia = LsuatchieuPUB[0].Gia;
                    pdv_pub.MaSC = LsuatchieuPUB[0].MaSC;
                    pdv_pub.MaGhe = g_Lmaghe[i];
                    pdv_BUL.Insert(pdv_pub);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            MessageBox.Show("Đặt vé thành công!");
            g_SuatChieu = null;
            g_Lmaghe = null;
            this.Close();
        }
    }
}
