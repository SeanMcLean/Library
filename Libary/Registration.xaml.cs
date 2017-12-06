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
        int parsedValue;
        string blankTextBox = "";

        public Registration()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            MainWindow win = new MainWindow();
            this.Hide();
            win.Show();
            Close();
        }
 
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //check to see if passwords match
            if (passwordBox.Password == passwordBoxConfirm.Password)
            {
                if (int.TryParse(tbxTelephoneNo.Text, out parsedValue))
                {
                    if (!string.IsNullOrWhiteSpace(tbxFirstName.Text)
                    & !string.IsNullOrWhiteSpace(tbxLastName.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress1.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress2.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress3.Text)
                    & !string.IsNullOrWhiteSpace(tbxEmailAddress.Text)
                    & !string.IsNullOrWhiteSpace(tbxUserName.Text))
                    {
                        mtdAddUser();
                        MessageBox.Show("Your details have been Registered. You will be notified when registration is complete.");
                        mtdClearUserDetails();
                    }

                    //check to see if text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxFirstName.Text))
                    {
                        MessageBox.Show("Missing First Name");
                    }
                    else if (string.IsNullOrWhiteSpace(tbxLastName.Text))
                    {
                        MessageBox.Show("Missing Last Name");
                    }
                    else if (string.IsNullOrWhiteSpace(tbxAddress1.Text))
                    {
                        MessageBox.Show("Missing Address Line1 Name");
                    }
                    else if (string.IsNullOrWhiteSpace(tbxAddress2.Text))
                    {
                        MessageBox.Show("Missing Address Line2 Name");
                    }
                    else if (string.IsNullOrWhiteSpace(tbxAddress3.Text))
                    {
                        MessageBox.Show("Missing Address Line3 Name");
                    }

                    else if (string.IsNullOrWhiteSpace(tbxEmailAddress.Text))
                    {
                        MessageBox.Show("Missing email Addresse");
                    }
                }

                else
                {
                    MessageBox.Show("This is a number only field, please enter telephone No");
                }

               /* else if(!int.TryParse(tbxTelephoneNo.Text, out parsedValue))
                {
                    MessageBox.Show("This is a number only field, please enter telephone No");
                    return;
                }*/
                //if no textboxes are empty

            }
            else
            {
                MessageBox.Show("Password Mismatch");
            }
        }

        private void mtdAddUser()
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
 
        private User GetUserDetails ()
        {
            User tempUser = new User();
            string password = passwordBox.Password;
            string passwordConfirm = passwordBoxConfirm.Password;

            tempUser.UserId = Guid.NewGuid().ToString();
            tempUser.FirstName = tbxFirstName.Text.Trim();
            tempUser.LastName = tbxLastName.Text.Trim();
            tempUser.Address = tbxAddress1.Text.Trim() + " " + tbxAddress2.Text.Trim() + " " + tbxAddress3.Text.Trim();
            tempUser.TelephoneNo = tbxTelephoneNo.Text.Trim();
            tempUser.Email = tbxEmailAddress.Text.Trim();
            tempUser.Password = password;
            //sets username to lower case to remove Upper/Lower case issues
            tempUser.UserName = tbxUserName.Text.Trim().ToLower();
            tempUser.AccessLevel = 1;

            return tempUser;

        }

        private void mtdClearUserDetails()
        {
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            tbxUserName.Text = "";

            passwordBox.Password = "";
            passwordBoxConfirm.Password = "";

            tbxAddress1.Text = "";
            tbxAddress2.Text = "";
            tbxAddress3.Text = "";
            tbxTelephoneNo.Text = "";
            tbxEmailAddress.Text = "";

        }
    }
}
