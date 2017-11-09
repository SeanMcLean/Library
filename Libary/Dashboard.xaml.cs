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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        DBEntities userDB;
        DBEntities itemsDB = new DBEntities();
        DBEntities EmployeeDB = new DBEntities();
        DBEntities PublisherDB;

        public User currentUser = new User();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userDB = new DBEntities();
            DatagridEmployee.ItemsSource = userDB.Users.ToList();

            /* Default Generated Code
             * Libary.SeanDBDataSet seanDBDataSet = ((Libary.SeanDBDataSet)(this.FindResource("seanDBDataSet")));
             // Load data into the table User. You can modify this code as needed.
             Libary.SeanDBDataSetTableAdapters.UserTableAdapter seanDBDataSetUserTableAdapter = new Libary.SeanDBDataSetTableAdapters.UserTableAdapter();
             seanDBDataSetUserTableAdapter.Fill(seanDBDataSet.User);
             System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
             userViewSource.View.MoveCurrentToFirst();*/


            PublisherDB = new DBEntities();
            publisherDataGrid.ItemsSource = PublisherDB.Publishers.ToList();

             
            /*
            Libary.SeanDBDataSet1 seanDBDataSet1 = ((Libary.SeanDBDataSet1)(this.FindResource("seanDBDataSet1")));
            // Load data into the table Item. You can modify this code as needed.
            Libary.SeanDBDataSet1TableAdapters.ItemTableAdapter seanDBDataSet1ItemTableAdapter = new Libary.SeanDBDataSet1TableAdapters.ItemTableAdapter();
            seanDBDataSet1ItemTableAdapter.Fill(seanDBDataSet1.Item);
            System.Windows.Data.CollectionViewSource itemViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemViewSource")));
            itemViewSource.View.MoveCurrentToFirst();
            */

            Libary.SeanDBDataSetPublisher seanDBDataSetPublisher = ((Libary.SeanDBDataSetPublisher)(this.FindResource("seanDBDataSetPublisher")));
            // Load data into the table Publisher. You can modify this code as needed.
            Libary.SeanDBDataSetPublisherTableAdapters.PublisherTableAdapter seanDBDataSetPublisherPublisherTableAdapter = new Libary.SeanDBDataSetPublisherTableAdapters.PublisherTableAdapter();
            seanDBDataSetPublisherPublisherTableAdapter.Fill(seanDBDataSetPublisher.Publisher);
            System.Windows.Data.CollectionViewSource publisherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("publisherViewSource")));
            publisherViewSource.View.MoveCurrentToFirst();
        }

        /// 
        /// Click Event Triggers 
        /// 

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
               currentUser = new User();
           // currentUser.FirstName = .Text.Trim();
        }

        private void Item_Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Item_Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Button_Click_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Button_Click_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Publisher_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            PublisherDB = new DBEntities();

            Publisher item = publisherDataGrid.SelectedItem as Publisher;

            try
            {
                Publisher publisher1 = PublisherDB.Publishers.Where(b => b.PublisherId == item.PublisherId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    PublisherDB.Publishers.Remove(publisher1);
                    PublisherDB.SaveChanges();
                    refresEmployeehGrid();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Publisher_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            PublisherDB = new DBEntities();
            Publisher item = publisherDataGrid.SelectedItem as Publisher;
            Publisher Publisher1 = PublisherDB.Publishers.Where(b => b.PublisherId == item.PublisherId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
            {
                Publisher1.Name = (publisherDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                Publisher1.Address = (publisherDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                Publisher1.TelephoneNo = int.Parse((publisherDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                Publisher1.Email = (publisherDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                try
                {
                    PublisherDB.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Employee_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            userDB = new DBEntities();

            User item = DatagridEmployee.SelectedItem as User;

            try
            {
                User user1 = userDB.Users.Where(b => b.UserId == item.UserId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    userDB.Users.Remove(user1);
                    userDB.SaveChanges();
                    refresEmployeehGrid();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Employee_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            userDB = new DBEntities();
            User item = DatagridEmployee.SelectedItem as User;
            User user1 = userDB.Users.Where(b => b.UserId == item.UserId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update Data", "Confirm", MessageBoxButton.YesNo))
            {
                // user1.UserId = (DatagridEmployee.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                user1.UserName = (DatagridEmployee.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                user1.FirstName = (DatagridEmployee.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                user1.LastName = (DatagridEmployee.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                user1.Address = (DatagridEmployee.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                user1.Email = (DatagridEmployee.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                user1.TelephoneNo = (DatagridEmployee.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                user1.Password = (DatagridEmployee.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                user1.AccessLevel = int.Parse((DatagridEmployee.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);

                            try
            {
                userDB.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            }

        }

        /// 
        /// Custom Methods 
        /// 

        private void refresEmployeehGrid()
        {
            DatagridEmployee.ItemsSource = userDB.Users.ToList();
            DatagridEmployee.Items.Refresh();
        }
        private void refresPublisherGrid()
        {
            publisherDataGrid.ItemsSource = userDB.Users.ToList();
            publisherDataGrid.Items.Refresh();
        }
        private void refresItemhGrid()
        {
            DatagridEmployee.ItemsSource = userDB.Users.ToList();
            DatagridEmployee.Items.Refresh();
        }
    }
}
