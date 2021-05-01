using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    /// <summary>
    /// Model item
    /// </summary>
    public class ModelItem
    {
        #region Variables

        private int modelId;
        private string modelName;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelItem"/> class.
        /// </summary>
        /// <param name="_modelId">The model identifier.</param>
        /// <param name="_modelName">Name of the model.</param>
        public ModelItem(int _modelId, string _modelName)
        {
            this.modelId = _modelId;
            this.modelName = _modelName;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        /// <value>
        /// The model identifier.
        /// </value>
        public int ModelId { get => modelId; set => modelId = value; }
        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        /// <value>
        /// The name of the model.
        /// </value>
        public string ModelName { get => modelName; set => modelName = value; }
        #endregion
    }
}
