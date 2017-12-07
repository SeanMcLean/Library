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
    /// Interaction logic for MemberAdd.xaml
    /// </summary>
    public partial class MemberAdd : Page
    {
        DBEntities db = new DBEntities();

        public MemberAdd()
        {
            InitializeComponent();
        }
        //method to add member
        public void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            //check if all inputs are full
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text)
            & !string.IsNullOrWhiteSpace(txtLastName.Text)
            & !string.IsNullOrWhiteSpace(txtAddress1.Text)
            & !string.IsNullOrWhiteSpace(txtAddress2.Text)
            & !string.IsNullOrWhiteSpace(txtAddress3.Text)
            & !string.IsNullOrWhiteSpace(txtClassification.Text))
            {
                //call methods to add Publisher 
                mtdAddMember();
                //Inform user that details have been added 
                MessageBox.Show("New Member Added");
                //clear old textbox data
                mtdClearMemberDetails();

            }
            //check to see if  Name text box is empty
            else if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Missing First Name");
            }
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
            //check to see if Classification text box is empty
            else if (string.IsNullOrWhiteSpace(txtClassification.Text))
            {
                MessageBox.Show("Missing Classification");
            }
        }
        //method to add new member to database
        public void mtdAddMember()
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
        //Method to retrieve user details from data fields 
        public Member GetUserDetails()
        {
            Member tempMember = new Member();

            tempMember.MemberId = Guid.NewGuid().ToString();
            tempMember.FirstName = txtFirstName.Text.Trim();
            tempMember.LastName = txtLastName.Text.Trim();
            tempMember.Classification = txtClassification.Text.Trim();
            tempMember.Address = txtAddress1.Text.Trim() + " " + txtAddress2.Text.Trim() + " " + txtAddress3.Text.Trim();
            tempMember.TransactionHistoryTotal = 0;
            return tempMember;
        }

        //method to clear data fields 
        public void mtdClearMemberDetails()
        {
            //clear all textboxes of values
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtClassification.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
        }
    }
}

