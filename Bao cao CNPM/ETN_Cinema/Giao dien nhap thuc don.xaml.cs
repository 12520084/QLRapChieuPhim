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
    /// Interaction logic for Giao_dien_nhap_thuc_don.xaml
    /// </summary>
    public partial class Giao_dien_nhap_thuc_don : Window
    {
        string filename;

        public Giao_dien_nhap_thuc_don()
        {
            InitializeComponent();
        }
        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            ThucDon_Pub _thucdonPub = new ThucDon_Pub();
            ThucDon_BUL _thucdonBul = new ThucDon_BUL();

            _thucdonPub.MaTD = "001";
            _thucdonPub.TenTD = (tb_TenThucDon.Text).ToString();
            _thucdonPub.Gia = float.Parse(tb_DonGia.Text);
            //_thucdonPub.HinhAnh = "Hehe";

            _thucdonBul.Insert(_thucdonPub);
        }

        private void btn_ChonAnh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                tb_LinkAnh.Text = filename;
                var uri = new Uri(filename);
                img_HinhMinhHoa.Source = new BitmapImage(uri);
            }
        }
    }
}
