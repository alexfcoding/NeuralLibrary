﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

namespace MyNeuralNetwork
{
    public partial class MainForm : Form
    {
        Network network;
        Signal signal;
        SignalType signalType;
        int trainCount;
        int inputSampleCount;
        int trainParam;
        int epoch = 0;

        ModelConstructor networkForm;
        Monitor networkMonitor = new Monitor();  

        bool pencilDown;
        bool chartCreated;

        Bitmap bmp;
        Graphics g;

        Random sampleRandomizer = new Random();
        Random randomClr = new Random();
        Random rndAngle = new Random();
        Random rndAmplitude = new Random();
        Random rndSet = new Random();
        
        public MainForm()
        {
            InitializeComponent();

            List<Chart> styledCharts = new List<Chart> { rateChart, errorsChart, errorsChart2, outputsChart, inputsChart, stateErrorsChart };           
            SetStyleForCharts(styledCharts);
        }

        private void SetStyleForCharts(List<Chart> styledCharts)
        {
            Font chartTitleFont = new System.Drawing.Font("Ms Sans Serif", 10, System.Drawing.FontStyle.Bold);
            Font chartAxisFont = new System.Drawing.Font("Ms Sans Serif", 7);

            for (int i = 0; i < styledCharts.Count; i++)
            {
                styledCharts[i].ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = chartAxisFont;
                styledCharts[i].ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = chartAxisFont;
                styledCharts[i].ChartAreas["ChartArea1"].AxisX.TitleFont = chartTitleFont;
                styledCharts[i].ChartAreas["ChartArea1"].AxisY.TitleFont = chartTitleFont;
            }            
        }

        public void callModelConstructorButton_Click(object sender, EventArgs e)
        {
            networkForm = new ModelConstructor();

            if (radioButton1.Checked)
            {
                signalType = SignalType.Image;
            }

            if (radioButton2.Checked)
            {
                signalType = SignalType.Sinus;
            }
                        
            networkForm.SendNetworkSetup += new EventHandler(form2_SendNetworkSetup);           
            networkForm.Show();
            networkForm.Top = this.Top + this.Height / 2 - networkForm.Width / 2;
            networkForm.Left = this.Left + this.Width / 2 - networkForm.Width / 2;
            networkForm.TopMost = true;

            trainNetworkButton.Enabled = true;
            callModelConstructorButton.Text = "Create next network";
        }

        private void form2_SendNetworkSetup(object sender, EventArgs e)
        {            
            network = new Network(networkForm.outputNeuronsCount, networkForm.learningRate);
            network.CreateInputLayer(networkForm.inputNeuronsCount, networkForm.hiddenNeuronsCount[0]);
            network.CreateHiddenLayers(networkForm.hiddenNeuronsCount, networkForm.outputNeuronsCount);
            network.CreateOutputLayer(networkForm.outputNeuronsCount, 0);
            networkMonitor.drawWeightsInMonitor(network);
            networkMonitor.Show();
        }

        private void DrawNetworkStats(DrawOptions drawOptions, int trainIteration = 1)
        {
            outputsChart.Series[0].Points.Clear();
            errorsChart.Series[0].Points.Clear();           
            networkMonitor.clearMonitor();                

            if (!chartCreated)
            {
                for (int i = 0; i < network.CurrentNetworkOutput.Length; i++)
                {
                    
                    int R = randomClr.Next(50, 255);
                    int G = randomClr.Next(50, 255);
                    int B = randomClr.Next(50, 255);

                    var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "Series" + (i).ToString(),
                        Color = System.Drawing.Color.FromArgb(255, R, G, B),
                        IsVisibleInLegend = false,
                        IsXValueIndexed = false,
                        ChartType = SeriesChartType.Spline,
                        BorderWidth = 3
                    };

                    stateErrorsChart.Series.Add(newSeries);
                }
               
                errorsChart2.Series[0].Points.AddY(0);

                for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
                {
                    stateErrorsChart.Series[j].Points.AddY(0);
                }                

                chartCreated = true;
            }

            for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
            {
                outputsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutput[j]);
                errorsChart.Series[0].Points.AddXY(j, network.CurrentNetworkOutputError[j]);
            }

            if (trainIteration % (network.CurrentNetworkOutput.Length * 20) == 0)
            {
                errorsChart2.Series[errorsChart2.Series.Count-1].Points.AddXY(trainIteration, Math.Abs(network.CurrentCumulativeError / (network.CurrentNetworkOutput.Length * 20) * 100 - 100));
            }

