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
    /// Interaction logic for Giao_dien_ban_ve.xaml
    /// </summary>

    public partial class Giao_dien_ban_ve : Window
    {
        List<Phim_Pub> LphimPUB;
        List<SuatChieu_Pub> LsuatchieuPUB;
        List<string> LloaiSC;
        List<string> LGioChieu;
        List<string> LPhongChieu;
        List<string> LNgayChieu;
        public static string g_SuatChieu;
        public static List<string> g_Lmaghe;
        public Giao_dien_ban_ve()
        {
            InitializeComponent();
            Phim_BUL phim_bul = new Phim_BUL();
            LsuatchieuPUB = new List<SuatChieu_Pub>();
            LphimPUB = phim_bul.GetMaPhim();
            
            cb_TenPhim.ItemsSource = LphimPUB;
            cb_TenPhim.DisplayMemberPath = "TenPhim";
            cb_TenPhim.SelectedValuePath = "TenPhim";
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

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (g_Lmaghe == null)
            {
                g_Lmaghe = new List<string>();
            }
            VarGlobal.g_VeBanPub = new VeBan_Pub();
            VarGlobal.g_VeBanPub.MaSC = LsuatchieuPUB[0].MaSC;
            VarGlobal.g_VeBanPub.LoaiSC = cb_LoaiSuatChieu.Text;
            VarGlobal.g_VeBanPub.GioChieu = DateTime.Parse(cb_GioChieu.Text);
            VarGlobal.g_VeBanPub.GiaVe = LsuatchieuPUB[0].Gia;
            VarGlobal.g_VeBanPub.NgayChieu = LsuatchieuPUB[0].NgayChieu;
            VarGlobal.g_VeBanPub.PhongChieu = cb_PhongChieu.Text;
            VarGlobal.g_VeBanPub.TenPhim = cb_TenPhim.Text;
            VarGlobal.g_VeBanPub.MaNV = tb_MaNhanVien.Text;//chỗ này thay bằng mã nhân viên lúc nhân viên nó đăng nhập vào nha Khoa(nhân viên bình thường thì chỉ cho nó truy cập vào chức năng bán vé thôi)!
            g_SuatChieu = LsuatchieuPUB[0].MaSC;
            Giao_dien_chon_ghe_dat_ve _gdcg = new Giao_dien_chon_ghe_dat_ve();
            this.Close();
            _gdcg.ShowDialog();
        }
    }
}
