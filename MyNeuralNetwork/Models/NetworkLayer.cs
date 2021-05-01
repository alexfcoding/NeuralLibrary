namespace MyNeuralNetwork.Models
{
    /// <summary>
    /// Network Layer
    /// </summary>
    public class NetworkLayer
    {
        private int id;
        private int modelId;
        private int layer;
        private int neuron;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkLayer"/> class.
        /// </summary>
        /// <param name="_id">The identifier.</param>
        /// <param name="_modelId">The model identifier.</param>
        /// <param name="_layer">The layer.</param>
        /// <param name="_neuron">The neuron.</param>
        public NetworkLayer(int _id, int _modelId, int _layer, int _neuron)
        {
            this.id = _id;
            this.modelId = _modelId;
            this.layer = _layer;
            this.neuron = _neuron;
        }

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
        /// <summary>
        /// Gets or sets the layer.
        /// </summary>
        /// <value>
        /// The layer.
        /// </value>
        public int Layer { get => layer; set => layer = value; }
        /// <summary>
        /// Gets or sets the neuron.
        /// </summary>
        /// <value>
        /// The neuron.
        /// </value>
        public int Neuron { get => neuron; set => neuron = value; }
    }
}