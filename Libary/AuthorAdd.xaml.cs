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

        public AuthorAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mtdAddAuthor();
            MessageBox.Show("New Author Added");
            mtdClearAuthorDetails();

            //  dash.refresAuthorGrid();

        }

        private void mtdAddAuthor()
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

        private Author GetUserDetails()
        {
            Author tempAuthor = new Author();

            tempAuthor.AuthorId = Guid.NewGuid().ToString();
            tempAuthor.AuthorName = txtName.Text.Trim();

            return tempAuthor;
        }

        private void mtdClearAuthorDetails()
        {
            txtName.Text = "";
        }

    }
}
