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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea36 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea37 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea38 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea39 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea40 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.log2 = new System.Windows.Forms.ListBox();
            this.trainNetorkButton = new System.Windows.Forms.Button();
            this.outputsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.weightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.signalsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TestButton = new System.Windows.Forms.Button();
            this.tg1 = new System.Windows.Forms.TextBox();
            this.tg2 = new System.Windows.Forms.TextBox();
            this.tg3 = new System.Windows.Forms.TextBox();
            this.signalParamTextBox = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tg6 = new System.Windows.Forms.TextBox();
            this.tg5 = new System.Windows.Forms.TextBox();
            this.tg4 = new System.Windows.Forms.TextBox();
            this.tg8 = new System.Windows.Forms.TextBox();
            this.tg7 = new System.Windows.Forms.TextBox();
            this.recognitionTestButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.tg9 = new System.Windows.Forms.TextBox();
            this.tg10 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.log.Location = new System.Drawing.Point(12, 150);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(255, 499);
            this.log.TabIndex = 1;
            // 
            // log2
            // 
            this.log2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log2.FormattingEnabled = true;
            this.log2.ItemHeight = 15;
            this.log2.Location = new System.Drawing.Point(12, 663);
            this.log2.Name = "log2";
            this.log2.Size = new System.Drawing.Size(255, 319);
            this.log2.TabIndex = 2;
            // 
            // trainNetorkButton
            // 
            this.trainNetorkButton.Enabled = false;
            this.trainNetorkButton.Location = new System.Drawing.Point(12, 80);
            this.trainNetorkButton.Name = "trainNetorkButton";
            this.trainNetorkButton.Size = new System.Drawing.Size(146, 23);
            this.trainNetorkButton.TabIndex = 3;
            this.trainNetorkButton.Text = "Train";
            this.trainNetorkButton.UseVisualStyleBackColor = true;
            this.trainNetorkButton.Click += new System.EventHandler(this.TrainNetworkButton_Click);
            // 
            // outputsChart
            // 
            chartArea36.AxisX.Title = "Network outputs";
            chartArea36.AxisY.Interval = 0.05D;
            chartArea36.AxisY.Maximum = 1D;
            chartArea36.AxisY.Minimum = 0D;
            chartArea36.AxisY.Title = "Signal amplitude";
            chartArea36.Name = "ChartArea1";
            this.outputsChart.ChartAreas.Add(chartArea36);
            this.outputsChart.Location = new System.Drawing.Point(320, 151);
            this.outputsChart.Name = "outputsChart";
            this.outputsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series36.ChartArea = "ChartArea1";
            series36.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series36.Name = "Series1";
            this.outputsChart.Series.Add(series36);
            this.outputsChart.Size = new System.Drawing.Size(192, 831);
            this.outputsChart.TabIndex = 4;
            this.outputsChart.Text = "chart1";
            // 
            // errorsChart
            // 
            chartArea37.AxisX.Title = "Output targets";
            chartArea37.AxisY.Interval = 0.1D;
            chartArea37.AxisY.Maximum = 1D;
            chartArea37.AxisY.Minimum = -1D;
            chartArea37.AxisY.Title = "Current error";
            chartArea37.Name = "ChartArea1";
            this.errorsChart.ChartAreas.Add(chartArea37);
            this.errorsChart.Location = new System.Drawing.Point(518, 151);
            this.errorsChart.Name = "errorsChart";
            this.errorsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series37.ChartArea = "ChartArea1";
            series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series37.MarkerSize = 30;
            series37.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series37.Name = "Series1";
            series37.YValuesPerPoint = 4;
            this.errorsChart.Series.Add(series37);
            this.errorsChart.Size = new System.Drawing.Size(191, 831);
            this.errorsChart.TabIndex = 5;
            this.errorsChart.Text = "chart2";
            // 
            // weightsChart
            // 
            chartArea38.AxisX.Interval = 1D;
            chartArea38.AxisX.Title = "Synapses";
            chartArea38.AxisY.Title = "Weights";
            chartArea38.BackColor = System.Drawing.Color.Black;
            chartArea38.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea38);
            this.weightsChart.Location = new System.Drawing.Point(715, 151);
            this.weightsChart.Name = "weightsChart";
            this.weightsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series38.ChartArea = "ChartArea1";
            series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series38.Color = System.Drawing.Color.Black;
            series38.MarkerBorderColor = System.Drawing.Color.White;
            series38.MarkerSize = 1;
            series38.Name = "Series1";
            series38.ShadowColor = System.Drawing.Color.White;
            this.weightsChart.Series.Add(series38);
            this.weightsChart.Size = new System.Drawing.Size(702, 831);
            this.weightsChart.TabIndex = 6;
            this.weightsChart.Text = "chart3";
            // 
            // signalsChart
            // 
            chartArea39.AxisX.Title = "Neuron";
            chartArea39.AxisY.Maximum = 2D;
            chartArea39.AxisY.Minimum = 0D;
            chartArea39.AxisY.Title = "Neuron signal amplitude";
            chartArea39.Name = "ChartArea1";
            this.signalsChart.ChartAreas.Add(chartArea39);
            this.signalsChart.Location = new System.Drawing.Point(1423, 150);
            this.signalsChart.Name = "signalsChart";
            this.signalsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series39.ChartArea = "ChartArea1";
            series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series39.Name = "Series1";
            this.signalsChart.Series.Add(series39);
            this.signalsChart.Size = new System.Drawing.Size(460, 832);
            this.signalsChart.TabIndex = 7;
            this.signalsChart.Text = "chart4";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(12, 109);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(146, 23);
            this.TestButton.TabIndex = 8;
            this.TestButton.Text = "Recognize";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // tg1
            // 
            this.tg1.Location = new System.Drawing.Point(12, 41);
            this.tg1.Name = "tg1";
            this.tg1.Size = new System.Drawing.Size(100, 22);
            this.tg1.TabIndex = 9;
            this.tg1.Text = "0,99";
            // 
            // tg2
            // 
            this.tg2.Location = new System.Drawing.Point(214, 41);
            this.tg2.Name = "tg2";
            this.tg2.Size = new System.Drawing.Size(100, 22);
            this.tg2.TabIndex = 10;
            this.tg2.Tag = "";
            this.tg2.Text = "0,01";
            // 
            // tg3
            // 
            this.tg3.Location = new System.Drawing.Point(143, 165);
            this.tg3.Name = "tg3";
            this.tg3.Size = new System.Drawing.Size(100, 22);
            this.tg3.TabIndex = 11;
            this.tg3.Text = "0,01";
            // 
            // signalParamTextBox
            // 
            this.signalParamTextBox.Location = new System.Drawing.Point(259, 80);
            this.signalParamTextBox.Name = "signalParamTextBox";
            this.signalParamTextBox.Size = new System.Drawing.Size(56, 22);
            this.signalParamTextBox.TabIndex = 19;
            this.signalParamTextBox.Text = "0";
            // 
            // chart1
            // 
            chartArea40.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea40);
            this.chart1.Location = new System.Drawing.Point(320, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series40.BorderWidth = 2;
            series40.ChartArea = "ChartArea1";
            series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series40.Name = "Series1";
            this.chart1.Series.Add(series40);
            this.chart1.Size = new System.Drawing.Size(1563, 133);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // tg6
            // 
            this.tg6.Location = new System.Drawing.Point(143, 249);
            this.tg6.Name = "tg6";
            this.tg6.Size = new System.Drawing.Size(100, 22);
            this.tg6.TabIndex = 23;
            this.tg6.Text = "0,01";
            // 
            // tg5
            // 
            this.tg5.Location = new System.Drawing.Point(143, 221);
            this.tg5.Name = "tg5";
            this.tg5.Size = new System.Drawing.Size(100, 22);
            this.tg5.TabIndex = 22;
            this.tg5.Tag = "";
            this.tg5.Text = "0,01";
            // 
            // tg4
            // 
            this.tg4.Location = new System.Drawing.Point(143, 193);
            this.tg4.Name = "tg4";
            this.tg4.Size = new System.Drawing.Size(100, 22);
            this.tg4.TabIndex = 21;
            this.tg4.Text = "0,01";
            // 
            // tg8
            // 
            this.tg8.Location = new System.Drawing.Point(143, 305);
            this.tg8.Name = "tg8";
            this.tg8.Size = new System.Drawing.Size(100, 22);
            this.tg8.TabIndex = 25;
            this.tg8.Tag = "";
            this.tg8.Text = "0,01";
            this.tg8.TextChanged += new System.EventHandler(this.tg8_TextChanged);
            // 
            // tg7
            // 
            this.tg7.Location = new System.Drawing.Point(143, 277);
            this.tg7.Name = "tg7";
            this.tg7.Size = new System.Drawing.Size(100, 22);
            this.tg7.TabIndex = 24;
            this.tg7.Text = "0,01";
            // 
            // recognitionTestButton
            // 
            this.recognitionTestButton.Location = new System.Drawing.Point(169, 109);
            this.recognitionTestButton.Name = "recognitionTestButton";
            this.recognitionTestButton.Size = new System.Drawing.Size(146, 23);
            this.recognitionTestButton.TabIndex = 26;
            this.recognitionTestButton.Text = "Recognition test";
            this.recognitionTestButton.UseVisualStyleBackColor = true;
            this.recognitionTestButton.Click += new System.EventHandler(this.recognitionTestButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(518, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.Location = new System.Drawing.Point(818, 198);
            this.iterationLabel.Name = "iterationLabel";
            this.iterationLabel.Size = new System.Drawing.Size(67, 17);
            this.iterationLabel.TabIndex = 28;
            this.iterationLabel.Text = "iteration: ";
            // 
            // tg9
            // 
            this.tg9.Location = new System.Drawing.Point(143, 333);
            this.tg9.Name = "tg9";
            this.tg9.Size = new System.Drawing.Size(100, 22);
            this.tg9.TabIndex = 29;
            this.tg9.Tag = "";
            this.tg9.Text = "0,01";
            // 
            // tg10
            // 
            this.tg10.Location = new System.Drawing.Point(143, 361);
            this.tg10.Name = "tg10";
            this.tg10.Size = new System.Drawing.Size(100, 22);
            this.tg10.TabIndex = 30;
            this.tg10.Tag = "";
            this.tg10.Text = "0,01";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 994);
            this.Controls.Add(this.log2);
            this.Controls.Add(this.tg10);
            this.Controls.Add(this.tg9);
            this.Controls.Add(this.iterationLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.recognitionTestButton);
            this.Controls.Add(this.tg8);
            this.Controls.Add(this.tg7);
            this.Controls.Add(this.tg6);
            this.Controls.Add(this.tg5);
            this.Controls.Add(this.tg4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.signalParamTextBox);
            this.Controls.Add(this.tg3);
            this.Controls.Add(this.tg2);
            this.Controls.Add(this.tg1);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.signalsChart);
            this.Controls.Add(this.weightsChart);
            this.Controls.Add(this.errorsChart);
            this.Controls.Add(this.outputsChart);
            this.Controls.Add(this.trainNetorkButton);
            this.Controls.Add(this.log);
            this.Controls.Add(this.testNetworkButton);
            this.Name = "MainForm";
            this.Text = "Multilayer perceptron";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ListBox log2;
        private System.Windows.Forms.Button trainNetorkButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart weightsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart signalsChart;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox tg1;
        private System.Windows.Forms.TextBox tg2;
        private System.Windows.Forms.TextBox tg3;
        private System.Windows.Forms.TextBox signalParamTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox tg6;
        private System.Windows.Forms.TextBox tg5;
        private System.Windows.Forms.TextBox tg4;
        private System.Windows.Forms.TextBox tg8;
        private System.Windows.Forms.TextBox tg7;
        private System.Windows.Forms.Button recognitionTestButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label iterationLabel;
        private System.Windows.Forms.TextBox tg9;
        private System.Windows.Forms.TextBox tg10;
    }
}

