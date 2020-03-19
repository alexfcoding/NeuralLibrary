﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Network
    {
        public int LayersCount { get; set; }
        public List<Layer> Layers { get; set; }
        public int inputNeuronCount { get; set; }
        public int hiddenNeuronCount { get; set; }
        public int outputNeuronCount { get; set; }

        Random randomWeight;

        public Network ()
        {
            Layers = new List<Layer>();
            randomWeight = new Random();
        }

        public void FillInputLayer (int inputNeuronCount)
        {
            Layer inputLayer = new Layer();

            for (int i = 0; i < inputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(3, NeuronType.Input, randomWeight);
                inputLayer.Neurons.Add(neuron);
            }

            Layers.Add(inputLayer);
        }

        public void FillHiddenLayer(int hiddenNeuronCount)
        {
            Layer hiddenLayer = new Layer();

            for (int i = 0; i < hiddenNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(3, NeuronType.Hidden, randomWeight);
                hiddenLayer.Neurons.Add(neuron);
            }

            Layers.Add(hiddenLayer);
        }

        public void FillOutputLayer(int outputNeuronCount)
        {
            Layer outputLayer = new Layer();

            for (int i = 0; i < outputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateWeights(3, NeuronType.Hidden, randomWeight);
                outputLayer.Neurons.Add(neuron);
            }

            Layers.Add(outputLayer);
        }

        public void SendSignalsToFirstLayer(double[] inputSignalAmplitude)
        {
            for (int i = 0; i < Layers[0].Neurons[0].Weights.Length; i++)
            {
                Layers[0].Neurons[i].OutputSignal = inputSignalAmplitude[i];
            }
        }

        public void MoveNeuronSignal ()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                for (int k = 0; k < Layers[i-1].Neurons.Count; k++)
                {
                    for (int j = 0; j < Layers[i].Neurons.Count; j++)
                    {
                        Layers[i].Neurons[k].OutputSignal += Layers[i - 1].Neurons[j].OutputSignal * Layers[i - 1].Neurons[j].Weights[k];
                    }
                }                
            }
        }
    }
}
