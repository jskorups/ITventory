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
using ITventory_v2.Interfaces;

namespace ITventory_v2
{
    /// <summary>
    /// Interaction logic for databaseViewEditGrid.xaml
    /// </summary>
    public partial class databaseViewEditGrid : Window
    {
        public databaseViewEditGrid(List<IDevices> lista)
        {
            InitializeComponent();
            DataContext = lista;
        }
        public databaseViewEditGrid()
        { 
            InitializeComponent();
            DataContext = new ViewModel.ComputerViewModel().ListOfDevices();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Interfaces.IDevices urzadzenie = ((Interfaces.IDevices)namedataGrid.SelectedItem);
            AddComputer d = new AddComputer(urzadzenie);
            d.ShowDialog();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
