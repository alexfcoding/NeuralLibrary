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
        public double[] inputWeights { get; set; }
        public double Power { get; set; }
        public String Type { get; set; }
                
        public void GenerateWeights (int weightCount, NeuronType neuronType, Random randomWeight)
        {
            inputWeights = new double[weightCount];

            Random rndNum = new Random();

            for (int i = 0; i < weightCount; i++)
            {
                if (neuronType == NeuronType.Input)
                    inputWeights[i] = 1;
                else
                    inputWeights[i] = randomWeight.NextDouble();
            }
        }

        public void  CalculateOutputSignal (double inputSignal, NeuronType neuronType) 
        {
            if (neuronType == NeuronType.Input)
            {
                OutputSignal = inputSignal;
            }
            else
            {
                for (int i = 0; i < inputWeights.Length; i++)
                {
                    OutputSignal += inputSignal * inputWeights[i];
                }
            }
                
           
        }

    }
}
