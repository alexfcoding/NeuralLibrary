using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    /// <summary>
    /// Model
    /// </summary>
    public class Model
    {
        #region Variables

        SQLiteConnection sqliteDb;
        private int modelId;
        private string modelName;
        private List<NetworkLayer> neuronLayers;
        private List<NetworkWeight> weights;
        private List<ModelItem> items;
        private string sqliteDbPath;

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="_sqliteDb">The sqlite database.</param>
        /// <param name="_sqliteDbPath">The sqlite database path.</param>
        public Model(SQLiteConnection _sqliteDb, string _sqliteDbPath)
        {
            this.sqliteDb = _sqliteDb;
            this.sqliteDbPath = _sqliteDbPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="_sqliteDb">The sqlite database.</param>
        /// <param name="_modelName">Name of the model.</param>
        /// <param name="_sqliteDbPath">The sqlite database path.</param>
        public Model(SQLiteConnection _sqliteDb, string _modelName, string _sqliteDbPath)
        {
            this.sqliteDb = _sqliteDb;
            this.modelName = _modelName;
            this.sqliteDbPath = _sqliteDbPath;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the sqlite database.
        /// </summary>
        /// <value>
        /// The sqlite database.
        /// </value>
        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }
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
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        internal List<ModelItem> Items { get => items; set => items = value; }
        /// <summary>
        /// Gets or sets the sqlite database path.
        /// </summary>
        /// <value>
        /// The sqlite database path.
        /// </value>
        public string SqliteDbPath { get => sqliteDbPath; set => sqliteDbPath = value; }
        /// <summary>
        /// Gets or sets the neuron layers.
        /// </summary>
        /// <value>
        /// The neuron layers.
        /// </value>
        public List<NetworkLayer> NeuronLayers { get => neuronLayers; set => neuronLayers = value; }
        /// <summary>
        /// Gets or sets the weights.
        /// </summary>
        /// <value>
        /// The weights.
        /// </value>
        public List<NetworkWeight> Weights { get => weights; set => weights = value; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            try
            {
                SqliteDb = new SQLiteConnection($"Data Source={SqliteDbPath};Version=3;New=True;Compress=True;");
                
                if (SqliteDb.State == System.Data.ConnectionState.Closed)
                    SqliteDb.Open();

                return SqliteDb;
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// Reads the model preview.
        /// </summary>
        public void ReadModelPreview()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            if (SqliteDb.State == System.Data.ConnectionState.Closed)
                SqliteDb.Open();

            try
            {
                sqlite_cmd = SqliteDb.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM MODEL";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                Items = new List<ModelItem>();

                while (sqlite_datareader.Read())
                {
                    Items.Add(new ModelItem(sqlite_datareader.GetInt32(0),
                                             sqlite_datareader.GetString(1)));
                }

                SqliteDb.Close();
            }
            catch
            {
                Items = null;
            }
        }

        /// <summary>
        /// Reads the model.
        /// </summary>
        /// <param name="query">The query.</param>
        public void ReadModel(string query)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            if (SqliteDb.State == System.Data.ConnectionState.Closed)
                SqliteDb.Open();

            try
            {
                sqlite_cmd = SqliteDb.CreateCommand();
                sqlite_cmd.CommandText = query;

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    ModelId = sqlite_datareader.GetInt32(0);
                    ModelName = sqlite_datareader.GetString(1);
                }
            }
            catch
            {                
            }
        }

        /// <summary>
        /// Gets the neuron layer data.
        /// </summary>
        /// <param name="query">The query.</param>
        public void GetNeuronLayerData(string query)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            if (SqliteDb.State == System.Data.ConnectionState.Closed)
                SqliteDb.Open();

            try
            {
                NeuronLayers = new List<NetworkLayer>();

                sqlite_cmd = SqliteDb.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                    NetworkLayer neuronLayer = new NetworkLayer(sqlite_datareader.GetInt32(0),
                                                                  sqlite_datareader.GetInt32(1),
                                                                  sqlite_datareader.GetInt32(2),
                                                                  sqlite_datareader.GetInt32(3));
                    NeuronLayers.Add(neuronLayer);
                }
            }
            catch
            {
                NeuronLayers = null;
            }
        }

        /// <summary>
        /// Gets the weight data.
        /// </summary>
        /// <param name="query">The query.</param>
        public void GetWeightData(string query)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            if (SqliteDb.State == System.Data.ConnectionState.Closed)
                SqliteDb.Open();

            try
            {
                Weights = new List<NetworkWeight>();

                sqlite_cmd = SqliteDb.CreateCommand();
                sqlite_cmd.CommandText = query;
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                    NetworkWeight networkWeight = new NetworkWeight(sqlite_datareader.GetInt32(0),
                                                                    sqlite_datareader.GetInt32(1),
                                                                    sqlite_datareader.GetInt32(2),
                                                                    sqlite_datareader.GetInt32(3),
                                                                    Convert.ToDouble(sqlite_datareader.GetString(4).Replace(',', '.')));

                    Weights.Add(networkWeight);
                }
            }
            catch
            {
                Weights = null;
            }
        }

        #endregion
    }
}
