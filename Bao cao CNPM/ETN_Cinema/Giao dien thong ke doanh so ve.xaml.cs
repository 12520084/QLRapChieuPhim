using Microsoft.Reporting.WinForms;
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
    public partial class Giao_dien_thong_ke_doanh_so_ve : Window
    {
        float m_TongDoanhSo;
        List<VeBan_Pub> LvebanPUB;
        public Giao_dien_thong_ke_doanh_so_ve()
        {
            InitializeComponent();
            DeleteTable();
            CreateListThongKe();
            PrepareReport();
            _reportViewer.RefreshReport();
        }

        public void CreateListThongKe()
        {
            LvebanPUB = new List<VeBan_Pub>();

            List<Phim_Pub> List_Phim = new List<Phim_Pub>();
            List<string> List_LoaiSC = new List<string>();

            Phim_BUL phim_BUL = new Phim_BUL();
            SuatChieu_BUL SuatChieu_BUL = new SuatChieu_BUL();
            m_TongDoanhSo = 0;
            List_Phim = phim_BUL.GetMaPhim();
            List_LoaiSC = SuatChieu_BUL.GetLoaiSC();
            for (int i = 0; i < List_Phim.Count; i++)
            {
                for (int j = 0; j < List_LoaiSC.Count; j++)
                {
                    List<VeBan_Pub> temp = new List<VeBan_Pub>();
                    VeBan_BUL veban_BUL = new VeBan_BUL();
                    temp = veban_BUL.GetVeTuLoaiSCvaTenPhim(List_LoaiSC[j], List_Phim[i].TenPhim);

                    DoanhSoBanVe_Pub doanhsobanve_PUB = new DoanhSoBanVe_Pub();
                    DoanhSoBanVe_BUL doanhsobanve_BUL = new DoanhSoBanVe_BUL();

                    float m_DoanhSo = 0;
                    int m_SoLuong = 0;
                    for (int k = 0; k < temp.Count; k++)
                    {
                        LvebanPUB.Add(temp[k]);
                        ++m_SoLuong;
                        m_DoanhSo += temp[k].GiaVe;
                        m_TongDoanhSo += temp[k].GiaVe;
                    }

                    doanhsobanve_PUB.TenPhim = List_Phim[i].TenPhim;
                    doanhsobanve_PUB.LoaiSC = List_LoaiSC[j];
                    doanhsobanve_PUB.SoLuong = m_SoLuong;
                    doanhsobanve_PUB.DoanhSo = m_DoanhSo;

                    doanhsobanve_BUL.Insert(doanhsobanve_PUB);
                }
            }
        }

        public void DeleteTable()
        {
            //xóa cái doanh số cũ đi để lấy cái mới về(nhớ gán index = 1)
            DoanhSoBanVe_BUL doanhsobanve_BUL = new DoanhSoBanVe_BUL();
            doanhsobanve_BUL.DeleteTable();
        }
        List<ReportParameter> Lparameter;
        private void PrepareReport()
        {
            ReportDataSource reportDataSource1 = new ReportDataSource();
            RAPCHIEUPHIMDataSetDoanhSo dataset = new RAPCHIEUPHIMDataSetDoanhSo();

            dataset.BeginInit();

            reportDataSource1.Name = "DataSetDoanhSo"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.DOANHSOBANVE;

            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "ETN_Cinema.ReportDoanhSo.rdlc";
            Lparameter = new List<ReportParameter>();
            Lparameter.Add(new ReportParameter("TongDoanhSo", StaticMethod.DanhDauChamChoTien(m_TongDoanhSo)));
            Lparameter.Add(new ReportParameter("NgayLap", DateTime.Now.Date.ToShortDateString()));
            this._reportViewer.LocalReport.SetParameters(Lparameter);
            dataset.EndInit();

            //fill data into adventureWorksDataSet
            RAPCHIEUPHIMDataSetDoanhSoTableAdapters.DOANHSOBANVETableAdapter DoanhsoAdapters = new RAPCHIEUPHIMDataSetDoanhSoTableAdapters.DOANHSOBANVETableAdapter();
            DoanhsoAdapters.ClearBeforeFill = true;
            DoanhsoAdapters.Fill(dataset.DOANHSOBANVE);

            _reportViewer.RefreshReport();
        } 
    }
}
