using System;
using System.Windows.Forms;
using NeuralLibrary;

namespace NetworkApprox
{
    public partial class ApproxForm : Form
    {       
        public ApproxForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            double learningRate = Convert.ToDouble(learnRateTextBox.Text);

            Network network = new Network(1, learningRate);
            Random rnd = new Random();

            int inputNeurons = 1;
            int[] hiddenLayers = { 100, 10 };
            int outputNeurons = 1;
            int iterations = 1000;

            network.CreateInputLayer(inputNeurons, hiddenLayers[0]);
            network.CreateHiddenLayers(hiddenLayers, outputNeurons);
            network.CreateOutputLayer(outputNeurons, 0);          

            double time = 0;
            double[] amplitude = new double[400];           
            double[] inputSignal = new double[1]; 
            
            int freq = rnd.Next(50, 100);
            int modifier = rnd.Next(2, 2 + Convert.ToInt32(freqTextBox.Text));

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 0; i < 400; i += 1)
            {
                time += 0.0001;
                amplitude[i] = (Math.Sin(time * freq + modifier) + Math.Sin(time * freq * modifier) + Math.Sin(time * freq * 5) + 3) / 6;
                chart1.Series[0].Points.AddXY(i, amplitude[i]);
            }

            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < 400; j++)
                {                    
                    network.Targets[0] = amplitude[j];
                    inputSignal[0] = amplitude[j];                    
                    network.SendSignalsToInputLayer(inputSignal); // Send signal to input layer  
                    network.Pass();
                    chart1.Series[1].Points.AddXY(j, network.CurrentNetworkOutput[0]);
                }
                               
                Application.DoEvents();
                chart1.Series[1].Points.Clear();
            }
            MessageBox.Show("Ready");
        }
    }
}
