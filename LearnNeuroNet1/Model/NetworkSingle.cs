using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNeuroNet1.Model
{
    /// <summary>
    /// Модель сети с 1 слоем
    /// </summary>
    public class NetworkSingle
    {
        public List<Neuron> Layer1 { get; set; }

        //скорость обучения
        private double corrector = 0.01;

        public NetworkSingle()
        {
            Layer1 = new List<Neuron>();
            Layer1.Add(new Neuron());
        }

        /// <summary>
        /// Заполняем веса случайными значениями от 1,00 до 2,00
        /// </summary>
        public void InitializeWeights(int inputNum)
        {
            Layer1[0].Weights = new double[inputNum];
            Random rnd = new Random();
            for (int i = 0; i < inputNum; i++)
            {
                Layer1[0].Weights[i] = rnd.Next(100, 200) * 0.01;
            }
        }

        /// <summary>
        /// Обучение сети
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="outputs"></param>
        public void Train(int[][] inputs, int[] outputs, int generations)
        {
            double output = 0;
            double error = 0;
            double[] adjustment = new double[inputs[0].Length];

            //Обучение состоит из определенного количества поколений
            for (int i = 0; i < generations; i++)
            {
                //в каждом поколении сеть должна пройтись по каждому из наборов входных значений
                for (int j = 0; j < inputs.Length; j++)
                {
                    //получить результат для каждого из наборов входных значений
                    output = Think(inputs[j]);
                    //высчитать ошибку
                    error = outputs[j] - output;
                    //скорректировать веса в соответствии с ошибкой
                    for (int k = 0; k < inputs[j].Length; k++)
                    {
                        Layer1[0].Weights[k] += corrector * inputs[j][k] * error;
                    }
                }
            }
        }

        /// <summary>
        /// Анализ данных нейронной сетью
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public double Think(int[] inputs)
        {
            double output = 0;

            for (int i = 0; i < Layer1.Count; i++)
            {
                Layer1[i].InputSignals = inputs;
                Layer1[i].Sum();
                //вот как выходной результат считать, когда будет больше 1 нейрона на последнем слое, не представляю
                output += Layer1[i].Output;
            }

            return output;
        }
    }
}
