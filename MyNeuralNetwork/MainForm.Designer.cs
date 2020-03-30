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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.testNetworkButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListBox();
            this.log2 = new System.Windows.Forms.ListBox();
            this.outputsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.errorsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.weightsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.signalsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tg3 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tg6 = new System.Windows.Forms.TextBox();
            this.tg5 = new System.Windows.Forms.TextBox();
            this.tg4 = new System.Windows.Forms.TextBox();
            this.tg8 = new System.Windows.Forms.TextBox();
            this.tg7 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iterationLabel = new System.Windows.Forms.Label();
            this.tg9 = new System.Windows.Forms.TextBox();
            this.tg10 = new System.Windows.Forms.TextBox();
            this.userPaintBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.iterationsTextBox = new System.Windows.Forms.TextBox();
            this.signalParamTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trainNetorkButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.recognitionTestButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorsChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.outputsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signalsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPaintBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart2)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            chartArea1.AxisX.Title = "Output neurons";
            chartArea1.AxisY.Interval = 0.05D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Signal amplitude";
            chartArea1.Name = "ChartArea1";
            this.outputsChart.ChartAreas.Add(chartArea1);
            this.outputsChart.Location = new System.Drawing.Point(320, 320);
            this.outputsChart.Name = "outputsChart";
            series1.ChartArea = "ChartArea1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series1";
            this.outputsChart.Series.Add(series1);
            this.outputsChart.Size = new System.Drawing.Size(255, 662);
            this.outputsChart.TabIndex = 4;
            this.outputsChart.Text = "chart1";
            // 
            // errorsChart
            // 
            chartArea2.AxisX.Title = "Output targets";
            chartArea2.AxisY.Interval = 0.1D;
            chartArea2.AxisY.Maximum = 1D;
            chartArea2.AxisY.Minimum = -1D;
            chartArea2.AxisY.Title = "Error";
            chartArea2.Name = "ChartArea1";
            this.errorsChart.ChartAreas.Add(chartArea2);
            this.errorsChart.Location = new System.Drawing.Point(581, 320);
            this.errorsChart.Name = "errorsChart";
            this.errorsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.MarkerSize = 15;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.errorsChart.Series.Add(series2);
            this.errorsChart.Size = new System.Drawing.Size(255, 662);
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
            this.weightsChart.Location = new System.Drawing.Point(1103, 616);
            this.weightsChart.Name = "weightsChart";
            this.weightsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.Black;
            series3.MarkerBorderColor = System.Drawing.Color.White;
            series3.MarkerSize = 1;
            series3.Name = "Series1";
            series3.ShadowColor = System.Drawing.Color.White;
            this.weightsChart.Series.Add(series3);
            this.weightsChart.Size = new System.Drawing.Size(809, 366);
            this.weightsChart.TabIndex = 6;
            this.weightsChart.Text = "chart3";
            // 
            // signalsChart
            // 
            chartArea4.AxisX.Title = "Neurons";
            chartArea4.AxisY.Maximum = 2D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.Title = "Signal amplitude";
            chartArea4.Name = "ChartArea1";
            this.signalsChart.ChartAreas.Add(chartArea4);
            this.signalsChart.Location = new System.Drawing.Point(842, 320);
            this.signalsChart.Name = "signalsChart";
            this.signalsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series4.Name = "Series1";
            this.signalsChart.Series.Add(series4);
            this.signalsChart.Size = new System.Drawing.Size(255, 662);
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
            chartArea5.AxisX.Title = "Input neurons";
            chartArea5.AxisY.Title = "Signal amplitude";
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(320, 77);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1563, 237);
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(354, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // iterationLabel
            // 
            this.iterationLabel.AutoSize = true;
            this.iterationLabel.BackColor = System.Drawing.Color.White;
            this.iterationLabel.Location = new System.Drawing.Point(351, 285);
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
            this.userPaintBox.Location = new System.Drawing.Point(401, 35);
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.signalParamTextBox);
            this.groupBox1.Controls.Add(this.iterationsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 223);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layers configuration";
            // 
            // iterationsTextBox
            // 
            this.iterationsTextBox.Location = new System.Drawing.Point(92, 147);
            this.iterationsTextBox.Name = "iterationsTextBox";
            this.iterationsTextBox.Size = new System.Drawing.Size(40, 22);
            this.iterationsTextBox.TabIndex = 35;
            this.iterationsTextBox.Text = "1000";
            // 
            // signalParamTextBox
            // 
            this.signalParamTextBox.Location = new System.Drawing.Point(92, 183);
            this.signalParamTextBox.Name = "signalParamTextBox";
            this.signalParamTextBox.Size = new System.Drawing.Size(40, 22);
            this.signalParamTextBox.TabIndex = 36;
            this.signalParamTextBox.Tag = "";
            this.signalParamTextBox.Text = "9";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 22);
            this.textBox1.TabIndex = 37;
            this.textBox1.Text = "784";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 22);
            this.textBox2.TabIndex = 38;
            this.textBox2.Text = "200";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(92, 96);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 22);
            this.textBox3.TabIndex = 39;
            this.textBox3.Text = "10";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 41;
            this.label3.Text = "Hidden:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Iterations:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 183);
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
            this.recognitionTestButton.Text = "Quality test";
            this.recognitionTestButton.UseVisualStyleBackColor = true;
            this.recognitionTestButton.Click += new System.EventHandler(this.recognitionTestButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(481, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1402, 14);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 36;
            // 
            // errorsChart2
            // 
            chartArea6.AxisX.Title = "Dataset sample";
            chartArea6.AxisY.Title = "Error";
            chartArea6.Name = "ChartArea1";
            this.errorsChart2.ChartAreas.Add(chartArea6);
            this.errorsChart2.Location = new System.Drawing.Point(1103, 320);
            this.errorsChart2.Name = "errorsChart2";
            this.errorsChart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.errorsChart2.Size = new System.Drawing.Size(780, 290);
            this.errorsChart2.TabIndex = 37;
            this.errorsChart2.Text = "chart2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(182, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 132);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 994);
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
            this.Controls.Add(this.pictureBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorsChart2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testNetworkButton;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ListBox log2;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart weightsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart signalsChart;
        private System.Windows.Forms.TextBox tg3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox tg6;
        private System.Windows.Forms.TextBox tg5;
        private System.Windows.Forms.TextBox tg4;
        private System.Windows.Forms.TextBox tg8;
        private System.Windows.Forms.TextBox tg7;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox signalParamTextBox;
        private System.Windows.Forms.TextBox iterationsTextBox;
        private System.Windows.Forms.Button trainNetorkButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button recognitionTestButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart errorsChart2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

