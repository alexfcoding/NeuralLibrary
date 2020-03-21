using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNeuralNetwork
{
    public partial class MainForm : Form
    {
        Network MyNetwork;
        Signal signal;

        enum LogOptions
        {
            PrintFirstState,
            PrintUpdatedNetwork
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            MyNetwork = new Network(3, 0.5);
            signal = new Signal(3);

            MyNetwork.CreateInputLayer(3, 3);
            MyNetwork.SendSignalsToInputLayer(signal.Amplitude);
            MyNetwork.CreateHiddenLayers(3, 3);
            MyNetwork.CreateOutputLayer(3, 3);

            MyNetwork.ForwardPropagation();
            MyNetwork.FindNetworkOutputError();
            MyNetwork.NeuronErrorDistribution();

            PrintNetworkStats(MyNetwork, signal, MyNetwork, log);

            trainNetworkButton.Enabled = true;
        }

        private void PrintNetworkStats(Network networkToPrint, Signal inputSignal, Network network, ListBox logToAdd)
        {
            logToAdd.Items.Clear();
            logToAdd.Items.Add($"________________Targets________________ ");

            for (int i = 0; i < network.Targets.Length; i++)
            {
                logToAdd.Items.Add(network.Targets[i]);
            }

            logToAdd.Items.Add($"________________Output________________ ");
            
            for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
            {
                logToAdd.Items.Add(network.CurrentNetworkOutput[i]);
            }
           
            logToAdd.Items.Add($"________________Error________________ ");
           
            for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
            {
                logToAdd.Items.Add(network.CurrentNetworkOutputError[i]);
            }
            
            logToAdd.Items.Add($"________________Input signals:________________");
            
            for (int i = 0; i < inputSignal.Amplitude.Length; i++)
            {
                logToAdd.Items.Add(inputSignal.Amplitude[i]);
            }

            for (int i = 0; i < networkToPrint.Layers.Count; i++)
            {
                logToAdd.Items.Add($"______________________Layer: {i}______________________");
                
                for (int j = 0; j < networkToPrint.Layers[i].Neurons.Count; j++)
                {
                    logToAdd.Items.Add($"_________Neuron: {j} _________");
                    logToAdd.Items.Add($"Error: {networkToPrint.Layers[i].Neurons[j].Error}");
                    logToAdd.Items.Add($"Signal amplitude: {networkToPrint.Layers[i].Neurons[j].OutputSignal}");

                    for (int k = 0; k < networkToPrint.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        logToAdd.Items.Add($"Weight {k} : {networkToPrint.Layers[i].Neurons[j].Weights[k]}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(true)
            {
                for (int k = 0; k < 10; k++)
                {
                    TrainNetwork(MyNetwork);
                }

                Application.DoEvents();
                Thread.Sleep(20);

                chart1.Series[0].Points.Clear();
                chart2.Series[0].Points.Clear();

                for (int j = 0; j < 3; j++)
                {
                    chart1.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutput[j]);
                    chart2.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutputError[j]);
                }

                PrintNetworkStats(MyNetwork, signal, MyNetwork, log2);

                int errorSum = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (Math.Abs(MyNetwork.CurrentNetworkOutputError[i]) < 0.03)
                    {
                        errorSum++;
                    }
                }

                if (errorSum == 3)
                    break;
            }
        }

        void TrainNetwork(Network networkToTrain)
        {
            networkToTrain.ForwardPropagation();
            networkToTrain.FindNetworkOutputError();

            networkToTrain.NeuronErrorDistribution();
            networkToTrain.RecalculateWeights();

        }
    }
}
