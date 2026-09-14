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

namespace Popova_rul.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void btnTask1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task1Page());
        }

        private void btnTask2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task2Page());
        }
        private void btnTask3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task3Page());
        }
        private void btnTask4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task4Page());
        }
        private void btnTask5_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Task5Page());
        }
    }
}