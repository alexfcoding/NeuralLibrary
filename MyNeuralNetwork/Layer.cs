using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Layer
    {
        public int NeuronCount { get; set; }
        public List<Neuron> NeuronList { get; set; }

        public Layer ()
        {
            NeuronList = new List<Neuron>();
        }
        public void AddNeuron(Neuron neuron)
        {
            NeuronList.Add(neuron);
        }
        
    }
}
