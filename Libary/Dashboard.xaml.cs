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
        //  DBEntities userDB;
        DBEntities itemsDB;
        DBEntities EmployeeDB;
        DBEntities PublisherDB;
        DBEntities MemberDB;
        DBEntities AuthorDB;


        public User currentUser = new User();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            itemsDB = new DBEntities();
            itemDataGrid.ItemsSource = itemsDB.Items.ToList();

            EmployeeDB = new DBEntities();
            DatagridEmployee.ItemsSource = EmployeeDB.Employees.ToList();

            PublisherDB = new DBEntities();
            publisherDataGrid.ItemsSource = PublisherDB.Publishers.ToList();

            AuthorDB = new DBEntities();
            authorDataGrid.ItemsSource = AuthorDB.Authors.ToList();

            MemberDB = new DBEntities();
            MemberDataGrid.ItemsSource = MemberDB.Members.ToList();

        }

        /// 
        /// Click Event Triggers 
        /// 


        /// 
        /// Author Methods & Events
        /// 
        private void Author_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            AuthorDB = new DBEntities();
            Author item = authorDataGrid.SelectedItem as Author;

            try
            {
                Author author = AuthorDB.Authors.Where(b => b.AuthorId == item.AuthorId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    AuthorDB.Authors.Remove(author);
                    AuthorDB.SaveChanges();
                    refresAuthorGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Author_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            AuthorDB = new DBEntities();
            Author item = authorDataGrid.SelectedItem as Author;

            Author authorTemp = AuthorDB.Authors.Where(b => b.AuthorId == item.AuthorId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update", "Confirm", MessageBoxButton.YesNo))
            {
                authorTemp.AuthorName = (authorDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                try
                {
                    AuthorDB.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void refresAuthorGrid()
        {
            authorDataGrid.ItemsSource = AuthorDB.Authors.ToList();
            authorDataGrid.Items.Refresh();
        }


        /// 
        /// Member Methods & Events
        /// 
        private void Member_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            MemberDB = new DBEntities();
            Member item = MemberDataGrid.SelectedItem as Member;

            try
            {
                Member member1 = MemberDB.Members.Where(b => b.MemberId == item.MemberId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    MemberDB.Members.Remove(member1);
                    MemberDB.SaveChanges();
                    refresItemGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Member_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            MemberDB = new DBEntities();
            Member item = MemberDataGrid.SelectedItem as Member;

            Member memberTemp = MemberDB.Members.Where(b => b.MemberId == item.MemberId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update", "Confirm", MessageBoxButton.YesNo))
            {
                memberTemp.FirstName = (MemberDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.LastName = (MemberDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.Address = (MemberDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.Classification = (MemberDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.TransactionHistoryTotal = decimal.Parse((MemberDataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);
                try
                {
                    MemberDB.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void refresMemberGrid()
        {
            MemberDataGrid.ItemsSource = MemberDB.Members.ToList();
            MemberDataGrid.Items.Refresh();
        }


        /// 
        /// Item Methods & Events
        /// 
        private void Item_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            itemsDB = new DBEntities();
            Item item = itemDataGrid.SelectedItem as Item;

            Item itemTemp = itemsDB.Items.Where(b => b.ItemId == item.ItemId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update", "Confirm", MessageBoxButton.YesNo))
            {
                itemTemp.ISBN = (itemDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.Title = (itemDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.Genre = (itemDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.Author = (itemDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.Publisher = (itemDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.CopiesAvailable = int.Parse((itemDataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);
                itemTemp.CopieOnLoan = int.Parse((itemDataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
             //   itemTemp.PublicationDate = Convert.ToDateTime((publisherDataGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text);

                try
                {
                    itemsDB.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Item_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            itemsDB = new DBEntities();

            Item item = itemDataGrid.SelectedItem as Item;

            try
            {
                Item item1 = itemsDB.Items.Where(b => b.ItemId == item.ItemId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    itemsDB.Items.Remove(item1);
                    itemsDB.SaveChanges();
                    refresItemGrid();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void refresItemGrid()
        {
            DatagridEmployee.ItemsSource = itemsDB.Users.ToList();
            DatagridEmployee.Items.Refresh();
        }

        /// 
        /// Publisher Methods & Events
        /// 
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
                    refresPublisherGrid();
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

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update", "Confirm", MessageBoxButton.YesNo))
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

        private void refresPublisherGrid()
        {
            publisherDataGrid.ItemsSource = PublisherDB.Publishers.ToList();
            publisherDataGrid.Items.Refresh();
        }


        /// 
        /// Employee Methods & Events
        /// 
        private void Employee_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            EmployeeDB = new DBEntities();
            Employee item = DatagridEmployee.SelectedItem as Employee;

            try
            {
                Employee employee = EmployeeDB.Employees.Where(b => b.EmployeeId == item.EmployeeId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    EmployeeDB.Employees.Remove(employee);
                    EmployeeDB.SaveChanges();
                    refresEmployeeGrid();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Employee_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            EmployeeDB = new DBEntities();
            Employee item = DatagridEmployee.SelectedItem as Employee;
            Employee employee = EmployeeDB.Employees.Where(b => b.EmployeeId == item.EmployeeId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update Data", "Confirm", MessageBoxButton.YesNo))
            {
                employee.FirstName = (DatagridEmployee.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                employee.LastName = (DatagridEmployee.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                employee.Address = (DatagridEmployee.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                employee.TelephoneNo = int.Parse((DatagridEmployee.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                employee.Email = (DatagridEmployee.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                employee.Role = (DatagridEmployee.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                employee.HireDate = Convert.ToDateTime((DatagridEmployee.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text);
                employee.Salary = decimal.Parse((DatagridEmployee.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text);


                try
                {
                    EmployeeDB.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void refresEmployeeGrid()
        {
            DatagridEmployee.ItemsSource = EmployeeDB.Employees.ToList();
            DatagridEmployee.Items.Refresh();
        }

        private void btnItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frItem.Content = new ItemAdd();
        }

        /// 
        /// Methods 
        /// 
    }
}
