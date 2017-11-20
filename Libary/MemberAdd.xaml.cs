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
        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            mtdAddMember();
            MessageBox.Show("New Member Added");
            mtdClearMemberDetails();

        }

        private void mtdAddMember()
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

        private Member GetUserDetails()
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

        private void mtdClearMemberDetails()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtClassification.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
        }
    }
}

