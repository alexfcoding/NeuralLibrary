using MyNeuralNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MyNeuralNetwork
{
    public partial class DatabaseLoader : Form
    {
        #region Variables
        private SQLiteConnection sqliteDb;
        private string sqliteDbPath;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseLoader"/> class.
        /// </summary>
        /// <param name="_sqliteDbPath">The sqlite database path.</param>
        public DatabaseLoader(string _sqliteDbPath)
        {
            InitializeComponent();

            sqliteDbPath = _sqliteDbPath;

            if (!string.IsNullOrEmpty(sqliteDbPath))
            {
                try
                {
                    Model model = new Model(SqliteDb, SqliteDbPath);
                    SqliteDb = model.GetConnection();
                    if (model.SqliteDb.State == System.Data.ConnectionState.Open)
                        model.ReadModelPreview();

                    SortedDictionary<int, string> models = new SortedDictionary<int, string>();
                    foreach (ModelItem item in model.Items)
                    {
                        models.Add(item.ModelId, item.ModelName);
                    }

                    cmbDatabaseLoader.DataSource = new BindingSource(models, null);
                    cmbDatabaseLoader.DisplayMember = "Value";
                    cmbDatabaseLoader.ValueMember = "Key";
                }
                catch
                {
                    MessageBox.Show("Error loading database existing models.");
                }
            }
            else
            {
                MessageBox.Show("Please, first select an database(sqlite) to load.");
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the sqlite database path.
        /// </summary>
        /// <value>
        /// The sqlite database path.
        /// </value>
        public string SqliteDbPath { get => sqliteDbPath; set => sqliteDbPath = value; }
        /// <summary>
        /// Gets or sets the sqlite database.
        /// </summary>
        /// <value>
        /// The sqlite database.
        /// </value>
        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }

        #endregion

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SqliteDbPath))
            {
                string selectedModelName = cmbDatabaseLoader.SelectedValue.ToString();
                Model model = new Model(SqliteDb, selectedModelName, SqliteDbPath);
                model.ReadModel(string.Format("SELECT * FROM MODEL WHERE NAME='{0}'", selectedModelName));
            }
            else
            {
                MessageBox.Show("Error connectiong to database.");
            }
        }

        private void btnViewModel_Click(object sender, EventArgs e)
        {
            if (cmbDatabaseLoader.SelectedValue != null)
            {
                try
                {
                    string selectedModelName = cmbDatabaseLoader.SelectedValue.ToString();
                    Model model = new Model(SqliteDb, selectedModelName, SqliteDbPath);
                    model.GetNeuronLayerData(string.Format("SELECT * FROM LAYERSNEURONS WHERE MODEL_ID={0}", selectedModelName));
                    model.GetWeightData(string.Format("SELECT * FROM WEIGHTS WHERE MODEL_ID={0}", selectedModelName));

                    gridNLayers.DataSource = model.NeuronLayers;
                    gridWeights.DataSource = model.Weights;

                    btnLoadModel.Enabled = true;
                }
                catch
                {
                    btnLoadModel.Enabled = false;
                    MessageBox.Show("Please select model before load model.");
                }
            }
            else
            {
                MessageBox.Show("Please selected an model to be loaded.");
            }
        }
        #endregion

        #region Methods



        #endregion
    }
}
