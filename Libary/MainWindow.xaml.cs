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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Create a new instance of SQL database connection
        DBEntities db = new DBEntities();

        //Global list used to contain all users
        List<User> userList = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }


        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                string username = tbxUserName.Text.Trim();
                //Password box is accessed using different commands to textbox
                string password = passwordBox.Password;
                //Check if inoutted credentials are in SQL database        
                user = VerifyUserDetails(username.ToLower(), password);
                if (user.AccessLevel > 0) //user exists
                {
                    //create a new instance of the Dashboard window
                    Dashboard dashboard = new Dashboard();
                    dashboard.Owner = this;
                    dashboard.currentUser = user;
                    this.Hide();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    //User does not exist
                    MessageBox.Show("Invalid user");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Conection Issues");
            }
        }

        //method to check if user details are true and exist
        public User VerifyUserDetails(string username, string password)
        {
            User verifiedUser = new User();
            foreach (var user in db.Users)
            {
                //If current user in userList List has ther same username and password
                //then the user exists
                if (user.UserName == username && user.Password == password)
                {
                    //put the details of the verified user into the verifiedUser object
                    verifiedUser = user;
                }
            }
            //Return the user details to the calling method
            return verifiedUser;
        }

        //method to load users into list 
        public void LoadUsers()
        {
            try
            {
                //clear list of any ciurrent users
                userList.Clear();
                //iterate through users in database and add to lsit
                foreach (var user in db.Users)
                {
                    userList.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database " + ex.InnerException);
            }

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //do this first before any user interaction is allowed with this window
            LoadUsers();
        }

        //method to open new regisitration window
        public void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //create new instance of registration window
            Registration reg2 = new Registration();
            //Display new instance 
            reg2.Show();
            //close this login window
            this.Close();
        }


    }
 
}