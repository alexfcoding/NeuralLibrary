using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace MyNeuralNetwork
{
    public class Network
    {
        public List<Layer> Layers { get; set; }
        public double LearningRate { get; set; }
        public double[] Targets { get; set; }
        public double[] CurrentNetworkOutput { get; set; }
        public double[] CurrentNetworkOutputError { get; set; }
        public double[] testResults { get; set; }
        public double ErrorTarget { get; set; }
        public List<double> signalParamsList { get; set; }

        Random randomWeight;

        public Network(int outputNeurons, double learningRate)
        {
            Layers = new List<Layer>();
            randomWeight = new Random();

            CurrentNetworkOutput = new double[outputNeurons];
            CurrentNetworkOutputError = new double[outputNeurons];
            Targets = new double[outputNeurons];
            testResults = new double[outputNeurons];

            LearningRate = learningRate;
            signalParamsList = new List<double>();
            
        }

        public void CreateInputLayer(int inputNeuronCount, int weightsCount)
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

        public void CreateHiddenLayers(int hiddenNeuronCount, int weightsCount)
        {
            Layer hiddenLayer = new Layer();

            for (int i = 0; i < hiddenNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(weightsCount, randomWeight);
                hiddenLayer.Neurons.Add(neuron);
            }

            Layers.Add(hiddenLayer);
        }

        public void CreateOutputLayer(int outputNeuronCount, int weightsCount)
        {
            Layer outputLayer = new Layer();

            for (int i = 0; i < outputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(weightsCount, randomWeight);
                outputLayer.Neurons.Add(neuron);
            }

            Layers.Add(outputLayer);
        }

        public void SendSignalsToInputLayer(double[] inputSignalAmplitude)
        {
            for (int i = 0; i < Layers[0].Neurons.Count; i++)
            {
                Layers[0].Neurons[i].OutputSignal = inputSignalAmplitude[i];
            }
        }

        public double[] ForwardPropagation()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++)
                {
                    
                    for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                    {
                        Layers[i].Neurons[k].OutputSignal += Layers[i - 1].Neurons[j].OutputSignal * Layers[i - 1].Neurons[j].Weights[k];
                    }

                    Layers[i].Neurons[k].OutputSignal = Sigmoid(Layers[i].Neurons[k].OutputSignal + Layers[i].Neurons[k].bias);

                    if (i == Layers.Count - 1)
                    {
                        CurrentNetworkOutput[k] = Layers[i].Neurons[k].OutputSignal;
                    }
                }
            }

            return CurrentNetworkOutput;
        }

        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void FindNetworkOutputError()
        {
            for (int i = 0; i < Layers[Layers.Count - 1].Neurons.Count; i++)
            {
                CurrentNetworkOutputError[i] = ((Targets[i] - CurrentNetworkOutput[i]));
                Layers[Layers.Count - 1].Neurons[i].Error = CurrentNetworkOutputError[i];
            }
        }

        public void NeuronErrorDistribution()
        {
            for (int i = Layers.Count - 1; i > 0; i--) // layers
            {
                for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                {
                    for (int k = 0; k < Layers[i - 1].Neurons[j].Weights.Length; k++)
                    {
                        Layers[i - 1].Neurons[j].Error += Layers[i - 1].Neurons[j].Weights[k] * Layers[i].Neurons[k].Error;
                    }
                }
            }
        }

        public void NeuronErrorDistributionTest()
        {
            // Weights error distribution
            double weightsSum = 0;

            for (int i = Layers.Count - 1; i > 0; i--) // layers
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++) // neurons
                {
                    for (int w = 0; w < Layers[i - 1].Neurons.Count; w++)
                    {
                        weightsSum += Layers[i - 1].Neurons[w].Weights[k];
                    }

                    for (int j = 0; j < Layers[i - 1].Neurons.Count; j++) // it was Layers[i - 1]
                    {
                        Layers[i - 1].Neurons[j].WeightErrorDistribution[k] = (Layers[i - 1].Neurons[j].Weights[k]) / (weightsSum) * Layers[i].Neurons[k].Error;
                    }

                    weightsSum = 0;
                }

                //Neuron Error Distribution

                for (int j = 0; j < Layers[i - 1].Neurons.Count; j++)
                {
                    for (int w = 0; w < Layers[i - 1].Neurons[j].Weights.Length; w++)
                    {
                        Layers[i - 1].Neurons[j].Error += Layers[i - 1].Neurons[j].WeightErrorDistribution[w];
                    }
                }
            }
        }

        public void RecalculateWeights()
        {
            double WijSum = 0;

            for (int i = Layers.Count - 1; i > 0; i--) // layers
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++) // neurons
                {
                    for (int j = 0; j < Layers[i - 1].Neurons.Count; j++) // neurons
                    {
                        WijSum += Layers[i - 1].Neurons[j].Weights[k] * Layers[i - 1].Neurons[j].OutputSignal;
                    }

                    for (int m = 0; m < Layers[i - 1].Neurons.Count; m++)
                    {
                        Layers[i - 1].Neurons[m].Weights[k] += LearningRate * (Layers[i].Neurons[k].Error) * Layers[i].Neurons[k].OutputSignal * (1 - Layers[i].Neurons[k].OutputSignal) * Layers[i - 1].Neurons[m].OutputSignal;
                        Layers[i - 1].Neurons[m].bias += LearningRate * (Layers[i].Neurons[k].Error) * Layers[i].Neurons[k].OutputSignal * (1 - Layers[i].Neurons[k].OutputSignal) * Layers[i - 1].Neurons[m].OutputSignal;
                    }

                    WijSum = 0;
                }
            }
        }

        public void CleanOldData()
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                for (int j = 0; j < Layers[i].Neurons.Count; j++)
                {
                    Layers[i].Neurons[j].OutputSignal = 0;
                    Layers[i].Neurons[j].Error = 0;
                }
            }
        }

        public double[] TestRecognitionRate()
        {
            double testCount = 100;
            testResults = new double[signalParamsList.Count];
            int imageIndex = 1;

            for (int i = 0; i < signalParamsList.Count; i++)
            {
                for (int j = 0; j < testCount; j++)
                { 
                    Signal signal = new Signal(Layers[0].Neurons.Count);
                    
                    signal.ImageFromFile($@"C:\mnist_png\testing\{i}\" + imageIndex.ToString() + ".png");
                    imageIndex++;

                    SendSignalsToInputLayer(signal.Amplitude);
                    ForwardPropagation();
                    FindNetworkOutputError();
                    
                    double maxPower = CurrentNetworkOutput[0];
                    double maxIndex = 0;

                    for (int k = 0; k < CurrentNetworkOutput.Length; k++)
                    {
                        if (CurrentNetworkOutput[k] > maxPower)
                        {
                            maxPower = CurrentNetworkOutput[k];
                            maxIndex = k;
                        }
                    }

                    if (maxIndex == i)
                    {
                        testResults[i]++;
                    }

                    CleanOldData();
                }
            }

            for (int i = 0; i < signalParamsList.Count; i++)
            {
                testResults[i] = testResults[i] / testCount * 100;
            }

            return testResults;
        }
    }
}
