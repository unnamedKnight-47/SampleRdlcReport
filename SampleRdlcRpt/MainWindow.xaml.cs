using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Reporting.WinForms;


namespace SampleRdlcRpt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Sale
        {
            public int SaleId { get; set; }
            public string ProductName { get; set; }
            public int QuantitySold { get; set; }
            public decimal UnitPrice { get; set; }
            public DateTime SaleDate { get; set; }
        }

        public List<Sale> GetSales()
        {
            return new List<Sale>
            {
                new Sale { SaleId = 1, ProductName = "Laptop", QuantitySold = 2, UnitPrice = 75000, SaleDate = new DateTime(2025, 6, 10) },
                new Sale { SaleId = 2, ProductName = "Mouse", QuantitySold = 10, UnitPrice = 500, SaleDate = new DateTime(2025, 6, 15) },
                new Sale { SaleId = 3, ProductName = "Laptop", QuantitySold = 1, UnitPrice = 75000, SaleDate = new DateTime(2025, 6, 20) },
                new Sale { SaleId = 4, ProductName = "Keyboard", QuantitySold = 3, UnitPrice = 2000, SaleDate = new DateTime(2025, 6, 25) },
                new Sale { SaleId = 5, ProductName = "Mouse", QuantitySold = 5, UnitPrice = 500, SaleDate = new DateTime(2025, 7, 1) }
            };
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string reportPath = @"D:\Report\SampleRdlcRpt\SampleRdlcRpt\Report1.rdlc";
            report.ProcessingMode = ProcessingMode.Local;
            report.LocalReport.ReportPath = reportPath;
            List<Sale> v1 = GetSales();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", v1);

            report.LocalReport.SetParameters(new ReportParameter("rptParval3", "Moon"));

            report.LocalReport.DataSources.Add(reportDataSource);
            report.RefreshReport();

            report.SetDisplayMode(DisplayMode.PrintLayout);
            report.ZoomMode = ZoomMode.Percent;
            report.ZoomPercent = 100;

        }
    }
}
