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
using System.Drawing;

namespace MyNeuralNetwork
{
    public partial class MainForm : Form
    {
        Network network;
        Signal signal;
        double signalSamples;
        bool imageMode;
        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            imageMode = true;

            signalSamples = 784;
            int hiddenNeurons = 32;
            int outputNeurons = 3;
            double learningRate = 0.5;
            network = new Network(outputNeurons, learningRate);
            network.ErrorTarget = 0.3;

            double freq = Convert.ToDouble(signalParamTextBox.Text);

            signal = new Signal((int)signalSamples);
            
            if (imageMode)
            {
                signal.GenerateImage($@"C:\mnist_png\training\{freq}\1.png");
                pictureBox1.Image = signal.image;
            }
            else
            {
                signal.GenerateSinus(freq);
            }


            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            network.CreateInputLayer((int)signalSamples, hiddenNeurons);
            network.SendSignalsToInputLayer(signal.Amplitude);
            network.CreateHiddenLayers(hiddenNeurons, (int)signalSamples);
            network.CreateOutputLayer(outputNeurons, 0);

            network.ForwardPropagation();
            network.FindNetworkOutputError();
            network.NeuronErrorDistribution();

            PrintNetworkStats(network, signal, network, log, LogOptions.PrintFirstState);
            //DrawNetworkStats();

            network.CleanOldData();

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

            //for (int i = 0; i < network.Layers.Count; i++)
            //{
            //    for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
            //    {
            //        for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
            //        {
            //            weightsChart.Series[0].Points.AddXY(weightId, network.Layers[i].Neurons[j].Weights[k]);
            //            weightId++;
            //        }

            //        signalsChart.Series[0].Points.AddXY(neuronId, network.Layers[i].Neurons[j].OutputSignal);
            //        neuronId++;
            //    }
            //}
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
            if (logOptions ==LogOptions.PrintTrainingNetwork)
                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    logToAdd.Items.Add(Math.Abs(network.CurrentNetworkOutputError[i]) + $" ( Error target : < {network.ErrorTarget} )");
                }

            //if (logOptions == LogOptions.PrintFirstState)
            {
                //logToAdd.Items.Add($"______________Input signals:_______________");

                //for (int i = 0; i < inputSignal.Amplitude.Length; i++)
                //{
                //    logToAdd.Items.Add(inputSignal.Amplitude[i]);
                //}

                //for (int i = 0; i < networkToPrint.Layers.Count; i++)
                //{
                //    logToAdd.Items.Add($"________________Layer: {i}________________");

                //    for (int j = 0; j < networkToPrint.Layers[i].Neurons.Count; j++)
                //    {
                //        logToAdd.Items.Add($"_________Neuron: {j} _________");
                //        logToAdd.Items.Add($"Error: {networkToPrint.Layers[i].Neurons[j].Error}");
                //        logToAdd.Items.Add($"Signal amplitude: {networkToPrint.Layers[i].Neurons[j].OutputSignal}");

                //        for (int k = 0; k < networkToPrint.Layers[i].Neurons[j].Weights.Length; k++)
                //        {
                //            logToAdd.Items.Add($"Weight {k} : {networkToPrint.Layers[i].Neurons[j].Weights[k]}");
                //        }
                //    }
                //}
            }

