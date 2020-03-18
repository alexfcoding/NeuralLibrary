using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Signal
    {
        public double Amplitude { get; set; }

        Signal ()
        {
            Random rndAmplitude = new Random();
            Amplitude = rndAmplitude.NextDouble();            
        }
    }
}
