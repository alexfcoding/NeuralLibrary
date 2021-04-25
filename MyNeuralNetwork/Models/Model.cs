using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    public class Model
    {
        #region Variables
        SQLiteConnection sqliteDb;
        private int modelId;
        private string modelName;
        private NetworkLayers neuronLayers;
        private NetworkWeights weights;
        private List<ModelItems> items;
        #endregion

        #region Contructors
        public Model(SQLiteConnection _sqliteDb)
        {
            this.SqliteDb = _sqliteDb;
        }
        public Model(SQLiteConnection _sqliteDb, int _modelId)
        {
            this.SqliteDb = _sqliteDb;
            this.ModelId = _modelId;
        }
        #endregion

        #region Properties
        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }
        public int ModelId { get => modelId; set => modelId = value; }
        public string ModelName { get => modelName; set => modelName = value; }
        internal NetworkLayers NeuronLayers { get => neuronLayers; set => neuronLayers = value; }
        internal NetworkWeights Weights { get => weights; set => weights = value; }
        internal List<ModelItems> Items { get => items; set => items = value; }

        #endregion

        #region Methods

        public void ReadModelPreview()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = SqliteDb.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM MODEL";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            Items = new List<ModelItems>();

            while (sqlite_datareader.Read())
            {
                Items.Add(new ModelItems(sqlite_datareader.GetInt32(0),
                                         sqlite_datareader.GetString(1)));
            }

            SqliteDb.Close();
        }

        public void ReadModel()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = SqliteDb.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM MODEL";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                int identificator = sqlite_datareader.GetInt32(0);
                if (identificator.Equals(ModelId))
                {
                    ModelId = sqlite_datareader.GetInt32(0);
                    ModelName = sqlite_datareader.GetString(1);
                }
            }

            NetworkLayers networkLayers = new NetworkLayers(SqliteDb, ModelId);
            networkLayers.ReadData();

            NetworkWeights networkWeights = new NetworkWeights(SqliteDb, ModelId);
            networkWeights.ReadData();

            SqliteDb.Close();
        }

        #endregion
    }

    class ModelItems
    {
        private int modelId;
        private string modelName;

        public ModelItems(int _modelId, string _modelName)
        {
            this.modelId = _modelId;
            this.modelName = _modelName;
        }

        public int ModelId { get => modelId; set => modelId = value; }
        public string ModelName { get => modelName; set => modelName = value; }
    }
}
