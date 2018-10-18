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
        }

        public AddComputer(ViewModel.ComputerViewModel model)
        {
            InitializeComponent();
          
            
        }

        private void addSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ComputerViewModel wnd = new ViewModel.ComputerViewModel();
            DataContext = new ViewModel.ComputerViewModel().SaveToDatabase();
            wnd.SaveToDatabase();
           
        }
    }
}
