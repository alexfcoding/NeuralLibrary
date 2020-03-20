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

        Random rndAmplitude = new Random();

        public Signal (int samplesCount)
        {
            Amplitude = new double[samplesCount];

            for (int i = 0; i < samplesCount; i++)
            {
                Amplitude[i] = rndAmplitude.Next(1,5);
            }
            
        }
        
    }
}
