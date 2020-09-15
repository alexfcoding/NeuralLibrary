namespace MyNeuralNetwork
{
    partial class Monitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monitorEnableCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // weightsChart
            // 
            this.weightsChart.BackColor = System.Drawing.Color.Black;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.Title = "Weights";
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.Maximum = 2D;
            chartArea3.AxisY.Minimum = -2D;
            chartArea3.AxisY.Title = "Values";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.BackSecondaryColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea3);
            this.weightsChart.Location = new System.Drawing.Point(6, 33);
            this.weightsChart.Name = "weightsChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.MarkerColor = System.Drawing.Color.White;
            series3.MarkerSize = 2;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series3.Name = "Series1";
            this.weightsChart.Series.Add(series3);
            this.weightsChart.Size = new System.Drawing.Size(509, 763);
            this.weightsChart.TabIndex = 51;
            this.weightsChart.Text = "chart2";
            // 
            // monitorEnableCheckBox
            // 
            this.monitorEnableCheckBox.AutoSize = true;
            this.monitorEnableCheckBox.Checked = true;
            this.monitorEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.monitorEnableCheckBox.Location = new System.Drawing.Point(6, 10);
            this.monitorEnableCheckBox.Name = "monitorEnableCheckBox";
            this.monitorEnableCheckBox.Size = new System.Drawing.Size(111, 17);
            this.monitorEnableCheckBox.TabIndex = 52;
            this.monitorEnableCheckBox.Text = "Enable Monitoring";
            this.monitorEnableCheckBox.UseVisualStyleBackColor = true;
            this.monitorEnableCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 808);
            this.Controls.Add(this.monitorEnableCheckBox);
            this.Controls.Add(this.weightsChart);
            this.Name = "Monitor";
            this.Text = "Network Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart weightsChart;
        private System.Windows.Forms.CheckBox monitorEnableCheckBox;
    }
}