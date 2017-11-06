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
        public User currentUser;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Libary.SeanDBDataSet seanDBDataSet = ((Libary.SeanDBDataSet)(this.FindResource("seanDBDataSet")));
            // Load data into the table User. You can modify this code as needed.
            Libary.SeanDBDataSetTableAdapters.UserTableAdapter seanDBDataSetUserTableAdapter = new Libary.SeanDBDataSetTableAdapters.UserTableAdapter();
            seanDBDataSetUserTableAdapter.Fill(seanDBDataSet.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }
    }
}
