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
    /// Interaction logic for AuthorAdd.xaml
    /// </summary>
    public partial class AuthorAdd : Page
    {
        DBEntities db = new DBEntities();
        
        //call components
        public AuthorAdd()
        {
            InitializeComponent();
        }

        //click event when user clicks add 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(txtName.Text))
            {
                    //call the add author method 
                    mtdAddAuthor();
                    //tell user author has been added 
                    MessageBox.Show("New Author Added");
                    //clear the textboxes
                    mtdClearAuthorDetails();

                }
            //check to see if  Name text box is empty
            else if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Missing Author Name");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("error adding author");
            }


        }
        //method to save the new changes to 
        private void mtdAddAuthor()
        {
            try
            {
                //set database configuration to not autodetect changes 
                db.Configuration.AutoDetectChangesEnabled = false;
                //set database to not ValidateOnSaveEnabled
                db.Configuration.ValidateOnSaveEnabled = false;
                //get database to call the GetUserDetails() method and add with entiystate
                db.Entry(GetUserDetails()).State = System.Data.Entity.EntityState.Added;
                //save changes to db
                db.SaveChanges();
                //set database configuration to autodetect changes 
                db.Configuration.AutoDetectChangesEnabled = true;
                //set database to  ValidateOnSaveEnabled
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Details");
            }
        }
        //method to retrieve details from textboxes 
        private Author GetUserDetails()
        {
            //create new insrtance of author to hold details 
            Author tempAuthor = new Author();
            //create new unique primary key for future record
            tempAuthor.AuthorId = Guid.NewGuid().ToString();
            //retrieve author name from textbox
            tempAuthor.AuthorName = txtName.Text.Trim();

            //return the details from the object
            return tempAuthor;
        }

        //method to clear input boxes
        private void mtdClearAuthorDetails()
        {
            //sets the text box to remove any input
            txtName.Text = "";
        }

    }
}
