﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
        Random randomClr = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            imageMode = true;
            trainCount = Convert.ToInt32(iterationsText.Text);
            signalSamples = Convert.ToInt32(inputsText.Text);
            int hiddenNeurons = Convert.ToInt32(hiddenText.Text);
            int outputNeurons = Convert.ToInt32(outputsText.Text);
            double learningRate = Convert.ToDouble(learningRateText.Text);
            network = new Network(outputNeurons, learningRate);
            network.ErrorTarget = 0.3;

            double freq = Convert.ToDouble(signalParamText.Text);

            signal = new Signal((int)signalSamples);
            
            if (imageMode)
            {
                signal.ImageFromFile($@"mnist_png\training\{freq}\1.png");
                previewPaintBox2.Image = signal.image;
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
            signalsChart.Series[0].Points.Clear();

            if (!chartCreated)
            {
                for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
                {
                    
                    int R = randomClr.Next(0, 255);
                    int G = randomClr.Next(0, 255);
                    int B = randomClr.Next(0, 255);

                    var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series" + (i).ToString(),
                        Color = System.Drawing.Color.FromArgb(255, R, G, B),
                        IsVisibleInLegend = false,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Spline,
                        BorderWidth = 1
                    };

                    errorsChart2.Series.Add(newSeries);
                }

                chartCreated = true;
            }
            
            double cumulativeError = 0;


            for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
            {
                outputsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutput[j]);
                errorsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutputError[j]);
                cumulativeError += Math.Pow(network.CurrentNetworkOutputError[j], 2) / network.CurrentNetworkOutput.Length;
                //errorsChart2.Series[j].Points.AddY(network.CurrentNetworkOutputError[j]);
            }

            //if (currentIteration % 10 == 0)
            //    errorsChart2.Series[0].Points.AddY((cumulativeError));
            if (currentIteration % 100 == 0)
            {
                for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
                {
                    errorsChart2.Series[j].Points.AddY((network.avgError[j]));
                }
            }

            int weightId = 0;
            int neuronId = 0;

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j += 1)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        if (drawOptions == DrawOptions.DrawWeights)
                        {
                            rateChart.Series[0].Points.AddXY(weightId, network.Layers[i].Neurons[j].Weights[k]);
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
            double freq = Convert.ToDouble(signalParamText.Text);
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
            
            int[] imageIndex = new int[network.Targets.Length];

            while (loopExit == 0)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                int param = rndSet.Next(0, Convert.ToInt32(network.Targets.Length));
               

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.Targets[i] = 0.01;
                }

                network.Targets[param] = 0.99;
                    
                if (imageMode)
                {
                    if (imageIndex[param] == 0)
                    {
                        imageIndex[param] = 1;
                    }

                    signal.ImageFromFile($@"mnist_png\training\{param}\" + imageIndex[param].ToString() + ".png");
                    previewPaintBox2.Image = signal.image;
                    previewPaintBox.Image = signal.image;
                    imageIndex[param]++;
                    //imageIndex++;
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
                TestSamples(network, param);
                
                network.CleanOldData();

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.avgError[param] = 0;
                }

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.avgError[param] += Math.Abs(network.CurrentNetworkOutputError[i]) / network.Targets.Length;
                }

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

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                label9.Text = $"Performance per cycle: {elapsedMs} ms / Estimated time: { (trainCount- trainIteration) * elapsedMs / 1000 / 60} min";
            }
        }

        private void TestSamples(Network networkToTest, int trueValue)
        {
            double maxPower = networkToTest.CurrentNetworkOutput[0];
            double maxIndex = 0;

            for (int k = 0; k < networkToTest.CurrentNetworkOutput.Length; k++)
            {
                if (networkToTest.CurrentNetworkOutput[k] > maxPower)
                {
                    maxPower = networkToTest.CurrentNetworkOutput[k];
                    maxIndex = k;
                }
            }

            if (maxIndex == trueValue)
            {
                detectLabel.Text = "Recognized";
                detectLabel.BackColor = Color.Lime;
            }
            else
            {
                detectLabel.Text = "Fail";
                detectLabel.BackColor = Color.Red;
            }
        }

        void TrainNetwork(Network networkToTrain)
        {
            networkToTrain.ForwardPropagation();
            networkToTrain.FindNetworkOutputError();
            networkToTrain.NeuronErrorDistribution();
            networkToTrain.RecalculateWeights();
        }

        public double[] TestRecognitionRate(Network networkToTest)
        {
            double testCount = 100;
            networkToTest.testResults = new double[networkToTest.signalParamsList.Count];
            int imageIndex = 1;

            double[] resultMatrix = new double[networkToTest.signalParamsList.Count];

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                for (int j = 0; j < testCount; j++)
                {
                    Signal signal = new Signal(networkToTest.Layers[0].Neurons.Count);

                    signal.ImageFromFile($@"mnist_png\testing\{i}\" + imageIndex.ToString() + ".png");
                    previewPaintBox.Image = signal.image;
                    Application.DoEvents();
                    imageIndex++;

                    networkToTest.SendSignalsToInputLayer(signal.Amplitude);
                    networkToTest.ForwardPropagation();
                    networkToTest.FindNetworkOutputError();

                    double maxPower = networkToTest.CurrentNetworkOutput[0];
                    double maxIndex = 0;

                    for (int k = 0; k < networkToTest.CurrentNetworkOutput.Length; k++)
                    {
                        if (networkToTest.CurrentNetworkOutput[k] > maxPower)
                        {
                            maxPower = networkToTest.CurrentNetworkOutput[k];
                            maxIndex = k;
                        }
                    }

                    resultMatrix[i] = networkToTest.testResults[i] / testCount * 100;

                    if (maxIndex == i)
                    {
                        networkToTest.testResults[i]++;
                        detectLabel.Text = "Recognized";
                        detectLabel.BackColor = Color.Lime;
                    }
                    else
                    {
                        detectLabel.Text = "Fail";
                        detectLabel.BackColor = Color.Red;
                    }

                    rateChart.Series[0].Points.Clear();

                    for (int m = 0; m < networkToTest.signalParamsList.Count; m++)
                    {
                        rateChart.Series[0].Points.AddXY(m, resultMatrix[m]);
                    }
                    networkToTest.CleanOldData();
                }
            }

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                networkToTest.testResults[i] = networkToTest.testResults[i] / testCount * 100;
            }

            return networkToTest.testResults;
        }

        public void FillProgressBar(int min, int max, int iteration)
        {
            progressBar1.Maximum = max;
            progressBar1.Minimum = min;
            progressBar1.Value = iteration;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            try
            {
                int imageIndex = 1;

                //for (int a = 0; a < 100; a++)
                {
                    double param = Convert.ToDouble(signalParamText.Text);
                    signal = new Signal((int)signalSamples);

                    if (imageMode)
                    {
                        signal.ImageFromFile($@"mnist_png\testing\{param}\" + imageIndex.ToString() + ".png");
                        previewPaintBox2.Image = signal.image;
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
            catch
            {
                MessageBox.Show("Create network first");
            }
            
        }

        private void recognitionTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                network.signalParamsList.Clear();

                if (imageMode)
                {
                    for (int i = 0; i < network.Targets.Length; i++)
                    {
                        network.signalParamsList.Add(i);
                    }
                }

                //new Thread(delegate () {
                //    TestNetworkWork(network);
                //}).Start();

                TestNetworkWork(network);
            }
            catch
            {
                MessageBox.Show("Create network first");
            }
            
        }

        public void TestNetworkWork (Network networkToTest)
        {
            TestRecognitionRate(networkToTest);

            string outputMessage = "";

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                outputMessage += $"Recognition rate for signal parameter ({networkToTest.signalParamsList[i]}) is {networkToTest.testResults[i]}% \n";
            }

            MessageBox.Show(outputMessage);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            //pencilDown = true;
            //bmp = new Bitmap(userPaintBox.Width, userPaintBox.Height);
            //g = Graphics.FromImage(bmp);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            //Color clr = new Color();
            //clr = Color.FromArgb(255, 252, 252, 252);

            //int X = e.X;
            //int Y = e.Y;
            
            //Point p = new Point(X, Y);
            //Pen pencil = new Pen(clr);

            //pencil.Width = 2f;

            //if (pencilDown)
            //{
            //    g.DrawEllipse(pencil, new RectangleF(X, Y, 1, 1));
            //}
            //userPaintBox.Image = bmp;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            //pencilDown = false;
            //pictureBox1.Image = userPaintBox.Image;

            //if (imageMode)
            //{
            //    signal.ImageFromDrawer(userPaintBox);
            //}

            //chart1.Series[0].Points.Clear();

            //for (int i = 0; i < signalSamples; i += 1)
            //{
            //    chart1.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            //}

            //network.SendSignalsToInputLayer(signal.Amplitude);

            //network.ForwardPropagation();

            //PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);

            //DrawNetworkStats(DrawOptions.DontDrawWeights);

            //network.CleanOldData();

            //Application.DoEvents();
            

            //double maxPower = network.CurrentNetworkOutput[0];
            //double maxIndex = 0;

            //for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
            //{
            //    if (network.CurrentNetworkOutput[j] > maxPower)
            //    {
            //        maxPower = network.CurrentNetworkOutput[j];
            //        maxIndex = j;
            //    }
            //}

            //label1.Text = maxIndex.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pencilDown = true;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Color clr = new Color();
            clr = Color.FromArgb(255, 252, 252, 252);

            int X = e.X;
            int Y = e.Y;

            Point p = new Point(X, Y);
            Pen pencil = new Pen(clr);

            pencil.Width = 24f;

            if (pencilDown)
            {
                g.DrawEllipse(pencil, new RectangleF(X, Y, 1, 1));
            }

            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pencilDown = false;
            userPaintBox.Image = ResizeImage(pictureBox1.Image, 28, 28);

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
            label8.Text = maxIndex.ToString();
        }
    }
}
