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

        public EmployeeAdd()
        {
            InitializeComponent();
        }
        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            mtdAddEmployee();
            MessageBox.Show("New Employee Added");
            mtdClearEmployeeDetails();

        }

        private void mtdAddEmployee()
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

        private Employee GetUserDetails()
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

        private void mtdClearEmployeeDetails()
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
        }
    }
}

