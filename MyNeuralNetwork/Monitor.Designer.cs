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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monitorEnableCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // weightsChart
            // 
            this.weightsChart.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Weights";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.Maximum = 1.5D;
            chartArea1.AxisY.Minimum = -1.5D;
            chartArea1.AxisY.Title = "Values";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea1);
            this.weightsChart.Location = new System.Drawing.Point(2, 1);
            this.weightsChart.Name = "weightsChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.MarkerColor = System.Drawing.Color.White;
            series1.MarkerSize = 2;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.weightsChart.Series.Add(series1);
            this.weightsChart.Size = new System.Drawing.Size(434, 723);
            this.weightsChart.TabIndex = 51;
            this.weightsChart.Text = "chart2";
            // 
            // monitorEnableCheckBox
            // 
            this.monitorEnableCheckBox.AutoSize = true;
            this.monitorEnableCheckBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monitorEnableCheckBox.Checked = true;
            this.monitorEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.monitorEnableCheckBox.ForeColor = System.Drawing.SystemColors.Window;
            this.monitorEnableCheckBox.Location = new System.Drawing.Point(12, 701);
            this.monitorEnableCheckBox.Name = "monitorEnableCheckBox";
            this.monitorEnableCheckBox.Size = new System.Drawing.Size(184, 17);
            this.monitorEnableCheckBox.TabIndex = 52;
            this.monitorEnableCheckBox.Text = "Enabled (disable for performance)";
            this.monitorEnableCheckBox.UseVisualStyleBackColor = false;
            this.monitorEnableCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 726);
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