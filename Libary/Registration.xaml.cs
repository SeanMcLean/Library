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

namespace Libary
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DBEntities db = new DBEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            mtdAddUser();

            MessageBox.Show("Your details have been Registered. You will be notified when registration is complete.");
            mtdClearUserDetails();

        }

        private void mtdAddUser()
        {
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(GetUserDetails()).State = System.Data.Entity.EntityState.Added;

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
 
        private User GetUserDetails ()
        {
            User tempUser = new User();

            tempUser.UserId = Guid.NewGuid().ToString();
            tempUser.FirstName = tbxFirstName.Text.Trim();
            tempUser.LastName = tbxLastName.Text.Trim();
            tempUser.Address = tbxAddress1.Text.Trim() + tbxAddress2.Text.Trim() + tbxAddress3.Text.Trim();
            tempUser.TelephoneNo = tbxTelephoneNo.Text.Trim();
            tempUser.Email = tbxEmailAddress.Text.Trim();
            tempUser.Password = tbxPassword.Text.Trim();
            tempUser.UserName = tbxUserName.Text.Trim();
            tempUser.AccessLevel = 1;

            return tempUser;

        }

        private void mtdClearUserDetails()
        {
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            tbxUserName.Text = "";
            tbxPassword.Text = "";
            tbxPasswordConfirm.Text = "";
            tbxAddress1.Text = "";
            tbxAddress2.Text = "";
            tbxAddress3.Text = "";
            tbxTelephoneNo.Text = "";
            tbxEmailAddress.Text = "";
        }        
    }
}
