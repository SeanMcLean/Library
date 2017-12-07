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
    /// Interaction logic for ItemAdd.xaml
    /// </summary>
    public partial class ItemAdd : Page
    {
        DBEntities db = new DBEntities();
        Dashboard dash = new Dashboard();

        int parsedValue1;
        public ItemAdd()
        {
            InitializeComponent();

            //initialse and populate items grid
            cbAuthor.ItemsSource = db.Authors.ToList();
            cbPublisher.ItemsSource = db.Publishers.ToList();
        }
        //event to add item to database
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            //check if all data is inputted
            if (!string.IsNullOrWhiteSpace(txtISBN.Text)
                    & !string.IsNullOrWhiteSpace(txtTitle.Text)
                    & !string.IsNullOrWhiteSpace(txtGenre.Text)
                    & !string.IsNullOrWhiteSpace(dpPublicationDate.Text)
                    & int.TryParse(txtCopiesAv.Text, out parsedValue1))
            {
                //call methods to add item 
                mtdAddItem();
                //Inform user that details have been added 
                MessageBox.Show("New Item Added");
                //clear old textbox data
                mtdClearItemDetails();

            }
            //check to see if ISBN text box is empty
            else if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Missing ISBN");
            }
            //check to see if Title text box is empty
            else if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Missing Title ");
            }
            //check to see if Genre text box is empty
            else if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Missing Genre Name");
            }
            //check to see if Copies Available text box is empty or a character

            else if (!int.TryParse(txtCopiesAv.Text, out parsedValue1))
            {
                MessageBox.Show("Invalid Copies Available Data");
            }
            //check to see if publication is empty
            else if (string.IsNullOrWhiteSpace(dpPublicationDate.Text))
            {
                MessageBox.Show("Missing Publication Date");
            }

          //  dash.refresItemGrid();

        }

        //method to add users to database
        private void mtdAddItem()
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

        //method to retreive user details to send to database
        private Item GetUserDetails()
        {
            //declare new item instance 
            Item tempItem = new Item();

            //new randon unique primary key 
            tempItem.ItemId = Guid.NewGuid().ToString();
            //set tempItem ISBN from txtISBN
            tempItem.ISBN = txtISBN.Text.Trim();
            //set tempItem Title from txtTitle
            tempItem.Title = txtTitle.Text.Trim();
            //set tempItem Genre from txtGenre
            tempItem.Genre = txtGenre.Text.Trim();
            // tempItem.AuthorId = cbAuthor.ItemsSource.ToString();
            // tempItem.PublisherId = cbPublisher.SelectedItem.ToString();

            //set tempItem CopiesAvailable from txtCopiesAv
            tempItem.CopiesAvailable = Convert.ToInt32(txtCopiesAv.Text.Trim());
            //set CopiesOnLoan to zero since nothing should be on loan ifit dosent exist
            tempItem.CopieOnLoan = 0;
            //set tempItem PublicationDate from dpPublicationDate
            tempItem.PublicationDate = Convert.ToDateTime(dpPublicationDate.SelectedDate.Value.Date.ToShortDateString());
            //issues with combo box and sending back foreign key insteaad of name
            //setting value to 1 until fixed
            tempItem.AuthorId = "1";
            tempItem.PublisherId = "1";

            return tempItem;
        }

        //method to clear datafields 
        private void mtdClearItemDetails()
        {
            //clear values from datafields 
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtCopiesAv.Text = "";
            //txtAuthor.Text = "";
            txtCopiesAv.Text = "";
            //dpPublicationDate.Text = "";

            cbAuthor.SelectedIndex = -1;
            cbPublisher.Text = "";
            dpPublicationDate.SelectedDate = null;
        }


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