            Application.DoEvents();
        }

        private void TrainNetworkButton_Click(object sender, EventArgs e)
        {
            double freq = Convert.ToDouble(signalParamTextBox.Text);
            signal = new Signal((int)signalSamples);
            network.signalParamsList.Add(freq);

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
            {
                network.CurrentNetworkOutputError[i] = 1;
            }

            int errorSum = 0;
            int loopExit = 0;
            Random noise = new Random();
            double time = 0;
            int imageIndex = 1;
            long iteration = 0;
            int symbolReady = 0;

            double[] signalParam = { 0, 4 };

            Random rndSet = new Random();

            while (loopExit == 0)
            {
                for (int k = 0; k < network.Targets.Length; k++)
                {
                    freq = rndSet.Next(1, 6);

                    int symbol = rndSet.Next(0, Convert.ToInt32(network.Targets.Length));

                    //for (int i = 0; i < network.Targets.Length; i++)
                    //{
                    //    network.Targets[i] = 0.01;
                    //}

                    //network.Targets[symbol] = 0.99;

                    if (k == 0)
                    {
                        symbol = 0;
                        network.Targets[0] = 0.9;
                        network.Targets[1] = 0.1;
                        network.Targets[2] = 0.1;
                    }
                    if (k == 1)
                    {
                        symbol = 1;
                        network.Targets[0] = 0.1;
                        network.Targets[1] = 0.9;
                        network.Targets[2] = 0.1;
                    }
                    if (k == 2)
                    {
                        symbol = 2;
                        network.Targets[0] = 0.1;
                        network.Targets[1] = 0.1;
                        network.Targets[2] = 0.9;
                    }

                    time += 0.01;
                    //signal.Amplitude[i] = Math.Sin(time * freq) + Math.Sin(4 * time * freq);//+ noise.NextDouble() / 8;
                    //signal.GenerateImage(@"C:\mnist_png\training\0\" + imageIndex.ToString() + ".png");
                    //signal.GenerateSinus(freq);
                    //signal.GenerateSinus(signalParam[k]);
                    //signal.GenerateImage($@"C:\mnist_png\training\{signalParam[k]}\" + imageIndex.ToString() + ".png");
                    
                    if (imageMode)
                    {
                        signal.GenerateImage($@"C:\mnist_png\training\{symbol}\" + imageIndex.ToString() + ".png");
                        pictureBox1.Image = signal.image;
                    }
                    else
                    {
                        signal.GenerateSinus(symbol * 10 + 1);
                    }

                    imageIndex++;

                    time = 0;

                    chart1.Series[0].Points.Clear();

                    for (int i = 0; i < signalSamples; i += 1)
                    {
                        chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                    }

                    network.SendSignalsToInputLayer(signal.Amplitude);

                    TrainNetwork(network);

                    PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                    DrawNetworkStats();
                    PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                    DrawNetworkStats();
                    Application.DoEvents();

                    network.CleanOldData();

                    iteration++;
                    iterationLabel.Text = $"iteration: {iteration.ToString()}";

                    double maxPower = network.CurrentNetworkOutput[0];
                    double maxIndex = 0;

                    for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
                    {
                        if (network.CurrentNetworkOutput[j] > maxPower)
                        {
                            maxPower = network.CurrentNetworkOutput[j];
                            maxIndex = j;
                        }
                    }

                    if (maxIndex == symbol)
                    {
                        symbolReady++;
                    }

                    //for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                    //{
                    //    if (Math.Abs(network.CurrentNetworkOutputError[i]) < network.ErrorTarget)
                    //    {
                    //        errorSum++;
                    //    }
                    //}

                    //if (errorSum == network.CurrentNetworkOutput.Length)
                    //{
                    //    //loopExit = 1;
                    //    errorSum = 0;
                    //    //break;
                    //    symbolReady++;
                    //}

                    errorSum = 0;

                    if (iteration == 100)
                    {
                        loopExit = 1;
                        break;
                    }
                }

                if (symbolReady == 3)
                {
                    loopExit = 1;
                    break;
                }
                else
                {
                    symbolReady = 0;
                }
            }
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
            int imageIndex = 1;

            for (int a = 0; a < 10; a++)
            { 
                double freq = Convert.ToDouble(signalParamTextBox.Text);
                signal = new Signal((int)signalSamples);
                //signal.GenerateSinus(freq);

                if (imageMode)
                {
                    signal.GenerateImage($@"C:\mnist_png\testing\{freq}\" + imageIndex.ToString() + ".png");
                    pictureBox1.Image = signal.image;
                }
                else
                {
                    signal.GenerateSinus(freq);
                }

                imageIndex++;
                //signal = new Signal((int)signalSamples, SignalType.Image, freq, @"C:\mnist_png\training\0\1.png");

                chart1.Series[0].Points.Clear();

                for (int i = 0; i < signalSamples; i += 1)
                {
                    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);

                network.ForwardPropagation();

                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);

                Application.DoEvents();
                DrawNetworkStats();

                Application.DoEvents();
                network.CleanOldData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tg8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
