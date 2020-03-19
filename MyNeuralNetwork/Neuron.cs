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
        public double Power { get; set; }
                
        public void GenerateWeights (int weightCount, NeuronType neuronType, Random randomWeight)
        {
            Weights = new double[weightCount];

            Random rndNum = new Random();
            
            for (int i = 0; i < weightCount; i++)
            {
                Weights[i] = randomWeight.NextDouble();
                //Weights[i] = 1;
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
                for (int i = 0; i < Weights.Length; i++)
                {
                    OutputSignal += inputSignal * Weights[i];
                }
            }
        }


    }
}
