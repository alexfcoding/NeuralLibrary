namespace MyNeuralNetwork
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.log2 = new System.Windows.Forms.ListBox();
            this.outputsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.signalsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tg3 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tg6 = new System.Windows.Forms.TextBox();
            this.tg5 = new System.Windows.Forms.TextBox();
            this.tg4 = new System.Windows.Forms.TextBox();
            this.tg8 = new System.Windows.Forms.TextBox();
            this.tg7 = new System.Windows.Forms.TextBox();
            this.previewPaintBox2 = new System.Windows.Forms.PictureBox();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.tg9 = new System.Windows.Forms.TextBox();
            this.tg10 = new System.Windows.Forms.TextBox();
            this.userPaintBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.learningRateText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputsText = new System.Windows.Forms.TextBox();
            this.hiddenText = new System.Windows.Forms.TextBox();
            this.inputsText = new System.Windows.Forms.TextBox();
            this.iterationsText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trainNetorkButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.recognitionTestButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorsChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.signalParamText = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.previewPaintBox = new System.Windows.Forms.PictureBox();
            this.detectLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPaintBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPaintBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPaintBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Location = new System.Drawing.Point(12, 12);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(302, 23);
            this.testNetworkButton.TabIndex = 0;
            this.testNetworkButton.Text = "Create Network";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log.FormattingEnabled = true;
            this.log.ItemHeight = 15;
            this.log.Location = new System.Drawing.Point(12, 345);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(302, 244);
            this.log.TabIndex = 1;
            // 
            // log2
            // 
            this.log2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log2.FormattingEnabled = true;
            this.log2.ItemHeight = 15;
            this.log2.Location = new System.Drawing.Point(12, 270);
            this.log2.Name = "log2";
            this.log2.Size = new System.Drawing.Size(302, 709);
            this.log2.TabIndex = 2;
            // 
            // outputsChart
            // 
            chartArea7.AxisX.Title = "Output neurons";
            chartArea7.AxisY.Interval = 0.05D;
            chartArea7.AxisY.Maximum = 1D;
            chartArea7.AxisY.Minimum = 0D;
            chartArea7.AxisY.Title = "Signal amplitude";
            chartArea7.Name = "ChartArea1";
            this.outputsChart.ChartAreas.Add(chartArea7);
            this.outputsChart.Location = new System.Drawing.Point(320, 229);
            this.outputsChart.Name = "outputsChart";
            series6.ChartArea = "ChartArea1";
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series6.Name = "Series1";
            this.outputsChart.Series.Add(series6);
            this.outputsChart.Size = new System.Drawing.Size(255, 753);
            this.outputsChart.TabIndex = 4;
            this.outputsChart.Text = "chart1";
            // 
            // errorsChart
            // 
            chartArea8.AxisX.Title = "Output neurons";
            chartArea8.AxisY.Interval = 0.1D;
            chartArea8.AxisY.Maximum = 1D;
            chartArea8.AxisY.Minimum = -1D;
            chartArea8.AxisY.Title = "Error";
            chartArea8.Name = "ChartArea1";
            this.errorsChart.ChartAreas.Add(chartArea8);
            this.errorsChart.Location = new System.Drawing.Point(581, 229);
            this.errorsChart.Name = "errorsChart";
            this.errorsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Color = System.Drawing.Color.Red;
            series7.MarkerSize = 15;
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series7.Name = "Series1";
            series7.YValuesPerPoint = 4;
            this.errorsChart.Series.Add(series7);
            this.errorsChart.Size = new System.Drawing.Size(255, 753);
            this.errorsChart.TabIndex = 5;
            this.errorsChart.Text = "chart2";
            // 
            // rateChart
            // 
            this.rateChart.BorderlineColor = System.Drawing.Color.Empty;
            chartArea9.AxisX.Interval = 1D;
            chartArea9.AxisX.Title = "Classes";
            chartArea9.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea9.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea9.AxisY.Maximum = 100D;
            chartArea9.AxisY.Minimum = 0D;
            chartArea9.AxisY.Title = "Recogniton rate, %";
            chartArea9.BackColor = System.Drawing.Color.White;
            chartArea9.Name = "ChartArea1";
            this.rateChart.ChartAreas.Add(chartArea9);
            this.rateChart.Location = new System.Drawing.Point(1048, 756);
            this.rateChart.Name = "rateChart";
            this.rateChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Red;
            series8.MarkerBorderColor = System.Drawing.Color.White;
            series8.MarkerSize = 1;
            series8.Name = "Series1";
            series8.ShadowColor = System.Drawing.Color.White;
            this.rateChart.Series.Add(series8);
            this.rateChart.Size = new System.Drawing.Size(852, 226);
            this.rateChart.TabIndex = 6;
            this.rateChart.Text = "chart3";
            // 
            // signalsChart
            // 
            chartArea10.AxisX.Title = "All neurons";
            chartArea10.AxisY.Maximum = 1D;
            chartArea10.AxisY.Minimum = 0D;
            chartArea10.AxisY.Title = "Amplitude";
            chartArea10.Name = "ChartArea1";
            this.signalsChart.ChartAreas.Add(chartArea10);
            this.signalsChart.Location = new System.Drawing.Point(842, 229);
            this.signalsChart.Name = "signalsChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series9.Name = "Series1";
            this.signalsChart.Series.Add(series9);
            this.signalsChart.Size = new System.Drawing.Size(200, 753);
            this.signalsChart.TabIndex = 7;
            this.signalsChart.Text = "chart4";
            // 
            // tg3
            // 
            this.tg3.Location = new System.Drawing.Point(195, 349);
            this.tg3.Name = "tg3";
            this.tg3.Size = new System.Drawing.Size(100, 22);
            this.tg3.TabIndex = 11;
            this.tg3.Text = "0,01";
            this.tg3.Visible = false;
            // 
            // chart1
            // 
            chartArea11.AxisX.Title = "Input neurons";
            chartArea11.AxisY.Title = "Amplitude";
            chartArea11.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea11);
            this.chart1.Location = new System.Drawing.Point(320, 77);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Black;
            series10.Name = "Series1";
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(1580, 146);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // tg6
            // 
            this.tg6.Location = new System.Drawing.Point(195, 433);
            this.tg6.Name = "tg6";
            this.tg6.Size = new System.Drawing.Size(100, 22);
            this.tg6.TabIndex = 23;
            this.tg6.Text = "0,01";
            this.tg6.Visible = false;
            // 
            // tg5
            // 
            this.tg5.Location = new System.Drawing.Point(195, 405);
            this.tg5.Name = "tg5";
            this.tg5.Size = new System.Drawing.Size(100, 22);
            this.tg5.TabIndex = 22;
            this.tg5.Tag = "";
            this.tg5.Text = "0,01";
            this.tg5.Visible = false;
            // 
            // tg4
            // 
            this.tg4.Location = new System.Drawing.Point(195, 377);
            this.tg4.Name = "tg4";
            this.tg4.Size = new System.Drawing.Size(100, 22);
            this.tg4.TabIndex = 21;
            this.tg4.Text = "0,01";
            this.tg4.Visible = false;
            // 
            // tg8
            // 
            this.tg8.Location = new System.Drawing.Point(195, 489);
            this.tg8.Name = "tg8";
            this.tg8.Size = new System.Drawing.Size(100, 22);
            this.tg8.TabIndex = 25;
            this.tg8.Tag = "";
            this.tg8.Text = "0,01";
            this.tg8.Visible = false;
            // 
            // tg7
            // 
            this.tg7.Location = new System.Drawing.Point(195, 461);
            this.tg7.Name = "tg7";
            this.tg7.Size = new System.Drawing.Size(100, 22);
            this.tg7.TabIndex = 24;
            this.tg7.Text = "0,01";
            this.tg7.Visible = false;
            // 
            // previewPaintBox2
            // 
            this.previewPaintBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previewPaintBox2.Location = new System.Drawing.Point(354, 35);
            this.previewPaintBox2.Name = "previewPaintBox2";
            this.previewPaintBox2.Size = new System.Drawing.Size(28, 28);
            this.previewPaintBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPaintBox2.TabIndex = 27;
            this.previewPaintBox2.TabStop = false;
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.BackColor = System.Drawing.Color.White;
            this.iterationLabel.Location = new System.Drawing.Point(330, 201);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(67, 17);
            this.iterationLabel.TabIndex = 28;
            this.iterationLabel.Text = "Iteration: ";
            // 
            // tg9
            // 
            this.tg9.Location = new System.Drawing.Point(195, 517);
            this.tg9.Name = "tg9";
            this.tg9.Size = new System.Drawing.Size(100, 22);
            this.tg9.TabIndex = 29;
            this.tg9.Tag = "";
            this.tg9.Text = "0,01";
            this.tg9.Visible = false;
            // 
            // tg10
            // 
            this.tg10.Location = new System.Drawing.Point(195, 545);
            this.tg10.Name = "tg10";
            this.tg10.Size = new System.Drawing.Size(100, 22);
            this.tg10.TabIndex = 30;
            this.tg10.Tag = "";
            this.tg10.Text = "0,01";
            this.tg10.Visible = false;
            // 
            // userPaintBox
            // 
            this.userPaintBox.BackColor = System.Drawing.Color.Black;
            this.userPaintBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPaintBox.Location = new System.Drawing.Point(403, 35);
            this.userPaintBox.Name = "userPaintBox";
            this.userPaintBox.Size = new System.Drawing.Size(28, 28);
            this.userPaintBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPaintBox.TabIndex = 31;
            this.userPaintBox.TabStop = false;
            this.userPaintBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.userPaintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.userPaintBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(451, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 31);
            this.label1.TabIndex = 33;
            this.label1.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.learningRateText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.outputsText);
            this.groupBox1.Controls.Add(this.hiddenText);
            this.groupBox1.Controls.Add(this.inputsText);
            this.groupBox1.Controls.Add(this.iterationsText);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 222);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layers configuration";
            // 
            // learningRateText
            // 
            this.learningRateText.Location = new System.Drawing.Point(92, 126);
            this.learningRateText.Name = "learningRateText";
            this.learningRateText.Size = new System.Drawing.Size(40, 22);
            this.learningRateText.TabIndex = 45;
            this.learningRateText.Text = "0,07";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Iterations:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Outputs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Hidden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Inputs:";
            // 
            // outputsText
            // 
            this.outputsText.Location = new System.Drawing.Point(92, 93);
            this.outputsText.Name = "outputsText";
            this.outputsText.Size = new System.Drawing.Size(40, 22);
            this.outputsText.TabIndex = 39;
            this.outputsText.Text = "10";
            // 
            // hiddenText
            // 
            this.hiddenText.Location = new System.Drawing.Point(92, 61);
            this.hiddenText.Name = "hiddenText";
            this.hiddenText.Size = new System.Drawing.Size(40, 22);
            this.hiddenText.TabIndex = 38;
            this.hiddenText.Text = "200";
            // 
            // inputsText
            // 
            this.inputsText.Location = new System.Drawing.Point(92, 29);
            this.inputsText.Name = "inputsText";
            this.inputsText.Size = new System.Drawing.Size(40, 22);
            this.inputsText.TabIndex = 37;
            this.inputsText.Text = "784";
            // 
            // iterationsText
            // 
            this.iterationsText.Location = new System.Drawing.Point(92, 160);
            this.iterationsText.Name = "iterationsText";
            this.iterationsText.Size = new System.Drawing.Size(40, 22);
            this.iterationsText.TabIndex = 35;
            this.iterationsText.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Param:";
            // 
            // trainNetorkButton
            // 
            this.trainNetorkButton.Enabled = false;
            this.trainNetorkButton.Location = new System.Drawing.Point(180, 182);
            this.trainNetorkButton.Name = "trainNetorkButton";
            this.trainNetorkButton.Size = new System.Drawing.Size(134, 23);
            this.trainNetorkButton.TabIndex = 3;
            this.trainNetorkButton.Text = "Train";
            this.trainNetorkButton.UseVisualStyleBackColor = true;
            this.trainNetorkButton.Click += new System.EventHandler(this.TrainNetworkButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(180, 211);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(134, 23);
            this.TestButton.TabIndex = 8;
            this.TestButton.Text = "Recognize";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // recognitionTestButton
            // 
            this.recognitionTestButton.Location = new System.Drawing.Point(180, 240);
            this.recognitionTestButton.Name = "recognitionTestButton";
            this.recognitionTestButton.Size = new System.Drawing.Size(134, 23);
            this.recognitionTestButton.TabIndex = 26;
            this.recognitionTestButton.Text = "Recognition rate";
            this.recognitionTestButton.UseVisualStyleBackColor = true;
            this.recognitionTestButton.Click += new System.EventHandler(this.recognitionTestButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(481, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1419, 14);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 36;
            // 
            // errorsChart2
            // 
            chartArea12.AxisX.InterlacedColor = System.Drawing.Color.Black;
            chartArea12.AxisX.Title = "Dataset sample x50";
            chartArea12.AxisY.InterlacedColor = System.Drawing.Color.Black;
            chartArea12.AxisY.Title = "Error";
            chartArea12.BackColor = System.Drawing.Color.White;
            chartArea12.Name = "ChartArea1";
            this.errorsChart2.ChartAreas.Add(chartArea12);
            this.errorsChart2.Location = new System.Drawing.Point(1048, 229);
            this.errorsChart2.Name = "errorsChart2";
            this.errorsChart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            this.errorsChart2.Size = new System.Drawing.Size(852, 235);
            this.errorsChart2.TabIndex = 37;
            this.errorsChart2.Text = "chart2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.signalParamText);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(182, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 132);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // signalParamText
            // 
            this.signalParamText.Location = new System.Drawing.Point(65, 92);
            this.signalParamText.Name = "signalParamText";
            this.signalParamText.Size = new System.Drawing.Size(35, 22);
            this.signalParamText.TabIndex = 45;
            this.signalParamText.Tag = "";
            this.signalParamText.Text = "9";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(122, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Function mode";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Image mode";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // previewPaintBox
            // 
            this.previewPaintBox.BackColor = System.Drawing.Color.Black;
            this.previewPaintBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPaintBox.Location = new System.Drawing.Point(1048, 470);
            this.previewPaintBox.Name = "previewPaintBox";
            this.previewPaintBox.Size = new System.Drawing.Size(280, 280);
            this.previewPaintBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPaintBox.TabIndex = 39;
            this.previewPaintBox.TabStop = false;
            // 
            // detectLabel
            // 
            this.detectLabel.AutoSize = true;
            this.detectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detectLabel.Location = new System.Drawing.Point(1051, 722);
            this.detectLabel.Name = "detectLabel";
            this.detectLabel.Size = new System.Drawing.Size(19, 25);
            this.detectLabel.TabIndex = 40;
            this.detectLabel.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1334, 470);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(1620, 470);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(280, 280);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 128F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1671, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 243);
            this.label8.TabIndex = 43;
            this.label8.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(478, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 25);
            this.label9.TabIndex = 44;
            this.label9.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1924, 994);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.detectLabel);
            this.Controls.Add(this.previewPaintBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.errorsChart2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userPaintBox);
            this.Controls.Add(this.log2);
            this.Controls.Add(this.tg10);
            this.Controls.Add(this.tg9);
            this.Controls.Add(this.iterationLabel);
            this.Controls.Add(this.previewPaintBox2);
            this.Controls.Add(this.recognitionTestButton);
            this.Controls.Add(this.tg8);
            this.Controls.Add(this.tg7);
            this.Controls.Add(this.tg6);
            this.Controls.Add(this.tg5);
            this.Controls.Add(this.tg4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tg3);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.signalsChart);
            this.Controls.Add(this.rateChart);
            this.Controls.Add(this.errorsChart);
            this.Controls.Add(this.outputsChart);
            this.Controls.Add(this.trainNetorkButton);
            this.Controls.Add(this.log);
            this.Controls.Add(this.testNetworkButton);
            this.Name = "MainForm";
            this.Text = "Multilayer perceptron";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewPaintBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPaintBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPaintBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ListBox log2;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart rateChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart signalsChart;
        private System.Windows.Forms.TextBox tg3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox tg6;
        private System.Windows.Forms.TextBox tg5;
        private System.Windows.Forms.TextBox tg4;
        private System.Windows.Forms.TextBox tg8;
        private System.Windows.Forms.TextBox tg7;
        private System.Windows.Forms.PictureBox previewPaintBox2;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.TextBox tg9;
        private System.Windows.Forms.TextBox tg10;
        private System.Windows.Forms.PictureBox userPaintBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputsText;
        private System.Windows.Forms.TextBox hiddenText;
        private System.Windows.Forms.TextBox inputsText;
        private System.Windows.Forms.TextBox iterationsText;
        private System.Windows.Forms.Button trainNetorkButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button recognitionTestButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorsChart2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox learningRateText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox signalParamText;
        private System.Windows.Forms.PictureBox previewPaintBox;
        private System.Windows.Forms.Label detectLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

