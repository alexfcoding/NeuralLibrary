using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Network
    {
        public List<Layer> Layers { get; set; }
        public double[] CurrentNetworkOutput { get; set; }
        
        Random randomWeight;

        public Network ()
        {
            Layers = new List<Layer>();
            randomWeight = new Random();
        }

        public void FillInputLayer (int inputNeuronCount, int weightsCount)
        {
            Layer inputLayer = new Layer();

            for (int i = 0; i < inputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(weightsCount, randomWeight);
                inputLayer.Neurons.Add(neuron);
            }

            Layers.Add(inputLayer);
        }

        public void FillHiddenLayer(int hiddenNeuronCount, int weightsCount)
        {
            Layer hiddenLayer = new Layer();

            for (int i = 0; i < hiddenNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(3, randomWeight);
                hiddenLayer.Neurons.Add(neuron);
            }

            Layers.Add(hiddenLayer);
        }

        public void FillOutputLayer(int outputNeuronCount, int weightsCount)
        {
            Layer outputLayer = new Layer();

            for (int i = 0; i < outputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(3, randomWeight);
                outputLayer.Neurons.Add(neuron);
            }

            Layers.Add(outputLayer);
        }

        public void SendSignalsToFirstLayer(double[] inputSignalAmplitude)
        {
            for (int i = 0; i < Layers[0].Neurons.Count; i++)
            {
                Layers[0].Neurons[i].OutputSignal = inputSignalAmplitude[i];
            }
        }

        public double[] ForwardPropagation ()
        {
            double[] currentNetworkOutput = new double[Layers[Layers.Count - 1].Neurons.Count];

            for (int i = 1; i < Layers.Count; i++)
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++)
                {
                    for (int j = 0; j < Layers[i-1].Neurons.Count; j++)
                    {
                        Layers[i].Neurons[k].OutputSignal += Layers[i - 1].Neurons[j].OutputSignal * Layers[i - 1].Neurons[j].Weights[k];
                    }
                    
                    Layers[i].Neurons[k].OutputSignal = Sigmoid(Layers[i].Neurons[k].OutputSignal);
                    
                    if (i == Layers.Count - 1)
                    {
                        currentNetworkOutput[k] = Layers[i].Neurons[k].OutputSignal;
                    }
                }                
            }

            return currentNetworkOutput;
        }

        public double Sigmoid (double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void CheckHiddenOutputError (double[] currentNetworkOutput, double[] trainingTargets)
        {
            double[] hiddenOutputError = new double[currentNetworkOutput.Length];

            for (int i = 0; i < currentNetworkOutput.Length; i++)
            {
                hiddenOutputError[i] = trainingTargets[i] - currentNetworkOutput[i];
            }
        }

        public void NeuronErrorDistribution()
        {
            double weightsSum = 0;

            for (int layerId = Layers.Count - 1; layerId > 1; layerId--) // layers
            {
                for (int neuronId = 0; neuronId < Layers[layerId].Neurons.Count; neuronId++) // neurons
                {
                    for (int weightId = 0; weightId < Layers[layerId - 1].Neurons.Count; weightId++) // weights
                    {
                        for (int weightSumId = 0; weightSumId < Layers[layerId - 1].Neurons.Count; weightSumId++)
                        {
                            weightsSum += Layers[layerId - 1].Neurons[weightSumId].Weights[neuronId];
                        }

                        Layers[layerId - 1].Neurons[neuronId].WeightErrorDistribution[weightId] = (Layers[layerId - 1].Neurons[weightId].Weights[neuronId]) / (weightsSum);
                        weightsSum = 0;
                    }
                }
            }
        }
    }
}
