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
        public double[] CurrentNetworkOutputError { get; set; }

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

        public void CheckNetworkOutputError (double[] currentNetworkOutput, double[] trainingTargets)
        {
            double[] CurrentNetworkOutputError = new double[currentNetworkOutput.Length];

            for (int i = 0; i < currentNetworkOutput.Length; i++)
            {
                CurrentNetworkOutputError[i] = trainingTargets[i] - currentNetworkOutput[i];
                Layers[Layers.Count - 1].Neurons[i].Error = CurrentNetworkOutputError[i];
            }
        }

        public void NeuronErrorDistribution()
        {
            double weightsSum = 0;

            for (int i = Layers.Count - 1; i > 0; i--) // layers
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++) // neurons
                {
                    for (int j = 0; j < Layers[i - 1].Neurons.Count; j++) // neurons
                    {
                        for (int w = 0; w < Layers[i - 1].Neurons.Count; w++)
                        {
                            weightsSum += Layers[i - 1].Neurons[w].Weights[k];
                        }

                        Layers[i - 1].Neurons[j].WeightErrorDistribution[k] = (Layers[i - 1].Neurons[j].Weights[k]) / (weightsSum) * Layers[i].Neurons[k].Error;

                        weightsSum = 0;
                    }
                }

                for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                {
                    for (int w = 0; w < Layers[i].Neurons[j].Weights.Length; w++)
                    {
                        Layers[i - 1].Neurons[j].Error += Layers[i - 1].Neurons[j].WeightErrorDistribution[w];
                    }
                }
            }
        }

        public void SetNeuronError ()
        {

        }
    }
}
