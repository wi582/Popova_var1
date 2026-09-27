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
    /// Логика взаимодействия для Task1Page.xaml
    /// </summary>
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text.Trim();

            if (input.Length == 0)
            {
                txtResult.Text = "Ошибка: введите число!";
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '0' && input[i] != '1')
                {
                    txtResult.Text = "Ошибка: только 0 и 1!";
                    return;
                }
            }

            int remainder = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int bit = input[i] - '0';
                remainder = (remainder * 2 + bit) % 15;
            }

            if (remainder == 0)
                txtResult.Text = "Число делится на 15.";
            else
                txtResult.Text = "Число НЕ делится на 15.";
        }
    }
}

