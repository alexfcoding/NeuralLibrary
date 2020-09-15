using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNeuralNetwork
{    
    public partial class ModelConstructor : Form
    {
        public event EventHandler SendNetworkSetup;

        public ModelConstructor()
        {
            InitializeComponent();
        }
        
        public int inputNeuronsCount { get; set; }
        public int outputNeuronsCount { get; set; }
        public int[] hiddenNeuronsCount { get; set; }
        public double learningRate { get; set; }               

        public void createNetworkButton_Click(object sender, EventArgs e)
        {
            learningRate = Convert.ToDouble(rateTextBox.Text);
            inputNeuronsCount = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            hiddenNeuronsCount = new int[dataGridView1.Rows.Count - 3];
            outputNeuronsCount = Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count-2].Cells[0].Value);
            
            for (int i = 0; i < dataGridView1.Rows.Count - 3; i++)
            {
                hiddenNeuronsCount[i] = Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value);
            }
            
            //trainParam = rndSet.Next(0, Convert.ToInt32(network.Targets.Length));
            //trainSymbol.Text = "Draw " + trainParam.ToString();Network  

            EventHandler handler = this.SendNetworkSetup;

            if (handler != null)
                handler(this, EventArgs.Empty);
            
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {           
            var grid = sender as DataGridView;
            var rowIdx = " " + (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            
        }
    }
}
