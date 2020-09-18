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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.monitorEnableCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // weightsChart
            // 
            this.weightsChart.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.Title = "Weights";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.Maximum = 2D;
            chartArea2.AxisY.Minimum = -2D;
            chartArea2.AxisY.Title = "Values";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.weightsChart.ChartAreas.Add(chartArea2);
            this.weightsChart.Location = new System.Drawing.Point(2, 2);
            this.weightsChart.Name = "weightsChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.MarkerColor = System.Drawing.Color.White;
            series2.MarkerSize = 2;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series2.Name = "Series1";
            this.weightsChart.Series.Add(series2);
            this.weightsChart.Size = new System.Drawing.Size(519, 721);
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
            this.monitorEnableCheckBox.Location = new System.Drawing.Point(12, 697);
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
            this.ClientSize = new System.Drawing.Size(523, 726);
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