using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    /// <summary>
    /// Network Weight
    /// </summary>
    public class NetworkWeight
    {
        private int id;
        private int modelId;
        private double error;
        private double outputSignal;
        private double bias;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkWeight"/> class.
        /// </summary>
        /// <param name="_id">The identifier.</param>
        /// <param name="_modelId">The model identifier.</param>
        /// <param name="_error">The error.</param>
        /// <param name="outputSignal">The output signal.</param>
        /// <param name="_bias">The bias.</param>
        public NetworkWeight(int _id,int _modelId, double _error, double outputSignal, double _bias)
        {
            this.id = _id;
            this.modelId = _modelId;
            this.error = _error;
            this.outputSignal = outputSignal;
            this.bias = _bias;
        }
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public double Error { get => error; set => error = value; }
        /// <summary>
        /// Gets or sets the output signal.
        /// </summary>
        /// <value>
        /// The output signal.
        /// </value>
        public double OutputSignal { get => outputSignal; set => outputSignal = value; }
        /// <summary>
        /// Gets or sets the bias.
        /// </summary>
        /// <value>
        /// The bias.
        /// </value>
        public double Bias { get => bias; set => bias = value; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public int ModelId { get => modelId; set => modelId = value; }
    }
}
