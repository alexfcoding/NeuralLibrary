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
        Network network;
        Signal signal;
        double signalSamples;

        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            signalSamples = 64;
            int hiddenNeurons = 16;
            int outputNeurons = 2;
            double learningRate = 0.01;

            network = new Network(outputNeurons, learningRate);
            network.ErrorTarget = 0.1;

            network.Targets[0] = Convert.ToDouble(tg1.Text);
            network.Targets[1] = Convert.ToDouble(tg2.Text);
            //MyNetwork.Targets[2] = Convert.ToDouble(tg3.Text);
            //MyNetwork.Targets[3] = Convert.ToDouble(tg4.Text);
            //MyNetwork.Targets[4] = Convert.ToDouble(tg5.Text);
            //MyNetwork.Targets[5] = Convert.ToDouble(tg6.Text);
            //MyNetwork.Targets[6] = Convert.ToDouble(tg7.Text);
            //MyNetwork.Targets[7] = Convert.ToDouble(tg8.Text);

            double freq = Convert.ToDouble(signalParamTextBox.Text);

            signal = new Signal((int)signalSamples, SignalType.Sinus, freq);

            //signal.Amplitude[0] = Convert.ToDouble(tg4.Text);
            //signal.Amplitude[1] = Convert.ToDouble(tg5.Text);
            //signal.Amplitude[2] = Convert.ToDouble(tg6.Text);

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            network.CreateInputLayer((int)signalSamples, hiddenNeurons);
            network.SendSignalsToInputLayer(signal.Amplitude);
            network.CreateHiddenLayers(hiddenNeurons, (int)signalSamples);
            network.CreateOutputLayer(outputNeurons, hiddenNeurons);

            network.ForwardPropagation();
            network.FindNetworkOutputError();
            network.NeuronErrorDistribution();

            PrintNetworkStats(network, signal, network, log, LogOptions.PrintFirstState);
            DrawNetworkStats();

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
                {
                    network.Layers[i].Neurons[j].OutputSignal = 0;
                    network.Layers[i].Neurons[j].Error = 0;
                }
            }

            trainNetorkButton.Enabled = true;
            testNetworkButton.Text = "Create next network";
        }

        private void DrawNetworkStats()
        {
            outputsChart.Series[0].Points.Clear();
            errorsChart.Series[0].Points.Clear();
            weightsChart.Series[0].Points.Clear();
            signalsChart.Series[0].Points.Clear();

            for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
            {
                outputsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutput[j]);
                errorsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutputError[j]);
            }

            int weightId = 0;
            int neuronId = 0;

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        weightsChart.Series[0].Points.AddXY(weightId, network.Layers[i].Neurons[j].Weights[k]);
                        weightId++;
                    }

                    signalsChart.Series[0].Points.AddXY(neuronId, network.Layers[i].Neurons[j].OutputSignal);
                    neuronId++;
                }   
            }
        }

        private void PrintNetworkStats(Network networkToPrint, Signal inputSignal, Network network, ListBox logToAdd, LogOptions logOptions)
        {
            //Thread.Sleep(20);
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
            if (logOptions ==LogOptions.PrintTrainingNetwork)
                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    logToAdd.Items.Add(Math.Abs(network.CurrentNetworkOutputError[i]) + $" ( Error target : < {network.ErrorTarget} )");
                }

            if (logOptions == LogOptions.PrintFirstState)
            {
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

            Application.DoEvents();
        }

        private void TrainNetworkButton_Click(object sender, EventArgs e)
        {
            network.Targets[0] = Convert.ToDouble(tg1.Text);
            network.Targets[1] = Convert.ToDouble(tg2.Text);
            //MyNetwork.Targets[2] = Convert.ToDouble(tg3.Text);
            //MyNetwork.Targets[3] = Convert.ToDouble(tg4.Text);
            //MyNetwork.Targets[4] = Convert.ToDouble(tg5.Text);
            //MyNetwork.Targets[5] = Convert.ToDouble(tg6.Text);
            //MyNetwork.Targets[6] = Convert.ToDouble(tg7.Text);
            //MyNetwork.Targets[7] = Convert.ToDouble(tg8.Text);

            double freq = Convert.ToDouble(signalParamTextBox.Text);
            signal = new Signal((int)signalSamples, SignalType.Sinus, freq);

            network.signalParamsList.Add(freq);

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }
            //signal.Amplitude[0] = Convert.ToDouble(tg4.Text);
            //signal.Amplitude[1] = Convert.ToDouble(tg5.Text);
            //signal.Amplitude[2] = Convert.ToDouble(tg6.Text);

            for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
            {
                network.CurrentNetworkOutputError[i] = 1;
            }

            int errorSum = 0;
            int loopExit = 0;

            Random noise = new Random();
            double time = 0;

            while(loopExit == 0)
            {
                for (int k = 0; k < 10; k++)
                {
                    for (int i = 0; i < signal.Amplitude.Length; i += 1)
                    {
                        time += 0.01;
                        signal.Amplitude[i] = Math.Sin(time * freq) + Math.Sin(4 * time * freq)+ noise.NextDouble() / 8;
                    }

                    time = 0;

                    chart1.Series[0].Points.Clear();

                    for (int i = 0; i < signalSamples; i += 1)
                    {
                        chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                    }

                    network.SendSignalsToInputLayer(signal.Amplitude);
                    TrainNetwork(network);
                   
                    if (k == 0)
                    {
                        Application.DoEvents();
                        PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                        DrawNetworkStats();
                    }

                    network.CleanOldData();
                }

                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    if (Math.Abs(network.CurrentNetworkOutputError[i]) < network.ErrorTarget)
                    {
                        errorSum++;
                    }
                }

                if (errorSum == network.CurrentNetworkOutput.Length)
                {
                    loopExit = 1;
                    errorSum = 0;
                    break;
                }

                errorSum = 0;

            }

            //Application.DoEvents();
            //PrintNetworkStats(MyNetwork, signal, MyNetwork, log2, LogOptions.PrintTrainingNetwork);
            //DrawNetworkStats();
        }

        void TrainNetwork(Network networkToTrain)
        {
            networkToTrain.ForwardPropagation();
            networkToTrain.FindNetworkOutputError();
            networkToTrain.NeuronErrorDistribution();
            networkToTrain.RecalculateWeights();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //signal.Amplitude[0] = Convert.ToDouble(tg4.Text);
            //signal.Amplitude[1] = Convert.ToDouble(tg5.Text);
            //signal.Amplitude[2] = Convert.ToDouble(tg6.Text);

            //for (int a = 0; a < 1000; a++)
            { 
                double freq = Convert.ToDouble(signalParamTextBox.Text);
                signal = new Signal((int)signalSamples, SignalType.Sinus, freq);

                chart1.Series[0].Points.Clear();

                for (int i = 0; i < signalSamples; i += 1)
                {
                    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);

                network.ForwardPropagation();

                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);

                DrawNetworkStats();

                for (int i = 0; i < network.Layers.Count; i++)
                {
                    for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
                    {
                        network.Layers[i].Neurons[j].OutputSignal = 0;
                        network.Layers[i].Neurons[j].Error = 0;
                    }
                }
            }
        }

        private void recognitionTestButton_Click(object sender, EventArgs e)
        {
            double[] result = network.TestRecognitionRate();

            for (int i = 0; i < network.signalParamsList.Count; i++)
            {
                MessageBox.Show($"Recognition quality for signal parameter ({network.signalParamsList[i]}) is: {result[i]}%");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
