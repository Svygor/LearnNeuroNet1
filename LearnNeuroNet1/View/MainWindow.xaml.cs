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
using LearnNeuroNet1.Model;

namespace LearnNeuroNet1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NetworkSingle network;        

        //По клику на Start Learning обучаем нейронную сеть на заранее известных значениях
        private void StartLearning_Click(object sender, RoutedEventArgs e)
        {
            int[][] inputs = new int[][]
            {
                new int[] { 2, 3 },
                new int[] { 1, 1 },
                new int[] { 5, 2 },
                new int[] { 12, 3 }
            };
            int[] outputs = new int[] { 10, 4, 14, 30};

            network = new NetworkSingle();
            network.InitializeWeights(inputs[0].Length);
            network.Train(inputs,outputs, 10000);
            MessageBox.Show("Обучение завершено");
        }

        //По клику на Start Testing нейронная сеть должна вывести в Lable правильный ответ
        //по заданным ниже числам
        private void StartTesting_Click(object sender, RoutedEventArgs e)
        {
            int[] inputs = new int[2];

            if (Num1.Text == null || Num2.Text == null)
            {
                MessageBox.Show("Необходимо ввести оба числа");
                return;
            }
            if (network == null)
            {
                MessageBox.Show("Нужно сначала обучить сеть");
                return;
            }
            try
            {
                inputs[0] = Convert.ToInt32(Num1.Text);
                inputs[1] = Convert.ToInt32(Num2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Оба введенных значения должны быть целыми числами");
                return;
            }
            MessageBox.Show(network.Think(inputs).ToString());
        }
    }
}
