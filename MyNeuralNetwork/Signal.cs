using System;
using System.Drawing;

namespace MyNeuralNetwork
{
    class Signal
    {
        public double[] Amplitude { get; set; }
        public double samplesCount { get; set; }
        public String ImagePath { get; set; }
        public Bitmap image { get; set; }

        Random rndAmplitude = new Random();
        
        public Signal (int samplesCount)
        {
            Amplitude = new double[samplesCount];
            this.samplesCount = samplesCount;
        }

        public void GenerateSinus(double freq)
        {
            double time = 0;

            for (int i = 0; i < samplesCount; i += 1)
            {
                time += 0.01;
                Amplitude[i] = Math.Sin(time * freq) + Math.Sin(4 * time * freq); //+ rndAmplitude.NextDouble();
            }
            
        }

        public void GenerateImage(string imagePath)
        {
            image = new Bitmap(imagePath);
            Color clr = new Color();

            int k = 0;
            for (int i = 0; i < image.Width; i += 1)
            {
                for (int j = 0; j < image.Height; j += 1)
                {
                    clr = image.GetPixel(i, j);                    
                    Amplitude[k] = (clr.R * 0.21 + clr.G * 0.587 + clr.B * 0.114) / 255 + 0.05;
                    
                    if (Amplitude[k] > 1)
                        Amplitude[k] = 0.99;
                    
                    k++;
                }
            }
        }
    }
}
