using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Layer
    {
        public List<Neuron> Neurons { get; set; }

        public Layer ()
        {
            Neurons = new List<Neuron>();
        }
        
    }
}
