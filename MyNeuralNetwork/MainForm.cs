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
            double learningRate = 0.002;

            MyNetwork = new Network(outputNeurons, learningRate);
            MyNetwork.ErrorTarget = 0.1;

            MyNetwork.Targets[0] = Convert.ToDouble(tg1.Text);
            MyNetwork.Targets[1] = Convert.ToDouble(tg2.Text);
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

            MyNetwork.CreateInputLayer((int)signalSamples, hiddenNeurons);
            MyNetwork.SendSignalsToInputLayer(signal.Amplitude);
            MyNetwork.CreateHiddenLayers(hiddenNeurons, (int)signalSamples);
            MyNetwork.CreateOutputLayer(outputNeurons, hiddenNeurons);

            MyNetwork.ForwardPropagation();
            MyNetwork.FindNetworkOutputError();
            MyNetwork.NeuronErrorDistribution();

            PrintNetworkStats(MyNetwork, signal, MyNetwork, log, LogOptions.PrintFirstState);
            DrawNetworkStats();

            for (int i = 0; i < MyNetwork.Layers.Count; i++)
            {
                for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                {
                    MyNetwork.Layers[i].Neurons[j].OutputSignal = 0;
                    MyNetwork.Layers[i].Neurons[j].Error = 0;
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

            for (int j = 0; j < MyNetwork.CurrentNetworkOutput.Length; j++)
            {
                outputsChart.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutput[j]);
                errorsChart.Series[0].Points.AddXY(j, MyNetwork.CurrentNetworkOutputError[j]);
            }

            int weightId = 0;
            int neuronId = 0;

            for (int i = 0; i < MyNetwork.Layers.Count; i++)
            {
                for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                {
                    for (int k = 0; k < MyNetwork.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        weightsChart.Series[0].Points.AddXY(weightId, MyNetwork.Layers[i].Neurons[j].Weights[k]);
                        weightId++;
                    }

                    signalsChart.Series[0].Points.AddXY(neuronId, MyNetwork.Layers[i].Neurons[j].OutputSignal);
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
            MyNetwork.Targets[0] = Convert.ToDouble(tg1.Text);
            MyNetwork.Targets[1] = Convert.ToDouble(tg2.Text);
            //MyNetwork.Targets[2] = Convert.ToDouble(tg3.Text);
            //MyNetwork.Targets[3] = Convert.ToDouble(tg4.Text);
            //MyNetwork.Targets[4] = Convert.ToDouble(tg5.Text);
            //MyNetwork.Targets[5] = Convert.ToDouble(tg6.Text);
            //MyNetwork.Targets[6] = Convert.ToDouble(tg7.Text);
            //MyNetwork.Targets[7] = Convert.ToDouble(tg8.Text);

            double freq = Convert.ToDouble(signalParamTextBox.Text);
            signal = new Signal((int)signalSamples, SignalType.Sinus, freq);

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }
            //signal.Amplitude[0] = Convert.ToDouble(tg4.Text);
            //signal.Amplitude[1] = Convert.ToDouble(tg5.Text);
            //signal.Amplitude[2] = Convert.ToDouble(tg6.Text);

            for (int i = 0; i < MyNetwork.CurrentNetworkOutputError.Length; i++)
            {
                MyNetwork.CurrentNetworkOutputError[i] = 1;
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

                    MyNetwork.SendSignalsToInputLayer(signal.Amplitude);
                    TrainNetwork(MyNetwork);
                   
                    if (k == 0)
                    {
                        Application.DoEvents();
                        PrintNetworkStats(MyNetwork, signal, MyNetwork, log2, LogOptions.PrintTrainingNetwork);
                        DrawNetworkStats();
                    }

                    MyNetwork.CleanOldData();
                }

                for (int i = 0; i < MyNetwork.CurrentNetworkOutputError.Length; i++)
                {
                    if (Math.Abs(MyNetwork.CurrentNetworkOutputError[i]) < MyNetwork.ErrorTarget)
                    {
                        errorSum++;
                    }
                }

                if (errorSum == MyNetwork.CurrentNetworkOutput.Length)
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

                double time = 0;
                Random noise = new Random();
                for (int i = 0; i < signal.Amplitude.Length; i += 1)
                {
                    time += 0.01;
                    signal.Amplitude[i] = Math.Sin(time * freq) + Math.Sin(4 * time * freq) + noise.NextDouble() / 8;
                }
                
                chart1.Series[0].Points.Clear();

                for (int i = 0; i < signalSamples; i += 1)
                {
                    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                MyNetwork.SendSignalsToInputLayer(signal.Amplitude);

                MyNetwork.ForwardPropagation();

                PrintNetworkStats(MyNetwork, signal, MyNetwork, log2, LogOptions.PrintTrainingNetwork);

                DrawNetworkStats();

                for (int i = 0; i < MyNetwork.Layers.Count; i++)
                {
                    for (int j = 0; j < MyNetwork.Layers[i].Neurons.Count; j++)
                    {
                        MyNetwork.Layers[i].Neurons[j].OutputSignal = 0;
                        MyNetwork.Layers[i].Neurons[j].Error = 0;
                    }
                }
            }
        }
    }
}
