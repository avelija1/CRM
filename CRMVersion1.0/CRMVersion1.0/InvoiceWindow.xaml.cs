using Microsoft.Windows.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int quantity;
        public static int idOfDatagridItemToEdit = -1;
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DataTable dt { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public InvoiceWindow()
        {
            InitializeComponent();
            SwitchMode();
            CustomerTB.Text = "Almedin";
            using (CRMV1Entities _context = new CRMV1Entities())
            {
                Services = new List<Service>();
                Services.Add(new Service());
                InvoiceDate = DateTime.Now;
                foreach (var service in _context.Services)
                {
                    Services.Add(service);
                }
                long id;
                if (_context.Services.Count() > 0)
                {
                    List<Invoice> c = _context.Invoices.ToList();
                    id = c[_context.Invoices.Count() - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }
                InvoiceNoTB.Text = id.ToString();
            }
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

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                if (PriceTB.Text != "")
                {
                    TotalTB.Text = (Convert.ToDecimal(PriceTB.Text) * quantity).ToString();
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex != -1 && comboBox.SelectedIndex!=0)
            {
                Service s = (Service)comboBox.SelectedItem;
                PriceTB.Text = s.Price.ToString();
                QuantityTB.Text = "1";
                TotalTB.Text = PriceTB.Text;
            }
            else
            {
                PriceTB.Text = "";
                QuantityTB.Text = "0";
                TotalTB.Text = "";
            }
        }

        //Add item button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (FieldAreValid())
            {
                ServiceItem si = new ServiceItem();
                si.Id = Convert.ToInt32(((Service)ServiceNameCB.SelectedItem).Id);
                si.LineNumber = dataGrid.Items.Count;
                si.ServiceName = ServiceNameCB.Text;
                si.Price = Convert.ToDecimal(PriceTB.Text);
                si.Quantity = Convert.ToInt32(QuantityTB.Text);
                si.Total = TotalTB.Text;
                dt.Rows.Add(si.LineNumber, si.Id, si.ServiceName, si.Price, si.Quantity, si.Total);
                dataGrid.ItemsSource = dt.DefaultView;
                ClearFields();
            }
        }

        private bool FieldAreValid()
        {
            if(ServiceNameCB.SelectedIndex==0 || ServiceNameCB.SelectedIndex==-1)
            {
                ServiceNameCB.SelectedIndex = -1;
                return false;
            }
            if(QuantityTB.Text=="")
            {
                QuantityTB.Text = "";
                return false;
            }

            return true;
        }

        private void QuantityTB_TextChanged(object sender, TextChangedEventArgs e)
        {
        
           try
            {
                Convert.ToInt32(QuantityTB.Text);
            }
            catch
            {
                TotalTB.Text = "";
            }
        }
        
        //Note: it is not fully implemented, I will implement it soon!
        //Save  button - saves invoice
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // DataTable dt = ((DataView)dataGrid.ItemsSource).ToTable();
            //using (CRMV1Entities _context = new CRMV1Entities())
            //{
            //    long id;
            //    if (_context.Items.Count() > 0)
            //    {
            //        List<Item> c = _context.Items.ToList();
            //        id = c[_context.Items.Count() - 1].Id + 1;
            //    }
            //    else
            //    {
            //        id = 1;
            //    }
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        int serviceId = Convert.ToInt32(row["Id"].ToString());
            //        int quantity = Convert.ToInt32(row["Quantity"].ToString());
            //        decimal total = Convert.ToDecimal(row["Total"].ToString());
            //        Item i = new Item() { Id=id,ServiceID = serviceId, InvoiceID = 2, Quantity = quantity, Total = total };
            //        _context.Items.Add(i);
            //        id++;
            //    }
            //    _context.SaveChanges();
            //}
        }



        private void EditButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                int id = Convert.ToInt32(button.CommandParameter);
                if (id != 0)//Case when we do not have any data in row
                {
                    SwitchMode(false);
                    idOfDatagridItemToEdit = id;
                    foreach (DataRow row in dt.Rows)
                    {
                        int serviceId = Convert.ToInt32(row["Id"].ToString());
                        if (serviceId == id)
                        {
                            ServiceNameCB.SelectedValue = id;
                            QuantityTB.Text = row["Quantity"].ToString();
                            TotalTB.Text = row["Total"].ToString();
                            PriceTB.Text = row["Price"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in delete button event: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            ServiceNameCB.SelectedIndex = 0;
            PriceTB.Text = "";
            QuantityTB.Text = "0";
            TotalTB.Text = "";
        }

        private void DeleteButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                int id = Convert.ToInt32(button.CommandParameter);

                if (id != 0)//Case when we do not have any data in row
                {
                    int indexToRemove = -1;
                    foreach (DataRow row in dt.Rows)
                    {
                        int serviceId = Convert.ToInt32(row["Id"].ToString());
                        if (serviceId == id)
                        {
                            indexToRemove = Convert.ToInt32(row["LineNumber"].ToString());
                        }
                    }
                    dt.Rows.RemoveAt(indexToRemove - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in delete button event: " + ex.Message);
            }
        }

        private void SaveItemChangesButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                int serviceId = Convert.ToInt32(row["Id"].ToString());
                if (serviceId == idOfDatagridItemToEdit)
                {
                    row["ServiceName"] = ServiceNameCB.Text.ToString();
                    row["Quantity"]=QuantityTB.Text;
                    row["Total"]=TotalTB.Text;
                    row["Price"]=PriceTB.Text;
                }
            }
            ClearFields();
            SwitchMode();
        }
        public void SwitchMode(bool addItemMode = true)
        {
            if (addItemMode)
            {
                AddItemButton.Visibility = System.Windows.Visibility.Visible;
                CancelEditButton.Visibility = System.Windows.Visibility.Hidden;
                SaveItemChangesButton.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                AddItemButton.Visibility = System.Windows.Visibility.Hidden;
                CancelEditButton.Visibility = System.Windows.Visibility.Visible;
                SaveItemChangesButton.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void CancelEditButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            SwitchMode();
        }

    }
}
