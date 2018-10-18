﻿using ITventory_v2.Models;
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

namespace ITventory_v2
{
    /// <summary>
    /// Logika interakcji dla klasy AddDatabase.xaml
    /// </summary>
    public partial class AddDatabase : Window
    {
        
        public AddDatabase()
        {
            InitializeComponent();
        }

        public AddDatabase(ViewModel.ComputerViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        private void addSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ComputerViewModel wnd = new ViewModel.ComputerViewModel();
            wnd.SaveToDatabase();
        }
    }
}
