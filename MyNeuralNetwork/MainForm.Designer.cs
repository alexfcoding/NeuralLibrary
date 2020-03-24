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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.log.Size = new System.Drawing.Size(302, 664);
            this.log.TabIndex = 1;
            // 
            // log2
            // 
            this.log2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log2.FormattingEnabled = true;
            this.log2.ItemHeight = 15;
            this.log2.Location = new System.Drawing.Point(12, 827);
            this.log2.Name = "log2";
            this.log2.Size = new System.Drawing.Size(302, 154);
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
            chartArea1.AxisX.Title = "Network outputs";
            chartArea1.AxisY.Interval = 0.05D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Signal amplitude";
            chartArea1.Name = "ChartArea1";
            this.outputsChart.ChartAreas.Add(chartArea1);
            this.outputsChart.Location = new System.Drawing.Point(320, 150);
            this.outputsChart.Name = "outputsChart";
            this.outputsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.outputsChart.Series.Add(series1);
            this.outputsChart.Size = new System.Drawing.Size(192, 831);
            this.outputsChart.TabIndex = 4;
            this.outputsChart.Text = "chart1";
            // 
            // errorsChart
            // 
            chartArea2.AxisX.Title = "Output targets";
            chartArea2.AxisY.Interval = 0.1D;
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = -1D;
            chartArea2.AxisY.Title = "Current error";
            chartArea2.Name = "ChartArea1";
            this.errorsChart.ChartAreas.Add(chartArea2);
            this.errorsChart.Location = new System.Drawing.Point(518, 151);
            this.errorsChart.Name = "errorsChart";
            this.errorsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.MarkerSize = 30;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.errorsChart.Series.Add(series2);
            this.errorsChart.Size = new System.Drawing.Size(191, 831);
            this.errorsChart.TabIndex = 5;
            this.errorsChart.Text = "chart2";
            // 
            // weightsChart
            // 
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.Title = "Synapses";
            chartArea3.AxisY.Title = "Weights";
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea3);
            this.weightsChart.Location = new System.Drawing.Point(715, 151);
            this.weightsChart.Name = "weightsChart";
            this.weightsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.Black;
            series3.MarkerBorderColor = System.Drawing.Color.White;
            series3.MarkerSize = 2;
            series3.Name = "Series1";
            series3.ShadowColor = System.Drawing.Color.White;
            this.weightsChart.Series.Add(series3);
            this.weightsChart.Size = new System.Drawing.Size(702, 831);
            this.weightsChart.TabIndex = 6;
            this.weightsChart.Text = "chart3";
            // 
            // signalsChart
            // 
            chartArea4.AxisX.Title = "Neuron";
            chartArea4.AxisY.Maximum = 2D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "Neuron signal amplitude";
            chartArea4.Name = "ChartArea1";
            this.signalsChart.ChartAreas.Add(chartArea4);
            this.signalsChart.Location = new System.Drawing.Point(1423, 150);
            this.signalsChart.Name = "signalsChart";
            this.signalsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series4.Name = "Series1";
            this.signalsChart.Series.Add(series4);
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
            this.tg3.Location = new System.Drawing.Point(169, 167);
            this.tg3.Name = "tg3";
            this.tg3.Size = new System.Drawing.Size(100, 22);
            this.tg3.TabIndex = 11;
            this.tg3.Text = "0,01";
            this.tg3.Visible = false;
            // 
            // signalParamTextBox
            // 
            this.signalParamTextBox.Location = new System.Drawing.Point(259, 80);
            this.signalParamTextBox.Name = "signalParamTextBox";
            this.signalParamTextBox.Size = new System.Drawing.Size(56, 22);
            this.signalParamTextBox.TabIndex = 19;
            this.signalParamTextBox.Text = "10";
            // 
            // chart1
            // 
            chartArea5.AxisY.Maximum = 2D;
            chartArea5.AxisY.Minimum = -2D;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(320, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1563, 133);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // tg6
            // 
            this.tg6.Location = new System.Drawing.Point(169, 251);
            this.tg6.Name = "tg6";
            this.tg6.Size = new System.Drawing.Size(100, 22);
            this.tg6.TabIndex = 23;
            this.tg6.Text = "0,01";
            this.tg6.Visible = false;
            // 
            // tg5
            // 
            this.tg5.Location = new System.Drawing.Point(169, 223);
            this.tg5.Name = "tg5";
            this.tg5.Size = new System.Drawing.Size(100, 22);
            this.tg5.TabIndex = 22;
            this.tg5.Tag = "";
            this.tg5.Text = "0,01";
            this.tg5.Visible = false;
            // 
            // tg4
            // 
            this.tg4.Location = new System.Drawing.Point(169, 195);
            this.tg4.Name = "tg4";
            this.tg4.Size = new System.Drawing.Size(100, 22);
            this.tg4.TabIndex = 21;
            this.tg4.Text = "0,01";
            this.tg4.Visible = false;
            // 
            // tg8
            // 
            this.tg8.Location = new System.Drawing.Point(169, 307);
            this.tg8.Name = "tg8";
            this.tg8.Size = new System.Drawing.Size(100, 22);
            this.tg8.TabIndex = 25;
            this.tg8.Tag = "";
            this.tg8.Text = "0,01";
            this.tg8.Visible = false;
            // 
            // tg7
            // 
            this.tg7.Location = new System.Drawing.Point(169, 279);
            this.tg7.Name = "tg7";
            this.tg7.Size = new System.Drawing.Size(100, 22);
            this.tg7.TabIndex = 24;
            this.tg7.Text = "0,01";
            this.tg7.Visible = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 994);
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
            this.Controls.Add(this.log2);
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
    }
}

