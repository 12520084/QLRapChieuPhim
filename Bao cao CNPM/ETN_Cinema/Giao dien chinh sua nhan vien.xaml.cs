using BUL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Giao_dien_chinh_sua_nhan_vien.xaml
    /// </summary>
    public partial class Giao_dien_chinh_sua_nhan_vien : Window
    {
        private List<PhongBan_Pub> _LphongbanPub;
        FileStream stream;
        String _pathOld;
        int _index;
        public Giao_dien_chinh_sua_nhan_vien()
        {
            InitializeComponent();

            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();

            _LphongbanPub = _phongbanBUL.GetPB();
            cbb_MaPB.ItemsSource = _LphongbanPub;
            cbb_MaPB.DisplayMemberPath = "TenPB";
            cbb_MaPB.SelectedValuePath = "MaPB";
            cbb_MaPB.SelectedIndex = -1;
            _index = GetIndex_BUL.GetIndex();
            datePicker_NamSinh.SelectedDate = DateTime.Now.AddYears(-20);
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            string filename;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
                var uri = new Uri(filename);
                stream = new FileStream("../Debug/Image/" + (_index + 1) + ".png", FileMode.Create);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Interlace = PngInterlaceOption.On;
                encoder.Frames.Add(BitmapFrame.Create(uri));
                encoder.Save(stream);
                stream.Flush();
                stream.Close();
                filename = stream.Name;
                img_AnhNhanVien.Source = new BitmapImage(new Uri(dlg.FileName.ToString()));
                tb_LinkAnh.Text = (_index + 1).ToString() + ".png";
            }
        }

        private void checkBox_Nam_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox_Nam.IsChecked == true)
                checkBox_Nu.IsChecked = false;
        }

        private void checkBox_Nu_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBox_Nu.IsChecked == true)
                checkBox_Nam.IsChecked = false;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

            NhanVien_Pub _nhanvienPubTemp = new NhanVien_Pub();
            _nhanvienPubTemp = _nhanvienBUL.GetNV(cbb_MaNV.SelectedValue.ToString());
            _pathOld = _nhanvienPubTemp.HinhAnh.ToString();

            VarGlobal.g_NhanVienPub.MaNV = _nhanvienPubTemp.MaNV;
            VarGlobal.g_NhanVienPub.HoTen = tb_TenNhanVien.Text.ToString();
            VarGlobal.g_NhanVienPub.NamSinh = DateTime.Parse(datePicker_NamSinh.Text);
            if (checkBox_Nam.IsChecked == true)
                VarGlobal.g_NhanVienPub.GioiTinh = true;
            else
                VarGlobal.g_NhanVienPub.GioiTinh = false;
            VarGlobal.g_NhanVienPub.DienThoai = tb_SoDienThoai.Text.ToString();
            VarGlobal.g_NhanVienPub.Email = tb_Email.Text.ToString();
            VarGlobal.g_NhanVienPub.QueQuan = tb_QueQuan.Text.ToString();
            VarGlobal.g_NhanVienPub.DiaChi = tb_DiaChi.Text.ToString();
            VarGlobal.g_NhanVienPub.CMND = tb_CMND.Text.ToString();
            VarGlobal.g_NhanVienPub.MaCV = cbb_ChucVu.SelectedValue.ToString();
            VarGlobal.g_NhanVienPub.MaPB = cbb_MaPB_Copy.SelectedValue.ToString();
            VarGlobal.g_NhanVienPub.NgayVaoLam = DateTime.Parse(datePicker_NgayVaoLam.Text);
            VarGlobal.g_NhanVienPub.HinhAnh = tb_LinkAnh.Text;
            VarGlobal.g_NhanVienPub.MatKhau = _nhanvienPubTemp.MatKhau;


            if (VarGlobal.g_NhanVienPub.MaCV == "CV0001")
            {
                _nhanvienBUL.ResetChucVu(cbb_MaPB_Copy.SelectedValue.ToString());
            }


            _nhanvienBUL.Update(VarGlobal.g_NhanVienPub);

            if(_nhanvienPubTemp.HinhAnh != _pathOld)
            GetIndex_BUL.SetIndex(_index + 1);
            MessageBox.Show("Chỉnh Sửa Thành Công - Nhấn OK để tiếp tục");
            this.Close();
        }

        private BitmapImage GetHinhAnhTuPoster(string _Poster)
        {
            BitmapImage bImg = new BitmapImage();
            Stream bm_Stream = new FileStream("../Debug/Image/" + _Poster, FileMode.Open);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(bm_Stream));
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Save(memoryStream);
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
            bImg.EndInit();
            memoryStream.Close();
            bm_Stream.Close();
            return bImg;
        }

        private void cbb_MaPB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string _maPB = null ;
            if (cbb_MaPB.SelectedValue.ToString() != null)
            {
                _maPB = cbb_MaPB.SelectedValue.ToString();

                List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
                NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();

                if (cbb_MaPB.SelectedIndex != 0)
                {
                    _LnhanvienPub = _nhanvienBUL.GetNVTheoPB(_maPB);
                    cbb_MaNV.ItemsSource = _LnhanvienPub;
                }
                else
                {
                    _LnhanvienPub = _nhanvienBUL.GetNVTheoPB("PB0001");
                    cbb_MaNV.ItemsSource = _LnhanvienPub;
                }
                cbb_MaNV.DisplayMemberPath = "HoTen";
                cbb_MaNV.SelectedValuePath = "MaNV";

                if (cbb_MaNV.SelectedIndex == -1)
                {
                    tb_TenNhanVien.Text = "";
                    datePicker_NamSinh.Text = "";

                    tb_SoDienThoai.Text = "";
                    tb_Email.Text = "";
                    tb_QueQuan.Text = "";
                    tb_DiaChi.Text = "";
                    tb_CMND.Text = "";
                    cbb_ChucVu.SelectedIndex = -1;
                    datePicker_NgayVaoLam.Text = "";

                    #region.Reset gioitinh
                    checkBox_Nam.IsChecked = false;
                    checkBox_Nu.IsChecked = false;

                    cbb_MaNV.SelectedIndex = 0;
                }
                
            }
            #endregion
        }

        private void cbb_MaPB_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void cbb_MaNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region.Reset gioitinh
            checkBox_Nam.IsChecked = false;
            checkBox_Nu.IsChecked = false;
            #endregion

            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvienBUL = new NhanVien_BUL();
            
            if(cbb_MaNV.SelectedValue != null)
            {
                this.btn_Submit.IsEnabled = true;
                this.btn_ChonAnh.IsEnabled = true;

                _nhanvienPub = _nhanvienBUL.GetNV(cbb_MaNV.SelectedValue.ToString());

                cbb_MaPB_Copy.ItemsSource = _LphongbanPub;
                cbb_MaPB_Copy.DisplayMemberPath = "TenPB";
                cbb_MaPB_Copy.SelectedValuePath = "MaPB";
                cbb_MaPB_Copy.SelectedValue = cbb_MaPB.SelectedValue;

                _pathOld = _nhanvienPub.HinhAnh;
                tb_LinkAnh.Text = _pathOld;
                #region.Fill data into textbox
                tb_TenNhanVien.Text = _nhanvienPub.HoTen;
                datePicker_NamSinh.Text = _nhanvienPub.NamSinh.ToShortDateString();
                if (_nhanvienPub.GioiTinh)
                    checkBox_Nam.IsChecked = true;
                else
                    checkBox_Nu.IsChecked = true;
                tb_SoDienThoai.Text = _nhanvienPub.DienThoai;
                tb_Email.Text = _nhanvienPub.Email;
                tb_QueQuan.Text = _nhanvienPub.QueQuan;
                tb_DiaChi.Text = _nhanvienPub.DiaChi;
                tb_CMND.Text = _nhanvienPub.CMND;

                NhanVien_BUL _pnhanvienBUL1 = new NhanVien_BUL();
                NhanVien_Pub _nhanvienPubSwap = new NhanVien_Pub();

                datePicker_NgayVaoLam.Text = _nhanvienPub.NgayVaoLam.ToShortDateString();
                img_AnhNhanVien.Source = GetHinhAnhTuPoster(_nhanvienPub.HinhAnh);

                List<ChucVu_Pub> _LchucvuPub = new List<ChucVu_Pub>();
                ChucVu_BUL _pchucvuBUL = new ChucVu_BUL();

                _LchucvuPub = _pchucvuBUL.GetCV();
                cbb_ChucVu.ItemsSource = _LchucvuPub;
                cbb_ChucVu.DisplayMemberPath = "TenCV";
                cbb_ChucVu.SelectedValuePath = "MaCV";
                cbb_ChucVu.SelectedValue = _nhanvienPub.MaCV;
                #endregion
            }
        }

        private void cbb_ChucVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteNV(object sender, RoutedEventArgs e)
        {
            if (cbb_MaNV.SelectedIndex != -1)
            {
                if (VarGlobal.g_NhanVienPub.MaNV != cbb_MaNV.SelectedValue.ToString())
                {
                                    NhanVien_BUL _nhanvien = new NhanVien_BUL();
                _nhanvien.Delete(cbb_MaNV.SelectedValue.ToString());
                MessageBox.Show("Xóa Thành Công - Nhấn OK để tiếp tục");
                tb_TenNhanVien.Text = "";
                datePicker_NamSinh.Text = "";

                tb_SoDienThoai.Text = "";
                tb_Email.Text = "";
                tb_QueQuan.Text = "";
                tb_DiaChi.Text = "";
                tb_CMND.Text = "";
                cbb_ChucVu.SelectedIndex = -1;
                datePicker_NgayVaoLam.Text = "";
                checkBox_Nam.IsChecked = false;
                checkBox_Nu.IsChecked = false;
                cbb_MaNV.SelectedIndex = cbb_MaNV.SelectedIndex - 1;
                }
                else
                {
                    MessageBox.Show("Không Thể Xóa Chính Mình - Nhấn OK để tiếp tục");
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Nhân Viên - Nhấn OK để tiếp tục");
            }
        }
    }
}