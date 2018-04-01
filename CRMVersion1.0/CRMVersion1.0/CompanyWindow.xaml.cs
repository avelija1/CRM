using CRMVersion1._0;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        private CRMV1Entities _context;
        private string fileName;
        private byte[] imageInBytes;
        public String CompanyName { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public CompanyWindow()
        {
            InitializeComponent();

            _context = new CRMV1Entities();
            if (_context.Companies.Count()!=0)
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
            DataContext = this;
        }
        //Save- Add or Edit Company details
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Add Company
            if(CheckIfDataInFieldsAreValid())//Validation on form needs to be implemented
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
                            FileName=fileName,
                            Data=imageInBytes
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

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private bool CheckIfDataInFieldsAreValid()
        {
            if (CompanyNameTB.Text == "")
            {
                MessageBox.Show("Enter valid company name!");
                return false;
            }
            if (AdressTB.Text == "")
            {
                MessageBox.Show("Enter valid adress!");
                return false;
            }
            if(TelephoneTB.Text=="")
            {
                MessageBox.Show("Enter valid telephone!!");
                return false;
            }
            if (WebSiteTB.Text == "")
            {
                MessageBox.Show("Enter valid website!!");
                return false;
            }
            return true;
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
        //Select logo button
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false };
            if(ofd.ShowDialog()==true)
            {
                fileName = ofd.FileName;
                image.Source = new BitmapImage(new Uri(fileName));
            }
            imageInBytes = getJPGFromImageControl(image.Source as BitmapImage);
        }
        //Cancel button!
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
