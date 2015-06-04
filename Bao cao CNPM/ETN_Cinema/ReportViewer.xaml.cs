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
using Microsoft.Reporting.WinForms;

using PUBLIC;
using BUL;

namespace ETN_Cinema
{
    /// <summary>
    /// Interaction logic for ReportViewer.xaml
    /// </summary>
    public partial class ReportViewer : Window
    {
        public ReportViewer()
        {
            InitializeComponent();
            PrepareReport();
            _reportViewer.RefreshReport();
        }
        private void PrepareReport()
        {
            ReportDataSource reportDataSource1 = new ReportDataSource();
            RAPCHIEUPHIMDataSet dataset = new RAPCHIEUPHIMDataSet();

            dataset.BeginInit();

            reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.PHIM;
            
            this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this._reportViewer.LocalReport.ReportEmbeddedResource = "ETN_Cinema.Report1.rdlc";
            dataset.EndInit();

            //fill data into adventureWorksDataSet
            //AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter salesOrderDetailTableAdapter = new AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter();
            RAPCHIEUPHIMDataSetTableAdapters.PHIMTableAdapter PhimTableAdapter = new RAPCHIEUPHIMDataSetTableAdapters.PHIMTableAdapter();
            PhimTableAdapter.ClearBeforeFill = true;
            PhimTableAdapter.Fill(dataset.PHIM);

            _reportViewer.RefreshReport();
        }  
    }
}
