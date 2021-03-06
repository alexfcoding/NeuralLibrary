﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    public class Neuron
    {
        public double OutputSignal { get; set; }
        public double[] Weights { get; set; }
        public double[] WeightErrorDistribution { get; set; }
        public double Error { get; set; }
        public double bias { get; set; }

        public void GenerateWeights (int weightCount, Random randomWeight)
        {
            Weights = new double[weightCount];
            
            WeightErrorDistribution = new double[weightCount];
            
            for (int i = 0; i < weightCount; i++)
            {
                double mean = 0;
                double stdDev = 0.3;
                MathNet.Numerics.Distributions.Normal normalDist = new MathNet.Numerics.Distributions.Normal(mean, stdDev);
                double randomGaussianValue = normalDist.Sample();
                //randomGaussianValue = randomWeight.NextDouble() - 0.5;
                //randomGaussianValue = 1;
                Weights[i] = randomGaussianValue;
                bias = randomGaussianValue;
            }
        }
    }
}
