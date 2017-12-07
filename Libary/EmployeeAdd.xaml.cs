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
    /// Interaction logic for EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : Page
    {
        DBEntities db = new DBEntities();
        int parsedValue;
        int parsedValueSAl;

        public EmployeeAdd()
        {
            InitializeComponent();
        }

        //Click event to add Employee
        public void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

                //check if the textboxes are empty 
                if (!string.IsNullOrWhiteSpace(txtFirstName.Text)
                & !string.IsNullOrWhiteSpace(txtLastName.Text)
                & !string.IsNullOrWhiteSpace(txtAddress1.Text)
                & !string.IsNullOrWhiteSpace(txtAddress2.Text)
                & !string.IsNullOrWhiteSpace(txtAddress3.Text)
                & !string.IsNullOrWhiteSpace(txtEmail.Text)
                & int.TryParse(txtSalary.Text, out parsedValueSAl)
                & int.TryParse(txtTelephone.Text, out parsedValue)
                & !string.IsNullOrWhiteSpace(txtRole.Text)
                &!string.IsNullOrWhiteSpace(dpHireDate.Text))

                {


                    //call methods to add Employee 
                    mtdAddEmployee();
                    //Inform user that details have been added 
                    MessageBox.Show("New Employee Added");
                    //clear old textbox data
                    mtdClearEmployeeDetails();
                }

                //check to see if First Name text box is empty
                else if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Missing First Name");
                }
                //check to see if First Last text box is empty
                else if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Missing Last Name");
                }
                //check to see if Address text box is empty
                else if (string.IsNullOrWhiteSpace(txtAddress1.Text))
                {
                    MessageBox.Show("Missing Address Line1 Name");
                }
                //check to see if Address text box is empty
                else if (string.IsNullOrWhiteSpace(txtAddress2.Text))
                {
                    MessageBox.Show("Missing Address Line2 Name");
                }
                //check to see if Address text box is empty
                else if (string.IsNullOrWhiteSpace(txtAddress3.Text))
                {
                    MessageBox.Show("Missing Address Line3 Name");
                }
                //check to see if Email text box is empty
                else if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Missing Email Name");
                }
                //check to see if Role text box is empty
                else if (string.IsNullOrWhiteSpace(txtRole.Text))
                {
                    MessageBox.Show("Missing Role Name");
                }
                //check to see if Address text box is empty
                else if (string.IsNullOrWhiteSpace(txtAddress3.Text))
                {
                    MessageBox.Show("Missing Address Line3 Name");
                }
            //check to see if Salary text box is empty
            else if (!int.TryParse(txtSalary.Text, out parsedValueSAl))
            {
                MessageBox.Show("Invalid Salary Data");
            }
            //check to see if Telephone text box is empty
            else if (!int.TryParse(txtTelephone.Text, out parsedValue))
            {
                MessageBox.Show("Invlid Telephone No");
            }
            //check to see if date text box is empty
            else if (string.IsNullOrWhiteSpace(dpHireDate.Text))
            {
                MessageBox.Show("Missing Date");
            }
        }

        //method to add Employee to database
        public void mtdAddEmployee()
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

        //Method to retrieve employee details from input fields 
        public Employee GetUserDetails()
        {
            Employee tempEmployee = new Employee();

            tempEmployee.EmployeeId = Guid.NewGuid().ToString();
            tempEmployee.FirstName = txtFirstName.Text.Trim();
            tempEmployee.LastName = txtLastName.Text.Trim();
            tempEmployee.TelephoneNo = int.Parse(txtTelephone.Text);
            tempEmployee.Address = txtAddress1.Text.Trim() + " " + txtAddress2.Text.Trim() + " " + txtAddress3.Text.Trim();
            tempEmployee.Email = txtEmail.Text.Trim();
            tempEmployee.Role = txtRole.Text.Trim();
            tempEmployee.Salary = decimal.Parse(txtSalary.Text.Trim());
            tempEmployee.HireDate = Convert.ToDateTime(dpHireDate.SelectedDate.Value.Date.ToShortDateString());

            return tempEmployee;
        }

        //method to clear employee details 
        public void mtdClearEmployeeDetails()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtTelephone.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
            txtRole.Text = "";
            dpHireDate.SelectedDate = null;
        }
    }
}

