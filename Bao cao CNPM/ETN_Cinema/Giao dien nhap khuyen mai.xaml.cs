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
using BUL;
using PUBLIC;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_nhap_khuyen_mai.xaml
    /// </summary>
    public partial class Giao_dien_nhap_khuyen_mai : Window
    {
        public Giao_dien_nhap_khuyen_mai()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            KhuyenMai_Pub km_pub = new KhuyenMai_Pub();
            KhuyenMai_BUL km_bul = new KhuyenMai_BUL();

            HeSoKM_BUL hskm_bul = new HeSoKM_BUL();
            HeSoKM_Pub hskm_pub1 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub2 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub3 = new HeSoKM_Pub();
            HeSoKM_Pub hskm_pub4 = new HeSoKM_Pub();
            
            km_pub.TenKM = tb_TenKM.Text;
            km_pub.NgayBatDau = datepicker_NgayBatDau.SelectedDate.Value;
            km_pub.NgayKetThuc = datepicker_NgayKetThuc.SelectedDate.Value;
            km_pub.NoiDung = tb_NoiDungKM.Text;

            hskm_pub1.HeSoKM = float.Parse(tb_LoaiKHMoi.Text);
            hskm_pub2.HeSoKM = float.Parse(tb_LoaiKHTT.Text);
            hskm_pub3.HeSoKM = float.Parse(tb_LoaiKHVIP.Text);
            hskm_pub4.HeSoKM = float.Parse(tb_LoaiKHBT.Text);

            hskm_pub1.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub2.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub3.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());
            hskm_pub4.MaKM = GetMa("KM", GetIndex_BUL.GetIndexKhuyenMai());

            hskm_pub1.TenLoaiKH = lb_LoaiKHMoi.Content.ToString();
            hskm_pub2.TenLoaiKH = lb_LoaiKHTT.Content.ToString();
            hskm_pub3.TenLoaiKH = lb_LoaiKHVIP.Content.ToString();
            hskm_pub4.TenLoaiKH = lb_LoaiKHBT.Content.ToString();

            hskm_bul.Insert(hskm_pub1);
            hskm_bul.Insert(hskm_pub2);
            hskm_bul.Insert(hskm_pub3);
            hskm_bul.Insert(hskm_pub4);
            km_bul.Insert(km_pub);
        }

        public string GetMa(string _startString, int m_Index)
        {
            if (m_Index < 10)
            {
                return _startString + "000" + m_Index;
            }
            else
            {
                if (m_Index < 100)
                {
                    return _startString + "00" + m_Index;
                }
                else
                {
                    if (m_Index < 1000)
                    {
                        return _startString + "0" + m_Index;
                    }
                    else
                    {
                        return _startString + m_Index;
                    }
                }
            }
        }
    }
}
