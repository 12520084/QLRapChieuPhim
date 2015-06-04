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
using PUBLIC;
using BUL;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for Giao_dien_tinh_gia_ve.xaml
    /// </summary>

    public class SelectableThing
    {

        public bool IsSelected
        {
            get;
            set;
        }

        public string Description
        {
            get { return m_KmPUB.NoiDung; }
        }

        private KhuyenMai_Pub m_KmPUB;

        public KhuyenMai_Pub KmPUB
        {
            get { return m_KmPUB; }
            set { m_KmPUB = value; }
        }

        public SelectableThing(KhuyenMai_Pub _Input)
        {
            m_KmPUB = new KhuyenMai_Pub();
            m_KmPUB.MaKM = _Input.MaKM;
            m_KmPUB.NgayBatDau = _Input.NgayBatDau;
            m_KmPUB.NgayKetThuc = _Input.NgayKetThuc;
            m_KmPUB.NoiDung = _Input.NoiDung;
            m_KmPUB.TenKM = _Input.TenKM;
        }
    }

    public partial class Giao_dien_tinh_gia_ve : Window
    {
        List<SelectableThing> Lkm;
        public Giao_dien_tinh_gia_ve()
        {
            InitializeComponent();
            Lkm = new List<SelectableThing>();
            KhuyenMai_BUL km_bul = new KhuyenMai_BUL();
            List<KhuyenMai_Pub> tempList = km_bul.GetKM();
            for (int i = 0; i < tempList.Count; i++)
            {
                Lkm.Add(new SelectableThing(tempList[i]));
            }
            CheckBoxes.ItemsSource = Lkm;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            string loaiKH;
            float f_HeSoUuDai = 0;
            List<float> LHeSoKM = new List<float>();
            List<string> LMaKM = new List<string>();

            for (int i = 0; i < Lkm.Count; i++)
            {
                if (Lkm[i].IsSelected)
                {
                    LMaKM.Add(Lkm[i].KmPUB.MaKM);
                }
            }

            KhachHang_BUL kh_bul = new KhachHang_BUL();
            if (tb_MaKH.Text != "")
            {
                loaiKH = kh_bul.GetKHTuMaKH(tb_MaKH.Text).MaLoaiKH; 
            }
            else
            {
                loaiKH = "Khách Hàng Bình Thường";
            }
            f_HeSoUuDai = kh_bul.GetHeSoUuDaiTuTenLoaiKH(loaiKH);
            for (int i = 0; i < LMaKM.Count; i++)
            {
                LHeSoKM.Add(kh_bul.GetHeSoKMTuMaKMVaLoaiKH(LMaKM[i], loaiKH));
            }
            float Final_Giave = 0;

            for (int i = 0; i < VarGlobal.g_LVeBanPub.Count; i++)
            {
                VarGlobal.g_LVeBanPub[i].GiaVe *= f_HeSoUuDai;
                VarGlobal.g_LVeBanPub[i].MaKH = tb_MaKH.Text;
            }

            for (int i = 0; i < VarGlobal.g_LVeBanPub.Count; i++)
            {
                for (int j = 0; j < LHeSoKM.Count; j++)
                {
                    VarGlobal.g_LVeBanPub[i].GiaVe *= LHeSoKM[j];
                }
            }
            VeBan_BUL vb_BUL = new VeBan_BUL();
            for (int i = 0; i < VarGlobal.g_LVeBanPub.Count; i++)
            {
                Final_Giave += VarGlobal.g_LVeBanPub[i].GiaVe;
                vb_BUL.Insert(VarGlobal.g_LVeBanPub[i]);
            }

            lb_XuatTongTien.Content = Danhdaucham(Final_Giave.ToString()) + " VND";
            MessageBox.Show("Nhập vé bán thành công. Bấm OK để thoát");
            this.Close();
        }

        private string Danhdaucham(string _Input)
        {
            string result1 = "";
            string result2 = "";
            int count = 0;
            for (int i = _Input.Length - 1; i >= 0; --i)
            {
                if ((count + 1) % 4 == 0)
                {
                    result1 += ".";
                    result1 += _Input[i];
                    count += 2;
                }
                else
                {
                    result1 += _Input[i];
                    ++count;
                }
            }
            for (int i = result1.Length - 1; i >= 0; --i)
            {
                result2 += result1[i];
            }
            return result2;
        }

        private void btn_CheckKH_Click(object sender, RoutedEventArgs e)
        {
            KhachHang_BUL kh_bul = new KhachHang_BUL();
            KhachHang_Pub kh_pub = kh_bul.GetKHTuMaKH(tb_MaKH.Text);
            if (kh_pub.MaKH == null)
            {
                lb_Exist.Content = " Mã Khách Hàng chưa đăng ký!";
                lb_Exist.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
            {
                lb_Exist.Content = "Mã Khách hàng tồn tại";
                lb_Exist.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
        }
    }
}
