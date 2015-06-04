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
    /// Interaction logic for Giao_dien_sua_khuyen_mai.xaml
    /// </summary>
    public partial class Giao_dien_sua_khuyen_mai : Window
    {
        List<KhuyenMai_Pub> LkmPUB;
        public Giao_dien_sua_khuyen_mai()
        {
            InitializeComponent();
            KhuyenMai_BUL km_bul = new KhuyenMai_BUL();
            LkmPUB = km_bul.GetKM();
            cb_MaCTKM.ItemsSource = LkmPUB;
            cb_MaCTKM.DisplayMemberPath = "MaKM";
            cb_MaCTKM.SelectedValuePath = "MaKM";
        }
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            string _MaKM = "";
            if (cb_MaCTKM.SelectedValue != null)
            {
                _MaKM = cb_MaCTKM.SelectedValue.ToString();
            }
            KhuyenMai_Pub km_Pub = new KhuyenMai_Pub();
            KhuyenMai_BUL km_BUL = new KhuyenMai_BUL();
            km_Pub.TenKM = tb_TenKM.Text;
            km_Pub.NoiDung = tb_NoiDungKM.Text;
            km_Pub.NgayBatDau = datepicker_NgayBatDau.SelectedDate.Value;
            km_Pub.NgayKetThuc = datepicker_NgayKetThuc.SelectedDate.Value;
            km_Pub.MaKM = _MaKM;

            HeSoKM_Pub hskm1_Pub = new HeSoKM_Pub();
            HeSoKM_Pub hskm2_Pub = new HeSoKM_Pub();
            HeSoKM_Pub hskm3_Pub = new HeSoKM_Pub();
            HeSoKM_Pub hskm4_Pub = new HeSoKM_Pub();

            hskm1_Pub.MaKM = _MaKM;
            hskm2_Pub.MaKM = _MaKM;
            hskm3_Pub.MaKM = _MaKM;
            hskm4_Pub.MaKM = _MaKM;

            hskm1_Pub.TenLoaiKH = lb_LoaiKHMoi.Content.ToString();
            hskm2_Pub.TenLoaiKH = lb_LoaiKHTT.Content.ToString();
            hskm3_Pub.TenLoaiKH = lb_LoaiKHVIP.Content.ToString();
            hskm4_Pub.TenLoaiKH = lb_LoaiKHBT.Content.ToString();

            hskm1_Pub.HeSoKM = float.Parse(tb_LoaiKHMoi.Text);
            hskm2_Pub.HeSoKM = float.Parse(tb_LoaiKHTT.Text);
            hskm3_Pub.HeSoKM = float.Parse(tb_LoaiKHVIP.Text);
            hskm4_Pub.HeSoKM = float.Parse(tb_LoaiKHBT.Text);

            HeSoKM_BUL hskm_BUL = new HeSoKM_BUL();
            hskm_BUL.UpdateHSKM(hskm1_Pub);
            hskm_BUL.UpdateHSKM(hskm2_Pub);
            hskm_BUL.UpdateHSKM(hskm3_Pub);
            hskm_BUL.UpdateHSKM(hskm4_Pub);
            km_BUL.Update(km_Pub);
            MessageBox.Show("Update thành công!");
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

        private void cb_MaCTKM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _MaKM = "";
            if (cb_MaCTKM.SelectedValue != null)
            {
                _MaKM = cb_MaCTKM.SelectedValue.ToString();
            }
            KhuyenMai_BUL kmBUL = new KhuyenMai_BUL();
            KhuyenMai_Pub kmPub = kmBUL.GetKMTheoMaKM(_MaKM);
            tb_TenKM.Text = kmPub.TenKM;
            tb_NoiDungKM.Text = kmPub.NoiDung;
            datepicker_NgayBatDau.SelectedDate = kmPub.NgayBatDau;
            datepicker_NgayKetThuc.SelectedDate = kmPub.NgayKetThuc;

            HeSoKM_BUL HSKM_BUL = new HeSoKM_BUL();
            tb_LoaiKHMoi.Text = HSKM_BUL.GetHSKMTheoMaKMvaLoaiKM(kmPub.MaKM, lb_LoaiKHMoi.Content.ToString()).HeSoKM.ToString();
            tb_LoaiKHTT.Text = HSKM_BUL.GetHSKMTheoMaKMvaLoaiKM(kmPub.MaKM, lb_LoaiKHTT.Content.ToString()).HeSoKM.ToString();
            tb_LoaiKHVIP.Text = HSKM_BUL.GetHSKMTheoMaKMvaLoaiKM(kmPub.MaKM, lb_LoaiKHVIP.Content.ToString()).HeSoKM.ToString();
            tb_LoaiKHBT.Text = HSKM_BUL.GetHSKMTheoMaKMvaLoaiKM(kmPub.MaKM, lb_LoaiKHBT.Content.ToString()).HeSoKM.ToString();
        }
    }
}
