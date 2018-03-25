using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CRMVersion1._0
{
    /// <summary>
    /// Interaction logic for InvoiceReport.xaml
    /// </summary>
    public partial class InvoiceReport : Window
    {
        public string companyName { get; set; }
        public string adress { get; set; }
        public string telefon { get; set; }
        public string website { get; set; }
        public byte[] logo { get; set; }

        public InvoiceReport(DataTable dt)
        {
            InitializeComponent();
            using (CRMV1Entities _context = new CRMV1Entities())
            {
                Company myCompany = _context.Companies.First();
                if (myCompany != null)
                {
                    companyName = myCompany.Name;
                    adress = myCompany.Adress;
                    telefon = myCompany.Telefon;
                    website = myCompany.Website;
                    logo = myCompany.Data;
                }
            }

            ReportDataSource reportDataSource = new ReportDataSource("CRMVersion1._0", dt);

            reportDataSource.Name = "DataSet1"; // Name of the DataSet we set in .rdlc

            reportDataSource.Value = dt;

            reportViewer.LocalReport.ReportPath = "C:/Users/840/Documents/Visual Studio 2015/Projects/CRMVersion1.0/CRMVersion1.0/InvoiceReport.rdlc";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("CompanyName",companyName, true));
            paramList.Add(new ReportParameter("Adress", adress, true));
            paramList.Add(new ReportParameter("Telefon", telefon, true));
            paramList.Add(new ReportParameter("Website", website, true));

            reportViewer.LocalReport.SetParameters(paramList);

            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            reportViewer.RefreshReport();
        }
    }
}