            if (trainIteration % (network.CurrentNetworkOutput.Length * 2) == 0)
            {
                for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
                {
                    stateErrorsChart.Series[j].Points.AddY((network.avgError[j]));
                }                
            }

            int weightId = 0;
            int neuronId = 0;

            networkMonitor.drawWeightsInMonitor(network);                       
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
                    logToAdd.Items.Add(Math.Abs(network.CurrentNetworkOutputError[i]));
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
            network.isTraining = true;
            trainCount = Convert.ToInt32(iterationsText.Text);
            inputSampleCount = network.Layers[0].Neurons.Count;
            string networkConfig = "";

            for (int i = 0; i < network.Layers.Count; i++)
            {
                if (i != network.Layers.Count - 1)
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count} x ";
                }
                else
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count}";
                }
                
            }

            this.Text = $"Multilayer Perceptron [Training network...] Model configuration: {networkConfig}";

            //for (int i = 0; i < errorsChart2.Series.Count; i++)
            {
                //errorsChart2.Series[i].Points.Clear();
            }

           

            int R = randomClr.Next(50, 255);
            int G = randomClr.Next(50, 255);
            int B = randomClr.Next(50, 255);

            var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series" + (epoch).ToString(),
                Color = System.Drawing.Color.FromArgb(255, R, G, B),
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3
            };

            errorsChart2.Series.Add(newSeries);
            errorsChart2.Series[epoch].Points.AddY(0);

            for (int i = 0; i < stateErrorsChart.Series.Count; i++)
            {
                stateErrorsChart.Series[i].Points.Clear();
            }

            double freq = Convert.ToDouble(signalParamText.Text);

            signal = new Signal(inputSampleCount);

            for (int i = 0; i < inputSampleCount; i += 1)
            {
                inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
            }

            for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
            {
                network.CurrentNetworkOutputError[i] = 1;
            }
                       
            int trainIteration = 1;
            int[] imageIndex = new int[network.Targets.Length];
            //int param = 0;

            while (network.isTraining)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                int param = sampleRandomizer.Next(0, Convert.ToInt32(network.Targets.Length));

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.Targets[i] = 0.01;
                }

                network.Targets[param] = 0.99;
                    
                if (signalType == SignalType.Image)
                {
                    if (imageIndex[param] == 0)
                    {
                        imageIndex[param] = 1;
                    }

                    rndAngle.Next(0, 360);
                    string pathToRandomImage = $@"mnist_png\training\{param}\" + imageIndex[param].ToString() + ".png";
                    signal.ImageFromFile(pathToRandomImage, rndAngle);
                    previewPaintBox2.Image = signal.image;
                    previewPaintBox.Image = signal.image;
                    imageIndex[param]++;
                }
                if (signalType == SignalType.Sinus)
                {
                    signal.GenerateSinus(param * 10 + 1, rndAmplitude);
                }

                inputsChart.Series[0].Points.Clear();

                for (int i = 0; i < inputSampleCount; i += 1)
                {
                    inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);
                TrainNetwork(network);
                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats(DrawOptions.DrawWeights, trainIteration);
                TestSamples(network, param);
                network.CleanOldData();
                trainIteration++;

                if (trainIteration % (network.Targets.Length * 20 + 1) == 0)
                    network.CurrentCumulativeError = 0;

                network.squaredError = 0;
                
                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.avgError[param] = 0;
                }

                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.avgError[param] += Math.Abs(network.CurrentNetworkOutputError[i] * network.CurrentNetworkOutputError[i]);                   
                }

                Application.DoEvents();                
                iterationLabel.Text = $"Sample: {trainIteration.ToString()}";
                FillProgressBar(0, trainCount, trainIteration);

                //double[] errors = new double[network.CurrentNetworkOutputError.Length];

                //for (int i = 0; i < network.CurrentNetworkOutputError.Length; i++)
                //{
                //    errors[i] += Math.Pow( (network.CurrentNetworkOutputError[i] - network.ErrorTarget), 2);
                //}

                if (trainIteration == trainCount)
                {
                    network.isTraining = false;
                    break;
                }

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                double sec = (trainCount - (double)trainIteration) * elapsedMs / 1000;
                double estimateMin = (sec - sec % 60) / 60;
                double estimateSec = Math.Round(sec % 60);
                estimateLabel.Text = $"{Math.Round((double)trainIteration / (double)trainCount * 100)} % / Performance per cycle: {elapsedMs} ms / Estimated time: {estimateMin} min {estimateSec} s";
            }
                       
            this.Text = $"Multilayer Perceptron [Ready...] Model configuration: {networkConfig}";
            recognitionTestButton.Enabled = true;
            epoch++;
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
                detectLabel.Text = "Failed";
                detectLabel.BackColor = Color.Red;
                networkToTest.CurrentCumulativeError++;                
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
            double testCount = 500;
            networkToTest.testResults = new double[networkToTest.signalParamsList.Count];
            int imageIndex = 1;
            double[] resultMatrix = new double[networkToTest.signalParamsList.Count];

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                for (int j = 0; j < testCount; j++)
                {
                    signal = new Signal(networkToTest.Layers[0].Neurons.Count);
                    rndAngle.Next(0, 360);
                    signal.ImageFromFile($@"mnist_png\testing\{i}\" + imageIndex.ToString() + ".png", rndAngle);
                    previewPaintBox2.Image = signal.image;
                    previewPaintBox.Image = signal.image;
                    Application.DoEvents();
                    imageIndex++;
                    networkToTest.SendSignalsToInputLayer(signal.Amplitude);
                    networkToTest.ForwardPropagation();
                    networkToTest.FindNetworkOutputError();
                    outputsChart.Series[0].Points.Clear();

                    for (int k = 0; k < network.CurrentNetworkOutput.Length; k++)
                    {
                        outputsChart.Series[0].Points.AddXY(k, network.CurrentNetworkOutput[k]);
                    }

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

                imageIndex = 1;
            }

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                networkToTest.testResults[i] = networkToTest.testResults[i];
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
            inputSampleCount = network.Layers[0].Neurons.Count;

            try
            {
                int imageIndex = 1;
                double param = Convert.ToDouble(signalParamText.Text);                
                signal = new Signal(inputSampleCount);

                if (signalType == SignalType.Image)
                {
                    rndAngle.Next(0, 360);
                    signal.ImageFromFile($@"mnist_png\testing\{param}\" + imageIndex.ToString() + ".png", rndAngle);
                    previewPaintBox2.Image = signal.image;
                }
                if (signalType == SignalType.Sinus)
                {
                    signal.GenerateSinus(param, rndAmplitude);
                }

                imageIndex++;

                inputsChart.Series[0].Points.Clear();

                for (int i = 0; i < inputSampleCount; i += 1)
                {
                    inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);
                network.ForwardPropagation();
                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats(DrawOptions.DontDrawWeights);
                network.CleanOldData();
                Application.DoEvents();
                
            }
            catch
            {
                MessageBox.Show("Could not pass network test :(");
            }
        }

        private void recognitionTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                network.signalParamsList.Clear();

                if (signalType == SignalType.Image)
                {
                    for (int i = 0; i < network.Targets.Length; i++)
                    {
                        network.signalParamsList.Add(i);
                    }
                }

                Validation(network);
            }
            catch
            {
                MessageBox.Show("Create network first");
            }

        }

        public void Validation (Network networkToTest)
        {
            TestRecognitionRate(networkToTest);
            string outputMessage = "";

            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                outputMessage += $"Validation rate for signal parameter ({networkToTest.signalParamsList[i]}): {networkToTest.testResults[i]} / 500 = {networkToTest.testResults[i] / 500 * 100}% \n";
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

            pencil.Width = 10f;

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

            if (signalType == SignalType.Image)
            {
                signal.ImageFromDrawer(userPaintBox);
            }

            if (!trainModeBox.Checked)
            {
                inputsChart.Series[0].Points.Clear();

                for (int i = 0; i < inputSampleCount; i += 1)
                {
                    inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);
                network.ForwardPropagation();
                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats(DrawOptions.DrawWeights);
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
            else
            {
                for (int i = 0; i < network.Targets.Length; i++)
                {
                    network.Targets[i] = 0.01;
                }

                network.Targets[trainParam] = 0.99;

                if (signalType == SignalType.Image)
                {
                    rndAngle.Next(0, 360);
                }
                if (signalType == SignalType.Sinus)
                {
                    signal.GenerateSinus(trainParam * 10 + 1, rndAmplitude);
                }

                inputsChart.Series[0].Points.Clear();

                for (int i = 0; i < inputSampleCount; i += 1)
                {
                    inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                }

                network.SendSignalsToInputLayer(signal.Amplitude);

                TrainNetwork(network);
                PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                DrawNetworkStats(DrawOptions.DrawWeights);
                TestSamples(network, trainParam);
                network.CleanOldData();

                trainParam = rndSet.Next(0, Convert.ToInt32(network.Targets.Length));                
                trainSymbol.Text = "Draw " + trainParam.ToString();

                Application.DoEvents();
            }
        }               

        private void StopTrainingButton_Click(object sender, EventArgs e)
        {
            network.isTraining = false;

            string networkConfig = "";

            for (int i = 0; i < network.Layers.Count; i++)
            {
                if (i != network.Layers.Count - 1)
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count} x ";
                }
                else
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count}";
                }

            }

            this.Text = $"Multilayer Perceptron [Ready...] Model configuration: {networkConfig}";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveModelToFile();
        }

        private void saveModelToFile()
        {
            int weightId = 0;
            int neuronId = 0;
            string weight = "";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Model.mdl");
            StreamWriter sw = File.CreateText(path);
                    
            for (int i = 0; i < network.Layers.Count; i++)
            {
                sw.WriteLine($"{i}:{network.Layers[i].Neurons.Count}");
            }

            sw.WriteLine("Weights:");

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j += 1)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                    {
                        weight = network.Layers[i].Neurons[j].Weights[k].ToString();
                        sw.WriteLine(i.ToString() + "/" + j.ToString() + "/" + weight);
                        weightId++;
                    }
                }
            }

            sw.Flush();
            sw.Close();
        }

        private void loadModelFromFile()
        {           
            string path, networkInfo, weightString;
            int neuronsCount = 0;
            int weightsCount = 0;
            String[] strlist;
            List<int> layersList = new List<int>();
            List<int> neuronsList = new List<int>();
            int strCounter = 0;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Model File (*.mdl)|*.mdl;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
               path = openFileDialog1.FileName;
            else
                return;

            StreamReader sr = File.OpenText(path);

            char[] sep = { ':' };

            while ((networkInfo = sr.ReadLine()) != "Weights:")
            {
                strlist = networkInfo.Split(sep, 2, StringSplitOptions.None);
                layersList.Add(Convert.ToInt32(strlist[0]));
                neuronsList.Add(Convert.ToInt32(strlist[1]));
                strCounter++;
            }
            
            int[] hiddenLayersNeurons = new int[neuronsList.Count-2];

            for (int i = 0; i < neuronsList.Count-2; i++)
            {
                hiddenLayersNeurons[i] = neuronsList[i + 1];
            }

            network = new Network(neuronsList[2], 0.07);
            signal = new Signal(neuronsList[0]);
            network.CreateInputLayer(neuronsList[0], neuronsList[1]);
            network.CreateHiddenLayers(hiddenLayersNeurons, neuronsList[2]);
            network.CreateOutputLayer(neuronsList[2], 0);
            PrintNetworkStats(network, signal, network, log2, LogOptions.PrintFirstState);
            DrawNetworkStats(DrawOptions.DrawWeights);
            network.CleanOldData();

            for (int i = 0; i < network.Layers.Count; i++)
            {
                for (int j = 0; j < network.Layers[i].Neurons.Count; j += 1)
                {
                    for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                    {      
                       
                        char[] separator = { '/' };

                        weightString = sr.ReadLine();
                        strlist = weightString.Split(separator, 3, StringSplitOptions.None);
                        network.Layers[i].Neurons[j].Weights[k] = Convert.ToDouble(strlist[2]);
                        weightsCount++;
                    }
                    neuronsCount++;
                }
            }
            
            trainNetworkButton.Enabled = true;
            recognitionTestButton.Enabled = true;

            if (radioButton1.Checked)
            {
                signalType = SignalType.Image;
            }

            if (radioButton2.Checked)
            {
                signalType = SignalType.Sinus;
            }

            inputSampleCount = neuronsList[0];            
            trainCount = Convert.ToInt32(iterationsText.Text);

            string networkConfig = "";

            for (int i = 0; i < network.Layers.Count; i++)
            {
                if (i != network.Layers.Count - 1)
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count} x ";
                }
                else
                {
                    networkConfig += $"{network.Layers[i].Neurons.Count}";
                }
            }
            
            MessageBox.Show($"Loaded pre-trained neural network: {networkConfig} neurons");
            this.Text = $"Multilayer Perceptron [Loaded...] Model configuration: {networkConfig}";
            networkMonitor.Show();
            networkMonitor.TopMost = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadModelFromFile();
        }
    }
}
