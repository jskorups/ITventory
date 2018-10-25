using ITventory_v2.ViewModel;
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

namespace ITventory_v2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void addNewMainBtn_click(object sender, RoutedEventArgs e)
        {
            View.chooser chos = new View.chooser();
            chos.ShowDialog();
        }

        

        private void EditViewGrid_Click(object sender, RoutedEventArgs e)
        {
            databaseViewEditGrid edt = new databaseViewEditGrid(new ComputerViewModel().ListOfDevices());
           // databaseViewEditGrid edt = new databaseViewEditGrid();
            edt.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
