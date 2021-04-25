using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    public class NetworkLayers
    {
        #region Variables

        private SQLiteConnection sqliteDb;
        private List<NeuronLayer> items;
        private int modelId;
        #endregion

        #region Contructors

        public NetworkLayers(SQLiteConnection _sqliteDb, int _modelId)
        {
            this.sqliteDb = _sqliteDb;
            this.ModelId = _modelId;
        }

        #endregion

        #region Properties

        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }
        public int ModelId { get => modelId; set => modelId = value; }
        internal List<NeuronLayer> Items { get => items; set => items = value; }

        #endregion

        #region Methods

        public void ReadData()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = SqliteDb.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM LAYERSNEURONS WHERE MODEL_ID=" + ModelId;
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            Items = new List<NeuronLayer>();

            while (sqlite_datareader.Read())
            {
                Items.Add(new NeuronLayer(sqlite_datareader.GetInt32(0),
                                          sqlite_datareader.GetInt32(1),
                                          sqlite_datareader.GetInt32(2),
                                          sqlite_datareader.GetInt32(3)));
            }
        }

        #endregion
    }

    class NeuronLayer
    {
        private int id;
        private int model_id;
        private int layer;
        private int neuron;

        public NeuronLayer(int _id, int _model_id, int _layer, int _neuron)
        {
            this.id = _id;
            this.model_id = _model_id;
            this.layer = _layer;
            this.neuron = _neuron;
        }

        public int Id { get => id; set => id = value; }
        public int Model_id { get => model_id; set => model_id = value; }
        public int Layer { get => layer; set => layer = value; }
        public int Neuron { get => neuron; set => neuron = value; }
    }
}
