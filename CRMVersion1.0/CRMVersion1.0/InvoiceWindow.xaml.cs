using Microsoft.Windows.Controls.Primitives;
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
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public List<Service> Services { get; set; }
        public
            DataTable dt
        { get; set; }
        public InvoiceWindow()
        {
            InitializeComponent();
            CRMV1Entities _contex = new CRMV1Entities();
            Services = _contex.Services.ToList();
            DataContext = this;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("LineNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("ServiceName", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Total", typeof(string)));
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            Service s = (Service)comboBox.SelectedItem;
            PriceTB.Text = s.Price.ToString();
            QuantityTB.Text = "1";
            TotalTB.Text = PriceTB.Text;
        }

        //Add button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ServiceItem si = new ServiceItem();
            si.Id = Convert.ToInt32(((Service)ServiceNameCB.SelectedItem).Id);
            si.LineNumber = dataGrid.Items.Count;
            si.ServiceName = ServiceNameCB.Text;
            si.Price = Convert.ToDecimal(PriceTB.Text);
            si.Quantity = Convert.ToInt32(QuantityTB.Text);
            si.Total = TotalTB.Text;
            dt.Rows.Add(si.LineNumber,si.Id,si.ServiceName,si.Price,si.Quantity,si.Total);
            dataGrid.ItemsSource = dt.DefaultView;
        }


        private void QuantityTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (QuantityTB.Text != "")
            {
                TotalTB.Text = (Convert.ToDecimal(PriceTB.Text) * Convert.ToInt32(QuantityTB.Text)).ToString();
            }
        }
        //Save button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
          DataTable dt = ((DataView)dataGrid.ItemsSource).ToTable();
            using (CRMV1Entities _context = new CRMV1Entities())
            {
                long id;
                if (_context.Items.Count() > 0)
                {
                    List<Item> c = _context.Items.ToList();
                    id = c[_context.Items.Count() - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }
                foreach (DataRow row in dt.Rows)
                {
                    int serviceId = Convert.ToInt32(row["Id"].ToString());
                    int quantity = Convert.ToInt32(row["Quantity"].ToString());
                    decimal total = Convert.ToDecimal(row["Total"].ToString());
                    Item i = new Item() { Id=id,ServiceID = serviceId, InvoiceID = 2, Quantity = quantity, Total = total };
                    _context.Items.Add(i);
                    id++;
                }
                _context.SaveChanges();
            }
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public static DataGridCell GetCell(DataGrid grid, int column, int rowN)
        {
            DataGridRow row = grid.ItemContainerGenerator.ContainerFromIndex(rowN) as DataGridRow;

            if (row != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

                if (presenter == null)
                {
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(row);
                }

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }
    }
}
