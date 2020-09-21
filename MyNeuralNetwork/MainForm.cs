using System;
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
        ModelConstructor networkForm;
        SignalType signalType;
        Monitor networkMonitor = new Monitor();

        int trainCount;
        int inputSampleCount;
        int trainParam;
        int epochs;
        int chartCount = 0;

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

            if (radioButton3.Checked)
            {
                signalType = SignalType.Image;
            }

            networkForm.SendNetworkSetup += new EventHandler(form2_SendNetworkSetup);           
            networkForm.Show();
            networkForm.Top = this.Top + this.Height / 2 - networkForm.Width / 2;
            networkForm.Left = this.Left + this.Width / 2 - networkForm.Width / 2;
            networkForm.TopMost = true;

            trainNetworkButton.Enabled = true;
            callModelConstructorButton.Text = "Create network";

            //int R = randomClr.Next(0, 255);
            //int G = randomClr.Next(0, 255);
            //int B = randomClr.Next(0, 255);

            //var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            //{
            //    Name = "Series" + (chartCount).ToString(),
            //    Color = System.Drawing.Color.FromArgb(255, R, G, B),
            //    IsVisibleInLegend = false,
            //    IsXValueIndexed = false,
            //    ChartType = SeriesChartType.Spline,
            //    BorderWidth = 3
            //};

            //errorsChart2.Series.Add(newSeries);
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
                        BorderWidth = 3
                    };

                    stateErrorsChart.Series.Add(newSeries);
                }
               
                if (errorsChart2.Series.Count > 0)
                {
                    errorsChart2.Series[0].Points.AddY(0);
                }
                

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

            if (trainIteration % (200) == 0)
            {
                errorsChart2.Series[errorsChart2.Series.Count-1].Points.AddXY(trainIteration, (double)network.CurrentRecognitionCount / 200 * 100);
                network.CurrentRecognitionCount = 0;
            }

            if (trainIteration % (network.CurrentNetworkOutput.Length * 2) == 0)
            {
                double sumError = 0;

                for (int j = 0; j < network.CurrentNetworkOutput.Length; j++)
                {                    
                    if (errorsCheckBox.Checked)
                    {
                        sumError += network.squaredError[j];
                    }
                    else
                    {
                        stateErrorsChart.Series[j].Points.AddY((network.squaredError[j]));
                    }                    
                }

                if (errorsCheckBox.Checked)
                {
                    stateErrorsChart.Series[0].Points.AddY(sumError / network.CurrentNetworkOutput.Length);
                }
            }

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
            epochs = Convert.ToInt32(epochsTextBox.Text);
            int epochIteration = 0;

            for (int epoch = 0; epoch < epochs; epoch++)
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

                for (int i = 0; i < errorsChart2.Series.Count; i++)
                {
                    errorsChart2.Series[i].Points.Clear();
                }

                int R = randomClr.Next(0, 255);
                int G = randomClr.Next(0, 255);
                int B = randomClr.Next(0, 255);

                var newSeries2 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Series" + (chartCount).ToString(),
                    Color = System.Drawing.Color.FromArgb(255, R, G, B),
                    IsVisibleInLegend = false,
                    IsXValueIndexed = false,
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                };

                errorsChart2.Series.Add(newSeries2);

                chartCount++;
                errorsChart2.Series[chartCount-1].Points.AddY(0);

                

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

                while (network.isTraining)
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    int param = sampleRandomizer.Next(0, Convert.ToInt32(network.Targets.Length));
                
                    int param2 = sampleRandomizer.Next(1, trainCount);

                    network.SetTarget(param);
                    
                    if (signalType == SignalType.Image)
                    {
                        if (imageIndex[param] == 0)
                        {
                            imageIndex[param] = 1;
                        }

                        rndAngle.Next(0, 360);
                        string pathToRandomImage = $@"mnist_png\training\{param}\" + imageIndex[param].ToString() + ".png";
                        //string pathToRandomImage = $@"mnist_png\training\{param}\" + param2.ToString() + ".png";
                        signal.ImageFromFile(pathToRandomImage, rndAngle);
                        previewPaintBox2.Image = signal.image;
                        previewPaintBox.Image = signal.image;
                        imageIndex[param]++;
                    }
                    if (signalType == SignalType.Sinus)
                    {
                        signal.GenerateSinus(param*10 + 1, rndAmplitude);
                    }

                    inputsChart.Series[0].Points.Clear();

                    for (int i = 0; i < inputSampleCount; i += 1)
                    {
                        inputsChart.Series[0].Points.AddXY(i, signal.Amplitude[i]);
                    }

                    trainIteration++;

                    network.SendSignalsToInputLayer(signal.Amplitude);
                    TrainNetwork(network);
                    //PrintNetworkStats(network, signal, network, log2, LogOptions.PrintTrainingNetwork);
                    DrawNetworkStats(DrawOptions.DrawWeights, trainIteration);
                    TestSamples(network, param);
                    network.CleanOldData();
                                                            

                    for (int i = 0; i < network.Targets.Length; i++)
                    {
                        network.squaredError[param] = 0;
                    }

                    for (int i = 0; i < network.Targets.Length; i++)
                    {
                        network.squaredError[param] += (network.CurrentNetworkOutputError[i] * network.CurrentNetworkOutputError[i]);                   
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
                    int totalIterations = trainCount * epochs;
                    epochIteration++;
                    double sec = (totalIterations - epochIteration) * elapsedMs / 1000;
                    double estimateMin = (sec - sec % 60) / 60;
                    double estimateSec = Math.Round(sec % 60);
                    estimateLabel.Text = $"{Math.Round((double)epochIteration / totalIterations * 100)} % / Epoch: {epoch + 1} / Performance per cycle: {elapsedMs} ms / Estimated time: {estimateMin} min {estimateSec} s";
                }
                       
                this.Text = $"Multilayer Perceptron [Ready...] Model configuration: {networkConfig}";
                recognitionTestButton.Enabled = true;                
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
                networkToTest.CurrentRecognitionCount++;
            }
            else
            {
                detectLabel.Text = "Failed";
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
            double testCount = 500;
            networkToTest.testResults = new double[networkToTest.signalParamsList.Count];
            int imageIndex = 1;
            int frequency = 1; 
            double[] resultMatrix = new double[networkToTest.signalParamsList.Count];
                       
            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                network.SetTarget(i);

                for (int j = 0; j < testCount; j++)
                {
                    if (network.isValidating)
                    {
                        signal = new Signal(networkToTest.Layers[0].Neurons.Count);
                        int param = sampleRandomizer.Next(0, Convert.ToInt32(network.Targets.Length));

                        if (signalType == SignalType.Image)
                        {            
                            rndAngle.Next(0, 360);
                            signal.ImageFromFile($@"mnist_png\testing\{i}\" + imageIndex.ToString() + ".png", rndAngle);
                            previewPaintBox2.Image = signal.image;
                            previewPaintBox.Image = signal.image;
                        }

                        if (signalType == SignalType.Sinus)
                        {
                            signal.GenerateSinus(i * 10 + 1, rndAmplitude);
                        }

                        Application.DoEvents();
                        imageIndex++;
                        frequency++;
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

                        inputsChart.Series[0].Points.Clear();

                        for (int k = 0; k < inputSampleCount; k += 1)
                        {
                            inputsChart.Series[0].Points.AddXY(k, signal.Amplitude[k]);
                        }

                        outputsChart.Series[0].Points.Clear();
                        errorsChart.Series[0].Points.Clear();

                        for (int k = 0; k < network.CurrentNetworkOutput.Length; k++)
                        {
                            outputsChart.Series[0].Points.AddXY(k, network.CurrentNetworkOutput[k]);
                            errorsChart.Series[0].Points.AddXY(k, network.Targets[k] - network.CurrentNetworkOutput[k]);
                        }

                        networkToTest.CleanOldData();
                    }
                }

                imageIndex = 1;
                frequency = 1;
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
            network.isValidating = true;

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

                if (signalType == SignalType.Sinus)
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
            double validatedCorrectlyCount = 0;
            for (int i = 0; i < networkToTest.signalParamsList.Count; i++)
            {
                validatedCorrectlyCount += (int)networkToTest.testResults[i];
                outputMessage += $"Validation rate for class ({networkToTest.signalParamsList[i]}): {networkToTest.testResults[i]} / 500 = {networkToTest.testResults[i] / 500 * 100}% \n";
            }

           outputMessage += "\n";
           outputMessage += $"Total Accuracy: {validatedCorrectlyCount}/{(500 * networkToTest.signalParamsList.Count)}={validatedCorrectlyCount / (500 * networkToTest.signalParamsList.Count) * 100}% \n";

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
            inputSampleCount = network.Layers[0].Neurons.Count;
            signal = new Signal(inputSampleCount);

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

                if (radioButton3.Checked)
                {
                    pictureBox3.Load($@"icons\\{maxIndex}.png");
                }
            }            
            else
            {
                network.SetTarget(trainParam);

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
            network.isValidating = false;            
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
            
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathToSave;
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "Model File (*.mdl)|*.mdl;";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                pathToSave = saveFileDialog1.FileName;
            else
                return;

            saveFileDialog1.FileName = "";
            saveModelToFile(pathToSave);
        }

        private void saveModelToFile(string path)
        {
            int weightId = 0;            
            string weight = "";
            
            StreamWriter sw = File.CreateText(path);
                    
            try
            {
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
            catch
            {
                MessageBox.Show("There is nothing to save, create network first");
            }
            
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

            int R = randomClr.Next(0, 255);
            int G = randomClr.Next(0, 255);
            int B = randomClr.Next(0, 255);

            var newSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series" + (chartCount).ToString(),
                Color = System.Drawing.Color.FromArgb(255, R, G, B),
                IsVisibleInLegend = false,
                IsXValueIndexed = false,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3
            };

            errorsChart2.Series.Add(newSeries);
            errorsChart2.Series[chartCount].Points.AddY(0);

            chartCount++;

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

            network = new Network(neuronsList[neuronsList.Count-1], 0.07);
            signal = new Signal(neuronsList[0]);
            network.CreateInputLayer(neuronsList[0], neuronsList[1]);
            network.CreateHiddenLayers(hiddenLayersNeurons, neuronsList[neuronsList.Count - 1]);
            network.CreateOutputLayer(neuronsList[neuronsList.Count - 1], 0);
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

            if (radioButton3.Checked)
            {
                signalType = SignalType.Image;
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pictureBox3.Visible = true;
            }
            else
            {
                pictureBox3.Visible = false;
            }
        }
    }
}
