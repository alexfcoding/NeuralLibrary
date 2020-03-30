using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace MyNeuralNetwork
{
    public partial class MainForm : Form
    {
        Network network;
        Signal signal;
        double signalSamples;
        int trainCount;
        bool imageMode;
        bool pencilDown;
        bool chartCreated;
        Bitmap bmp;
        Graphics g;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            imageMode = true;
            trainCount = Convert.ToInt32(iterationsTextBox.Text);

            signalSamples = 784;
            int hiddenNeurons = 200;
            int outputNeurons = 10;
            double learningRate = 0.1;
            network = new Network(outputNeurons, learningRate);
            network.ErrorTarget = 0.3;

            double freq = Convert.ToDouble(signalParamTextBox.Text);

            signal = new Signal((int)signalSamples);
            
            if (imageMode)
            {
                signal.ImageFromFile($@"C:\mnist_png\training\{freq}\1.png");
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
            network.CreateHiddenLayers(hiddenNeurons, outputNeurons);
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

        private void DrawNetworkStats(DrawOptions drawOptions, int currentIteration = 1)
        {
            outputsChart.Series[0].Points.Clear();
            errorsChart.Series[0].Points.Clear();
            weightsChart.Series[0].Points.Clear();
            signalsChart.Series[0].Points.Clear();

            if (!chartCreated)
            {
                for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
                {
                    var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series" + (i).ToString(),
                        Color = System.Drawing.Color.Black,
                        IsVisibleInLegend = false,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Spline,
                        BorderWidth = 1
                    };

                    errorsChart2.Series.Add(newSeries);
                }

                chartCreated = true;
            }

            //errorsChart2.Series[0].Points.Clear();
            double cumulativeError = 0;

            for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
            {
                outputsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutput[j]);
                errorsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutputError[j]);
                cumulativeError += Math.Pow(network.CurrentNetworkOutputError[j], 2) / network.CurrentNetworkOutput.Length;
                //errorsChart2.Series[j].Points.AddY(network.CurrentNetworkOutputError[j]);
            }

            if (currentIteration % 10 == 0)
                errorsChart2.Series[0].Points.AddY((cumulativeError));

            int weightId = 0;
            int neuronId = 0;

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j++)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        if (drawOptions == DrawOptions.DrawWeights)
                        {
                            weightsChart.Series[0].Points.AddXY(weightId, network.Layers[i].Neurons[j].Weights[k]);
                            weightId++;
                        }
                    }

                    signalsChart.Series[0].Points.AddXY(neuronId, network.Layers[i].Neurons[j].OutputSignal);
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

            //if (logOptions == LogOptions.PrintFirstState)
            //{
            //    logToAdd.Items.Add($"______________Input signals:_______________");

            //    for (int i = 0; i < inputSignal.Amplitude.Length; i++)
            //    {
            //        logToAdd.Items.Add(inputSignal.Amplitude[i]);
            //    }

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
            ////}

            Application.DoEvents();
        }

        private void TrainNetworkButton_Click(object sender, EventArgs e)
        {
            double freq = Convert.ToDouble(signalParamTextBox.Text);
            signal = new Signal((int)signalSamples);

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
            {
                network.CurrentNetworkOutputError[i] = 1;
            }
            
            int loopExit = 0;
            int trainIteration = 0;
            double[] signalParam = { 0, 4 };
            Random noise = new Random();
            Random rndSet = new Random();

            int imageIndex = 1;

            while (loopExit == 0)
            { 
                int param = rndSet.Next(0, Convert.ToInt32(network.Targets.Length));

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.Targets[i] = 0.01;
                }

                network.Targets[param] = 0.99;
                    
                if (imageMode)
                {
                    signal.ImageFromFile($@"C:\mnist_png\training\{param}\" + imageIndex.ToString() + ".png");
                    pictureBox1.Image = signal.image;
                    imageIndex++;
                }
                else
                {
                    signal.GenerateSinus(param * 10 + 1);
                }

                chart1.Series[0].Points.Clear();

                for (int i = 0; i < signalSamples; i += 1)
                {
                    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);
                TrainNetwork(network);
                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats(DrawOptions.DontDrawWeights, trainIteration);
                network.CleanOldData();

                Application.DoEvents();

                trainIteration++;
                iterationLabel.Text = $"iteration: {trainIteration.ToString()}";

                FillProgressBar(0, trainCount, trainIteration);

                double[] errors = new double[network.CurrentNetworkOutputError.Length];

                for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                {
                    errors[i] += Math.Pow( (network.CurrentNetworkOutputError[i] - network.ErrorTarget), 2);
                }

                if (trainIteration == trainCount)
                {
                    loopExit = 1;
                    break;
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

        public void FillProgressBar(int min, int max, int iteration)
        {
            progressBar1.Maximum = max;
            progressBar1.Minimum = min;
            progressBar1.Value = iteration;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            int imageIndex = 1;

            //for (int a = 0; a < 100; a++)
            { 
                double param = Convert.ToDouble(signalParamTextBox.Text);
                signal = new Signal((int)signalSamples);

                if (imageMode)
                {
                    signal.ImageFromFile($@"C:\mnist_png\testing\{param}\" + imageIndex.ToString() + ".png");
                    pictureBox1.Image = signal.image;
                }
                else
                {
                    signal.GenerateSinus(param);
                }

                imageIndex++;

                chart1.Series[0].Points.Clear();

                for (int i = 0; i < signalSamples; i += 1)
                {
                    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);
                network.ForwardPropagation();

                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                
                DrawNetworkStats(DrawOptions.DontDrawWeights);
                network.CleanOldData();

                Application.DoEvents();
            }
        }

        private void recognitionTestButton_Click(object sender, EventArgs e)
        {
            network.signalParamsList.Clear();

            if (imageMode)
            {
                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.signalParamsList.Add(i);
                }
            }

            new Thread(delegate () {
                TestNetworkWork(network);
            }).Start();
        }

        public static void TestNetworkWork (Network networkToTest)
        {
            networkToTest.TestRecognitionRate();

            string outputMessage = "";

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                outputMessage += $"Recognition quality for signal parameter ({networkToTest.signalParamsList[i]}) is {networkToTest.testResults[i]}% \n";
            }

            MessageBox.Show(outputMessage);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pencilDown = true;
            bmp = new Bitmap(userPaintBox.Width, userPaintBox.Height);
            g = Graphics.FromImage(bmp);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Color clr = new Color();
            clr = Color.FromArgb(255, 252, 252, 252);

            int X = e.X;
            int Y = e.Y;
            
            Point p = new Point(X, Y);
            Pen pencil = new Pen(clr);

            pencil.Width = 1.8f;

            if (pencilDown)
            {
                g.DrawEllipse(pencil, new RectangleF(X, Y, 1, 1));
            }
            userPaintBox.Image = bmp;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pencilDown = false;

            if (imageMode)
            {
                signal.ImageFromDrawer(userPaintBox);
            }

            chart1.Series[0].Points.Clear();

            for (int i = 0; i < signalSamples; i += 1)
            {
                chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            network.SendSignalsToInputLayer(signal.Amplitude);

            network.ForwardPropagation();

            PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);

            DrawNetworkStats(DrawOptions.DontDrawWeights);

            network.CleanOldData();

            Application.DoEvents();
            

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

            label1.Text = maxIndex.ToString();
        }
    }
}
