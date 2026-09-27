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
    /// Логика взаимодействия для Task3Page.xaml
    /// </summary>
    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string[] parts = txtInput.Text.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                txtResult.Text = "Введите числа!";
                return;
            }

            Dictionary<string, List<string>> groups =
                new Dictionary<string, List<string>>();

            foreach (string s in parts)
            {
                int num;
                if (!int.TryParse(s, out num))
                    continue;

                char[] digits = Math.Abs(num).ToString().ToCharArray();
                Array.Sort(digits);
                string key = new string(digits);

                if (!groups.ContainsKey(key))
                    groups[key] = new List<string>();

                groups[key].Add(s);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Найденные группы чисел из одних и тех же цифр:");

            bool found = false;
            foreach (var pair in groups)
            {
                if (pair.Value.Count > 1)
                {
                    found = true;
                    sb.AppendLine(string.Join(", ", pair.Value));
                }
            }

            if (!found)
                sb.AppendLine("Таких чисел нет.");

            txtResult.Text = sb.ToString();
        }
    }
}

