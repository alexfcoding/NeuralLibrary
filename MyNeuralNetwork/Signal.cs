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

        public Signal ()
        {
            Amplitude = new double[3];

            Amplitude[0] = 2;
            Amplitude[1] = 4;
            Amplitude[2] = 8;
        }
    }
}
