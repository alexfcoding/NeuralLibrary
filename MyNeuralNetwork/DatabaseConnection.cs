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
    //https://www.codeguru.com/csharp/.net/net_data/using-sqlite-in-a-c-application.html#:~:text=To%20connect%20SQLite%20with%20C%23,as%20pictured%20in%20Figure%201.&text=To%20install%20the%20driver%2C%20right,install%20the%20package%20that%20appears.
    public partial class DatabaseConnection : Form
    {
        #region Variables

        private SQLiteConnection sqliteDb;
        private string sqlite_db_path;

        #endregion

        #region Constructors
        public DatabaseConnection(string _sqlite_db_path)
        {
            InitializeComponent();

            this.sqlite_db_path = _sqlite_db_path;
        }
        #endregion

        #region Properties

        public string Sqlite_db_path { get => sqlite_db_path; set => sqlite_db_path = value; }
        public SQLiteConnection SqliteDb { get => sqliteDb; set => sqliteDb = value; }

        #endregion

        #region Methods

        private SQLiteConnection CreateConnection(string path)
        {
            SqliteDb = new SQLiteConnection($"Data Source={path};Version=3;New=True;Compress=True;");

            try
            {
                SqliteDb.Open();
                Sqlite_db_path = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Sqlite_db_path = string.Empty;
            }
            return SqliteDb;
        }

        private bool Disconnect()
        {
            try
            {
                if (SqliteDb != null)
                    SqliteDb.Close();
                    SqliteDb.Dispose();
                    btnDatabaseConnect.Enabled = true;
                    return true; 
            }
            catch
            {
                return false;
            }            
        }

        #endregion

        #region Events

        private void btnOpenSQLiteDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSQLiteDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse SQLite Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "db",
                Filter = "db files (*.db, *.sqlite, *.sqlite3, *.db3)|*.db; *.sqlite; *.sqlite3; *.db3",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openSQLiteDialog.ShowDialog() == DialogResult.OK)
            {
                Sqlite_db_path = txtDatabasePath.Text = openSQLiteDialog.FileName;
                SqliteDb = CreateConnection(Sqlite_db_path);

                btnDatabaseConnect.Enabled = true;
            }
        }

        private void btnTestDatabaseConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDatabasePath.Text))
            {
                MessageBox.Show("Please select database file.");
            }
            else if (!string.IsNullOrWhiteSpace(txtDatabasePath.Text))
            {
                if (SqliteDb != null)
                {
                    if (SqliteDb.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Database connection is open.");
                    }
                    else if (SqliteDb.State == ConnectionState.Closed)
                    {
                        MessageBox.Show("Database connection is closed.");
                    }
                }
            }
        }

        private void btnDatabaseDisconnect_Click(object sender, EventArgs e)
        {
            bool isDisconnected = Disconnect();
            SqliteDb = null;

            if (!isDisconnected)
                MessageBox.Show("Failure to disconnect the database.");
        }

        private void btnDatabaseConnect_Click(object sender, EventArgs e)
        {
            SqliteDb = CreateConnection(txtDatabasePath.Text);
            if (SqliteDb.State == ConnectionState.Open)
            {
                MessageBox.Show("Database connection is open.");
            }
            else if (SqliteDb.State == ConnectionState.Closed)
            {
                MessageBox.Show("Database connection is closed.");
            }
        }

        #endregion

        #region Methods

        public string GetConnetionPath()
        {
            return Sqlite_db_path;
        }

        #endregion

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
