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

namespace Libary
{
    /// <summary>
    /// Interaction logic for PublisherAdd.xaml
    /// </summary>
    public partial class PublisherAdd : Page
    {
        DBEntities db = new DBEntities();
        int parsedValue;

        public PublisherAdd()
        {
            InitializeComponent();
        }

        //click event to add publisher
        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            //check if the textboxes are empty 
            if (!string.IsNullOrWhiteSpace(txtName.Text)
            & !string.IsNullOrWhiteSpace(txtAddress1.Text)
            & !string.IsNullOrWhiteSpace(txtAddress2.Text)
            & !string.IsNullOrWhiteSpace(txtAddress3.Text)
            & !string.IsNullOrWhiteSpace(txtEmail.Text)
            &int.TryParse(txtTelephone.Text, out parsedValue))
            {
                //call methods to add Publisher 
                mtdAddPublisher();
                //Inform user that details have been added 
                MessageBox.Show("New Publisher Added");
                //clear old textbox data
                mtdClearPublisherDetails();

            }
            //check to see if  Name text box is empty
            else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Missing First Name");
            }
            //check to see if Address text box is empty
            else if (string.IsNullOrWhiteSpace(txtAddress1.Text))
            {
                MessageBox.Show("Missing Address Line1 Name");
            }
            //check to see if Address text box is empty
            else if (string.IsNullOrWhiteSpace(txtAddress2.Text))
            {
                MessageBox.Show("Missing Address Line2 Name");
            }
            //check to see if Address text box is empty
            else if (string.IsNullOrWhiteSpace(txtAddress3.Text))
            {
                MessageBox.Show("Missing Address Line3 Name");
            }
            //check to see if Email text box is empty
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Missing Email Name");
            }
            //check to see if Telephone text box is empty
            else if (!int.TryParse(txtTelephone.Text, out parsedValue))
            {
                MessageBox.Show("Invlid Telephone No");
            }

        }
        //mehtod to add publisher to database
        private void mtdAddPublisher()
        {
            try
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(GetUserDetails()).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Details");
            }
        }

        //method to retrieve publisher details from data inputs
        private Publisher GetUserDetails()
        {
            Publisher tempPublisher = new Publisher();

            tempPublisher.PublisherId = Guid.NewGuid().ToString();
            tempPublisher.Name = txtName.Text.Trim();
            tempPublisher.TelephoneNo = int.Parse(txtTelephone.Text);
            tempPublisher.Email = txtEmail.Text.Trim();
            tempPublisher.Address = txtAddress1.Text.Trim() + " " + txtAddress2.Text.Trim() + " " + txtAddress3.Text.Trim();

            return tempPublisher;
        }

        //method to clear publisher details from inputs 
        private void mtdClearPublisherDetails()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtTelephone.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
        }
    }
}

