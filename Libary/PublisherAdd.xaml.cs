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

        public PublisherAdd()
        {
            InitializeComponent();
        }
        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            mtdAddPublisher();
            MessageBox.Show("New Publisher Added");
            mtdClearPublisherDetails();

        }

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

