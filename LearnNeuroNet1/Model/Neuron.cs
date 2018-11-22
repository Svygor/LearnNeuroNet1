using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNeuroNet1.Model
{
    /// <summary>
    /// Модели нейрона
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// Список выходных сигналов
        /// </summary>
        public int[] InputSignals { get; set; }

        /// <summary>
        /// Список выходных сигналов
        /// </summary>
        public double[] Weights { get; set; }

        /// <summary>
        /// Выходной сигнал
        /// </summary>
        public double Output { get; set; }

        /// <summary>
        /// Функция, перемножающая входные значения на соответствующий им вес и считающая сумму получившихся значений
        /// </summary>
        /// <returns>сумма взвешенных (слово-то какое... взвешенных) входных значений</returns>
        public void Sum()
        {
            double sum = 0;

            //Проверяем входные данные на Null
            if (InputSignals == null)
            {
                throw new NullReferenceException("Массив входных данных не может быть Null");
            }
            if (Weights == null)
            {
                throw new NullReferenceException("Массив весов не может быть Null");
            }

            int inputsCount = InputSignals.Length;

            //перемонажем каждый входной сигнал на соотствующий ему вес
            for (int i = 0; i < inputsCount; i++)
            {
                sum += InputSignals[i] * Weights[i];
            }

            Output = sum;
        }

        /// <summary>
        /// Активационная функция
        /// </summary>
        /// <returns></returns>
        public void ActivationFunc()
        {
            Output = 1 / (1 + Math.Exp(-Output));
        }
    }
}
