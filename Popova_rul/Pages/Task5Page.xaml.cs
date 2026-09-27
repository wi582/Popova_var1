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
    /// Логика взаимодействия для Task5Page.xaml
    /// </summary>
    public partial class Task5Page : Page
    {
        private Random rnd = new Random();
        public Task5Page()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n, m;
            if (!int.TryParse(txtN.Text, out n) ||
                !int.TryParse(txtM.Text, out m))
            {
                MessageBox.Show("N и M должны быть числами!");
                return;
            }

            if (n <= 0 || m <= 0)
            {
                MessageBox.Show("N и M должны быть больше 0!");
                return;
            }

            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = rnd.Next(-10, 11); 

            txtOriginal.Text = MatrixToString(matrix);

            int[] flat = new int[n * m];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    flat[k++] = matrix[i, j];

            int[] asc = (int[])flat.Clone();
            Array.Sort(asc);

            int[] desc = (int[])flat.Clone();
            Array.Sort(desc);
            Array.Reverse(desc);

            txtAsc.Text = MatrixToString(ArrayToMatrix(asc, n, m));
            txtDesc.Text = MatrixToString(ArrayToMatrix(desc, n, m));

            int min = flat[0];
            int max = flat[0];
            for (int i = 1; i < flat.Length; i++)
            {
                if (flat[i] < min) min = flat[i];
                if (flat[i] > max) max = flat[i];
            }

            txtMinMax.Text = $"Минимум = {min}, Максимум = {max}";
        }

        private string MatrixToString(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sb.Append(matrix[i, j].ToString().PadLeft(5));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private int[,] ArrayToMatrix(int[] arr, int n, int m)
        {
            int[,] matrix = new int[n, m];
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = arr[k++];
            return matrix;
        }
    }
}