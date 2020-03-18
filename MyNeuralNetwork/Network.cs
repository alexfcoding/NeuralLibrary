using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Network
    {
        public int LayersCount { get; set; }
        public List<Layer> LayerList { get; set; }
        public int inputNeuronCount { get; set; }
        public int hiddenNeuronCount { get; set; }
        public int outputNeuronCount { get; set; }
        
        public Network ()
        {
            LayerList = new List<Layer>();
        }

        public void FillInputLayer (int inputNeuronCount)
        {
            Layer inputLayer = new Layer();

            for (int i = 0; i < inputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateRandomWeights(3, NeuronType.Input);
                inputLayer.NeuronList.Add(neuron);
            }

            LayerList.Add(inputLayer);
        }

        public void FillHiddenLayer(int hiddenNeuronCount)
        {
            Layer hiddenLayer = new Layer();

            for (int i = 0; i < hiddenNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateRandomWeights(3, NeuronType.Hidden);
                hiddenLayer.NeuronList.Add(neuron);
            }

            LayerList.Add(hiddenLayer);
        }

        public void FillOutputLayer(int outputNeuronCount)
        {
            Layer outputLayer = new Layer();

            for (int i = 0; i < outputNeuronCount; i++)
            {
                Neuron neuron = new Neuron();
                neuron.GenerateRandomWeights(3, NeuronType.Hidden);
                outputLayer.NeuronList.Add(neuron);
            }

            LayerList.Add(outputLayer);
        }
    }
}
