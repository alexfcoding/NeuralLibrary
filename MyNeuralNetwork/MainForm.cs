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
            PrintTrainingNetwork
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            MyNetwork = new Network(3, 0.5);
            signal = new Signal(3);
            MyNetwork.ErrorTarget = 0.03;

            MyNetwork.CreateInputLayer(3, 3);
            MyNetwork.SendSignalsToInputLayer(signal.Amplitude);
            MyNetwork.CreateHiddenLayers(3, 3);
            MyNetwork.CreateOutputLayer(3, 3);

            MyNetwork.ForwardPropagation();
            MyNetwork.FindNetworkOutputError();
            MyNetwork.NeuronErrorDistribution();

            PrintNetworkStats(MyNetwork, signal, MyNetwork, log, LogOptions.PrintFirstState);

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            for (int j = 0; j < 3; j++)
            {
                chart1.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutput[j]);
                chart2.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutputError[j]);
            }

            DrawNetworkStats();

            trainNetworkButton.Enabled = true;
            testNetworkButton.Text = "Create next network";
        }

        private void DrawNetworkStats()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();

            for (int j = 0; j < 3; j++)
            {
                chart1.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutput[j]);
                chart2.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutputError[j]);
            }

            int weightId = 0;
            int neuronId = 0;

            for (int i = 0; i < MyNetwork.Layers.Count; i++)
            {
                for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                {
                    for (int k = 0; k < MyNetwork.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        chart3.Series[0].Points.AddXY(weightId, MyNetwork.Layers[k].Neurons[j].Weights[j]);
                        weightId++;
                    }

                    chart4.Series[0].Points.AddXY(neuronId, MyNetwork.Layers[i].Neurons[j].OutputSignal);
                    neuronId++;
                }   

            }
        }

        private void PrintNetworkStats(Network networkToPrint, Signal inputSignal, Network network, ListBox logToAdd, LogOptions logOptions)
        {
            logToAdd.Items.Clear();
            logToAdd.Items.Add($"________________Targets_________________ ");

            for (int i = 0; i < network.Targets.Length; i++)
            {
                logToAdd.Items.Add(network.Targets[i]);
            }

            logToAdd.Items.Add($"_____________Network output______________ ");

            if (logOptions == LogOptions.PrintFirstState)
                for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
                {
                    logToAdd.Items.Add(network.CurrentNetworkOutput[i]);
                }

            if (logOptions == LogOptions.PrintTrainingNetwork)
                for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
                {
                    logToAdd.Items.Add(network.CurrentNetworkOutput[i] + $" ( Output target : {network.Targets[i]} )");
                }

            logToAdd.Items.Add($"___________Network output error___________");
            
            if (logOptions == LogOptions.PrintFirstState)
                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    logToAdd.Items.Add(Math.Abs(network.CurrentNetworkOutputError[i]));
                }
            if (logOptions == LogOptions.PrintTrainingNetwork)
                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    logToAdd.Items.Add(Math.Abs(network.CurrentNetworkOutputError[i]) + $" ( Error target : < {network.ErrorTarget} )");
                }

            logToAdd.Items.Add($"______________Input signals:_______________");
            
            for (int i = 0; i < inputSignal.Amplitude.Length; i++)
            {
                logToAdd.Items.Add(inputSignal.Amplitude[i]);
            }

            for (int i = 0; i < networkToPrint.Layers.Count; i++)
            {
                logToAdd.Items.Add($"________________Layer: {i}________________");
                
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

                PrintNetworkStats(MyNetwork, signal, MyNetwork, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats();

                int errorSum = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (Math.Abs(MyNetwork.CurrentNetworkOutputError[i]) < MyNetwork.ErrorTarget)
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
