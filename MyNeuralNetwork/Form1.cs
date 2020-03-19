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

            MyNetwork.FillInputLayer(3, 5);

            Signal signal = new Signal(5);
            MyNetwork.SendSignalsToFirstLayer(signal.Amplitude);

            MyNetwork.FillHiddenLayer(5, 3);

            MyNetwork.FillOutputLayer(3, 3);

            MyNetwork.ForwardPropagation();

            for (int i = 0; i < MyNetwork.Layers.Count; i++)
            {
                log.Items.Add($"Layer: {i}");

                for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                {
                    log.Items.Add(MyNetwork.Layers[i].Neurons[j].OutputSignal);
                }

                log.Items.Add(" ");
            }
        }
    }
}
