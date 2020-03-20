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
            log.Items.Clear();
            Network MyNetwork = new Network(3);

            Signal signal = new Signal(3);

            MyNetwork.FillInputLayer(3, 3);
            MyNetwork.SendSignalsToFirstLayer(signal.Amplitude);
            MyNetwork.FillHiddenLayer(3, 3);
            MyNetwork.FillOutputLayer(3, 3);

            MyNetwork.ForwardPropagation();

            MyNetwork.FindNetworkOutputError();

            MyNetwork.NeuronErrorDistribution();

            PrintNetworkStats(MyNetwork, signal, MyNetwork);
        }

        private void PrintNetworkStats(Network networkToPrint, Signal inputSignal, Network MyNetwork)
        {
            log.Items.Add($"________________Targets________________ ");
            log.Items.Add("");

            for (int i = 0; i < MyNetwork.Targets.Length; i++)
            {
                log.Items.Add(MyNetwork.Targets[i]);
            }

            log.Items.Add("");

            log.Items.Add($"________________Output________________ ");
            log.Items.Add("");

            for (int i = 0; i < MyNetwork.CurrentNetworkOutput.Length; i++)
            {
                log.Items.Add(MyNetwork.CurrentNetworkOutput[i]);
            }
            log.Items.Add("");

            log.Items.Add($"________________Error________________ ");
            log.Items.Add("");

            for (int i = 0; i < MyNetwork.CurrentNetworkOutputError.Length; i++)
            {
                log.Items.Add(MyNetwork.CurrentNetworkOutputError[i]);
            }

            log.Items.Add($"________________Input signals:________________");
            log.Items.Add("");

            for (int i = 0; i < inputSignal.Amplitude.Length; i++)
            {
                log.Items.Add(inputSignal.Amplitude[i]);
            }
            
            for (int i = 0; i < networkToPrint.Layers.Count; i++)
            {
                log.Items.Add($"________________Layer: {i} ________________");
                log.Items.Add("");

                for (int j = 0; j < networkToPrint.Layers[i].Neurons.Count; j++)
                {
                    log.Items.Add($"_________Neuron: {j} _________");
                    log.Items.Add("");
                    log.Items.Add($"Error: {networkToPrint.Layers[i].Neurons[j].Error}");
                    log.Items.Add($"Signal amplitude: {networkToPrint.Layers[i].Neurons[j].OutputSignal}");

                    for (int k = 0; k < networkToPrint.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        log.Items.Add($"Weight {k} : {networkToPrint.Layers[i].Neurons[j].Weights[k]}");
                    }
                    log.Items.Add("");

                }

                log.Items.Add(" ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
