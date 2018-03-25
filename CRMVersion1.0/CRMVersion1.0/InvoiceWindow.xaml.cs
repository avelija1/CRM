﻿using Microsoft.Windows.Controls.Primitives;
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
            CRMV1Entities2 _contex = new CRMV1Entities2();
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
          DataTable dt = ((DataView)dataGrid.ItemsSource).ToTable();
            foreach (DataRow row in dt.Rows)
            {
                string serviceId=  row["Id"].ToString();
                string quantity = row["ServiceName"].ToString();
                string total = row["Total"].ToString();
                MessageBox.Show(serviceId + quantity + total);
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