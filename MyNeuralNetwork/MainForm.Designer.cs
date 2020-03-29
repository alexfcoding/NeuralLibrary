﻿namespace MyNeuralNetwork
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.userPaintBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.iterationsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPaintBox)).BeginInit();
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
            this.log.Location = new System.Drawing.Point(12, 165);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(302, 484);
            this.log.TabIndex = 1;
            // 
            // log2
            // 
            this.log2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log2.FormattingEnabled = true;
            this.log2.ItemHeight = 15;
            this.log2.Location = new System.Drawing.Point(12, 663);
            this.log2.Name = "log2";
            this.log2.Size = new System.Drawing.Size(302, 319);
            this.log2.TabIndex = 2;
            // 
            // trainNetorkButton
            // 
            this.trainNetorkButton.Enabled = false;
            this.trainNetorkButton.Location = new System.Drawing.Point(12, 97);
            this.trainNetorkButton.Name = "trainNetorkButton";
            this.trainNetorkButton.Size = new System.Drawing.Size(146, 23);
            this.trainNetorkButton.TabIndex = 3;
            this.trainNetorkButton.Text = "Train";
            this.trainNetorkButton.UseVisualStyleBackColor = true;
            this.trainNetorkButton.Click += new System.EventHandler(this.TrainNetworkButton_Click);
            // 
            // outputsChart
            // 
            chartArea6.AxisX.Title = "Network outputs";
            chartArea6.AxisY.Interval = 0.05D;
            chartArea6.AxisY.Maximum = 1D;
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.AxisY.Title = "Signal amplitude";
            chartArea6.Name = "ChartArea1";
            this.outputsChart.ChartAreas.Add(chartArea6);
            this.outputsChart.Location = new System.Drawing.Point(320, 221);
            this.outputsChart.Name = "outputsChart";
            this.outputsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series6.ChartArea = "ChartArea1";
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series6.Name = "Series1";
            this.outputsChart.Series.Add(series6);
            this.outputsChart.Size = new System.Drawing.Size(192, 761);
            this.outputsChart.TabIndex = 4;
            this.outputsChart.Text = "chart1";
            // 
            // errorsChart
            // 
            chartArea7.AxisX.Title = "Output targets";
            chartArea7.AxisY.Interval = 0.1D;
            chartArea7.AxisY.Maximum = 1D;
            chartArea7.AxisY.Minimum = -1D;
            chartArea7.AxisY.Title = "Current error";
            chartArea7.Name = "ChartArea1";
            this.errorsChart.ChartAreas.Add(chartArea7);
            this.errorsChart.Location = new System.Drawing.Point(518, 221);
            this.errorsChart.Name = "errorsChart";
            this.errorsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.MarkerSize = 30;
            series7.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series7.Name = "Series1";
            series7.YValuesPerPoint = 4;
            this.errorsChart.Series.Add(series7);
            this.errorsChart.Size = new System.Drawing.Size(191, 761);
            this.errorsChart.TabIndex = 5;
            this.errorsChart.Text = "chart2";
            // 
            // weightsChart
            // 
            chartArea8.AxisX.Interval = 1D;
            chartArea8.AxisX.Title = "Synapses";
            chartArea8.AxisY.Title = "Weights";
            chartArea8.BackColor = System.Drawing.Color.Black;
            chartArea8.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea8);
            this.weightsChart.Location = new System.Drawing.Point(715, 151);
            this.weightsChart.Name = "weightsChart";
            this.weightsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Color = System.Drawing.Color.Black;
            series8.MarkerBorderColor = System.Drawing.Color.White;
            series8.MarkerSize = 1;
            series8.Name = "Series1";
            series8.ShadowColor = System.Drawing.Color.White;
            this.weightsChart.Series.Add(series8);
            this.weightsChart.Size = new System.Drawing.Size(702, 831);
            this.weightsChart.TabIndex = 6;
            this.weightsChart.Text = "chart3";
            // 
            // signalsChart
            // 
            chartArea9.AxisX.Title = "Neuron";
            chartArea9.AxisY.Maximum = 2D;
            chartArea9.AxisY.Minimum = 0D;
            chartArea9.AxisY.Title = "Neuron signal amplitude";
            chartArea9.Name = "ChartArea1";
            this.signalsChart.ChartAreas.Add(chartArea9);
            this.signalsChart.Location = new System.Drawing.Point(1423, 150);
            this.signalsChart.Name = "signalsChart";
            this.signalsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series9.Name = "Series1";
            this.signalsChart.Series.Add(series9);
            this.signalsChart.Size = new System.Drawing.Size(460, 832);
            this.signalsChart.TabIndex = 7;
            this.signalsChart.Text = "chart4";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(12, 126);
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
            this.tg3.Location = new System.Drawing.Point(138, 417);
            this.tg3.Name = "tg3";
            this.tg3.Size = new System.Drawing.Size(100, 22);
            this.tg3.TabIndex = 11;
            this.tg3.Text = "0,01";
            this.tg3.Visible = false;
            // 
            // signalParamTextBox
            // 
            this.signalParamTextBox.Location = new System.Drawing.Point(258, 69);
            this.signalParamTextBox.Name = "signalParamTextBox";
            this.signalParamTextBox.Size = new System.Drawing.Size(56, 22);
            this.signalParamTextBox.TabIndex = 19;
            this.signalParamTextBox.Text = "0";
            // 
            // chart1
            // 
            chartArea10.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea10);
            this.chart1.Location = new System.Drawing.Point(320, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Name = "Series1";
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(1563, 133);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // tg6
            // 
            this.tg6.Location = new System.Drawing.Point(138, 501);
            this.tg6.Name = "tg6";
            this.tg6.Size = new System.Drawing.Size(100, 22);
            this.tg6.TabIndex = 23;
            this.tg6.Text = "0,01";
            this.tg6.Visible = false;
            // 
            // tg5
            // 
            this.tg5.Location = new System.Drawing.Point(138, 473);
            this.tg5.Name = "tg5";
            this.tg5.Size = new System.Drawing.Size(100, 22);
            this.tg5.TabIndex = 22;
            this.tg5.Tag = "";
            this.tg5.Text = "0,01";
            this.tg5.Visible = false;
            // 
            // tg4
            // 
            this.tg4.Location = new System.Drawing.Point(138, 445);
            this.tg4.Name = "tg4";
            this.tg4.Size = new System.Drawing.Size(100, 22);
            this.tg4.TabIndex = 21;
            this.tg4.Text = "0,01";
            this.tg4.Visible = false;
            // 
            // tg8
            // 
            this.tg8.Location = new System.Drawing.Point(138, 557);
            this.tg8.Name = "tg8";
            this.tg8.Size = new System.Drawing.Size(100, 22);
            this.tg8.TabIndex = 25;
            this.tg8.Tag = "";
            this.tg8.Text = "0,01";
            this.tg8.Visible = false;
            // 
            // tg7
            // 
            this.tg7.Location = new System.Drawing.Point(138, 529);
            this.tg7.Name = "tg7";
            this.tg7.Size = new System.Drawing.Size(100, 22);
            this.tg7.TabIndex = 24;
            this.tg7.Text = "0,01";
            this.tg7.Visible = false;
            // 
            // recognitionTestButton
            // 
            this.recognitionTestButton.Location = new System.Drawing.Point(168, 126);
            this.recognitionTestButton.Name = "recognitionTestButton";
            this.recognitionTestButton.Size = new System.Drawing.Size(146, 23);
            this.recognitionTestButton.TabIndex = 26;
            this.recognitionTestButton.Text = "Recognition test";
            this.recognitionTestButton.UseVisualStyleBackColor = true;
            this.recognitionTestButton.Click += new System.EventHandler(this.recognitionTestButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(320, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
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
            this.tg9.Location = new System.Drawing.Point(138, 585);
            this.tg9.Name = "tg9";
            this.tg9.Size = new System.Drawing.Size(100, 22);
            this.tg9.TabIndex = 29;
            this.tg9.Tag = "";
            this.tg9.Text = "0,01";
            this.tg9.Visible = false;
            // 
            // tg10
            // 
            this.tg10.Location = new System.Drawing.Point(138, 613);
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
            this.userPaintBox.Location = new System.Drawing.Point(401, 151);
            this.userPaintBox.Name = "userPaintBox";
            this.userPaintBox.Size = new System.Drawing.Size(28, 28);
            this.userPaintBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPaintBox.TabIndex = 31;
            this.userPaintBox.TabStop = false;
            this.userPaintBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.userPaintBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.userPaintBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Recognize";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(451, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 31);
            this.label1.TabIndex = 33;
            this.label1.Text = "-";
            // 
            // iterationsTextBox
            // 
            this.iterationsTextBox.Location = new System.Drawing.Point(12, 69);
            this.iterationsTextBox.Name = "iterationsTextBox";
            this.iterationsTextBox.Size = new System.Drawing.Size(56, 22);
            this.iterationsTextBox.TabIndex = 34;
            this.iterationsTextBox.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 994);
            this.Controls.Add(this.iterationsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userPaintBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPaintBox)).EndInit();
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
        private System.Windows.Forms.PictureBox userPaintBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox iterationsTextBox;
    }
}

