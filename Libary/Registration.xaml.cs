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

        public Registration()
        {
            InitializeComponent();
        }

        //click event to return to login window
        public void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //crraste new MainWindow instance
            MainWindow win = new MainWindow();
            //hide this page 
            this.Hide();
            //display MainWindow 
            win.Show();
            //close registration page 
            Close();
        }
 
        //click event to add used 
        public void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //check to see if passwords match
            if (passwordBox.Password == passwordBoxConfirm.Password)
            {
                //check if telphone number box has int instead of string 
                if (int.TryParse(tbxTelephoneNo.Text, out parsedValue))
                {
                    //check if the textboxes are empty 
                    if (!string.IsNullOrWhiteSpace(tbxFirstName.Text)
                    & !string.IsNullOrWhiteSpace(tbxLastName.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress1.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress2.Text)
                    & !string.IsNullOrWhiteSpace(tbxAddress3.Text)
                    & !string.IsNullOrWhiteSpace(tbxEmailAddress.Text)
                    & !string.IsNullOrWhiteSpace(tbxUserName.Text))
                    {
                        //call methods to add user 
                        mtdAddUser();
                        //Inform user that details have been added 
                        MessageBox.Show("Your details have been Registered. You will be notified when registration is complete.");
                        //clear old textbox data
                        mtdClearUserDetails();
                    }

                    //check to see if First Name text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxFirstName.Text))
                    {
                        MessageBox.Show("Missing First Name");
                    }
                    //check to see if First Last text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxLastName.Text))
                    {
                        MessageBox.Show("Missing Last Name");
                    }
                    //check to see if Address text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxAddress1.Text))
                    {
                        MessageBox.Show("Missing Address Line1 Name");
                    }
                    //check to see if Address text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxAddress2.Text))
                    {
                        MessageBox.Show("Missing Address Line2 Name");
                    }
                    //check to see if Address text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxAddress3.Text))
                    {
                        MessageBox.Show("Missing Address Line3 Name");
                    }
                    //check to see if EmailAddress text box is empty
                    else if (string.IsNullOrWhiteSpace(tbxEmailAddress.Text))
                    {
                        MessageBox.Show("Missing email Addresse");
                    }
                }
                //tell user use of textbox
                else
                {
                    MessageBox.Show("This is a number only field, please enter telephone No");
                }

            }
            //tell user password mismatch
            else
            {
                MessageBox.Show("Password Mismatch");
            }
        }

        //method to add user, to be called in other mehtods
        public void mtdAddUser()
        {
            try
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                //retrieve the user details 
                db.Entry(GetUserDetails()).State = System.Data.Entity.EntityState.Added;
                //save database changes 
                db.SaveChanges();
                db.Configuration.AutoDetectChangesEnabled = true;
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Details");
            }     
        }
 
        //methods to retrieve user details from textboxes 
        public User GetUserDetails ()
        {
            //create a new user instance 
            User tempUser = new User();
            //create varable to hold passwordBox values 
            string password = passwordBox.Password;
            //create varable to hold passwordBoxConfirm values 
            string passwordConfirm = passwordBoxConfirm.Password;
            //set tempUser userid from random id gen
            tempUser.UserId = Guid.NewGuid().ToString();
            //set tempUser username from tbxFirstName
            tempUser.FirstName = tbxFirstName.Text.Trim();
            //set tempUser FirstName from tbxFirstName
            tempUser.LastName = tbxLastName.Text.Trim();
            //set tempUser address  from tbxAddress1, tbxAddress2, tbxAddress3
            tempUser.Address = tbxAddress1.Text.Trim() + " " + tbxAddress2.Text.Trim() + " " + tbxAddress3.Text.Trim();
            //set tempUser TelephoneNo from tbxTelephoneNo
            tempUser.TelephoneNo = tbxTelephoneNo.Text.Trim();
            //set tempUser Email from tbxEmailAddress
            tempUser.Email = tbxEmailAddress.Text.Trim();
            //set tempUser Password from password variable
            tempUser.Password = password;
            //sets username to lower case to remove Upper/Lower case issues
            tempUser.UserName = tbxUserName.Text.Trim().ToLower();
            //set tempUser AccessLeve. To be update by administrator 
            tempUser.AccessLevel = 1;

            //return the page details 
            return tempUser;

        }

        //method to clear old details after add 
        public void mtdClearUserDetails()
        {
            //set blank values to all input boxes

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
