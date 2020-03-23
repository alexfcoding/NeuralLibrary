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

        public Signal (int samplesCount, SignalType Sinus, double freq = 100)
        {
            Amplitude = new double[samplesCount];

            if (Sinus == SignalType.Sinus)
            {
                double time = 0;

                for (int i = 0; i < samplesCount; i += 1)
                {
                    time += 0.01;
                    Amplitude[i] = Math.Sin(time * freq) + Math.Sin(4 * time * freq) + rndAmplitude.NextDouble() / 8;
                }
            }
            

        }
        
    }
}
