﻿using System;
using System.Collections.Generic;
using System.Threading;
namespace MyNeuralNetwork
{
    public class Network
    {
        public List<Layer> Layers { get; set; }
        public double LearningRate { get; set; }
        public double[] Targets { get; set; }
        public double[] CurrentNetworkOutput { get; set; }
        public double[] CurrentNetworkOutputError { get; set; }
        public double[] squaredError { get; set; }
        public double CurrentRecognitionCount { get; set; }        
        public double[] testResults { get; set; }
        public double ErrorTarget { get; set; }
        public List<double> signalParamsList { get; set; }
        public bool isTraining { get; set; }
        public bool isValidating { get; set; }

        Random randomWeight;

        public Network(int inputNeuronCount, int[] hiddenLayersNeurons, int outputNeurons)
        {
            Layers = new List<Layer>();
            randomWeight = new Random();                    
            signalParamsList = new List<double>();            
            CurrentRecognitionCount = 0;
            isTraining = false;
            isValidating = false;
            LearningRate = 0.01;

            CreateInputLayer(inputNeuronCount, hiddenLayersNeurons[0]);
            CreateHiddenLayers(hiddenLayersNeurons, outputNeurons);
            CreateOutputLayer(outputNeurons, 0);
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

        public void CreateHiddenLayers(int[] hiddenLayersNeurons, int lastHiddenLayerNeurons)
        {
            int layersCount = hiddenLayersNeurons.Length;

            for (int layer = 0; layer < layersCount; layer++)
            {
                Layer hiddenLayer = new Layer();

                for (int i = 0; i < hiddenLayersNeurons[layer]; i++)
                {
                    Neuron neuron = new Neuron();

                    if (layer == hiddenLayersNeurons.Length-1)
                    {
                        neuron.GenerateWeights(lastHiddenLayerNeurons, randomWeight);
                    }
                    else
                    {
                        neuron.GenerateWeights(hiddenLayersNeurons[layer + 1], randomWeight);
                    }
                    
                    hiddenLayer.Neurons.Add(neuron);
                }
                Layers.Add(hiddenLayer);
            }
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

            CurrentNetworkOutput = new double[outputNeuronCount];
            CurrentNetworkOutputError = new double[outputNeuronCount];
            Targets = new double[outputNeuronCount];
            testResults = new double[outputNeuronCount];
            squaredError = new double[outputNeuronCount];
        }

        public void SetTarget(int classToTrain)
        {
            for (int k = 0; k <Targets.Length; k++)
            {
               Targets[k] = 0.01;
            }
           Targets[classToTrain] = 0.99;
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

                    Layers[i].Neurons[k].OutputSignal = Sigmoid(Layers[i].Neurons[k].OutputSignal); //+ Layers[i].Neurons[k].bias);

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
                CurrentNetworkOutputError[i] = (Targets[i] - CurrentNetworkOutput[i]);
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
            //double WijSum = 0;
           
            for (int i = Layers.Count - 1; i > 0; i--) // layers
            {
                for (int k = 0; k < Layers[i].Neurons.Count; k++) // neurons
                {
                    //for (int j = 0; j < Layers[i - 1].Neurons.Count; j++) // neurons
                    //{
                    //    WijSum += Layers[i - 1].Neurons[j].Weights[k] * Layers[i - 1].Neurons[j].OutputSignal;
                    //}

                    for (int m = 0; m < Layers[i - 1].Neurons.Count; m++)
                    {
                        Layers[i - 1].Neurons[m].Weights[k] += LearningRate * (Layers[i].Neurons[k].Error) * Layers[i].Neurons[k].OutputSignal * (1 - Layers[i].Neurons[k].OutputSignal) * Layers[i - 1].Neurons[m].OutputSignal;
                        //Layers[i - 1].Neurons[m].bias += LearningRate * (Layers[i].Neurons[k].Error) * Layers[i].Neurons[k].OutputSignal * (1 - Layers[i].Neurons[k].OutputSignal) * Layers[i - 1].Neurons[m].OutputSignal;
                    }

                    //WijSum = 0;
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

        public void Pass()
        {
            ForwardPropagation();
            FindNetworkOutputError();
            NeuronErrorDistribution();
            RecalculateWeights();
            CleanOldData();
        }
    }
}
