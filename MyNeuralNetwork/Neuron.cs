using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Neuron
    {
        public double OutputSignal { get; set; }
        public double[] Weights { get; set; }
        public double[] WeightErrorDistribution { get; set; }

        public void GenerateWeights (int weightCount, Random randomWeight)
        {
            Weights = new double[weightCount];

            WeightErrorDistribution = new double[weightCount];
            
            for (int i = 0; i < weightCount; i++)
            {
                //Weights[i] = randomWeight.NextDouble();
                Weights[i] = randomWeight.NextDouble();
                //Weights[i] = 1;
            }
        }
    }
}
