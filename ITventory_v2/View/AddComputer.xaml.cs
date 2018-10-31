using ITventory_v2.Interfaces;
using ITventory_v2.Models;
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
    /// Logika interakcji dla klasy AddComputer.xaml
    /// </summary>
    public partial class AddComputer : Window
    {
        
        public AddComputer()
        {
            InitializeComponent();
            DataContext = new ViewModel.ComputerViewModel();
            uzytkownicyLista.ItemsSource = new ViewModel.ComputerViewModel().ListOfNames();
        }

        public AddComputer(ViewModel.ComputerViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }

        public AddComputer(IDevices device)
        {
            InitializeComponent();
            DataContext = device;
            if (device.GetType() == typeof(ViewModel.ComputerViewModel)) { MessageBox.Show("Huraa to komputer"); }
        }

        private void addSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ComputerViewModel wnd = (ViewModel.ComputerViewModel)DataContext;
            wnd.SaveToDatabase();
            this.Close();
        }
    }
}
