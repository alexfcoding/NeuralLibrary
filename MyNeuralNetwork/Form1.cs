using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNeuralNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            Network MyNetwork = new Network();
            double[] targets = new double[3];
            Random rndTarget = new Random();

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = rndTarget.NextDouble();
            }

            MyNetwork.FillInputLayer(3, 3);

            Signal signal = new Signal(3);

            MyNetwork.SendSignalsToFirstLayer(signal.Amplitude);
            MyNetwork.FillHiddenLayer(3, 3);
            MyNetwork.FillOutputLayer(3, 3);

            double[] currentNetworkOut = new double[3];
            currentNetworkOut = MyNetwork.ForwardPropagation();

            MyNetwork.CheckNetworkOutputError(currentNetworkOut, targets);

            MyNetwork.NeuronErrorDistribution();

            for (int i = 0; i < MyNetwork.Layers.Count; i++)
            {
                log.Items.Add($"Layer: {i}");

                for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                {
                    log.Items.Add(MyNetwork.Layers[i].Neurons[j].OutputSignal + $" (Error: {MyNetwork.Layers[i].Neurons[j].Error})");
                }

                log.Items.Add(" ");
            }
        }
    }
}
