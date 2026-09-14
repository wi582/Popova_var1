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
            // Разбиваем строку на числа
            string[] parts = txtInput.Text.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                txtResult.Text = "Введите числа!";
                return;
            }

            // Группируем числа по ключу (отсортированные цифры)
            Dictionary<string, List<string>> groups =
                new Dictionary<string, List<string>>();

            foreach (string s in parts)
            {
                // Проверка, что это число
                int num;
                if (!int.TryParse(s, out num))
                    continue;

                // Строим ключ: цифры числа, отсортированные по возрастанию
                char[] digits = Math.Abs(num).ToString().ToCharArray();
                Array.Sort(digits);
                string key = new string(digits);

                if (!groups.ContainsKey(key))
                    groups[key] = new List<string>();

                groups[key].Add(s);
            }

            // Выводим только группы, где больше 1 числа
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

