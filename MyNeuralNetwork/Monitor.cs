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
    public partial class Monitor : Form
    {        
        public bool monitorEnabled { get; set; }

        public Monitor()
        {
            InitializeComponent();
            monitorEnabled = true;
        }

        public void drawWeightsInMonitor(Network network)
        {
            int weightId = 0;            

            if (monitorEnabled == true)
            {
                for (int i = 0; i < network.Layers.Count; i++)
                {
                    for (int j = 0; j < network.Layers[i].Neurons.Count; j += 1)
                    {
                        for (int k = 0; k < network.Layers[i].Neurons[j].Weights.Length; k++)
                        {
                            if (k % 10 == 0)
                            {
                                weightsChart.Series[0].Points.AddXY(weightId, network.Layers[i].Neurons[j].Weights[k]);                                
                            }
                            weightId++;
                        }                   
                    }
                }
            }
        }

        public void clearMonitor()
        {
            try
            {
                if (monitorEnabled == true)
                {
                    weightsChart.Series[0].Points.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please restart NeuralNetwork in order to load Monitor GUI.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (monitorEnableCheckBox.Checked)
            {
                monitorEnabled = true;
            }
            else
            {
                monitorEnabled = false;
            }
        }
    }
}
