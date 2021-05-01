
namespace MyNeuralNetwork
{
    partial class DatabaseConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenSQLiteDialog = new System.Windows.Forms.Button();
            this.btnDatabaseDisconnect = new System.Windows.Forms.Button();
            this.btnDatabaseConnect = new System.Windows.Forms.Button();
            this.btnTestDatabaseConnection = new System.Windows.Forms.Button();
            this.txtDatabasePath = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnOpenSQLiteDialog);
            this.groupBox1.Controls.Add(this.btnDatabaseDisconnect);
            this.groupBox1.Controls.Add(this.btnDatabaseConnect);
            this.groupBox1.Controls.Add(this.btnTestDatabaseConnection);
            this.groupBox1.Controls.Add(this.txtDatabasePath);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Connection Settings";
            // 
            // btnOpenSQLiteDialog
            // 
            this.btnOpenSQLiteDialog.Location = new System.Drawing.Point(536, 40);
            this.btnOpenSQLiteDialog.Name = "btnOpenSQLiteDialog";
            this.btnOpenSQLiteDialog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSQLiteDialog.TabIndex = 4;
            this.btnOpenSQLiteDialog.Text = "Browser";
            this.btnOpenSQLiteDialog.UseVisualStyleBackColor = true;
            this.btnOpenSQLiteDialog.Click += new System.EventHandler(this.btnOpenSQLiteDialog_Click);
            // 
            // btnDatabaseDisconnect
            // 
            this.btnDatabaseDisconnect.Location = new System.Drawing.Point(455, 85);
            this.btnDatabaseDisconnect.Name = "btnDatabaseDisconnect";
            this.btnDatabaseDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseDisconnect.TabIndex = 3;
            this.btnDatabaseDisconnect.Text = "Disconnect";
            this.btnDatabaseDisconnect.UseVisualStyleBackColor = true;
            this.btnDatabaseDisconnect.Click += new System.EventHandler(this.btnDatabaseDisconnect_Click);
            // 
            // btnDatabaseConnect
            // 
            this.btnDatabaseConnect.Location = new System.Drawing.Point(536, 85);
            this.btnDatabaseConnect.Name = "btnDatabaseConnect";
            this.btnDatabaseConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseConnect.TabIndex = 2;
            this.btnDatabaseConnect.Text = "Connect";
            this.btnDatabaseConnect.UseVisualStyleBackColor = true;
            this.btnDatabaseConnect.Click += new System.EventHandler(this.btnDatabaseConnect_Click);
            // 
            // btnTestDatabaseConnection
            // 
            this.btnTestDatabaseConnection.Location = new System.Drawing.Point(7, 85);
            this.btnTestDatabaseConnection.Name = "btnTestDatabaseConnection";
            this.btnTestDatabaseConnection.Size = new System.Drawing.Size(136, 23);
            this.btnTestDatabaseConnection.TabIndex = 1;
            this.btnTestDatabaseConnection.Text = "Test Connection";
            this.btnTestDatabaseConnection.UseVisualStyleBackColor = true;
            this.btnTestDatabaseConnection.Click += new System.EventHandler(this.btnTestDatabaseConnection_Click);
            // 
            // txtDatabasePath
            // 
            this.txtDatabasePath.Location = new System.Drawing.Point(7, 40);
            this.txtDatabasePath.Name = "txtDatabasePath";
            this.txtDatabasePath.Size = new System.Drawing.Size(523, 20);
            this.txtDatabasePath.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(536, 164);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // DatabaseConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 218);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DatabaseConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Connection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenSQLiteDialog;
        private System.Windows.Forms.Button btnDatabaseDisconnect;
        private System.Windows.Forms.Button btnDatabaseConnect;
        private System.Windows.Forms.Button btnTestDatabaseConnection;
        private System.Windows.Forms.TextBox txtDatabasePath;
        private System.Windows.Forms.Button btnReturn;
    }
}