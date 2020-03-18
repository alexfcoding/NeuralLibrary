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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void testNetworkButton_Click(object sender, EventArgs e)
        {
            Network MyNetwork = new Network();

            MyNetwork.FillInputLayer(3);
            MyNetwork.FillHiddenLayer(3);
            MyNetwork.FillOutputLayer(3);

            MyNetwork.MoveForward();
        }
    }
}
