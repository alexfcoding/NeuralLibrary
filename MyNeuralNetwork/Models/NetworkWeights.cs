using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork.Models
{
    public class NetworkWeights
    {
        #region Variables

        private SQLiteConnection sqliteDb;
        private List<Weight> items;
        private int modelId;
        #endregion

        #region Constructors

        public NetworkWeights(SQLiteConnection _sqliteDb, int _modelId)
        {
            this.sqliteDb = _sqliteDb;
            this.ModelId = _modelId;
        }

        #endregion

        #region Properties

        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }
        public int ModelId { get => modelId; set => modelId = value; }
        internal List<Weight> Items { get => items; set => items = value; }

        #endregion

        #region Methods

        public void ReadData()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = SqliteDb.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM WEIGHTS WHERE MODEL_ID=" + ModelId;
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            Items = new List<Weight>();

            while (sqlite_datareader.Read())
            {
                Items.Add(new Weight(sqlite_datareader.GetInt32(2),
                                     sqlite_datareader.GetInt32(3),
                                     Convert.ToDouble(sqlite_datareader.GetString(4).Replace(',', '.'))));
            }
            SqliteDb.Close();
        }

        #endregion
    }

    class Weight
    {
        private double x;
        private double y;
        private double z;

        public Weight(double _x, double _y, double _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }
    }
}
