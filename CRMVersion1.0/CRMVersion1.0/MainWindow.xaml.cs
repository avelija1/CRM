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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRMVersion1._0
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
        //My Company button 
        private void button_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customers = new CustomerWindow();
            customers.Show();
        }
        //Customers button
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CompanyWindow company = new CompanyWindow();
            company.Show();
        }
        //Services button
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow services = new ServiceWindow();
            services.Show();
        }
        //Invoices button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InvoiceWindow invoices = new InvoiceWindow();
            invoices.Show();
        }
    }
}
