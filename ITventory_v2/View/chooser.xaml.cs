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

namespace ITventory_v2.View
{
    /// <summary>
    /// Interaction logic for chooser.xaml
    /// </summary>
    public partial class chooser : Window
    {
        public chooser()
        {
            InitializeComponent();
        }

        private void chooserCpu_Click(object sender, RoutedEventArgs e)
        {
            AddComputer addWnd = new AddComputer();
            addWnd.ShowDialog();

        }

        private void chooserPhone_Click(object sender, RoutedEventArgs e)
        {
            AddPhone addWnd = new AddPhone();
            addWnd.ShowDialog();
        }

        private void chooserPrinter_Click(object sender, RoutedEventArgs e)
        {
            AddPrinter addWnd = new AddPrinter();
            addWnd.ShowDialog();
        }
    }
}
