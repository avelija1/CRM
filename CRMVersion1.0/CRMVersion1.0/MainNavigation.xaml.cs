using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainNavigation.xaml
    /// </summary>
    public partial class MainNavigation : Window
    {

        private static bool addMode = true;
        private static int idOfCustomerToEdit = -1;//auxiliary variable
        private CRMV1Entities1 _context;
        private string fileName;
        private byte[] imageInBytes;
  

        public MainNavigation()
        {
            InitializeComponent();
            _context = new CRMV1Entities1();//Open connection on windows initialization and dispose on window_unloaded even
            if (_context.Companies.Count() != 0)
            {
                Company myCompany = _context.Companies.First();
                CompanyNameTB.Text = myCompany.Name;
                AdressTB.Text = myCompany.Adress;
                TelephoneTB.Text = myCompany.Telefon;
                WebSiteTB.Text = myCompany.Website;
                image.Source = new BitmapImage(new Uri(myCompany.FileName));
                fileName = myCompany.FileName;
                imageInBytes = myCompany.Data;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateCustomersList();
                label2.Content = "Add customer";
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
                label2.Content = "Add customer";
                addMode = true;
            }
            else
            {
                label2.Content = "Edit customer";
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
                    Customer customerToEdit = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
                    if (customerToEdit != null)
                    {
                        FirstNameTB.Text = customerToEdit.FirstName;
                        LastNameTB.Text = customerToEdit.LastName;
                    }
                    idOfCustomerToEdit = id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving customer data: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit button event error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            FirstNameTB.Text = "";
            LastNameTB.Text = "";
        }

        private void DeleteButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = (Button)sender;
                int id = Convert.ToInt32(button.CommandParameter);
                DeleteCustomer(id);
                UpdateCustomersList();
                // MessageBox.Show("User successfully deleted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in delete button event: " + ex.Message);
            }
        }

        private void UpdateCustomersList()
        {
            try
            {
                var query = (from Customer in _context.Customers orderby Customer.FirstName select new { FirstName = Customer.FirstName, LastName = Customer.LastName, ID = Customer.Id }).ToList();
                dataGrid.ItemsSource = query;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer list update error: " + ex.Message);
            }
        }

        private void AddCustomer()
        {
            try
            {
                long id;
                //Specifying id manualy because sqlite has problem with autoincrement
                if (_context.Customers.Count() > 0)
                {
                    List<Customer> c = _context.Customers.ToList();
                    id = c[_context.Customers.Count() - 1].Id + 1;
                }
                else
                {
                    id = 1;
                }
                Customer newCustomer = new Customer
                {
                    Id = id,
                    FirstName = FirstNameTB.Text,
                    LastName = LastNameTB.Text

                };
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer add error: " + ex.Message);
            }
        }

        private void EditCustomer(int id)
        {
            try
            {
                Customer customerToEdit = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
                if (customerToEdit != null)
                {
                    customerToEdit.FirstName = FirstNameTB.Text;
                    customerToEdit.LastName = LastNameTB.Text;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer edit error: " + ex.Message);
            }
        }

        private void DeleteCustomer(int id)
        {
            try
            {
                Customer customerToDelete = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
                if (customerToDelete != null)
                {
                    _context.Customers.Remove(customerToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer delete error: " + ex.Message);
            }
        }

        //Save button, that add or edit customer based on addMode variable!
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfDataInFieldsAreValid())
            {
                if (addMode)
                {
                    AddCustomer();
                }
                else
                {

                    EditCustomer(idOfCustomerToEdit);
                    idOfCustomerToEdit = -1;
                    SwitchFormMode(true);
                }
                ClearFields();
                UpdateCustomersList();
            }
        }

        private bool CheckIfDataInFieldsAreValid()
        {
            if (FirstNameTB.Text == "")
            {
                MessageBox.Show("Enter valid first name!");
                return false;
            }
            if (LastNameTB.Text == "")
            {
                MessageBox.Show("Enter valid last name!");
                return false;
            }
            return true;
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




        //------------------------------------------------------------------Customer Screen--------------------------------------------------------

   

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false };
            if (ofd.ShowDialog() == true)
            {
                fileName = ofd.FileName;
                image.Source = new BitmapImage(new Uri(fileName));
            }
            imageInBytes = getJPGFromImageControl(image.Source as BitmapImage);
        }

        private byte[] getJPGFromImageControl(BitmapImage bitmapImage)
        {
            throw new NotImplementedException();
        }

        private void btnSaveComp_Click(object sender, RoutedEventArgs e)
        {
            //Add Company
            if (CheckIfDataInFieldsAreValid())//Validation on form needs to be implemented
            {
                if (_context.Companies.Count() == 0)
                {
                    try
                    {
                        Company newCompany = new Company
                        {
                            Name = CompanyNameTB.Text,
                            Adress = AdressTB.Text,
                            Telefon = TelephoneTB.Text,
                            Website = WebSiteTB.Text,
                            FileName = fileName,
                            Data = imageInBytes
                        };
                        _context.Companies.Add(newCompany);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company add error: " + ex.Message);
                    }
                }//Edit Company
                else
                {
                    try
                    {
                        Company existingCompany = _context.Companies.FirstOrDefault();
                        if (existingCompany != null)
                        {
                            existingCompany.Name = CompanyNameTB.Text;
                            existingCompany.Adress = AdressTB.Text;
                            existingCompany.Telefon = TelephoneTB.Text;
                            existingCompany.Website = WebSiteTB.Text;
                            existingCompany.FileName = fileName;
                            existingCompany.Data = imageInBytes;
                        }
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Company edit error: " + ex.Message);
                    }
                }
            }
        }
    }
}
