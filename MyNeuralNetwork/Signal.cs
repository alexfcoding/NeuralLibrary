using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    class Signal
    {
        public double[] Amplitude { get; set; }

        public Signal (int samplesCount)
        {
            Amplitude = new double[samplesCount];

            for (int i = 0; i < samplesCount; i++)
            {
                Amplitude[i] = i;
            }
            
        }
        
    }
}
