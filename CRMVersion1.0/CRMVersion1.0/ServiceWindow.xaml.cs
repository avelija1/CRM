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

namespace CRMVersion1._0
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private static bool addMode = true;
        private static int idOfServiceToEdit = -1;
        private CRMV1Entities1 _context;

        public ServiceWindow()
        {
            InitializeComponent();
            _context = new CRMV1Entities1();//Opening connection on window initialization, dispose on window_unload!
        }


        private bool CheckIfDataInFieldsAreValid()
        {
            if (ServiceNameTB.Text == "")
            {
                MessageBox.Show("Enter valid service name!");
                return false;
            }
            if (PriceTB.Text == "")
            {
                MessageBox.Show("Enter valid price!");
                return false;
            }
            return true;
        }

        //Save button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfDataInFieldsAreValid())
            {
                if (addMode)
                {
                    AddService();
                    //  MessageBox.Show("User successfully added!");
                }
                else
                {

                    EditService(idOfServiceToEdit);
                    idOfServiceToEdit = -1;
                    SwitchFormMode(true);
                }
                ClearFields();
                UpdateServicesList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateServicesList();
                label2.Content = "Add service";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on window load: " + ex.Message);
            }
        }

        private void SwitchFormMode(bool add)
        {
            if (add)
            {
                label2.Content = "Add service";
                addMode = true;
            }
            else
            {
                label2.Content = "Edit service";
                addMode = false;
            }
        }

        private void EditButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                SwitchFormMode(false);
                var button = (Button)sender;
                int id = Convert.ToInt32(button.CommandParameter);
                try
                {
                    Service serviceToEdit = _context.Services.Where(x => x.Id == id).FirstOrDefault();
                    if (serviceToEdit != null)
                    {
                        ServiceNameTB.Text = serviceToEdit.Name;
                        PriceTB.Text = serviceToEdit.Price.ToString();
                    }
                    idOfServiceToEdit = id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving service data: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit button event error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            ServiceNameTB.Text = "";
            PriceTB.Text = "";
        }

        private void DeleteButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                int id = Convert.ToInt32(button.CommandParameter);
                DeleteService(id);
                UpdateServicesList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in delete button event: " + ex.Message);
            }
        }

        private void UpdateServicesList()
        {
            try
            {
                var query = (from Service in _context.Services orderby Service.Name select new { ServiceName = Service.Name, Price = Service.Price, ID = Service.Id }).ToList();
                dataGrid.ItemsSource = query;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service list update error: " + ex.Message);
            }
        }

        private void AddService()
        {
            try
            {
                long id;
                if (_context.Services.Count() > 0)
                {
                    List<Service> c = _context.Services.ToList();
                    id = c[_context.Services.Count() - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }

                Service newService = new Service
                {
                    Id = id,
                    Name = ServiceNameTB.Text,
                    Price = Convert.ToDecimal(PriceTB.Text)
                };
                _context.Services.Add(newService);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service add error: " + ex.Message);
            }
        }

        private void EditService(int id)
        {
            try
            {
                Service serviceToEdit = _context.Services.Where(x => x.Id == id).FirstOrDefault();
                if (serviceToEdit != null)
                {
                    serviceToEdit.Name = ServiceNameTB.Text;
                    serviceToEdit.Price = Convert.ToDecimal(PriceTB.Text);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service edit error: " + ex.Message);
            }
        }

        private void DeleteService(int id)
        {
            try
            {
                Service serviceToDelete = _context.Services.Where(x => x.Id == id).FirstOrDefault();
                if (serviceToDelete != null)
                {
                    _context.Services.Remove(serviceToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service delete error: " + ex.Message);
            }
        }
        //Cancel button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            SwitchFormMode(true);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _context.Dispose();
        }
    }
}