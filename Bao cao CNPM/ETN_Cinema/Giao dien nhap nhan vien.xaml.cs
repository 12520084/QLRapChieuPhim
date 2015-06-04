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
    /// Interaction logic for Giao_dien_nhap_nhan_vien.xaml
    /// </summary>
    public partial class Giao_dien_nhap_nhan_vien : Window
    {
        MyException m_Exception;
        int _index;
        FileStream stream;
        List<ChucVu_Pub> _LchucvuPub = new List<ChucVu_Pub>();
        List<PhongBan_Pub> _LphongbanPub = new List<PhongBan_Pub>();
        List<NhanVien_Pub> _LnhanvienPub = new List<NhanVien_Pub>();
        public Giao_dien_nhap_nhan_vien()
        {
            InitializeComponent();
            m_Exception = new MyException();
            m_Exception.AddDateTimePicker(datePicker_NgaySinh, lb_NgayThangNamSinh);
            m_Exception.AddDateTimePicker(datePicker_NgayVaoLam, lb_NgayVaoLam);
            m_Exception.AddTextBox(tb_TenNhanVien, lb_TenNhanVien);
            m_Exception.AddTextBox(tb_SoDienThoai, lb_SoDienThoai);
            m_Exception.AddTextBox(tb_QueQuan, lb_QueQuan);
            //m_Exception.AddTextBox(tb_PhongBan, lb_PhongBan);
            //m_Exception.AddTextBox(tb_NguoiQuanLy, lb_NguoiQuanLy);
            m_Exception.AddTextBox(tb_Email, lb_Email);
            m_Exception.AddTextBox(tb_DiaChi, lb_DiaChi);
            m_Exception.AddTextBox(tb_CMND, lb_CMND);
            //m_Exception.AddTextBox(tb_ChucVu, lb_ChucVu);
            //m_Exception.AddCheckbox(checkBox_Nam, lb_GioiTinh);
            //m_Exception.AddCheckbox(checkBox_Nu, lb_GioiTinh);
            m_Exception.AddImage(img_AnhNhanVien, lb_AnhNhanVien);
            _index = GetIndex_BUL.GetIndex();

            datePicker_NgaySinh.SelectedDate = DateTime.Now.AddYears(-20);
            datePicker_NgayVaoLam.SelectedDate = DateTime.Now;
            ChucVu_BUL _pchucvuBUL = new ChucVu_BUL();

            _LchucvuPub = _pchucvuBUL.GetCV();
            cmb_ChucVu.ItemsSource = _LchucvuPub;
            cmb_ChucVu.DisplayMemberPath = "TenCV";
            cmb_ChucVu.SelectedValuePath = "MaCV";


            PhongBan_BUL _phongbanBUL = new PhongBan_BUL();

            _LphongbanPub = _phongbanBUL.GetPB();
            cmb_PhongBan.ItemsSource = _LphongbanPub;
            cmb_PhongBan.DisplayMemberPath = "TenPB";
            cmb_PhongBan.SelectedValuePath = "MaPB";

            tb_MaNV.IsEnabled = false;
            tb_MaNV.Text = StaticMethod.GetMaNVFromIndex(_index + 1);
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_Pub _nhanvienPub = new NhanVien_Pub();
            NhanVien_BUL _nhanvieBul = new NhanVien_BUL();
            _nhanvienPub.MaNV = tb_MaNV.Text.ToString();
            _nhanvienPub.HoTen = tb_TenNhanVien.Text.ToString();
            _nhanvienPub.NamSinh = DateTime.Parse(datePicker_NgaySinh.Text);
            if (checkBox_Nam.IsEnabled)
                _nhanvienPub.GioiTinh = true;
            else
                _nhanvienPub.GioiTinh = false;
            _nhanvienPub.DienThoai = tb_SoDienThoai.Text.ToString();
            _nhanvienPub.Email = tb_Email.Text.ToString();
            _nhanvienPub.QueQuan = tb_QueQuan.Text.ToString();
            _nhanvienPub.DiaChi = tb_DiaChi.Text.ToString();
            _nhanvienPub.CMND = tb_CMND.Text.ToString();
            //
            _nhanvienPub.MaCV = cmb_ChucVu.SelectedValue.ToString();
            _nhanvienPub.MaPB = cmb_PhongBan.SelectedValue.ToString();
            _nhanvienPub.NgayVaoLam = DateTime.Parse(datePicker_NgayVaoLam.Text);
            _nhanvienPub.HinhAnh = tb_LinkAnh.Text.ToString();
            //_nhanvienPub.MatKhau = StaticMethod.md5("etncinema");
            _nhanvienPub.MatKhau = "etncinema";
            m_Exception.ShowMessageBox();
            _nhanvieBul.Insert(_nhanvienPub);
            MessageBox.Show("Nhập Thành Công");
            GetIndex_BUL.SetIndex(_index + 1);
            this.Close();
        }

        private void checkBox_Nam_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Nu.IsChecked = false;
        }

        private void checkBox_Nu_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Nam.IsChecked = false;
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
             Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 

            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";

            string filename;

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    filename = dlg.FileName;
                    var uri = new Uri(filename);
                    //save hình
                     stream = new FileStream("../Debug/Image/" + (_index + 1)  + ".png", FileMode.Create);
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    //TextBlock myTextBlock = new TextBlock();
                    //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
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

        private void tb_QueQuan_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmb_ChucVu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_PhongBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
