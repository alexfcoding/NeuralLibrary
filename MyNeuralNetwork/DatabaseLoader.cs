using MyNeuralNetwork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNeuralNetwork
{
    public partial class DatabaseLoader : Form
    {
        SQLiteConnection sqliteDb;
        private string sqlite_db_path;

        public DatabaseLoader(string _sqlite_db_path)
        {
            InitializeComponent();

            this.sqlite_db_path = _sqlite_db_path;
        }

        public string Sqlite_db_path { get => sqlite_db_path; set => sqlite_db_path = value; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Sqlite_db_path))
            {
                sqliteDb = new SQLiteConnection($"Data Source={Sqlite_db_path};Version=3;New=True;Compress=True;");
                sqliteDb.Open();

                Model model = new Model(sqliteDb, 1);
                model.ReadModel();
            }
            else
            {
                MessageBox.Show("Error connectiong to database.");
            }
        }

        private void btnViewModel_Click(object sender, EventArgs e)
        {
            Model model = new Model(sqliteDb);
            model.ReadModelPreview();

            foreach (ModelItems item in model.Items)
            {
                
            }
        }
    }
}
