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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.log2 = new System.Windows.Forms.ListBox();
            this.trainNetworkButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // testNetworkButton
            // 
            this.testNetworkButton.Location = new System.Drawing.Point(12, 12);
            this.testNetworkButton.Name = "testNetworkButton";
            this.testNetworkButton.Size = new System.Drawing.Size(396, 23);
            this.testNetworkButton.TabIndex = 0;
            this.testNetworkButton.Text = "CreateNetwork";
            this.testNetworkButton.UseVisualStyleBackColor = true;
            this.testNetworkButton.Click += new System.EventHandler(this.testNetworkButton_Click);
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.ItemHeight = 16;
            this.log.Location = new System.Drawing.Point(12, 51);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(396, 932);
            this.log.TabIndex = 1;
            // 
            // log2
            // 
            this.log2.FormattingEnabled = true;
            this.log2.ItemHeight = 16;
            this.log2.Location = new System.Drawing.Point(414, 51);
            this.log2.Name = "log2";
            this.log2.Size = new System.Drawing.Size(396, 932);
            this.log2.TabIndex = 2;
            // 
            // trainNetworkButton
            // 
            this.trainNetworkButton.Enabled = false;
            this.trainNetworkButton.Location = new System.Drawing.Point(414, 12);
            this.trainNetworkButton.Name = "trainNetworkButton";
            this.trainNetworkButton.Size = new System.Drawing.Size(396, 23);
            this.trainNetworkButton.TabIndex = 3;
            this.trainNetworkButton.Text = "Train";
            this.trainNetworkButton.UseVisualStyleBackColor = true;
            this.trainNetworkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Targets";
            chartArea1.AxisY.Interval = 0.05D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Output";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(816, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(391, 971);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.AxisX.Title = "Targets";
            chartArea2.AxisY.Interval = 0.1D;
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = -1D;
            chartArea2.AxisY.Title = "Current error";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(1213, 12);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.MarkerSize = 30;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(391, 971);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1726, 994);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.trainNetworkButton);
            this.Controls.Add(this.log2);
            this.Controls.Add(this.log);
            this.Controls.Add(this.testNetworkButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ListBox log2;
        private System.Windows.Forms.Button trainNetworkButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

