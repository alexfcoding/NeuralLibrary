using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Neuron
    {
        public double[] InputSignal { get; set; }
        public double[] inputWeights { get; set; }
        public String Type { get; set; }
        
        public void GenerateRandomWeights (int weightCount, NeuronType neuronType)
        {
            inputWeights = new double[weightCount];
            double randomWeight;
            Random rndNum = new Random();

            for (int i = 0; i < weightCount; i++)
            {
                randomWeight = rndNum.NextDouble();

                if (neuronType == NeuronType.Input)
                    inputWeights[i] = 1;
                else
                    inputWeights[i] = randomWeight;
            }
        }

        public void CalculateOutputSignal (double[] inputWeights, double[] inputSignals) 
        {
            double outputSignal = 0;
            for (int i = 0; i < inputWeights.Length; i++)
            {
                outputSignal += inputSignals[i] * inputWeights[i];
            }
        }

    }
}
