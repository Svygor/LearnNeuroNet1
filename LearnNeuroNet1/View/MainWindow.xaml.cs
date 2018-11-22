using System.Windows;
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
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 0, 1, 1 }
            };
            int[] outputs = new int[] { 1, 1, 0};

            network = new NetworkSingle();
            network.InitializeWeights(inputs[0].Length);
            network.Train(inputs,outputs, 10000);
            MessageBox.Show("Обучение завершено");
        }

        //По клику на Start Testing нейронная сеть должна вывести в Lable правильный ответ
        //по заданным ниже числам
        private void StartTesting_Click(object sender, RoutedEventArgs e)
        {
            //int[] inputs = new int[2];

            //if (Num1.Text == null || Num2.Text == null)
            //{
            //    MessageBox.Show("Необходимо ввести оба числа");
            //    return;
            //}
            if (network == null)
            {
                MessageBox.Show("Нужно сначала обучить сеть");
                return;
            }
            //try
            //{
            //    inputs[0] = Convert.ToInt32(Num1.Text);
            //    inputs[1] = Convert.ToInt32(Num2.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Оба введенных значения должны быть целыми числами");
            //    return;
            //}
            int[] inputs = new int[] { 1, 0, 0 };
            MessageBox.Show(network.Think(inputs).ToString());
        }
    }
}
