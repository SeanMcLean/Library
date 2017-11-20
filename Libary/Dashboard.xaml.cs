﻿using System;
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
        DBEntities databaseEntity;
        DBEntities userDB;
        DBEntities itemsDB;
        DBEntities EmployeeDB;
        DBEntities PublisherDB;
        DBEntities MemberDB;
        DBEntities AuthorDB;

        LibraryMethods lm = new LibraryMethods();

        public User currentUser = new User();

        public Dashboard()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDashboard(currentUser.AccessLevel);
        }



        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// AuthorTab Methods & Events                                                               ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 
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
                    if ((authorDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text == " ")
                    {
                        MessageBox.Show("Please Enter Name");
                    }
                }
            }
        }

        private void refresAuthorGrid()
        {
            authorDataGrid.ItemsSource = AuthorDB.Authors.ToList();
            authorDataGrid.Items.Refresh();
        }

        private void btnAuthorAdd_Click(object sender, RoutedEventArgs e)
        {
            frAuthor.Content = new AuthorAdd();
            frAuthor.Visibility = Visibility.Visible;
            btnAuthorAdd.Visibility = Visibility.Hidden;
            btnAuthorClose.Visibility = Visibility.Visible;
       
        }
        private void btnAuthorClose_Click(object sender, RoutedEventArgs e)
        {
            btnAuthorAdd.Visibility = Visibility.Visible;
            btnAuthorClose.Visibility = Visibility.Hidden;
            frAuthor.Visibility = Visibility.Hidden;
            refresAuthorGrid();
        }

        private void tbxSearchAuth_TextChanged(object sender, TextChangedEventArgs e)
        {
            AuthorDB = new DBEntities();
            authorDataGrid.ItemsSource = AuthorDB.Authors.Where(b => b.AuthorName.Contains(tbxSearchAuth.Text)).ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// MemberTab Methods & Events                                                               ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 
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
                    refresMemberGrid();
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
                memberTemp.FirstName = (MemberDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.LastName = (MemberDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.Address = (MemberDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.Classification = (MemberDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                memberTemp.TransactionHistoryTotal = decimal.Parse((MemberDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
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

        private void btnMemberAdd_Click(object sender, RoutedEventArgs e)
        {
            frMember.Content = new MemberAdd();
            frMember.Visibility = Visibility.Visible;
            btnMemberAdd.Visibility = Visibility.Hidden;
            btnMemberClose.Visibility = Visibility.Visible;

        }
        private void btnMemberClose_Click(object sender, RoutedEventArgs e)
        {
            btnMemberAdd.Visibility = Visibility.Visible;
            btnMemberClose.Visibility = Visibility.Hidden;
            frMember.Visibility = Visibility.Hidden;
            refresMemberGrid();
        }

        private void tbxSearchMember_TextChanged(object sender, TextChangedEventArgs e)
        {
            MemberDB = new DBEntities();
            MemberDataGrid.ItemsSource = MemberDB.Members.Where(b => b.FirstName.Contains(tbxSearchMember.Text) || b.LastName.Contains(tbxSearchMember.Text)).ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// SearchTab/Item Methods & Events                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemsDB = new DBEntities();
            itemDataGrid.ItemsSource = itemsDB.Items.Where(b => b.Title.Contains(tbxSearch.Text)).ToList();
        }

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
                itemTemp.AuthorId = (itemDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                itemTemp.PublisherId = (itemDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
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

        private void Item_Button_Click_Reserve(object sender, RoutedEventArgs e)
        {
            itemsDB = new DBEntities();
            Item item = itemDataGrid.SelectedItem as Item;

            Item itemTemp = itemsDB.Items.Where(b => b.ItemId == item.ItemId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Reserve", "Confirm", MessageBoxButton.YesNo))
            {
                if (itemTemp.CopiesAvailable == 0)
                {
                    MessageBox.Show("No copies available");
                }
                else
                {
                    itemTemp.CopiesAvailable--;
                    itemTemp.CopieOnLoan++;
                    refresItemGrid();
                }

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

        public void refresItemGrid()
        {
            itemDataGrid.ItemsSource = itemsDB.Items.ToList();
            itemDataGrid.Items.Refresh();
        }

        private void btnItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frItem.Content = new ItemAdd();
            frItem.Visibility = Visibility.Visible;
            btnItemAdd.Visibility = Visibility.Hidden;
            btnItemClose.Visibility = Visibility.Visible;

        }
        private void btnItemClose_Click(object sender, RoutedEventArgs e)
        {
            btnItemAdd.Visibility = Visibility.Visible;
            btnItemClose.Visibility = Visibility.Hidden;
            frItem.Visibility = Visibility.Hidden;
            refresItemGrid();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// PublisherTab Methods & Events                                                            ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 
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
                Publisher1.Name = (publisherDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                Publisher1.Address = (publisherDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                Publisher1.TelephoneNo = int.Parse((publisherDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                Publisher1.Email = (publisherDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
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

        private void btnPublisherAdd_Click(object sender, RoutedEventArgs e)
        {
            frPublisher.Content = new PublisherAdd();
            frPublisher.Visibility = Visibility.Visible;
            btnPublisherAdd.Visibility = Visibility.Hidden;
            btnPublisherClose.Visibility = Visibility.Visible;

        }
        private void btnPublisherClose_Click(object sender, RoutedEventArgs e)
        {
            btnPublisherAdd.Visibility = Visibility.Visible;
            btnPublisherClose.Visibility = Visibility.Hidden;
            frPublisher.Visibility = Visibility.Hidden;
            refresPublisherGrid();
        }
        private void tbxSearchPub_TextChanged(object sender, TextChangedEventArgs e)
        {
            PublisherDB = new DBEntities();
            publisherDataGrid.ItemsSource = PublisherDB.Publishers.Where(b => b.Name.Contains(tbxSearchPub.Text)).ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// EmployeeTab Methods & Events                                                             ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 
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
                // var hireStr = "";

               // hireStr = (DatagridEmployee.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;

                employee.FirstName = (DatagridEmployee.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                employee.LastName = (DatagridEmployee.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                employee.Address = (DatagridEmployee.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                employee.TelephoneNo = int.Parse((DatagridEmployee.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                employee.Email = (DatagridEmployee.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                employee.Role = (DatagridEmployee.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            //    employee.HireDate = (DatagridEmployee.SelectedCells[6].Column.GetCellContent(item) as TextBlock).DisplayDate;
                employee.Salary = decimal.Parse((DatagridEmployee.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text);

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


        private void btnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            frEmployee.Content = new EmployeeAdd();
            frEmployee.Visibility = Visibility.Visible;
            btnEmployeeAdd.Visibility = Visibility.Hidden;
            btnEmployeeClose.Visibility = Visibility.Visible;

        }
        private void btnEmployeeClose_Click(object sender, RoutedEventArgs e)
        {
            btnEmployeeAdd.Visibility = Visibility.Visible;
            btnEmployeeClose.Visibility = Visibility.Hidden;
            frEmployee.Visibility = Visibility.Hidden;
            refresEmployeeGrid();
        }
        private void tbxSearchEmp_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeDB = new DBEntities();
            DatagridEmployee.ItemsSource = EmployeeDB.Employees.Where(b => b.FirstName.Contains(tbxSearchEmp.Text) || b.LastName.Contains(tbxSearchEmp.Text)).ToList();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// AdminTab Methods & Events                                                             ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        private void User_Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            userDB = new DBEntities();
            User item = userDataGrid.SelectedItem as User;

            try
            {
                User tempUser = userDB.Users.Where(b => b.UserId == item.UserId).Single();
                if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Delete", "Confirm", MessageBoxButton.YesNo))
                {
                    userDB.Users.Remove(tempUser);
                    userDB.SaveChanges();
                    refresUserGrid();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void User_Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            userDB = new DBEntities();
            User item = userDataGrid.SelectedItem as User;
            User tempUser = userDB.Users.Where(b => b.UserId == item.UserId).Single();

            if (MessageBoxResult.Yes == MessageBox.Show("Are you sure you wish to Update Data", "Confirm", MessageBoxButton.YesNo))
            {
                tempUser.FirstName = (userDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.LastName = (userDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.Address = (userDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.TelephoneNo = (userDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.Email = (userDataGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.Password = (userDataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                tempUser.AccessLevel = int.Parse((userDataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);

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


        private void refresUserGrid()
        {
            userDataGrid.ItemsSource = userDB.Users.ToList();
            userDataGrid.Items.Refresh();
        }
        private void tbxSearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {

            userDB = new DBEntities();
            userDataGrid.ItemsSource = userDB.Users.Where(b => b.FirstName.Contains(tbxSearchUser.Text) || b.LastName.Contains(tbxSearchUser.Text)).ToList();

        }
        ///////////////////////////////////////////////////////////////////////////////////////////// 
        /// Methods                                                                               ///
        ///////////////////////////////////////////////////////////////////////////////////////////// 

        //Method to display different functionality depending on user permission
        private void ShowDashboard(int accessLevel)
        {
            //only show items tab for student and hide additional functionality
            if (accessLevel == 1)
            {
                //create new entity instances for data connection
                databaseEntity = new DBEntities();

                //initialse and populate items grid
                itemDataGrid.ItemsSource = databaseEntity.Items.ToList();

                //hide the update and delete buttons of the datagrid by calling column IDs
                itemDataGrid.Columns[8].Visibility = Visibility.Collapsed;
                itemDataGrid.Columns[9].Visibility = Visibility.Collapsed;

                //hide the tabs the student should not have access to
                MemberTab.Visibility = Visibility.Hidden;
                EmployeeTab.Visibility = Visibility.Hidden;
                AuthorTab.Visibility = Visibility.Hidden;
                PublisherTab.Visibility = Visibility.Hidden;
                AdminTab.Visibility = Visibility.Hidden;

                //hide buttons student should not have access to
                btnItemAdd.Visibility = Visibility.Hidden;
                btnItemClose.Visibility = Visibility.Hidden;



            }
            //show all controls for admin access
            if (accessLevel == 2)
            {
                //create new entity instances for data connection
                itemsDB  = new DBEntities();
                EmployeeDB = new DBEntities();
                PublisherDB = new DBEntities();
                AuthorDB = new DBEntities();
                MemberDB = new DBEntities();
                userDB = new DBEntities();

                //initialse and populate items grid
                itemDataGrid.ItemsSource = itemsDB.Items.ToList();
              //  cbPublisher.ItemsSource = PublisherDB.Publishers.ToList();
              //  cbAuthor.ItemsSource = AuthorDB.Authors.ToList();

                //initialse and populate Employee grid
                DatagridEmployee.ItemsSource = EmployeeDB.Employees.ToList();

                //initialse and populate Publisher grid
                publisherDataGrid.ItemsSource = PublisherDB.Publishers.ToList();

                //initialse and populate Author grid
                authorDataGrid.ItemsSource = AuthorDB.Authors.ToList();

                //initialse and populate Member grid
                MemberDataGrid.ItemsSource = MemberDB.Members.ToList();

                userDataGrid.ItemsSource = userDB.Users.ToList();
            }
        }

    }
}


