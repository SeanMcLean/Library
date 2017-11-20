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

        public ItemAdd()
        {
            InitializeComponent();

            //initialse and populate items grid
            cbAuthor.ItemsSource = db.Authors.ToList();
            cbPublisher.ItemsSource = db.Publishers.ToList();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
                mtdAddItem();
                MessageBox.Show("New Item Added");
                mtdClearItemDetails();

          //  dash.refresItemGrid();

        }

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

        private Item GetUserDetails()
        {
            Item tempItem = new Item();

            tempItem.ItemId = Guid.NewGuid().ToString();
            tempItem.ISBN = txtISBN.Text.Trim();
            tempItem.Title = txtTitle.Text.Trim();
            tempItem.Genre = txtGenre.Text.Trim();
            tempItem.AuthorId = cbAuthor.ItemsSource.ToString();
            tempItem.PublisherId = cbPublisher.SelectedItem.ToString();
            tempItem.CopiesAvailable = Convert.ToInt32(txtCopiesAv.Text.Trim());
            tempItem.CopieOnLoan = 0;
            tempItem.PublicationDate = Convert.ToDateTime(dpPublicationDate.SelectedDate.Value.Date.ToShortDateString());

            return tempItem;
        }

        private void mtdClearItemDetails()
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtCopiesAv.Text = "";
         //   txtAuthor.Text = "";
            txtCopiesAv.Text = "";
            dpPublicationDate.Text = "" ;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
