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
    /// Логика взаимодействия для Task4Page.xaml
    /// </summary>
    public partial class Task4Page : Page
    {
        public Task4Page()
        {
            InitializeComponent();
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            // Считываем массив
            string[] parts = txtArray.Text.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            int[] x = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out x[i]))
                {
                    txtResult.Text = "Ошибка ввода чисел!";
                    return;
                }
            }

            // Считываем m и n
            int m, n;
            if (!int.TryParse(txtM.Text, out m) ||
                !int.TryParse(txtN.Text, out n))
            {
                txtResult.Text = "Ошибка: m или n не число!";
                return;
            }

            if (m + n != x.Length)
            {
                txtResult.Text = $"Ошибка: m + n = {m + n}, а длина массива = {x.Length}";
                return;
            }

            // Запоминаем исходный массив
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Исходный массив: " + string.Join(" ", x));

            // Алгоритм трёх переворотов
            Reverse(x, 0, x.Length - 1);   // 1. весь массив
            Reverse(x, 0, n - 1);          // 2. первые n
            Reverse(x, n, x.Length - 1);   // 3. последние m

            sb.AppendLine("Результат: " + string.Join(" ", x));
            sb.AppendLine();
            sb.AppendLine($"Начало (m={m}): {string.Join(" ", SubArray(x, 0, m))}");
            sb.AppendLine($"Конец  (n={n}): {string.Join(" ", SubArray(x, m, n))}");

            txtResult.Text = sb.ToString();
        }

        // Переворот части массива от left до right включительно
        private void Reverse(int[] arr, int left, int right)
        {
            while (left < right)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        // Вспомогательный метод — кусок массива
        private int[] SubArray(int[] arr, int start, int count)
        {
            int[] result = new int[count];
            for (int i = 0; i < count; i++)
                result[i] = arr[start + i];
            return result;
        }
    }
}