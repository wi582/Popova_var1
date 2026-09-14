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
    /// Логика взаимодействия для Task2Page.xaml
    /// </summary>
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text.Trim();

            if (input.Length == 0)
            {
                txtResult.Text = "0";
                return;
            }

            // Пробуем преобразовать в целое число
            int intNumber;
            if (int.TryParse(input, out intNumber))
            {
                txtResult.Text = "1";
                return;
            }

            // Пробуем преобразовать в вещественное число
            double doubleNumber;
            if (double.TryParse(input, out doubleNumber))
            {
                txtResult.Text = "2";
                return;
            }

            txtResult.Text = "0";
        }
    }
}

