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
        public User currentUser;

        System.Data.OleDb.OleDbDataAdapter dataAdapter;

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

            Libary.SeanDBDataSet1 seanDBDataSet1 = ((Libary.SeanDBDataSet1)(this.FindResource("seanDBDataSet1")));
            // Load data into the table Item. You can modify this code as needed.
            Libary.SeanDBDataSet1TableAdapters.ItemTableAdapter seanDBDataSet1ItemTableAdapter = new Libary.SeanDBDataSet1TableAdapters.ItemTableAdapter();
            seanDBDataSet1ItemTableAdapter.Fill(seanDBDataSet1.Item);
            System.Windows.Data.CollectionViewSource itemViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemViewSource")));
            itemViewSource.View.MoveCurrentToFirst();


            Libary.SeanDBDataSetPublisher seanDBDataSetPublisher = ((Libary.SeanDBDataSetPublisher)(this.FindResource("seanDBDataSetPublisher")));
            // Load data into the table Publisher. You can modify this code as needed.
            Libary.SeanDBDataSetPublisherTableAdapters.PublisherTableAdapter seanDBDataSetPublisherPublisherTableAdapter = new Libary.SeanDBDataSetPublisherTableAdapters.PublisherTableAdapter();
            seanDBDataSetPublisherPublisherTableAdapter.Fill(seanDBDataSetPublisher.Publisher);
            System.Windows.Data.CollectionViewSource publisherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("publisherViewSource")));
            publisherViewSource.View.MoveCurrentToFirst();
        }

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
 

        }
    }
}